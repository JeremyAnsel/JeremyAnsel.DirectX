// <copyright file="IDWriteNumberSubstitution.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// Holds the appropriate digits and numeric punctuation for a given locale.
/// </summary>
[Guid("14885CC9-BAB0-4f90-B6ED-5C366A2CD03D")]
internal unsafe readonly struct IDWriteNumberSubstitution
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
}
