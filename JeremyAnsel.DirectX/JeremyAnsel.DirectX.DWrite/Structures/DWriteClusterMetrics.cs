// <copyright file="DWriteClusterMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_CLUSTER_METRICS structure contains information about a glyph cluster.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteClusterMetrics : IEquatable<DWriteClusterMetrics>
    {
        /// <summary>
        /// The total advance width of all glyphs in the cluster.
        /// </summary>
        private float width;

        /// <summary>
        /// The number of text positions in the cluster.
        /// </summary>
        private ushort length;

        /// <summary>
        /// Packed data.
        /// </summary>
        private ushort data;

        /// <summary>
        /// Gets the total advance width of all glyphs in the cluster.
        /// </summary>
        public float Width
        {
            get { return this.width; }
        }

        /// <summary>
        /// Gets the number of text positions in the cluster.
        /// </summary>
        public ushort Length
        {
            get { return this.length; }
        }

        /// <summary>
        /// Gets a value indicating whether the line can be broken right after the cluster.
        /// </summary>
        public bool CanWrapLineAfter
        {
            get { return (this.data & 1U) != 0; }
        }

        /// <summary>
        /// Gets a value indicating whether the cluster corresponds to whitespace character.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace", Justification = "Reviewed")]
        public bool IsWhitespace
        {
            get { return (this.data & (1U << 1)) != 0; }
        }

        /// <summary>
        /// Gets a value indicating whether the cluster corresponds to a newline character.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Newline", Justification = "Reviewed")]
        public bool IsNewline
        {
            get { return (this.data & (1U << 2)) != 0; }
        }

        /// <summary>
        /// Gets a value indicating whether the cluster corresponds to soft hyphen character.
        /// </summary>
        public bool IsSoftHyphen
        {
            get { return (this.data & (1U << 3)) != 0; }
        }

        /// <summary>
        /// Gets a value indicating whether the cluster is read from right to left.
        /// </summary>
        public bool IsRightToLeft
        {
            get { return (this.data & (1U << 4)) != 0; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteClusterMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteClusterMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteClusterMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteClusterMetrics left, DWriteClusterMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteClusterMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteClusterMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteClusterMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteClusterMetrics left, DWriteClusterMetrics right)
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
            if (!(obj is DWriteClusterMetrics))
            {
                return false;
            }

            return this.Equals((DWriteClusterMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteClusterMetrics other)
        {
            return this.width == other.width
                && this.length == other.length
                && this.data == other.data;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.width,
                this.length,
                this.data
            }
            .GetHashCode();
        }
    }
}
