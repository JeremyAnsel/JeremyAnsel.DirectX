using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapScaler : WicBitmapSource
{
    private IWicBitmapScaler? _handle;

    internal WicBitmapScaler(IWicBitmapScaler handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapScaler(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapScaler)handle;
    }

    internal IWicBitmapScaler GetWicBitmapScaler()
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

    public void Initialize(WicBitmapSource source, uint width, uint height, WicBitmapInterpolationMode mode)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Initialize(source.GetWicBitmapSource(), width, height, mode);
    }
}
