// <copyright file="DWriteTextRange.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_TEXT_RANGE structure specifies a range of text positions where format is applied.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteTextRange : IEquatable<DWriteTextRange>
    {
        /// <summary>
        /// The start text position of the range.
        /// </summary>
        private uint startPosition;

        /// <summary>
        /// The number of text positions in the range.
        /// </summary>
        private uint length;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteTextRange"/> struct.
        /// </summary>
        /// <param name="startPosition">The start text position of the range.</param>
        /// <param name="length">The number of text positions in the range.</param>
        public DWriteTextRange(uint startPosition, uint length)
        {
            this.startPosition = startPosition;
            this.length = length;
        }

        /// <summary>
        /// Gets or sets the start text position of the range.
        /// </summary>
        public uint StartPosition
        {
            get { return this.startPosition; }
            set { this.startPosition = value; }
        }

        /// <summary>
        /// Gets or sets the number of text positions in the range.
        /// </summary>
        public uint Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteTextRange"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteTextRange"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteTextRange"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteTextRange left, DWriteTextRange right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteTextRange"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteTextRange"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteTextRange"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteTextRange left, DWriteTextRange right)
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
            if (obj is not DWriteTextRange)
            {
                return false;
            }

            return this.Equals((DWriteTextRange)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteTextRange other)
        {
            return this.startPosition == other.startPosition
                && this.length == other.length;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.startPosition,
                this.length
            }
            .GetHashCode();
        }
    }
}
