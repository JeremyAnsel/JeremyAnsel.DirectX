// <copyright file="IDWriteFontFileEnumerator.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The font file enumerator interface encapsulates a collection of font files. The font system uses this interface
/// to enumerate font files when building a font collection.
/// </summary>
[Guid("72755049-5ff7-435d-8348-4be97cfa6c7c")]
internal unsafe readonly struct IDWriteFontFileEnumerator
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Advances to the next font file in the collection. When it is first created, the enumerator is positioned
    /// before the first element of the collection and the first call to MoveNext advances to the first file.
    /// </summary>
    /// <param name="hasCurrentFile">Receives the value TRUE if the enumerator advances to a file, or FALSE if
    /// the enumerator advanced past the last file in the collection.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> MoveNext;

    /// <summary>
    /// Gets a reference to the current font file.
    /// </summary>
    /// <param name="fontFile">Pointer to the newly created font file object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetCurrentFontFile;
}
