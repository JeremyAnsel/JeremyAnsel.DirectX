// <copyright file="DWriteFontList.cs" company="Jérémy Ansel">
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
/// The IDWriteFontList interface represents a list of fonts.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFontList : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFontListGuid = typeof(IDWriteFontList).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFontList* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFontList"/> class.
    /// </summary>
    public DWriteFontList(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFontList**)comPtr;
    }

    /// <summary>
    /// Gets the font collection that contains the fonts.
    /// </summary>
    /// <returns><see cref="DWriteFontCollection"/></returns>
    public DWriteFontCollection GetFontCollection()
    {
        nint ptr;
        int hr = _comImpl->GetFontCollection(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFontCollection(ptr);
    }

    /// <summary>
    /// Gets the number of fonts in the font list.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetFontCount()
    {
        return _comImpl->GetFontCount(_comPtr);
    }

    /// <summary>
    /// Gets a font given its zero-based index.
    /// </summary>
    /// <param name="index">Zero-based index of the font in the font list.</param>
    /// <returns><see cref="DWriteFont"/></returns>
    public DWriteFont GetFont(uint index)
    {
        nint ptr;
        int hr = _comImpl->GetFont(_comPtr, index, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DWriteFont(ptr);
    }
}
