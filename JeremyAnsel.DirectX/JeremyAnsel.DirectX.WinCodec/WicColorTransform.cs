using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicColorTransform : WicBitmapSource
{
    private IWicColorTransform? _handle;

    internal WicColorTransform(IWicColorTransform handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicColorTransform(object handle)
        : base(handle)
    {
        _handle = (IWicColorTransform)handle;
    }

    internal IWicColorTransform GetWicColorTransform()
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

    public void Initialize(
        WicBitmapSource pIBitmapSource,
        WicColorContext pIContextSource,
        WicColorContext pIContextDest,
        in WicPixelFormatGuid pixelFmtDest)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Initialize(
            pIBitmapSource.GetWicBitmapSource(),
            pIContextSource.GetWicColorContext(),
            pIContextDest.GetWicColorContext(),
            pixelFmtDest);
    }
}
