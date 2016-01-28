﻿// <copyright file="D2D1RectF.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a rectangle defined by the coordinates of the upper-left corner (left, top) and the coordinates of the lower-right corner (right, bottom).
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1RectF : IEquatable<D2D1RectF>
    {
        /// <summary>
        /// The x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        private float left;

        /// <summary>
        /// The y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        private float top;

        /// <summary>
        /// The x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        private float right;

        /// <summary>
        /// The y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        private float bottom;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RectF"/> struct.
        /// </summary>
        /// <param name="left">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="top">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="right">The x-coordinate of the lower-right corner of the rectangle.</param>
        /// <param name="bottom">The y-coordinate of the lower-right corner of the rectangle.</param>
        public D2D1RectF(float left, float top, float right, float bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        /// <summary>
        /// Gets an infinite rectangle.
        /// </summary>
        public static D2D1RectF Infinite
        {
            get { return new D2D1RectF(float.MinValue, float.MinValue, float.MaxValue, float.MaxValue); }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public float Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public float Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public float Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the lower-right corner of the rectangle.
        /// </summary>
        public float Bottom
        {
            get { return this.bottom; }
            set { this.bottom = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1RectF"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RectF"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RectF"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1RectF left, D2D1RectF right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1RectF"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RectF"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Vector4F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1RectF left, D2D1RectF right)
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
            if (!(obj is D2D1RectF))
            {
                return false;
            }

            return this.Equals((D2D1RectF)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1RectF other)
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
