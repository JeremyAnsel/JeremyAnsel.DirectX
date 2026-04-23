// <copyright file="IWicDdsEncoder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("5cacdb4c-407e-41b3-b936-d0f010cd6732")]
internal unsafe readonly struct IWicDdsEncoder
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, in WicDdsParameters, int> SetParameters;

    public readonly delegate* unmanaged[Stdcall]<nint, WicDdsParameters*, int> GetParameters;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint*, uint*, uint*, int> CreateNewFrame;
}
