using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;
using System.Text;

namespace JeremyAnsel.DirectX.WinCodec;

public class WicBitmapCodecInfo : WicComponentInfo
{
    private IWicBitmapCodecInfo? _handle;

    internal WicBitmapCodecInfo(IWicBitmapCodecInfo handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapCodecInfo(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapCodecInfo)handle;
    }

    internal IWicBitmapCodecInfo GetWicBitmapCodecInfo()
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

    public Guid GetContainerFormat()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetContainerFormat(out Guid guid);
        return guid;
    }

    public Guid[] GetPixelFormats()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetPixelFormats(0, null, out uint actual);

        if (actual <= 0)
        {
            return Array.Empty<Guid>();
        }

        var formats = new Guid[actual];
        _handle.GetPixelFormats(actual, formats, out actual);
        return formats;
    }

    public string GetColorManagementVersion()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(256);
        _handle.GetColorManagementVersion(256, sb, out uint actual);
        return sb.ToString();
    }

    public string GetDeviceManufacturer()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(256);
        _handle.GetDeviceManufacturer(256, sb, out uint actual);
        return sb.ToString();
    }

    public string GetDeviceModels()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(1024);
        _handle.GetDeviceModels(1024, sb, out uint actual);
        return sb.ToString();
    }

    public string GetMimeTypes()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(1024);
        _handle.GetMimeTypes(1024, sb, out uint actual);
        return sb.ToString();
    }

    public string GetFileExtensions()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(1024);
        _handle.GetFileExtensions(1024, sb, out uint actual);
        return sb.ToString();
    }

    public bool DoesSupportAnimation()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.DoesSupportAnimation(out bool value);
        return value;
    }

    public bool DoesSupportChromakey()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.DoesSupportChromakey(out bool value);
        return value;
    }

    public bool DoesSupportLossless()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.DoesSupportLossless(out bool value);
        return value;
    }

    public bool DoesSupportMultiframe()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.DoesSupportMultiframe(out bool value);
        return value;
    }

    public bool MatchesMimeType(string mimeType)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.MatchesMimeType(mimeType, out bool value);
        return value;
    }
}
