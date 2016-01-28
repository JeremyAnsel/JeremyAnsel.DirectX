// <copyright file="D2D1QuadraticBezierSegment.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the control point and end point for a quadratic Bezier segment.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1QuadraticBezierSegment : IEquatable<D2D1QuadraticBezierSegment>
    {
        /// <summary>
        /// The control point of the quadratic Bezier segment.
        /// </summary>
        private D2D1Point2F point1;

        /// <summary>
        /// The end point of the quadratic Bezier segment.
        /// </summary>
        private D2D1Point2F point2;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1QuadraticBezierSegment"/> struct.
        /// </summary>
        /// <param name="point1">The control point of the quadratic Bezier segment.</param>
        /// <param name="point2">The end point of the quadratic Bezier segment.</param>
        public D2D1QuadraticBezierSegment(D2D1Point2F point1, D2D1Point2F point2)
        {
            this.point1 = point1;
            this.point2 = point2;
        }

        /// <summary>
        /// Gets or sets the control point of the quadratic Bezier segment.
        /// </summary>
        public D2D1Point2F Point1
        {
            get { return this.point1; }
            set { this.point1 = value; }
        }

        /// <summary>
        /// Gets or sets the end point of the quadratic Bezier segment.
        /// </summary>
        public D2D1Point2F Point2
        {
            get { return this.point2; }
            set { this.point2 = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1QuadraticBezierSegment"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1QuadraticBezierSegment"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1QuadraticBezierSegment"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1QuadraticBezierSegment left, D2D1QuadraticBezierSegment right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1QuadraticBezierSegment"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1QuadraticBezierSegment"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1QuadraticBezierSegment"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1QuadraticBezierSegment left, D2D1QuadraticBezierSegment right)
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
            if (!(obj is D2D1QuadraticBezierSegment))
            {
                return false;
            }

            return this.Equals((D2D1QuadraticBezierSegment)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1QuadraticBezierSegment other)
        {
            return this.point1 == other.point1
                && this.point2 == other.point2;
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
                this.point2
            }
            .GetHashCode();
        }
    }
}
