using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("9EDDE9E7-8DEE-47ea-99DF-E6FAF2ED44BF")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapDecoder
{
    void QueryCapability(
        [In] IWicWin32Stream pIStream,
        [Out] out WicBitmapDecoderCapabilities pdwCapability
        );

    void Initialize(
        [In] IWicWin32Stream pIStream,
        [In] WicDecodeOptions cacheOptions
        );

    void GetContainerFormat(
        [Out] out Guid pguidContainerFormat
        );

    void GetDecoderInfo(
        [Out] out IWicBitmapDecoderInfo ppIDecoderInfo
        );

    void CopyPalette(
        [In] IWicPalette pIPalette
        );

    void GetMetadataQueryReader();

    void GetPreview(
        [Out] out IWicBitmapSource ppIBitmapSource
        );

    void GetColorContexts(
        [In] uint cCount,
        [In, Out] IWicColorContext[]? ppIColorContexts,
        [Out] out uint pcActualCount
        );

    void GetThumbnail(
        [Out] out IWicBitmapSource ppIThumbnail
        );

    void GetFrameCount(
        [Out] out uint pCount
        );

    void GetFrame(
        [In] uint index,
        [Out] out IWicBitmapFrameDecode ppIBitmapFrame
        );
}
