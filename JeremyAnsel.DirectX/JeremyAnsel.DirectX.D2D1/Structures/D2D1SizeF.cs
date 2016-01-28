// <copyright file="D2D1SizeF.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Stores an ordered pair of floats, typically the width and height of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1SizeF : IEquatable<D2D1SizeF>
    {
        /// <summary>
        /// The horizontal component of this size.
        /// </summary>
        private float width;

        /// <summary>
        /// The vertical component of this size.
        /// </summary>
        private float height;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1SizeF"/> struct.
        /// </summary>
        /// <param name="width">The horizontal component of this size.</param>
        /// <param name="height">The vertical component of this size.</param>
        public D2D1SizeF(float width, float height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets or sets the horizontal component of this size.
        /// </summary>
        public float Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the vertical component of this size.
        /// </summary>
        public float Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1SizeF"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1SizeF"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1SizeF"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1SizeF left, D2D1SizeF right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1SizeF"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1SizeF"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1SizeF"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1SizeF left, D2D1SizeF right)
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
            if (!(obj is D2D1SizeF))
            {
                return false;
            }

            return this.Equals((D2D1SizeF)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1SizeF other)
        {
            return this.width == other.width
                && this.height == other.height;
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
                this.height
            }
            .GetHashCode();
        }
    }
}
