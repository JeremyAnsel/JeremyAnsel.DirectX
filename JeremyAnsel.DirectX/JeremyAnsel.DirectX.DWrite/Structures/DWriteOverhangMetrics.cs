// <copyright file="DWriteOverhangMetrics.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_OVERHANG_METRICS structure holds how much any visible pixels
    /// (in DIPs) overshoot each side of the layout or inline objects.
    /// </summary>
    /// <remarks>
    /// Positive overhangs indicate that the visible area extends outside the layout
    /// box or inline object, while negative values mean there is whitespace inside.
    /// The returned values are unaffected by rendering transforms or pixel snapping.
    /// Additionally, they may not exactly match final target's pixel bounds after
    /// applying grid fitting and hinting.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteOverhangMetrics : IEquatable<DWriteOverhangMetrics>
    {
        /// <summary>
        /// The distance from the left-most visible DIP to its left alignment edge.
        /// </summary>
        private readonly float left;

        /// <summary>
        /// The distance from the top-most visible DIP to its top alignment edge.
        /// </summary>
        private readonly float top;

        /// <summary>
        /// The distance from the right-most visible DIP to its right alignment edge.
        /// </summary>
        private readonly float right;

        /// <summary>
        /// The distance from the bottom-most visible DIP to its bottom alignment edge.
        /// </summary>
        private readonly float bottom;

        /// <summary>
        /// Gets the distance from the left-most visible DIP to its left alignment edge.
        /// </summary>
        public float Left
        {
            get { return this.left; }
        }

        /// <summary>
        /// Gets the distance from the top-most visible DIP to its top alignment edge.
        /// </summary>
        public float Top
        {
            get { return this.top; }
        }

        /// <summary>
        /// Gets the distance from the right-most visible DIP to its right alignment edge.
        /// </summary>
        public float Right
        {
            get { return this.right; }
        }

        /// <summary>
        /// Gets the distance from the bottom-most visible DIP to its bottom alignment edge.
        /// </summary>
        public float Bottom
        {
            get { return this.bottom; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteOverhangMetrics"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteOverhangMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteOverhangMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteOverhangMetrics left, DWriteOverhangMetrics right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteOverhangMetrics"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteOverhangMetrics"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteOverhangMetrics"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteOverhangMetrics left, DWriteOverhangMetrics right)
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
            if (obj is not DWriteOverhangMetrics)
            {
                return false;
            }

            return this.Equals((DWriteOverhangMetrics)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteOverhangMetrics other)
        {
            return this.left == other.left
                && this.top == other.top
                && this.right == other.right
                && this.bottom == other.bottom;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.left,
                this.top,
                this.right,
                this.bottom
            }
            .GetHashCode();
        }
    }
}
