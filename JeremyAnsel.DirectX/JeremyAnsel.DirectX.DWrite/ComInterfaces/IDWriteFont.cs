// <copyright file="IDWriteFont.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The IDWriteFont interface represents a physical font in a font collection.
/// </summary>
[Guid("acd16696-8c14-4f5d-877e-fe3fc1d32737")]
internal unsafe readonly struct IDWriteFont
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Gets the font family to which the specified font belongs.
    /// </summary>
    /// <param name="fontFamily">Receives a pointer to the font family object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetFontFamily;

    /// <summary>
    /// Gets the weight of the specified font.
    /// </summary>
    /// <returns><see cref="DWriteFontWeight"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontWeight> GetWeight;

    /// <summary>
    /// Gets the stretch (aka. width) of the specified font.
    /// </summary>
    /// <returns><see cref="DWriteFontStretch"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontStretch> GetStretch;

    /// <summary>
    /// Gets the style (aka. slope) of the specified font.
    /// </summary>
    /// <returns><see cref="DWriteFontStyle"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontStyle> GetStyle;

    /// <summary>
    /// Returns TRUE if the font is a symbol font or FALSE if not.
    /// </summary>
    /// <returns><see cref="bool"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int> IsSymbolFont;

    /// <summary>
    /// Gets a localized strings collection containing the face names for the font (e.g., Regular or Bold), indexed by locale name.
    /// </summary>
    /// <param name="names">Receives a pointer to the newly created localized strings object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetFaceNames;

    /// <summary>
    /// Gets a localized strings collection containing the specified informational strings, indexed by locale name.
    /// </summary>
    /// <param name="informationalStringID">Identifies the string to get.</param>
    /// <param name="informationalStrings">Receives a pointer to the newly created localized strings object.</param>
    /// <param name="exists">Receives the value TRUE if the font contains the specified string ID or FALSE if not.</param>
    /// <remarks>
    /// If the font does not contain the specified string, the return value is S_OK but 
    /// informationalStrings receives a NULL pointer and exists receives the value FALSE.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteInformationalStringId, nint*, int*, int> GetInformationalStrings;

    /// <summary>
    /// Gets a value that indicates what simulation are applied to the specified font.
    /// </summary>
    /// <returns><see cref="DWriteFontSimulations"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontSimulations> GetSimulations;

    /// <summary>
    /// Gets the metrics for the font.
    /// </summary>
    /// <param name="fontMetrics">Receives the font metrics.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetMetrics;

    /// <summary>
    /// Determines whether the font supports the specified character.
    /// </summary>
    /// <param name="unicodeValue">Unicode (UCS-4) character value.</param>
    /// <param name="exists">Receives the value TRUE if the font supports the specified character or FALSE if not.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int*, int> HasCharacter;

    /// <summary>
    /// Creates a font face object for the font.
    /// </summary>
    /// <param name="fontFace">Receives a pointer to the newly created font face object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateFontFace;
}
