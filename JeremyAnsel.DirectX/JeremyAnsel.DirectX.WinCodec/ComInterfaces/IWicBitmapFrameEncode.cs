using System;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("00000105-a8f2-4877-ba0a-fd2b6645fb94")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicBitmapFrameEncode
{
    void Initialize(
        [In] IntPtr pIEncoderOptions
        );

    void SetSize(
        [In] uint uiWidth,
        [In] uint uiHeight
        );

    void SetResolution(
        [In] double dpiX,
        [In] double dpiY
        );

    void SetPixelFormat(
        [In, Out] ref WicPixelFormatGuid pPixelFormat
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

    void WritePixels(
        [In] uint lineCount,
        [In] uint cbStride,
        [In] uint cbBufferSize,
        [In] IntPtr pbPixels
        );

    void WriteSource(
        [In] IWicBitmapSource pIBitmapSource,
        [In] IntPtr prc
        );

    void Commit(
        );

    void GetMetadataQueryWriter();
}
