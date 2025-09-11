// <copyright file="D2D1ArcSegment.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes an elliptical arc between two points.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1ArcSegment : IEquatable<D2D1ArcSegment>
    {
        /// <summary>
        /// The end point of the arc.
        /// </summary>
        private D2D1Point2F point;

        /// <summary>
        /// The x-radius and y-radius of the arc.
        /// </summary>
        private D2D1SizeF size;

        /// <summary>
        /// A value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.
        /// </summary>
        private float rotationAngle;

        /// <summary>
        /// A value that specifies whether the arc sweep is clockwise or counterclockwise.
        /// </summary>
        private D2D1SweepDirection sweepDirection;

        /// <summary>
        /// A value that specifies whether the given arc is larger than 180 degrees.
        /// </summary>
        private D2D1ArcSize arcSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1ArcSegment"/> struct.
        /// </summary>
        /// <param name="point">The end point of the arc.</param>
        /// <param name="size">The x-radius and y-radius of the arc.</param>
        /// <param name="rotationAngle">A value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.</param>
        /// <param name="sweepDirection">A value that specifies whether the arc sweep is clockwise or counterclockwise.</param>
        /// <param name="arcSize">A value that specifies whether the given arc is larger than 180 degrees.</param>
        public D2D1ArcSegment(D2D1Point2F point, D2D1SizeF size, float rotationAngle, D2D1SweepDirection sweepDirection, D2D1ArcSize arcSize)
        {
            this.point = point;
            this.size = size;
            this.rotationAngle = rotationAngle;
            this.sweepDirection = sweepDirection;
            this.arcSize = arcSize;
        }

        /// <summary>
        /// Gets or sets the end point of the arc.
        /// </summary>
        public D2D1Point2F Point
        {
            get { return this.point; }
            set { this.point = value; }
        }

        /// <summary>
        /// Gets or sets the x-radius and y-radius of the arc.
        /// </summary>
        public D2D1SizeF Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies how many degrees in the clockwise direction the ellipse is rotated relative to the current coordinate system.
        /// </summary>
        public float RotationAngle
        {
            get { return this.rotationAngle; }
            set { this.rotationAngle = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the arc sweep is clockwise or counterclockwise.
        /// </summary>
        public D2D1SweepDirection SweepDirection
        {
            get { return this.sweepDirection; }
            set { this.sweepDirection = value; }
        }

        /// <summary>
        /// Gets or sets a value that specifies whether the given arc is larger than 180 degrees.
        /// </summary>
        public D2D1ArcSize ArcSize
        {
            get { return this.arcSize; }
            set { this.arcSize = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1ArcSegment"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1ArcSegment"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1ArcSegment"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1ArcSegment left, D2D1ArcSegment right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1ArcSegment"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1ArcSegment"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1ArcSegment"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1ArcSegment left, D2D1ArcSegment right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not D2D1ArcSegment)
            {
                return false;
            }

            return this.Equals((D2D1ArcSegment)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1ArcSegment other)
        {
            return this.point == other.point
                && this.size == other.size
                && this.rotationAngle == other.rotationAngle
                && this.sweepDirection == other.sweepDirection
                && this.arcSize == other.arcSize;
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
                this.size,
                this.rotationAngle,
                this.sweepDirection,
                this.arcSize
            }
            .GetHashCode();
        }
    }
}
