// <copyright file="IWicBitmapSourceTransform.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid(Guid)]
internal unsafe readonly struct IWicBitmapSourceTransform
{
    public const string Guid = "3B16811B-6A43-4ec9-B713-3D5A0C13B940";

    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
