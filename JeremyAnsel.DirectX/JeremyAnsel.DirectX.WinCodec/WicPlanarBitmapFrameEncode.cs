using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicPlanarBitmapFrameEncode : IDisposable
{
    private IWicPlanarBitmapFrameEncode? _handle;

    internal WicPlanarBitmapFrameEncode(IWicPlanarBitmapFrameEncode handle)
    {
        _handle = handle;
    }

    public WicPlanarBitmapFrameEncode(object handle)
    {
        _handle = (IWicPlanarBitmapFrameEncode)handle;
    }

    public WicPlanarBitmapFrameEncode(WicBitmapFrameEncode encode)
    {
        _handle = (IWicPlanarBitmapFrameEncode)encode.GetWicBitmapFrameEncode();
    }

    internal IWicPlanarBitmapFrameEncode GetWicPlanarBitmapFrameEncode()
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

    public void WritePixels(uint lineCount, WicBitmapPlane[] planes)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        GCHandle[] handles = new GCHandle[planes.Length];
        for (int i = 0; i < planes.Length; i++)
        {
            handles[i] = GCHandle.Alloc(planes[i].Buffer, GCHandleType.Pinned);
        }

        try
        {
            WicBitmapPlanePtr[] pPlanes = new WicBitmapPlanePtr[planes.Length];

            for (int i = 0; i < planes.Length; i++)
            {
                pPlanes[i] = new WicBitmapPlanePtr(planes[i].Format, handles[i].AddrOfPinnedObject(), planes[i].Stride, planes[i].BufferSize);
            }

            _handle.WritePixels(lineCount, pPlanes, (uint)planes.Length);
        }
        finally
        {
            for (int i = 0; i < planes.Length; i++)
            {
                handles[i].Free();
            }
        }
    }

    public unsafe void WriteSource(WicBitmapSource[] ppPlanes, WicRect? rc)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        if (rc is null)
        {
            _handle.WriteSource(Array.ConvertAll(ppPlanes, t => t.GetWicBitmapSource()), (uint)ppPlanes.Length, IntPtr.Zero);
        }
        else
        {
            WicRect prc = rc.Value;
            _handle.WriteSource(Array.ConvertAll(ppPlanes, t => t.GetWicBitmapSource()), (uint)ppPlanes.Length, new IntPtr(&prc));
        }
    }
}
