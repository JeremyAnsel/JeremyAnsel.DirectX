using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapDecoder : IDisposable
{
    private IWicBitmapDecoder? _handle;

    internal WicBitmapDecoder(IWicBitmapDecoder handle)
    {
        _handle = handle;
    }

    public WicBitmapDecoder(object handle)
    {
        _handle = (IWicBitmapDecoder)handle;
    }

    internal IWicBitmapDecoder GetWicBitmapDecoder()
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

    public WicBitmapDecoderCapabilities QueryCapability(Stream stream)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var comStream = new WicWin32ComStream(stream);
        _handle.QueryCapability(comStream, out WicBitmapDecoderCapabilities pdwCapability);
        return pdwCapability;
    }

    public void Initialize(Stream stream, WicDecodeOptions cacheOptions)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var comStream = new WicWin32ComStream(stream);
        _handle.Initialize(comStream, cacheOptions);
    }

    public Guid GetContainerFormat()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetContainerFormat(out Guid format);
        return format;
    }

    public WicBitmapDecoderInfo GetDecoderInfo()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetDecoderInfo(out IWicBitmapDecoderInfo decoderInfo);
        return new WicBitmapDecoderInfo(decoderInfo);
    }

    public void CopyPalette(WicPalette palette)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CopyPalette(palette.GetWicPalette());
    }

    public WicBitmapSource GetPreview()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetPreview(out IWicBitmapSource preview);
        return new WicBitmapSource(preview);
    }

    public WicColorContext[] GetColorContexts()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetColorContexts(0, null, out uint pcActualCount);
        IWicColorContext[] contexts = new IWicColorContext[pcActualCount];
        _handle.GetColorContexts(pcActualCount, contexts, out pcActualCount);
        return Array.ConvertAll(contexts, t => new WicColorContext(t));
    }

    public WicBitmapSource GetThumbnail()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetThumbnail(out IWicBitmapSource thumbnail);
        return new WicBitmapSource(thumbnail);
    }

    public uint GetFrameCount()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetFrameCount(out uint count);
        return count;
    }

    public WicBitmapFrameDecode GetFrame(uint index)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetFrame(index, out IWicBitmapFrameDecode frame);
        return new WicBitmapFrameDecode(frame);
    }
}
