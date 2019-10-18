// <copyright file="DWriteShapingGlyphProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Shaping output properties per output glyph.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteShapingGlyphProperties : IEquatable<DWriteShapingGlyphProperties>
    {
        /// <summary>
        /// Packed data.
        /// </summary>
        private ushort data;

        /// <summary>
        /// Gets or sets the justification class, whether to use spacing, kashidas, or
        /// another method. This exists for backwards compatibility
        /// with <c>Uniscribe's SCRIPT_JUSTIFY</c> enumeration.
        /// </summary>
        public ushort Justification
        {
            get { return (ushort)(this.data & 0xFU); }
            set { this.data ^= (ushort)((this.data ^ value) & 0xFU); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the glyph is the first of a cluster.
        /// </summary>
        public bool IsClusterStart
        {
            get
            {
                return (this.data & (1U << 4)) != 0;
            }

            set
            {
                if (value)
                {
                    this.data |= (ushort)(1U << 4);
                }
                else
                {
                    this.data &= unchecked((ushort)~(1U << 4));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether  the glyph is a diacritic.
        /// </summary>
        public bool IsDiacritic
        {
            get
            {
                return (this.data & (1U << 5)) != 0;
            }

            set
            {
                if (value)
                {
                    this.data |= (ushort)(1U << 5);
                }
                else
                {
                    this.data &= unchecked((ushort)~(1U << 5));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the glyph has no width, blank, ZWJ, ZWNJ etc.
        /// </summary>
        public bool IsZeroWidthSpace
        {
            get
            {
                return (this.data & (1U << 6)) != 0;
            }

            set
            {
                if (value)
                {
                    this.data |= (ushort)(1U << 6);
                }
                else
                {
                    this.data &= unchecked((ushort)~(1U << 6));
                }
            }
        }

        /// <summary>
        /// Compares two <see cref="DWriteShapingGlyphProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteShapingGlyphProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteShapingGlyphProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteShapingGlyphProperties left, DWriteShapingGlyphProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteShapingGlyphProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteShapingGlyphProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteShapingGlyphProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteShapingGlyphProperties left, DWriteShapingGlyphProperties right)
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
            if (!(obj is DWriteShapingGlyphProperties))
            {
                return false;
            }

            return this.Equals((DWriteShapingGlyphProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteShapingGlyphProperties other)
        {
            return this.data == other.data;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.data.GetHashCode();
        }
    }
}
