using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputFactory : IDisposable
{
    private IDirectInput8? _handle;

    public DirectInputFactory()
    {
        IntPtr hinst = NativeMethods.GetModuleHandle(null);
        _handle = NativeMethods.CreateDInput8(hinst);

        if (_handle is null)
        {
            throw new InvalidOperationException("DirectInput factory creation failed.");
        }
    }

    public object Handle => _handle ?? throw new ObjectDisposedException(nameof(_handle));

    public void Dispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }
    }

    public bool IsDeviceAttached(in Guid instance)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        int result = _handle.GetDeviceStatus(instance);
        return result == 0;
    }

    public DirectInputDevice CreateDevice(in Guid instance)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateDevice(instance, out IDirectInputDevice8? device, IntPtr.Zero);
        return new DirectInputDevice(device);
    }

    public DirectInputDeviceInfo[] EnumDevices(DirectInputDeviceEnumClasses deviceClass, DirectInputDeviceEnumOptions options)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        List<DIDEVICEINSTANCE> diDevices = new();

        int enumDevicesCallback(in DIDEVICEINSTANCE lpddi, IntPtr pvRef)
        {
            diDevices.Add(lpddi);
            return DirectInputConstants.EnumContinue;
        }

        DI8DEVCLASS diType = deviceClass switch
        {
            DirectInputDeviceEnumClasses.All => DI8DEVCLASS.ALL,
            DirectInputDeviceEnumClasses.Device => DI8DEVCLASS.DEVICE,
            DirectInputDeviceEnumClasses.Pointer => DI8DEVCLASS.POINTER,
            DirectInputDeviceEnumClasses.Keyboard => DI8DEVCLASS.KEYBOARD,
            DirectInputDeviceEnumClasses.GameController => DI8DEVCLASS.GAMECTRL,
            _ => throw new ArgumentOutOfRangeException(nameof(deviceClass))
        };

        DIEDFL diOptions = DIEDFL.ALLDEVICES;

        if (options.HasFlag(DirectInputDeviceEnumOptions.AttachedOnly))
        {
            diOptions |= DIEDFL.ATTACHEDONLY;
        }

        if (options.HasFlag(DirectInputDeviceEnumOptions.ForceFeedback))
        {
            diOptions |= DIEDFL.FORCEFEEDBACK;
        }

        if (options.HasFlag(DirectInputDeviceEnumOptions.IncludeAliases))
        {
            diOptions |= DIEDFL.INCLUDEALIASES;
        }

        if (options.HasFlag(DirectInputDeviceEnumOptions.IncludePhantoms))
        {
            diOptions |= DIEDFL.INCLUDEPHANTOMS;
        }

        if (options.HasFlag(DirectInputDeviceEnumOptions.IncludeHidden))
        {
            diOptions |= DIEDFL.INCLUDEHIDDEN;
        }

        _handle.EnumDevices(diType, enumDevicesCallback, IntPtr.Zero, diOptions);

        DirectInputDeviceInfo[] devices = Array.ConvertAll(diDevices.ToArray(), t => new DirectInputDeviceInfo(t));
        return devices;
    }

    public static void ShowJoystickControlPanel(IntPtr hWnd)
    {
        NativeMethods.ShowJoyCPL(hWnd);
    }
}
