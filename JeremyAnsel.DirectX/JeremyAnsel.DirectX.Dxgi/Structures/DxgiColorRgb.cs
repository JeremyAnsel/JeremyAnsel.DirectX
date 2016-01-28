// <copyright file="DxgiColorRgb.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents an RGB color.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiColorRgb : IEquatable<DxgiColorRgb>
    {
        /// <summary>
        /// A value representing the color of the red component. The range of this value is between 0 and 1.
        /// </summary>
        private float red;

        /// <summary>
        /// A value representing the color of the green component. The range of this value is between 0 and 1.
        /// </summary>
        private float green;

        /// <summary>
        /// A value representing the color of the blue component. The range of this value is between 0 and 1.
        /// </summary>
        private float blue;

        /// <summary>
        /// Gets or sets a value representing the color of the red component. The range of this value is between 0 and 1.
        /// </summary>
        public float Red
        {
            get { return this.red; }
            set { this.red = value; }
        }

        /// <summary>
        /// Gets or sets a value representing the color of the green component. The range of this value is between 0 and 1.
        /// </summary>
        public float Green
        {
            get { return this.green; }
            set { this.green = value; }
        }

        /// <summary>
        /// Gets or sets a value representing the color of the blue component. The range of this value is between 0 and 1.
        /// </summary>
        public float Blue
        {
            get { return this.blue; }
            set { this.blue = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiColorRgb"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiColorRgb"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiColorRgb"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiColorRgb left, DxgiColorRgb right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiColorRgb"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiColorRgb"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiColorRgb"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiColorRgb left, DxgiColorRgb right)
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
                "{0};{1};{2}",
                this.red,
                this.green,
                this.blue);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiColorRgb))
            {
                return false;
            }

            return this.Equals((DxgiColorRgb)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiColorRgb other)
        {
            return this.red == other.red
                && this.green == other.green
                && this.blue == other.blue;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.red,
                this.green,
                this.blue
            }
            .GetHashCode();
        }
    }
}
