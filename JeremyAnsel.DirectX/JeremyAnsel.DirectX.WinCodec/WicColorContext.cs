using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicColorContext : IDisposable
{
    private IWicColorContext? _handle;

    internal WicColorContext(IWicColorContext handle)
    {
        _handle = handle;
    }

    public WicColorContext(object handle)
    {
        _handle = (IWicColorContext)handle;
    }

    internal IWicColorContext GetWicColorContext()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        return _handle;
    }

    public object Handle => _handle ?? throw new ObjectDisposedException(nameof(_handle));

    public void Dispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }
    }

    public void InitializeFromFilename(string filename)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializeFromFilename(filename);
    }

    public void InitializeFromMemory(byte[] buffer)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializeFromMemory(buffer, (uint)buffer.Length);
    }

    public void InitializeFromExifColorSpace(uint value)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializeFromExifColorSpace(value);
    }

    public WicColorContextType GetContextType()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetType(out WicColorContextType type);
        return type;
    }

    public byte[] GetProfileBytes()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetProfileBytes(0, null, out uint actualSize);

        if (actualSize <= 0)
        {
            return Array.Empty<byte>();
        }

        var bytes = new byte[actualSize];
        _handle.GetProfileBytes((uint)bytes.Length, bytes, out actualSize);
        return bytes;
    }

    public uint GetExifColorSpace()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetExifColorSpace(out uint value);
        return value;
    }
}
