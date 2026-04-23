// <copyright file="DWriteTypography.cs" company="Jérémy Ansel">
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
/// Font typography setting.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteTypography : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteTypographyGuid = typeof(IDWriteTypography).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteTypography* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteTypography"/> class.
    /// </summary>
    public DWriteTypography(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteTypography**)comPtr;
    }

    /// <summary>
    /// Add font feature.
    /// </summary>
    /// <param name="fontFeature">The font feature to add.</param>
    public void AddFontFeature(DWriteFontFeature fontFeature)
    {
        int hr = _comImpl->AddFontFeature(_comPtr, fontFeature.NameTag, fontFeature.Parameter);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get the number of font features.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetFontFeatureCount()
    {
        return _comImpl->GetFontFeatureCount(_comPtr);
    }

    /// <summary>
    /// Get the font feature at the specified index.
    /// </summary>
    /// <param name="fontFeatureIndex">The zero-based index of the font feature to get.</param>
    /// <returns><see cref="DWriteFontFeature"/></returns>
    public DWriteFontFeature GetFontFeature(uint fontFeatureIndex)
    {
        int size = DWriteFontFeature.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetFontFeature(_comPtr, fontFeatureIndex, ptr);
        return DWriteFontFeature.NativeReadFrom((nint)ptr);
    }
}
