namespace JeremyAnsel.DirectX.DirectSound;

internal unsafe readonly struct IDirectSoundBuffer
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetCaps;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int*, int> GetCurrentPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int, int*, int> GetFormat;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetVolume;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetPan;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetFrequency;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetStatus;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, int> Initialize;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int, nint*, int*, nint*, int*, int, int> Lock;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int, int, int> Play;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int> SetCurrentPosition;
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> SetFormat;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int> SetVolume;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int> SetPan;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int> SetFrequency;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Stop;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, nint, int, int> Unlock;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Restore;
}
