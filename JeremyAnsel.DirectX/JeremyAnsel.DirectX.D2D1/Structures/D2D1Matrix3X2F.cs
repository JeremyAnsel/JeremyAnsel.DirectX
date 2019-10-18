// <copyright file="D2D1Matrix3X2F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Represents a 3-by-2 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct D2D1Matrix3X2F : IEquatable<D2D1Matrix3X2F>
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
        /// Initializes a new instance of the <see cref="D2D1Matrix3X2F"/> struct.
        /// </summary>
        /// <param name="m11">The value in the first row and first column of the matrix.</param>
        /// <param name="m12">The value in the first row and second column of the matrix.</param>
        /// <param name="m21">The value in the second row and first column of the matrix.</param>
        /// <param name="m22">The value in the second row and second column of the matrix.</param>
        /// <param name="m31">The value in the third row and first column of the matrix.</param>
        /// <param name="m32">The value in the third row and second column of the matrix.</param>
        public D2D1Matrix3X2F(float m11, float m12, float m21, float m22, float m31, float m32)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m21 = m21;
            this.m22 = m22;
            this.m31 = m31;
            this.m32 = m32;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Matrix3X2F"/> struct.
        /// </summary>
        /// <param name="values">The values of the matrix.</param>
        public D2D1Matrix3X2F(float[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            if (values.Length != 6)
            {
                throw new ArgumentOutOfRangeException(nameof(values));
            }

            this.m11 = values[0];
            this.m12 = values[1];
            this.m21 = values[2];
            this.m22 = values[3];
            this.m31 = values[4];
            this.m32 = values[5];
        }

        /// <summary>
        /// Gets an identity matrix.
        /// </summary>
        public static D2D1Matrix3X2F Identity
        {
            get
            {
                D2D1Matrix3X2F identity;

                identity.m11 = 1.0f;
                identity.m12 = 0.0f;
                identity.m21 = 0.0f;
                identity.m22 = 1.0f;
                identity.m31 = 0.0f;
                identity.m32 = 0.0f;

                return identity;
            }
        }

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
        /// Gets the determinant of the matrix.
        /// </summary>
        public float Determinant
        {
            get { return (this.m11 * this.m22) - (this.m12 * this.m21); }
        }

        /// <summary>
        /// Gets a value indicating whether the matrix is invertible.
        /// </summary>
        public bool IsInvertible
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return NativeMethods.D2D1IsMatrixInvertible(ref this); }
        }

        /// <summary>
        /// Gets a value indicating whether the matrix is the identity matrix.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                return this.m11 == 1.0f
                    && this.m12 == 0.0f
                    && this.m21 == 0.0f
                    && this.m22 == 1.0f
                    && this.m31 == 0.0f
                    && this.m32 == 0.0f;
            }
        }

        /// <summary>
        /// Multiplies this matrix with the specified matrix and returns the result.
        /// </summary>
        /// <param name="left">The left matrix.</param>
        /// <param name="right">The right matrix.</param>
        /// <returns>The result matrix</returns>
        public static D2D1Matrix3X2F operator *(D2D1Matrix3X2F left, D2D1Matrix3X2F right)
        {
            return D2D1Matrix3X2F.Multiply(left, right);
        }

        /// <summary>
        /// Uses this matrix to transform the specified point and returns the result.
        /// </summary>
        /// <param name="point">The point to transform.</param>
        /// <param name="matrix">The transform matrix.</param>
        /// <returns>The result point.</returns>
        public static D2D1Point2F operator *(D2D1Point2F point, D2D1Matrix3X2F matrix)
        {
            return matrix.TranformPoint(point);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Matrix3X2F"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Matrix3X2F"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Matrix3X2F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        public static bool operator ==(D2D1Matrix3X2F left, D2D1Matrix3X2F right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="D2D1Matrix3X2F"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="D2D1Matrix3X2F"/> to compare.</param>
        /// <param name="right">The right <see cref="D2D1Matrix3X2F"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        public static bool operator !=(D2D1Matrix3X2F left, D2D1Matrix3X2F right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Creates a translation transformation that has the specified x and y displacements.
        /// </summary>
        /// <param name="size">The distance to translate along the x-axis and the y-axis.</param>
        /// <returns>A transformation matrix that translates an object the specified horizontal and vertical distance.</returns>
        public static D2D1Matrix3X2F Translation(D2D1SizeF size)
        {
            D2D1Matrix3X2F translation;

            translation.m11 = 1.0f;
            translation.m12 = 0.0f;
            translation.m21 = 0.0f;
            translation.m22 = 1.0f;
            translation.m31 = size.Width;
            translation.m32 = size.Height;

            return translation;
        }

        /// <summary>
        /// Creates a translation transformation that has the specified x and y displacements.
        /// </summary>
        /// <param name="x">The distance to translate along the x-axis.</param>
        /// <param name="y">The distance to translate along the y-axis.</param>
        /// <returns>A transformation matrix that translates an object the specified horizontal and vertical distance.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        public static D2D1Matrix3X2F Translation(float x, float y)
        {
            D2D1Matrix3X2F translation;

            translation.m11 = 1.0f;
            translation.m12 = 0.0f;
            translation.m21 = 0.0f;
            translation.m22 = 1.0f;
            translation.m31 = x;
            translation.m32 = y;

            return translation;
        }

        /// <summary>
        /// Creates a scale transformation that has the specified scale factors.
        /// </summary>
        /// <param name="size">The x-axis and y-axis scale factors of the scale transformation.</param>
        /// <returns>The new scale transformation.</returns>
        public static D2D1Matrix3X2F Scale(D2D1SizeF size)
        {
            D2D1Matrix3X2F scale;

            scale.m11 = size.Width;
            scale.m12 = 0.0f;
            scale.m21 = 0.0f;
            scale.m22 = size.Height;
            scale.m31 = 0.0f;
            scale.m32 = 0.0f;

            return scale;
        }

        /// <summary>
        /// Creates a scale transformation that has the specified scale factors and center point.
        /// </summary>
        /// <param name="size">The x-axis and y-axis scale factors of the scale transformation.</param>
        /// <param name="center">The point about which the scale is performed.</param>
        /// <returns>The new scale transformation.</returns>
        public static D2D1Matrix3X2F Scale(D2D1SizeF size, D2D1Point2F center)
        {
            D2D1Matrix3X2F scale;

            scale.m11 = size.Width;
            scale.m12 = 0.0f;
            scale.m21 = 0.0f;
            scale.m22 = size.Height;
            scale.m31 = center.X - (size.Width * center.X);
            scale.m32 = center.Y - (size.Height * center.Y);

            return scale;
        }

        /// <summary>
        /// Creates a scale transformation that has the specified scale factors.
        /// </summary>
        /// <param name="x">The x-axis scale factor of the scale transformation.</param>
        /// <param name="y">The y-axis scale factor of the scale transformation.</param>
        /// <returns>The new scale transformation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        public static D2D1Matrix3X2F Scale(float x, float y)
        {
            D2D1Matrix3X2F scale;

            scale.m11 = x;
            scale.m12 = 0.0f;
            scale.m21 = 0.0f;
            scale.m22 = y;
            scale.m31 = 0.0f;
            scale.m32 = 0.0f;

            return scale;
        }

        /// <summary>
        /// Creates a scale transformation that has the specified scale factors and center point.
        /// </summary>
        /// <param name="x">The x-axis scale factor of the scale transformation.</param>
        /// <param name="y">The y-axis scale factor of the scale transformation.</param>
        /// <param name="center">The point about which the scale is performed.</param>
        /// <returns>The new scale transformation.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        public static D2D1Matrix3X2F Scale(float x, float y, D2D1Point2F center)
        {
            D2D1Matrix3X2F scale;

            scale.m11 = x;
            scale.m12 = 0.0f;
            scale.m21 = 0.0f;
            scale.m22 = y;
            scale.m31 = center.X - (x * center.X);
            scale.m32 = center.Y - (y * center.Y);

            return scale;
        }

        /// <summary>
        /// Creates a rotation transformation that has the specified angle.
        /// </summary>
        /// <param name="angle">The rotation angle in degrees. A positive angle creates a clockwise rotation, and a negative angle creates a counterclockwise rotation.</param>
        /// <returns>The new rotation transformation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Matrix3X2F Rotation(float angle)
        {
            D2D1Matrix3X2F matrix;
            NativeMethods.D2D1MakeRotateMatrix(angle, new D2D1Point2F(), out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a rotation transformation that has the specified angle and center point.
        /// </summary>
        /// <param name="angle">The rotation angle in degrees. A positive angle creates a clockwise rotation, and a negative angle creates a counterclockwise rotation.</param>
        /// <param name="center">The point about which the rotation is performed.</param>
        /// <returns>The new rotation transformation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Matrix3X2F Rotation(float angle, D2D1Point2F center)
        {
            D2D1Matrix3X2F matrix;
            NativeMethods.D2D1MakeRotateMatrix(angle, center, out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a skew transformation that has the specified x-axis and y-axis values.
        /// </summary>
        /// <param name="angleX">The x-axis skew angle, which is measured in degrees counterclockwise from the y-axis.</param>
        /// <param name="angleY">The y-axis skew angle, which is measured in degrees clockwise from the x-axis.</param>
        /// <returns>The new skew transformation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Matrix3X2F Skew(float angleX, float angleY)
        {
            D2D1Matrix3X2F matrix;
            NativeMethods.D2D1MakeSkewMatrix(angleX, angleY, new D2D1Point2F(), out matrix);
            return matrix;
        }

        /// <summary>
        /// Creates a skew transformation that has the specified x-axis and y-axis values and center point.
        /// </summary>
        /// <param name="angleX">The x-axis skew angle, which is measured in degrees counterclockwise from the y-axis.</param>
        /// <param name="angleY">The y-axis skew angle, which is measured in degrees clockwise from the x-axis.</param>
        /// <param name="center">The point about which the skew is performed.</param>
        /// <returns>The new skew transformation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Matrix3X2F Skew(float angleX, float angleY, D2D1Point2F center)
        {
            D2D1Matrix3X2F matrix;
            NativeMethods.D2D1MakeSkewMatrix(angleX, angleY, center, out matrix);
            return matrix;
        }

        /// <summary>
        /// Multiplies the two matrices and stores the result in this matrix.
        /// </summary>
        /// <param name="a">The first matrix to multiply.</param>
        /// <param name="b">The second matrix to multiply.</param>
        /// <returns>The result matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "a", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "b", Justification = "Reviewed")]
        public static D2D1Matrix3X2F Multiply(D2D1Matrix3X2F a, D2D1Matrix3X2F b)
        {
            D2D1Matrix3X2F result;

            result.m11 = (a.m11 * b.m11) + (a.m12 * b.m21);
            result.m12 = (a.m11 * b.m12) + (a.m12 * b.m22);
            result.m21 = (a.m21 * b.m11) + (a.m22 * b.m21);
            result.m22 = (a.m21 * b.m12) + (a.m22 * b.m22);
            result.m31 = (a.m31 * b.m11) + (a.m32 * b.m21) + b.m31;
            result.m32 = (a.m31 * b.m12) + (a.m32 * b.m22) + b.m32;

            return result;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is D2D1Matrix3X2F))
            {
                return false;
            }

            return this.Equals((D2D1Matrix3X2F)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public bool Equals(D2D1Matrix3X2F other)
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

        /// <summary>
        /// Inverts the matrix, if it is invertible.
        /// </summary>
        /// <returns><value>true</value> if the matrix was inverted; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Invert()
        {
            return NativeMethods.D2D1InvertMatrix(ref this);
        }

        /// <summary>
        /// Uses this matrix to transform the specified point and returns the result.
        /// </summary>
        /// <param name="point">The point to transform.</param>
        /// <returns>The result point.</returns>
        public D2D1Point2F TranformPoint(D2D1Point2F point)
        {
            return new D2D1Point2F(
                (point.X * this.m11) + (point.Y * this.m21) + this.m31,
                (point.X * this.m12) + (point.Y * this.m22) + this.m32);
        }
    }
}
