using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapEncoderInfo : WicBitmapCodecInfo
{
    private IWicBitmapEncoderInfo? _handle;

    internal WicBitmapEncoderInfo(IWicBitmapEncoderInfo handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapEncoderInfo(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapEncoderInfo)handle;
    }

    internal IWicBitmapEncoderInfo GetWicBitmapEncoderInfo()
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

    public WicBitmapEncoder CreateInstance()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateInstance(out IWicBitmapEncoder encoder);
        return new WicBitmapEncoder(encoder);
    }
}
