// <copyright file="IDWriteFontFamily.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The IDWriteFontFamily interface represents a set of fonts that share the same design but are differentiated
/// by weight, stretch, and style.
/// </summary>
/// <remarks>Inherited from <see cref="IDWriteFontList"/></remarks>
[Guid("da20d8ef-812a-4c43-9802-62ec4abd7add")]
internal unsafe readonly struct IDWriteFontFamily
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFontCollection;
    private readonly nint GetFontCount;
    private readonly nint GetFont;

    /// <summary>
    /// Creates a localized strings object that contains the family names for the font family, indexed by locale name.
    /// </summary>
    /// <param name="names">Receives a pointer to the newly created localized strings object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetFamilyNames;

    /// <summary>
    /// Gets the font that best matches the specified properties.
    /// </summary>
    /// <param name="weight">Requested font weight.</param>
    /// <param name="stretch">Requested font stretch.</param>
    /// <param name="style">Requested font style.</param>
    /// <param name="matchingFont">Receives a pointer to the newly created font object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontWeight, DWriteFontStretch, DWriteFontStyle, nint*, int> GetFirstMatchingFont;

    /// <summary>
    /// Gets a list of fonts in the font family ranked in order of how well they match the specified properties.
    /// </summary>
    /// <param name="weight">Requested font weight.</param>
    /// <param name="stretch">Requested font stretch.</param>
    /// <param name="style">Requested font style.</param>
    /// <param name="matchingFonts">Receives a pointer to the newly created font list object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontWeight, DWriteFontStretch, DWriteFontStyle, nint*, int> GetMatchingFonts;
}
