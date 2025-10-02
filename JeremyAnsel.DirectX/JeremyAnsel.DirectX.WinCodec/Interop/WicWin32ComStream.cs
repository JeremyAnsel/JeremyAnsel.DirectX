using System.Runtime.InteropServices;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace JeremyAnsel.DirectX.WinCodec;

//internal sealed class WicWin32ComStream : Stream, IWicWin32Stream
//{
//    private const int S_OK = 0;
//    private const int E_NOTIMPL = -2147467263;

//    private Stream? _stream;

//    public WicWin32ComStream(Stream? stream)
//        : this(stream, false)
//    {
//    }

//    internal WicWin32ComStream(Stream? stream, bool sync)
//    {
//        if (stream is null)
//        {
//            throw new ArgumentNullException("stream");
//        }

//        if (sync)
//        {
//            stream = Synchronized(stream);
//        }

//        _stream = stream;
//    }

//    int IWicWin32Stream.Clone(out IWicWin32Stream? ppstm)
//    {
//        //ppstm = newstream;
//        ppstm = null;
//        return E_NOTIMPL;
//    }

//    int IWicWin32Stream.Commit(int grfCommitFlags)
//    {
//        return E_NOTIMPL;
//    }

//    int IWicWin32Stream.CopyTo(IWicWin32Stream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
//    {
//        return E_NOTIMPL;
//    }

//    int IWicWin32Stream.LockRegion(long libOffset, long cb, int dwLockType)
//    {
//        return E_NOTIMPL;
//    }

//    unsafe int IWicWin32Stream.Read(IntPtr pv, int cb, IntPtr pcbRead)
//    {
//        if (!CanRead)
//        {
//            throw new InvalidOperationException("Stream not readable");
//        }

//        int read = CopyTo(_stream!, pv, cb);

//        if (pcbRead != IntPtr.Zero)
//        {
//            Marshal.WriteInt64(pcbRead, read);
//        }

//        return S_OK;
//    }

//    int IWicWin32Stream.Revert()
//    {
//        return E_NOTIMPL;
//    }

//    int IWicWin32Stream.Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
//    {
//        //hope that the SeekOrigin enumeration won't change
//        SeekOrigin origin = (SeekOrigin)dwOrigin;
//        long pos = Seek(dlibMove, origin);

//        if (plibNewPosition != IntPtr.Zero)
//        {
//            Marshal.WriteInt64(plibNewPosition, pos);
//        }

//        return S_OK;
//    }

//    int IWicWin32Stream.SetSize(long libNewSize)
//    {
//        return E_NOTIMPL;
//    }

//    int IWicWin32Stream.Stat(ref STATSTG pstatstg, int grfStatFlag)
//    {
//        pstatstg.pwcsName = null!;
//        pstatstg.type = 2; // STREAM
//        pstatstg.cbSize = _stream!.Length;
//        pstatstg.mtime = default;
//        pstatstg.ctime = default;
//        pstatstg.atime = default;
//        pstatstg.grfMode = 0;
//        pstatstg.grfLocksSupported = 0;
//        pstatstg.clsid = default;
//        pstatstg.grfStateBits = 0;
//        pstatstg.reserved = 0;
//        return S_OK;
//    }

//    int IWicWin32Stream.UnlockRegion(long libOffset, long cb, int dwLockType)
//    {
//        return E_NOTIMPL;
//    }

//    unsafe int IWicWin32Stream.Write(IntPtr pv, int cb, IntPtr pcbWritten)
//    {
//        if (!CanWrite)
//        {
//            throw new InvalidOperationException("Stream is not writeable.");
//        }

//        CopyTo(pv, _stream!, cb);

//        if (pcbWritten != IntPtr.Zero)
//        {
//            Marshal.WriteInt32(pcbWritten, cb);
//        }

//        return S_OK;
//    }

//    public override bool CanRead
//    {
//        get
//        {
//            if (_stream is null)
//            {
//                throw new ObjectDisposedException(nameof(_stream));
//            }

//            return _stream.CanRead;
//        }
//    }

//    public override bool CanSeek
//    {
//        get
//        {
//            if (_stream is null)
//            {
//                throw new ObjectDisposedException(nameof(_stream));
//            }

