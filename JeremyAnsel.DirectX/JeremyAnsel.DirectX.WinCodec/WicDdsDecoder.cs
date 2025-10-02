using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicDdsDecoder : IDisposable
{
    private IWicDdsDecoder? _handle;

    internal WicDdsDecoder(IWicDdsDecoder handle)
    {
        _handle = handle;
    }

    public WicDdsDecoder(object handle)
    {
        _handle = (IWicDdsDecoder)handle;
    }

    public WicDdsDecoder(WicBitmapDecoder decoder)
    {
        _handle = (IWicDdsDecoder)decoder.GetWicBitmapDecoder();
    }

    internal IWicDdsDecoder GetWicDdsDecoder()
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

    public WicDdsParameters GetParameters()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetParameters(out WicDdsParameters parameters);
        return parameters;
    }

    public WicBitmapFrameDecode GetFrame(uint arrayIndex, uint mipLevel, uint sliceIndex)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetFrame(arrayIndex, mipLevel, sliceIndex, out IWicBitmapFrameDecode frame);
        return new WicBitmapFrameDecode(frame);
    }
}
