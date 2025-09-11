// <copyright file="DWriteSize.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Specifies the width and height of a rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteSize : IEquatable<DWriteSize>
    {
        /// <summary>
        /// Specifies the rectangle's width.
        /// </summary>
        private int width;

        /// <summary>
        /// Specifies the rectangle's height.
        /// </summary>
        private int height;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteSize"/> struct.
        /// </summary>
        /// <param name="width">The rectangle's width.</param>
        /// <param name="height">The rectangle's height.</param>
        public DWriteSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets or sets the rectangle's width.
        /// </summary>
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets the rectangle's height.
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteSize"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteSize"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteSize"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteSize left, DWriteSize right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteSize"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteSize"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteSize"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteSize left, DWriteSize right)
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
                "{0};{1}",
                this.width,
                this.height);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DWriteSize)
            {
                return false;
            }

            return this.Equals((DWriteSize)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteSize other)
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
