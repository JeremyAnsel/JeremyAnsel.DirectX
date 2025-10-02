using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicImageEncoder : IDisposable
{
    private IWicImageEncoder? _handle;

    internal WicImageEncoder(IWicImageEncoder handle)
    {
        _handle = handle;
    }

    public WicImageEncoder(object handle)
    {
        _handle = (IWicImageEncoder)handle;
    }

    internal IWicImageEncoder GetWicImageEncoder()
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

    public unsafe void WriteFrame(object d2d1Image, WicBitmapFrameEncode encode, WicImageParameters? parameters)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (parameters is null)
        {
            _handle.WriteFrame((ID2D1Image)d2d1Image, encode.GetWicBitmapFrameEncode(), IntPtr.Zero);
        }
        else
        {
            WicImageParameters pParameters = parameters.Value;
            _handle.WriteFrame((ID2D1Image)d2d1Image, encode.GetWicBitmapFrameEncode(), new IntPtr(&pParameters));
        }
    }

    public unsafe void WriteFrameThumbnail(object d2d1Image, WicBitmapFrameEncode encode, WicImageParameters? parameters)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (parameters is null)
        {
            _handle.WriteFrameThumbnail((ID2D1Image)d2d1Image, encode.GetWicBitmapFrameEncode(), IntPtr.Zero);
        }
        else
        {
            WicImageParameters pParameters = parameters.Value;
            _handle.WriteFrameThumbnail((ID2D1Image)d2d1Image, encode.GetWicBitmapFrameEncode(), new IntPtr(&pParameters));
        }
    }

    public unsafe void WriteThumbnail(object d2d1Image, WicBitmapEncoder encode, WicImageParameters? parameters)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (parameters is null)
        {
            _handle.WriteThumbnail((ID2D1Image)d2d1Image, encode.GetWicBitmapEncoder(), IntPtr.Zero);
        }
        else
        {
            WicImageParameters pParameters = parameters.Value;
            _handle.WriteThumbnail((ID2D1Image)d2d1Image, encode.GetWicBitmapEncoder(), new IntPtr(&pParameters));
        }
    }
}
