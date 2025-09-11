// <copyright file="DWriteGlyphRunDescription.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_GLYPH_RUN_DESCRIPTION structure contains additional properties
    /// related to those in DWRITE_GLYPH_RUN.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteGlyphRunDescription : IEquatable<DWriteGlyphRunDescription>
    {
        /// <summary>
        /// The locale name associated with this run.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        private string localeName;

        /// <summary>
        /// The text associated with the glyphs.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        private string textString;

        /// <summary>
        /// The number of characters (UTF16 code-units).
        /// Note that this may be different than the number of glyphs.
        /// </summary>
        private uint textLength;

        /// <summary>
        /// An array of indices to the glyph indices array, of the first glyphs of
        /// all the glyph clusters of the glyphs to render. 
        /// </summary>
        [MarshalAs(UnmanagedType.LPArray)]
        private ushort[] clusterMap;

        /// <summary>
        /// Corresponding text position in the original string
        /// this glyph run came from.
        /// </summary>
        private uint textPosition;

        /// <summary>
        /// Gets or sets the locale name associated with this run.
        /// </summary>
        public string LocaleName
        {
            get { return this.localeName; }
            set { this.localeName = value; }
        }

        /// <summary>
        /// Gets or sets the text associated with the glyphs.
        /// </summary>
        public string TextString
        {
            get
            {
                return this.textString;
            }

            set
            {
                this.textString = value;
                this.textLength = value == null ? 0U : (uint)value.Length;
            }
        }

        /// <summary>
        /// Gets the number of characters (UTF16 code-units).
        /// Note that this may be different than the number of glyphs.
        /// </summary>
        public uint TextLength
        {
            get { return this.textLength; }
        }

        /// <summary>
        /// Gets or sets an array of indices to the glyph indices array, of the first glyphs of
        /// all the glyph clusters of the glyphs to render. 
        /// </summary>
        [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "Reviewed")]
        public ushort[] ClusterMap
        {
            get
            {
                return this.clusterMap;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (value.Length != this.textLength)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.clusterMap = value;
            }
        }

        /// <summary>
        /// Gets or sets the corresponding text position in the original string
        /// this glyph run came from.
        /// </summary>
        public uint TextPosition
        {
            get { return this.textPosition; }
            set { this.textPosition = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphRunDescription"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphRunDescription"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphRunDescription"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteGlyphRunDescription left, DWriteGlyphRunDescription right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphRunDescription"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphRunDescription"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphRunDescription"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteGlyphRunDescription left, DWriteGlyphRunDescription right)
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
            if (obj is not DWriteGlyphRunDescription)
            {
                return false;
            }

            return this.Equals((DWriteGlyphRunDescription)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteGlyphRunDescription other)
        {
            return this.localeName == other.localeName
                && this.textString == other.textString
                && this.textLength == other.textLength
                && this.clusterMap == other.clusterMap
                && this.textPosition == other.textPosition;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.localeName,
                this.textString,
                this.textLength,
                this.clusterMap,
                this.textPosition
            }
            .GetHashCode();
        }
    }
}
