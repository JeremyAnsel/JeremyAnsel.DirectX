// <copyright file="XMUNibble4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4D vector with four unsigned 4-bit integer components.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Sequential)]
    public struct XMUNibble4 : IEquatable<XMUNibble4>
    {
        /// <summary>
        /// A packed value representing the vector.
        /// </summary>
        private ushort v;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUNibble4"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUNibble4(ushort packed)
        {
            this.v = packed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUNibble4"/> struct.
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
        public XMUNibble4(byte x, byte y, byte z, byte w)
        {
            this.v = (ushort)((x & 0xFU) | ((y & 0xFU) << 4) | ((z & 0xFU) << 8) | ((w & 0xFU) << 12));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUNibble4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUNibble4(byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 4)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.v = (ushort)((array[0] & 0xFU) | ((array[1] & 0xFU) << 4) | ((array[2] & 0xFU) << 8) | ((array[3] & 0xFU) << 12));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUNibble4"/> struct.
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
        public XMUNibble4(float x, float y, float z, float w)
        {
            this = new XMVector(x, y, z, w);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMUNibble4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMUNibble4(float[] array)
        {
            this = XMVector.LoadFloat4(new XMFloat4(array));
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public byte X
        {
            get { return (byte)(this.v & 0xFU); }
            set { this.v ^= (ushort)((this.v ^ value) & 0xFU); }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public byte Y
        {
            get { return (byte)((this.v >> 4) & 0xFU); }
            set { this.v ^= (ushort)((this.v ^ (value << 4)) & (0xFU << 4)); }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public byte Z
        {
            get { return (byte)((this.v >> 8) & 0xFU); }
            set { this.v ^= (ushort)((this.v ^ (value << 8)) & (0xFU << 8)); }
        }

        /// <summary>
        /// Gets or sets the w-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public byte W
        {
            get { return (byte)((this.v >> 12) & 0xFU); }
            set { this.v ^= (ushort)((this.v ^ (value << 12)) & (0xFU << 12)); }
        }

        /// <summary>
        /// Converts a <see cref="XMUNibble4"/> to a packed value.
        /// </summary>
        /// <param name="value">A <see cref="XMUNibble4"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator ushort(XMUNibble4 value)
        {
            return value.v;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMUNibble4"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMUNibble4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMUNibble4(ushort value)
        {
            return new XMUNibble4(value);
        }

        /// <summary>
        /// Converts a <see cref="XMUNibble4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMUNibble4"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMUNibble4 value)
        {
            return new XMVector(
                (float)(value.v & 0xFU),
                (float)((value.v >> 4) & 0xFU),
                (float)((value.v >> 8) & 0xFU),
                (float)((value.v >> 12) & 0xFU));
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMUNibble4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMUNibble4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMUNibble4(XMVector value)
        {
            XMVector max = XMVector.FromFloat(15.0f, 15.0f, 15.0f, 15.0f);

            XMVector n = value.Clamp(XMGlobalConstants.Zero, max);
            n = n.Round();

            ushort v = (ushort)((((uint)n.W & 0xFU) << 12) | (((uint)n.Z & 0xFU) << 8) | (((uint)n.Y & 0xFU) << 4) | ((uint)n.X & 0xFU));
            return new XMUNibble4(v);
        }

        /// <summary>
        /// Compares two <see cref="XMUNibble4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMUNibble4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMUNibble4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMUNibble4 left, XMUNibble4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMUNibble4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMUNibble4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMUNibble4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMUNibble4 left, XMUNibble4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMUNibble4"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMUNibble4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMUNibble4 FromPacked(ushort value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMUNibble4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMUNibble4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMUNibble4 FromVector(XMVector value)
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
            if (!(obj is XMUNibble4))
            {
                return false;
            }

            return this.Equals((XMUNibble4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMUNibble4 other)
        {
            return this.v == other.v;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return this.v.GetHashCode();
        }

        /// <summary>
        /// Converts a <see cref="XMUNibble4"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort ToPacked()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMUNibble4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
