// <copyright file="D2D1Ellipse.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the center point, x-radius, and y-radius of an ellipse.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1Ellipse : IEquatable<D2D1Ellipse>
    {
        /// <summary>
        /// The center point of the ellipse.
        /// </summary>
        private D2D1Point2F point;

        /// <summary>
        /// The X-radius of the ellipse.
        /// </summary>
        private float radiusX;

        /// <summary>
        /// The Y-radius of the ellipse.
        /// </summary>
        private float radiusY;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Ellipse"/> struct.
        /// </summary>
        /// <param name="point">The center point of the ellipse.</param>
        /// <param name="radiusX">The X-radius of the ellipse.</param>
        /// <param name="radiusY">The Y-radius of the ellipse.</param>
        public D2D1Ellipse(D2D1Point2F point, float radiusX, float radiusY)
        {
            this.point = point;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        /// <summary>
        /// Gets or sets the center point of the ellipse.
        /// </summary>
        public D2D1Point2F Point
        {
            get { return this.point; }
            set { this.point = value; }
        }

        /// <summary>
        /// Gets or sets the X-radius of the ellipse.
        /// </summary>
        public float RadiusX
        {
            get { return this.radiusX; }
            set { this.radiusX = value; }
        }

        /// <summary>
        /// Gets or sets the Y-radius of the ellipse.
        /// </summary>
        public float RadiusY
        {
            get { return this.radiusY; }
            set { this.radiusY = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1Ellipse"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Ellipse"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Ellipse"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1Ellipse left, D2D1Ellipse right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Ellipse"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Ellipse"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Ellipse"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1Ellipse left, D2D1Ellipse right)
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
            if (!(obj is D2D1Ellipse))
            {
                return false;
            }

            return this.Equals((D2D1Ellipse)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1Ellipse other)
        {
            return this.point == other.point
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
                this.point,
                this.radiusX,
                this.radiusY
            }
            .GetHashCode();
        }
    }
}
