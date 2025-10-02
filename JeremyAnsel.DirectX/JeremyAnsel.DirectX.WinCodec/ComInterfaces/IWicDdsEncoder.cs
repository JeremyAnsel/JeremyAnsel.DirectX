using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("5cacdb4c-407e-41b3-b936-d0f010cd6732")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicDdsEncoder
{
    void SetParameters(
        [In] in WicDdsParameters pParameters
        );

    void GetParameters(
        [Out] out WicDdsParameters pParameters
        );

    void CreateNewFrame(
        [Out] out IWicBitmapFrameEncode ppIFrameEncode,
        [Out] out uint pArrayIndex,
        [Out] out uint pMipLevel,
        [Out] out uint pSliceIndex
    );
}
