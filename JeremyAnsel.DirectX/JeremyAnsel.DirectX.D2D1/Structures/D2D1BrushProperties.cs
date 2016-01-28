// <copyright file="D2D1BrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes the opacity and transformation of a brush.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1BrushProperties : IEquatable<D2D1BrushProperties>
    {
        /// <summary>
        /// A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.
        /// </summary>
        private float opacity;

        /// <summary>
        /// The transformation that is applied to the brush.
        /// </summary>
        private D2D1Matrix3X2F transform;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BrushProperties"/> struct.
        /// </summary>
        /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.</param>
        public D2D1BrushProperties(float opacity)
        {
            this.opacity = opacity;
            this.transform = D2D1Matrix3X2F.Identity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BrushProperties"/> struct.
        /// </summary>
        /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.</param>
        /// <param name="transform">The transformation that is applied to the brush.</param>
        public D2D1BrushProperties(float opacity, D2D1Matrix3X2F transform)
        {
            this.opacity = opacity;
            this.transform = transform;
        }

        /// <summary>
        /// Gets default properties (1.0f, Identity).
        /// </summary>
        public static D2D1BrushProperties Default
        {
            get { return new D2D1BrushProperties(1.0f, D2D1Matrix3X2F.Identity); }
        }

        /// <summary>
        /// Gets or sets a value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.
        /// </summary>
        public float Opacity
        {
            get { return this.opacity; }
            set { this.opacity = value; }
        }

        /// <summary>
        /// Gets or sets the transformation that is applied to the brush.
        /// </summary>
        public D2D1Matrix3X2F Transform
        {
            get { return this.transform; }
            set { this.transform = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1BrushProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1BrushProperties left, D2D1BrushProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1BrushProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1BrushProperties left, D2D1BrushProperties right)
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
            if (!(obj is D2D1BrushProperties))
            {
                return false;
            }

            return this.Equals((D2D1BrushProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1BrushProperties other)
        {
            return this.opacity == other.opacity
                && this.transform == other.transform;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.opacity,
                this.transform
            }
            .GetHashCode();
        }
    }
}