//            return _stream.CanSeek;
//        }
//    }

//    public override bool CanWrite
//    {
//        get
//        {
//            if (_stream is null)
//            {
//                throw new ObjectDisposedException(nameof(_stream));
//            }

//            return _stream.CanWrite;
//        }
//    }

//    public override void Flush()
//    {
//        if (_stream is null)
//        {
//            throw new ObjectDisposedException(nameof(_stream));
//        }

//        _stream.Flush();
//    }

//    public override long Length
//    {
//        get
//        {
//            if (_stream is null)
//            {
//                throw new ObjectDisposedException(nameof(_stream));
//            }

//            return _stream.Length;
//        }
//    }

//    public override long Position
//    {
//        get
//        {
//            if (_stream is null)
//            {
//                throw new ObjectDisposedException(nameof(_stream));
//            }

//            return _stream.Position;
//        }

//        set
//        {
//            if (_stream is null)
//            {
//                throw new ObjectDisposedException(nameof(_stream));
//            }

//            _stream.Position = value;
//        }
//    }

//    public override int Read(byte[] buffer, int offset, int count)
//    {
//        if (_stream is null)
//        {
//            throw new ObjectDisposedException(nameof(_stream));
//        }

//        return _stream.Read(buffer, offset, count);
//    }

//    public override long Seek(long offset, SeekOrigin origin)
//    {
//        if (_stream is null)
//        {
//            throw new ObjectDisposedException(nameof(_stream));
//        }

//        return _stream.Seek(offset, origin);
//    }

//    public override void SetLength(long value)
//    {
//        if (_stream is null)
//        {
//            throw new ObjectDisposedException(nameof(_stream));
//        }

//        _stream.SetLength(value);
//    }

//    public override void Write(byte[] buffer, int offset, int count)
//    {
//        if (_stream is null)
//        {
//            throw new ObjectDisposedException(nameof(_stream));
//        }

//        _stream.Write(buffer, offset, count);
//    }

//    protected override void Dispose(bool disposing)
//    {
//        if (_stream != null)
//        {
//            _stream.Dispose();
//            _stream = null;
//        }
//    }

//    private static byte[] _buffer = new byte[32768];

//    private static int CopyTo(Stream source, IntPtr destination, int length)
//    {
//        int bufferLength = _buffer.Length;
//        int read = 0;

//        while (length > 0)
//        {
//            int count = Math.Min(bufferLength, length);
//            count = source.Read(_buffer, 0, count);

//            if (count == 0)
//            {
//                break;
//            }

//            Marshal.Copy(_buffer, 0, destination + read, count);
//            length -= count;
//            read += count;
//        }

//        return read;
//    }

//    private static int CopyTo(IntPtr source, Stream destination, int length)
//    {
//        int bufferLength = _buffer.Length;
//        int read = 0;

//        while (length > 0)
//        {
//            int count = Math.Min(bufferLength, length);
//            Marshal.Copy(source + read, _buffer, 0, count);
//            destination.Write(_buffer, 0, count);
//            length -= count;
//            read += count;
//        }

//        return read;
//    }
//}

internal sealed class WicWin32ComStream : IWicWin32Stream, IDisposable
{
    private const int S_OK = 0;
    private const int E_NOTIMPL = -2147467263;

    private Stream? _stream;

    internal WicWin32ComStream(Stream? stream)
    {
        if (stream is null)
        {
            throw new ArgumentNullException("stream");
        }

        _stream = stream;
    }

    int IWicWin32Stream.Clone(out IWicWin32Stream? ppstm)
    {
        //ppstm = newstream;
        ppstm = null;
        return E_NOTIMPL;
    }

    int IWicWin32Stream.Commit(int grfCommitFlags)
    {
        return E_NOTIMPL;
    }

