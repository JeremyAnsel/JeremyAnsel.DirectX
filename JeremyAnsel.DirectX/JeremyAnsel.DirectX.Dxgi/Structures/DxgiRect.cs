// <copyright file="DxgiRect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the coordinates of the upper-left and lower-right corners of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiRect : IEquatable<DxgiRect>
    {
        /// <summary>
        /// The x-coordinate of the upper-left corner of a rectangle.
        /// </summary>
        private int left;

        /// <summary>
        /// The y-coordinate of the upper-left corner of a rectangle.
        /// </summary>
        private int top;

        /// <summary>
        /// The x-coordinate of the lower-right corner of a rectangle.
        /// </summary>
        private int right;

        /// <summary>
        /// The y-coordinate of the lower-right corner of a rectangle.
        /// </summary>
        private int bottom;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiRect"/> struct.
        /// </summary>
        /// <param name="left">The x-coordinate of the upper-left corner of a rectangle.</param>
        /// <param name="top">The y-coordinate of the upper-left corner of a rectangle.</param>
        /// <param name="right">The x-coordinate of the lower-right corner of a rectangle.</param>
        /// <param name="bottom">The y-coordinate of the lower-right corner of a rectangle.</param>
        public DxgiRect(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of a rectangle.
        /// </summary>
        public int Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of a rectangle.
        /// </summary>
        public int Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the lower-right corner of a rectangle.
        /// </summary>
        public int Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the lower-right corner of a rectangle.
        /// </summary>
        public int Bottom
        {
            get { return this.bottom; }
            set { this.bottom = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiRect"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiRect"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiRect"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiRect left, DxgiRect right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiRect"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiRect"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiRect"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiRect left, DxgiRect right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0};{1};{2};{3}",
                this.left,
                this.top,
                this.right,
                this.bottom);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiRect))
            {
                return false;
            }

            return this.Equals((DxgiRect)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiRect other)
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
