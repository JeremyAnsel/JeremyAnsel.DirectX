// <copyright file="IDWriteTextAnalysisSink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The interface implemented by the text analyzer's client to receive the
    /// output of a given text analysis. The Text analyzer disregards any current
    /// state of the analysis sink, therefore a Set method call on a range
    /// overwrites the previously set analysis result of the same range. 
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("5810cd44-0ca0-4701-b3fa-bec5182ae4f6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextAnalysisSink
    {
        /// <summary>
        /// Report script analysis for the text range.
        /// </summary>
        /// <param name="textPosition">Starting position to report from.</param>
        /// <param name="textLength">Number of UTF16 units of the reported range.</param>
        /// <param name="scriptAnalysis">Script analysis of characters in range.</param>
        void SetScriptAnalysis(
            [In] uint textPosition,
            [In] uint textLength,
            [In] ref DWriteScriptAnalysis scriptAnalysis);

        /// <summary>
        /// Report line-break opportunities for each character, starting from
        /// the specified position.
        /// </summary>
        /// <param name="textPosition">Starting position to report from.</param>
        /// <param name="textLength">Number of UTF16 units of the reported range.</param>
        /// <param name="lineBreakpoints">Breaking conditions for each character.</param>
        void SetLineBreakpoints(
            [In] uint textPosition,
            [In] uint textLength,
            [In, MarshalAs(UnmanagedType.LPArray)] DWriteLineBreakpoint[] lineBreakpoints);

        /// <summary>
        /// Set bidirectional level on the range, called once per each
        /// level run change (either explicit or resolved implicit).
        /// </summary>
        /// <param name="textPosition">Starting position to report from.</param>
        /// <param name="textLength">Number of UTF16 units of the reported range.</param>
        /// <param name="explicitLevel">Explicit level from embedded control codes
        /// RLE/RLO/LRE/LRO/PDF, determined before any additional rules.</param>
        /// <param name="resolvedLevel">Final implicit level considering the
        /// explicit level and characters' natural directionality, after all
        /// Bidi rules have been applied.</param>
        void SetBidiLevel(
            [In] uint textPosition,
            [In] uint textLength,
            [In] byte explicitLevel,
            [In] byte resolvedLevel);

        /// <summary>
        /// Set number substitution on the range.
        /// </summary>
        /// <param name="textPosition">Starting position to report from.</param>
        /// <param name="textLength">Number of UTF16 units of the reported range.</param>
        /// <param name="numberSubstitution">The number substitution applicable to
        /// the returned range of text. The sink callback may hold onto it by
        /// incrementing its ref count.</param>
        /// <remark>
        /// Unlike script and bidi analysis, where every character passed to the
        /// analyzer has a result, this will only be called for those ranges where
        /// substitution is applicable. For any other range, you will simply not
        /// be called.
        /// </remark>
        void SetNumberSubstitution(
            [In] uint textPosition,
            [In] uint textLength,
            [In] IDWriteNumberSubstitution numberSubstitution);
    }
}
