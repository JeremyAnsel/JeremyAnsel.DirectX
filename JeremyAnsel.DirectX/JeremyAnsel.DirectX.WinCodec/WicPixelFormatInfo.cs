using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicPixelFormatInfo : WicComponentInfo
{
    private IWicPixelFormatInfo2? _handle;

    internal WicPixelFormatInfo(IWicPixelFormatInfo2 handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicPixelFormatInfo(object handle)
        : base(handle)
    {
        _handle = (IWicPixelFormatInfo2)handle;
    }

    internal IWicPixelFormatInfo2 GetWicPixelFormatInfo2()
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

    public Guid GetFormatGUID()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetFormatGUID(out Guid format);
        return format;
    }

    public WicColorContext GetColorContext()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetColorContext(out IWicColorContext context);
        return new WicColorContext(context);
    }

    public uint GetBitsPerPixel()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetBitsPerPixel(out uint bpp);
        return bpp;
    }

    public uint GetChannelCount()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetChannelCount(out uint channels);
        return channels;
    }

    public bool SupportsTransparency()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SupportsTransparency(out bool value);
        return value;
    }

    public WicPixelFormatNumericRepresentation GetNumericRepresentation()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetNumericRepresentation(out WicPixelFormatNumericRepresentation numericRepresentation);
        return numericRepresentation;
    }
}
