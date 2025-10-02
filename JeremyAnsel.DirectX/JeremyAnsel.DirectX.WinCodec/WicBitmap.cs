using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmap : WicBitmapSource
{
    private IWicBitmap? _handle;

    internal WicBitmap(IWicBitmap handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmap(object handle)
        : base(handle)
    {
        _handle = (IWicBitmap)handle;
    }

    internal IWicBitmap GetWicBitmap()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        return _handle;
    }

    protected override void OnDispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }

        base.OnDispose();
    }

    public WicBitmapLock Lock(in WicRect rc, WicBitmapLockFlags flags)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Lock(rc, flags, out IWicBitmapLock pLock);
        return new WicBitmapLock(pLock);
    }

    public void SetPalette(WicPalette pIPalette)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetPalette(pIPalette.GetWicPalette());
    }

    public void SetResolution(double dpiX, double dpiY)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetResolution(dpiX, dpiY);
    }
}
