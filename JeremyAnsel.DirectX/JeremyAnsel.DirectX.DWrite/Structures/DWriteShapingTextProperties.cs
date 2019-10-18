// <copyright file="DWriteShapingTextProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Shaping output properties per input character.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteShapingTextProperties : IEquatable<DWriteShapingTextProperties>
    {
        /// <summary>
        /// Packed data.
        /// </summary>
        private ushort data;

        /// <summary>
        /// Gets or sets a value indicating whether this character can be shaped independently from the others
        /// (usually set for the space character).
        /// </summary>
        public bool IsShapedAlone
        {
            get
            {
                return (this.data & 1U) != 0;
            }

            set
            {
                if (value)
                {
                    this.data |= (ushort)1U;
                }
                else
                {
                    this.data &= unchecked((ushort)~1U);
                }
            }
        }

        /// <summary>
        /// Compares two <see cref="DWriteShapingTextProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteShapingTextProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteShapingTextProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteShapingTextProperties left, DWriteShapingTextProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteShapingTextProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteShapingTextProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteShapingTextProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteShapingTextProperties left, DWriteShapingTextProperties right)
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
            if (!(obj is DWriteShapingTextProperties))
            {
                return false;
            }

            return this.Equals((DWriteShapingTextProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteShapingTextProperties other)
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
