using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicFormatConverter : WicBitmapSource
{
    private IWicFormatConverter? _handle;

    internal WicFormatConverter(IWicFormatConverter handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicFormatConverter(object handle)
        : base(handle)
    {
        _handle = (IWicFormatConverter)handle;
    }

    internal IWicFormatConverter GetWicFormatConverter()
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
        WicBitmapSource pISource,
        in WicPixelFormatGuid dstFormat,
        WicBitmapDitherType dither,
        WicPalette? pIPalette,
        double alphaThresholdPercent,
        WicBitmapPaletteType paletteTranslate)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Initialize(
            pISource.GetWicBitmapSource(),
            dstFormat,
            dither,
            pIPalette is null ? null : pIPalette.GetWicPalette(),
            alphaThresholdPercent,
            paletteTranslate);
    }

    public bool CanConvert(in WicPixelFormatGuid srcPixelFormat, in WicPixelFormatGuid dstPixelFormat)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CanConvert(srcPixelFormat, dstPixelFormat, out bool canConvert);
        return canConvert;
    }
}
