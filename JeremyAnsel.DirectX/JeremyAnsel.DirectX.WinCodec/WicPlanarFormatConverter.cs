using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicPlanarFormatConverter : WicBitmapSource
{
    private IWicPlanarFormatConverter? _handle;

    internal WicPlanarFormatConverter(IWicPlanarFormatConverter handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicPlanarFormatConverter(object handle)
        : base(handle)
    {
        _handle = (IWicPlanarFormatConverter)handle;
    }

    public WicPlanarFormatConverter(WicFormatConverter converter)
        : base(converter.GetWicBitmapSource())
    {
        _handle = (IWicPlanarFormatConverter)converter.GetWicBitmapSource();
    }

    internal IWicPlanarFormatConverter GetWicPlanarFormatConverter()
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
        WicBitmapSource[] ppPlanes,
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
            Array.ConvertAll(ppPlanes, t => t.GetWicBitmapSource()),
            (uint)ppPlanes.Length,
            dstFormat,
            dither,
            pIPalette?.GetWicPalette(),
            alphaThresholdPercent,
            paletteTranslate);
    }

    public bool CanConvert(WicPixelFormatGuid[] pSrcPixelFormats, in WicPixelFormatGuid dstPixelFormat)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CanConvert(pSrcPixelFormats, (uint)pSrcPixelFormats.Length, dstPixelFormat, out bool canConvert);
        return canConvert;
    }
}
