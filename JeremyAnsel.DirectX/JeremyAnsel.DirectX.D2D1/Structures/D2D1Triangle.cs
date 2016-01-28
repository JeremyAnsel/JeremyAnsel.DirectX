// <copyright file="D2D1Triangle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the three vertices that describe a triangle.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1Triangle : IEquatable<D2D1Triangle>
    {
        /// <summary>
        /// The first vertex of a triangle.
        /// </summary>
        private D2D1Point2F point1;

        /// <summary>
        /// The second vertex of a triangle.
        /// </summary>
        private D2D1Point2F point2;

        /// <summary>
        /// The third vertex of a triangle.
        /// </summary>
        private D2D1Point2F point3;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Triangle"/> struct.
        /// </summary>
        /// <param name="point1">The first vertex of a triangle.</param>
        /// <param name="point2">The second vertex of a triangle.</param>
        /// <param name="point3">The third vertex of a triangle.</param>
        public D2D1Triangle(D2D1Point2F point1, D2D1Point2F point2, D2D1Point2F point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        /// <summary>
        /// Gets or sets the first vertex of a triangle.
        /// </summary>
        public D2D1Point2F Point1
        {
            get { return this.point1; }
            set { this.point1 = value; }
        }

        /// <summary>
        /// Gets or sets the second vertex of a triangle.
        /// </summary>
        public D2D1Point2F Point2
        {
            get { return this.point2; }
            set { this.point2 = value; }
        }

        /// <summary>
        /// Gets or sets the third vertex of a triangle.
        /// </summary>
        public D2D1Point2F Point3
        {
            get { return this.point3; }
            set { this.point3 = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1Triangle"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Triangle"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Triangle"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1Triangle left, D2D1Triangle right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Triangle"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Triangle"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Triangle"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1Triangle left, D2D1Triangle right)
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
            if (!(obj is D2D1Triangle))
            {
                return false;
            }

            return this.Equals((D2D1Triangle)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1Triangle other)
        {
            return this.point1 == other.point1
                && this.point2 == other.point2
                && this.point3 == other.point3;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.point1,
                this.point2,
                this.point3
            }
            .GetHashCode();
        }
    }
}
