// <copyright file="DWriteGlyphRun.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// The DWRITE_GLYPH_RUN structure contains the information needed by renderers
    /// to draw glyph runs. All coordinates are in device independent pixels (DIPs).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteGlyphRun : IEquatable<DWriteGlyphRun>
    {
        /// <summary>
        /// The physical font face to draw with.
        /// </summary>
        private IDWriteFontFace fontFace;

        /// <summary>
        /// Logical size of the font in DIPs, not points (equals 1/96 inch).
        /// </summary>
        private float fontEMSize;

        /// <summary>
        /// The number of glyphs.
        /// </summary>
        private uint glyphCount;

        /// <summary>
        /// The indices to render.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)]
        private ushort[] glyphIndices;

        /// <summary>
        /// Glyph advance widths.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)]
        private float[] glyphAdvances;

        /// <summary>
        /// Glyph offsets.
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)]
        private DWriteGlyphOffset[] glyphOffsets;

        /// <summary>
        /// If true, specifies that glyphs are rotated 90 degrees to the left and
        /// vertical metrics are used. Vertical writing is achieved by specifying
        /// isSideways = true and rotating the entire run 90 degrees to the right
        /// via a rotate transform.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private bool isSideways;

        /// <summary>
        /// The implicit resolved bidi level of the run. Odd levels indicate
        /// right-to-left languages like Hebrew and Arabic, while even levels
        /// indicate left-to-right languages like English and Japanese (when
        /// written horizontally). For right-to-left languages, the text origin
        /// is on the right, and text should be drawn to the left.
        /// </summary>
        private uint bidiLevel;

        /// <summary>
        /// Gets or sets the physical font face to draw with.
        /// </summary>
        public DWriteFontFace FontFace
        {
            get
            {
                return new DWriteFontFace(this.fontFace);
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                this.fontFace = (IDWriteFontFace)value.Handle;
            }
        }

        /// <summary>
        /// Gets or sets the logical size of the font in DIPs, not points (equals 1/96 inch).
        /// </summary>
        public float FontEMSize
        {
            get { return this.fontEMSize; }
            set { this.fontEMSize = value; }
        }

        /// <summary>
        /// Gets the number of glyphs.
        /// </summary>
        public uint GlyphCount
        {
            get { return this.glyphCount; }
        }

        /// <summary>
        /// Gets the indices to render.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Indices", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Reviewed")]
        public ushort[] GlyphIndices
        {
            get { return this.glyphIndices; }
        }

        /// <summary>
        /// Gets the glyph advance widths.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Reviewed")]
        public float[] GlyphAdvances
        {
            get { return this.glyphAdvances; }
        }

        /// <summary>
        /// Gets the glyph offsets.
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Reviewed")]
        public DWriteGlyphOffset[] GlyphOffsets
        {
            get { return this.glyphOffsets; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether glyphs are rotated 90 degrees to the left and
        /// vertical metrics are used. Vertical writing is achieved by specifying
        /// isSideways = true and rotating the entire run 90 degrees to the right
        /// via a rotate transform.
        /// </summary>
        public bool IsSideways
        {
            get { return this.isSideways; }
            set { this.isSideways = value; }
        }

        /// <summary>
        /// Gets or sets the implicit resolved bidi level of the run. Odd levels indicate
        /// right-to-left languages like Hebrew and Arabic, while even levels
        /// indicate left-to-right languages like English and Japanese (when
        /// written horizontally). For right-to-left languages, the text origin
        /// is on the right, and text should be drawn to the left.
        /// </summary>
        public uint BidiLevel
        {
            get { return this.bidiLevel; }
            set { this.bidiLevel = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphRun"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphRun"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphRun"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteGlyphRun left, DWriteGlyphRun right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphRun"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphRun"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphRun"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteGlyphRun left, DWriteGlyphRun right)
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
            if (!(obj is DWriteGlyphRun))
            {
                return false;
            }

            return this.Equals((DWriteGlyphRun)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteGlyphRun other)
        {
            return this.fontFace == other.fontFace
                && this.fontEMSize == other.fontEMSize
                && this.glyphCount == other.glyphCount
                && this.glyphIndices == other.glyphIndices
                && this.glyphAdvances == other.glyphAdvances
                && this.glyphOffsets == other.glyphOffsets
                && this.isSideways == other.isSideways
                && this.bidiLevel == other.bidiLevel;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.fontFace,
                fontEmSize = this.fontEMSize,
                this.glyphCount,
                this.glyphIndices,
                this.glyphAdvances,
                this.glyphOffsets,
                this.isSideways,
                this.bidiLevel
            }
            .GetHashCode();
        }

        /// <summary>
        /// Sets the glyph indices, advance widths, and offsets.
        /// </summary>
        /// <param name="indices">The indices to render.</param>
        /// <param name="advances">Glyph advance widths.</param>
        /// <param name="offsets">Glyph offsets.</param>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Indices", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "indices", Justification = "Reviewed")]
        public void SetGlyphIndicesAdvancesOffsets(ushort[] indices, float[] advances, DWriteGlyphOffset[] offsets)
        {
            if (indices == null)
            {
                throw new ArgumentNullException("indices");
            }

            if (advances == null)
            {
                throw new ArgumentNullException("advances");
            }

            if (offsets == null)
            {
                throw new ArgumentNullException("offsets");
            }

            if (advances.Length != indices.Length)
            {
                throw new ArgumentOutOfRangeException("advances");
            }

            if (offsets.Length != indices.Length)
            {
                throw new ArgumentOutOfRangeException("offsets");
            }

            this.glyphCount = (uint)indices.Length;
            this.glyphIndices = indices;
            this.glyphAdvances = advances;
            this.glyphOffsets = offsets;
        }
    }
}
