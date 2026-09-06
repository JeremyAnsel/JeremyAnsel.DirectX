using System.Numerics;

namespace JeremyAnsel.DirectX.DirectSound;

internal unsafe readonly struct IDirectSound3DBuffer
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetAllParameters;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int*, int> GetConeAngles;
    public readonly delegate* unmanaged[Stdcall]<nint, Vector3*, int> GetConeOrientation;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetConeOutsideVolume;
    public readonly delegate* unmanaged[Stdcall]<nint, float*, int> GetMaxDistance;
    public readonly delegate* unmanaged[Stdcall]<nint, float*, int> GetMinDistance;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetMode;
    public readonly delegate* unmanaged[Stdcall]<nint, Vector3*, int> GetPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, Vector3*, int> GetVelocity;
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int, int> SetAllParameters;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int, int, int> SetConeAngles;
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, int, int> SetConeOrientation;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int, int> SetConeOutsideVolume;
    public readonly delegate* unmanaged[Stdcall]<nint, float, int, int> SetMaxDistance;
    public readonly delegate* unmanaged[Stdcall]<nint, float, int, int> SetMinDistance;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int, int> SetMode;
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, int, int> SetPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, int, int> SetVelocity;
}
