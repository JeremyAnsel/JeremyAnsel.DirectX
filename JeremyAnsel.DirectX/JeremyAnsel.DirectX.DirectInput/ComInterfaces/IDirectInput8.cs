// <copyright file="IDirectInput8.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal delegate int LPDIENUMDEVICESCALLBACK(nint lpddi, nint pvRef);

internal delegate int LPDIENUMDEVICESBYSEMANTICSCB(nint lpddi, nint lpdid, DIEDBS dwFlags, int dwRemaining, nint pvRef);

[Guid(DirectInputGuids.IDirectInput8WString)]
internal unsafe readonly struct IDirectInput8
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint*, nint, int> CreateDevice;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, LPDIENUMDEVICESCALLBACK, nint, uint, int> EnumDevices;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, int> GetDeviceStatus;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, int> RunControlPanel;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, char*, Guid*, int> FindDevice;

    public readonly delegate* unmanaged[Stdcall]<nint, char*, void*, LPDIENUMDEVICESBYSEMANTICSCB, nint, uint, int> EnumDevicesBySemantics;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, int, nint, int> ConfigureDevices;
}
