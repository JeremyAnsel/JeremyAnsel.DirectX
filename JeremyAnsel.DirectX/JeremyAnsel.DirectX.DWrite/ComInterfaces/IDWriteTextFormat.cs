// <copyright file="IDWriteTextFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The format of text used for text layout.
/// </summary>
/// <remarks>
/// This object may not be thread-safe and it may carry the state of text format change.
/// </remarks>
[Guid("9c906818-31d7-4fd3-a151-7c5e225db55a")]
internal unsafe readonly struct IDWriteTextFormat
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Set alignment option of text relative to layout box's leading and trailing edge.
    /// </summary>
    /// <param name="textAlignment">Text alignment option</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteTextAlignment, int> SetTextAlignment;

    /// <summary>
    /// Set alignment option of paragraph relative to layout box's top and bottom edge.
    /// </summary>
    /// <param name="paragraphAlignment">Paragraph alignment option</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteParagraphAlignment, int> SetParagraphAlignment;

    /// <summary>
    /// Set word wrapping option.
    /// </summary>
    /// <param name="wordWrapping">Word wrapping option</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteWordWrapping, int> SetWordWrapping;

    /// <summary>
    /// Set paragraph reading direction.
    /// </summary>
    /// <param name="readingDirection">Text reading direction</param>
    /// <remarks>
    /// The flow direction must be perpendicular to the reading direction.
    /// Setting both to a vertical direction or both to horizontal yields
    /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteReadingDirection, int> SetReadingDirection;

    /// <summary>
    /// Set paragraph flow direction.
    /// </summary>
    /// <param name="flowDirection">Paragraph flow direction</param>
    /// <remarks>
    /// The flow direction must be perpendicular to the reading direction.
    /// Setting both to a vertical direction or both to horizontal yields
    /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFlowDirection, int> SetFlowDirection;

    /// <summary>
    /// Set incremental tab stop position.
    /// </summary>
    /// <param name="incrementalTabStop">The incremental tab stop value</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, int> SetIncrementalTabStop;

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
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, int> SetTrimming;

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
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteLineSpacingMethod, float, float, int> SetLineSpacing;

    /// <summary>
    /// Get alignment option of text relative to layout box's leading and trailing edge.
    /// </summary>
    /// <returns><see cref="DWriteTextAlignment"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteTextAlignment> GetTextAlignment;

    /// <summary>
    /// Get alignment option of paragraph relative to layout box's top and bottom edge.
    /// </summary>
    /// <returns><see cref="DWriteParagraphAlignment"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteParagraphAlignment> GetParagraphAlignement;

    /// <summary>
    /// Get word wrapping option.
    /// </summary>
    /// <returns><see cref="DWriteWordWrapping"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteWordWrapping> GetWordWrapping;

    /// <summary>
    /// Get paragraph reading direction.
    /// </summary>
    /// <returns><see cref="DWriteReadingDirection"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteReadingDirection> GetReadingDirection;

    /// <summary>
    /// Get paragraph flow direction.
    /// </summary>
    /// <returns><see cref="DWriteFlowDirection"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFlowDirection> GetFlowDirection;

    /// <summary>
    /// Get incremental tab stop position.
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetIncrementalTabStop;

    /// <summary>
    /// Get trimming options for text overflowing the layout width.
    /// </summary>
    /// <param name="trimmingOptions">Text trimming options.</param>
    /// <param name="trimmingSign">Trimming omission sign. This parameter may be NULL.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, int> GetTrimming;

    /// <summary>
    /// Get line spacing.
    /// </summary>
    /// <param name="lineSpacingMethod">How line height is determined.</param>
    /// <param name="lineSpacing">The line height, or rather distance between one baseline to another.</param>
    /// <param name="baseline">Distance from top of line to baseline.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteLineSpacingMethod*, float*, float*, int> GetLineSpacing;

    /// <summary>
    /// Get the font collection.
    /// </summary>
    /// <param name="fontCollection">The current font collection.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetFontCollection;

    /// <summary>
    /// Get the length of the font family name, in characters, not including the terminating NULL character.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetFontFamilyNameLength;

    /// <summary>
    /// Get a copy of the font family name.
    /// </summary>
    /// <param name="fontFamilyName">Character array that receives the current font family name</param>
    /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, char*, uint, int> GetFontFamilyName;

    /// <summary>
    /// Get the font weight.
    /// </summary>
    /// <returns><see cref="DWriteFontWeight"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontWeight> GetFontWeight;

    /// <summary>
    /// Get the font style.
    /// </summary>
    /// <returns><see cref="DWriteFontStyle"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontStyle> GetFontStyle;

    /// <summary>
    /// Get the font stretch.
    /// </summary>
    /// <returns><see cref="DWriteFontStretch"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontStretch> GetFontStretch;

    /// <summary>
    /// Get the font em height.
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetFontSize;

    /// <summary>
    /// Get the length of the locale name, in characters, not including the terminating NULL character.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetLocaleNameLength;

    /// <summary>
    /// Get a copy of the locale name.
    /// </summary>
    /// <param name="localeName">Character array that receives the current locale name</param>
    /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, char*, uint, int> GetLocaleName;
}
