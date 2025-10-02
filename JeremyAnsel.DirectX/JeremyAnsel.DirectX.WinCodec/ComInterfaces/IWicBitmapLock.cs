using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("00000123-a8f2-4877-ba0a-fd2b6645fb94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapLock
{
    void GetSize(
        [Out] out uint puiWidth,
        [Out] out uint puiHeight
        );

    void GetStride(
        [Out] out uint pcbStride
        );

    void GetDataPointer(
        [Out] out uint pcbBufferSize,
        [Out] out IntPtr ppbData
        );

    void GetPixelFormat(
        [Out] out WicPixelFormatGuid pPixelFormat
        );
}
