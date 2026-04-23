// <copyright file="IWicProgressiveLevelControl.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("DAAC296F-7AA5-4dbf-8D15-225C5976F891")]
internal unsafe readonly struct IWicProgressiveLevelControl
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
