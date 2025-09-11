// <copyright file="DWriteGlyphOffset.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Optional adjustment to a glyph's position. A glyph offset changes the position of a glyph without affecting
    /// the pen position. Offsets are in logical, pre-transform units.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteGlyphOffset : IEquatable<DWriteGlyphOffset>
    {
        /// <summary>
        /// Offset in the advance direction of the run. A positive advance offset moves the glyph to the right
        /// (in pre-transform coordinates) if the run is left-to-right or to the left if the run is right-to-left.
        /// </summary>
        private float advanceOffset;

        /// <summary>
        /// Offset in the ascent direction, i.e., the direction ascenders point. A positive ascender offset moves
        /// the glyph up (in pre-transform coordinates).
        /// </summary>
        private float ascenderOffset;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteGlyphOffset"/> struct.
        /// </summary>
        /// <param name="advanceOffset">Offset in the advance direction of the run.</param>
        /// <param name="ascenderOffset">Offset in the ascent direction, i.e., the direction ascenders point.</param>
        public DWriteGlyphOffset(float advanceOffset, float ascenderOffset)
        {
            this.advanceOffset = advanceOffset;
            this.ascenderOffset = ascenderOffset;
        }

        /// <summary>
        /// Gets or sets the offset in the advance direction of the run. A positive advance offset moves the glyph to the right
        /// (in pre-transform coordinates) if the run is left-to-right or to the left if the run is right-to-left.
        /// </summary>
        public float AdvanceOffset
        {
            get { return this.advanceOffset; }
            set { this.advanceOffset = value; }
        }

        /// <summary>
        /// Gets or sets the offset in the ascent direction, i.e., the direction ascenders point. A positive ascender offset moves
        /// the glyph up (in pre-transform coordinates).
        /// </summary>
        public float AscenderOffset
        {
            get { return this.ascenderOffset; }
            set { this.ascenderOffset = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphOffset"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphOffset"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphOffset"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteGlyphOffset left, DWriteGlyphOffset right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteGlyphOffset"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteGlyphOffset"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteGlyphOffset"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteGlyphOffset left, DWriteGlyphOffset right)
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
            if (obj is not DWriteGlyphOffset)
            {
                return false;
            }

            return this.Equals((DWriteGlyphOffset)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteGlyphOffset other)
        {
            return this.advanceOffset == other.advanceOffset
                && this.ascenderOffset == other.ascenderOffset;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.advanceOffset,
                this.ascenderOffset
            }
            .GetHashCode();
        }
    }
}
