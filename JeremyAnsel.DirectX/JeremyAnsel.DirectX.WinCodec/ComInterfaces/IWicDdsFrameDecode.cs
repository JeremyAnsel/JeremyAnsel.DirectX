using System;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("3d4c0c61-18a4-41e4-bd80-481a4fc9f464")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicDdsFrameDecode
{
    void GetSizeInBlocks(
        [Out] out uint pWidthInBlocks,
        [Out] out uint pHeightInBlocks
        );

    void GetFormatInfo(
        [Out] out WicDdsFormatInfo pFormatInfo
        );

    void CopyBlocks(
        [In] IntPtr prcBoundsInBlocks,
        [In] uint cbStride,
        [In] uint cbBufferSize,
        [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbBuffer
        );
}
