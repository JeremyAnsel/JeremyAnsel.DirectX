// <copyright file="DirectInputDevice.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DirectInputDevice : DXComObject
{
    private DirectInputMouseState? _stateMouse;

    private DirectInputMouseState2? _stateMouse2;

    private DirectInputJoystickState? _stateJoystick;

    private DirectInputJoystickState2? _stateJoystick2;

    private DirectInputKeyboardState? _stateKeyboard;

    private DirectInputDeviceObjectInfo[]? _objectInfos;

    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DirectInputDeviceGuid = typeof(IDirectInputDevice8).GUID;

    private readonly nint _comPtr;
    private readonly IDirectInputDevice8* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectInputDevice"/> class.
    /// </summary>
    public DirectInputDevice(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectInputDevice8**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputDeviceCapabilities GetCapabilities()
    {
        DIDEVCAPS caps = new();
        caps.Size = DXMarshal.SizeOf<DIDEVCAPS>();
        int hr = _comImpl->GetCapabilities(_comPtr, &caps);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectInputDeviceCapabilities(caps);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    public DirectInputDeviceObjectInfo[] EnumObjects(DirectInputObjectDataTypes filter)
    {
        List<DirectInputDeviceObjectInfo> diObjects = new();

        int enumObjectsCallback(nint lpddoi, IntPtr pvRef)
        {
            DIDEVICEOBJECTINSTANCE doi = *(DIDEVICEOBJECTINSTANCE*)lpddoi;
            diObjects.Add(new DirectInputDeviceObjectInfo(doi));
            return DirectInputConstants.EnumContinue;
        }

        int hr = _comImpl->EnumObjects(_comPtr, enumObjectsCallback, 0, (uint)filter);
        Marshal.ThrowExceptionForHR(hr);
        return diObjects.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="how"></param>
    /// <param name="obj"></param>
    /// <param name="value"></param>
    public void GetPropertyUInt(DirectInputPropertyTypes prop, DirectInputHowTypes how, int obj, out uint value)
    {
        DIPROPDWORD diProp;
        diProp.Header.Size = DXMarshal.SizeOf<DIPROPDWORD>();
        diProp.Header.HeaderSize = DXMarshal.SizeOf<DIPROPHEADER>();
        diProp.Header.How = (DIPH)(uint)how;
        diProp.Header.Obj = obj;
        int hr = _comImpl->GetProperty(_comPtr, (nint)prop, &diProp);
        Marshal.ThrowExceptionForHR(hr);
        value = diProp.Data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="how"></param>
    /// <param name="obj"></param>
    /// <param name="value"></param>
    public void SetPropertyUInt(DirectInputPropertyTypes prop, DirectInputHowTypes how, int obj, uint value)
    {
        DIPROPDWORD diProp;
        diProp.Header.Size = DXMarshal.SizeOf<DIPROPDWORD>();
        diProp.Header.HeaderSize = DXMarshal.SizeOf<DIPROPHEADER>();
        diProp.Header.How = (DIPH)(uint)how;
        diProp.Header.Obj = obj;
        diProp.Data = value;
        int hr = _comImpl->SetProperty(_comPtr, (nint)prop, &diProp);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="how"></param>
    /// <param name="obj"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public void GetPropertyRange(DirectInputPropertyTypes prop, DirectInputHowTypes how, int obj, out int min, out int max)
    {
        DIPROPRANGE diProp;
        diProp.Header.Size = DXMarshal.SizeOf<DIPROPRANGE>();
        diProp.Header.HeaderSize = DXMarshal.SizeOf<DIPROPHEADER>();
        diProp.Header.How = (DIPH)(uint)how;
        diProp.Header.Obj = obj;
        int hr = _comImpl->GetProperty(_comPtr, (nint)prop, &diProp);
        Marshal.ThrowExceptionForHR(hr);
        min = diProp.Min;
        max = diProp.Max;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prop"></param>
    /// <param name="how"></param>
    /// <param name="obj"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    public void SetPropertyRange(DirectInputPropertyTypes prop, DirectInputHowTypes how, int obj, int min, int max)
    {
        DIPROPRANGE diProp;
        diProp.Header.Size = Marshal.SizeOf<DIPROPRANGE>();
        diProp.Header.HeaderSize = Marshal.SizeOf<DIPROPHEADER>();
        diProp.Header.How = (DIPH)(uint)how;
        diProp.Header.Obj = obj;
        diProp.Min = min;
        diProp.Max = max;
        int hr = _comImpl->SetProperty(_comPtr, (nint)prop, &diProp);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Acquire()
    {
        int hr = _comImpl->Acquire(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    public void Unacquire()
    {
        int hr = _comImpl->Unacquire(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cbData"></param>
    /// <param name="lpvData"></param>
    public void GetDeviceState(int cbData, void* lpvData)
    {
        int hr = _comImpl->GetDeviceState(_comPtr, cbData, lpvData);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputMouseState GetDeviceStateForMouse()
    {
        DIMouseState data;
        GetDeviceState(DXMarshal.SizeOf<DIMouseState>(), &data);
        _stateMouse ??= new DirectInputMouseState();
        _stateMouse.Update(data);
        return _stateMouse;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputMouseState2 GetDeviceStateForMouse2()
    {
        DIMouseState2 data;
        GetDeviceState(DXMarshal.SizeOf<DIMouseState2>(), &data);
        _stateMouse2 ??= new DirectInputMouseState2();
        _stateMouse2.Update(data);
        return _stateMouse2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputJoystickState GetDeviceStateForJoystick()
    {
        DIJoystickState data;
        GetDeviceState(DXMarshal.SizeOf<DIJoystickState>(), &data);
        _stateJoystick ??= new DirectInputJoystickState();
        _stateJoystick.Update(data);
        return _stateJoystick;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputJoystickState2 GetDeviceStateForJoystick2()
    {
        DIJoystickState2 data;
        GetDeviceState(DXMarshal.SizeOf<DIJoystickState2>(), &data);
        _stateJoystick2 ??= new DirectInputJoystickState2();
        _stateJoystick2.Update(data);
        return _stateJoystick2;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputKeyboardState GetDeviceStateForKeyboard()
    {
        _stateKeyboard ??= new DirectInputKeyboardState();

        fixed (void* ptr = _stateKeyboard.Data)
        {
            GetDeviceState(256, ptr);
        }

        return _stateKeyboard;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    public void SetDataFormat(DirectInputDataFormat? format)
    {
        if (format is null)
        {
            throw new ArgumentNullException(nameof(format));
        }

        int diDataFormatSize = DXMarshal.SizeOf<DIDATAFORMAT>();
        int diObjectDataFormatSize = DXMarshal.SizeOf<DIOBJECTDATAFORMAT>();
        int guidSize = DXMarshal.SizeOf<Guid>();
        int globalSize = diDataFormatSize + (diObjectDataFormatSize + guidSize) * format.ObjectDataFormats.Length;
        int objectsIndex = diDataFormatSize;
        int guidsIndex = diDataFormatSize + diObjectDataFormatSize * format.ObjectDataFormats.Length;

        nint globalPtr = Marshal.AllocHGlobal(globalSize);

        try
        {
            DIDATAFORMAT dataFormat;
            dataFormat.Size = diDataFormatSize;
            dataFormat.ObjSize = diObjectDataFormatSize;
            dataFormat.Flags = (uint)format.Options;
            dataFormat.DataSize = format.DataSize;
            dataFormat.NumObjs = format.ObjectDataFormats.Length;
            dataFormat.rgodf = globalPtr + diDataFormatSize;
            DXMarshal.WriteStructure(globalPtr, dataFormat);

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
                DXMarshal.WriteStructure(globalPtr + objectIndex, objectDataFormat);

                if (objectFormat.Guid is not null)
                {
                    DXMarshal.WriteStructure(globalPtr + guidIndex, objectFormat.Guid.Value);
                }
            }

            int hr = _comImpl->SetDataFormat(_comPtr, globalPtr);
            Marshal.ThrowExceptionForHR(hr);
        }
        finally
        {
            Marshal.FreeHGlobal(globalPtr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetDataFormatForMouse()
    {
        SetDataFormat(DIDataFormats.c_dfDIMouse);
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetDataFormatForMouse2()
    {
        SetDataFormat(DIDataFormats.c_dfDIMouse2);
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetDataFormatForJoystick()
    {
        SetDataFormat(DIDataFormats.c_dfDIJoystick);
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetDataFormatForJoystick2()
    {
        SetDataFormat(DIDataFormats.c_dfDIJoystick2);
    }

    /// <summary>
    /// 
    /// </summary>
    public void SetDataFormatForKeyboard()
    {
        SetDataFormat(DIDataFormats.c_dfDIKeyboard);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hWnd"></param>
    /// <param name="level"></param>
    public void SetCooperativeLevel(nint hWnd, DirectInputCooperativeLevels level)
    {
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

        int hr = _comImpl->SetCooperativeLevel(_comPtr, hWnd, diLevel);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objType"></param>
    /// <returns></returns>
    public DirectInputDeviceObjectInfo GetObjectInfo(uint objType)
    {
        DIDEVICEOBJECTINSTANCE diInfo = new();
        diInfo.Size = DXMarshal.SizeOf<DIDEVICEOBJECTINSTANCE>();
        int hr = _comImpl->GetObjectInfo(_comPtr, &diInfo, objType, DIPH.BYID);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectInputDeviceObjectInfo(diInfo);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputDeviceInfo GetDeviceInfo()
    {
        DIDEVICEINSTANCE diInfo = new();
        diInfo.Size = DXMarshal.SizeOf<DIDEVICEINSTANCE>();
        int hr = _comImpl->GetDeviceInfo(_comPtr, &diInfo);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectInputDeviceInfo(diInfo);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hWnd"></param>
    public void RunControlPanel(nint hWnd)
    {
        int hr = _comImpl->RunControlPanel(_comPtr, hWnd, 0);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guid"></param>
    /// <param name="lpeff"></param>
    /// <returns></returns>
    public DirectInputEffect CreateEffect(in Guid guid, DirectInputEffectParametersData? lpeff)
    {
        nint ptr;
        int hr;

        if (lpeff is null)
        {
            hr = _comImpl->CreateEffect(_comPtr, guid, 0, &ptr, 0);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            nint data = lpeff.ToRawData(DirectInputEffectParameterOptions.AllParams);

            try
            {
                hr = _comImpl->CreateEffect(_comPtr, guid, data, &ptr, 0);
                Marshal.ThrowExceptionForHR(hr);
            }
            finally
            {
                DirectInputEffectParametersData.FreeRawData(data);
            }
        }

        nint _effectPtr = ptr;
        IDirectInputEffect* _effectImpl = *(IDirectInputEffect**)ptr;
        Guid pguid;
        hr = _effectImpl->GetEffectGuid(_effectPtr, &pguid);
        Marshal.ThrowExceptionForHR(hr);
        DirectInputEffectInfo infos = GetEffectInfo(pguid);
        return new DirectInputEffect(ptr, infos);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="effectType"></param>
    /// <param name="lpeff"></param>
    /// <returns></returns>
    public DirectInputEffect CreateEffect(DirectInputDefaultEffectType effectType, DirectInputEffectParametersData? lpeff)
    {
        return effectType switch
        {
            DirectInputDefaultEffectType.ConstantForce => CreateEffect(DirectInputGuids.ConstantForce, lpeff),
            DirectInputDefaultEffectType.RampForce => CreateEffect(DirectInputGuids.RampForce, lpeff),
            DirectInputDefaultEffectType.Square => CreateEffect(DirectInputGuids.Square, lpeff),
            DirectInputDefaultEffectType.Sine => CreateEffect(DirectInputGuids.Sine, lpeff),
            DirectInputDefaultEffectType.Triangle => CreateEffect(DirectInputGuids.Triangle, lpeff),
            DirectInputDefaultEffectType.SawtoothUp => CreateEffect(DirectInputGuids.SawtoothUp, lpeff),
            DirectInputDefaultEffectType.SawtoothDown => CreateEffect(DirectInputGuids.SawtoothDown, lpeff),
            DirectInputDefaultEffectType.Spring => CreateEffect(DirectInputGuids.Spring, lpeff),
            DirectInputDefaultEffectType.Damper => CreateEffect(DirectInputGuids.Damper, lpeff),
            DirectInputDefaultEffectType.Inertia => CreateEffect(DirectInputGuids.Inertia, lpeff),
            DirectInputDefaultEffectType.Friction => CreateEffect(DirectInputGuids.Friction, lpeff),
            DirectInputDefaultEffectType.CustomForce => CreateEffect(DirectInputGuids.CustomForce, lpeff),
            _ => throw new ArgumentOutOfRangeException(nameof(effectType)),
        };
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="effectType"></param>
    /// <returns></returns>
    public DirectInputEffectInfo[] EnumEffects(DirectInputEffectTypes effectType)
    {
        List<DirectInputEffectInfo> diEffects = new();

        int enumEffectsCallback(nint pdei, nint pvRef)
        {
            DIEFFECTINFO dei = *(DIEFFECTINFO*)pdei;
            diEffects.Add(new DirectInputEffectInfo(dei));
            return DirectInputConstants.EnumContinue;
        }

        int hr = _comImpl->EnumEffects(_comPtr, enumEffectsCallback, 0, (uint)effectType);
        Marshal.ThrowExceptionForHR(hr);
        return diEffects.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public DirectInputEffectInfo GetEffectInfo(in Guid guid)
    {
        DIEFFECTINFO pdei;
        pdei.Size = DXMarshal.SizeOf<DIEFFECTINFO>();
        int hr = _comImpl->GetEffectInfo(_comPtr, &pdei, guid);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectInputEffectInfo(pdei);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputForceFeedbackStates GetForceFeedbackState()
    {
        uint state;
        int hr = _comImpl->GetForceFeedbackState(_comPtr, &state);
        Marshal.ThrowExceptionForHR(hr);
        return (DirectInputForceFeedbackStates)state;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="command"></param>
    public void SendForceFeedbackCommand(DirectInputForceFeedbackCommands command)
    {
        int hr = _comImpl->SendForceFeedbackCommand(_comPtr, (uint)command);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DirectInputEffect[] EnumCreatedEffectObjects()
    {
        List<DirectInputEffect> diEffects = new();

        int enumCreatedEffectObjectsCallback(nint peff, nint pvRef)
        {
            nint _effectPtr = peff;
            IDirectInputEffect* _effectImpl = *(IDirectInputEffect**)peff;
            Guid pguid;
            int hr = _effectImpl->GetEffectGuid(_effectPtr, &pguid);
            Marshal.ThrowExceptionForHR(hr);
            DirectInputEffectInfo infos = GetEffectInfo(pguid);
            diEffects.Add(new DirectInputEffect(peff, infos));
            return DirectInputConstants.EnumContinue;
        }

        int hr = _comImpl->EnumCreatedEffectObjects(_comPtr, enumCreatedEffectObjectsCallback, 0, 0);
        Marshal.ThrowExceptionForHR(hr);
        return diEffects.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Poll()
    {
        int hr = _comImpl->Poll(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
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
