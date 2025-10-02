using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("409cd537-8532-40cb-9774-e2feb2df4e9c")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicDdsDecoder
{
    void GetParameters(
        [Out] out WicDdsParameters pParameters
        );

    void GetFrame(
        [In] uint arrayIndex,
        [In] uint mipLevel,
        [In] uint sliceIndex,
        [Out] out IWicBitmapFrameDecode ppIBitmapFrame
        );
}
