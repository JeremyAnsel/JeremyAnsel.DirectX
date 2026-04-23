// <copyright file="IDXUnknown.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXCommon.ComInterfaces;

internal unsafe readonly struct IDXUnknown
{
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint*, int> QueryInterface;
    public readonly delegate* unmanaged[Stdcall]<nint, int> AddRef;
    public readonly delegate* unmanaged[Stdcall]<nint, int> Release;
}
