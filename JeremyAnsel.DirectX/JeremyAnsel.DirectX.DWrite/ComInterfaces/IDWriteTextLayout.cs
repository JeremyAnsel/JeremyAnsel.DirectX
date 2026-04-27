// <copyright file="IDWriteTextLayout.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The IDWriteTextLayout interface represents a block of text after it has
/// been fully analyzed and formatted.
/// All coordinates are in device independent pixels (DIPs).
/// </summary>
/// <remarks>Inherited from <see cref="IDWriteTextFormat"/></remarks>
[Guid("53737037-6d14-410b-9bfe-0b182bb70961")]
internal unsafe readonly struct IDWriteTextLayout
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetTextAlignment;
    private readonly nint SetParagraphAlignment;
    private readonly nint SetWordWrapping;
    private readonly nint SetReadingDirection;
    private readonly nint SetFlowDirection;
    private readonly nint SetIncrementalTabStop;
    private readonly nint SetTrimming;
    private readonly nint SetLineSpacing;
    private readonly nint GetTextAlignment;
    private readonly nint GetParagraphAlignement;
    private readonly nint GetWordWrapping;
    private readonly nint GetReadingDirection;
    private readonly nint GetFlowDirection;
    private readonly nint GetIncrementalTabStop;
    private readonly nint GetTrimming;
    private readonly nint GetLineSpacing;
    private readonly nint GetFontCollection0;
    private readonly nint GetFontFamilyNameLength0;
    private readonly nint GetFontFamilyName0;
    private readonly nint GetFontWeight0;
    private readonly nint GetFontStyle0;
    private readonly nint GetFontStretch0;
    private readonly nint GetFontSize0;
    private readonly nint GetLocaleNameLength0;
    private readonly nint GetLocaleName0;

    /// <summary>
    /// Set layout maximum width
    /// </summary>
    /// <param name="maxWidth">Layout maximum width</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, int> SetMaxWidth;

    /// <summary>
    /// Set layout maximum height
    /// </summary>
    /// <param name="maxHeight">Layout maximum height</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, int> SetMaxHeight;

    /// <summary>
    /// Set the font collection.
    /// </summary>
    /// <param name="fontCollection">The font collection to set</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, DWriteTextRange, int> SetFontCollection;

    /// <summary>
    /// Set null-terminated font family name.
    /// </summary>
    /// <param name="fontFamilyName">Font family name</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, char*, DWriteTextRange, int> SetFontFamilyName;

    /// <summary>
    /// Set font weight.
    /// </summary>
    /// <param name="fontWeight">Font weight</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontWeight, DWriteTextRange, int> SetFontWeight;

    /// <summary>
    /// Set font style.
    /// </summary>
    /// <param name="fontStyle">Font style</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontStyle, DWriteTextRange, int> SetFontStyle;

    /// <summary>
    /// Set font stretch.
    /// </summary>
    /// <param name="fontStretch">font stretch</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DWriteFontStretch, DWriteTextRange, int> SetFontStretch;

    /// <summary>
    /// Set font em height.
    /// </summary>
    /// <param name="fontSize">Font em height</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, DWriteTextRange, int> SetFontSize;

    /// <summary>
    /// Set underline.
    /// </summary>
    /// <param name="hasUnderline">The Boolean flag indicates whether underline takes place</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, int, DWriteTextRange, int> SetUnderline;

    /// <summary>
    /// Set strikethrough.
    /// </summary>
    /// <param name="hasStrikethrough">The Boolean flag indicates whether strikethrough takes place</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, int, DWriteTextRange, int> SetStrikethrough;

    /// <summary>
    /// Set application-defined drawing effect.
    /// </summary>
    /// <param name="drawingEffect">Pointer to an application-defined drawing effect.</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    /// <remarks>
    /// This drawing effect is associated with the specified range and will be passed back
    /// to the application via the callback when the range is drawn at drawing time.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint, int> SetDrawingEffect;

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
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint, int> SetInlineObject;

    /// <summary>
    /// Set font typography features.
    /// </summary>
    /// <param name="typography">Pointer to font typography setting.</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, DWriteTextRange, int> SetTypography;

    /// <summary>
    /// Set locale name.
    /// </summary>
    /// <param name="localeName">Locale name</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, char*, DWriteTextRange, int> SetLocaleName;

    /// <summary>
    /// Get layout maximum width
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetMaxWidth;

    /// <summary>
    /// Get layout maximum height
    /// </summary>
    /// <returns><see cref="float"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetMaxHeight;

    /// <summary>
    /// Get the font collection where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="fontCollection">The current font collection</param>
    /// <param name="textRange">Text range to which this change applies.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, void*, int> GetFontCollection;

    /// <summary>
    /// Get the length of the font family name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="nameLength">Size of the character array in character count not including the terminated NULL character.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, void*, int> GetFontFamilyNameLength;

    /// <summary>
    /// Copy the font family name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="fontFamilyName">Character array that receives the current font family name</param>
    /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint, void*, int> GetFontFamilyName;

    /// <summary>
    /// Get the font weight where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="fontWeight">The current font weight</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, DWriteFontWeight*, void*, int> GetFontWeight;

    /// <summary>
    /// Get the font style where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="fontStyle">The current font style</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, DWriteFontStyle*, void*, int> GetFontStyle;

    /// <summary>
    /// Get the font stretch where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="fontStretch">The current font stretch</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, DWriteFontStretch*, void*, int> GetFontStretch;

    /// <summary>
    /// Get the font em height where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="fontSize">The current font em height</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, float*, void*, int> GetFontSize;

    /// <summary>
    /// Get the underline presence where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="hasUnderline">The Boolean flag indicates whether text is underlined.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int*, void*, int> GetUnderline;

    /// <summary>
    /// Get the strikethrough presence where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="hasStrikethrough">The Boolean flag indicates whether text has strikethrough.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int*, void*, int> GetStrikethrough;

    /// <summary>
    /// Get the application-defined drawing effect where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="drawingEffect">The current application-defined drawing effect.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, void*, int> GetDrawingEffect;

    /// <summary>
    /// Get the inline object at the given position.
    /// </summary>
    /// <param name="currentPosition">The given text position.</param>
    /// <param name="inlineObject">The inline object.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, void*, int> GetInlineObject;

    /// <summary>
    /// Get the typography setting where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="typography">The current typography setting.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, void*, int> GetTypography;

    /// <summary>
    /// Get the length of the locale name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="nameLength">Size of the character array in character count not including the terminated NULL character.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, void*, int> GetLocaleNameLength;

    /// <summary>
    /// Get the locale name where the current position is at.
    /// </summary>
    /// <param name="currentPosition">The current text position.</param>
    /// <param name="localeName">Character array that receives the current locale name</param>
    /// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
    /// <param name="textRange">The position range of the current format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint, void*, int> GetLocaleName;

    /// <summary>
    /// Initiate drawing of the text.
    /// </summary>
    /// <param name="clientDrawingContext">An application defined value
    /// included in rendering callbacks.</param>
    /// <param name="renderer">The set of application-defined callbacks that do
    /// the actual rendering.</param>
    /// <param name="originX">X-coordinate of the layout's left side.</param>
    /// <param name="originY">Y-coordinate of the layout's top side.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, float, float, int> Draw;

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
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, uint*, int> GetLineMetrics;

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
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetMetrics;

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
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetOverhangMetrics;

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
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, uint*, int> GetClusterMetrics;

    /// <summary>
    /// Determines the minimum possible width the layout can be set to without
    /// emergency breaking between the characters of whole words.
    /// </summary>
    /// <param name="minWidth">Minimum width.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float*, int> DetermineMinWidth;

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
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, int*, int*, void*, int> HitTestPoint;

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
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int, float*, float*, void*, int> HitTestTextPosition;

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
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, float, float, void*, uint, uint*, int> HitTestTextRange;
}
