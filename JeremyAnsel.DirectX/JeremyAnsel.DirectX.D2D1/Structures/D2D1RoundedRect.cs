// <copyright file="D2D1RoundedRect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the dimensions and corner radii of a rounded rectangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1RoundedRect : IEquatable<D2D1RoundedRect>
    {
        /// <summary>
        /// The coordinates of the rectangle.
        /// </summary>
        private D2D1RectF rect;

        /// <summary>
        /// The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
        /// </summary>
        private float radiusX;

        /// <summary>
        /// The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
        /// </summary>
        private float radiusY;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RoundedRect"/> struct.
        /// </summary>
        /// <param name="rect">The coordinates of the rectangle.</param>
        /// <param name="radiusX">The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</param>
        /// <param name="radiusY">The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</param>
        public D2D1RoundedRect(D2D1RectF rect, float radiusX, float radiusY)
        {
            this.rect = rect;
            this.radiusX = radiusX;
            this.radiusY = radiusY;
        }

        /// <summary>
        /// Gets or sets the coordinates of the rectangle.
        /// </summary>
        public D2D1RectF Rect
        {
            get { return this.rect; }
            set { this.rect = value; }
        }

        /// <summary>
        /// Gets or sets the x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
        /// </summary>
        public float RadiusX
        {
            get { return this.radiusX; }
            set { this.radiusX = value; }
        }

        /// <summary>
        /// Gets or sets the y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
        /// </summary>
        public float RadiusY
        {
            get { return this.radiusY; }
            set { this.radiusY = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1RoundedRect"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RoundedRect"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RoundedRect"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1RoundedRect left, D2D1RoundedRect right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1RoundedRect"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1RoundedRect"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1RoundedRect"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1RoundedRect left, D2D1RoundedRect right)
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
            if (!(obj is D2D1RoundedRect))
            {
                return false;
            }

            return this.Equals((D2D1RoundedRect)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1RoundedRect other)
        {
            return this.rect == other.rect
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
                this.rect,
                this.radiusX,
                this.radiusY
            }
            .GetHashCode();
        }
    }
}
