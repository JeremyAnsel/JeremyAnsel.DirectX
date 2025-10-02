using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.InteropServices;
using System.Text;

namespace JeremyAnsel.DirectX.WinCodec;

public class WicComponentInfo : IDisposable
{
    private IWicComponentInfo? _handle;

    internal WicComponentInfo(IWicComponentInfo handle)
    {
        _handle = handle;
    }

    public WicComponentInfo(object handle)
    {
        _handle = (IWicComponentInfo)handle;
    }

    internal IWicComponentInfo GetWicComponentInfo()
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
        OnDispose();
    }

    protected virtual void OnDispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }
    }

    public WicComponentType GetComponentType()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetComponentType(out WicComponentType type);
        return type;
    }

    public Guid GetCLSID()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetCLSID(out Guid guid);
        return guid;
    }

    public WicComponentSigning GetSigningStatus()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetSigningStatus(out WicComponentSigning status);
        return status;
    }

    public string GetAuthor()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(256);
        _handle.GetAuthor(256, sb, out uint actual);
        return sb.ToString();
    }

    public Guid GetVendorGUID()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetVendorGUID(out Guid guid);
        return guid;
    }

    public string GetVersion()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(256);
        _handle.GetVersion(256, sb, out uint actual);
        return sb.ToString();
    }

    public string GetSpecVersion()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(256);
        _handle.GetSpecVersion(256, sb, out uint actual);
        return sb.ToString();
    }

    public string GetFriendlyName()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        var sb = new StringBuilder(256);
        _handle.GetFriendlyName(256, sb, out uint actual);
        return sb.ToString();
    }
}
