using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("3B16811B-6A43-4ec9-A813-3D930C13B940")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapFrameDecode
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

    void GetMetadataQueryReader();

    void GetColorContexts(
         [In] uint cCount,
         [In, MarshalAs(UnmanagedType.LPArray)] IWicColorContext[]? ppIColorContexts,
         [Out] out uint pcActualCount);

    void GetThumbnail(
        [Out] out IWicBitmapSource ppIThumbnail
        );
}
