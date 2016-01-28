// <copyright file="D2D1Matrix5X4F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a 5-by-4 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1Matrix5X4F : IEquatable<D2D1Matrix5X4F>
    {
        /// <summary>
        /// The value in the first row and first column of the matrix.
        /// </summary>
        private float m11;

        /// <summary>
        /// The value in the first row and second column of the matrix.
        /// </summary>
        private float m12;

        /// <summary>
        /// The value in the first row and third column of the matrix.
        /// </summary>
        private float m13;

        /// <summary>
        /// The value in the first row and fourth column of the matrix.
        /// </summary>
        private float m14;

        /// <summary>
        /// The value in the second row and first column of the matrix.
        /// </summary>
        private float m21;

        /// <summary>
        /// The value in the second row and second column of the matrix.
        /// </summary>
        private float m22;

        /// <summary>
        /// The value in the second row and third column of the matrix.
        /// </summary>
        private float m23;

        /// <summary>
        /// The value in the second row and fourth column of the matrix.
        /// </summary>
        private float m24;

        /// <summary>
        /// The value in the third row and first column of the matrix.
        /// </summary>
        private float m31;

        /// <summary>
        /// The value in the third row and second column of the matrix.
        /// </summary>
        private float m32;

        /// <summary>
        /// The value in the third row and third column of the matrix.
        /// </summary>
        private float m33;

        /// <summary>
        /// The value in the third row and fourth column of the matrix.
        /// </summary>
        private float m34;

        /// <summary>
        /// The value in the fourth row and first column of the matrix.
        /// </summary>
        private float m41;

        /// <summary>
        /// The value in the fourth row and second column of the matrix.
        /// </summary>
        private float m42;

        /// <summary>
        /// The value in the fourth row and third column of the matrix.
        /// </summary>
        private float m43;

        /// <summary>
        /// The value in the fourth row and fourth column of the matrix.
        /// </summary>
        private float m44;

        /// <summary>
        /// The value in the fifth row and first column of the matrix.
        /// </summary>
        private float m51;

        /// <summary>
        /// The value in the fifth row and second column of the matrix.
        /// </summary>
        private float m52;

        /// <summary>
        /// The value in the fifth row and third column of the matrix.
        /// </summary>
        private float m53;

        /// <summary>
        /// The value in the fifth row and fourth column of the matrix.
        /// </summary>
        private float m54;

        /// <summary>
        /// Gets or sets the value in the first row and first column of the matrix.
        /// </summary>
        public float M11
        {
            get { return this.m11; }
            set { this.m11 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the first row and second column of the matrix.
        /// </summary>
        public float M12
        {
            get { return this.m12; }
            set { this.m12 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the first row and third column of the matrix.
        /// </summary>
        public float M13
        {
            get { return this.m13; }
            set { this.m13 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the first row and fourth column of the matrix.
        /// </summary>
        public float M14
        {
            get { return this.m14; }
            set { this.m14 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and first column of the matrix.
        /// </summary>
        public float M21
        {
            get { return this.m21; }
            set { this.m21 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and second column of the matrix.
        /// </summary>
        public float M22
        {
            get { return this.m22; }
            set { this.m22 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and third column of the matrix.
        /// </summary>
        public float M23
        {
            get { return this.m23; }
            set { this.m23 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and fourth column of the matrix.
        /// </summary>
        public float M24
        {
            get { return this.m24; }
            set { this.m24 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and first column of the matrix.
        /// </summary>
        public float M31
        {
            get { return this.m31; }
            set { this.m31 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and second column of the matrix.
        /// </summary>
        public float M32
        {
            get { return this.m32; }
            set { this.m32 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and third column of the matrix.
        /// </summary>
        public float M33
        {
            get { return this.m33; }
            set { this.m33 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and fourth column of the matrix.
        /// </summary>
        public float M34
        {
            get { return this.m34; }
            set { this.m34 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and first column of the matrix.
        /// </summary>
        public float M41
        {
            get { return this.m41; }
            set { this.m41 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and second column of the matrix.
        /// </summary>
        public float M42
        {
            get { return this.m42; }
            set { this.m42 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and third column of the matrix.
        /// </summary>
        public float M43
        {
            get { return this.m43; }
            set { this.m43 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and fourth column of the matrix.
        /// </summary>
        public float M44
        {
            get { return this.m44; }
            set { this.m44 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fifth row and first column of the matrix.
        /// </summary>
        public float M51
        {
            get { return this.m51; }
            set { this.m51 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fifth row and second column of the matrix.
        /// </summary>
        public float M52
        {
            get { return this.m52; }
            set { this.m52 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fifth row and third column of the matrix.
        /// </summary>
        public float M53
        {
            get { return this.m53; }
            set { this.m53 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fifth row and fourth column of the matrix.
        /// </summary>
        public float M54
        {
            get { return this.m54; }
            set { this.m54 = value; }
        }

        /// <summary>
        /// Compares two <see cref="D2D1Matrix5X4F"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Matrix5X4F"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Matrix5X4F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1Matrix5X4F left, D2D1Matrix5X4F right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Matrix5X4F"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Matrix5X4F"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Matrix5X4F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1Matrix5X4F left, D2D1Matrix5X4F right)
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
            if (!(obj is D2D1Matrix5X4F))
            {
                return false;
            }

            return this.Equals((D2D1Matrix5X4F)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1Matrix5X4F other)
        {
            return this.m11 == other.m11
                && this.m12 == other.m12
                && this.m13 == other.m13
                && this.m14 == other.m14
                && this.m21 == other.m21
                && this.m22 == other.m22
                && this.m23 == other.m23
                && this.m24 == other.m24
                && this.m31 == other.m31
                && this.m32 == other.m32
                && this.m33 == other.m33
                && this.m34 == other.m34
                && this.m41 == other.m41
                && this.m42 == other.m42
                && this.m43 == other.m43
                && this.m44 == other.m44
                && this.m51 == other.m51
                && this.m52 == other.m52
                && this.m53 == other.m53
                && this.m54 == other.m54;
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
                this.m13,
                this.m14,
                this.m21,
                this.m22,
                this.m23,
                this.m24,
                this.m31,
                this.m32,
                this.m33,
                this.m34,
                this.m41,
                this.m42,
                this.m43,
                this.m44,
                this.m51,
                this.m52,
                this.m53,
                this.m54
            }
            .GetHashCode();
        }
    }
}
