// <copyright file="IWicDdsDecoder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("409cd537-8532-40cb-9774-e2feb2df4e9c")]
internal unsafe readonly struct IWicDdsDecoder
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, WicDdsParameters*, int> GetParameters;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint, nint*, int> GetFrame;
}
