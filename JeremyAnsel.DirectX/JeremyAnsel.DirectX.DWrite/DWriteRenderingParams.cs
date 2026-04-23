// <copyright file="DWriteRenderingParams.cs" company="Jérémy Ansel">
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
/// The interface that represents text rendering settings for glyph rasterization and filtering.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteRenderingParams : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteRenderingParamsGuid = typeof(IDWriteRenderingParams).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteRenderingParams* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteRenderingParams"/> class.
    /// </summary>
    public DWriteRenderingParams(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteRenderingParams**)comPtr;
    }

    /// <summary>
    /// Gets the gamma value used for gamma correction. Valid values must be
    /// greater than zero and cannot exceed 256.
    /// </summary>
    public float Gamma
    {
        get { return _comImpl->GetGamma(_comPtr); }
    }

    /// <summary>
    /// Gets the amount of contrast enhancement. Valid values are greater than
    /// or equal to zero.
    /// </summary>
    public float EnhancedContrast
    {
        get { return _comImpl->GetEnhancedContrast(_comPtr); }
    }

    /// <summary>
    /// Gets the ClearType level. Valid values range from 0.0f (no ClearType) 
    /// to 1.0f (full ClearType).
    /// </summary>
    public float ClearTypeLevel
    {
        get { return _comImpl->GetClearTypeLevel(_comPtr); }
    }

    /// <summary>
    /// Gets the pixel geometry.
    /// </summary>
    public DWritePixelGeometry PixelGeometry
    {
        get { return _comImpl->GetPixelGeometry(_comPtr); }
    }

    /// <summary>
    /// Gets the rendering mode.
    /// </summary>
    public DWriteRenderingMode RenderingMode
    {
        get { return _comImpl->GetRenderingMode(_comPtr); }
    }
}
