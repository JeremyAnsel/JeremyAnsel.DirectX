using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

public sealed class WicBitmapFrameDecode : WicBitmapSource
{
    private IWicBitmapFrameDecode? _handle;

    internal WicBitmapFrameDecode(IWicBitmapFrameDecode handle)
        : base(handle)
    {
        _handle = handle;
    }

    public WicBitmapFrameDecode(object handle)
        : base(handle)
    {
        _handle = (IWicBitmapFrameDecode)handle;
    }

    internal IWicBitmapFrameDecode GetWicBitmapFrameDecode()
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

    public WicColorContext[] GetColorContexts()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetColorContexts(0, null, out uint actualCount);

        if (actualCount <= 0)
        {
            return Array.Empty<WicColorContext>();
        }

        var contexts = new IWicColorContext[actualCount];
        _handle.GetColorContexts(actualCount, contexts, out actualCount);
        return Array.ConvertAll(contexts, t => new WicColorContext(t));
    }

    public WicBitmapSource GetThumbnail()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetThumbnail(out IWicBitmapSource ppIThumbnail);
        return new WicBitmapSource(ppIThumbnail);
    }
}
