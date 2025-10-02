using System;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("3C613A02-34B2-44ea-9A7C-45AEA9C6FD6D")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicColorContext
{
    void InitializeFromFilename(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wzFilename
        );

    void InitializeFromMemory(
        [In, MarshalAs(UnmanagedType.LPArray)] byte[] pbBuffer,
        [In] uint cbBufferSize
        );

    void InitializeFromExifColorSpace(
        [In] uint value
        );

    void GetType(
        [Out] out WicColorContextType pType
        );

    void GetProfileBytes(
        [In] uint cbBuffer,
        [In, Out, MarshalAs(UnmanagedType.LPArray)] byte[]? pbBuffer,
        [Out] out uint pcbActual
        );

    void GetExifColorSpace(
        [Out] out uint pValue
        );
}
