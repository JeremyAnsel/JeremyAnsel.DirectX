// <copyright file="IWicDdsFrameDecode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("3d4c0c61-18a4-41e4-bd80-481a4fc9f464")]
internal unsafe readonly struct IWicDdsFrameDecode
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, uint*, int> GetSizeInBlocks;

    public readonly delegate* unmanaged[Stdcall]<nint, WicDdsFormatInfo*, int> GetFormatInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, WicRect*, uint, uint, void*, int> CopyBlocks;
}
