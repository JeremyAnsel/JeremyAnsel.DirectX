// <copyright file="IDWriteTextLayout.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// The IDWriteTextLayout interface represents a block of text after it has
    /// been fully analyzed and formatted.
    /// All coordinates are in device independent pixels (DIPs).
    /// </summary>
    /// <remarks>Inherited from <see cref="IDWriteTextFormat"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("53737037-6d14-410b-9bfe-0b182bb70961")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextLayout
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
            [In] IDWriteInlineObject? trimmingSign);

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
            [Out] out IDWriteFontCollection? fontCollection);

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
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? fontFamilyName,
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
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? localeName,
            [In] uint nameSize);

        /// <summary>
        /// Set layout maximum width
        /// </summary>
        /// <param name="maxWidth">Layout maximum width</param>
        void SetMaxWidth(
            [In] float maxWidth);

        /// <summary>
        /// Set layout maximum height
        /// </summary>
        /// <param name="maxHeight">Layout maximum height</param>
        void SetMaxHeight(
            [In] float maxHeight);

        /// <summary>
        /// Set the font collection.
        /// </summary>
        /// <param name="fontCollection">The font collection to set</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetFontCollection(
            [In] IDWriteFontCollection? fontCollection,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set null-terminated font family name.
        /// </summary>
        /// <param name="fontFamilyName">Font family name</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetFontFamilyName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string? fontFamilyName,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set font weight.
        /// </summary>
        /// <param name="fontWeight">Font weight</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetFontWeight(
            [In] DWriteFontWeight fontWeight,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set font style.
        /// </summary>
        /// <param name="fontStyle">Font style</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetFontStyle(
            [In] DWriteFontStyle fontStyle,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set font stretch.
        /// </summary>
        /// <param name="fontStretch">font stretch</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetFontStretch(
            [In] DWriteFontStretch fontStretch,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set font em height.
        /// </summary>
        /// <param name="fontSize">Font em height</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetFontSize(
            [In] float fontSize,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set underline.
        /// </summary>
        /// <param name="hasUnderline">The Boolean flag indicates whether underline takes place</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetUnderline(
            [In, MarshalAs(UnmanagedType.Bool)] bool hasUnderline,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set strikethrough.
        /// </summary>
        /// <param name="hasStrikethrough">The Boolean flag indicates whether strikethrough takes place</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetStrikethrough(
            [In, MarshalAs(UnmanagedType.Bool)] bool hasStrikethrough,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set application-defined drawing effect.
        /// </summary>
        /// <param name="drawingEffect">Pointer to an application-defined drawing effect.</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        /// <remarks>
        /// This drawing effect is associated with the specified range and will be passed back
        /// to the application via the callback when the range is drawn at drawing time.
        /// </remarks>
        void SetDrawingEffect(
            [In, MarshalAs(UnmanagedType.IUnknown)] object? drawingEffect,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set inline object.
        /// </summary>
        /// <param name="inlineObject">Pointer to an application-implemented inline object.</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        /// <remarks>
        /// This inline object applies to the specified range and will be passed back
        /// to the application via the DrawInlineObject callback when the range is drawn.
        /// Any text in that range will be suppressed.
        /// </remarks>
        void SetInlineObject(
            [In] IDWriteInlineObject? inlineObject,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set font typography features.
        /// </summary>
        /// <param name="typography">Pointer to font typography setting.</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetTypography(
            [In] IDWriteTypography? typography,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Set locale name.
        /// </summary>
        /// <param name="localeName">Locale name</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void SetLocaleName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string? localeName,
            [In] DWriteTextRange textRange);

        /// <summary>
        /// Get layout maximum width
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetMaxWidth();

        /// <summary>
        /// Get layout maximum height
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [PreserveSig]
        float GetMaxHeight();

        /// <summary>
        /// Get the font collection where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="fontCollection">The current font collection</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        void GetFontCollection(
            [In] uint currentPosition,
            [Out] out IDWriteFontCollection? fontCollection,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the length of the font family name where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="nameLength">Size of the character array in character count not including the terminated NULL character.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetFontFamilyNameLength(
            [In] uint currentPosition,
            [Out] out uint nameLength,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Copy the font family name where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="fontFamilyName">Character array that receives the current font family name</param>
        /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetFontFamilyName(
            [In] uint currentPosition,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? fontFamilyName,
            [In] uint nameSize,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the font weight where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="fontWeight">The current font weight</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetFontWeight(
            [In] uint currentPosition,
            [Out] out DWriteFontWeight fontWeight,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the font style where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="fontStyle">The current font style</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetFontStyle(
            [In] uint currentPosition,
            [Out] out DWriteFontStyle fontStyle,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the font stretch where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="fontStretch">The current font stretch</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetFontStretch(
            [In] uint currentPosition,
            [Out] out DWriteFontStretch fontStretch,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the font em height where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="fontSize">The current font em height</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetFontSize(
            [In] uint currentPosition,
            [Out] out float fontSize,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the underline presence where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="hasUnderline">The Boolean flag indicates whether text is underlined.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetUnderline(
            [In] uint currentPosition,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool hasUnderline,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the strikethrough presence where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="hasStrikethrough">The Boolean flag indicates whether text has strikethrough.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetStrikethrough(
            [In] uint currentPosition,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool hasStrikethrough,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the application-defined drawing effect where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="drawingEffect">The current application-defined drawing effect.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetDrawingEffect(
            [In] uint currentPosition,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object? drawingEffect,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the inline object at the given position.
        /// </summary>
        /// <param name="currentPosition">The given text position.</param>
        /// <param name="inlineObject">The inline object.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetInlineObject(
            [In] uint currentPosition,
            [Out] out IDWriteInlineObject? inlineObject,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the typography setting where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="typography">The current typography setting.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetTypography(
            [In] uint currentPosition,
            [Out] out IDWriteTypography? typography,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the length of the locale name where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="nameLength">Size of the character array in character count not including the terminated NULL character.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetLocaleNameLength(
            [In] uint currentPosition,
            [Out] out uint nameLength,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Get the locale name where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="localeName">Character array that receives the current locale name</param>
        /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
        /// <param name="textRange">The position range of the current format.</param>
        void GetLocaleName(
            [In] uint currentPosition,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? localeName,
            [In] uint nameSize,
            [Out] out DWriteTextRange textRange);

        /// <summary>
        /// Initiate drawing of the text.
        /// </summary>
        /// <param name="clientDrawingContext">An application defined value
        /// included in rendering callbacks.</param>
        /// <param name="renderer">The set of application-defined callbacks that do
        /// the actual rendering.</param>
        /// <param name="originX">X-coordinate of the layout's left side.</param>
        /// <param name="originY">Y-coordinate of the layout's top side.</param>
        void Draw(
            [In] IntPtr clientDrawingContext,
            [In] IDWriteTextRenderer? renderer,
            [In] float originX,
            [In] float originY);

        /// <summary>
        /// GetLineMetrics returns properties of each line.
        /// </summary>
        /// <param name="lineMetrics">The array to fill with line information.</param>
        /// <param name="maxLineCount">The maximum size of the lineMetrics array.</param>
        /// <param name="actualLineCount">The actual size of the lineMetrics
        /// array that is needed.</param>
        /// <remarks>
        /// If maxLineCount is not large enough E_NOT_SUFFICIENT_BUFFER, 
        /// which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER),
        /// is returned and *actualLineCount is set to the number of lines
        /// needed.
        /// </remarks>
        void GetLineMetrics(
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteLineMetrics[]? lineMetrics,
            [In] uint maxLineCount,
            [Out] out uint actualLineCount);

        /// <summary>
        /// GetMetrics retrieves overall metrics for the formatted string.
        /// </summary>
        /// <param name="textMetrics">The returned metrics.</param>
        /// <remarks>
        /// Drawing effects like underline and strikethrough do not contribute
        /// to the text size, which is essentially the sum of advance widths and
        /// line heights. Additionally, visible swashes and other graphic
        /// adornments may extend outside the returned width and height.
        /// </remarks>
        void GetMetrics(
            [Out] out DWriteTextMetrics textMetrics);

        /// <summary>
        /// GetOverhangMetrics returns the overhangs (in DIPs) of the layout and all
        /// objects contained in it, including text glyphs and inline objects.
        /// </summary>
        /// <param name="overhangs">Overshoots of visible extents (in DIPs) outside the layout.</param>
        /// <remarks>
        /// Any underline and strikethrough do not contribute to the black box
        /// determination, since these are actually drawn by the renderer, which
        /// is allowed to draw them in any variety of styles.
        /// </remarks>
        void GetOverhangMetrics(
            [Out] out DWriteOverhangMetrics overhangs);

        /// <summary>
        /// Retrieve logical properties and measurement of each cluster.
        /// </summary>
        /// <param name="clusterMetrics">The array to fill with cluster information.</param>
        /// <param name="maxClusterCount">The maximum size of the clusterMetrics array.</param>
        /// <param name="actualClusterCount">The actual size of the clusterMetrics array that is needed.</param>
        /// <remarks>
        /// If maxClusterCount is not large enough E_NOT_SUFFICIENT_BUFFER, 
        /// which is equivalent to HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER), 
        /// is returned and *actualClusterCount is set to the number of clusters
        /// needed.
        /// </remarks>
        void GetClusterMetrics(
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteClusterMetrics[]? clusterMetrics,
            [In] uint maxClusterCount,
            [Out] out uint actualClusterCount);

        /// <summary>
        /// Determines the minimum possible width the layout can be set to without
        /// emergency breaking between the characters of whole words.
        /// </summary>
        /// <param name="minWidth">Minimum width.</param>
        void DetermineMinWidth(
            [Out] out float minWidth);

        /// <summary>
        /// Given a coordinate (in DIPs) relative to the top-left of the layout box,
        /// this returns the corresponding hit-test metrics of the text string where
        /// the hit-test has occurred. This is useful for mapping mouse clicks to caret
        /// positions. When the given coordinate is outside the text string, the function
        /// sets the output value *isInside to false but returns the nearest character
        /// position.
        /// </summary>
        /// <param name="pointX">X coordinate to hit-test, relative to the top-left location of the layout box.</param>
        /// <param name="pointY">Y coordinate to hit-test, relative to the top-left location of the layout box.</param>
        /// <param name="isTrailingHit">Output flag indicating whether the hit-test location is at the leading or the trailing
        /// side of the character. When the output *isInside value is set to false, this value is set according to the output
        /// position value to represent the edge closest to the hit-test location. </param>
        /// <param name="isInside">Output flag indicating whether the hit-test location is inside the text string.
        /// When false, the position nearest the text's edge is returned.</param>
        /// <param name="hitTestMetrics">Output geometry fully enclosing the hit-test location. When the output isInside value
        /// is set to false, this structure represents the geometry enclosing the edge closest to the hit-test location.</param>
        void HitTestPoint(
            [In] float pointX,
            [In] float pointY,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isTrailingHit,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isInside,
            [Out] out DWriteHitTestMetrics hitTestMetrics);

        /// <summary>
        /// Given a text position and whether the caret is on the leading or trailing
        /// edge of that position, this returns the corresponding coordinate (in DIPs)
        /// relative to the top-left of the layout box. This is most useful for drawing
        /// the caret's current position, but it could also be used to anchor an IME to the
        /// typed text or attach a floating menu near the point of interest. It may also be
        /// used to programmatically obtain the geometry of a particular text position
        /// for UI automation.
        /// </summary>
        /// <param name="textPosition">Text position to get the coordinate of.</param>
        /// <param name="isTrailingHit">Flag indicating whether the location is of the leading or the trailing side of the specified text position. </param>
        /// <param name="pointX">Output caret X, relative to the top-left of the layout box.</param>
        /// <param name="pointY">Output caret Y, relative to the top-left of the layout box.</param>
        /// <param name="hitTestMetrics">Output geometry fully enclosing the specified text position.</param>
        /// <remarks>
        /// When drawing a caret at the returned X,Y, it should be centered on X
        /// and drawn from the Y coordinate down. The height will be the size of the
        /// hit-tested text (which can vary in size within a line).
        /// Reading direction also affects which side of the character the caret is drawn.
        /// However, the returned X coordinate will be correct for either case.
        /// You can get a text length back that is larger than a single character.
        /// This happens for complex scripts when multiple characters form a single cluster,
        /// when diacritics join their base character, or when you test a surrogate pair.
        /// </remarks>
        void HitTestTextPosition(
            [In] uint textPosition,
            [In, MarshalAs(UnmanagedType.Bool)] bool isTrailingHit,
            [Out] out float pointX,
            [Out] out float pointY,
            [Out] out DWriteHitTestMetrics hitTestMetrics);

        /// <summary>
        /// The application calls this function to get a set of hit-test metrics
        /// corresponding to a range of text positions. The main usage for this
        /// is to draw highlighted selection of the text string.
        /// The function returns <value>E_NOT_SUFFICIENT_BUFFER</value>, which is equivalent to 
        /// <c>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</c>, when the buffer size of
        /// hitTestMetrics is too small to hold all the regions calculated by the
        /// function. In such situation, the function sets the output value
        /// <c>actualHitTestMetricsCount</c> to the number of geometries calculated.
        /// The application is responsible to allocate a new buffer of greater
        /// size and call the function again.
        /// A good value to use as an initial value for <c>maxHitTestMetricsCount</c> may
        /// be calculated from the following equation:
        /// <c>maxHitTestMetricsCount = lineCount * maxBidiReorderingDepth</c>
        /// where lineCount is obtained from the value of the output argument
        /// <c>actualLineCount</c> from the function <see cref="IDWriteTextLayout.GetLineMetrics"/>,
        /// and the <c>maxBidiReorderingDepth</c> value from the <c>DWRITE_TEXT_METRICS</c>
        /// structure of the output argument <c>textMetrics</c> from the function
        /// <see cref="IDWriteFactory.CreateTextLayout"/>.
        /// </summary>
        /// <param name="textPosition">First text position of the specified range.</param>
        /// <param name="textLength">Number of positions of the specified range.</param>
        /// <param name="originX">Offset of the X origin (left of the layout box) which is added to each of the hit-test metrics returned.</param>
        /// <param name="originY">Offset of the Y origin (top of the layout box) which is added to each of the hit-test metrics returned.</param>
        /// <param name="hitTestMetrics">Pointer to a buffer of the output geometry fully enclosing the specified position range.</param>
        /// <param name="maxHitTestMetricsCount">Maximum number of distinct metrics it could hold in its buffer memory.</param>
        /// <param name="actualHitTestMetricsCount">Actual number of metrics returned or needed.</param>
        /// <remarks>
        /// There are no gaps in the returned metrics. While there could be visual gaps,
        /// depending on bidi ordering, each range is contiguous and reports all the text,
        /// including any hidden characters and trimmed text.
        /// The height of each returned range will be the same within each line, regardless
        /// of how the font sizes vary.
        /// </remarks>
        void HitTestTextRange(
            [In] uint textPosition,
            [In] uint textLength,
            [In] float originX,
            [In] float originY,
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteHitTestMetrics[]? hitTestMetrics,
            [In] uint maxHitTestMetricsCount,
            [Out] out uint actualHitTestMetricsCount);
    }
}
