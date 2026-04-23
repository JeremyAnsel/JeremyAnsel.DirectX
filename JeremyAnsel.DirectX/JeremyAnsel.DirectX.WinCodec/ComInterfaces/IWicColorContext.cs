// <copyright file="IWicBitmapFlipRotator.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("3C613A02-34B2-44ea-9A7C-45AEA9C6FD6D")]
internal unsafe readonly struct IWicColorContext
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, char*, int> InitializeFromFilename;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, int> InitializeFromMemory;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> InitializeFromExifColorSpace;

    public readonly delegate* unmanaged[Stdcall]<nint, WicColorContextType*, int> GetContextType;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, uint*, int> GetProfileBytes;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetExifColorSpace;
}
