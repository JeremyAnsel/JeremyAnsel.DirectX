// <copyright file="DWriteTextLayout.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// The IDWriteTextLayout interface represents a block of text after it has
    /// been fully analyzed and formatted.
    /// All coordinates are in device independent pixels (DIPs).
    /// </summary>
    public sealed class DWriteTextLayout : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite text layout interface.
        /// </summary>
        private readonly IDWriteTextLayout handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteTextLayout"/> class.
        /// </summary>
        /// <param name="handle">A DWrite factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteTextLayout(IDWriteTextLayout handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets an handle representing the DWrite object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle; }
        }

        /// <summary>
        /// Gets or sets the alignment option of text relative to layout box's leading and trailing edge.
        /// </summary>
        public DWriteTextAlignment TextAlignment
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetTextAlignment(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetTextAlignment(value); }
        }

        /// <summary>
        /// Gets or sets the alignment option of paragraph relative to layout box's top and bottom edge.
        /// </summary>
        public DWriteParagraphAlignment ParagraphAlignment
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetParagraphAlignement(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetParagraphAlignment(value); }
        }

        /// <summary>
        /// Gets or sets the word wrapping option.
        /// </summary>
        public DWriteWordWrapping WordWrapping
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetWordWrapping(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetWordWrapping(value); }
        }

        /// <summary>
        /// Gets or sets the paragraph reading direction.
        /// </summary>
        /// <remarks>
        /// The flow direction must be perpendicular to the reading direction.
        /// Setting both to a vertical direction or both to horizontal yields
        /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
        /// </remarks>
        public DWriteReadingDirection ReadingDirection
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetReadingDirection(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetReadingDirection(value); }
        }

        /// <summary>
        /// Gets or sets paragraph flow direction.
        /// </summary>
        /// <remarks>
        /// The flow direction must be perpendicular to the reading direction.
        /// Setting both to a vertical direction or both to horizontal yields
        /// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics or Draw.
        /// </remarks>
        public DWriteFlowDirection FlowDirection
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetFlowDirection(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetFlowDirection(value); }
        }

        /// <summary>
        /// Gets or sets the incremental tab stop position.
        /// </summary>
        public float IncrementalTabStop
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetIncrementalTabStop(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetIncrementalTabStop(value); }
        }

        /// <summary>
        /// Gets or sets the layout maximum width
        /// </summary>
        public float MaxWidth
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetMaxWidth(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetMaxWidth(value); }
        }

        /// <summary>
        /// Gets or sets the layout maximum height
        /// </summary>
        public float MaxHeight
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetMaxHeight(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { this.handle.SetMaxHeight(value); }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteTextLayout value)
        {
            return value != null && value.handle != null;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the DWrite object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM DWrite interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.handle);
        }

        /// <summary>
        /// Set trimming options for any trailing text exceeding the layout width
        /// or for any far text exceeding the layout height.
        /// </summary>
        /// <param name="trimmingOptions">Text trimming options.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTrimming(DWriteTrimming trimmingOptions)
        {
            this.handle.SetTrimming(ref trimmingOptions, null);
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLineSpacing(DWriteLineSpacingMethod lineSpacingMethod, float lineSpacing, float baseline)
        {
            this.handle.SetLineSpacing(lineSpacingMethod, lineSpacing, baseline);
        }

        /// <summary>
        /// Get trimming options for text overflowing the layout width.
        /// </summary>
        /// <returns><see cref="DWriteTrimming"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteTrimming GetTrimming()
        {
            this.handle.GetTrimming(out DWriteTrimming trimmingOptions, IntPtr.Zero);
            return trimmingOptions;
        }

        /// <summary>
        /// Get line spacing.
        /// </summary>
        /// <param name="lineSpacingMethod">How line height is determined.</param>
        /// <param name="lineSpacing">The line height, or rather distance between one baseline to another.</param>
        /// <param name="baseline">Distance from top of line to baseline.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetLineSpacing(out DWriteLineSpacingMethod lineSpacingMethod, out float lineSpacing, out float baseline)
        {
            this.handle.GetLineSpacing(out lineSpacingMethod, out lineSpacing, out baseline);
        }

        /// <summary>
        /// Get the font collection.
        /// </summary>
        /// <returns><see cref="DWriteFontCollection"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontCollection GetFontCollection()
        {
            this.handle.GetFontCollection(out IDWriteFontCollection fontCollection);

            if (fontCollection == null)
            {
                return null;
            }

            return new DWriteFontCollection(fontCollection);
        }

        /// <summary>
        /// Get a copy of the font family name.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetFontFamilyName()
        {
            uint length = this.handle.GetFontFamilyNameLength();
            length++;

            StringBuilder name = new StringBuilder((int)length);
            this.handle.GetFontFamilyName(name, length);

            return name.ToString();
        }

        /// <summary>
        /// Get a copy of the locale name.
        /// </summary>
        /// <returns><see cref="string"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetLocaleName()
        {
            uint length = this.handle.GetLocaleNameLength();
            length++;

            StringBuilder name = new StringBuilder((int)length);
            this.handle.GetLocaleName(name, length);

            return name.ToString();
        }

        /// <summary>
        /// Set the font collection.
        /// </summary>
        /// <param name="fontCollection">The font collection to set</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontCollection(DWriteFontCollection fontCollection, DWriteTextRange textRange)
        {
            if (fontCollection == null)
            {
                throw new ArgumentNullException(nameof(fontCollection));
            }

            this.handle.SetFontCollection((IDWriteFontCollection)fontCollection.Handle, textRange);
        }

        /// <summary>
        /// Set null-terminated font family name.
        /// </summary>
        /// <param name="fontFamilyName">Font family name</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontFamilyName(string fontFamilyName, DWriteTextRange textRange)
        {
            this.handle.SetFontFamilyName(fontFamilyName, textRange);
        }

        /// <summary>
        /// Set font weight.
        /// </summary>
        /// <param name="fontWeight">Font weight</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontWeight(DWriteFontWeight fontWeight, DWriteTextRange textRange)
        {
            this.handle.SetFontWeight(fontWeight, textRange);
        }

        /// <summary>
        /// Set font style.
        /// </summary>
        /// <param name="fontStyle">Font style</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontStyle(DWriteFontStyle fontStyle, DWriteTextRange textRange)
        {
            this.handle.SetFontStyle(fontStyle, textRange);
        }

        /// <summary>
        /// Set font stretch.
        /// </summary>
        /// <param name="fontStretch">font stretch</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontStretch(DWriteFontStretch fontStretch, DWriteTextRange textRange)
        {
            this.handle.SetFontStretch(fontStretch, textRange);
        }

        /// <summary>
        /// Set font em height.
        /// </summary>
        /// <param name="fontSize">Font em height</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFontSize(float fontSize, DWriteTextRange textRange)
        {
            this.handle.SetFontSize(fontSize, textRange);
        }

        /// <summary>
        /// Set underline.
        /// </summary>
        /// <param name="hasUnderline">The Boolean flag indicates whether underline takes place</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetUnderline(bool hasUnderline, DWriteTextRange textRange)
        {
            this.handle.SetUnderline(hasUnderline, textRange);
        }

        /// <summary>
        /// Set strikethrough.
        /// </summary>
        /// <param name="hasStrikethrough">The Boolean flag indicates whether strikethrough takes place</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetStrikethrough(bool hasStrikethrough, DWriteTextRange textRange)
        {
            this.handle.SetStrikethrough(hasStrikethrough, textRange);
        }

        /// <summary>
        /// Set font typography features.
        /// </summary>
        /// <param name="typography">Pointer to font typography setting.</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTypography(DWriteTypography typography, DWriteTextRange textRange)
        {
            if (typography == null)
            {
                throw new ArgumentNullException(nameof(typography));
            }

            this.handle.SetTypography((IDWriteTypography)typography.Handle, textRange);
        }

        /// <summary>
        /// Set locale name.
        /// </summary>
        /// <param name="localeName">Locale name</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLocaleName(string localeName, DWriteTextRange textRange)
        {
            this.handle.SetLocaleName(localeName, textRange);
        }

        /// <summary>
        /// Get the font collection where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">Text range to which this change applies.</param>
        /// <returns><see cref="DWriteFontCollection"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontCollection GetFontCollection(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetFontCollection(currentPosition, out IDWriteFontCollection fontCollection, out textRange);

            if (fontCollection == null)
            {
                return null;
            }

            return new DWriteFontCollection(fontCollection);
        }

        /// <summary>
        /// Copy the font family name where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="string"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetFontFamilyName(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetFontFamilyNameLength(currentPosition, out uint length, out _);
            length++;

            StringBuilder name = new StringBuilder((int)length);
            this.handle.GetFontFamilyName(currentPosition, name, length, out textRange);

            return name.ToString();
        }

        /// <summary>
        /// Gets the font weight.
        /// </summary>
        /// <returns><see cref="DWriteFontWeight"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontWeight GetFontWeight()
        {
            return this.handle.GetFontWeight();
        }

        /// <summary>
        /// Get the font weight where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="DWriteFontWeight"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontWeight GetFontWeight(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetFontWeight(currentPosition, out DWriteFontWeight fontWeight, out textRange);
            return fontWeight;
        }

        /// <summary>
        /// Gets the font style.
        /// </summary>
        /// <returns><see cref="DWriteFontStyle"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontStyle GetFontStyle()
        {
            return this.handle.GetFontStyle();
        }

        /// <summary>
        /// Get the font style where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="DWriteFontStyle"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontStyle GetFontStyle(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetFontStyle(currentPosition, out DWriteFontStyle fontStyle, out textRange);
            return fontStyle;
        }

        /// <summary>
        /// Gets the font stretch.
        /// </summary>
        /// <returns><see cref="DWriteFontStretch"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontStretch GetFontStretch()
        {
            return this.handle.GetFontStretch();
        }

        /// <summary>
        /// Get the font stretch where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="DWriteFontStretch"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontStretch GetFontStretch(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetFontStretch(currentPosition, out DWriteFontStretch fontStretch, out textRange);
            return fontStretch;
        }

        /// <summary>
        /// Gets the font em height.
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetFontSize()
        {
            return this.handle.GetFontSize();
        }

        /// <summary>
        /// Get the font em height where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="float"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetFontSize(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetFontSize(currentPosition, out float fontSize, out textRange);
            return fontSize;
        }

        /// <summary>
        /// Get the underline presence where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="bool"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetUnderline(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetUnderline(currentPosition, out bool hasUnderline, out textRange);
            return hasUnderline;
        }

        /// <summary>
        /// Get the strikethrough presence where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="bool"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool GetStrikethrough(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetStrikethrough(currentPosition, out bool hasStrikethrough, out textRange);
            return hasStrikethrough;
        }

        /// <summary>
        /// Get the typography setting where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="DWriteTypography"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteTypography GetTypography(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetTypography(currentPosition, out IDWriteTypography typography, out textRange);

            if (typography == null)
            {
                return null;
            }

            return new DWriteTypography(typography);
        }

        /// <summary>
        /// Get the locale name where the current position is at.
        /// </summary>
        /// <param name="currentPosition">The current text position.</param>
        /// <param name="textRange">The position range of the current format.</param>
        /// <returns><see cref="string"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string GetLocaleName(uint currentPosition, out DWriteTextRange textRange)
        {
            this.handle.GetLocaleNameLength(currentPosition, out uint length, out _);
            length++;

            StringBuilder name = new StringBuilder((int)length);
            this.handle.GetLocaleName(currentPosition, name, length, out textRange);

            return name.ToString();
        }

        /// <summary>
        /// GetMetrics retrieves overall metrics for the formatted string.
        /// </summary>
        /// <remarks>
        /// Drawing effects like underline and strikethrough do not contribute
        /// to the text size, which is essentially the sum of advance widths and
        /// line heights. Additionally, visible swashes and other graphic
        /// adornments may extend outside the returned width and height.
        /// </remarks>
        /// <returns><see cref="DWriteTextMetrics"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteTextMetrics GetMetrics()
        {
            this.handle.GetMetrics(out DWriteTextMetrics textMetrics);
            return textMetrics;
        }

        /// <summary>
        /// GetOverhangMetrics returns the overhangs (in DIPs) of the layout and all
        /// objects contained in it, including text glyphs and inline objects.
        /// </summary>
        /// <remarks>
        /// Any underline and strikethrough do not contribute to the black box
        /// determination, since these are actually drawn by the renderer, which
        /// is allowed to draw them in any variety of styles.
        /// </remarks>
        /// <returns><see cref="DWriteOverhangMetrics"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteOverhangMetrics GetOverhangMetrics()
        {
            this.handle.GetOverhangMetrics(out DWriteOverhangMetrics overhangs);
            return overhangs;
        }

        /// <summary>
        /// Determines the minimum possible width the layout can be set to without
        /// emergency breaking between the characters of whole words.
        /// </summary>
        /// <returns><see cref="float"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float DetermineMinWidth()
        {
            this.handle.DetermineMinWidth(out float minWidth);
            return minWidth;
        }

        /// <summary>
        /// Given a coordinate (in DIPs) relative to the top-left of the layout box,
        /// this returns the corresponding hit-test metrics of the text string where
        /// the hit-test has occurred. This is useful for mapping mouse clicks to caret
        /// positions. When the given coordinate is outside the text string, the function
        /// sets the output value isInside to false but returns the nearest character
        /// position.
        /// </summary>
        /// <param name="pointX">X coordinate to hit-test, relative to the top-left location of the layout box.</param>
        /// <param name="pointY">Y coordinate to hit-test, relative to the top-left location of the layout box.</param>
        /// <param name="isTrailingHit">Output flag indicating whether the hit-test location is at the leading or the trailing
        /// side of the character. When the output isInside value is set to false, this value is set according to the output
        /// position value to represent the edge closest to the hit-test location. </param>
        /// <param name="isInside">Output flag indicating whether the hit-test location is inside the text string.
        /// When false, the position nearest the text's edge is returned.</param>
        /// <returns><see cref="DWriteHitTestMetrics"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteHitTestMetrics HitTestPoint(float pointX, float pointY, out bool isTrailingHit, out bool isInside)
        {
            this.handle.HitTestPoint(pointX, pointY, out isTrailingHit, out isInside, out DWriteHitTestMetrics hitTestMetrics);
            return hitTestMetrics;
        }

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
        /// <returns><see cref="DWriteHitTestMetrics"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteHitTestMetrics HitTestTextPosition(uint textPosition, bool isTrailingHit, out float pointX, out float pointY)
        {
            this.handle.HitTestTextPosition(textPosition, isTrailingHit, out pointX, out pointY, out DWriteHitTestMetrics hitTestMetrics);
            return hitTestMetrics;
        }
    }
}
