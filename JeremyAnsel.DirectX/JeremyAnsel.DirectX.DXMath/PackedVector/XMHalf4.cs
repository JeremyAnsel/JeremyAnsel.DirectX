﻿// <copyright file="XMHalf4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4D vector consisting of four half-precision (16-bit) floating-point values.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMHalf4 : IEquatable<XMHalf4>
    {
        /// <summary>
        /// The x-coordinate.
        /// </summary>
        private Half x;

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        private Half y;

        /// <summary>
        /// The z-coordinate.
        /// </summary>
        private Half z;

        /// <summary>
        /// The w-coordinate.
        /// </summary>
        private Half w;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMHalf4"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMHalf4(ulong packed)
        {
            fixed (XMHalf4* v = &this)
            {
                *(ulong*)v = packed;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMHalf4"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-coordinate.</param>
        /// <param name="w">The w-coordinate.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMHalf4(Half x, Half y, Half z, Half w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMHalf4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMHalf4(Half[] array)
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
        /// Initializes a new instance of the <see cref="XMHalf4"/> struct.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="z">The z-coordinate.</param>
        /// <param name="w">The w-coordinate.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMHalf4(float x, float y, float z, float w)
        {
            this.x = (Half)x;
            this.y = (Half)y;
            this.z = (Half)z;
            this.w = (Half)w;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMHalf4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMHalf4(float[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.x = (Half)array[0];
            this.y = (Half)array[1];
            this.z = (Half)array[2];
            this.w = (Half)array[3];
        }

        /// <summary>
        /// Gets or sets the x-coordinate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public Half X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public Half Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        /// <summary>
        /// Gets or sets the z-coordinate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public Half Z
        {
            get { return this.z; }
            set { this.z = value; }
        }

        /// <summary>
        /// Gets or sets the w-coordinate.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public Half W
        {
            get { return this.w; }
            set { this.w = value; }
        }

        /// <summary>
        /// Converts a <see cref="XMHalf4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMHalf4"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMHalf4 value)
        {
            return new XMVector(
                (float)value.x,
                (float)value.y,
                (float)value.z,
                (float)value.w);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMHalf4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMHalf4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMHalf4(XMVector value)
        {
            return new XMHalf4(
                (Half)value.X,
                (Half)value.Y,
                (Half)value.Z,
                (Half)value.W);
        }

        /// <summary>
        /// Compares two <see cref="XMHalf4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMHalf4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMHalf4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMHalf4 left, XMHalf4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMHalf4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMHalf4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMHalf4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMHalf4 left, XMHalf4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMHalf4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMHalf4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMHalf4 FromVector(XMVector value)
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
            if (!(obj is XMHalf4))
            {
                return false;
            }

            return this.Equals((XMHalf4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMHalf4 other)
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
        /// Converts a <see cref="XMHalf4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
