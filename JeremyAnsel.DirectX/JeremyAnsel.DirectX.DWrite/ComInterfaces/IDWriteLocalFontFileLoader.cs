// <copyright file="IDWriteLocalFontFileLoader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// A built-in implementation of IDWriteFontFileLoader interface that operates on local font files
/// and exposes local font file information from the font file reference key.
/// Font file references created using CreateFontFileReference use this font file loader.
/// </summary>
/// <remarks>Inherited from <see cref="IDWriteFontFileLoader"/></remarks>
[Guid("b2d9f3ec-c9fe-4a11-a2ec-d86208f7c0a2")]
internal unsafe readonly struct IDWriteLocalFontFileLoader
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint CreateStreamFromKey;

    /// <summary>
    /// Obtains the length of the absolute file path from the font file reference key.
    /// </summary>
    /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the local font file
    /// within the scope of the font loader being used.</param>
    /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
    /// <param name="filePathLength">Length of the file path string not including the terminated NULL character.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, uint*, int> GetFilePathLengthFromKey;

    /// <summary>
    /// Obtains the absolute font file path from the font file reference key.
    /// </summary>
    /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the local font file
    /// within the scope of the font loader being used.</param>
    /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
    /// <param name="filePath">Character array that receives the local file path.</param>
    /// <param name="filePathSize">Size of the filePath array in character count including the terminated NULL character.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, char*, uint, int> GetFilePathFromKey;

    /// <summary>
    /// Obtains the last write time of the file from the font file reference key.
    /// </summary>
    /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the local font file
    /// within the scope of the font loader being used.</param>
    /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
    /// <param name="lastWriteTime">Last modified time of the font file.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, ulong*, int> GetLastWriteTimeFromKey;
}
