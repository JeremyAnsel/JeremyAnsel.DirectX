using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicDdsFrameDecode : IDisposable
{
    private IWicDdsFrameDecode? _handle;

    internal WicDdsFrameDecode(IWicDdsFrameDecode handle)
    {
        _handle = handle;
    }

    public WicDdsFrameDecode(object handle)
    {
        _handle = (IWicDdsFrameDecode)handle;
    }

    public WicDdsFrameDecode(WicBitmapFrameDecode decode)
    {
        _handle = (IWicDdsFrameDecode)decode.GetWicBitmapFrameDecode();
    }

    internal IWicDdsFrameDecode GetWicDdsFrameDecode()
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

    public void GetSizeInBlocks(uint pWidthInBlocks, uint pHeightInBlocks)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetSizeInBlocks(out pWidthInBlocks, out pHeightInBlocks);
    }

    public WicDdsFormatInfo GetFormatInfo()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetFormatInfo(out WicDdsFormatInfo info);
        return info;
    }

    public unsafe void CopyBlocks(WicRect? rc, uint cbStride, byte[] buffer)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (rc is null)
        {
            _handle.CopyBlocks(IntPtr.Zero, cbStride, (uint)buffer.Length, buffer);
        }
        else
        {
            WicRect prc = rc.Value;
            _handle.CopyBlocks(new IntPtr(&prc), cbStride, (uint)buffer.Length, buffer);
        }
    }
}
