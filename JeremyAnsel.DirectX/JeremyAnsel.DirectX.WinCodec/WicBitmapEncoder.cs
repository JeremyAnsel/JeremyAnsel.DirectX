using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapEncoder : IDisposable
{
    private IWicBitmapEncoder? _handle;

    internal WicBitmapEncoder(IWicBitmapEncoder handle)
    {
        _handle = handle;
    }

    public WicBitmapEncoder(object handle)
    {
        _handle = (IWicBitmapEncoder)handle;
    }

    internal IWicBitmapEncoder GetWicBitmapEncoder()
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

    public void Initialize(Stream stream, WicBitmapEncoderCacheOption cacheOption)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var comStream = new WicWin32ComStream(stream);
        _handle.Initialize(comStream, cacheOption);
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

    public WicBitmapEncoderInfo GetEncoderInfo()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetEncoderInfo(out IWicBitmapEncoderInfo encoderInfo);
        return new WicBitmapEncoderInfo(encoderInfo);
    }

    public void SetColorContexts(WicColorContext[] ppIColorContext)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetColorContexts((uint)ppIColorContext.Length, Array.ConvertAll(ppIColorContext, t => t.GetWicColorContext()));
    }

    public void SetPalette(WicPalette pIPalette)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetPalette(pIPalette.GetWicPalette());
    }

    public void SetThumbnail(WicBitmapSource pIThumbnail)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetThumbnail(pIThumbnail.GetWicBitmapSource());
    }

    public void SetPreview(WicBitmapSource pIPreview)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetPreview(pIPreview.GetWicBitmapSource());
    }

    public WicBitmapFrameEncode CreateNewFrame()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateNewFrame(out IWicBitmapFrameEncode frame, IntPtr.Zero);
        return new WicBitmapFrameEncode(frame);
    }

    public void Commit()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Commit();
    }
}
