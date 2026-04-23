// <copyright file="DWriteFontFile.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The interface that represents a reference to a font file.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFontFile : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFontFileGuid = typeof(IDWriteFontFile).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFontFile* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFontFile"/> class.
    /// </summary>
    public DWriteFontFile(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFontFile**)comPtr;
    }

    /// <summary>
    /// Gets the reference key size of a font file.
    /// </summary>
    /// <returns></returns>
    public uint GetReferenceKeySize()
    {
        nint keyPtr;
        uint size;
        int hr = _comImpl->GetReferenceKey(_comPtr, &keyPtr, &size);
        Marshal.ThrowExceptionForHR(hr);
        return size;
    }

    /// <summary>
    /// Gets the reference key of a font file.
    /// </summary>
    /// <returns><see cref="byte"/></returns>
    public byte[] GetReferenceKey()
    {
        nint keyPtr;
        uint size;
        int hr = _comImpl->GetReferenceKey(_comPtr, &keyPtr, &size);
        Marshal.ThrowExceptionForHR(hr);
        var key = new byte[size];
        Marshal.Copy(keyPtr, key, 0, (int)size);
        return key;
    }

    /// <summary>
    /// Gets the reference key of a font file.
    /// </summary>
    public void GetReferenceKey(Span<byte> key)
    {
        nint keyPtr;
        uint size;
        int hr = _comImpl->GetReferenceKey(_comPtr, &keyPtr, &size);
        Marshal.ThrowExceptionForHR(hr);
        new Span<byte>((void*)keyPtr, (int)size).CopyTo(key);
    }

    /// <summary>
    /// Analyzes a file and returns whether it represents a font, and whether the font type is supported by the font system.
    /// </summary>
    /// <param name="isSupportedFontType">TRUE if the font type is supported by the font system, FALSE otherwise.</param>
    /// <param name="fontFileType">The type of the font file. Note that even if isSupportedFontType is FALSE,
    /// the fontFileType value may be different from DWRITE_FONT_FILE_TYPE_UNKNOWN.</param>
    /// <param name="fontFaceType">The type of the font face that can be constructed from the font file.
    /// Note that even if isSupportedFontType is FALSE, the fontFaceType value may be different from
    /// DWRITE_FONT_FACE_TYPE_UNKNOWN.</param>
    /// <param name="numberOfFaces">Number of font faces contained in the font file.</param>
    /// <remarks>
    /// IMPORTANT: certain font file types are recognized, but not supported by the font system.
    /// For example, the font system will recognize a file as a Type 1 font file,
    /// but will not be able to construct a font face object from it. In such situations, Analyze will set
    /// isSupportedFontType output parameter to FALSE.
    /// </remarks>
    public void Analyse(out bool isSupportedFontType, out DWriteFontFileType fontFileType, out DWriteFontFaceType fontFaceType, out uint numberOfFaces)
    {
        int supported;
        DWriteFontFileType file;
        DWriteFontFaceType face;
        uint count;
        int hr = _comImpl->Analyse(_comPtr, &supported, &file, &face, &count);
        Marshal.ThrowExceptionForHR(hr);
        isSupportedFontType = supported != 0;
        fontFileType = file;
        fontFaceType = face;
        numberOfFaces = count;
    }
}
