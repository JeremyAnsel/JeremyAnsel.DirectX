// <copyright file="DWriteTextMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Overall metrics associated with text after layout.
    /// All coordinates are in device independent pixels (DIPs).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteTextMetrics : IEquatable<DWriteTextMetrics>
    {
        /// <summary>
        /// Left-most point of formatted text relative to layout box
        /// (excluding any glyph overhang).
        /// </summary>
        private float left;

        /// <summary>
        /// Top-most point of formatted text relative to layout box
        /// (excluding any glyph overhang).
        /// </summary>
        private float top;

        /// <summary>
        /// The width of the formatted text ignoring trailing whitespace
        /// at the end of each line.
        /// </summary>
        private float width;

        /// <summary>
        /// The width of the formatted text taking into account the
        /// trailing whitespace at the end of each line.
        /// </summary>
        private float widthIncludingTrailingWhitespace;

        /// <summary>
        /// The height of the formatted text. The height of an empty string
        /// is determined by the size of the default font's line height.
        /// </summary>
        private float height;

        /// <summary>
        /// Initial width given to the layout. Depending on whether the text
        /// was wrapped or not, it can be either larger or smaller than the
        /// text content width.
        /// </summary>
        private float layoutWidth;

        /// <summary>
        /// Initial height given to the layout. Depending on the length of the
        /// text, it may be larger or smaller than the text content height.
        /// </summary>
        private float layoutHeight;

        /// <summary>
        /// The maximum reordering count of any line of text, used
        /// to calculate the most number of hit-testing boxes needed.
        /// If the layout has no bidirectional text or no text at all,
        /// the minimum level is 1.
        /// </summary>
        private uint maxBidiReorderingDepth;

        /// <summary>
        /// Total number of lines.
        /// </summary>
        private uint lineCount;

        /// <summary>
        /// Gets the left-most point of formatted text relative to layout box
        /// (excluding any glyph overhang).
        /// </summary>
        public float Left
        {
            get { return this.left; }
        }

        /// <summary>
        /// Gets the top-most point of formatted text relative to layout box
        /// (excluding any glyph overhang).
        /// </summary>
        public float Top
        {
            get { return this.top; }
        }

        /// <summary>
        /// Gets the width of the formatted text ignoring trailing whitespace
        /// at the end of each line.
        /// </summary>
        public float Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Gets the width of the formatted text taking into account the
        /// trailing whitespace at the end of each line.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", Justification = "Reviewed")]
        public float WidthIncludingTrailingWhitespace
        {
            get { return this.widthIncludingTrailingWhitespace; }
        }

        /// <summary>
        /// Gets the height of the formatted text. The height of an empty string
        /// is determined by the size of the default font's line height.
        /// </summary>
        public float Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// Gets the initial width given to the layout. Depending on whether the text
        /// was wrapped or not, it can be either larger or smaller than the
        /// text content width.
        /// </summary>
        public float LayoutWidth
        {
            get { return this.layoutWidth; }
        }

        /// <summary>
        /// Gets the initial height given to the layout. Depending on the length of the
        /// text, it may be larger or smaller than the text content height.
        /// </summary>
        public float LayoutHeight
        {
            get { return this.layoutHeight; }
        }

        /// <summary>
        /// Gets the maximum reordering count of any line of text, used
        /// to calculate the most number of hit-testing boxes needed.
        /// If the layout has no bidirectional text or no text at all,
        /// the minimum level is 1.
        /// </summary>
        public uint MaxBidiReorderingDepth
        {
            get { return this.maxBidiReorderingDepth; }
        }

        /// <summary>
        /// Gets the total number of lines.
        /// </summary>
        public uint LineCount
        {
            get { return this.lineCount; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteTextMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteTextMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteTextMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteTextMetrics left, DWriteTextMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteTextMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteTextMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteTextMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteTextMetrics left, DWriteTextMetrics right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DWriteTextMetrics))
            {
                return false;
            }

            return this.Equals((DWriteTextMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteTextMetrics other)
        {
            return this.left == other.left
                && this.top == other.top
                && this.width == other.width
                && this.widthIncludingTrailingWhitespace == other.widthIncludingTrailingWhitespace
                && this.height == other.height
                && this.layoutWidth == other.layoutWidth
                && this.layoutHeight == other.layoutHeight
                && this.maxBidiReorderingDepth == other.maxBidiReorderingDepth
                && this.lineCount == other.lineCount;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.left,
                this.top,
                this.width,
                this.widthIncludingTrailingWhitespace,
                this.height,
                this.layoutWidth,
                this.layoutHeight,
                this.maxBidiReorderingDepth,
                this.lineCount
            }
            .GetHashCode();
        }
    }
}
