// <copyright file="D2D1Point2U.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents an x-coordinate and y-coordinate pair in two-dimensional space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1Point2U : IEquatable<D2D1Point2U>
    {
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        private uint x;

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        private uint y;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Point2U"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        public D2D1Point2U(uint x, uint y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the point.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public uint X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the point.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public uint Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1Point2U"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Point2U"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Point2U"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1Point2U left, D2D1Point2U right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Point2U"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Point2U"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Point2U"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1Point2U left, D2D1Point2U right)
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
            if (!(obj is D2D1Point2U))
            {
                return false;
            }

            return this.Equals((D2D1Point2U)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1Point2U other)
        {
            return this.x == other.x
                && this.y == other.y;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.x,
                this.y
            }
            .GetHashCode();
        }
    }
}
