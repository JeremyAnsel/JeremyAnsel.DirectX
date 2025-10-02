using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapClipper : WicBitmapSource
{
    private IWicBitmapClipper? _handle;

    internal WicBitmapClipper(IWicBitmapClipper handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapClipper(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapClipper)handle;
    }

    internal IWicBitmapClipper GetWicBitmapClipper()
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

    public void Initialize(WicBitmapSource source, in WicRect rc)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Initialize(source.GetWicBitmapSource(), rc);
    }
}
