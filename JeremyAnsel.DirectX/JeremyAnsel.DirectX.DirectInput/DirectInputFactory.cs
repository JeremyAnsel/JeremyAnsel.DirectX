// <copyright file="DirectInputFactory.cs" company="Jérémy Ansel">
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
public unsafe class DirectInputFactory : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DirectInputFactoryGuid = typeof(IDirectInput8).GUID;

    private readonly nint _comPtr;
    private readonly IDirectInput8* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DirectInputFactory"/> class.
    /// </summary>
    public DirectInputFactory(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDirectInput8**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    public DirectInputFactory()
        : this(NativeMethods.CreateDInput8())
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="instance"></param>
    /// <returns></returns>
    public bool IsDeviceAttached(in Guid instance)
    {
        int result = _comImpl->GetDeviceStatus(_comPtr, instance);
        return result == 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="instance"></param>
    /// <returns></returns>
    public DirectInputDevice CreateDevice(in Guid instance)
    {
        nint ptr;
        int hr = _comImpl->CreateDevice(_comPtr, instance, &ptr, 0);
        Marshal.ThrowExceptionForHR(hr);
        return new DirectInputDevice(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="deviceClass"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public DirectInputDeviceInfo[] EnumDevices(DirectInputDeviceEnumClasses deviceClass, DirectInputDeviceEnumOptions options)
    {
        List<DirectInputDeviceInfo> diDevices = new();

        int enumDevicesCallback(nint lpddi, nint pvRef)
        {
            DIDEVICEINSTANCE di = *(DIDEVICEINSTANCE*)lpddi;
            diDevices.Add(new DirectInputDeviceInfo(di));
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

        int hr = _comImpl->EnumDevices(_comPtr, diType, enumDevicesCallback, 0, diOptions);
        Marshal.ThrowExceptionForHR(hr);
        return diDevices.ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="hWnd"></param>
    public static void ShowJoystickControlPanel(nint hWnd)
    {
        NativeMethods.ShowJoyCPL(hWnd);
    }
}
