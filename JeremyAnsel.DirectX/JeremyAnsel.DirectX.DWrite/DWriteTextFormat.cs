// <copyright file="DWriteTextFormat.cs" company="Jérémy Ansel">
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
    /// The format of text used for text layout.
    /// </summary>
    /// <remarks>
    /// This object may not be thread-safe and it may carry the state of text format change.
    /// </remarks>
    public sealed class DWriteTextFormat : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite text format interface.
        /// </summary>
        private IDWriteTextFormat handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteTextFormat"/> class.
        /// </summary>
        /// <param name="handle">A DWrite factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteTextFormat(IDWriteTextFormat handle)
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
        /// Gets the font weight.
        /// </summary>
        public DWriteFontWeight FontWeight
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetFontWeight(); }
        }

        /// <summary>
        /// Gets the font style.
        /// </summary>
        public DWriteFontStyle FontStyle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetFontStyle(); }
        }

        /// <summary>
        /// Gets the font stretch.
        /// </summary>
        public DWriteFontStretch FontStretch
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetFontStretch(); }
        }

        /// <summary>
        /// Gets the font em height.
        /// </summary>
        public float FontSize
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetFontSize(); }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteTextFormat value)
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
            DWriteTrimming trimmingOptions;
            this.handle.GetTrimming(out trimmingOptions, IntPtr.Zero);
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
        public void GetLineSpaceing(out DWriteLineSpacingMethod lineSpacingMethod, out float lineSpacing, out float baseline)
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
            IDWriteFontCollection fontCollection;
            this.handle.GetFontCollection(out fontCollection);
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
    }
}
