// <copyright file="D2D1Vector4F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A vector of 4 FLOAT values (x, y, z, w).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1Vector4F : IEquatable<D2D1Vector4F>
    {
        /// <summary>
        /// The x value of the vector.
        /// </summary>
        private float x;

        /// <summary>
        /// The y value of the vector.
        /// </summary>
        private float y;

        /// <summary>
        /// The z value of the vector.
        /// </summary>
        private float z;

        /// <summary>
        /// The w value of the vector.
        /// </summary>
        private float w;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Vector4F"/> struct.
        /// </summary>
        /// <param name="x">The x value of the vector.</param>
        /// <param name="y">The y value of the vector.</param>
        /// <param name="z">The z value of the vector.</param>
        /// <param name="w">The w value of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        public D2D1Vector4F(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Gets or sets the x value of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y value of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets the z value of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public float Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets the w value of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public float W
        {
            get { return this.w; }
            set { this.w = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1Vector4F"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Vector4F"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Vector4F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1Vector4F left, D2D1Vector4F right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Vector4F"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Vector4F"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Vector4F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1Vector4F left, D2D1Vector4F right)
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
            if (!(obj is D2D1Vector4F))
            {
                return false;
            }

            return this.Equals((D2D1Vector4F)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1Vector4F other)
        {
            return this.x == other.x
                && this.y == other.y
                && this.z == other.z
                & this.w == other.w;
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
                this.y,
                this.z,
                this.w
            }
            .GetHashCode();
        }
    }
}
