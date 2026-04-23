// <copyright file="IWicPlanarBitmapSourceTransform.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("3AFF9CCE-BE95-4303-B927-E7D16FF4A613")]
internal unsafe readonly struct IWicPlanarBitmapSourceTransform
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
