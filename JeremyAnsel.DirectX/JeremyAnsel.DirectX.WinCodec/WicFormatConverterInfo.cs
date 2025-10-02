using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicFormatConverterInfo : WicComponentInfo
{
    private IWicFormatConverterInfo? _handle;

    internal WicFormatConverterInfo(IWicFormatConverterInfo handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicFormatConverterInfo(object handle)
        : base(handle)
    {
        _handle = (IWicFormatConverterInfo)handle;
    }

    internal IWicFormatConverterInfo GetWicFormatConverterInfo()
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

    public WicPixelFormatGuid[] GetPixelFormats()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetPixelFormats(0, null, out uint actual);

        if (actual <= 0)
        {
            return Array.Empty<WicPixelFormatGuid>();
        }

        var formats = new WicPixelFormatGuid[actual];
        _handle.GetPixelFormats(actual, formats, out actual);
        return formats;
    }

    public WicFormatConverter CreateInstance()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateInstance(out IWicFormatConverter converter);
        return new WicFormatConverter(converter);
    }
}
