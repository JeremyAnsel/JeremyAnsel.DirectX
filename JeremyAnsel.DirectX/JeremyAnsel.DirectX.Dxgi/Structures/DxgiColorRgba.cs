// <copyright file="DxgiColorRgba.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The structure represents a color value with alpha, which is used for transparency.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiColorRgba : IEquatable<DxgiColorRgba>
    {
        /// <summary>
        /// A value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
        /// </summary>
        private float red;

        /// <summary>
        /// A value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
        /// </summary>
        private float green;

        /// <summary>
        /// A value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
        /// </summary>
        private float blue;

        /// <summary>
        /// A value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
        /// </summary>
        private float alpha;

        /// <summary>
        /// Gets or sets a value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
        /// </summary>
        public float Red
        {
            get { return this.red; }
            set { this.red = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
        /// </summary>
        public float Green
        {
            get { return this.green; }
            set { this.green = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
        /// </summary>
        public float Blue
        {
            get { return this.blue; }
            set { this.blue = value; }
        }

        /// <summary>
        /// Gets or sets value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
        /// </summary>
        public float Alpha
        {
            get { return this.alpha; }
            set { this.alpha = value; }
        }

        /// <summary>
        /// Compares two <see cref="DxgiColorRgba"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiColorRgba"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiColorRgba"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiColorRgba left, DxgiColorRgba right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiColorRgba"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiColorRgba"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiColorRgba"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiColorRgba left, DxgiColorRgba right)
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
                this.red,
                this.green,
                this.blue,
                this.alpha);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DxgiColorRgba))
            {
                return false;
            }

            return this.Equals((DxgiColorRgba)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiColorRgba other)
        {
            return this.red == other.red
                && this.green == other.green
                && this.blue == other.blue
                && this.alpha == other.alpha;
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
                this.blue,
                this.alpha
            }
            .GetHashCode();
        }
    }
}
