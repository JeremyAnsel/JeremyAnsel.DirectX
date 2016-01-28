// <copyright file="D2D1BitmapBrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the extend modes and the interpolation mode of an <see cref="D2D1BitmapBrush"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1BitmapBrushProperties : IEquatable<D2D1BitmapBrushProperties>
    {
        /// <summary>
        /// A value that describes how the brush horizontally tiles those areas that extend past its bitmap.
        /// </summary>
        private D2D1ExtendMode extendModeX;

        /// <summary>
        /// A value that describes how the brush vertically tiles those areas that extend past its bitmap.
        /// </summary>
        private D2D1ExtendMode extendModeY;

        /// <summary>
        /// A value that specifies how the bitmap is interpolated when it is scaled or rotated.
        /// </summary>
        private D2D1BitmapInterpolationMode interpolationMode;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BitmapBrushProperties"/> struct.
        /// </summary>
        /// <param name="extendModeX">A value that describes how the brush horizontally tiles those areas that extend past its bitmap.</param>
        /// <param name="extendModeY">A value that describes how the brush vertically tiles those areas that extend past its bitmap.</param>
        /// <param name="interpolationMode">A value that specifies how the bitmap is interpolated when it is scaled or rotated.</param>
        public D2D1BitmapBrushProperties(D2D1ExtendMode extendModeX, D2D1ExtendMode extendModeY, D2D1BitmapInterpolationMode interpolationMode)
        {
            this.extendModeX = extendModeX;
            this.extendModeY = extendModeY;
            this.interpolationMode = interpolationMode;
        }

        /// <summary>
        /// Gets default properties (Clamp, Clamp, Linear).
        /// </summary>
        public static D2D1BitmapBrushProperties Default
        {
            get { return new D2D1BitmapBrushProperties(D2D1ExtendMode.Clamp, D2D1ExtendMode.Clamp, D2D1BitmapInterpolationMode.Linear); }
        }

        /// <summary>
        /// Gets or sets a value that describes how the brush horizontally tiles those areas that extend past its bitmap.
        /// </summary>
        public D2D1ExtendMode ExtendModeX
        {
            get { return this.extendModeX; }
            set { this.extendModeX = value; }
        }

        /// <summary>
        /// Gets or sets a value that describes how the brush vertically tiles those areas that extend past its bitmap.
        /// </summary>
        public D2D1ExtendMode ExtendModeY
        {
            get { return this.extendModeY; }
            set { this.extendModeY = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies how the bitmap is interpolated when it is scaled or rotated.
        /// </summary>
        public D2D1BitmapInterpolationMode InterpolationMode
        {
            get { return this.interpolationMode; }
            set { this.interpolationMode = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1BitmapBrushProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BitmapBrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BitmapBrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1BitmapBrushProperties left, D2D1BitmapBrushProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1BitmapBrushProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BitmapBrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BitmapBrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1BitmapBrushProperties left, D2D1BitmapBrushProperties right)
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
            if (!(obj is D2D1BitmapBrushProperties))
            {
                return false;
            }

            return this.Equals((D2D1BitmapBrushProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1BitmapBrushProperties other)
        {
            return this.extendModeX == other.extendModeX
                && this.extendModeY == other.extendModeY
                && this.interpolationMode == other.interpolationMode;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.extendModeX,
                this.extendModeY,
                this.interpolationMode
            }
            .GetHashCode();
        }
    }
}
