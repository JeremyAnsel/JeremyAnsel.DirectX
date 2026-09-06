using System.Numerics;

namespace JeremyAnsel.DirectX.DirectSound;

internal unsafe readonly struct IDirectSound3DListener
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetAllParameters;
    public readonly delegate* unmanaged[Stdcall]<nint, float*, int> GetDistanceFactor;
    public readonly delegate* unmanaged[Stdcall]<nint, float*, int> GetDopplerFactor;
    public readonly delegate* unmanaged[Stdcall]<nint, Vector3*, Vector3*, int> GetOrientation;
    public readonly delegate* unmanaged[Stdcall]<nint, Vector3*, int> GetPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, float*, int> GetRolloffFactor;
    public readonly delegate* unmanaged[Stdcall]<nint, Vector3*, int> GetVelocity;
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int, int> SetAllParameters;
    public readonly delegate* unmanaged[Stdcall]<nint, float, int, int> SetDistanceFactor;
    public readonly delegate* unmanaged[Stdcall]<nint, float, int, int> SetDopplerFactor;
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, float, float, float, int, int> SetOrientation;
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, int, int> SetPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, float, int, int> SetRolloffFactor;
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, int, int> SetVelocity;
    public readonly delegate* unmanaged[Stdcall]<nint, int> CommitDeferredSettings;
}
