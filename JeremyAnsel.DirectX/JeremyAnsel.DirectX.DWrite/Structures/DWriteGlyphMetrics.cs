// <copyright file="DWriteGlyphMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_GLYPH_METRICS structure specifies the metrics of an individual glyph.
    /// The units depend on how the metrics are obtained.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteGlyphMetrics : IEquatable<DWriteGlyphMetrics>
    {
        /// <summary>
        /// Specifies the X offset from the glyph origin to the left edge of the black box.
        /// The glyph origin is the current horizontal writing position.
        /// A negative value means the black box extends to the left of the origin (often true for lowercase italic 'f').
        /// </summary>
        private readonly int leftSideBearing;

        /// <summary>
        /// Specifies the X offset from the origin of the current glyph to the origin of the next glyph when writing horizontally.
        /// </summary>
        private readonly uint advanceWidth;

        /// <summary>
        /// Specifies the X offset from the right edge of the black box to the origin of the next glyph when writing horizontally.
        /// The value is negative when the right edge of the black box overhangs the layout box.
        /// </summary>
        private readonly int rightSideBearing;

        /// <summary>
        /// Specifies the vertical offset from the vertical origin to the top of the black box.
        /// Thus, a positive value adds whitespace whereas a negative value means the glyph overhangs the top of the layout box.
        /// </summary>
        private readonly int topSideBearing;

        /// <summary>
        /// Specifies the Y offset from the vertical origin of the current glyph to the vertical origin of the next glyph when writing vertically.
        /// (Note that the term "origin" by itself denotes the horizontal origin. The vertical origin is different.
        /// Its Y coordinate is specified by verticalOriginY value,
        /// and its X coordinate is half the advanceWidth to the right of the horizontal origin).
        /// </summary>
        private readonly uint advanceHeight;

        /// <summary>
        /// Specifies the vertical distance from the black box's bottom edge to the advance height.
        /// Positive when the bottom edge of the black box is within the layout box.
        /// Negative when the bottom edge of black box overhangs the layout box.
        /// </summary>
        private readonly int bottomSideBearing;

        /// <summary>
        /// Specifies the Y coordinate of a glyph's vertical origin, in the font's design coordinate system.
        /// The y coordinate of a glyph's vertical origin is the sum of the glyph's top side bearing
        /// and the top (i.e. yMax) of the glyph's bounding box.
        /// </summary>
        private readonly int verticalOriginY;

        /// <summary>
        /// Gets the X offset from the glyph origin to the left edge of the black box.
        /// The glyph origin is the current horizontal writing position.
        /// A negative value means the black box extends to the left of the origin (often true for lowercase italic 'f').
        /// </summary>
        public int LeftSideBearing
        {
            get { return this.leftSideBearing; }
        }

        /// <summary>
        /// Gets the X offset from the origin of the current glyph to the origin of the next glyph when writing horizontally.
        /// </summary>
        public uint AdvanceWidth
        {
            get { return this.advanceWidth; }
        }

        /// <summary>
        /// Gets the X offset from the right edge of the black box to the origin of the next glyph when writing horizontally.
        /// The value is negative when the right edge of the black box overhangs the layout box.
        /// </summary>
        public int RightSideBearing
        {
            get { return this.rightSideBearing; }
        }

        /// <summary>
        /// Gets the vertical offset from the vertical origin to the top of the black box.
        /// Thus, a positive value adds whitespace whereas a negative value means the glyph overhangs the top of the layout box.
        /// </summary>
        public int TopSideBearing
        {
            get { return this.topSideBearing; }
        }

        /// <summary>
        /// Gets the Y offset from the vertical origin of the current glyph to the vertical origin of the next glyph when writing vertically.
        /// (Note that the term "origin" by itself denotes the horizontal origin. The vertical origin is different.
        /// Its Y coordinate is specified by verticalOriginY value,
        /// and its X coordinate is half the advanceWidth to the right of the horizontal origin).
        /// </summary>
        public uint AdvanceHeight
        {
            get { return this.advanceHeight; }
        }

        /// <summary>
        /// Gets the vertical distance from the black box's bottom edge to the advance height.
        /// Positive when the bottom edge of the black box is within the layout box.
        /// Negative when the bottom edge of black box overhangs the layout box.
        /// </summary>
        public int BottomSideBearing
        {
            get { return this.bottomSideBearing; }
        }

        /// <summary>
        /// Gets the Y coordinate of a glyph's vertical origin, in the font's design coordinate system.
        /// The y coordinate of a glyph's vertical origin is the sum of the glyph's top side bearing
        /// and the top (i.e. yMax) of the glyph's bounding box.
        /// </summary>
        public int VerticalOriginY
        {
            get { return this.verticalOriginY; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteGlyphMetrics left, DWriteGlyphMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteGlyphMetrics left, DWriteGlyphMetrics right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DWriteGlyphMetrics)
            {
                return false;
            }

            return this.Equals((DWriteGlyphMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteGlyphMetrics other)
        {
            return this.leftSideBearing == other.leftSideBearing
                && this.advanceWidth == other.advanceWidth
                && this.rightSideBearing == other.rightSideBearing
                && this.topSideBearing == other.topSideBearing
                && this.advanceHeight == other.advanceHeight
                && this.bottomSideBearing == other.bottomSideBearing
                && this.verticalOriginY == other.verticalOriginY;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.leftSideBearing,
                this.advanceWidth,
                this.rightSideBearing,
                this.topSideBearing,
                this.advanceHeight,
                this.bottomSideBearing,
                this.verticalOriginY
            }
            .GetHashCode();
        }
    }
}
