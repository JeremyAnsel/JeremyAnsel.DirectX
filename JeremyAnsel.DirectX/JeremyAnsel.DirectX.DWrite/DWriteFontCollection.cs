// <copyright file="DWriteFontCollection.cs" company="Jérémy Ansel">
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
/// The DWriteFontCollection encapsulates a collection of fonts.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFontCollection : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFontCollectionGuid = typeof(IDWriteFontCollection).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFontCollection* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFontCollection"/> class.
    /// </summary>
    public DWriteFontCollection(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFontCollection**)comPtr;
    }

    /// <summary>
    /// Gets the number of font families in the collection.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetFontFamilyCount()
    {
        return _comImpl->GetFontFamilyCount(_comPtr);
    }

    /// <summary>
    /// Creates a font family object given a zero-based font family index.
    /// </summary>
    /// <param name="index">Zero-based index of the font family.</param>
    /// <returns><see cref="DWriteFontFamily"/></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DWriteFontFamily GetFontFamily(uint index)
    {
        nint ptr;
        int hr = _comImpl->GetFontFamily(_comPtr, index, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontFamily(ptr);
    }

    /// <summary>
    /// Finds the font family with the specified family name.
    /// </summary>
    /// <param name="familyName">Name of the font family. The name is not case-sensitive but must otherwise exactly match a family name in the collection.</param>
    /// <param name="index">Receives the zero-based index of the matching font family if the family name was found or UINT_MAX otherwise.</param>
    /// <returns>TRUE if the family name exists or FALSE otherwise.</returns>
    public uint FindFontFamily(string familyName)
    {
        return FindFontFamily(familyName.AsSpan());
    }

    /// <summary>
    /// Finds the font family with the specified family name.
    /// </summary>
    /// <param name="familyName">Name of the font family. The name is not case-sensitive but must otherwise exactly match a family name in the collection.</param>
    /// <param name="index">Receives the zero-based index of the matching font family if the family name was found or UINT_MAX otherwise.</param>
    /// <returns>TRUE if the family name exists or FALSE otherwise.</returns>
    public uint FindFontFamily(ReadOnlySpan<char> familyName)
    {
        fixed (char* familyNamePtr = familyName)
        {
            uint index;
            int exists;
            int hr = _comImpl->FindFontFamily(_comPtr, familyNamePtr, &index, &exists);
            Marshal.ThrowExceptionForHR(hr);
            return index;
        }
    }

    /// <summary>
    /// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical font must belong 
    /// to the font collection.
    /// </summary>
    /// <param name="fontFace">Font face object that specifies the physical font.</param>
    /// <remarks>
    /// If the specified physical font is not part of the font collection the return value is DWRITE_E_NOFONT.
    /// </remarks>
    /// <returns><see cref="DWriteFont"/></returns>
    public DWriteFont GetFontFromFontFace(DWriteFontFace? fontFace)
    {
        if (fontFace is null)
        {
            throw new ArgumentNullException(nameof(fontFace));
        }

        nint ptr;
        int hr = _comImpl->GetFontFromFontFace(_comPtr, fontFace.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFont(ptr);
    }
}
