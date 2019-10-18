// <copyright file="XMFloat3X3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 3*3 floating point matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMFloat3X3 : IEquatable<XMFloat3X3>
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
        /// Initializes a new instance of the <see cref="XMFloat3X3"/> struct.
        /// </summary>
        /// <param name="m11">The value in the first row and first column.</param>
        /// <param name="m12">The value in the first row and second column.</param>
        /// <param name="m13">The value in the first row and third column.</param>
        /// <param name="m21">The value in the second row and first column.</param>
        /// <param name="m22">The value in the second row and second column.</param>
        /// <param name="m23">The value in the second row and third column.</param>
        /// <param name="m31">The value in the third row and first column.</param>
        /// <param name="m32">The value in the third row and second column.</param>
        /// <param name="m33">The value in the third row and third column.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3X3(
            float m11,
            float m12,
            float m13,
            float m21,
            float m22,
            float m23,
            float m31,
            float m32,
            float m33)
        {
            this.m11 = m11;
            this.m12 = m12;
            this.m13 = m13;
            this.m21 = m21;
            this.m22 = m22;
            this.m23 = m23;
            this.m31 = m31;
            this.m32 = m32;
            this.m33 = m33;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3X3"/> struct.
        /// </summary>
        /// <param name="array">The values of the matrix.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3X3(float[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 9)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.m11 = array[0];
            this.m12 = array[1];
            this.m13 = array[2];
            this.m21 = array[3];
            this.m22 = array[4];
            this.m23 = array[5];
            this.m31 = array[6];
            this.m32 = array[7];
            this.m33 = array[8];
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
                if (row < 0 || row >= 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }

                if (column < 0 || column >= 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(column));
                }

                fixed (XMFloat3X3* m = &this)
                {
                    return ((float*)m)[(row * 3) + column];
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (row < 0 || row >= 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(row));
                }

                if (column < 0 || column >= 3)
                {
                    throw new ArgumentOutOfRangeException(nameof(column));
                }

                fixed (XMFloat3X3* m = &this)
                {
                    ((float*)m)[(row * 3) + column] = value;
                }
            }
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3X3"/> to a <see cref="XMMatrix"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat3X3"/>.</param>
        /// <returns>A <see cref="XMMatrix"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMMatrix(XMFloat3X3 value)
        {
            return XMMatrix.LoadFloat3X3(value);
        }

        /// <summary>
        /// Converts a <see cref="XMMatrix"/> to a <see cref="XMFloat3X3"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMMatrix"/>.</param>
        /// <returns>A <see cref="XMFloat3X3"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMFloat3X3(XMMatrix value)
        {
            XMFloat3X3 ret;
            value.StoreFloat3X3(out ret);
            return ret;
        }

        /// <summary>
        /// Compares two <see cref="XMFloat3X3"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat3X3"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat3X3"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMFloat3X3 left, XMFloat3X3 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat3X3"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat3X3"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat3X3"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMFloat3X3 left, XMFloat3X3 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMMatrix"/> to a <see cref="XMFloat3X3"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMMatrix"/>.</param>
        /// <returns>A <see cref="XMFloat3X3"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat3X3 FromMatrix(XMMatrix value)
        {
            return value;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is XMFloat3X3))
            {
                return false;
            }

            return this.Equals((XMFloat3X3)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMFloat3X3 other)
        {
            return this.m11 == other.m11
                && this.m12 == other.m12
                && this.m13 == other.m13
                && this.m21 == other.m21
                && this.m22 == other.m22
                && this.m23 == other.m23
                && this.m31 == other.m31
                && this.m32 == other.m32
                && this.m33 == other.m33;
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
                this.m21,
                this.m22,
                this.m23,
                this.m31,
                this.m32,
                this.m33
            }
            .GetHashCode();
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3X3"/> to a <see cref="XMMatrix"/>.
        /// </summary>
        /// <returns>A <see cref="XMMatrix"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMMatrix ToMatrix()
        {
            return this;
        }
    }
}
