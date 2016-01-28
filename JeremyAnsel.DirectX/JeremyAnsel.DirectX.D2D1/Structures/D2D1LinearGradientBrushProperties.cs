// <copyright file="D2D1LinearGradientBrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the starting point and endpoint of the gradient axis for an <see cref="D2D1LinearGradientBrush"/>.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1LinearGradientBrushProperties : IEquatable<D2D1LinearGradientBrushProperties>
    {
        /// <summary>
        /// In the brush's coordinate space, the starting point of the gradient axis.
        /// </summary>
        private D2D1Point2F startPoint;

        /// <summary>
        /// In the brush's coordinate space, the endpoint of the gradient axis.
        /// </summary>
        private D2D1Point2F endPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1LinearGradientBrushProperties"/> struct.
        /// </summary>
        /// <param name="startPoint">The starting point of the gradient axis, in the brush's coordinate space.</param>
        /// <param name="endPoint">The endpoint of the gradient axis, in the brush's coordinate space.</param>
        public D2D1LinearGradientBrushProperties(D2D1Point2F startPoint, D2D1Point2F endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        /// <summary>
        /// Gets or sets the starting point of the gradient axis, in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F StartPoint
        {
            get { return this.startPoint; }
            set { this.startPoint = value; }
        }

        /// <summary>
        /// Gets or sets the endpoint of the gradient axis, in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F EndPoint
        {
            get { return this.endPoint; }
            set { this.endPoint = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1LinearGradientBrushProperties"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1LinearGradientBrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1LinearGradientBrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1LinearGradientBrushProperties left, D2D1LinearGradientBrushProperties right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1LinearGradientBrushProperties"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1LinearGradientBrushProperties"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1LinearGradientBrushProperties"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1LinearGradientBrushProperties left, D2D1LinearGradientBrushProperties right)
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
            if (!(obj is D2D1LinearGradientBrushProperties))
            {
                return false;
            }

            return this.Equals((D2D1LinearGradientBrushProperties)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1LinearGradientBrushProperties other)
        {
            return this.startPoint == other.startPoint
                && this.endPoint == other.endPoint;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.startPoint,
                this.endPoint
            }
            .GetHashCode();
        }
    }
}
