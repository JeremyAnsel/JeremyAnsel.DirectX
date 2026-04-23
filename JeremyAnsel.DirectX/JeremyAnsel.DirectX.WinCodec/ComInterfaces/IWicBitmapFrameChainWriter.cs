// <copyright file="IWicBitmapFrameChainWriter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("40d9ea28-4768-47b3-8c12-558a48e98e38")]
internal unsafe readonly struct IWicBitmapFrameChainWriter
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
