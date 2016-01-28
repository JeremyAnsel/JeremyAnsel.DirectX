// <copyright file="D2D1RadialGradientBrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the gradient origin offset and the size and position of the gradient ellipse for an <see cref="D2D1RadialGradientBrush"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1RadialGradientBrushProperties : IEquatable<D2D1RadialGradientBrushProperties>
    {
        /// <summary>
        /// The center of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        private D2D1Point2F center;

        /// <summary>
        /// The offset of the gradient origin relative to the gradient ellipse's center, in the brush's coordinate space.
        /// </summary>
        private D2D1Point2F gradientOriginOffset;

        /// <summary>
        /// The x-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        private float radiusX;

        /// <summary>
        /// The y-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        private float radiusY;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RadialGradientBrushProperties"/> struct.
        /// </summary>
        /// <param name="center">The center of the gradient ellipse, in the brush's coordinate space.</param>
        /// <param name="gradientOriginOffset">The offset of the gradient origin relative to the gradient ellipse's center, in the brush's coordinate space.</param>
        /// <param name="radiusX">The x-radius of the gradient ellipse, in the brush's coordinate space.</param>
        /// <param name="radiusY">The y-radius of the gradient ellipse, in the brush's coordinate space.</param>
        public D2D1RadialGradientBrushProperties(D2D1Point2F center, D2D1Point2F gradientOriginOffset, float radiusX, float radiusY)
        {
            this.center = center;
            this.gradientOriginOffset = gradientOriginOffset;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        /// <summary>
        /// Gets or sets the center of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F Center
        {
            get { return this.center; }
            set { this.center = value; }
        }

        /// <summary>
        /// Gets or sets the offset of the gradient origin relative to the gradient ellipse's center, in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F GradientOriginOffset
        {
            get { return this.gradientOriginOffset; }
            set { this.gradientOriginOffset = value; }
        }

        /// <summary>
        /// Gets or sets the x-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        public float RadiusX
        {
            get { return this.radiusX; }
            set { this.radiusX = value; }
        }

        /// <summary>
        /// Gets or sets the y-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        public float RadiusY
        {
            get { return this.radiusY; }
            set { this.radiusY = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1RadialGradientBrushProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RadialGradientBrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RadialGradientBrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1RadialGradientBrushProperties left, D2D1RadialGradientBrushProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1RadialGradientBrushProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RadialGradientBrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RadialGradientBrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1RadialGradientBrushProperties left, D2D1RadialGradientBrushProperties right)
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
            if (!(obj is D2D1RadialGradientBrushProperties))
            {
                return false;
            }

            return this.Equals((D2D1RadialGradientBrushProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1RadialGradientBrushProperties other)
        {
            return this.center == other.center
                && this.gradientOriginOffset == other.gradientOriginOffset
                && this.radiusX == other.radiusX
                && this.radiusY == other.radiusY;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.center,
                this.gradientOriginOffset,
                this.radiusX,
                this.radiusY
            }
            .GetHashCode();
        }
    }
}
