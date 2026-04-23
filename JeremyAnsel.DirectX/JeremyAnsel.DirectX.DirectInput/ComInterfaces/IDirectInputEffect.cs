// <copyright file="IDirectInputEffect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[Guid(DirectInputGuids.IDirectInputEffectString)]
internal unsafe readonly struct IDirectInputEffect
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, in Guid, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetEffectGuid;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, int> GetParameters;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, int> SetParameters;

    public readonly delegate* unmanaged[Stdcall]<nint, int, uint, int> Start;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Stop;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetEffectStatus;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Download;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Unload;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> Escape;
}
