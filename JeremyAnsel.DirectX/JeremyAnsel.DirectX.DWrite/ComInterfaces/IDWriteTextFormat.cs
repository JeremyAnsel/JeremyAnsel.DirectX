// <copyright file="IDWriteTextFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// The format of text used for text layout.
    /// </summary>
    /// <remarks>
    /// This object may not be thread-safe and it may carry the state of text format change.
    /// </remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("9c906818-31d7-4fd3-a151-7c5e225db55a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextFormat
    {
        /// <summary>
        /// Set alignment option of text relative to layout box's leading and trailing edge.
        /// </summary>
        /// <param name="textAlignment">Text alignment option</param>
        void SetTextAlignment(
            [In] DWriteTextAlignment textAlignment);

        /// <summary>
        /// Set alignment option of paragraph relative to layout box's top and bottom edge.
        /// </summary>
        /// <param name="paragraphAlignment">Paragraph alignment option</param>
        void SetParagraphAlignment(
            [In] DWriteParagraphAlignment paragraphAlignment);

        /// <summary>
        /// Set word wrapping option.
        /// </summary>
        /// <param name="wordWrapping">Word wrapping option</param>
        void SetWordWrapping(
            [In] DWriteWordWrapping wordWrapping);

        /// <summary>
        /// Set paragraph reading direction.
        /// </summary>
        /// <param name="readingDirection">Text reading direction</param>
        /// <remarks>
        /// The flow direction must be perpendicular to the reading direction.
        /// Setting both to a vertical direction or both to horizontal yields
        /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
        /// </remarks>
        void SetReadingDirection(
            [In] DWriteReadingDirection readingDirection);

        /// <summary>
        /// Set paragraph flow direction.
        /// </summary>
        /// <param name="flowDirection">Paragraph flow direction</param>
        /// <remarks>
        /// The flow direction must be perpendicular to the reading direction.
        /// Setting both to a vertical direction or both to horizontal yields
        /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
        /// </remarks>
        void SetFlowDirection(
            [In] DWriteFlowDirection flowDirection);

        /// <summary>
        /// Set incremental tab stop position.
        /// </summary>
        /// <param name="incrementalTabStop">The incremental tab stop value</param>
        void SetIncrementalTabStop(
            [In] float incrementalTabStop);

        /// <summary>
        /// Set trimming options for any trailing text exceeding the layout width
        /// or for any far text exceeding the layout height.
        /// </summary>
        /// <param name="trimmingOptions">Text trimming options.</param>
        /// <param name="trimmingSign">Application-defined omission sign. This parameter may be NULL if no trimming sign is desired.</param>
        /// <remarks>
        /// Any inline object can be used for the trimming sign, but CreateEllipsisTrimmingSign
        /// provides a typical ellipsis symbol. Trimming is also useful vertically for hiding
        /// partial lines.
        /// </remarks>
        void SetTrimming(
            [In] ref DWriteTrimming trimmingOptions,
            [In] IDWriteInlineObject trimmingSign);

        /// <summary>
        /// Set line spacing.
        /// </summary>
        /// <param name="lineSpacingMethod">How to determine line height.</param>
        /// <param name="lineSpacing">The line height, or rather distance between one baseline to another.</param>
        /// <param name="baseline">Distance from top of line to baseline. A reasonable ratio to lineSpacing is 80%.</param>
        /// <remarks>
        /// For the default method, spacing depends solely on the content.
        /// For uniform spacing, the given line height will override the content.
        /// </remarks>
        void SetLineSpacing(
            [In] DWriteLineSpacingMethod lineSpacingMethod,
            [In] float lineSpacing,
            [In] float baseline);

        /// <summary>
        /// Get alignment option of text relative to layout box's leading and trailing edge.
        /// </summary>
        /// <returns><see cref="DWriteTextAlignment"/></returns>
        [PreserveSig]
        DWriteTextAlignment GetTextAlignment();

        /// <summary>
        /// Get alignment option of paragraph relative to layout box's top and bottom edge.
        /// </summary>
        /// <returns><see cref="DWriteParagraphAlignment"/></returns>
        [PreserveSig]
        DWriteParagraphAlignment GetParagraphAlignement();

        /// <summary>
        /// Get word wrapping option.
        /// </summary>
        /// <returns><see cref="DWriteWordWrapping"/></returns>
        [PreserveSig]
        DWriteWordWrapping GetWordWrapping();

        /// <summary>
        /// Get paragraph reading direction.
        /// </summary>
        /// <returns><see cref="DWriteReadingDirection"/></returns>
        [PreserveSig]
        DWriteReadingDirection GetReadingDirection();

        /// <summary>
        /// Get paragraph flow direction.
        /// </summary>
        /// <returns><see cref="DWriteFlowDirection"/></returns>
        [PreserveSig]
        DWriteFlowDirection GetFlowDirection();

        /// <summary>
        /// Get incremental tab stop position.
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetIncrementalTabStop();

        /// <summary>
        /// Get trimming options for text overflowing the layout width.
        /// </summary>
        /// <param name="trimmingOptions">Text trimming options.</param>
        /// <param name="trimmingSign">Trimming omission sign. This parameter may be NULL.</param>
        void GetTrimming(
            [Out] out DWriteTrimming trimmingOptions,
            [Out] IntPtr trimmingSign);

        /// <summary>
        /// Get line spacing.
        /// </summary>
        /// <param name="lineSpacingMethod">How line height is determined.</param>
        /// <param name="lineSpacing">The line height, or rather distance between one baseline to another.</param>
        /// <param name="baseline">Distance from top of line to baseline.</param>
        void GetLineSpacing(
            [Out] out DWriteLineSpacingMethod lineSpacingMethod,
            [Out] out float lineSpacing,
            [Out] out float baseline);

        /// <summary>
        /// Get the font collection.
        /// </summary>
        /// <param name="fontCollection">The current font collection.</param>
        void GetFontCollection(
            [Out] out IDWriteFontCollection fontCollection);

        /// <summary>
        /// Get the length of the font family name, in characters, not including the terminating NULL character.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetFontFamilyNameLength();

        /// <summary>
        /// Get a copy of the font family name.
        /// </summary>
        /// <param name="fontFamilyName">Character array that receives the current font family name</param>
        /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
        void GetFontFamilyName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder fontFamilyName,
            [In] uint nameSize);

        /// <summary>
        /// Get the font weight.
        /// </summary>
        /// <returns><see cref="DWriteFontWeight"/></returns>
        [PreserveSig]
        DWriteFontWeight GetFontWeight();

        /// <summary>
        /// Get the font style.
        /// </summary>
        /// <returns><see cref="DWriteFontStyle"/></returns>
        [PreserveSig]
        DWriteFontStyle GetFontStyle();

        /// <summary>
        /// Get the font stretch.
        /// </summary>
        /// <returns><see cref="DWriteFontStretch"/></returns>
        [PreserveSig]
        DWriteFontStretch GetFontStretch();

        /// <summary>
        /// Get the font em height.
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetFontSize();

        /// <summary>
        /// Get the length of the locale name, in characters, not including the terminating NULL character.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetLocaleNameLength();

        /// <summary>
        /// Get a copy of the locale name.
        /// </summary>
        /// <param name="localeName">Character array that receives the current locale name</param>
        /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
        void GetLocaleName(
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder localeName,
            [In] uint nameSize);
    }
}
