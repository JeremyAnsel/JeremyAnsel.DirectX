using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapFrameEncode : IDisposable
{
    private IWicBitmapFrameEncode? _handle;

    internal WicBitmapFrameEncode(IWicBitmapFrameEncode handle)
    {
        _handle = handle;
    }

    public WicBitmapFrameEncode(object handle)
    {
        _handle = (IWicBitmapFrameEncode)handle;
    }

    internal IWicBitmapFrameEncode GetWicBitmapFrameEncode()
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

    public void Initialize()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Initialize(IntPtr.Zero);
    }

    public void SetSize(uint width, uint height)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetSize(width, height);
    }

    public void SetResolution(double dpiX, double dpiY)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetResolution(dpiX, dpiY);
    }

    public void SetPixelFormat(ref WicPixelFormatGuid format)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetPixelFormat(ref format);
    }

    public void SetColorContexts(WicColorContext[] ppIColorContext)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetColorContexts((uint)ppIColorContext.Length, Array.ConvertAll(ppIColorContext, t => t.GetWicColorContext()));
    }

    public void SetPalette(WicPalette palette)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetPalette(palette.GetWicPalette());
    }

    public void SetThumbnail(WicBitmapSource pIThumbnail)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetThumbnail(pIThumbnail.GetWicBitmapSource());
    }

    public void WritePixels(uint lineCount, uint cbStride, IntPtr pixels, int length)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.WritePixels(lineCount, cbStride, (uint)length, pixels);
    }

    public unsafe void WritePixels(uint lineCount, uint cbStride, byte[] pixels)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        fixed (byte* ptr = pixels)
        {
            _handle.WritePixels(lineCount, cbStride, (uint)pixels.Length, new IntPtr(ptr));
        }
    }

    public unsafe void WritePixels(uint lineCount, uint cbStride, byte[] pixels, int start, int length)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        fixed (byte* ptr = pixels)
        {
            _handle.WritePixels(lineCount, cbStride, (uint)length, new IntPtr(ptr + start));
        }
    }

    public unsafe void WriteSource(WicBitmapSource pIBitmapSource, WicRect? rc)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (rc is null)
        {
            _handle.WriteSource(pIBitmapSource.GetWicBitmapSource(), IntPtr.Zero);
        }
        else
        {
            WicRect prc = rc.Value;
            _handle.WriteSource(pIBitmapSource.GetWicBitmapSource(), new IntPtr(&prc));
        }
    }

    public void Commit()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Commit();
    }
}
