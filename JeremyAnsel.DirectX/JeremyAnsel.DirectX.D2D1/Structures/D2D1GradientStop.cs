// <copyright file="D2D1GradientStop.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains the position and color of a gradient stop.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1GradientStop : IEquatable<D2D1GradientStop>
    {
        /// <summary>
        /// A value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.
        /// </summary>
        private float position;

        /// <summary>
        /// The color of the gradient stop.
        /// </summary>
        private D2D1ColorF color;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1GradientStop"/> struct.
        /// </summary>
        /// <param name="position">A value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.</param>
        /// <param name="color">The color of the gradient stop.</param>
        public D2D1GradientStop(float position, D2D1ColorF color)
        {
            this.position = position;
            this.color = color;
        }

        /// <summary>
        /// Gets or sets a value that indicates the relative position of the gradient stop in the brush. This value must be in the [0.0f, 1.0f] range if the gradient stop is to be seen explicitly.
        /// </summary>
        public float Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        /// <summary>
        /// Gets or sets the color of the gradient stop.
        /// </summary>
        public D2D1ColorF Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1GradientStop"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1GradientStop"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1GradientStop"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1GradientStop left, D2D1GradientStop right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1GradientStop"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1GradientStop"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1GradientStop"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1GradientStop left, D2D1GradientStop right)
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
            if (!(obj is D2D1GradientStop))
            {
                return false;
            }

            return this.Equals((D2D1GradientStop)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1GradientStop other)
        {
            return this.position == other.position
                && this.color == other.color;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.position,
                this.color
            }
            .GetHashCode();
        }
    }
}
