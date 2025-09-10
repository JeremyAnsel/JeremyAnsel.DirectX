// <copyright file="DxgiPoint.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the x- and y- coordinates of a point.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiPoint : IEquatable<DxgiPoint>
    {
        /// <summary>
        /// The x-coordinate of the point.
        /// </summary>
        private int x;

        /// <summary>
        /// The y-coordinate of the point.
        /// </summary>
        private int y;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiPoint"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the point.</param>
        /// <param name="y">The y-coordinate of the point.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        public DxgiPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the point.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the point.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiPoint"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiPoint"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiPoint"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiPoint left, DxgiPoint right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiPoint"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiPoint"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiPoint"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiPoint left, DxgiPoint right)
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
                this.x,
                this.y);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DxgiPoint)
            {
                return false;
            }

            return this.Equals((DxgiPoint)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiPoint other)
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
