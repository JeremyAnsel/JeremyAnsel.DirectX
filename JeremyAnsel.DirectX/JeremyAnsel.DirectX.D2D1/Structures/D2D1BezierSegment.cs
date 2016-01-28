// <copyright file="D2D1BezierSegment.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a cubic bezier segment drawn between two points.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1BezierSegment : IEquatable<D2D1BezierSegment>
    {
        /// <summary>
        /// The first control point for the Bezier segment.
        /// </summary>
        private D2D1Point2F point1;

        /// <summary>
        /// The second control point for the Bezier segment.
        /// </summary>
        private D2D1Point2F point2;

        /// <summary>
        /// The end point for the Bezier segment.
        /// </summary>
        private D2D1Point2F point3;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BezierSegment"/> struct.
        /// </summary>
        /// <param name="point1">The first control point for the Bezier segment.</param>
        /// <param name="point2">The second control point for the Bezier segment.</param>
        /// <param name="point3">The end point for the Bezier segment.</param>
        public D2D1BezierSegment(D2D1Point2F point1, D2D1Point2F point2, D2D1Point2F point3)
        {
            this.point1 = point1;
            this.point2 = point2;
            this.point3 = point3;
        }

        /// <summary>
        /// Gets or sets the first control point for the Bezier segment.
        /// </summary>
        public D2D1Point2F Point1
        {
            get { return this.point1; }
            set { this.point1 = value; }
        }

        /// <summary>
        /// Gets or sets the second control point for the Bezier segment.
        /// </summary>
        public D2D1Point2F Point2
        {
            get { return this.point2; }
            set { this.point2 = value; }
        }

        /// <summary>
        /// Gets or sets the end point for the Bezier segment.
        /// </summary>
        public D2D1Point2F Point3
        {
            get { return this.point3; }
            set { this.point3 = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1BezierSegment"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BezierSegment"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BezierSegment"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1BezierSegment left, D2D1BezierSegment right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1BezierSegment"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1BezierSegment"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1BezierSegment"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1BezierSegment left, D2D1BezierSegment right)
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
            if (!(obj is D2D1BezierSegment))
            {
                return false;
            }

            return this.Equals((D2D1BezierSegment)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1BezierSegment other)
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
