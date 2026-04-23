// <copyright file="WicWin32ComStream.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec.Interop;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
internal unsafe sealed class WicWin32ComStream : IDisposable
{
    private const int S_OK = 0;
    private const int E_NOTIMPL = -2147467263;
    private const int E_NOINTERFACE = -2147467262;

    private static readonly Guid IID_IUnknown = new("00000000-0000-0000-C000-000000000046");
    private static readonly Guid IID_IStream = new("0000000C-0000-0000-C000-000000000046");

    private Stream? _stream;
    private GCHandle _gcHandle;
    private nint _vtable;
    private int _refCounter;

    public WicWin32ComStream(Stream? stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException("stream");
        }

        _stream = stream;
        Alloc();
    }

    public void Dispose()
    {
        //_stream?.Dispose();
        _stream = null;
        Free();
    }

    public nint Handle => _vtable;

    private void Alloc()
    {
        int size = sizeof(nint) * 2 + DXMarshal.SizeOf<IWicWin32Stream>();
        nint ptr = Marshal.AllocHGlobal(size);
        _gcHandle = GCHandle.Alloc(this);
        Marshal.WriteIntPtr(ptr, ptr + sizeof(nint) * 2);
        Marshal.WriteIntPtr(ptr + sizeof(nint), (nint)_gcHandle);
        *(IWicWin32Stream*)(ptr + sizeof(nint) * 2) = GetVtbl();
        _vtable = ptr;
        _refCounter = 0;
    }

    private void Free()
    {
        if (_gcHandle.IsAllocated)
        {
            _gcHandle.Free();
        }

        if (_vtable != 0)
        {
            Marshal.FreeHGlobal(_vtable);
            _vtable = 0;
        }
    }

    private delegate int QueryInterfaceDelegate(nint @this, in Guid iid, nint* ppvObject);
    private delegate int AddRefDelegate(nint @this);
    private delegate int ReleaseDelegate(nint @this);
    private delegate int ReadDelegate(nint @this, void* pv, int cb, ulong* pcbRead);
    private delegate int WriteDelegate(nint @this, void* pv, int cb, ulong* pcbWritten);
    private delegate int SeekDelegate(nint @this, ulong dlibMove, int dwOrigin, ulong* plibNewPosition);
    private delegate int SetSizeDelegate(nint @this, ulong libNewSize);
    private delegate int CopyToDelegate(nint @this, nint pstm, ulong cb, ulong* pcbRead, ulong* pcbWritten);
    private delegate int CommitDelegate(nint @this, int grfCommitFlags);
    private delegate int RevertDelegate(nint @this);
    private delegate int LockRegionDelegate(nint @this, ulong libOffset, ulong cb, int dwLockType);
    private delegate int UnlockRegionDelegate(nint @this, ulong libOffset, ulong cb, int dwLockType);
    private delegate int StatDelegate(nint @this, STATSTG* pstatstg, int grfStatFlag);
    private delegate int CloneDelegate(nint @this, out nint ppstm);

    private static readonly QueryInterfaceDelegate _QueryInterface = new(QueryInterface);
    private static readonly AddRefDelegate _AddRef = new(AddRef);
    private static readonly ReleaseDelegate _Release = new(Release);
    private static readonly ReadDelegate _Read = new(Read);
    private static readonly WriteDelegate _Write = new(Write);
    private static readonly SeekDelegate _Seek = new(Seek);
    private static readonly SetSizeDelegate _SetSize = new(SetSize);
    private static readonly CopyToDelegate _CopyTo = new(CopyTo);
    private static readonly CommitDelegate _Commit = new(Commit);
    private static readonly RevertDelegate _Revert = new(Revert);
    private static readonly LockRegionDelegate _LockRegion = new(LockRegion);
    private static readonly UnlockRegionDelegate _UnlockRegion = new(UnlockRegion);
    private static readonly StatDelegate _Stat = new(Stat);
    private static readonly CloneDelegate _Clone = new(Clone);

    private static IWicWin32Stream GetVtbl()
    {
        IWicWin32Stream vtbl;
        *(nint*)&vtbl.QueryInterface = Marshal.GetFunctionPointerForDelegate(_QueryInterface);
        *(nint*)&vtbl.AddRef = Marshal.GetFunctionPointerForDelegate(_AddRef);
        *(nint*)&vtbl.Release = Marshal.GetFunctionPointerForDelegate(_Release);
        *(nint*)&vtbl.Read = Marshal.GetFunctionPointerForDelegate(_Read);
        *(nint*)&vtbl.Write = Marshal.GetFunctionPointerForDelegate(_Write);
        *(nint*)&vtbl.Seek = Marshal.GetFunctionPointerForDelegate(_Seek);
        *(nint*)&vtbl.SetSize = Marshal.GetFunctionPointerForDelegate(_SetSize);
        *(nint*)&vtbl.CopyTo = Marshal.GetFunctionPointerForDelegate(_CopyTo);
        *(nint*)&vtbl.Commit = Marshal.GetFunctionPointerForDelegate(_Commit);
        *(nint*)&vtbl.Revert = Marshal.GetFunctionPointerForDelegate(_Revert);
        *(nint*)&vtbl.LockRegion = Marshal.GetFunctionPointerForDelegate(_LockRegion);
        *(nint*)&vtbl.UnlockRegion = Marshal.GetFunctionPointerForDelegate(_UnlockRegion);
        *(nint*)&vtbl.Stat = Marshal.GetFunctionPointerForDelegate(_Stat);
        *(nint*)&vtbl.Clone = Marshal.GetFunctionPointerForDelegate(_Clone);
        return vtbl;
    }

    private static WicWin32ComStream GetThis(nint @this)
    {
        nint ptr = Marshal.ReadIntPtr(@this, IntPtr.Size);
        WicWin32ComStream thisObject = (WicWin32ComStream)GCHandle.FromIntPtr(ptr).Target!;

        if (thisObject._stream is null)
        {
            throw new ObjectDisposedException(nameof(_stream));
        }

        return thisObject;
    }

    private static int QueryInterface(nint @this, in Guid iid, nint* ppvObject)
    {
        try
        {
            if (IID_IUnknown.Equals(iid) || IID_IStream.Equals(iid))
            {
                *ppvObject = @this;
                AddRef(@this);
                return S_OK;
            }
            else
            {
                *ppvObject = 0;
                return E_NOINTERFACE;
            }
        }
        catch (Exception e)
        {
            return Marshal.GetHRForException(e);
        }
    }

    private static int AddRef(nint @this)
    {
        try
        {
            WicWin32ComStream thisObject = GetThis(@this);

            lock (thisObject)
            {
                return ++thisObject._refCounter;
            }
        }
        catch
        {
            return 0;
        }
    }

    private static int Release(nint @this)
    {
        try
        {
            WicWin32ComStream thisObject = GetThis(@this);

            lock (thisObject)
            {
                if ((thisObject._refCounter != 0) && (--thisObject._refCounter == 0))
                {
                    thisObject.Dispose();
                }

                return thisObject._refCounter;
            }
        }
        catch
        {
            return 0;
        }
    }

    private static int Read(nint @this, void* pv, int cb, ulong* pcbRead)
    {
        try
        {
            WicWin32ComStream thisObject = GetThis(@this);

            if (!thisObject._stream!.CanRead)
            {
                throw new InvalidOperationException("Stream not readable.");
            }

            int read = StreamHelpers.CopyTo(thisObject._stream!, (nint)pv, cb);

            if (pcbRead != null)
            {
                *pcbRead = (ulong)read;
            }

            return S_OK;
        }
        catch (Exception e)
        {
            if (pcbRead != null)
            {
                *pcbRead = 0;
            }

            return Marshal.GetHRForException(e);
        }
    }

    private static int Write(nint @this, void* pv, int cb, ulong* pcbWritten)
    {
        try
        {
            WicWin32ComStream thisObject = GetThis(@this);

            if (!thisObject._stream!.CanWrite)
            {
                throw new InvalidOperationException("Stream is not writeable.");
            }

            int write = StreamHelpers.CopyTo((nint)pv, thisObject._stream!, cb);

            if (pcbWritten != null)
            {
                *pcbWritten = (ulong)write;
            }

            return S_OK;
        }
        catch (Exception e)
        {
            if (pcbWritten != null)
            {
                *pcbWritten = 0;
            }

            return Marshal.GetHRForException(e);
        }
    }

    private static int Seek(nint @this, ulong dlibMove, int dwOrigin, ulong* plibNewPosition)
    {
        try
        {
            WicWin32ComStream thisObject = GetThis(@this);

            SeekOrigin origin = (SeekOrigin)dwOrigin;
            ulong pos = (ulong)thisObject._stream!.Seek((long)dlibMove, origin);

            if (plibNewPosition != null)
            {
                *plibNewPosition = pos;
            }

            return S_OK;
        }
        catch (Exception e)
        {
            if (plibNewPosition != null)
            {
                *plibNewPosition = 0;
            }

            return Marshal.GetHRForException(e);
        }
    }

    private static int SetSize(nint @this, ulong libNewSize)
    {
        return E_NOTIMPL;
    }

    private static int CopyTo(nint @this, nint pstm, ulong cb, ulong* pcbRead, ulong* pcbWritten)
    {
        return E_NOTIMPL;
    }

    private static int Commit(nint @this, int grfCommitFlags)
    {
        return E_NOTIMPL;
    }

    private static int Revert(nint @this)
    {
        return E_NOTIMPL;
    }

    private static int LockRegion(nint @this, ulong libOffset, ulong cb, int dwLockType)
    {
        return E_NOTIMPL;
    }

    private static int UnlockRegion(nint @this, ulong libOffset, ulong cb, int dwLockType)
    {
        return E_NOTIMPL;
    }

    private static int Stat(nint @this, STATSTG* pstatstg, int grfStatFlag)
    {
        WicWin32ComStream thisObject = GetThis(@this);

        ulong length = (ulong)thisObject._stream!.Length;
        if (length == 0)
        {
            length = 0x7fffffff;
        }

        pstatstg->pwcsName = null;
        pstatstg->type = 2; // STREAM
        pstatstg->cbSize = length;
        pstatstg->mtime = default;
        pstatstg->ctime = default;
        pstatstg->atime = default;
        pstatstg->grfMode = 2;
        pstatstg->grfLocksSupported = 2;
        pstatstg->clsid = default;
        pstatstg->grfStateBits = 0;
        pstatstg->reserved = 0;
        return S_OK;
    }

    private static int Clone(nint @this, out nint ppstm)
    {
        ppstm = 0;
        return E_NOTIMPL;
    }
}
