namespace JeremyAnsel.DirectX.DirectSound;

internal unsafe readonly struct IDirectSound
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, nint, int> CreateSoundBuffer;
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetCaps;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, int> DuplicateSoundBuffer;
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, int> SetCooperativeLevel;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Compact;
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetSpeakerConfig;
    public readonly delegate* unmanaged[Stdcall]<nint, int, int> SetSpeakerConfig;
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> Initialize;
}
