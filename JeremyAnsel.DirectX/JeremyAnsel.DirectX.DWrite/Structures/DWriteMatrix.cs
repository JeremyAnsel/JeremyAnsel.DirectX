// <copyright file="DWriteMatrix.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// The DWRITE_MATRIX structure specifies the graphics transform to be applied
    /// to rendered glyphs.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DWriteMatrix : IEquatable<DWriteMatrix>
    {
        /// <summary>
        /// Horizontal scaling / cosine of rotation
        /// </summary>
        private float m11;

        /// <summary>
        /// Vertical shear / sine of rotation
        /// </summary>
        private float m12;

        /// <summary>
        /// Horizontal shear / negative sine of rotation
        /// </summary>
        private float m21;

        /// <summary>
        /// Vertical scaling / cosine of rotation
        /// </summary>
        private float m22;

        /// <summary>
        /// Horizontal shift (always orthogonal regardless of rotation)
        /// </summary>
        private float dx;

        /// <summary>
        /// Vertical shift (always orthogonal regardless of rotation)
        /// </summary>
        private float dy;

        /// <summary>
        /// Gets or sets the horizontal scaling / cosine of rotation
        /// </summary>
        public float M11
        {
            get { return this.m11; }
            set { this.m11 = value; }
        }

        /// <summary>
        /// Gets or sets the vertical shear / sine of rotation
        /// </summary>
        public float M12
        {
            get { return this.m12; }
            set { this.m12 = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal shear / negative sine of rotation
        /// </summary>
        public float M21
        {
            get { return this.m21; }
            set { this.m21 = value; }
        }

        /// <summary>
        /// Gets or sets the vertical scaling / cosine of rotation
        /// </summary>
        public float M22
        {
            get { return this.m22; }
            set { this.m22 = value; }
        }

        /// <summary>
        /// Gets or sets the horizontal shift (always orthogonal regardless of rotation)
        /// </summary>
        public float DX
        {
            get { return this.dx; }
            set { this.dx = value; }
        }

        /// <summary>
        /// Gets or sets the vertical shift (always orthogonal regardless of rotation)
        /// </summary>
        public float DY
        {
            get { return this.dy; }
            set { this.dy = value; }
        }

        /// <summary>
        /// Compares two <see cref="DWriteMatrix"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteMatrix"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteMatrix"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DWriteMatrix left, DWriteMatrix right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DWriteMatrix"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DWriteMatrix"/> to compare.</param>
        /// <param name="right">The right <see cref="DWriteMatrix"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DWriteMatrix left, DWriteMatrix right)
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
            if (!(obj is DWriteMatrix))
            {
                return false;
            }

            return this.Equals((DWriteMatrix)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DWriteMatrix other)
        {
            return this.m11 == other.m11
                && this.m12 == other.m12
                && this.m21 == other.m21
                && this.m22 == other.m22
                && this.dx == other.dx
                && this.dy == other.dy;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.m11,
                this.m12,
                this.m21,
                this.m22,
                this.dx,
                this.dy
            }
            .GetHashCode();
        }
    }
}
