// <copyright file="D2D1BitmapProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the pixel format and dpi of a bitmap.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1BitmapProperties : IEquatable<D2D1BitmapProperties>
    {
        /// <summary>
        /// The bitmap's pixel format and alpha mode.
        /// </summary>
        private D2D1PixelFormat pixelFormat;

        /// <summary>
        /// The horizontal dpi of the bitmap.
        /// </summary>
        private float dpiX;

        /// <summary>
        /// The vertical dpi of the bitmap.
        /// </summary>
        private float dpiY;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BitmapProperties"/> struct.
        /// </summary>
        /// <param name="pixelFormat">The bitmap's pixel format and alpha mode.</param>
        /// <param name="dpiX">The horizontal dpi of the bitmap.</param>
        /// <param name="dpiY">The vertical dpi of the bitmap.</param>
        public D2D1BitmapProperties(D2D1PixelFormat pixelFormat, float dpiX, float dpiY)
        {
            this.pixelFormat = pixelFormat;
            this.dpiX = dpiX;
            this.dpiY = dpiY;
        }

        /// <summary>
        /// Gets default properties (Default, 96, 96).
        /// </summary>
        public static D2D1BitmapProperties Default
        {
            get { return new D2D1BitmapProperties(D2D1PixelFormat.Default, 96.0f, 96.0f); }
        }

        /// <summary>
        /// Gets or sets the bitmap's pixel format and alpha mode.
        /// </summary>
        public D2D1PixelFormat PixelFormat
        {
            get { return this.pixelFormat; }
            set { this.pixelFormat = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal dpi of the bitmap.
        /// </summary>
        public float DpiX
        {
            get { return this.dpiX; }
            set { this.dpiX = value; }
        }

        /// <summary>
        /// Gets or sets the vertical dpi of the bitmap.
        /// </summary>
        public float DpiY
        {
            get { return this.dpiY; }
            set { this.dpiY = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1BitmapProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BitmapProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BitmapProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1BitmapProperties left, D2D1BitmapProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1BitmapProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BitmapProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BitmapProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1BitmapProperties left, D2D1BitmapProperties right)
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
            if (!(obj is D2D1BitmapProperties))
            {
                return false;
            }

            return this.Equals((D2D1BitmapProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1BitmapProperties other)
        {
            return this.pixelFormat == other.pixelFormat
                && this.dpiX == other.dpiX
                && this.dpiY == other.dpiY;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.pixelFormat,
                this.dpiX,
                this.dpiY
            }
            .GetHashCode();
        }
    }
}
