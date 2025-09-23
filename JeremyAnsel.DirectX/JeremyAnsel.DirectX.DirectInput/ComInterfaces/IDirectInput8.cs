using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

internal delegate int LPDIENUMDEVICESCALLBACK(in DIDEVICEINSTANCE lpddi, IntPtr pvRef);

internal delegate int LPDIENUMDEVICESBYSEMANTICSCB(in DIDEVICEINSTANCE lpddi, IDirectInputDevice8? lpdid, DIEDBS dwFlags, int dwRemaining, IntPtr pvRef);

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid(DirectInputGuids.IDirectInput8WString)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDirectInput8
{
    void CreateDevice(
        [In] in Guid rguid,
        [Out] out IDirectInputDevice8? pOut,
        [In] IntPtr pUnkOuter);

    void EnumDevices(
        [In] DI8DEVCLASS dwDevType,
        [In, MarshalAs(UnmanagedType.FunctionPtr)] LPDIENUMDEVICESCALLBACK lpCallback,
        [In] IntPtr pvRef,
        [In] DIEDFL dwFlags);

    [PreserveSig]
    int GetDeviceStatus(
        [In] in Guid rguidInstance);

    void RunControlPanel(
        [In] IntPtr hwndOwner,
        [In] int dwFlags);

    void Initialize(
        [In] IntPtr hinst,
        [In] int dwVersion);

    void FindDevice(
        [In] in Guid rguidClass,
        [In, MarshalAs(UnmanagedType.LPWStr)] string ptszName,
        [Out] out Guid pguidInstance);

    void EnumDevicesBySemantics(
        [In, MarshalAs(UnmanagedType.LPWStr)] string? ptszUserName,
        [In] in DIACTIONFORMAT lpdiActionFormat,
        [In, MarshalAs(UnmanagedType.FunctionPtr)] LPDIENUMDEVICESBYSEMANTICSCB lpCallback,
        [In] IntPtr pvRef,
        [In] DIEDBSFL dwFlags);

    void ConfigureDevices(
        [In] IntPtr lpdiCallback,
        [In] IntPtr lpdiCDParams,
        [In] int dwFlags,
        [In] IntPtr pvRefData);
}
