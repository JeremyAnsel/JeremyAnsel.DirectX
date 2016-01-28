// <copyright file="DWriteLineBreakpoint.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Line breakpoint characteristics of a character.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteLineBreakpoint : IEquatable<DWriteLineBreakpoint>
    {
        /// <summary>
        /// Packed data.
        /// </summary>
        private byte data;

        /// <summary>
        /// Gets or sets the breaking condition before the character.
        /// </summary>
        public DWriteBreakCondition BreakConditionBefore
        {
            get { return (DWriteBreakCondition)(this.data & 0x3U); }
            set { this.data ^= (byte)((this.data ^ (byte)value) & 0x3U); }
        }

        /// <summary>
        /// Gets or sets the breaking condition after the character.
        /// </summary>
        public DWriteBreakCondition BreakConditionAfter
        {
            get { return (DWriteBreakCondition)((this.data >> 2) & 0x3U); }
            set { this.data ^= (byte)((this.data ^ ((byte)value << 2)) & (0x3U << 2)); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the character is some form of whitespace, which may be meaningful
        /// for justification.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", Justification = "Reviewed")]
        public bool IsWhitespace
        {
            get
            {
                return (this.data & (1U << 4)) != 0;
            }

            set
            {
                if (value)
                {
                    this.data |= (byte)(1U << 4);
                }
                else
                {
                    this.data &= unchecked((byte)~(1U << 4));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether  the character is a soft hyphen, often used to indicate hyphenation
        /// points inside words.
        /// </summary>
        public bool IsSoftHyphen
        {
            get
            {
                return (this.data & (1U << 5)) != 0;
            }

            set
            {
                if (value)
                {
                    this.data |= (byte)(1U << 5);
                }
                else
                {
                    this.data &= unchecked((byte)~(1U << 5));
                }
            }
        }

        /// <summary>
        /// Compares two <see cref="DWriteLineBreakpoint"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteLineBreakpoint"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteLineBreakpoint"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteLineBreakpoint left, DWriteLineBreakpoint right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteLineBreakpoint"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteLineBreakpoint"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteLineBreakpoint"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteLineBreakpoint left, DWriteLineBreakpoint right)
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
            if (!(obj is DWriteLineBreakpoint))
            {
                return false;
            }

            return this.Equals((DWriteLineBreakpoint)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteLineBreakpoint other)
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
