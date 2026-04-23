// <copyright file="D3D11ColorWriteEnables.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Identify which components of each pixel of a render target are writable during blending.
/// </summary>
[SuppressMessage("Microsoft.Design", "CA1028:EnumStorageShouldBeInt32", Justification = "Reviewed")]
[Flags]
public enum D3D11ColorWriteEnables : byte
{
    /// <summary>
    /// No value.
    /// </summary>
    None = 0,

    /// <summary>
    /// Allow data to be stored in the red component.
    /// </summary>
    Red = 1,

    /// <summary>
    /// Allow data to be stored in the green component.
    /// </summary>
    Green = 2,

    /// <summary>
    /// Allow data to be stored in the blue component.
    /// </summary>
    Blue = 4,

    /// <summary>
    /// Allow data to be stored in the alpha component.
    /// </summary>
    Alpha = 8,

    /// <summary>
    /// Allow data to be stored in all components.
    /// </summary>
    All = Red | Green | Blue | Alpha,
}
