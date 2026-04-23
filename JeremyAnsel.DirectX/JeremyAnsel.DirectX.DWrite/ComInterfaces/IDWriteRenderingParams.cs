// <copyright file="IDWriteRenderingParams.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The interface that represents text rendering settings for glyph rasterization and filtering.
/// </summary>
[Guid("2f0da53a-2add-47cd-82ee-d9ec34688e75")]
internal unsafe readonly struct IDWriteRenderingParams
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Gets the gamma value used for gamma correction. Valid values must be
    /// greater than zero and cannot exceed 256.
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetGamma;

    /// <summary>
    /// Gets the amount of contrast enhancement. Valid values are greater than
    /// or equal to zero.
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetEnhancedContrast;

    /// <summary>
    /// Gets the ClearType level. Valid values range from 0.0f (no ClearType) 
    /// to 1.0f (full ClearType).
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetClearTypeLevel;

    /// <summary>
    /// Gets the pixel geometry.
    /// </summary>
    /// <returns><see cref="DWritePixelGeometry"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWritePixelGeometry> GetPixelGeometry;

    /// <summary>
    /// Gets the rendering mode.
    /// </summary>
    /// <returns><see cref="DWriteRenderingMode"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteRenderingMode> GetRenderingMode;
}
