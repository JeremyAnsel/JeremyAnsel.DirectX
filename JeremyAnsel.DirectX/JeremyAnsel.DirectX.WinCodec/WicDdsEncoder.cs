using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicDdsEncoder : IDisposable
{
    private IWicDdsEncoder? _handle;

    internal WicDdsEncoder(IWicDdsEncoder handle)
    {
        _handle = handle;
    }

    public WicDdsEncoder(object handle)
    {
        _handle = (IWicDdsEncoder)handle;
    }

    public WicDdsEncoder(WicBitmapEncoder encoder)
    {
        _handle = (IWicDdsEncoder)encoder.GetWicBitmapEncoder();
    }

    internal IWicDdsEncoder GetWicDdsEncoder()
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

    public void SetParameters(in WicDdsParameters pParameters)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.SetParameters(pParameters);
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

    public WicBitmapFrameEncode CreateNewFrame()
    {
        return CreateNewFrame(out _, out _, out _);
    }

    public WicBitmapFrameEncode CreateNewFrame(out uint pArrayIndex, out uint pMipLevel, out uint pSliceIndex)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.CreateNewFrame(out IWicBitmapFrameEncode frame, out pArrayIndex, out pMipLevel, out pSliceIndex);
        return new WicBitmapFrameEncode(frame);
    }
}
