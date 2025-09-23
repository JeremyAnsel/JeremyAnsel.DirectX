using System.Data;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputDevice : IDisposable
{
    private IDirectInputDevice8? _handle;

    private DirectInputMouseState? _stateMouse;

    private DirectInputMouseState2? _stateMouse2;

    private DirectInputJoystickState? _stateJoystick;

    private DirectInputJoystickState2? _stateJoystick2;

    private DirectInputKeyboardState? _stateKeyboard;

    private DirectInputDeviceObjectInfo[]? _objectInfos;

    internal DirectInputDevice(IDirectInputDevice8? handle)
    {
        if (handle is null)
        {
            throw new ArgumentNullException(nameof(handle));
        }

        _handle = handle;
    }

    public void Dispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }
    }

    public DirectInputDeviceCapabilities GetCapabilities()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        DIDEVCAPS caps = new();
        caps.Size = Marshal.SizeOf<DIDEVCAPS>();
        _handle.GetCapabilities(ref caps);

        return new DirectInputDeviceCapabilities(caps);
    }

    public DirectInputDeviceObjectInfo[] EnumObjects(DirectInputObjectDataTypes filter)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        List<DIDEVICEOBJECTINSTANCE> diObjects = new();

        int enumObjectsCallback(in DIDEVICEOBJECTINSTANCE lpddoi, IntPtr pvRef)
        {
            diObjects.Add(lpddoi);
            return DirectInputConstants.EnumContinue;
        }

        DIDFT diFilter = (DIDFT)(uint)filter;
        _handle.EnumObjects(enumObjectsCallback, IntPtr.Zero, diFilter);

        DirectInputDeviceObjectInfo[] objects = Array.ConvertAll(diObjects.ToArray(), t => new DirectInputDeviceObjectInfo(t));
        return objects;
    }

    public void Acquire()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Acquire();
    }

    public void Unacquire()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Unacquire();
    }

    public void GetDeviceState(int cbData, IntPtr lpvData)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetDeviceState(cbData, lpvData);
    }

    public unsafe DirectInputMouseState GetDeviceStateForMouse()
    {
        DIMouseState data = default;
        GetDeviceState(Marshal.SizeOf<DIMouseState>(), new IntPtr(&data));
        _stateMouse ??= new DirectInputMouseState();
        _stateMouse.Update(data);
        return _stateMouse;
    }

    public unsafe DirectInputMouseState2 GetDeviceStateForMouse2()
    {
        DIMouseState2 data = default;
        GetDeviceState(Marshal.SizeOf<DIMouseState2>(), new IntPtr(&data));
        _stateMouse2 ??= new DirectInputMouseState2();
        _stateMouse2.Update(data);
        return _stateMouse2;
    }

    public unsafe DirectInputJoystickState GetDeviceStateForJoystick()
    {
        DIJoystickState data = default;
        GetDeviceState(Marshal.SizeOf<DIJoystickState>(), new IntPtr(&data));
        _stateJoystick ??= new DirectInputJoystickState();
        _stateJoystick.Update(data);
        return _stateJoystick;
    }

    public unsafe DirectInputJoystickState2 GetDeviceStateForJoystick2()
    {
        DIJoystickState2 data = default;
        GetDeviceState(Marshal.SizeOf<DIJoystickState2>(), new IntPtr(&data));
        _stateJoystick2 ??= new DirectInputJoystickState2();
        _stateJoystick2.Update(data);
        return _stateJoystick2;
    }

    public unsafe DirectInputKeyboardState GetDeviceStateForKeyboard()
    {
        _stateKeyboard ??= new DirectInputKeyboardState();

        fixed (void* ptr = _stateKeyboard.Data)
        {
            GetDeviceState(256, new IntPtr(ptr));
        }

        return _stateKeyboard;
    }

    public void SetDataFormat(DirectInputDataFormat? format)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (format is null)
        {
            throw new ArgumentNullException(nameof(format));
        }

        int diDataFormatSize = Marshal.SizeOf<DIDATAFORMAT>();
        int diObjectDataFormatSize = Marshal.SizeOf<DIOBJECTDATAFORMAT>();
        int guidSize = Marshal.SizeOf<Guid>();
        int globalSize = diDataFormatSize + (diObjectDataFormatSize + guidSize) * format.ObjectDataFormats.Length;
        int objectsIndex = diDataFormatSize;
        int guidsIndex = diDataFormatSize + diObjectDataFormatSize * format.ObjectDataFormats.Length;

        IntPtr globalPtr = Marshal.AllocHGlobal(globalSize);

        try
        {
            DIDATAFORMAT dataFormat;
            dataFormat.Size = diDataFormatSize;
            dataFormat.ObjSize = diObjectDataFormatSize;
            dataFormat.Flags = (uint)format.Options;
            dataFormat.DataSize = format.DataSize;
            dataFormat.NumObjs = format.ObjectDataFormats.Length;
            dataFormat.rgodf = globalPtr + diDataFormatSize;
            Marshal.StructureToPtr(dataFormat, globalPtr, false);

            for (int objectFormatIndex = 0; objectFormatIndex < format.ObjectDataFormats.Length; objectFormatIndex++)
            {
                DirectInputObjectDataFormat objectFormat = format.ObjectDataFormats[objectFormatIndex];
                int objectIndex = objectsIndex + diObjectDataFormatSize * objectFormatIndex;
                int guidIndex = guidsIndex + guidSize * objectFormatIndex;

                DIOBJECTDATAFORMAT objectDataFormat;
                objectDataFormat.Guid = objectFormat.Guid is null ? IntPtr.Zero : (globalPtr + guidIndex);
                objectDataFormat.Ofs = objectFormat.Offset;
                objectDataFormat.Type = (uint)objectFormat.DataType | ((uint)(ushort)objectFormat.DataInstance << 8);
                objectDataFormat.Flags = (uint)objectFormat.Options;
                Marshal.StructureToPtr(objectDataFormat, globalPtr + objectIndex, false);

                if (objectFormat.Guid is not null)
                {
                    Marshal.StructureToPtr(objectFormat.Guid.Value, globalPtr + guidIndex, false);
                }
            }

            _handle.SetDataFormat(globalPtr);
        }
        finally
        {
            Marshal.FreeHGlobal(globalPtr);
        }
    }

    public void SetDataFormatForMouse()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        SetDataFormat(DIDataFormats.c_dfDIMouse);
    }

    public void SetDataFormatForMouse2()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        SetDataFormat(DIDataFormats.c_dfDIMouse2);
    }

    public void SetDataFormatForJoystick()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        SetDataFormat(DIDataFormats.c_dfDIJoystick);
    }

    public void SetDataFormatForJoystick2()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        SetDataFormat(DIDataFormats.c_dfDIJoystick2);
    }

    public void SetDataFormatForKeyboard()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        SetDataFormat(DIDataFormats.c_dfDIKeyboard);
    }

    public void SetCooperativeLevel(IntPtr hWnd, DirectInputCooperativeLevels level)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        DISCL diLevel = 0;

        if (level.HasFlag(DirectInputCooperativeLevels.Exclusive))
        {
            diLevel |= DISCL.EXCLUSIVE;
        }

        if (level.HasFlag(DirectInputCooperativeLevels.NonExclusive))
        {
            diLevel |= DISCL.NONEXCLUSIVE;
        }

        if (level.HasFlag(DirectInputCooperativeLevels.Foreground))
        {
            diLevel |= DISCL.FOREGROUND;
        }

        if (level.HasFlag(DirectInputCooperativeLevels.Background))
        {
            diLevel |= DISCL.BACKGROUND;
        }

        if (level.HasFlag(DirectInputCooperativeLevels.NoWinKey))
        {
            diLevel |= DISCL.NOWINKEY;
        }

        _handle.SetCooperativeLevel(hWnd, diLevel);
    }

    public DirectInputDeviceObjectInfo GetObjectInfo(uint objType)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        DIDEVICEOBJECTINSTANCE diInfo = new();
        diInfo.Size = Marshal.SizeOf<DIDEVICEOBJECTINSTANCE>();
        _handle.GetObjectInfo(ref diInfo, objType, DIPH.BYID);
        return new DirectInputDeviceObjectInfo(diInfo);
    }

    public DirectInputDeviceInfo GetDeviceInfo()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        DIDEVICEINSTANCE diInfo = new();
        diInfo.Size = Marshal.SizeOf<DIDEVICEINSTANCE>();
        _handle.GetDeviceInfo(ref diInfo);
        return new DirectInputDeviceInfo(diInfo);
    }

    public void RunControlPanel(IntPtr hWnd)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.RunControlPanel(hWnd, 0);
    }

    public DirectInputEffect? CreateEffect(in Guid guid, DirectInputEffectParametersData? lpeff)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        IDirectInputEffect? effect;

        if (lpeff is null)
        {
            _handle.CreateEffect(guid, IntPtr.Zero, out effect, IntPtr.Zero);
        }
        else
        {
            IntPtr ptr = lpeff.ToRawData(DirectInputEffectParameterOptions.AllParams);

            try
            {
                _handle.CreateEffect(guid, ptr, out effect, IntPtr.Zero);
            }
            finally
            {
                DirectInputEffectParametersData.FreeRawData(ptr);
            }
        }

        if (effect is null)
        {
            return null;
        }

        effect.GetEffectGuid(out Guid pguid);
        DirectInputEffectInfo infos = GetEffectInfo(pguid);

        return new DirectInputEffect(effect, infos);
    }

    public DirectInputEffect? CreateEffect(DirectInputDefaultEffectType effectType, DirectInputEffectParametersData? lpeff)
    {
        switch (effectType)
        {
            case DirectInputDefaultEffectType.ConstantForce:
                return CreateEffect(DirectInputGuids.ConstantForce, lpeff);

            case DirectInputDefaultEffectType.RampForce:
                return CreateEffect(DirectInputGuids.RampForce, lpeff);

            case DirectInputDefaultEffectType.Square:
                return CreateEffect(DirectInputGuids.Square, lpeff);

            case DirectInputDefaultEffectType.Sine:
                return CreateEffect(DirectInputGuids.Sine, lpeff);

            case DirectInputDefaultEffectType.Triangle:
                return CreateEffect(DirectInputGuids.Triangle, lpeff);

            case DirectInputDefaultEffectType.SawtoothUp:
                return CreateEffect(DirectInputGuids.SawtoothUp, lpeff);

            case DirectInputDefaultEffectType.SawtoothDown:
                return CreateEffect(DirectInputGuids.SawtoothDown, lpeff);

            case DirectInputDefaultEffectType.Spring:
                return CreateEffect(DirectInputGuids.Spring, lpeff);

            case DirectInputDefaultEffectType.Damper:
                return CreateEffect(DirectInputGuids.Damper, lpeff);

            case DirectInputDefaultEffectType.Inertia:
                return CreateEffect(DirectInputGuids.Inertia, lpeff);

            case DirectInputDefaultEffectType.Friction:
                return CreateEffect(DirectInputGuids.Friction, lpeff);

            case DirectInputDefaultEffectType.CustomForce:
                return CreateEffect(DirectInputGuids.CustomForce, lpeff);
        }

        return null;
    }

    public DirectInputEffectInfo[] EnumEffects(DirectInputEffectTypes effectType)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        List<DIEFFECTINFO> diEffects = new();

        int enumEffectsCallback(in DIEFFECTINFO pdei, IntPtr pvRef)
        {
            diEffects.Add(pdei);
            return DirectInputConstants.EnumContinue;
        }

        _handle.EnumEffects(enumEffectsCallback, IntPtr.Zero, (DIEFT)(uint)effectType);

        DirectInputEffectInfo[] effects = Array.ConvertAll(diEffects.ToArray(), t => new DirectInputEffectInfo(t));
        return effects;
    }

    public DirectInputEffectInfo GetEffectInfo(Guid guid)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        DIEFFECTINFO pdei = default;
        pdei.Size = Marshal.SizeOf<DIEFFECTINFO>();
        _handle.GetEffectInfo(ref pdei, guid);
        return new DirectInputEffectInfo(pdei);
    }

    public DirectInputForceFeedbackStates GetForceFeedbackState()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetForceFeedbackState(out DIGFFS state);
        return (DirectInputForceFeedbackStates)(uint)state;
    }

    public void SendForceFeedbackCommand(DirectInputForceFeedbackCommands command)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SendForceFeedbackCommand((DISFFC)(uint)command);
    }

    public DirectInputEffect[] EnumCreatedEffectObjects()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        List<IDirectInputEffect> diEffects = new();

        int enumCreatedEffectObjectsCallback(IDirectInputEffect peff, IntPtr pvRef)
        {
            diEffects.Add(peff);
            return DirectInputConstants.EnumContinue;
        }

        _handle.EnumCreatedEffectObjects(enumCreatedEffectObjectsCallback, IntPtr.Zero, 0);

        DirectInputEffect[] effects = Array.ConvertAll(diEffects.ToArray(), t =>
        {
            t.GetEffectGuid(out Guid pguid);
            DirectInputEffectInfo infos = GetEffectInfo(pguid);
            return new DirectInputEffect(t, infos);
        });

        return effects;
    }

    public void Poll()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Poll();
    }

    public string GetMouseObjectName(DirectInputMouseObjects o)
    {
        _objectInfos ??= EnumObjects(DirectInputObjectDataTypes.All);

        DirectInputObjectDataTypes dataType = (DirectInputObjectDataTypes)(((uint)o & 0xff0000) >> 16);
        int dataInstance = (int)((uint)o & 0xffff);

        DirectInputDeviceObjectInfo? info = _objectInfos
            .Where(t => t.DataType.HasFlag(dataType) && t.DataInstance == dataInstance)
            .FirstOrDefault();

        if (info is null)
        {
            return o.ToString();
        }

        return info.Name;
    }

    public string GetMouse2ObjectName(DirectInputMouse2Objects o)
    {
        _objectInfos ??= EnumObjects(DirectInputObjectDataTypes.All);

        DirectInputObjectDataTypes dataType = (DirectInputObjectDataTypes)(((uint)o & 0xff0000) >> 16);
        int dataInstance = (int)((uint)o & 0xffff);

        DirectInputDeviceObjectInfo? info = _objectInfos
            .Where(t => t.DataType.HasFlag(dataType) && t.DataInstance == dataInstance)
            .FirstOrDefault();

        if (info is null)
        {
            return o.ToString();
        }

        return info.Name;
    }

    public string GetJoystickObjectName(DirectInputJoystickObjects o)
    {
        _objectInfos ??= EnumObjects(DirectInputObjectDataTypes.All);

        DirectInputObjectDataTypes dataType = (DirectInputObjectDataTypes)(((uint)o & 0xff0000) >> 16);
        int dataInstance = (int)((uint)o & 0xffff);

        DirectInputDeviceObjectInfo? info = _objectInfos
            .Where(t => t.DataType.HasFlag(dataType) && t.DataInstance == dataInstance)
            .FirstOrDefault();

        if (info is null)
        {
            return o.ToString();
        }

        return info.Name;
    }

    public string GetJoystick2ObjectName(DirectInputJoystick2Objects o)
    {
        _objectInfos ??= EnumObjects(DirectInputObjectDataTypes.All);

        DirectInputObjectDataTypes dataType = (DirectInputObjectDataTypes)(((uint)o & 0xff0000) >> 16);
        int dataInstance = (int)((uint)o & 0xffff);

        DirectInputDeviceObjectInfo? info = _objectInfos
            .Where(t => t.DataType.HasFlag(dataType) && t.DataInstance == dataInstance)
            .FirstOrDefault();

        if (info is null)
        {
            return o.ToString();
        }

        return info.Name;
    }

    public string GetKeyboardObjectName(DirectInputKeyboardKeys key)
    {
        _objectInfos ??= EnumObjects(DirectInputObjectDataTypes.All);

        int index = (int)key;

        DirectInputDeviceObjectInfo? info = _objectInfos
            .Where(t => t.DataType.HasFlag(DirectInputObjectDataTypes.PushButton) && t.DataInstance == index)
            .FirstOrDefault();

        if (info is null)
        {
            return key.ToString();
        }

        return info.Name;
    }
}
