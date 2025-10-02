using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("00000301-a8f2-4877-ba0a-fd2b6645fb94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicFormatConverter
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
        [In] in WicPixelFormatGuid dstFormat,
        [In] WicBitmapDitherType dither,
        [In] IWicPalette? pIPalette,
        [In] double alphaThresholdPercent,
        [In] WicBitmapPaletteType paletteTranslate
        );

    void CanConvert(
        [In] in WicPixelFormatGuid srcPixelFormat,
        [In] in WicPixelFormatGuid dstPixelFormat,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfCanConvert);
}
