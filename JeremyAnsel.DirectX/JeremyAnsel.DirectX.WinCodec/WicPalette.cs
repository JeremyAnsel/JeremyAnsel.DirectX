using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicPalette : IDisposable
{
    private IWicPalette? _handle;

    internal WicPalette(IWicPalette handle)
    {
        _handle = handle;
    }

    public WicPalette(object handle)
    {
        _handle = (IWicPalette)handle;
    }

    internal IWicPalette GetWicPalette()
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

    public void InitializePredefined(WicBitmapPaletteType ePaletteType, bool fAddTransparentColor)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializePredefined(ePaletteType, fAddTransparentColor);
    }

    public void InitializeCustom(WicColor[] colors)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializeCustom(colors, (uint)colors.Length);
    }

    public void InitializeFromBitmap(WicBitmapSource surface, uint colorCount, bool fAddTransparentColor)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializeFromBitmap(surface.GetWicBitmapSource(), colorCount, fAddTransparentColor);
    }

    public void InitializeFromPalette(WicPalette palette)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.InitializeFromPalette(palette.GetWicPalette());
    }

    public WicBitmapPaletteType GetPaletteType()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetType(out WicBitmapPaletteType type);
        return type;
    }

    public uint GetColorCount()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetColorCount(out uint count);
        return count;
    }

    public WicColor[] GetColors()
    {
        return GetColors(out _);
    }

    public WicColor[] GetColors(out uint actualColors)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetColorCount(out uint colorCount);
        var colors = new WicColor[colorCount];
        _handle.GetColors(colorCount, colors, out actualColors);
        return colors;
    }

    public bool IsBlackWhite()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.IsBlackWhite(out bool isBlackWhite);
        return isBlackWhite;
    }

    public bool IsGrayscale()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.IsGrayscale(out bool isGrayscale);
        return isGrayscale;
    }

    public bool HasAlpha()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.HasAlpha(out bool hasAlpha);
        return hasAlpha;
    }
}
