// <copyright file="XMFloat4X4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4*4 floating point matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMFloat4X4 : IEquatable<XMFloat4X4>
    {
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
        /// Initializes a new instance of the <see cref="XMFloat4X4"/> struct.
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
        public XMFloat4X4(
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
        /// Initializes a new instance of the <see cref="XMFloat4X4"/> struct.
        /// </summary>
        /// <param name="array">The values of the matrix.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat4X4(float[]? array)
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
        /// Gets or sets an element specified by row and column.
        /// </summary>
        /// <param name="row">The row containing the matrix element.</param>
        /// <param name="column">The column containing the matrix element.</param>
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

                fixed (XMFloat4X4* m = &this)
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

                fixed (XMFloat4X4* m = &this)
                {
                    ((float*)m)[(row * 4) + column] = value;
                }
            }
        }

        /// <summary>
        /// Converts a <see cref="XMFloat4X4"/> to a <see cref="XMMatrix"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat4X4"/>.</param>
        /// <returns>A <see cref="XMMatrix"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMMatrix(XMFloat4X4 value)
        {
            return XMMatrix.LoadFloat4X4(value);
        }

        /// <summary>
        /// Converts a <see cref="XMMatrix"/> to a <see cref="XMFloat4X4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMMatrix"/>.</param>
        /// <returns>A <see cref="XMFloat4X4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMFloat4X4(XMMatrix value)
        {
            value.StoreFloat4X4(out XMFloat4X4 ret);
            return ret;
        }

        /// <summary>
        /// Compares two <see cref="XMFloat4X4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat4X4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat4X4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMFloat4X4 left, XMFloat4X4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat4X4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat4X4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat4X4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMFloat4X4 left, XMFloat4X4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMMatrix"/> to a <see cref="XMFloat4X4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMMatrix"/>.</param>
        /// <returns>A <see cref="XMFloat4X4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat4X4 FromMatrix(XMMatrix value)
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object? obj)
        {
            if (!(obj is XMFloat4X4))
            {
                return false;
            }

            return this.Equals((XMFloat4X4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMFloat4X4 other)
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
        /// Converts a <see cref="XMFloat4X4"/> to a <see cref="XMMatrix"/>.
        /// </summary>
        /// <returns>A <see cref="XMMatrix"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix ToMatrix()
        {
            return this;
        }
    }
}
