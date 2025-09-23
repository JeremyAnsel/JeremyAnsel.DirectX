using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DirectInput;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid(DirectInputGuids.IDirectInputEffectString)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IDirectInputEffect
{
    void Initialize(
         [In] IntPtr hinst,
         [In] int dwVersion,
         [In] ref Guid rguid);

    void GetEffectGuid(
        [Out] out Guid pguid);

    void GetParameters(
        [In, Out] IntPtr peff,
        [In] DIEP dwFlags);

    void SetParameters(
        [In] IntPtr peff,
        [In] DIEP dwFlags);

    void Start(
         [In] int dwIterations,
         [In] DIES dwFlags);

    void Stop();

    void GetEffectStatus(
        [Out] out DIEGES flags);

    void Download();

    void Unload();

    void Escape(
        [In, Out] ref DIEFFESCAPE pesc);
}
