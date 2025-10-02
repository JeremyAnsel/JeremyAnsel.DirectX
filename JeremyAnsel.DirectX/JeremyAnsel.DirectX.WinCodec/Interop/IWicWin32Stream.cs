using System.Runtime.InteropServices;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

[SecurityCritical, SuppressUnmanagedCodeSecurity]
[ComImport, Guid("0000000c-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IWicWin32Stream
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
}
