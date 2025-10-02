using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("F928B7B8-2221-40C1-B72E-7E82F1974D1A")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicPlanarBitmapFrameEncode
{
    void WritePixels(
        [In] uint lineCount,
        [In, MarshalAs(UnmanagedType.LPArray)] WicBitmapPlanePtr[] pPlanes,
        [In] uint cPlanes
        );

    void WriteSource(
        [In, MarshalAs(UnmanagedType.LPArray)] IWicBitmapSource[] ppPlanes,
        [In] uint cPlanes,
        [In] IntPtr prcSource
        );
}
