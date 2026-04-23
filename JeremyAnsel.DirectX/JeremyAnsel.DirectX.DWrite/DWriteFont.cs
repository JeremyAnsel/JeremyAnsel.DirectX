// <copyright file="DWriteFont.cs" company="Jérémy Ansel">
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
/// The IDWriteFont interface represents a physical font in a font collection.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFont : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFontGuid = typeof(IDWriteFont).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFont* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFont"/> class.
    /// </summary>
    public DWriteFont(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFont**)comPtr;
    }

    /// <summary>
    /// Gets the weight of the specified font.
    /// </summary>
    public DWriteFontWeight Weight
    {
        get { return _comImpl->GetWeight(_comPtr); }
    }

    /// <summary>
    /// Gets the stretch (aka. width) of the specified font.
    /// </summary>
    public DWriteFontStretch Stretch
    {
        get { return _comImpl->GetStretch(_comPtr); }
    }

    /// <summary>
    /// Gets the style (aka. slope) of the specified font.
    /// </summary>
    public DWriteFontStyle Style
    {
        get { return _comImpl->GetStyle(_comPtr); }
    }

    /// <summary>
    /// Gets a value indicating whether the font is a symbol font.
    /// </summary>
    public bool IsSymbolFont
    {
        get { return _comImpl->IsSymbolFont(_comPtr) != 0; }
    }

    /// <summary>
    /// Gets a value that indicates what simulation are applied to the specified font.
    /// </summary>
    public DWriteFontSimulations Simulations
    {
        get { return _comImpl->GetSimulations(_comPtr); }
    }

    /// <summary>
    /// Gets the font family to which the specified font belongs.
    /// </summary>
    /// <returns><see cref="DWriteFontFamily"/></returns>
    public DWriteFontFamily GetFontFamily()
    {
        nint ptr;
        int hr = _comImpl->GetFontFamily(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontFamily(ptr);
    }

    /// <summary>
    /// Gets a localized strings collection containing the face names for the font (e.g., Regular or Bold), indexed by locale name.
    /// </summary>
    /// <returns><see cref="DWriteLocalizedStrings"/></returns>
    public DWriteLocalizedStrings GetFaceNames()
    {
        nint ptr;
        int hr = _comImpl->GetFaceNames(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteLocalizedStrings(ptr);
    }

    /// <summary>
    /// Gets a localized strings collection containing the specified informational strings, indexed by locale name.
    /// </summary>
    /// <param name="informationalStringId">Identifies the string to get.</param>
    /// <remarks>
    /// If the font does not contain the specified string, the return value is S_OK but 
    /// informationalStrings receives a NULL pointer and exists receives the value FALSE.
    /// </remarks>
    /// <returns><see cref="DWriteLocalizedStrings"/></returns>
    public DWriteLocalizedStrings? GetInformationalStrings(DWriteInformationalStringId informationalStringId)
    {
        int exists;
        nint ptr;
        int hr = _comImpl->GetInformationalStrings(_comPtr, informationalStringId, &ptr, &exists);
        Marshal.ThrowExceptionForHR(hr);

        if (exists == 0)
        {
            return null;
        }

        return new DWriteLocalizedStrings(ptr);
    }

    /// <summary>
    /// Gets the metrics for the font.
    /// </summary>
    /// <returns><see cref="DWriteFontMetrics"/></returns>
    public DWriteFontMetrics GetMetrics()
    {
        int size = DWriteFontMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        _comImpl->GetMetrics(_comPtr, ptr);
        return DWriteFontMetrics.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Determines whether the font supports the specified character.
    /// </summary>
    /// <param name="unicodeValue">Unicode (UCS-4) character value.</param>
    /// <returns><see cref="bool"/></returns>
    public bool HasCharacter(uint unicodeValue)
    {
        int exists;
        int hr = _comImpl->HasCharacter(_comPtr, unicodeValue, &exists);
        Marshal.ThrowExceptionForHR(hr);
        return exists != 0;
    }

    /// <summary>
    /// Creates a font face object for the font.
    /// </summary>
    /// <returns><see cref="DWriteFontFace"/></returns>
    public DWriteFontFace CreateFontFace()
    {
        nint ptr;
        int hr = _comImpl->CreateFontFace(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontFace(ptr);
    }
}
