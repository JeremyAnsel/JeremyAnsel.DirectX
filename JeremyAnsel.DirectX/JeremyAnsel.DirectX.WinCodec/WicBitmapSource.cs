using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public class WicBitmapSource : IDisposable
{
    private IWicBitmapSource? _handle;

    internal WicBitmapSource(IWicBitmapSource handle)
    {
        _handle = handle;
    }

    public WicBitmapSource(object handle)
    {
        _handle = (IWicBitmapSource)handle;
    }

    internal IWicBitmapSource GetWicBitmapSource()
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
        OnDispose();
    }

    protected virtual void OnDispose()
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

    public WicPixelFormatGuid GetPixelFormat()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetPixelFormat(out WicPixelFormatGuid format);
        return format;
    }

    public void GetResolution(out double dpiX, out double dpiY)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetResolution(out dpiX, out dpiY);
    }

    public void CopyPalette(WicPalette palette)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CopyPalette(palette.GetWicPalette());
    }

    public unsafe void CopyPixels(WicRect? rc, uint stride, IntPtr buffer, int length)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (rc is null)
        {
            _handle.CopyPixels(IntPtr.Zero, stride, (uint)length, buffer);
        }
        else
        {
            WicRect rect = rc.Value;
            _handle.CopyPixels(new IntPtr(&rect), stride, (uint)length, buffer);
        }
    }

    public unsafe void CopyPixels(WicRect? rc, uint stride, byte[] buffer)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (rc is null)
        {
            fixed (byte* ptr = buffer)
            {
                _handle.CopyPixels(IntPtr.Zero, stride, (uint)buffer.Length, new IntPtr(ptr));
            }
        }
        else
        {
            WicRect rect = rc.Value;

            fixed (byte* ptr = buffer)
            {
                _handle.CopyPixels(new IntPtr(&rect), stride, (uint)buffer.Length, new IntPtr(ptr));
            }
        }
    }

    public unsafe void CopyPixels(WicRect? rc, uint stride, byte[] buffer, int start, int length)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (rc is null)
        {
            fixed (byte* ptr = buffer)
            {
                _handle.CopyPixels(IntPtr.Zero, stride, (uint)length, new IntPtr(ptr + start));
            }
        }
        else
        {
            WicRect rect = rc.Value;

            fixed (byte* ptr = buffer)
            {
                _handle.CopyPixels(new IntPtr(&rect), stride, (uint)length, new IntPtr(ptr + start));
            }
        }
    }
}
