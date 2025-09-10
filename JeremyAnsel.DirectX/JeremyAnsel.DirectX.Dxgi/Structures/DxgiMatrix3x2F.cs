// <copyright file="DxgiMatrix3x2F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a 3x2 matrix.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "x", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Sequential)]
    public struct DxgiMatrix3x2F : IEquatable<DxgiMatrix3x2F>
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
        /// The value in the second row and first column of the matrix.
        /// </summary>
        private float m21;

        /// <summary>
        /// The value in the second row and second column of the matrix.
        /// </summary>
        private float m22;

        /// <summary>
        /// The value in the third row and first column of the matrix.
        /// </summary>
        private float m31;

        /// <summary>
        /// The value in the third row and second column of the matrix.
        /// </summary>
        private float m32;

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
        /// Compares two <see cref="DxgiMatrix3x2F"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiMatrix3x2F"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiMatrix3x2F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(DxgiMatrix3x2F left, DxgiMatrix3x2F right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="DxgiMatrix3x2F"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="DxgiMatrix3x2F"/> to compare.</param>
        /// <param name="right">The right <see cref="DxgiMatrix3x2F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(DxgiMatrix3x2F left, DxgiMatrix3x2F right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0};{1};{2};{3};{4};{5}",
                this.m11,
                this.m12,
                this.m21,
                this.m22,
                this.m31,
                this.m32);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (obj is not DxgiMatrix3x2F)
            {
                return false;
            }

            return this.Equals((DxgiMatrix3x2F)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(DxgiMatrix3x2F other)
        {
            return this.m11 == other.m11
                && this.m12 == other.m12
                && this.m21 == other.m21
                && this.m22 == other.m22
                && this.m31 == other.m31
                && this.m32 == other.m32;
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
                this.m31,
                this.m32
            }
            .GetHashCode();
        }
    }
}
