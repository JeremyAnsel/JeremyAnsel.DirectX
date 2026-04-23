// <copyright file="DWriteFontFamily.cs" company="Jérémy Ansel">
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
/// The IDWriteFontFamily interface represents a set of fonts that share the same design but are differentiated
/// by weight, stretch, and style.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFontFamily : DWriteFontList
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFontFamilyGuid = typeof(IDWriteFontFamily).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFontFamily* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFontFamily"/> class.
    /// </summary>
    public DWriteFontFamily(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFontFamily**)comPtr;
    }

    /// <summary>
    /// Creates a localized strings object that contains the family names for the font family, indexed by locale name.
    /// </summary>
    /// <returns><see cref="DWriteLocalizedStrings"/></returns>
    public DWriteLocalizedStrings GetFamilyNames()
    {
        nint ptr;
        int hr = _comImpl->GetFamilyNames(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteLocalizedStrings(ptr);
    }

    /// <summary>
    /// Gets the font that best matches the specified properties.
    /// </summary>
    /// <param name="weight">Requested font weight.</param>
    /// <param name="stretch">Requested font stretch.</param>
    /// <param name="style">Requested font style.</param>
    /// <returns><see cref="DWriteFont"/></returns>
    public DWriteFont GetFirstMatchingFont(DWriteFontWeight weight, DWriteFontStretch stretch, DWriteFontStyle style)
    {
        nint ptr;
        int hr = _comImpl->GetFirstMatchingFont(_comPtr, weight, stretch, style, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFont(ptr);
    }

    /// <summary>
    /// Gets a list of fonts in the font family ranked in order of how well they match the specified properties.
    /// </summary>
    /// <param name="weight">Requested font weight.</param>
    /// <param name="stretch">Requested font stretch.</param>
    /// <param name="style">Requested font style.</param>
    /// <returns><see cref="DWriteFontList"/></returns>
    public DWriteFontList GetMatchingFonts(DWriteFontWeight weight, DWriteFontStretch stretch, DWriteFontStyle style)
    {
        nint ptr;
        int hr = _comImpl->GetMatchingFonts(_comPtr, weight, stretch, style, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontList(ptr);
    }
}
