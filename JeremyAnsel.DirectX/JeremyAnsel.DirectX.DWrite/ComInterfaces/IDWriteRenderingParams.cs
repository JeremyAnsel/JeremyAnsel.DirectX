// <copyright file="IDWriteRenderingParams.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The interface that represents text rendering settings for glyph rasterization and filtering.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2f0da53a-2add-47cd-82ee-d9ec34688e75")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteRenderingParams
    {
        /// <summary>
        /// Gets the gamma value used for gamma correction. Valid values must be
        /// greater than zero and cannot exceed 256.
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetGamma();

        /// <summary>
        /// Gets the amount of contrast enhancement. Valid values are greater than
        /// or equal to zero.
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetEnhancedContrast();

        /// <summary>
        /// Gets the ClearType level. Valid values range from 0.0f (no ClearType) 
        /// to 1.0f (full ClearType).
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetClearTypeLevel();

        /// <summary>
        /// Gets the pixel geometry.
        /// </summary>
        /// <returns><see cref="DWritePixelGeometry"/></returns>
        [PreserveSig]
        DWritePixelGeometry GetPixelGeometry();

        /// <summary>
        /// Gets the rendering mode.
        /// </summary>
        /// <returns><see cref="DWriteRenderingMode"/></returns>
        [PreserveSig]
        DWriteRenderingMode GetRenderingMode();
    }
}
