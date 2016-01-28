// <copyright file="IDWriteTypography.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Font typography setting.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("55f1112b-1dc2-4b3c-9541-f46894ed85b6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTypography
    {
        /// <summary>
        /// Add font feature.
        /// </summary>
        /// <param name="fontFeature">The font feature to add.</param>
        void AddFontFeature(
            [In] DWriteFontFeature fontFeature);

        /// <summary>
        /// Get the number of font features.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetFontFeatureCount();

        /// <summary>
        /// Get the font feature at the specified index.
        /// </summary>
        /// <param name="fontFeatureIndex">The zero-based index of the font feature to get.</param>
        /// <param name="fontFeature">The font feature.</param>
        void GetFontFeature(
            [In] uint fontFeatureIndex,
            [Out] out DWriteFontFeature fontFeature);
    }
}
