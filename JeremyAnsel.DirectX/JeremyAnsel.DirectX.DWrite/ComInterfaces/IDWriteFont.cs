// <copyright file="IDWriteFont.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteFont interface represents a physical font in a font collection.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("acd16696-8c14-4f5d-877e-fe3fc1d32737")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteFont
    {
        /// <summary>
        /// Gets the font family to which the specified font belongs.
        /// </summary>
        /// <param name="fontFamily">Receives a pointer to the font family object.</param>
        void GetFontFamily(
            [Out] out IDWriteFontFamily? fontFamily);

        /// <summary>
        /// Gets the weight of the specified font.
        /// </summary>
        /// <returns><see cref="DWriteFontWeight"/></returns>
        [PreserveSig]
        DWriteFontWeight GetWeight();

        /// <summary>
        /// Gets the stretch (aka. width) of the specified font.
        /// </summary>
        /// <returns><see cref="DWriteFontStretch"/></returns>
        [PreserveSig]
        DWriteFontStretch GetStretch();

        /// <summary>
        /// Gets the style (aka. slope) of the specified font.
        /// </summary>
        /// <returns><see cref="DWriteFontStyle"/></returns>
        [PreserveSig]
        DWriteFontStyle GetStyle();

        /// <summary>
        /// Returns TRUE if the font is a symbol font or FALSE if not.
        /// </summary>
        /// <returns><see cref="bool"/></returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsSymbolFont();

        /// <summary>
        /// Gets a localized strings collection containing the face names for the font (e.g., Regular or Bold), indexed by locale name.
        /// </summary>
        /// <param name="names">Receives a pointer to the newly created localized strings object.</param>
        void GetFaceNames(
            [Out] out IDWriteLocalizedStrings? names);

        /// <summary>
        /// Gets a localized strings collection containing the specified informational strings, indexed by locale name.
        /// </summary>
        /// <param name="informationalStringID">Identifies the string to get.</param>
        /// <param name="informationalStrings">Receives a pointer to the newly created localized strings object.</param>
        /// <param name="exists">Receives the value TRUE if the font contains the specified string ID or FALSE if not.</param>
        /// <remarks>
        /// If the font does not contain the specified string, the return value is S_OK but 
        /// informationalStrings receives a NULL pointer and exists receives the value FALSE.
        /// </remarks>
        void GetInformationalStrings(
            [In] DWriteInformationalStringId informationalStringID,
            [Out] out IDWriteLocalizedStrings? informationalStrings,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool exists);

        /// <summary>
        /// Gets a value that indicates what simulation are applied to the specified font.
        /// </summary>
        /// <returns><see cref="DWriteFontSimulations"/></returns>
        [PreserveSig]
        DWriteFontSimulations GetSimulations();

        /// <summary>
        /// Gets the metrics for the font.
        /// </summary>
        /// <param name="fontMetrics">Receives the font metrics.</param>
        [PreserveSig]
        void GetMetrics(
            [Out] out DWriteFontMetrics fontMetrics);

        /// <summary>
        /// Determines whether the font supports the specified character.
        /// </summary>
        /// <param name="unicodeValue">Unicode (UCS-4) character value.</param>
        /// <param name="exists">Receives the value TRUE if the font supports the specified character or FALSE if not.</param>
        void HasCharacter(
            [In] uint unicodeValue,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool exists);

        /// <summary>
        /// Creates a font face object for the font.
        /// </summary>
        /// <param name="fontFace">Receives a pointer to the newly created font face object.</param>
        void CreateFontFace(
            [Out] out IDWriteFontFace? fontFace);
    }
}
