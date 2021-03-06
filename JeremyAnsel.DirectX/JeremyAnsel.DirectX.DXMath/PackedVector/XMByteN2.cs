﻿// <copyright file="XMByteN2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 2D vector for storing signed, normalized values as signed 8-bits (1 byte) integers.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMByteN2 : IEquatable<XMByteN2>
    {
        /// <summary>
        /// The x-coordinate of the vector.
        /// </summary>
        private sbyte x;

        /// <summary>
        /// The y-coordinate of the vector.
        /// </summary>
        private sbyte y;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMByteN2"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMByteN2(ushort packed)
        {
            fixed (XMByteN2* v = &this)
            {
                *(ushort*)v = packed;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMByteN2"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the vector.</param>
        /// <param name="y">The y-coordinate of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMByteN2(sbyte x, sbyte y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMByteN2"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMByteN2(sbyte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 2)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.x = array[0];
            this.y = array[1];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMByteN2"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the vector.</param>
        /// <param name="y">The y-coordinate of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMByteN2(float x, float y)
        {
            this = new XMVector(x, y, 0.0f, 0.0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMByteN2"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMByteN2(float[] array)
        {
            this = XMVector.LoadFloat2(new XMFloat2(array));
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public sbyte X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public sbyte Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Converts a <see cref="XMByteN2"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMByteN2"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMByteN2 value)
        {
            return new XMVector(
                (value.x == -128) ? -1.0f : ((float)value.x * (1.0f / 127.0f)),
                (value.y == -128) ? -1.0f : ((float)value.y * (1.0f / 127.0f)),
                0.0f,
                0.0f);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMByteN2"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMByteN2"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMByteN2(XMVector value)
        {
            XMVector n = value.Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One);
            n = XMVector.Multiply(n, XMGlobalConstants.ByteMax);
            n = n.Round();

            return new XMByteN2(
                (sbyte)n.X,
                (sbyte)n.Y);
        }

        /// <summary>
        /// Compares two <see cref="XMByteN2"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMByteN2"/> to compare.</param>
        /// <param name="right">The right <see cref="XMByteN2"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMByteN2 left, XMByteN2 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMByteN2"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMByteN2"/> to compare.</param>
        /// <param name="right">The right <see cref="XMByteN2"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMByteN2 left, XMByteN2 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMByteN2"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMByteN2"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMByteN2 FromVector(XMVector value)
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
            if (!(obj is XMByteN2))
            {
                return false;
            }

            return this.Equals((XMByteN2)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMByteN2 other)
        {
            return this.x == other.x
                && this.y == other.y;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return new
            {
                this.x,
                this.y
            }
            .GetHashCode();
        }

        /// <summary>
        /// Converts a <see cref="XMByteN2"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
