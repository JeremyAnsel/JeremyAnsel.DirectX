﻿// <copyright file="XMUByteN4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 3D vector for storing unsigned, normalized values as signed 8-bits (1 byte) integers.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMUByteN4 : IEquatable<XMUByteN4>
    {
        /// <summary>
        /// The x-coordinate of the vector.
        /// </summary>
        private byte x;

        /// <summary>
        /// The y-coordinate of the vector.
        /// </summary>
        private byte y;

        /// <summary>
        /// The z-coordinate of the vector.
        /// </summary>
        private byte z;

        /// <summary>
        /// The w-coordinate of the vector.
        /// </summary>
        private byte w;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUByteN4"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUByteN4(uint packed)
        {
            fixed (XMUByteN4* v = &this)
            {
                *(uint*)v = packed;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUByteN4"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the vector.</param>
        /// <param name="y">The y-coordinate of the vector.</param>
        /// <param name="z">The z-coordinate of the vector.</param>
        /// <param name="w">The w-coordinate of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUByteN4(byte x, byte y, byte z, byte w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUByteN4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUByteN4(byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.x = array[0];
            this.y = array[1];
            this.z = array[2];
            this.w = array[3];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUByteN4"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate of the vector.</param>
        /// <param name="y">The y-coordinate of the vector.</param>
        /// <param name="z">The z-coordinate of the vector.</param>
        /// <param name="w">The w-coordinate of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUByteN4(float x, float y, float z, float w)
        {
            this = new XMVector(x, y, z, w);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUByteN4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUByteN4(float[] array)
        {
            this = XMVector.LoadFloat4(new XMFloat4(array));
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public byte X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public byte Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public byte Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets the w-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public byte W
        {
            get { return this.w; }
            set { this.w = value; }
        }

        /// <summary>
        /// Converts a <see cref="XMUByteN4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMUByteN4"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMUByteN4 value)
        {
            return new XMVector(
                (float)value.x / 255.0f,
                (float)value.y / 255.0f,
                (float)value.z / 255.0f,
                (float)value.w / 255.0f);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMUByteN4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMUByteN4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMUByteN4(XMVector value)
        {
            XMVector n = value.Saturate();
            n = XMVector.Multiply(n, XMGlobalConstants.UByteMax);
            n = n.Round();

            return new XMUByteN4(
                (byte)n.X,
                (byte)n.Y,
                (byte)n.Z,
                (byte)n.W);
        }

        /// <summary>
        /// Compares two <see cref="XMUByteN4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMUByteN4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMUByteN4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMUByteN4 left, XMUByteN4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMUByteN4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMUByteN4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMUByteN4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMUByteN4 left, XMUByteN4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMUByteN4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMUByteN4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMUByteN4 FromVector(XMVector value)
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
            if (!(obj is XMUByteN4))
            {
                return false;
            }

            return this.Equals((XMUByteN4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMUByteN4 other)
        {
            return this.x == other.x
                && this.y == other.y
                && this.z == other.z
                && this.w == other.w;
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
                this.y,
                this.z,
                this.w
            }
            .GetHashCode();
        }

        /// <summary>
        /// Converts a <see cref="XMUByteN4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
