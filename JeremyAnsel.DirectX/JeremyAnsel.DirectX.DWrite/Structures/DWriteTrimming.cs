// <copyright file="DWriteTrimming.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_TRIMMING structure specifies the trimming option for text overflowing the layout box.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteTrimming : IEquatable<DWriteTrimming>
    {
        /// <summary>
        /// Text granularity of which trimming applies.
        /// </summary>
        private DWriteTrimmingGranularity granularity;

        /// <summary>
        /// Character code used as the delimiter signaling the beginning of the portion of text to be preserved,
        /// most useful for path ellipsis, where the delimiter would be a slash.
        /// </summary>
        private uint delimiter;

        /// <summary>
        /// How many occurrences of the delimiter to step back.
        /// </summary>
        private uint delimiterCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteTrimming"/> struct.
        /// </summary>
        /// <param name="granularity">Text granularity of which trimming applies.</param>
        /// <param name="delimiter">Character code used as the delimiter signaling the beginning of the portion of text to be preserved.</param>
        /// <param name="delimiterCount">How many occurrences of the delimiter to step back.</param>
        public DWriteTrimming(DWriteTrimmingGranularity granularity, uint delimiter, uint delimiterCount)
        {
            this.granularity = granularity;
            this.delimiter = delimiter;
            this.delimiterCount = delimiterCount;
        }

        /// <summary>
        /// Gets or sets the text granularity of which trimming applies.
        /// </summary>
        public DWriteTrimmingGranularity Granularity
        {
            get { return this.granularity; }
            set { this.granularity = value; }
        }

        /// <summary>
        /// Gets or sets the character code used as the delimiter signaling the beginning of the portion of text to be preserved,
        /// most useful for path ellipsis, where the delimiter would be a slash.
        /// </summary>
        public uint Delimiter
        {
            get { return this.delimiter; }
            set { this.delimiter = value; }
        }

        /// <summary>
        /// Gets or sets how many occurrences of the delimiter to step back.
        /// </summary>
        public uint DelimiterCount
        {
            get { return this.delimiterCount; }
            set { this.delimiterCount = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteTrimming"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteTrimming"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteTrimming"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteTrimming left, DWriteTrimming right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteTrimming"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteTrimming"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteTrimming"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteTrimming left, DWriteTrimming right)
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
            if (obj is not DWriteTrimming)
            {
                return false;
            }

            return this.Equals((DWriteTrimming)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteTrimming other)
        {
            return this.granularity == other.granularity
                && this.delimiter == other.delimiter
                && this.delimiterCount == other.delimiterCount;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.granularity,
                this.delimiter,
                this.delimiterCount
            }
            .GetHashCode();
        }
    }
}
