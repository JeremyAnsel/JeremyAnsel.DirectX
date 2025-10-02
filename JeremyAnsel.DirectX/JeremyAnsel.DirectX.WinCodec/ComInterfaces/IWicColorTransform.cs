using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("B66F034F-D0E2-40ab-B436-6DE39E321A94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicColorTransform
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
         [In] IWicBitmapSource pIBitmapSource,
         [In] IWicColorContext pIContextSource,
         [In] IWicColorContext pIContextDest,
         [In] in WicPixelFormatGuid pixelFmtDest
         );
}
