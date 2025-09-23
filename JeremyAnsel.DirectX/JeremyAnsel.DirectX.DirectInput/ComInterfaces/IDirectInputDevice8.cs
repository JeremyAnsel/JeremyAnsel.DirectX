using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

internal delegate int LPDIENUMDEVICEOBJECTSCALLBACK(in DIDEVICEOBJECTINSTANCE lpddoi, IntPtr pvRef);

internal delegate int LPDIENUMEFFECTSCALLBACK(in DIEFFECTINFO pdei, IntPtr pvRef);

internal delegate int LPDIENUMCREATEDEFFECTOBJECTSCALLBACK(IDirectInputEffect peff, IntPtr pvRef);

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid(DirectInputGuids.IDirectInputDevice8WString)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDirectInputDevice8
{
    void GetCapabilities(
        [In, Out] ref DIDEVCAPS lpDIDevCaps);

    void EnumObjects(
        [In, MarshalAs(UnmanagedType.FunctionPtr)] LPDIENUMDEVICEOBJECTSCALLBACK lpCallback,
        [In] IntPtr pvRef,
        [In] DIDFT dwFlags);

    void GetProperty(
        [In] IntPtr rguidProp,
        [In] IntPtr pdiph);

    void SetProperty(
        [In] IntPtr rguidProp,
        [In] IntPtr pdiph);

    void Acquire();

    void Unacquire();

    void GetDeviceState(
        [In] int cbData,
        [In] IntPtr lpvData);

    void GetDeviceData(
        [In] int cbObjectData,
        [In, MarshalAs(UnmanagedType.LPArray)] DIDEVICEOBJECTDATA[]? rgdod,
        [In, Out] ref int pdwInOut,
        [In] DIGDD dwFlags);

    void SetDataFormat(
        [In] IntPtr lpdf);

    void SetEventNotification(
        [In] IntPtr hEvent);

    void SetCooperativeLevel(
        [In] IntPtr hwnd,
        [In] DISCL dwFlags);

    void GetObjectInfo(
        [In] ref DIDEVICEOBJECTINSTANCE pdidoi,
        [In] uint dwObj,
        [In] DIPH dwHow);

    void GetDeviceInfo(
        [In] ref DIDEVICEINSTANCE pdidi);

    void RunControlPanel(
        [In] IntPtr hwndOwner,
        [In] int dwFlags);

    void Initialize();

    void CreateEffect(
        [In] in Guid rguid,
        [In] IntPtr lpeff,
        [Out] out IDirectInputEffect? ppdeff,
        [In] IntPtr punkOuter);

    void EnumEffects(
        [In, MarshalAs(UnmanagedType.FunctionPtr)] LPDIENUMEFFECTSCALLBACK lpCallback,
        [In] IntPtr pvRef,
        [In] DIEFT dwEffType);

    public void GetEffectInfo(
        [In, Out] ref DIEFFECTINFO pdei,
        [In] in Guid rguid);

    void GetForceFeedbackState(
        [Out] out DIGFFS pdwOut);

    void SendForceFeedbackCommand(
        [In] DISFFC dwFlags);

    void EnumCreatedEffectObjects(
        [In, MarshalAs(UnmanagedType.FunctionPtr)] LPDIENUMCREATEDEFFECTOBJECTSCALLBACK lpCallback,
        [In] IntPtr pvRef,
        [In] int fl);

    void Escape(
        [In] ref DIEFFESCAPE pesc);

    void Poll();

    void SendDeviceData();

    void EnumEffectsInFile();

    void WriteEffectToFile();

    void BuildActionMap();

    void SetActionMap();

    void GetImageInfo();
}
