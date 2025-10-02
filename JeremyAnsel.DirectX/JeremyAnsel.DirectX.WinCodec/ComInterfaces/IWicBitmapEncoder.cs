using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("00000103-a8f2-4877-ba0a-fd2b6645fb94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapEncoder
{
    void Initialize(
        [In] IWicWin32Stream pIStream,
        [In] WicBitmapEncoderCacheOption cacheOption
        );

    void GetContainerFormat(
        [Out] out Guid pguidContainerFormat
        );

    void GetEncoderInfo(
        [Out] out IWicBitmapEncoderInfo ppIEncoderInfo
        );

    void SetColorContexts(
        [In] uint cCount,
        [In, MarshalAs(UnmanagedType.LPArray)] IWicColorContext[] ppIColorContext
        );

    void SetPalette(
        [In] IWicPalette pIPalette
        );

    void SetThumbnail(
        [In] IWicBitmapSource pIThumbnail
        );

    void SetPreview(
        [In] IWicBitmapSource pIPreview
        );

    void CreateNewFrame(
        [Out] out IWicBitmapFrameEncode ppIFrameEncode,
        [In] IntPtr ppIEncoderOptions
        );

    void Commit(
        );

    void GetMetadataQueryWriter();
}
