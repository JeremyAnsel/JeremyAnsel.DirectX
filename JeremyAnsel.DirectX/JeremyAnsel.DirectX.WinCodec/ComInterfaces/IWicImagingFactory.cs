using JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("7B816B45-1996-4476-B132-DE9E247C8AF0")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicImagingFactory
{
    void CreateDecoderFromFilename(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wzFilename,
        [In] IntPtr pguidVendor,
        [In] WicWin32GenericAccessRights dwDesiredAccess,
        [In] WicDecodeOptions metadataOptions,
        [Out] out IWicBitmapDecoder ppIDecoder
        );

    void CreateDecoderFromStream(
        [In] IWicWin32Stream pIStream,
        [In] IntPtr pguidVendor,
        [In] WicDecodeOptions metadataOptions,
        [Out] out IWicBitmapDecoder ppIDecoder
        );

    void CreateDecoderFromFileHandle(
        [In] IntPtr hFile,
        [In] IntPtr pguidVendor,
        [In] WicDecodeOptions metadataOptions,
        [Out] out IWicBitmapDecoder ppIDecoder
        );

    void CreateComponentInfo(
        [In] in Guid clsidComponent,
        [Out] out IWicComponentInfo ppIInfo
        );

    void CreateDecoder(
        [In] in Guid guidContainerFormat,
        [In] IntPtr pguidVendor,
        [Out] out IWicBitmapDecoder ppIDecoder
        );

    void CreateEncoder(
        [In] in Guid guidContainerFormat,
        [In] IntPtr pguidVendor,
        [Out] out IWicBitmapEncoder ppIEncoder
        );

    void CreatePalette(
        [Out] out IWicPalette ppIPalette
        );

    void CreateFormatConverter(
        [Out] out IWicFormatConverter ppIFormatConverter
        );

    void CreateBitmapScaler(
        [Out] out IWicBitmapScaler ppIBitmapScaler
        );

    void CreateBitmapClipper(
        [Out] out IWicBitmapClipper ppIBitmapClipper
        );

    void CreateBitmapFlipRotator(
        [Out] out IWicBitmapFlipRotator ppIBitmapFlipRotator
        );

    void CreateStream();

    void CreateColorContext(
        [Out] out IWicColorContext ppIWICColorContext
        );

    void CreateColorTransformer(
        [Out] out IWicColorTransform ppIWICColorTransform
        );

    void CreateBitmap(
        [In] uint uiWidth,
        [In] uint uiHeight,
        [In] in WicPixelFormatGuid pixelFormat,
        [In] WicBitmapCreateCacheOption option,
        [Out] out IWicBitmap ppIBitmap
        );

    void CreateBitmapFromSource(
        [In] IWicBitmapSource pIBitmapSource,
        [In] WicBitmapCreateCacheOption option,
        [Out] out IWicBitmap ppIBitmap
        );

    void CreateBitmapFromSourceRect(
        [In] IWicBitmapSource pIBitmapSource,
        [In] uint x,
        [In] uint y,
        [In] uint width,
        [In] uint height,
        [Out] out IWicBitmap ppIBitmap
        );

    void CreateBitmapFromMemory(
        [In] uint uiWidth,
        [In] uint uiHeight,
        [In] in WicPixelFormatGuid pixelFormat,
        [In] uint cbStride,
        [In] uint cbBufferSize,
        [In] IntPtr pbBuffer,
        [Out] out IWicBitmap ppIBitmap
        );

    void CreateBitmapFromHBITMAP(
        [In] IntPtr hBitmap,
        [In] IntPtr hPalette,
        [In] WicBitmapAlphaChannelOption options,
        [Out] out IWicBitmap ppIBitmap
        );

    void CreateBitmapFromHICON(
        [In] IntPtr hIcon,
        [Out] out IWicBitmap ppIBitmap
        );

    void CreateComponentEnumerator();

    void CreateFastMetadataEncoderFromDecoder();

    void CreateFastMetadataEncoderFromFrameDecode();

    void CreateQueryWriter();

    void CreateQueryWriterFromReader();

    void CreateImageEncoder(
        [In] ID2D1Device pD2DDevice,
        [Out] out IWicImageEncoder ppWICImageEncoder
        );
}
