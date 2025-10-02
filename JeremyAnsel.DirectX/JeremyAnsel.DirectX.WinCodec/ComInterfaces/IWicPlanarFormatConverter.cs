using System.Numerics;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("BEBEE9CB-83B0-4DCC-8132-B0AAA55EAC96")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicPlanarFormatConverter
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
        [In, MarshalAs(UnmanagedType.LPArray)] IWicBitmapSource[] ppPlanes,
        [In] uint cPlanes,
        [In] in WicPixelFormatGuid dstFormat,
        [In] WicBitmapDitherType dither,
        [In] IWicPalette? pIPalette,
        [In] double alphaThresholdPercent,
        [In] WicBitmapPaletteType paletteTranslate
        );

    void CanConvert(
        [In, MarshalAs(UnmanagedType.LPArray)] WicPixelFormatGuid[] pSrcPixelFormats,
        [In] uint cSrcPlanes,
        [In] in WicPixelFormatGuid dstPixelFormat,
        [Out, MarshalAs(UnmanagedType.Bool)] out bool pfCanConvert
        );
}
