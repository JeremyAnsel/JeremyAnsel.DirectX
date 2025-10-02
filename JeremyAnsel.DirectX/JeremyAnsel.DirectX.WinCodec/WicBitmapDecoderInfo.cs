using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapDecoderInfo : WicBitmapCodecInfo
{
    private IWicBitmapDecoderInfo? _handle;

    internal WicBitmapDecoderInfo(IWicBitmapDecoderInfo handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapDecoderInfo(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapDecoderInfo)handle;
    }

    internal IWicBitmapDecoderInfo GetWicBitmapDecoderInfo()
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

    public bool MatchesPattern(Stream stream)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var comStream = new WicWin32ComStream(stream);
        _handle.MatchesPattern(comStream, out bool value);
        return value;
    }

    public WicBitmapDecoder CreateInstance()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateInstance(out IWicBitmapDecoder decoder);
        return new WicBitmapDecoder(decoder);
    }
}
