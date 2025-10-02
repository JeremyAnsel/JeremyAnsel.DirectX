using System.Runtime.InteropServices;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from IStream</remarks>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("135FF860-22B7-4ddf-B0F6-218F4F299A43")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicStream
{
    [PreserveSig]
    int Read(IntPtr pv, int cb, IntPtr pcbRead);

    [PreserveSig]
    int Write(IntPtr pv, int cb, IntPtr pcbWritten);

    [PreserveSig]
    int Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

    [PreserveSig]
    int SetSize(long libNewSize);

    [PreserveSig]
    int CopyTo(IWicWin32Stream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

    [PreserveSig]
    int Commit(int grfCommitFlags);

    [PreserveSig]
    int Revert();

    [PreserveSig]
    int LockRegion(long libOffset, long cb, int dwLockType);

    [PreserveSig]
    int UnlockRegion(long libOffset, long cb, int dwLockType);

    [PreserveSig]
    int Stat(ref STATSTG pstatstg, int grfStatFlag);

    [PreserveSig]
    int Clone(out IWicWin32Stream? ppstm);

    void InitializeFromIStream(
        [In] IWicWin32Stream pIStream
        );

    void InitializeFromFilename(
        [In, MarshalAs(UnmanagedType.LPWStr)] string wzFileName,
        [In] WicWin32GenericAccessRights dwDesiredAccess
        );

    void InitializeFromMemory(
        [In] IntPtr pbBuffer,
        [In] uint cbBufferSize
        );

    void InitializeFromIStreamRegion(
        [In] IWicWin32Stream pIStream,
        [In] ulong ulOffset,
        [In] ulong ulMaxSize
        );
}
