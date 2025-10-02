using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("E4FBCF03-223D-4e81-9333-D635556DD1B5")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapClipper
{
    void GetSize(
        [Out] out uint puiWidth,
        [Out] out uint puiHeight
        );

    void GetPixelFormat(
        [Out] out WicPixelFormatGuid pPixelFormat
        );

    void GetResolution(
        [Out] out double pDpiX,
        [Out] out double pDpiY
        );

    void CopyPalette(
        [In] IWicPalette pIPalette
        );

    void CopyPixels(
        [In] IntPtr prc,
        [In] uint cbStride,
        [In] uint cbBufferSize,
        [In] IntPtr pbBuffer
        );

    void Initialize(
        [In] IWicBitmapSource pISource,
        [In] in WicRect prc
        );
}
