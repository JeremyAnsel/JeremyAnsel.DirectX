// <copyright file="IDWriteFontFamily.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteFontFamily interface represents a set of fonts that share the same design but are differentiated
    /// by weight, stretch, and style.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDWriteFontList"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("da20d8ef-812a-4c43-9802-62ec4abd7add")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteFontFamily
    {
        /// <summary>
        /// Gets the font collection that contains the fonts.
        /// </summary>
        /// <param name="fontCollection">Receives a pointer to the font collection object.</param>
        void GetFontCollection(
            [Out] out IDWriteFontCollection? fontCollection);

        /// <summary>
        /// Gets the number of fonts in the font list.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetFontCount();

        /// <summary>
        /// Gets a font given its zero-based index.
        /// </summary>
        /// <param name="index">Zero-based index of the font in the font list.</param>
        /// <param name="font">Receives a pointer to the newly created font object.</param>
        void GetFont(
            [In] uint index,
            [Out] out IDWriteFont? font);

        /// <summary>
        /// Creates a localized strings object that contains the family names for the font family, indexed by locale name.
        /// </summary>
        /// <param name="names">Receives a pointer to the newly created localized strings object.</param>
        void GetFamilyNames(
            [Out] out IDWriteLocalizedStrings? names);

        /// <summary>
        /// Gets the font that best matches the specified properties.
        /// </summary>
        /// <param name="weight">Requested font weight.</param>
        /// <param name="stretch">Requested font stretch.</param>
        /// <param name="style">Requested font style.</param>
        /// <param name="matchingFont">Receives a pointer to the newly created font object.</param>
        void GetFirstMatchingFont(
            [In] DWriteFontWeight weight,
            [In] DWriteFontStretch stretch,
            [In] DWriteFontStyle style,
            [Out] out IDWriteFont? matchingFont);

        /// <summary>
        /// Gets a list of fonts in the font family ranked in order of how well they match the specified properties.
        /// </summary>
        /// <param name="weight">Requested font weight.</param>
        /// <param name="stretch">Requested font stretch.</param>
        /// <param name="style">Requested font style.</param>
        /// <param name="matchingFonts">Receives a pointer to the newly created font list object.</param>
        void GetMatchingFonts(
            [In] DWriteFontWeight weight,
            [In] DWriteFontStretch stretch,
            [In] DWriteFontStyle style,
            [Out] out IDWriteFontList? matchingFonts);
    }
}
