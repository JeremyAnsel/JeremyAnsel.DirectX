// <copyright file="XMMatrix.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Describes a 4*4 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMMatrix : IEquatable<XMMatrix>
    {
        /// <summary>
        /// The decompose epsilon.
        /// </summary>
        private const float DecomposeEpsilon = 0.0001f;

        /// <summary>
        /// The value in the first row and first column.
        /// </summary>
        private float m11;

        /// <summary>
        /// The value in the first row and second column.
        /// </summary>
        private float m12;

        /// <summary>
        /// The value in the first row and third column.
        /// </summary>
        private float m13;

        /// <summary>
        /// The value in the first row and fourth column.
        /// </summary>
        private float m14;

        /// <summary>
        /// The value in the second row and first column.
        /// </summary>
        private float m21;

        /// <summary>
        /// The value in the second row and second column.
        /// </summary>
        private float m22;

        /// <summary>
        /// The value in the second row and third column.
        /// </summary>
        private float m23;

        /// <summary>
        /// The value in the second row and fourth column.
        /// </summary>
        private float m24;

        /// <summary>
        /// The value in the third row and first column.
        /// </summary>
        private float m31;

        /// <summary>
        /// The value in the third row and second column.
        /// </summary>
        private float m32;

        /// <summary>
        /// The value in the third row and third column.
        /// </summary>
        private float m33;

        /// <summary>
        /// The value in the third row and fourth column.
        /// </summary>
        private float m34;

        /// <summary>
        /// The value in the fourth row and first column.
        /// </summary>
        private float m41;

        /// <summary>
        /// The value in the fourth row and second column.
        /// </summary>
        private float m42;

        /// <summary>
        /// The value in the fourth row and third column.
        /// </summary>
        private float m43;

        /// <summary>
        /// The value in the fourth row and fourth column.
        /// </summary>
        private float m44;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMMatrix"/> struct.
        /// </summary>
        /// <param name="r1">The first row.</param>
        /// <param name="r2">The second row.</param>
        /// <param name="r3">The third row.</param>
        /// <param name="r4">The fourth row.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix(XMVector r1, XMVector r2, XMVector r3, XMVector r4)
        {
            this.m11 = r1.X;
            this.m12 = r1.Y;
            this.m13 = r1.Z;
            this.m14 = r1.W;
            this.m21 = r2.X;
            this.m22 = r2.Y;
            this.m23 = r2.Z;
            this.m24 = r2.W;
            this.m31 = r3.X;
            this.m32 = r3.Y;
            this.m33 = r3.Z;
            this.m34 = r3.W;
            this.m41 = r4.X;
            this.m42 = r4.Y;
            this.m43 = r4.Z;
            this.m44 = r4.W;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMMatrix"/> struct.
        /// </summary>
        /// <param name="rows">The rows.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix(XMVector[] rows)
        {
            if (rows == null)
            {
                throw new ArgumentNullException(nameof(rows));
            }

            if (rows.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(rows));
            }

            this.m11 = rows[0].X;
            this.m12 = rows[0].Y;
            this.m13 = rows[0].Z;
            this.m14 = rows[0].W;
            this.m21 = rows[1].X;
            this.m22 = rows[1].Y;
            this.m23 = rows[1].Z;
            this.m24 = rows[1].W;
            this.m31 = rows[2].X;
            this.m32 = rows[2].Y;
            this.m33 = rows[2].Z;
            this.m34 = rows[2].W;
            this.m41 = rows[3].X;
            this.m42 = rows[3].Y;
            this.m43 = rows[3].Z;
            this.m44 = rows[3].W;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMMatrix"/> struct.
        /// </summary>
        /// <param name="m11">The value in the first row and first column.</param>
        /// <param name="m12">The value in the first row and second column.</param>
        /// <param name="m13">The value in the first row and third column.</param>
        /// <param name="m14">The value in the first row and fourth column.</param>
        /// <param name="m21">The value in the second row and first column.</param>
        /// <param name="m22">The value in the second row and second column.</param>
        /// <param name="m23">The value in the second row and third column.</param>
        /// <param name="m24">The value in the second row and fourth column.</param>
        /// <param name="m31">The value in the third row and first column.</param>
        /// <param name="m32">The value in the third row and second column.</param>
        /// <param name="m33">The value in the third row and third column.</param>
        /// <param name="m34">The value in the third row and fourth column.</param>
        /// <param name="m41">The value in the fourth row and first column.</param>
        /// <param name="m42">The value in the fourth row and second column.</param>
        /// <param name="m43">The value in the fourth row and third column.</param>
        /// <param name="m44">The value in the fourth row and fourth column.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix(
            float m11,
            float m12,
            float m13,
            float m14,
            float m21,
            float m22,
            float m23,
            float m24,
            float m31,
            float m32,
            float m33,
            float m34,
            float m41,
            float m42,
            float m43,
            float m44)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m14 = m14;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m24 = m24;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
            this.m34 = m34;
            this.m41 = m41;
            this.m42 = m42;
            this.m43 = m43;
            this.m44 = m44;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMMatrix"/> struct.
        /// </summary>
        /// <param name="array">The values.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix(float[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 16)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.m11 = array[0];
            this.m12 = array[1];
            this.m13 = array[2];
            this.m14 = array[3];
            this.m21 = array[4];
            this.m22 = array[5];
            this.m23 = array[6];
            this.m24 = array[7];
            this.m31 = array[8];
            this.m32 = array[9];
            this.m33 = array[10];
            this.m34 = array[11];
            this.m41 = array[12];
            this.m42 = array[13];
            this.m43 = array[14];
            this.m44 = array[15];
        }

        /// <summary>
        /// Gets the identity matrix.
        /// </summary>
        public static XMMatrix Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new XMMatrix(
                    XMGlobalConstants.IdentityR0,
                    XMGlobalConstants.IdentityR1,
                    XMGlobalConstants.IdentityR2,
                    XMGlobalConstants.IdentityR3);
            }
        }

        /// <summary>
        /// Gets or sets the value in the first row and first column.
        /// </summary>
        public float M11
        {
            get { return this.m11; }
            set { this.m11 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the first row and second column.
        /// </summary>
        public float M12
        {
            get { return this.m12; }
            set { this.m12 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the first row and third column.
        /// </summary>
        public float M13
        {
            get { return this.m13; }
            set { this.m13 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the first row and fourth column.
        /// </summary>
        public float M14
        {
            get { return this.m14; }
            set { this.m14 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and first column.
        /// </summary>
        public float M21
        {
            get { return this.m21; }
            set { this.m21 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and second column.
        /// </summary>
        public float M22
        {
            get { return this.m22; }
            set { this.m22 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and third column.
        /// </summary>
        public float M23
        {
            get { return this.m23; }
            set { this.m23 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the second row and fourth column.
        /// </summary>
        public float M24
        {
            get { return this.m24; }
            set { this.m24 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and first column.
        /// </summary>
        public float M31
        {
            get { return this.m31; }
            set { this.m31 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and second column.
        /// </summary>
        public float M32
        {
            get { return this.m32; }
            set { this.m32 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and third column.
        /// </summary>
        public float M33
        {
            get { return this.m33; }
            set { this.m33 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the third row and fourth column.
        /// </summary>
        public float M34
        {
            get { return this.m34; }
            set { this.m34 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and first column.
        /// </summary>
        public float M41
        {
            get { return this.m41; }
            set { this.m41 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and second column.
        /// </summary>
        public float M42
        {
            get { return this.m42; }
            set { this.m42 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and third column.
        /// </summary>
        public float M43
        {
            get { return this.m43; }
            set { this.m43 = value; }
        }

        /// <summary>
        /// Gets or sets the value in the fourth row and fourth column.
        /// </summary>
        public float M44
        {
            get { return this.m44; }
            set { this.m44 = value; }
        }

        /// <summary>
        /// Gets or sets a value specified by row and column.
        /// </summary>
        /// <param name="row">The row of the value.</param>
        /// <param name="column">The column of the value.</param>
        /// <returns>A float value.</returns>
        [SuppressMessage("Microsoft.Design", "CA1023:IndexersShouldNotBeMultidimensional", Justification = "Reviewed")]
        public float this[int row, int column]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (row < 0 || row >= 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }

                if (column < 0 || column >= 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(column));
                }

                fixed (XMMatrix* m = &this)
                {
                    return ((float*)m)[(row * 4) + column];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (row < 0 || row >= 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }

                if (column < 0 || column >= 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(column));
                }

                fixed (XMMatrix* m = &this)
                {
                    ((float*)m)[(row * 4) + column] = value;
                }
            }
        }

        /// <summary>
        /// Performance an identity operation on a matrix.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <returns>Returns the matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator +(XMMatrix m)
        {
            return XMMatrix.Plus(m);
        }

        /// <summary>
        /// Computes the negation of a matrix.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <returns>Returns the negation of the matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator -(XMMatrix m)
        {
            return XMMatrix.Negate(m);
        }

        /// <summary>
        /// Computes the sum of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns a matrix that is the sum of the two matrices.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator +(XMMatrix m1, XMMatrix m2)
        {
            return XMMatrix.Add(m1, m2);
        }

        /// <summary>
        /// Computes the difference of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns a matrix that is the difference of the two matrices.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator -(XMMatrix m1, XMMatrix m2)
        {
            return XMMatrix.Subtract(m1, m2);
        }

        /// <summary>
        /// Computes the product of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns the product of M1 and M2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator *(XMMatrix m1, XMMatrix m2)
        {
            return XMMatrix.Multiply(m1, m2);
        }

        /// <summary>
        /// Multiply each element of a matrix by a scalar.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <param name="s">The scalar.</param>
        /// <returns>A matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator *(XMMatrix m, float s)
        {
            return XMMatrix.Multiply(m, s);
        }

        /// <summary>
        /// Multiply each element of a matrix by a scalar.
        /// </summary>
        /// <param name="s">The scalar.</param>
        /// <param name="m">The matrix.</param>
        /// <returns>A matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator *(float s, XMMatrix m)
        {
            return XMMatrix.Multiply(m, s);
        }

        /// <summary>
        /// Divide each element of a matrix by a scalar.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <param name="s">The scalar.</param>
        /// <returns>A matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix operator /(XMMatrix m, float s)
        {
            return XMMatrix.Divide(m, s);
        }

        /// <summary>
        /// Compares two <see cref="XMMatrix"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMMatrix"/> to compare.</param>
        /// <param name="right">The right <see cref="XMMatrix"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMMatrix left, XMMatrix right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMMatrix"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMMatrix"/> to compare.</param>
        /// <param name="right">The right <see cref="XMMatrix"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMMatrix left, XMMatrix right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Convert a matrix to an array of float.
        /// </summary>
        /// <param name="value">The matrix.</param>
        /// <returns>An array of float.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator float[](XMMatrix value)
        {
            return value.ToArray();
        }

        /// <summary>
        /// Loads an <see cref="XMFloat3X3"/> into an <see cref="XMMatrix"/>.
        /// </summary>
        /// <param name="source">The structure to load.</param>
        /// <returns>A matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LoadFloat3X3(XMFloat3X3 source)
        {
            XMMatrix m;

            m.m11 = source.M11;
            m.m12 = source.M12;
            m.m13 = source.M13;
            m.m14 = 0.0f;

            m.m21 = source.M21;
            m.m22 = source.M22;
            m.m23 = source.M23;
            m.m24 = 0.0f;

            m.m31 = source.M31;
            m.m32 = source.M32;
            m.m33 = source.M33;
            m.m34 = 0.0f;

            m.m41 = 0.0f;
            m.m42 = 0.0f;
            m.m43 = 0.0f;
            m.m44 = 1.0f;

            return m;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat4X3"/> into an <see cref="XMMatrix"/>.
        /// </summary>
        /// <param name="source">The structure to load.</param>
        /// <returns>A matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LoadFloat4X3(XMFloat4X3 source)
        {
            XMMatrix m;

            m.m11 = source.M11;
            m.m12 = source.M12;
            m.m13 = source.M13;
            m.m14 = 0.0f;

            m.m21 = source.M21;
            m.m22 = source.M22;
            m.m23 = source.M23;
            m.m24 = 0.0f;

            m.m31 = source.M31;
            m.m32 = source.M32;
            m.m33 = source.M33;
            m.m34 = 0.0f;

            m.m41 = source.M41;
            m.m42 = source.M42;
            m.m43 = source.M43;
            m.m44 = 1.0f;

            return m;
        }

        /// <summary>
        /// Loads an <see cref="XMFloat4X4"/> into an <see cref="XMMatrix"/>.
        /// </summary>
        /// <param name="source">The structure to load.</param>
        /// <returns>A matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LoadFloat4X4(XMFloat4X4 source)
        {
            XMMatrix m;

            m.m11 = source.M11;
            m.m12 = source.M12;
            m.m13 = source.M13;
            m.m14 = source.M14;

            m.m21 = source.M21;
            m.m22 = source.M22;
            m.m23 = source.M23;
            m.m24 = source.M24;

            m.m31 = source.M31;
            m.m32 = source.M32;
            m.m33 = source.M33;
            m.m34 = source.M34;

            m.m41 = source.M41;
            m.m42 = source.M42;
            m.m43 = source.M43;
            m.m44 = source.M44;

            return m;
        }

        /// <summary>
        /// Computes the product of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns the product of M1 and M2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Multiply(XMMatrix m1, XMMatrix m2)
        {
            XMMatrix result;
            float x;
            float y;
            float z;
            float w;

            x = m1.m11;
            y = m1.m12;
            z = m1.m13;
            w = m1.m14;
            result.m11 = (m2.m11 * x) + (m2.m21 * y) + (m2.m31 * z) + (m2.m41 * w);
            result.m12 = (m2.m12 * x) + (m2.m22 * y) + (m2.m32 * z) + (m2.m42 * w);
            result.m13 = (m2.m13 * x) + (m2.m23 * y) + (m2.m33 * z) + (m2.m43 * w);
            result.m14 = (m2.m14 * x) + (m2.m24 * y) + (m2.m34 * z) + (m2.m44 * w);

            x = m1.m21;
            y = m1.m22;
            z = m1.m23;
            w = m1.m24;
            result.m21 = (m2.m11 * x) + (m2.m21 * y) + (m2.m31 * z) + (m2.m41 * w);
            result.m22 = (m2.m12 * x) + (m2.m22 * y) + (m2.m32 * z) + (m2.m42 * w);
            result.m23 = (m2.m13 * x) + (m2.m23 * y) + (m2.m33 * z) + (m2.m43 * w);
            result.m24 = (m2.m14 * x) + (m2.m24 * y) + (m2.m34 * z) + (m2.m44 * w);

            x = m1.m31;
            y = m1.m32;
            z = m1.m33;
            w = m1.m34;
            result.m31 = (m2.m11 * x) + (m2.m21 * y) + (m2.m31 * z) + (m2.m41 * w);
            result.m32 = (m2.m12 * x) + (m2.m22 * y) + (m2.m32 * z) + (m2.m42 * w);
            result.m33 = (m2.m13 * x) + (m2.m23 * y) + (m2.m33 * z) + (m2.m43 * w);
            result.m34 = (m2.m14 * x) + (m2.m24 * y) + (m2.m34 * z) + (m2.m44 * w);

            x = m1.m41;
            y = m1.m42;
            z = m1.m43;
            w = m1.m44;
            result.m41 = (m2.m11 * x) + (m2.m21 * y) + (m2.m31 * z) + (m2.m41 * w);
            result.m42 = (m2.m12 * x) + (m2.m22 * y) + (m2.m32 * z) + (m2.m42 * w);
            result.m43 = (m2.m13 * x) + (m2.m23 * y) + (m2.m33 * z) + (m2.m43 * w);
            result.m44 = (m2.m14 * x) + (m2.m24 * y) + (m2.m34 * z) + (m2.m44 * w);

            return result;
        }

        /// <summary>
        /// Computes the transpose of the product of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns the transpose of the product of M1 and M2.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix MultiplyTranspose(XMMatrix m1, XMMatrix m2)
        {
            XMMatrix result;
            float x;
            float y;
            float z;
            float w;

            x = m2.m11;
            y = m2.m21;
            z = m2.m31;
            w = m2.m41;
            result.m11 = (m1.m11 * x) + (m1.m12 * y) + (m1.m13 * z) + (m1.m14 * w);
            result.m12 = (m1.m21 * x) + (m1.m22 * y) + (m1.m23 * z) + (m1.m24 * w);
            result.m13 = (m1.m31 * x) + (m1.m32 * y) + (m1.m33 * z) + (m1.m34 * w);
            result.m14 = (m1.m41 * x) + (m1.m42 * y) + (m1.m43 * z) + (m1.m44 * w);

            x = m2.m12;
            y = m2.m22;
            z = m2.m32;
            w = m2.m42;
            result.m21 = (m1.m11 * x) + (m1.m12 * y) + (m1.m13 * z) + (m1.m14 * w);
            result.m22 = (m1.m21 * x) + (m1.m22 * y) + (m1.m23 * z) + (m1.m24 * w);
            result.m23 = (m1.m31 * x) + (m1.m32 * y) + (m1.m33 * z) + (m1.m34 * w);
            result.m24 = (m1.m41 * x) + (m1.m42 * y) + (m1.m43 * z) + (m1.m44 * w);

            x = m2.m13;
            y = m2.m23;
            z = m2.m33;
            w = m2.m43;
            result.m31 = (m1.m11 * x) + (m1.m12 * y) + (m1.m13 * z) + (m1.m14 * w);
            result.m32 = (m1.m21 * x) + (m1.m22 * y) + (m1.m23 * z) + (m1.m24 * w);
            result.m33 = (m1.m31 * x) + (m1.m32 * y) + (m1.m33 * z) + (m1.m34 * w);
            result.m34 = (m1.m41 * x) + (m1.m42 * y) + (m1.m43 * z) + (m1.m44 * w);

            x = m2.m14;
            y = m2.m24;
            z = m2.m34;
            w = m2.m44;
            result.m41 = (m1.m11 * x) + (m1.m12 * y) + (m1.m13 * z) + (m1.m14 * w);
            result.m42 = (m1.m21 * x) + (m1.m22 * y) + (m1.m23 * z) + (m1.m24 * w);
            result.m43 = (m1.m31 * x) + (m1.m32 * y) + (m1.m33 * z) + (m1.m34 * w);
            result.m44 = (m1.m41 * x) + (m1.m42 * y) + (m1.m43 * z) + (m1.m44 * w);

            return result;
        }

        /// <summary>
        /// Multiply each element of a matrix by a scalar.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <param name="s">The scalar.</param>
        /// <returns>A matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Multiply(XMMatrix m, float s)
        {
            XMMatrix result;
            result.m11 = m.m11 * s;
            result.m12 = m.m12 * s;
            result.m13 = m.m13 * s;
            result.m14 = m.m14 * s;
            result.m21 = m.m21 * s;
            result.m22 = m.m22 * s;
            result.m23 = m.m23 * s;
            result.m24 = m.m24 * s;
            result.m31 = m.m31 * s;
            result.m32 = m.m32 * s;
            result.m33 = m.m33 * s;
            result.m34 = m.m34 * s;
            result.m41 = m.m41 * s;
            result.m42 = m.m42 * s;
            result.m43 = m.m43 * s;
            result.m44 = m.m44 * s;
            return result;
        }

        /// <summary>
        /// Divide each element of a matrix by a scalar.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <param name="s">The scalar.</param>
        /// <returns>A matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "s", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Divide(XMMatrix m, float s)
        {
            XMMatrix result;
            result.m11 = m.m11 / s;
            result.m12 = m.m12 / s;
            result.m13 = m.m13 / s;
            result.m14 = m.m14 / s;
            result.m21 = m.m21 / s;
            result.m22 = m.m22 / s;
            result.m23 = m.m23 / s;
            result.m24 = m.m24 / s;
            result.m31 = m.m31 / s;
            result.m32 = m.m32 / s;
            result.m33 = m.m33 / s;
            result.m34 = m.m34 / s;
            result.m41 = m.m41 / s;
            result.m42 = m.m42 / s;
            result.m43 = m.m43 / s;
            result.m44 = m.m44 / s;
            return result;
        }

        /// <summary>
        /// Builds a translation matrix from the specified offsets.
        /// </summary>
        /// <param name="offsetX">Translation along the x-axis.</param>
        /// <param name="offsetY">Translation along the y-axis.</param>
        /// <param name="offsetZ">Translation along the z-axis.</param>
        /// <returns>Returns the translation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Translation(float offsetX, float offsetY, float offsetZ)
        {
            return new XMMatrix(
                1.0f,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f,
                0.0f,
                offsetX,
                offsetY,
                offsetZ,
                1.0f);
        }

        /// <summary>
        /// Builds a translation matrix from a vector.
        /// </summary>
        /// <param name="offset">3D vector describing the translations along the x-axis, y-axis, and z-axis.</param>
        /// <returns>Returns the translation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix TranslationFromVector(XMVector offset)
        {
            return new XMMatrix(
                1.0f,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f,
                0.0f,
                offset.X,
                offset.Y,
                offset.Z,
                1.0f);
        }

        /// <summary>
        /// Builds a matrix that scales along the x-axis, y-axis, and z-axis.
        /// </summary>
        /// <param name="scaleX">Scaling factor along the x-axis.</param>
        /// <param name="scaleY">Scaling factor along the y-axis.</param>
        /// <param name="scaleZ">Scaling factor along the z-axis.</param>
        /// <returns>Returns the scaling matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Scaling(float scaleX, float scaleY, float scaleZ)
        {
            return new XMMatrix(
                scaleX,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                scaleY,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                scaleZ,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f);
        }

        /// <summary>
        /// Builds a scaling matrix from a 3D vector.
        /// </summary>
        /// <param name="scale">3D vector describing the scaling along the x-axis, y-axis, and z-axis.</param>
        /// <returns>Returns the scaling matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix ScalingFromVector(XMVector scale)
        {
            return new XMMatrix(
                scale.X,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                scale.Y,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                scale.Z,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f);
        }

        /// <summary>
        /// Builds a matrix that rotates around the x-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation around the x-axis, in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationX(float angle)
        {
            XMScalar.SinCos(out float sinAngle, out float cosAngle, angle);

            return new XMMatrix(
                1.0f,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                cosAngle,
                sinAngle,
                0.0f,
                0.0f,
                -sinAngle,
                cosAngle,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f);
        }

        /// <summary>
        /// Builds a matrix that rotates around the y-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation around the y-axis, in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationY(float angle)
        {
            XMScalar.SinCos(out float sinAngle, out float cosAngle, angle);

            return new XMMatrix(
                cosAngle,
                0.0f,
                -sinAngle,
                0.0f,
                0.0f,
                1.0f,
                0.0f,
                0.0f,
                sinAngle,
                0.0f,
                cosAngle,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f);
        }

        /// <summary>
        /// Builds a matrix that rotates around the z-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation around the z-axis, in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationZ(float angle)
        {
            XMScalar.SinCos(out float sinAngle, out float cosAngle, angle);

            return new XMMatrix(
                cosAngle,
                sinAngle,
                0.0f,
                0.0f,
                -sinAngle,
                cosAngle,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                1.0f);
        }

        /// <summary>
        /// Builds a rotation matrix based on a given pitch, yaw, and roll (Euler angles).
        /// </summary>
        /// <param name="pitch">Angle of rotation around the x-axis, in radians.</param>
        /// <param name="yaw">Angle of rotation around the y-axis, in radians.</param>
        /// <param name="roll">Angle of rotation around the z-axis, in radians.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationRollPitchYaw(float pitch, float yaw, float roll)
        {
            XMVector angles = new XMVector(pitch, yaw, roll, 0.0f);
            return XMMatrix.RotationRollPitchYawFromVector(angles);
        }

        /// <summary>
        /// Builds a rotation matrix based on a vector containing the Euler angles (pitch, yaw, and roll).
        /// </summary>
        /// <param name="angles">3D vector containing the Euler angles in the order pitch, then yaw, and then roll.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationRollPitchYawFromVector(XMVector angles)
        {
            XMVector q = XMQuaternion.RotationRollPitchYawFromVector(angles);
            return XMMatrix.RotationQuaternion(q);
        }

        /// <summary>
        /// Builds a matrix that rotates around an arbitrary normal vector.
        /// </summary>
        /// <param name="normalAxis">Normal vector describing the axis of rotation.</param>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationNormal(XMVector normalAxis, float angle)
        {
            XMScalar.SinCos(out float sinAngle, out float cosAngle, angle);

            XMVector a = new XMVector(sinAngle, cosAngle, 1.0f - cosAngle, 0.0f);

            XMVector c2 = XMVector.SplatZ(a);
            XMVector c1 = XMVector.SplatY(a);
            XMVector c0 = XMVector.SplatX(a);

            XMVector n0 = new XMVector(normalAxis.Y, normalAxis.Z, normalAxis.X, normalAxis.W);
            XMVector n1 = new XMVector(normalAxis.Z, normalAxis.X, normalAxis.Y, normalAxis.W);

            XMVector v0 = XMVector.Multiply(c2, n0);
            v0 = XMVector.Multiply(v0, n1);

            XMVector r0 = XMVector.Multiply(c2, normalAxis);
            r0 = XMVector.MultiplyAdd(r0, normalAxis, c1);

            XMVector r1 = XMVector.MultiplyAdd(c0, normalAxis, v0);
            XMVector r2 = XMVector.NegativeMultiplySubtract(c0, normalAxis, v0);

            v0 = XMVector.Select(a, r0, XMGlobalConstants.Select1110);

            XMVector v1 = new XMVector(r1.Z, r2.Y, r2.Z, r1.X);
            XMVector v2 = new XMVector(r1.Y, r2.X, r1.Y, r2.X);

            return new XMMatrix(
                new XMVector(v0.X, v1.X, v1.Y, v0.W),
                new XMVector(v1.Z, v0.Y, v1.W, v0.W),
                new XMVector(v2.X, v2.Y, v0.Z, v0.W),
                XMGlobalConstants.IdentityR3);
        }

        /// <summary>
        /// Builds a matrix that rotates around an arbitrary axis.
        /// </summary>
        /// <param name="axis">Vector describing the axis of rotation.</param>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationAxis(XMVector axis, float angle)
        {
            Debug.Assert(!XMVector3.Equal(axis, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(!XMVector3.IsInfinite(axis), "Reviewed");

            XMVector normal = XMVector3.Normalize(axis);
            return XMMatrix.RotationNormal(normal, angle);
        }

        /// <summary>
        /// Builds a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="quaternion">Quaternion defining the rotation.</param>
        /// <returns>Returns the rotation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix RotationQuaternion(XMVector quaternion)
        {
            XMVector constant1110 = XMVector.FromFloat(1.0f, 1.0f, 1.0f, 0.0f);

            XMVector q0 = XMVector.Add(quaternion, quaternion);
            XMVector q1 = XMVector.Multiply(quaternion, q0);

            XMVector v0 = new XMVector(q1.Y, q1.X, q1.X, 0.0f);
            XMVector v1 = new XMVector(q1.Z, q1.Z, q1.Y, 0.0f);
            XMVector r0 = XMVector.Subtract(constant1110, v0);
            r0 = XMVector.Subtract(r0, v1);

            v0 = new XMVector(quaternion.X, quaternion.X, quaternion.Y, quaternion.W);
            v1 = new XMVector(q0.Z, q0.Y, q0.Z, q0.W);
            v0 = XMVector.Multiply(v0, v1);

            v1 = XMVector.SplatW(quaternion);
            XMVector v2 = new XMVector(q0.Y, q0.Z, q0.X, q0.W);
            v1 = XMVector.Multiply(v1, v2);

            XMVector r1 = XMVector.Add(v0, v1);
            XMVector r2 = XMVector.Subtract(v0, v1);

            v0 = new XMVector(r1.Y, r2.X, r2.Y, r1.Z);
            v1 = new XMVector(r1.X, r2.Z, r1.X, r2.Z);

            return new XMMatrix(
                new XMVector(r0.X, v0.X, v0.Y, r0.W),
                new XMVector(v0.Z, r0.Y, v0.W, r0.W),
                new XMVector(v1.X, v1.Y, r0.Z, r0.W),
                XMGlobalConstants.IdentityR3);
        }

        /// <summary>
        /// Builds a 2D transformation matrix in the xy plane.
        /// </summary>
        /// <param name="scalingOrigin">2D vector describing the center of the scaling.</param>
        /// <param name="scalingOrientation">Scaling rotation factor.</param>
        /// <param name="scaling">2D vector containing the scaling factors for the x-axis and y-axis.</param>
        /// <param name="rotationOrigin">2D vector describing the center of the rotation.</param>
        /// <param name="rotation">Angle of rotation, in radians.</param>
        /// <param name="translation">2D vector describing the translation.</param>
        /// <returns>Returns the transformation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Transformation2D(
            XMVector scalingOrigin,
            float scalingOrientation,
            XMVector scaling,
            XMVector rotationOrigin,
            float rotation,
            XMVector translation)
        {
            //// M = Inverse(MScalingOrigin) * Transpose(MScalingOrientation) * MScaling * MScalingOrientation *
            ////         MScalingOrigin * Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

            XMVector v_sScalingOrigin = XMVector.Select(XMGlobalConstants.Select1100, scalingOrigin, XMGlobalConstants.Select1100);
            XMVector negScalingOrigin = v_sScalingOrigin.Negate();

            XMMatrix m_scalingOriginI = XMMatrix.TranslationFromVector(negScalingOrigin);
            XMMatrix m_scalingOrientation = XMMatrix.RotationZ(scalingOrientation);
            XMMatrix m_scalingOrientationT = m_scalingOrientation.Transpose();
            XMVector v_scaling = XMVector.Select(XMGlobalConstants.One, scaling, XMGlobalConstants.Select1100);
            XMMatrix m_scaling = XMMatrix.ScalingFromVector(v_scaling);
            XMVector v_rotationOrigin = XMVector.Select(XMGlobalConstants.Select1100, rotationOrigin, XMGlobalConstants.Select1100);
            XMMatrix m_rotation = XMMatrix.RotationZ(rotation);
            XMVector v_translation = XMVector.Select(XMGlobalConstants.Select1100, translation, XMGlobalConstants.Select1100);

            XMMatrix m = XMMatrix.Multiply(m_scalingOriginI, m_scalingOrientationT);
            m = XMMatrix.Multiply(m, m_scaling);
            m = XMMatrix.Multiply(m, m_scalingOrientation);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_sScalingOrigin);
            ((XMVector*)&m)[3] = XMVector.Subtract(((XMVector*)&m)[3], v_rotationOrigin);
            m = XMMatrix.Multiply(m, m_rotation);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_rotationOrigin);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_translation);

            return m;
        }

        /// <summary>
        /// Builds a transformation matrix.
        /// </summary>
        /// <param name="scalingOrigin">3D vector describing the center of the scaling.</param>
        /// <param name="scalingOrientationQuaternion">Quaternion describing the orientation of the scaling.</param>
        /// <param name="scaling">3D vector containing the scaling factors for the x-axis, y-axis, and z-axis.</param>
        /// <param name="rotationOrigin">3D vector describing the center of the rotation.</param>
        /// <param name="rotationQuaternion">Quaternion describing the rotation around the origin indicated by RotationOrigin.</param>
        /// <param name="translation">3D vector describing the translations along the x-axis, y-axis, and z-axis.</param>
        /// <returns>Returns the transformation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Transformation(
            XMVector scalingOrigin,
            XMVector scalingOrientationQuaternion,
            XMVector scaling,
            XMVector rotationOrigin,
            XMVector rotationQuaternion,
            XMVector translation)
        {
            //// M = Inverse(MScalingOrigin) * Transpose(MScalingOrientation) * MScaling * MScalingOrientation *
            ////         MScalingOrigin * Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

            XMVector v_scalingOrigin = XMVector.Select(XMGlobalConstants.Select1110, scalingOrigin, XMGlobalConstants.Select1110);
            XMVector negScalingOrigin = scalingOrigin.Negate();

            XMMatrix m_scalingOriginI = XMMatrix.TranslationFromVector(negScalingOrigin);
            XMMatrix m_scalingOrientation = XMMatrix.RotationQuaternion(scalingOrientationQuaternion);
            XMMatrix m_scalingOrientationT = m_scalingOrientation.Transpose();
            XMMatrix m_scaling = XMMatrix.ScalingFromVector(scaling);
            XMVector v_rotationOrigin = XMVector.Select(XMGlobalConstants.Select1110, rotationOrigin, XMGlobalConstants.Select1110);
            XMMatrix m_rotation = XMMatrix.RotationQuaternion(rotationQuaternion);
            XMVector v_translation = XMVector.Select(XMGlobalConstants.Select1110, translation, XMGlobalConstants.Select1110);

            XMMatrix m;
            m = XMMatrix.Multiply(m_scalingOriginI, m_scalingOrientationT);
            m = XMMatrix.Multiply(m, m_scaling);
            m = XMMatrix.Multiply(m, m_scalingOrientation);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_scalingOrigin);
            ((XMVector*)&m)[3] = XMVector.Subtract(((XMVector*)&m)[3], v_rotationOrigin);
            m = XMMatrix.Multiply(m, m_rotation);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_rotationOrigin);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_translation);

            return m;
        }

        /// <summary>
        /// Builds a 2D affine transformation matrix in the xy plane.
        /// </summary>
        /// <param name="scaling">2D vector of scaling factors for the x-coordinate and y-coordinate.</param>
        /// <param name="rotationOrigin">2D vector describing the center of rotation.</param>
        /// <param name="rotation">Radian angle of rotation.</param>
        /// <param name="translation">2D vector translation offsets.</param>
        /// <returns>Returns the 2D affine transformation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix AffineTransformation2D(
            XMVector scaling,
            XMVector rotationOrigin,
            float rotation,
            XMVector translation)
        {
            //// M = MScaling * Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

            XMVector v_scaling = XMVector.Select(XMGlobalConstants.One, scaling, XMGlobalConstants.Select1100);
            XMMatrix m_scaling = XMMatrix.ScalingFromVector(v_scaling);
            XMVector v_rotationOrigin = XMVector.Select(XMGlobalConstants.Select1100, rotationOrigin, XMGlobalConstants.Select1100);
            XMMatrix m_rotation = XMMatrix.RotationZ(rotation);
            XMVector v_translation = XMVector.Select(XMGlobalConstants.Select1100, translation, XMGlobalConstants.Select1100);

            XMMatrix m;
            m = m_scaling;
            ((XMVector*)&m)[3] = XMVector.Subtract(((XMVector*)&m)[3], v_rotationOrigin);
            m = XMMatrix.Multiply(m, m_rotation);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_rotationOrigin);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_translation);

            return m;
        }

        /// <summary>
        /// Builds an affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Vector of scaling factors for each dimension.</param>
        /// <param name="rotationOrigin">Point identifying the center of rotation.</param>
        /// <param name="rotationQuaternion">Rotation factors.</param>
        /// <param name="translation">Translation offsets.</param>
        /// <returns>Returns the affine transformation matrix, built from the scaling, rotation, and translation information.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix AffineTransformation(
            XMVector scaling,
            XMVector rotationOrigin,
            XMVector rotationQuaternion,
            XMVector translation)
        {
            //// M = MScaling * Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

            XMMatrix m_scaling = XMMatrix.ScalingFromVector(scaling);
            XMVector v_rotationOrigin = XMVector.Select(XMGlobalConstants.Select1110, rotationOrigin, XMGlobalConstants.Select1110);
            XMMatrix m_rotation = XMMatrix.RotationQuaternion(rotationQuaternion);
            XMVector v_translation = XMVector.Select(XMGlobalConstants.Select1110, translation, XMGlobalConstants.Select1110);

            XMMatrix m;
            m = m_scaling;
            ((XMVector*)&m)[3] = XMVector.Subtract(((XMVector*)&m)[3], v_rotationOrigin);
            m = XMMatrix.Multiply(m, m_rotation);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_rotationOrigin);
            ((XMVector*)&m)[3] = XMVector.Add(((XMVector*)&m)[3], v_translation);

            return m;
        }

        /// <summary>
        /// Builds a transformation matrix designed to reflect vectors through a given plane.
        /// </summary>
        /// <param name="reflectionPlane">Plane to reflect through.</param>
        /// <returns>Returns the transformation matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Reflect(XMVector reflectionPlane)
        {
            Debug.Assert(!XMVector3.Equal(reflectionPlane, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(!XMVector3.IsInfinite(reflectionPlane), "Reviewed");

            XMVector negativeTwo = XMVector.FromFloat(-2.0f, -2.0f, -2.0f, 0.0f);

            XMVector p = XMPlane.Normalize(reflectionPlane);
            XMVector s = XMVector.Multiply(p, negativeTwo);

            XMVector a = XMVector.SplatX(p);
            XMVector b = XMVector.SplatY(p);
            XMVector c = XMVector.SplatZ(p);
            XMVector d = XMVector.SplatW(p);

            return new XMMatrix(
                XMVector.MultiplyAdd(a, s, XMGlobalConstants.IdentityR0),
                XMVector.MultiplyAdd(b, s, XMGlobalConstants.IdentityR1),
                XMVector.MultiplyAdd(c, s, XMGlobalConstants.IdentityR2),
                XMVector.MultiplyAdd(d, s, XMGlobalConstants.IdentityR3));
        }

        /// <summary>
        /// Builds a transformation matrix that flattens geometry into a plane.
        /// </summary>
        /// <param name="shadowPlane">Reference plane.</param>
        /// <param name="lightPosition">4D vector describing the light's position. If the light's w-component is 0.0f, the ray from the origin to the light represents a directional light. If it is 1.0f, the light is a point light.</param>
        /// <returns>Returns the transformation matrix that flattens the geometry into the plane ShadowPlane.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Shadow(XMVector shadowPlane, XMVector lightPosition)
        {
            XMVector select0001 = XMVector.FromInt((uint)XMSelection.Select0, (uint)XMSelection.Select0, (uint)XMSelection.Select0, (uint)XMSelection.Select1);

            Debug.Assert(!XMVector3.Equal(shadowPlane, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(!XMPlane.IsInfinite(shadowPlane), "Reviewed");

            XMVector p = XMPlane.Normalize(shadowPlane);
            XMVector dot = XMPlane.Dot(p, lightPosition).Negate();

            XMVector d = XMVector.SplatW(p);
            XMVector c = XMVector.SplatZ(p);
            XMVector b = XMVector.SplatY(p);
            XMVector a = XMVector.SplatX(p);

            dot = XMVector.Select(select0001, dot, select0001);

            XMMatrix m;
            ((XMVector*)&m)[3] = XMVector.MultiplyAdd(d, lightPosition, dot);
            dot = dot.RotateLeft(1);
            ((XMVector*)&m)[2] = XMVector.MultiplyAdd(c, lightPosition, dot);
            dot = dot.RotateLeft(1);
            ((XMVector*)&m)[1] = XMVector.MultiplyAdd(b, lightPosition, dot);
            dot = dot.RotateLeft(1);
            ((XMVector*)&m)[0] = XMVector.MultiplyAdd(a, lightPosition, dot);

            return m;
        }

        /// <summary>
        /// Builds a view matrix for a left-handed coordinate system using a camera position, an up direction, and a focal point.
        /// </summary>
        /// <param name="eyePosition">Position of the camera.</param>
        /// <param name="focusPosition">Position of the focal point.</param>
        /// <param name="directionUp">Up direction of the camera.</param>
        /// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LookAtLH(XMVector eyePosition, XMVector focusPosition, XMVector directionUp)
        {
            XMVector eyeDirection = XMVector.Subtract(focusPosition, eyePosition);
            return XMMatrix.LookToLH(eyePosition, eyeDirection, directionUp);
        }

        /// <summary>
        /// Builds a view matrix for a right-handed coordinate system using a camera position, an up direction, and a focal point.
        /// </summary>
        /// <param name="eyePosition">Position of the camera.</param>
        /// <param name="focusPosition">Position of the focal point.</param>
        /// <param name="directionUp">Up direction of the camera.</param>
        /// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LookAtRH(XMVector eyePosition, XMVector focusPosition, XMVector directionUp)
        {
            XMVector negEyeDirection = XMVector.Subtract(eyePosition, focusPosition);
            return XMMatrix.LookToLH(eyePosition, negEyeDirection, directionUp);
        }

        /// <summary>
        /// Builds a view matrix for a left-handed coordinate system using a camera position, an up direction, and a camera direction.
        /// </summary>
        /// <param name="eyePosition">Position of the camera.</param>
        /// <param name="eyeDirection">Direction of the camera.</param>
        /// <param name="directionUp">Up direction of the camera.</param>
        /// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LookToLH(XMVector eyePosition, XMVector eyeDirection, XMVector directionUp)
        {
            Debug.Assert(!XMVector3.Equal(eyeDirection, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(!XMVector3.IsInfinite(eyeDirection), "Reviewed");
            Debug.Assert(!XMVector3.Equal(directionUp, XMGlobalConstants.Zero), "Reviewed");
            Debug.Assert(!XMVector3.IsInfinite(directionUp), "Reviewed");

            XMVector r2 = XMVector3.Normalize(eyeDirection);

            XMVector r0 = XMVector3.Cross(directionUp, r2);
            r0 = XMVector3.Normalize(r0);

            XMVector r1 = XMVector3.Cross(r2, r0);

            XMVector negEyePosition = eyePosition.Negate();

            XMVector d0 = XMVector3.Dot(r0, negEyePosition);
            XMVector d1 = XMVector3.Dot(r1, negEyePosition);
            XMVector d2 = XMVector3.Dot(r2, negEyePosition);

            XMMatrix m = new XMMatrix(
                XMVector.Select(d0, r0, XMGlobalConstants.Select1110),
                XMVector.Select(d1, r1, XMGlobalConstants.Select1110),
                XMVector.Select(d2, r2, XMGlobalConstants.Select1110),
                XMGlobalConstants.IdentityR3);

            return m.Transpose();
        }

        /// <summary>
        /// Builds a view matrix for a right-handed coordinate system using a camera position, an up direction, and a camera direction.
        /// </summary>
        /// <param name="eyePosition">Position of the camera.</param>
        /// <param name="eyeDirection">Direction of the camera.</param>
        /// <param name="directionUp">Up direction of the camera.</param>
        /// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix LookToRH(XMVector eyePosition, XMVector eyeDirection, XMVector directionUp)
        {
            XMVector negEyeDirection = eyeDirection.Negate();
            return XMMatrix.LookToLH(eyePosition, negEyeDirection, directionUp);
        }

        /// <summary>
        /// Builds a left-handed perspective projection matrix.
        /// </summary>
        /// <param name="viewWidth">Width of the frustum at the near clipping plane.</param>
        /// <param name="viewHeight">Height of the frustum at the near clipping plane.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the perspective projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix PerspectiveLH(float viewWidth, float viewHeight, float nearZ, float farZ)
        {
            Debug.Assert(nearZ > 0.0f && farZ > 0.0f, "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewWidth, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewHeight, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float twoNearZ = nearZ + nearZ;
            float range = farZ / (farZ - nearZ);

            return new XMMatrix(
                twoNearZ / viewWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                twoNearZ / viewHeight,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                1.0f,
                0.0f,
                0.0f,
                -range * nearZ,
                0.0f);
        }

        /// <summary>
        /// Builds a right-handed perspective projection matrix.
        /// </summary>
        /// <param name="viewWidth">Width of the frustum at the near clipping plane.</param>
        /// <param name="viewHeight">Height of the frustum at the near clipping plane.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the perspective projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix PerspectiveRH(float viewWidth, float viewHeight, float nearZ, float farZ)
        {
            Debug.Assert(nearZ > 0.0f && farZ > 0.0f, "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewWidth, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewHeight, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float twoNearZ = nearZ + nearZ;
            float range = farZ / (nearZ - farZ);

            return new XMMatrix(
                twoNearZ / viewWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                twoNearZ / viewHeight,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                -1.0f,
                0.0f,
                0.0f,
                range * nearZ,
                0.0f);
        }

        /// <summary>
        /// Builds a left-handed perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fovAngleY">Top-down field-of-view angle in radians.</param>
        /// <param name="aspectHByW">Aspect ratio of view-space X:Y.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the perspective projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix PerspectiveFovLH(float fovAngleY, float aspectHByW, float nearZ, float farZ)
        {
            Debug.Assert(nearZ > 0.0f && farZ > 0.0f, "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(fovAngleY, 0.0f, 0.00001f * 2.0f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(aspectHByW, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            XMScalar.SinCos(out float sinFov, out float cosFov, 0.5f * fovAngleY);

            float height = cosFov / sinFov;
            float width = height / aspectHByW;
            float range = farZ / (farZ - nearZ);

            return new XMMatrix(
                width,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                height,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                1.0f,
                0.0f,
                0.0f,
                -range * nearZ,
                0.0f);
        }

        /// <summary>
        /// Builds a right-handed perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fovAngleY">Top-down field-of-view angle in radians.</param>
        /// <param name="aspectHByW">Aspect ratio of view-space X:Y.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the perspective projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix PerspectiveFovRH(float fovAngleY, float aspectHByW, float nearZ, float farZ)
        {
            Debug.Assert(nearZ > 0.0f && farZ > 0.0f, "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(fovAngleY, 0.0f, 0.00001f * 2.0f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(aspectHByW, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            XMScalar.SinCos(out float sinFov, out float cosFov, 0.5f * fovAngleY);

            float height = cosFov / sinFov;
            float width = height / aspectHByW;
            float range = farZ / (nearZ - farZ);

            return new XMMatrix(
                width,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                height,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                -1.0f,
                0.0f,
                0.0f,
                range * nearZ,
                0.0f);
        }

        /// <summary>
        /// Builds a custom version of a left-handed perspective projection matrix.
        /// </summary>
        /// <param name="viewLeft">The x-coordinate of the left side of the clipping frustum at the near clipping plane.</param>
        /// <param name="viewRight">The x-coordinate of the right side of the clipping frustum at the near clipping plane.</param>
        /// <param name="viewBottom">The y-coordinate of the bottom side of the clipping frustum at the near clipping plane.</param>
        /// <param name="viewTop">The y-coordinate of the top side of the clipping frustum at the near clipping plane.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the custom perspective projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix PerspectiveOffCenterLH(float viewLeft, float viewRight, float viewBottom, float viewTop, float nearZ, float farZ)
        {
            Debug.Assert(nearZ > 0.0f && farZ > 0.0f, "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewRight, viewLeft, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewTop, viewBottom, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float twoNearZ = nearZ + nearZ;
            float reciprocalWidth = 1.0f / (viewRight - viewLeft);
            float reciprocalHeight = 1.0f / (viewTop - viewBottom);
            float range = farZ / (farZ - nearZ);

            return new XMMatrix(
                twoNearZ * reciprocalWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                twoNearZ * reciprocalHeight,
                0.0f,
                0.0f,
                -(viewLeft + viewRight) * reciprocalWidth,
                -(viewTop + viewBottom) * reciprocalHeight,
                range,
                1.0f,
                0.0f,
                0.0f,
                -range * nearZ,
                0.0f);
        }

        /// <summary>
        /// Builds a custom version of a right-handed perspective projection matrix.
        /// </summary>
        /// <param name="viewLeft">The x-coordinate of the left side of the clipping frustum at the near clipping plane.</param>
        /// <param name="viewRight">The x-coordinate of the right side of the clipping frustum at the near clipping plane.</param>
        /// <param name="viewBottom">The y-coordinate of the bottom side of the clipping frustum at the near clipping plane.</param>
        /// <param name="viewTop">The y-coordinate of the top side of the clipping frustum at the near clipping plane.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the custom perspective projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix PerspectiveOffCenterRH(float viewLeft, float viewRight, float viewBottom, float viewTop, float nearZ, float farZ)
        {
            Debug.Assert(nearZ > 0.0f && farZ > 0.0f, "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewRight, viewLeft, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewTop, viewBottom, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float twoNearZ = nearZ + nearZ;
            float reciprocalWidth = 1.0f / (viewRight - viewLeft);
            float reciprocalHeight = 1.0f / (viewTop - viewBottom);
            float range = farZ / (nearZ - farZ);

            return new XMMatrix(
                twoNearZ * reciprocalWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                twoNearZ * reciprocalHeight,
                0.0f,
                0.0f,
                (viewLeft + viewRight) * reciprocalWidth,
                (viewTop + viewBottom) * reciprocalHeight,
                range,
                -1.0f,
                0.0f,
                0.0f,
                range * nearZ,
                0.0f);
        }

        /// <summary>
        /// Builds an orthogonal projection matrix for a left-handed coordinate system.
        /// </summary>
        /// <param name="viewWidth">Width of the frustum at the near clipping plane.</param>
        /// <param name="viewHeight">Height of the frustum at the near clipping plane.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the orthogonal projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix OrthographicLH(float viewWidth, float viewHeight, float nearZ, float farZ)
        {
            Debug.Assert(!XMScalar.NearEqual(viewWidth, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewHeight, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float range = 1.0f / (farZ - nearZ);

            return new XMMatrix(
                2.0f / viewWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                2.0f / viewHeight,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                0.0f,
                0.0f,
                0.0f,
                -range * nearZ,
                1.0f);
        }

        /// <summary>
        /// Builds an orthogonal projection matrix for a right-handed coordinate system.
        /// </summary>
        /// <param name="viewWidth">Width of the frustum at the near clipping plane.</param>
        /// <param name="viewHeight">Height of the frustum at the near clipping plane.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the orthogonal projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix OrthographicRH(float viewWidth, float viewHeight, float nearZ, float farZ)
        {
            Debug.Assert(!XMScalar.NearEqual(viewWidth, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewHeight, 0.0f, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float range = 1.0f / (nearZ - farZ);

            return new XMMatrix(
                2.0f / viewWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                2.0f / viewHeight,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                0.0f,
                0.0f,
                0.0f,
                range * nearZ,
                1.0f);
        }

        /// <summary>
        /// Builds a custom orthogonal projection matrix for a left-handed coordinate system.
        /// </summary>
        /// <param name="viewLeft">Minimum x-value of the view volume.</param>
        /// <param name="viewRight">Maximum x-value of the view volume.</param>
        /// <param name="viewBottom">Minimum y-value of the view volume.</param>
        /// <param name="viewTop">Maximum y-value of the view volume.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the custom orthogonal projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix OrthographicOffCenterLH(float viewLeft, float viewRight, float viewBottom, float viewTop, float nearZ, float farZ)
        {
            Debug.Assert(!XMScalar.NearEqual(viewRight, viewLeft, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewTop, viewBottom, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float reciprocalWidth = 1.0f / (viewRight - viewLeft);
            float reciprocalHeight = 1.0f / (viewTop - viewBottom);
            float range = 1.0f / (farZ - nearZ);

            return new XMMatrix(
                reciprocalWidth + reciprocalWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                reciprocalHeight + reciprocalHeight,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                0.0f,
                -(viewLeft + viewRight) * reciprocalWidth,
                -(viewTop + viewBottom) * reciprocalHeight,
                -range * nearZ,
                1.0f);
        }

        /// <summary>
        /// Builds a custom orthogonal projection matrix for a right-handed coordinate system.
        /// </summary>
        /// <param name="viewLeft">Minimum x-value of the view volume.</param>
        /// <param name="viewRight">Maximum x-value of the view volume.</param>
        /// <param name="viewBottom">Minimum y-value of the view volume.</param>
        /// <param name="viewTop">Maximum y-value of the view volume.</param>
        /// <param name="nearZ">Distance to the near clipping plane.</param>
        /// <param name="farZ">Distance to the far clipping plane.</param>
        /// <returns>Returns the custom orthogonal projection matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix OrthographicOffCenterRH(float viewLeft, float viewRight, float viewBottom, float viewTop, float nearZ, float farZ)
        {
            Debug.Assert(!XMScalar.NearEqual(viewRight, viewLeft, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(viewTop, viewBottom, 0.00001f), "Reviewed");
            Debug.Assert(!XMScalar.NearEqual(farZ, nearZ, 0.00001f), "Reviewed");

            float reciprocalWidth = 1.0f / (viewRight - viewLeft);
            float reciprocalHeight = 1.0f / (viewTop - viewBottom);
            float range = 1.0f / (nearZ - farZ);

            return new XMMatrix(
                reciprocalWidth + reciprocalWidth,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                reciprocalHeight + reciprocalHeight,
                0.0f,
                0.0f,
                0.0f,
                0.0f,
                range,
                0.0f,
                -(viewLeft + viewRight) * reciprocalWidth,
                -(viewTop + viewBottom) * reciprocalHeight,
                range * nearZ,
                1.0f);
        }

        /// <summary>
        /// Performance an identity operation on a matrix.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <returns>Returns the matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Plus(XMMatrix m)
        {
            return m;
        }

        /// <summary>
        /// Computes the negation of a matrix.
        /// </summary>
        /// <param name="m">The matrix.</param>
        /// <returns>Returns the negation of the matrix.</returns>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "m", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Negate(XMMatrix m)
        {
            return new XMMatrix(
                ((XMVector*)&m)[0].Negate(),
                ((XMVector*)&m)[1].Negate(),
                ((XMVector*)&m)[2].Negate(),
                ((XMVector*)&m)[3].Negate());
        }

        /// <summary>
        /// Computes the sum of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns a matrix that is the sum of the two matrices.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Add(XMMatrix m1, XMMatrix m2)
        {
            return new XMMatrix(
                XMVector.Add(((XMVector*)&m1)[0], ((XMVector*)&m2)[0]),
                XMVector.Add(((XMVector*)&m1)[1], ((XMVector*)&m2)[1]),
                XMVector.Add(((XMVector*)&m1)[2], ((XMVector*)&m2)[2]),
                XMVector.Add(((XMVector*)&m1)[3], ((XMVector*)&m2)[3]));
        }

        /// <summary>
        /// Computes the difference of two matrices.
        /// </summary>
        /// <param name="m1">The first matrix.</param>
        /// <param name="m2">The second matrix.</param>
        /// <returns>Returns a matrix that is the difference of the two matrices.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMMatrix Subtract(XMMatrix m1, XMMatrix m2)
        {
            return new XMMatrix(
                XMVector.Subtract(((XMVector*)&m1)[0], ((XMVector*)&m2)[0]),
                XMVector.Subtract(((XMVector*)&m1)[1], ((XMVector*)&m2)[1]),
                XMVector.Subtract(((XMVector*)&m1)[2], ((XMVector*)&m2)[2]),
                XMVector.Subtract(((XMVector*)&m1)[3], ((XMVector*)&m2)[3]));
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is XMMatrix))
            {
                return false;
            }

            return this.Equals((XMMatrix)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMMatrix other)
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
                && this.m44 == other.m44;
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
                this.m44
            }
            .GetHashCode();
        }

        /// <summary>
        /// Convert a matrix to an array of float.
        /// </summary>
        /// <returns>An array of float.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float[] ToArray()
        {
            return new float[]
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
                this.m44
            };
        }

        /// <summary>
        /// Stores an <see cref="XMMatrix"/> in an <see cref="XMFloat3X3"/>.
        /// </summary>
        /// <param name="destination">The destination structure</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat3X3(out XMFloat3X3 destination)
        {
            destination = new XMFloat3X3(
                this.m11,
                this.m12,
                this.m13,
                this.m21,
                this.m22,
                this.m23,
                this.m31,
                this.m32,
                this.m33);
        }

        /// <summary>
        /// Stores an <see cref="XMMatrix"/> in an <see cref="XMFloat4X3"/>.
        /// </summary>
        /// <param name="destination">The destination structure</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat4X3(out XMFloat4X3 destination)
        {
            destination = new XMFloat4X3(
                this.m11,
                this.m12,
                this.m13,
                this.m21,
                this.m22,
                this.m23,
                this.m31,
                this.m32,
                this.m33,
                this.m41,
                this.m42,
                this.m43);
        }

        /// <summary>
        /// Stores an <see cref="XMMatrix"/> in an <see cref="XMFloat4X4"/>.
        /// </summary>
        /// <param name="destination">The destination structure</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void StoreFloat4X4(out XMFloat4X4 destination)
        {
            destination = new XMFloat4X4(
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
                this.m44);
        }

        /// <summary>
        /// Tests whether any of the elements of a matrix are NaN.
        /// </summary>
        /// <returns>Returns true if any element of M is NaN, and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsNaN()
        {
            fixed (XMMatrix* m = &this)
            {
                uint* work = (uint*)m;

                //// remove sign
                //// NaN is 0x7F800001 through 0x7FFFFFFF inclusive

                return ((work[0] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[1] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[2] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[3] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[4] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[5] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[6] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[7] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[8] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[9] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[10] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[11] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[12] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[13] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[14] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU)
                    || ((work[15] & 0x7FFFFFFFU) - 0x7F800001U < 0x007FFFFFU);
            }
        }

        /// <summary>
        /// Tests whether any of the elements of a matrix are positive or negative infinity.
        /// </summary>
        /// <returns>Returns true if any element of M is either positive or negative infinity, and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsInfinite()
        {
            fixed (XMMatrix* m = &this)
            {
                uint* work = (uint*)m;

                //// Remove sign
                //// INF is 0x7F800000

                return ((work[0] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[1] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[2] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[3] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[4] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[5] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[6] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[7] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[8] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[9] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[10] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[11] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[12] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[13] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[14] & 0x7FFFFFFFU) == 0x7F800000U)
                    || ((work[15] & 0x7FFFFFFFU) == 0x7F800000U);
            }
        }

        /// <summary>
        /// Tests whether a matrix is the identity matrix.
        /// </summary>
        /// <returns>Returns true if M is the identity matrix, and false otherwise.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsIdentity()
        {
            fixed (XMMatrix* m = &this)
            {
                // Use the integer pipeline to reduce branching to a minimum
                uint* work = (uint*)m;

                // Convert 1.0f to zero and or them together
                // Or all the 0.0f entries together
                uint one = work[0] ^ 0x3F800000U;
                uint zero = work[1];
                zero |= work[2];
                zero |= work[3];

                // 2nd row
                zero |= work[4];
                one |= work[5] ^ 0x3F800000U;
                zero |= work[6];
                zero |= work[7];

                // 3rd row
                zero |= work[8];
                zero |= work[9];
                one |= work[10] ^ 0x3F800000U;
                zero |= work[11];

                // 4th row
                zero |= work[12];
                zero |= work[13];
                zero |= work[14];
                one |= work[15] ^ 0x3F800000U;

                // If all zero entries are zero, the uZero==0
                zero &= 0x7FFFFFFF;    // Allow -0.0f

                // If all 1.0f entries are 1.0f, then uOne==0
                one |= zero;
                return one == 0;
            }
        }

        /// <summary>
        /// Computes the transpose of a matrix.
        /// </summary>
        /// <returns>Returns the transpose.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix Transpose()
        {
            //// Original matrix:
            ////
            ////     m00m01m02m03
            ////     m10m11m12m13
            ////     m20m21m22m23
            ////     m30m31m32m33

            fixed (XMMatrix* m = &this)
            {
                XMMatrix p;

                // m00m20m01m21
                ((uint*)&p)[0 + 0] = ((uint*)m)[0 + 0];
                ((uint*)&p)[0 + 1] = ((uint*)m)[8 + 0];
                ((uint*)&p)[0 + 2] = ((uint*)m)[0 + 1];
                ((uint*)&p)[0 + 3] = ((uint*)m)[8 + 1];

                // m10m30m11m31
                ((uint*)&p)[4 + 0] = ((uint*)m)[4 + 0];
                ((uint*)&p)[4 + 1] = ((uint*)m)[12 + 0];
                ((uint*)&p)[4 + 2] = ((uint*)m)[4 + 1];
                ((uint*)&p)[4 + 3] = ((uint*)m)[12 + 1];

                // m02m22m03m23
                ((uint*)&p)[8 + 0] = ((uint*)m)[0 + 2];
                ((uint*)&p)[8 + 1] = ((uint*)m)[8 + 2];
                ((uint*)&p)[8 + 2] = ((uint*)m)[0 + 3];
                ((uint*)&p)[8 + 3] = ((uint*)m)[8 + 3];

                // m12m32m13m33
                ((uint*)&p)[12 + 0] = ((uint*)m)[4 + 2];
                ((uint*)&p)[12 + 1] = ((uint*)m)[12 + 2];
                ((uint*)&p)[12 + 2] = ((uint*)m)[4 + 3];
                ((uint*)&p)[12 + 3] = ((uint*)m)[12 + 3];

                XMMatrix mt;

                // m00m10m20m30
                ((uint*)&mt)[0 + 0] = ((uint*)&p)[0 + 0];
                ((uint*)&mt)[0 + 1] = ((uint*)&p)[4 + 0];
                ((uint*)&mt)[0 + 2] = ((uint*)&p)[0 + 1];
                ((uint*)&mt)[0 + 3] = ((uint*)&p)[4 + 1];

                // m01m11m21m31
                ((uint*)&mt)[4 + 0] = ((uint*)&p)[0 + 2];
                ((uint*)&mt)[4 + 1] = ((uint*)&p)[4 + 2];
                ((uint*)&mt)[4 + 2] = ((uint*)&p)[0 + 3];
                ((uint*)&mt)[4 + 3] = ((uint*)&p)[4 + 3];

                // m02m12m22m32
                ((uint*)&mt)[8 + 0] = ((uint*)&p)[8 + 0];
                ((uint*)&mt)[8 + 1] = ((uint*)&p)[12 + 0];
                ((uint*)&mt)[8 + 2] = ((uint*)&p)[8 + 1];
                ((uint*)&mt)[8 + 3] = ((uint*)&p)[12 + 1];

                // m03m13m23m33
                ((uint*)&mt)[12 + 0] = ((uint*)&p)[8 + 2];
                ((uint*)&mt)[12 + 1] = ((uint*)&p)[12 + 2];
                ((uint*)&mt)[12 + 2] = ((uint*)&p)[8 + 3];
                ((uint*)&mt)[12 + 3] = ((uint*)&p)[12 + 3];

                return mt;
            }
        }

        /// <summary>
        /// Computes the inverse of a matrix.
        /// </summary>
        /// <param name="determinant">A vector, each of whose components is the determinant of M.</param>
        /// <returns>Returns the matrix inverse of M. If there is no inverse (that is, if the determinant is 0), returns an infinite matrix.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix Inverse(out XMVector determinant)
        {
            XMMatrix mt = this.Transpose();

            XMVector v00;
            XMVector v01;
            XMVector v02;
            XMVector v03;

            XMVector v10;
            XMVector v11;
            XMVector v12;
            XMVector v13;

            v00 = new XMVector(mt.m31, mt.m31, mt.m32, mt.m32);
            v10 = new XMVector(mt.m43, mt.m44, mt.m43, mt.m44);
            v01 = new XMVector(mt.m11, mt.m11, mt.m12, mt.m12);
            v11 = new XMVector(mt.m23, mt.m24, mt.m23, mt.m24);
            v02 = new XMVector(mt.m31, mt.m33, mt.m11, mt.m13);
            v12 = new XMVector(mt.m42, mt.m44, mt.m22, mt.m24);

            XMVector d0 = XMVector.Multiply(v00, v10);
            XMVector d1 = XMVector.Multiply(v01, v11);
            XMVector d2 = XMVector.Multiply(v02, v12);

            v00 = new XMVector(mt.m33, mt.m34, mt.m33, mt.m34);
            v10 = new XMVector(mt.m41, mt.m41, mt.m42, mt.m42);
            v01 = new XMVector(mt.m13, mt.m14, mt.m13, mt.m14);
            v11 = new XMVector(mt.m21, mt.m21, mt.m22, mt.m22);
            v02 = new XMVector(mt.m32, mt.m34, mt.m12, mt.m14);
            v12 = new XMVector(mt.m41, mt.m43, mt.m21, mt.m23);

            d0 = XMVector.NegativeMultiplySubtract(v00, v10, d0);
            d1 = XMVector.NegativeMultiplySubtract(v01, v11, d1);
            d2 = XMVector.NegativeMultiplySubtract(v02, v12, d2);

            v00 = new XMVector(mt.m22, mt.m23, mt.m21, mt.m22);
            v10 = new XMVector(d2.Y, d0.Y, d0.W, d0.X);
            v01 = new XMVector(mt.m13, mt.m11, mt.m12, mt.m11);
            v11 = new XMVector(d0.W, d2.Y, d0.Y, d0.Z);
            v02 = new XMVector(mt.m42, mt.m43, mt.m41, mt.m42);
            v12 = new XMVector(d2.W, d1.Y, d1.W, d1.X);
            v03 = new XMVector(mt.m33, mt.m31, mt.m32, mt.m31);
            v13 = new XMVector(d1.W, d2.W, d1.Y, d1.Z);

            XMVector c0 = XMVector.Multiply(v00, v10);
            XMVector c2 = XMVector.Multiply(v01, v11);
            XMVector c4 = XMVector.Multiply(v02, v12);
            XMVector c6 = XMVector.Multiply(v03, v13);

            v00 = new XMVector(mt.m23, mt.m24, mt.m22, mt.m23);
            v10 = new XMVector(d0.W, d0.X, d0.Y, d2.X);
            v01 = new XMVector(mt.m14, mt.m13, mt.m14, mt.m12);
            v11 = new XMVector(d0.Z, d0.Y, d2.X, d0.X);
            v02 = new XMVector(mt.m43, mt.m44, mt.m42, mt.m43);
            v12 = new XMVector(d1.W, d1.X, d1.Y, d2.Z);
            v03 = new XMVector(mt.m34, mt.m33, mt.m34, mt.m32);
            v13 = new XMVector(d1.Z, d1.Y, d2.Z, d1.X);

            c0 = XMVector.NegativeMultiplySubtract(v00, v10, c0);
            c2 = XMVector.NegativeMultiplySubtract(v01, v11, c2);
            c4 = XMVector.NegativeMultiplySubtract(v02, v12, c4);
            c6 = XMVector.NegativeMultiplySubtract(v03, v13, c6);

            v00 = new XMVector(mt.m24, mt.m21, mt.m24, mt.m21);
            v10 = new XMVector(d0.Z, d2.Y, d2.X, d0.Z);
            v01 = new XMVector(mt.m12, mt.m14, mt.m11, mt.m13);
            v11 = new XMVector(d2.Y, d0.X, d0.W, d2.X);
            v02 = new XMVector(mt.m44, mt.m41, mt.m44, mt.m41);
            v12 = new XMVector(d1.Z, d2.W, d2.Z, d1.Z);
            v03 = new XMVector(mt.m32, mt.m34, mt.m31, mt.m33);
            v13 = new XMVector(d2.W, d1.X, d1.W, d2.Z);

            XMVector c1 = XMVector.NegativeMultiplySubtract(v00, v10, c0);
            c0 = XMVector.MultiplyAdd(v00, v10, c0);
            XMVector c3 = XMVector.MultiplyAdd(v01, v11, c2);
            c2 = XMVector.NegativeMultiplySubtract(v01, v11, c2);
            XMVector c5 = XMVector.NegativeMultiplySubtract(v02, v12, c4);
            c4 = XMVector.MultiplyAdd(v02, v12, c4);
            XMVector c7 = XMVector.MultiplyAdd(v03, v13, c6);
            c6 = XMVector.NegativeMultiplySubtract(v03, v13, c6);

            XMVector r0 = new XMVector(c0.X, c1.Y, c0.Z, c1.W);
            XMVector r1 = new XMVector(c2.X, c3.Y, c2.Z, c3.W);
            XMVector r2 = new XMVector(c4.X, c5.Y, c4.Z, c5.W);
            XMVector r3 = new XMVector(c6.X, c7.Y, c6.Z, c7.W);

            determinant = XMVector.Replicate((r0.X * mt.m11) + (r0.Y * mt.m12) + (r0.Z * mt.m13) + (r0.W * mt.m14));

            XMVector reciprocal = determinant.Reciprocal();

            return new XMMatrix(
                XMVector.Multiply(r0, reciprocal),
                XMVector.Multiply(r1, reciprocal),
                XMVector.Multiply(r2, reciprocal),
                XMVector.Multiply(r3, reciprocal));
        }

        /// <summary>
        /// Computes the inverse of a matrix.
        /// </summary>
        /// <returns>Returns the matrix inverse of M. If there is no inverse (that is, if the determinant is 0), returns an infinite matrix.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix Inverse()
        {
            return this.Inverse(out _);
        }

        /// <summary>
        /// Computes the determinant of a matrix.
        /// </summary>
        /// <returns>Returns a vector. The determinant of M is replicated into each component.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector Determinant()
        {
            XMVector sign = new XMVector(1.0f, -1.0f, 1.0f, -1.0f);

            XMVector v0 = new XMVector(this.m32, this.m31, this.m31, this.m31);
            XMVector v1 = new XMVector(this.m43, this.m43, this.m42, this.m42);
            XMVector v2 = new XMVector(this.m33, this.m31, this.m31, this.m31);
            XMVector v3 = new XMVector(this.m44, this.m44, this.m44, this.m43);
            XMVector v4 = new XMVector(this.m33, this.m33, this.m32, this.m32);
            XMVector v5 = new XMVector(this.m44, this.m44, this.m44, this.m43);

            XMVector p0 = XMVector.Multiply(v0, v1);
            XMVector p1 = XMVector.Multiply(v2, v3);
            XMVector p2 = XMVector.Multiply(v4, v5);

            v0 = new XMVector(this.m33, this.m33, this.m32, this.m32);
            v1 = new XMVector(this.m42, this.m41, this.m41, this.m41);
            v2 = new XMVector(this.m34, this.m34, this.m34, this.m33);
            v3 = new XMVector(this.m42, this.m41, this.m41, this.m41);
            v4 = new XMVector(this.m34, this.m34, this.m34, this.m33);
            v5 = new XMVector(this.m43, this.m43, this.m42, this.m42);

            p0 = XMVector.NegativeMultiplySubtract(v0, v1, p0);
            p1 = XMVector.NegativeMultiplySubtract(v2, v3, p1);
            p2 = XMVector.NegativeMultiplySubtract(v4, v5, p2);

            v0 = new XMVector(this.m24, this.m24, this.m24, this.m23);
            v1 = new XMVector(this.m23, this.m23, this.m22, this.m22);
            v2 = new XMVector(this.m22, this.m21, this.m21, this.m21);

            XMVector s = XMVector.Multiply(new XMVector(this.m11, this.m12, this.m13, this.m14), sign);

            XMVector r = XMVector.Multiply(v0, p0);
            r = XMVector.NegativeMultiplySubtract(v1, p1, r);
            r = XMVector.MultiplyAdd(v2, p2, r);

            return XMVector.Replicate((s.X * r.X) + (s.Y * r.Y) + (s.Z * r.Z) + (s.W * r.W));
        }

        /// <summary>
        /// Breaks down a general 3D transformation matrix into its scalar, rotational, and translational components.
        /// </summary>
        /// <param name="scale">The scaling factors applied along the x, y, and z-axes.</param>
        /// <param name="rotationQuaternion">A quaternion that describes the rotation.</param>
        /// <param name="translation">A translation along the x, y, and z-axes.</param>
        /// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Decompose(out XMVector scale, out XMVector rotationQuaternion, out XMVector translation)
        {
            fixed (XMMatrix* m = &this)
            {
                XMMatrix canonicalBasis = new XMMatrix(
                    XMGlobalConstants.IdentityR0,
                    XMGlobalConstants.IdentityR1,
                    XMGlobalConstants.IdentityR2,
                    XMGlobalConstants.IdentityR3);

                // Get the translation
                translation = ((XMVector*)m)[3];

                XMMatrix matTemp = new XMMatrix(
                    ((XMVector*)m)[0],
                    ((XMVector*)m)[1],
                    ((XMVector*)m)[2],
                    XMGlobalConstants.IdentityR3);

                XMMatrix basis = matTemp;

                XMVector outScale = new XMVector(
                    XMVector3.Length(((XMVector*)&basis)[0]).X,
                    XMVector3.Length(((XMVector*)&basis)[1]).X,
                    XMVector3.Length(((XMVector*)&basis)[2]).X,
                    0.0f);

                XMMatrix.RankDecompose(out int a, out int b, out int c, outScale.X, outScale.Y, outScale.Z);

                if (((float*)&outScale)[a] < XMMatrix.DecomposeEpsilon)
                {
                    ((XMVector*)&basis)[a] = ((XMVector*)&canonicalBasis)[a];
                }

                ((XMVector*)&basis)[a] = XMVector3.Normalize(((XMVector*)&basis)[a]);

                if (((float*)&outScale)[b] < XMMatrix.DecomposeEpsilon)
                {
                    float f_absX = Math.Abs(((XMVector*)&basis)[a].X);
                    float f_absY = Math.Abs(((XMVector*)&basis)[a].Y);
                    float f_absZ = Math.Abs(((XMVector*)&basis)[a].Z);

                    XMMatrix.RankDecompose(out int aa, out int bb, out int cc, f_absX, f_absY, f_absZ);

                    ((XMVector*)&basis)[b] = XMVector3.Cross(((XMVector*)&basis)[a], ((XMVector*)&canonicalBasis)[cc]);
                }

                ((XMVector*)&basis)[b] = XMVector3.Normalize(((XMVector*)&basis)[b]);

                if (((float*)&outScale)[c] < XMMatrix.DecomposeEpsilon)
                {
                    ((XMVector*)&basis)[c] = XMVector3.Cross(((XMVector*)&basis)[a], ((XMVector*)&basis)[b]);
                }

                ((XMVector*)&basis)[c] = XMVector3.Normalize(((XMVector*)&basis)[c]);

                float det = matTemp.Determinant().X;

                // use Kramer's rule to check for handedness of coordinate system
                if (det < 0.0f)
                {
                    // switch coordinate system by negating the scale and inverting the basis vector on the x-axis
                    ((float*)&outScale)[a] = -((float*)&outScale)[a];
                    ((XMVector*)&basis)[a] = ((XMVector*)&basis)[a].Negate();
                    det = -det;
                }

                scale = outScale;

                det -= 1.0f;
                det *= det;

                if (det > XMMatrix.DecomposeEpsilon)
                {
                    // Non-SRT matrix encountered
                    rotationQuaternion = XMVector.Zero;
                    return false;
                }

                // generate the quaternion from the matrix
                rotationQuaternion = XMQuaternion.RotationMatrix(matTemp);
                return true;
            }
        }

        /// <summary>
        /// Decompose a matrix by ranks.
        /// </summary>
        /// <param name="a">The first rank.</param>
        /// <param name="b">The second rank.</param>
        /// <param name="c">The third rank.</param>
        /// <param name="x">The first value.</param>
        /// <param name="y">The second value.</param>
        /// <param name="z">The third value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void RankDecompose(out int a, out int b, out int c, float x, float y, float z)
        {
            if (x < y)
            {
                if (y < z)
                {
                    a = 2;
                    b = 1;
                    c = 0;
                }
                else
                {
                    a = 1;

                    if (x < z)
                    {
                        b = 2;
                        c = 0;
                    }
                    else
                    {
                        b = 0;
                        c = 2;
                    }
                }
            }
            else
            {
                if (x < z)
                {
                    a = 2;
                    b = 0;
                    c = 1;
                }
                else
                {
                    a = 0;

                    if (y < z)
                    {
                        b = 2;
                        c = 1;
                    }
                    else
                    {
                        b = 1;
                        c = 2;
                    }
                }
            }
        }
    }
}
