using JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("04C75BF8-3CE1-473B-ACC5-3CC4F5E94999")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicImageEncoder
{
    void WriteFrame(
        [In] ID2D1Image pImage,
        [In] IWicBitmapFrameEncode pFrameEncode,
        [In] IntPtr pImageParameters
        );

    void WriteFrameThumbnail(
        [In] ID2D1Image pImage,
        [In] IWicBitmapFrameEncode pFrameEncode,
        [In] IntPtr pImageParameters
        );

    void WriteThumbnail(
        [In] ID2D1Image pImage,
        [In] IWicBitmapEncoder pEncoder,
        [In] IntPtr pImageParameters
        );
}
