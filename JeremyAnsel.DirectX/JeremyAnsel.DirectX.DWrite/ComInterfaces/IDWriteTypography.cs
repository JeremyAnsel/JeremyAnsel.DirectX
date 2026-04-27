// <copyright file="IDWriteTypography.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// Font typography setting.
/// </summary>
[Guid("55f1112b-1dc2-4b3c-9541-f46894ed85b6")]
internal unsafe readonly struct IDWriteTypography
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Add font feature.
    /// </summary>
    /// <param name="fontFeature">The font feature to add.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontFeature, int> AddFontFeature;

    /// <summary>
    /// Get the number of font features.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetFontFeatureCount;

    /// <summary>
    /// Get the font feature at the specified index.
    /// </summary>
    /// <param name="fontFeatureIndex">The zero-based index of the font feature to get.</param>
    /// <param name="fontFeature">The font feature.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, int> GetFontFeature;
}
