// <copyright file="IWicBitmapSourceTransform.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSourceTransform"/></remarks>
[Guid("c3373fdf-6d39-4e5f-8e79-bf40c0b7ed77")]
internal unsafe readonly struct IWicBitmapSourceTransform2
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
