// <copyright file="DWriteLineMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_LINE_METRICS structure contains information about a formatted
    /// line of text.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteLineMetrics : IEquatable<DWriteLineMetrics>
    {
        /// <summary>
        /// The number of total text positions in the line.
        /// This includes any trailing whitespace and newline characters.
        /// </summary>
        private readonly uint length;

        /// <summary>
        /// The number of whitespace positions at the end of the line.  Newline
        /// sequences are considered whitespace.
        /// </summary>
        private readonly uint trailingWhitespaceLength;

        /// <summary>
        /// The number of characters in the newline sequence at the end of the line.
        /// If the count is zero, then the line was either wrapped or it is the
        /// end of the text.
        /// </summary>
        private readonly uint newlineLength;

        /// <summary>
        /// Height of the line as measured from top to bottom.
        /// </summary>
        private readonly float height;

        /// <summary>
        /// Distance from the top of the line to its baseline.
        /// </summary>
        private readonly float baseline;

        /// <summary>
        /// The line is trimmed.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        private readonly bool isTrimmed;

        /// <summary>
        /// Gets the number of total text positions in the line.
        /// This includes any trailing whitespace and newline characters.
        /// </summary>
        public uint Length
        {
            get { return this.length; }
        }

        /// <summary>
        /// Gets the number of whitespace positions at the end of the line.  Newline
        /// sequences are considered whitespace.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", Justification = "Reviewed")]
        public uint TrailingWhitespaceLength
        {
            get { return this.trailingWhitespaceLength; }
        }

        /// <summary>
        /// Gets the number of characters in the newline sequence at the end of the line.
        /// If the count is zero, then the line was either wrapped or it is the
        /// end of the text.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Newline", Justification = "Reviewed")]
        public uint NewlineLength
        {
            get { return this.newlineLength; }
        }

        /// <summary>
        /// Gets the height of the line as measured from top to bottom.
        /// </summary>
        public float Height
        {
            get { return this.height; }
        }

        /// <summary>
        /// Gets the distance from the top of the line to its baseline.
        /// </summary>
        public float Baseline
        {
            get { return this.baseline; }
        }

        /// <summary>
        /// Gets a value indicating whether the line is trimmed.
        /// </summary>
        public bool IsTrimmed
        {
            get { return this.isTrimmed; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteLineMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteLineMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteLineMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteLineMetrics left, DWriteLineMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteLineMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteLineMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteLineMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteLineMetrics left, DWriteLineMetrics right)
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
            if (!(obj is DWriteLineMetrics))
            {
                return false;
            }

            return this.Equals((DWriteLineMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteLineMetrics other)
        {
            return this.length == other.length
                && this.trailingWhitespaceLength == other.trailingWhitespaceLength
                && this.newlineLength == other.newlineLength
                && this.height == other.height
                && this.baseline == other.baseline
                && this.isTrimmed == other.isTrimmed;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.length,
                this.trailingWhitespaceLength,
                this.newlineLength,
                this.height,
                this.baseline,
                this.isTrimmed
            }
            .GetHashCode();
        }
    }
}
