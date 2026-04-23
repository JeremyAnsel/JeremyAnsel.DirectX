// <copyright file="IWicBitmapFrameChainReader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("0c599495-a120-4222-9130-a8c29410bd0b")]
internal unsafe readonly struct IWicBitmapFrameChainReader
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
