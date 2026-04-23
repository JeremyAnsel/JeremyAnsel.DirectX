// <copyright file="IDWriteFontList.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The IDWriteFontList interface represents a list of fonts.
/// </summary>
[Guid("1a0d8438-1d97-4ec1-aef9-a2fb86ed6acb")]
internal unsafe readonly struct IDWriteFontList
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Gets the font collection that contains the fonts.
    /// </summary>
    /// <param name="fontCollection">Receives a pointer to the font collection object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetFontCollection;

    /// <summary>
    /// Gets the number of fonts in the font list.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetFontCount;

    /// <summary>
    /// Gets a font given its zero-based index.
    /// </summary>
    /// <param name="index">Zero-based index of the font in the font list.</param>
    /// <param name="font">Receives a pointer to the newly created font object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> GetFont;
}
