using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapLock : IDisposable
{
    private IWicBitmapLock? _handle;

    internal WicBitmapLock(IWicBitmapLock handle)
    {
        _handle = handle;
    }

    public WicBitmapLock(object handle)
    {
        _handle = (IWicBitmapLock)handle;
    }

    internal IWicBitmapLock GetWicBitmapLock()
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

    public void GetSize(out uint width, out uint height)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetSize(out width, out height);
    }

    public uint GetStride()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetStride(out uint stride);
        return stride;
    }

    public void GetDataPointer(out uint size, out IntPtr data)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetDataPointer(out size, out data);
    }

    public WicPixelFormatGuid GetPixelFormat()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetPixelFormat(out WicPixelFormatGuid format);
        return format;
    }
}
