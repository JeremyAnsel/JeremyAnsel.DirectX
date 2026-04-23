// <copyright file="IWicImageEncoder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("04C75BF8-3CE1-473B-ACC5-3CC4F5E94999")]
internal unsafe readonly struct IWicImageEncoder
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, WicImageParameters*, int> WriteFrame;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, WicImageParameters*, int> WriteFrameThumbnail;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, WicImageParameters*, int> WriteThumbnail;
}
