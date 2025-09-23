using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

public sealed class DirectInputEffect : IDisposable
{
    private IDirectInputEffect? _handle;

    internal DirectInputEffect(IDirectInputEffect? handle, DirectInputEffectInfo infos)
    {
        if (handle is null)
        {
            throw new ArgumentNullException(nameof(handle));
        }

        _handle = handle;
        Infos = infos;
    }

    public DirectInputEffectInfo Infos { get; }

    public void Dispose()
    {
        if (_handle is not null)
        {
            Marshal.ReleaseComObject(_handle);
            _handle = null;
        }
    }

    public Guid GetEffectGuid()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetEffectGuid(out Guid guid);
        return guid;
    }

    public DirectInputEffectParametersData GetParameters(DirectInputEffectParameterOptions options)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        DirectInputEffectParametersData data;
        IntPtr ptr = DirectInputEffectParametersData.AllocRawData(options, Infos.EffectType);

        try
        {
            _handle.GetParameters(ptr, (DIEP)(uint)options);
            data = DirectInputEffectParametersData.FromRawData(ptr, options, Infos.EffectType);
        }
        finally
        {
            DirectInputEffectParametersData.FreeRawData(ptr);
        }

        return data;
    }

    public void SetParameters(DirectInputEffectParametersData peff, DirectInputEffectParameterOptions options)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        IntPtr ptr = peff.ToRawData(options);

        try
        {
            _handle.SetParameters(ptr, (DIEP)(uint)options);
        }
        finally
        {
            DirectInputEffectParametersData.FreeRawData(ptr);
        }
    }

    public void Start(int iterations, DirectInputEffectStartOptions options)
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Start(iterations, (DIES)(uint)options);
    }

    public void Stop()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Stop();
    }

    public DirectInputEffectStatus GetEffectStatus()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.GetEffectStatus(out DIEGES status);
        return (DirectInputEffectStatus)(uint)status;
    }

    public void Download()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Download();
    }

    public void Unload()
    {
        if (_handle is null)
        {
            throw new ObjectDisposedException(nameof(_handle));
        }

        _handle.Unload();
    }
}
