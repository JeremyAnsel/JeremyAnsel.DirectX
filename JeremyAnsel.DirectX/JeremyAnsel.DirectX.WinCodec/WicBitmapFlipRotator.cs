using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapFlipRotator : WicBitmapSource
{
    private IWicBitmapFlipRotator? _handle;

    internal WicBitmapFlipRotator(IWicBitmapFlipRotator handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapFlipRotator(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapFlipRotator)handle;
    }

    internal IWicBitmapFlipRotator GetWicBitmapFlipRotator()
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

    public void Initialize(WicBitmapSource source, WicBitmapTransformOptions options)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Initialize(source.GetWicBitmapSource(), options);
    }
}
