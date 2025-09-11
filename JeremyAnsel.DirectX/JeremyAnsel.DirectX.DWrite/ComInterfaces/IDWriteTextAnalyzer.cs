// <copyright file="IDWriteTextAnalyzer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Analyzes various text properties for complex script processing.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("b7e6163e-7f46-43b4-84b3-e4e6249c365d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextAnalyzer
    {
        /// <summary>
        /// Analyzes a text range for script boundaries, reading text attributes
        /// from the source and reporting the Unicode script ID to the sink 
        /// callback SetScript.
        /// </summary>
        /// <param name="analysisSource">Source object to analyze.</param>
        /// <param name="textPosition">Starting position within the source object.</param>
        /// <param name="textLength">Length to analyze.</param>
        /// <param name="analysisSink">Callback object.</param>
        void AnalyzeScript(
            [In] IDWriteTextAnalysisSource? analysisSource,
            [In] uint textPosition,
            [In] uint textLength,
            [In] IDWriteTextAnalysisSink? analysisSink);

        /// <summary>
        /// Analyzes a text range for script directionality, reading attributes
        /// from the source and reporting levels to the sink callback <c>SetBidiLevel</c>.
        /// </summary>
        /// <param name="analysisSource">Source object to analyze.</param>
        /// <param name="textPosition">Starting position within the source object.</param>
        /// <param name="textLength">Length to analyze.</param>
        /// <param name="analysisSink">Callback object.</param>
        /// <remarks>
        /// While the function can handle multiple paragraphs, the text range
        /// should not arbitrarily split the middle of paragraphs. Otherwise the
        /// returned levels may be wrong, since the Bidi algorithm is meant to
        /// apply to the paragraph as a whole.
        /// </remarks>
        /// <remarks>
        /// Embedded control codes (LRE/LRO/RLE/RLO/PDF) are taken into account.
        /// </remarks>
        void AnalyzeBidi(
            [In] IDWriteTextAnalysisSource? analysisSource,
            [In] uint textPosition,
            [In] uint textLength,
            [In] IDWriteTextAnalysisSink? analysisSink);

        /// <summary>
        /// Analyzes a text range for spans where number substitution is applicable,
        /// reading attributes from the source and reporting substitutable ranges
        /// to the sink callback SetNumberSubstitution.
        /// </summary>
        /// <param name="analysisSource">Source object to analyze.</param>
        /// <param name="textPosition">Starting position within the source object.</param>
        /// <param name="textLength">Length to analyze.</param>
        /// <param name="analysisSink">Callback object.</param>
        /// <remarks>
        /// While the function can handle multiple ranges of differing number
        /// substitutions, the text ranges should not arbitrarily split the
        /// middle of numbers. Otherwise it will treat the numbers separately
        /// and will not translate any intervening punctuation.
        /// </remarks>
        /// <remarks>
        /// Embedded control codes (LRE/LRO/RLE/RLO/PDF) are taken into account.
        /// </remarks>
        void AnalyzeNumberSubstitution(
            [In] IDWriteTextAnalysisSource? analysisSource,
            [In] uint textPosition,
            [In] uint textLength,
            [In] IDWriteTextAnalysisSink? analysisSink);

        /// <summary>
        /// Analyzes a text range for potential breakpoint opportunities, reading
        /// attributes from the source and reporting breakpoint opportunities to
        /// the sink callback SetLineBreakpoints.
        /// </summary>
        /// <param name="analysisSource">Source object to analyze.</param>
        /// <param name="textPosition">Starting position within the source object.</param>
        /// <param name="textLength">Length to analyze.</param>
        /// <param name="analysisSink">Callback object.</param>
        /// <remarks>
        /// While the function can handle multiple paragraphs, the text range
        /// should not arbitrarily split the middle of paragraphs, unless the
        /// given text span is considered a whole unit. Otherwise the
        /// returned properties for the first and last characters will
        /// inappropriately allow breaks.
        /// </remarks>
        /// <remarks>
        /// Special cases include the first, last, and surrogate characters. Any
        /// text span is treated as if adjacent to inline objects on either side.
        /// So the rules with contingent-break opportunities are used, where the 
        /// edge between text and inline objects is always treated as a potential
        /// break opportunity, dependent on any overriding rules of the adjacent
        /// objects to prohibit or force the break (see Unicode TR #14).
        /// Surrogate pairs never break between.
        /// </remarks>
        void AnalyzeLineBreakpoints(
            [In] IDWriteTextAnalysisSource? analysisSource,
            [In] uint textPosition,
            [In] uint textLength,
            [In] IDWriteTextAnalysisSink? analysisSink);

        /// <summary>
        /// Parses the input text string and maps it to the set of glyphs and associated glyph data
        /// according to the font and the writing system's rendering rules.
        /// </summary>
        /// <param name="textString">The string to convert to glyphs.</param>
        /// <param name="textLength">The length of textString.</param>
        /// <param name="fontFace">The font face to get glyphs from.</param>
        /// <param name="isSideways">Set to true if the text is intended to be
        /// drawn vertically.</param>
        /// <param name="isRightToLeft">Set to TRUE for right-to-left text.</param>
        /// <param name="scriptAnalysis">Script analysis result from AnalyzeScript.</param>
        /// <param name="localeName">The locale to use when selecting glyphs.
        /// If this is NULL then the default mapping based on the script is used.</param>
        /// <param name="numberSubstitution">Optional number substitution which
        /// selects the appropriate glyphs for digits and related numeric characters,
        /// depending on the results obtained from AnalyzeNumberSubstitution. Passing
        /// null indicates that no substitution is needed and that the digits should
        /// receive nominal glyphs.</param>
        /// <param name="features">An array of pointers to the sets of typographic 
        /// features to use in each feature range.</param>
        /// <param name="featureRangeLengths">The length of each feature range, in characters.  
        /// The sum of all lengths should be equal to textLength.</param>
        /// <param name="featureRanges">The number of feature ranges.</param>
        /// <param name="maxGlyphCount">The maximum number of glyphs that can be
        /// returned.</param>
        /// <param name="clusterMap">The mapping from character ranges to glyph 
        /// ranges.</param>
        /// <param name="textProps">Per-character output properties.</param>
        /// <param name="glyphIndices">Output glyph indices.</param>
        /// <param name="glyphProps">Per-glyph output properties.</param>
        /// <param name="actualGlyphCount">The actual number of glyphs returned if
        /// the call succeeds.</param>
        /// <remarks>
        /// Note that the mapping from characters to glyphs is, in general, many-
        /// to-many.  The recommended estimate for the per-glyph output buffers is
        /// (3 * textLength / 2 + 16).  This is not guaranteed to be sufficient.
        /// The value of the actualGlyphCount parameter is only valid if the call
        /// succeeds.  In the event that <c>maxGlyphCount</c> is not big enough
        /// <value>E_NOT_SUFFICIENT_BUFFER</value>, which is equivalent to <c>HRESULT_FROM_WIN32(ERROR_INSUFFICIENT_BUFFER)</c>,
        /// will be returned.  The application should allocate a larger buffer and try again.
        /// </remarks>
        void GetGlyphs(
            [In, MarshalAs(UnmanagedType.LPWStr)] string? textString,
            [In] uint textLength,
            [In] IDWriteFontFace? fontFace,
            [In, MarshalAs(UnmanagedType.Bool)] bool isSideways,
            [In, MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
            [In] ref DWriteScriptAnalysis scriptAnalysis,
            [In, MarshalAs(UnmanagedType.LPWStr)] string? localeName,
            [In] IDWriteNumberSubstitution? numberSubstitution,
            [In] IntPtr features,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths,
            [In] uint featureRanges,
            [In] uint maxGlyphCount,
            [Out, MarshalAs(UnmanagedType.LPArray)] ushort[]? clusterMap,
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteShapingTextProperties[]? textProps,
            [Out, MarshalAs(UnmanagedType.LPArray)] ushort[]? glyphIndices,
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteShapingGlyphProperties[]? glyphProps,
            [Out] out uint actualGlyphCount);

        /// <summary>
        /// Place glyphs output from the GetGlyphs method according to the font 
        /// and the writing system's rendering rules.
        /// </summary>
        /// <param name="textString">The original string the glyphs came from.</param>
        /// <param name="clusterMap">The mapping from character ranges to glyph 
        /// ranges. Returned by GetGlyphs.</param>
        /// <param name="textProps">Per-character properties. Returned by 
        /// GetGlyphs.</param>
        /// <param name="textLength">The length of textString.</param>
        /// <param name="glyphIndices">Glyph indices. See GetGlyphs</param>
        /// <param name="glyphProps">Per-glyph properties. See GetGlyphs</param>
        /// <param name="glyphCount">The number of glyphs.</param>
        /// <param name="fontFace">The font face the glyphs came from.</param>
        /// <param name="fontEmSize">Logical font size in DIP's.</param>
        /// <param name="isSideways">Set to true if the text is intended to be
        /// drawn vertically.</param>
        /// <param name="isRightToLeft">Set to TRUE for right-to-left text.</param>
        /// <param name="scriptAnalysis">Script analysis result from AnalyzeScript.</param>
        /// <param name="localeName">The locale to use when selecting glyphs.
        /// If this is NULL then the default mapping based on the script is used.</param>
        /// <param name="features">An array of pointers to the sets of typographic 
        /// features to use in each feature range.</param>
        /// <param name="featureRangeLengths">The length of each feature range, in characters.  
        /// The sum of all lengths should be equal to textLength.</param>
        /// <param name="featureRanges">The number of feature ranges.</param>
        /// <param name="glyphAdvances">The advance width of each glyph.</param>
        /// <param name="glyphOffsets">The offset of the origin of each glyph.</param>
        void GetGlyphPlacements(
            [In, MarshalAs(UnmanagedType.LPWStr)] string? textString,
            [In, MarshalAs(UnmanagedType.LPArray)] ushort[]? clusterMap,
            [In, MarshalAs(UnmanagedType.LPArray)] DWriteShapingTextProperties[]? textProps,
            [In] uint textLength,
            [In, MarshalAs(UnmanagedType.LPArray)] ushort[]? glyphIndices,
            [In, MarshalAs(UnmanagedType.LPArray)] DWriteShapingGlyphProperties[]? glyphProps,
            [In] uint glyphCount,
            [In] IDWriteFontFace? fontFace,
            [In] float fontEmSize,
            [In, MarshalAs(UnmanagedType.Bool)] bool isSideways,
            [In, MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
            [In] ref DWriteScriptAnalysis scriptAnalysis,
            [In, MarshalAs(UnmanagedType.LPWStr)] string? localeName,
            [In] IntPtr features,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths,
            [In] uint featureRanges,
            [Out, MarshalAs(UnmanagedType.LPArray)] float[]? glyphAdvances,
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteGlyphOffset[]? glyphOffsets);

        /// <summary>
        /// Place glyphs output from the GetGlyphs method according to the font 
        /// and the writing system's rendering rules.
        /// </summary>
        /// <param name="textString">The original string the glyphs came from.</param>
        /// <param name="clusterMap">The mapping from character ranges to glyph 
        /// ranges. Returned by GetGlyphs.</param>
        /// <param name="textProps">Per-character properties. Returned by 
        /// GetGlyphs.</param>
        /// <param name="textLength">The length of textString.</param>
        /// <param name="glyphIndices">Glyph indices. See GetGlyphs</param>
        /// <param name="glyphProps">Per-glyph properties. See GetGlyphs</param>
        /// <param name="glyphCount">The number of glyphs.</param>
        /// <param name="fontFace">The font face the glyphs came from.</param>
        /// <param name="fontEmSize">Logical font size in DIP's.</param>
        /// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this 
        /// value is 1.0f. If the DPI is 120, this value is 120.0f/96.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the
        /// scaling specified by the font size and pixelsPerDip.</param>
        /// <param name="useGdiNatural">
        /// When set to FALSE, the metrics are the same as the metrics of GDI aliased text.
        /// When set to TRUE, the metrics are the same as the metrics of text measured by GDI using a font
        /// created with CLEARTYPE_NATURAL_QUALITY.
        /// </param>
        /// <param name="isSideways">Set to true if the text is intended to be
        /// drawn vertically.</param>
        /// <param name="isRightToLeft">Set to TRUE for right-to-left text.</param>
        /// <param name="scriptAnalysis">Script analysis result from AnalyzeScript.</param>
        /// <param name="localeName">The locale to use when selecting glyphs.
        /// If this is NULL then the default mapping based on the script is used.</param>
        /// <param name="features">An array of pointers to the sets of typographic 
        /// features to use in each feature range.</param>
        /// <param name="featureRangeLengths">The length of each feature range, in characters.  
        /// The sum of all lengths should be equal to textLength.</param>
        /// <param name="featureRanges">The number of feature ranges.</param>
        /// <param name="glyphAdvances">The advance width of each glyph.</param>
        /// <param name="glyphOffsets">The offset of the origin of each glyph.</param>
        void GetGdiCompatibleGlyphPlacements(
            [In, MarshalAs(UnmanagedType.LPWStr)] string? textString,
            [In, MarshalAs(UnmanagedType.LPArray)] ushort[]? clusterMap,
            [In, MarshalAs(UnmanagedType.LPArray)] DWriteShapingTextProperties[]? textProps,
            [In] uint textLength,
            [In, MarshalAs(UnmanagedType.LPArray)] ushort[]? glyphIndices,
            [In, MarshalAs(UnmanagedType.LPArray)] DWriteShapingGlyphProperties[]? glyphProps,
            [In] uint glyphCount,
            [In] IDWriteFontFace? fontFace,
            [In] float fontEmSize,
            [In] float pixelsPerDip,
            [In] IntPtr transform,
            [In, MarshalAs(UnmanagedType.Bool)] bool useGdiNatural,
            [In, MarshalAs(UnmanagedType.Bool)] bool isSideways,
            [In, MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
            [In] ref DWriteScriptAnalysis scriptAnalysis,
            [In, MarshalAs(UnmanagedType.LPWStr)] string? localeName,
            [In] IntPtr features,
            [In, MarshalAs(UnmanagedType.LPArray)] uint[]? featureRangeLengths,
            [In] uint featureRanges,
            [Out, MarshalAs(UnmanagedType.LPArray)] float[]? glyphAdvances,
            [Out, MarshalAs(UnmanagedType.LPArray)] DWriteGlyphOffset[]? glyphOffsets);
    }
}