    int IWicWin32Stream.CopyTo(IWicWin32Stream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
    {
        return E_NOTIMPL;
    }

    int IWicWin32Stream.LockRegion(long libOffset, long cb, int dwLockType)
    {
        return E_NOTIMPL;
    }

    unsafe int IWicWin32Stream.Read(IntPtr pv, int cb, IntPtr pcbRead)
    {
        if (!CanRead)
        {
            throw new InvalidOperationException("Stream not readable");
        }

        int read = StreamHelpers.CopyTo(_stream!, pv, cb);

        if (pcbRead != IntPtr.Zero)
        {
            Marshal.WriteInt64(pcbRead, read);
        }

        return S_OK;
    }

    int IWicWin32Stream.Revert()
    {
        return E_NOTIMPL;
    }

    int IWicWin32Stream.Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
    {
        //hope that the SeekOrigin enumeration won't change
        SeekOrigin origin = (SeekOrigin)dwOrigin;
        long pos = Seek(dlibMove, origin);

        if (plibNewPosition != IntPtr.Zero)
        {
            Marshal.WriteInt64(plibNewPosition, pos);
        }

        return S_OK;
    }

    int IWicWin32Stream.SetSize(long libNewSize)
    {
        return E_NOTIMPL;
    }

    int IWicWin32Stream.Stat(ref STATSTG pstatstg, int grfStatFlag)
    {
        pstatstg.pwcsName = null!;
        pstatstg.type = 2; // STREAM
        pstatstg.cbSize = _stream!.Length;
        pstatstg.mtime = default;
        pstatstg.ctime = default;
        pstatstg.atime = default;
        pstatstg.grfMode = 0;
        pstatstg.grfLocksSupported = 0;
        pstatstg.clsid = default;
        pstatstg.grfStateBits = 0;
        pstatstg.reserved = 0;
        return S_OK;
    }

    int IWicWin32Stream.UnlockRegion(long libOffset, long cb, int dwLockType)
    {
        return E_NOTIMPL;
    }

    unsafe int IWicWin32Stream.Write(IntPtr pv, int cb, IntPtr pcbWritten)
    {
        if (!CanWrite)
        {
            throw new InvalidOperationException("Stream is not writeable.");
        }

        StreamHelpers.CopyTo(pv, _stream!, cb);

        if (pcbWritten != IntPtr.Zero)
        {
            Marshal.WriteInt32(pcbWritten, cb);
        }

        return S_OK;
    }

    public bool CanRead
    {
        get
        {
            if (_stream is null)
            {
                throw new ObjectDisposedException(nameof(_stream));
            }

            return _stream.CanRead;
        }
    }

    public bool CanSeek
    {
        get
        {
            if (_stream is null)
            {
                throw new ObjectDisposedException(nameof(_stream));
            }

            return _stream.CanSeek;
        }
    }

    public bool CanWrite
    {
        get
        {
            if (_stream is null)
            {
                throw new ObjectDisposedException(nameof(_stream));
            }

            return _stream.CanWrite;
        }
    }

    public void Flush()
    {
        if (_stream is null)
        {
            throw new ObjectDisposedException(nameof(_stream));
        }

        _stream.Flush();
    }

    public long Length
    {
        get
        {
            if (_stream is null)
            {
                throw new ObjectDisposedException(nameof(_stream));
            }

            return _stream.Length;
        }
    }

    public long Position
    {
        get
        {
            if (_stream is null)
            {
                throw new ObjectDisposedException(nameof(_stream));
            }

            return _stream.Position;
        }

        set
        {
            if (_stream is null)
            {
                throw new ObjectDisposedException(nameof(_stream));
            }

            _stream.Position = value;
        }
    }

    public int Read(byte[] buffer, int offset, int count)
    {
        if (_stream is null)
        {
            throw new ObjectDisposedException(nameof(_stream));
        }

        return _stream.Read(buffer, offset, count);
    }

    public long Seek(long offset, SeekOrigin origin)
    {
        if (_stream is null)
        {
            throw new ObjectDisposedException(nameof(_stream));
        }

        return _stream.Seek(offset, origin);
    }

    public void SetLength(long value)
    {
        if (_stream is null)
        {
            throw new ObjectDisposedException(nameof(_stream));
        }

        _stream.SetLength(value);
    }

    public void Write(byte[] buffer, int offset, int count)
    {
        if (_stream is null)
        {
            throw new ObjectDisposedException(nameof(_stream));
        }

        _stream.Write(buffer, offset, count);
    }

    public void Dispose()
    {
        if (_stream != null)
        {
            _stream.Dispose();
            _stream = null;
        }
    }
}
