// <copyright file="D3D11Box.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines a 3D box.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D3D11Box : IEquatable<D3D11Box>
    {
        /// <summary>
        /// The x position of the left hand side of the box.
        /// </summary>
        private uint left;

        /// <summary>
        /// The y position of the top of the box.
        /// </summary>
        private uint top;

        /// <summary>
        /// The z position of the front of the box.
        /// </summary>
        private uint front;

        /// <summary>
        /// The x position of the right hand side of the box.
        /// </summary>
        private uint right;

        /// <summary>
        /// The y position of the bottom of the box.
        /// </summary>
        private uint bottom;

        /// <summary>
        /// The z position of the back of the box.
        /// </summary>
        private uint back;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Box"/> struct.
        /// </summary>
        /// <param name="left">The x position of the left hand side of the box.</param>
        /// <param name="top">The y position of the top of the box.</param>
        /// <param name="front">The z position of the front of the box.</param>
        /// <param name="right">The x position of the right hand side of the box.</param>
        /// <param name="bottom">The y position of the bottom of the box.</param>
        /// <param name="back">The z position of the back of the box.</param>
        public D3D11Box(uint left, uint top, uint front, uint right, uint bottom, uint back)
        {
            this.left = left;
            this.top = top;
            this.front = front;
            this.right = right;
            this.bottom = bottom;
            this.back = back;
        }

        /// <summary>
        /// Gets or sets the x position of the left hand side of the box.
        /// </summary>
        public uint Left
        {
            get { return this.left; }
            set { this.left = value; }
        }

        /// <summary>
        /// Gets or sets the y position of the top of the box.
        /// </summary>
        public uint Top
        {
            get { return this.top; }
            set { this.top = value; }
        }

        /// <summary>
        /// Gets or sets the z position of the front of the box.
        /// </summary>
        public uint Front
        {
            get { return this.front; }
            set { this.front = value; }
        }

        /// <summary>
        /// Gets or sets the x position of the right hand side of the box.
        /// </summary>
        public uint Right
        {
            get { return this.right; }
            set { this.right = value; }
        }

        /// <summary>
        /// Gets or sets the y position of the bottom of the box.
        /// </summary>
        public uint Bottom
        {
            get { return this.bottom; }
            set { this.bottom = value; }
        }

        /// <summary>
        /// Gets or sets the z position of the back of the box.
        /// </summary>
        public uint Back
        {
            get { return this.back; }
            set { this.back = value; }
        }

        /// <summary>
        /// Compares two <see cref="D3D11Box"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Box"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Box"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D3D11Box left, D3D11Box right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D3D11Box"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D3D11Box"/> to compare.</param>
        /// <param name="right">The right <see cref="D3D11Box"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D3D11Box left, D3D11Box right)
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
            if (obj is not D3D11Box)
            {
                return false;
            }

            return this.Equals((D3D11Box)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D3D11Box other)
        {
            return this.left == other.left
                && this.top == other.top
                && this.front == other.front
                && this.right == other.right
                && this.bottom == other.bottom
                && this.back == other.back;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.left,
                this.top,
                this.front,
                this.right,
                this.bottom,
                this.back
            }
            .GetHashCode();
        }
    }
}
