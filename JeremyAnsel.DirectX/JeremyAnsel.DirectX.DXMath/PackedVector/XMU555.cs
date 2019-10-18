// <copyright file="XMU555.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4D vector with x-,y-, and z- components represented as 5 bit unsigned integer values, and the w-component as a 1 bit integer value.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Sequential)]
    public struct XMU555 : IEquatable<XMU555>
    {
        /// <summary>
        /// A packed value representing the vector.
        /// </summary>
        private ushort v;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU555"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU555(ushort packed)
        {
            this.v = packed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU555"/> struct.
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
        public XMU555(byte x, byte y, byte z, bool w)
        {
            this.v = (ushort)((x & 0x1FU) | ((y & 0x1FU) << 5) | ((z & 0x1FU) << 10) | (w ? 0x8000U : 0U));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU555"/> struct.
        /// </summary>
        /// <param name="array">The x y z components of the vector.</param>
        /// <param name="w">The w component of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU555(byte[] array, bool w)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.v = (ushort)((array[0] & 0x1FU) | ((array[1] & 0x1FU) << 5) | ((array[2] & 0x1FU) << 10) | (w ? 0x8000U : 0U));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU555"/> struct.
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
        public XMU555(float x, float y, float z, bool w)
        {
            this = new XMVector(x, y, z, w ? 1.0f : 0.0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU555"/> struct.
        /// </summary>
        /// <param name="array">The x y z components of the vector.</param>
        /// <param name="w">The w component of the vector.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "w", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU555(float[] array, bool w)
        {
            XMVector v = XMVector.LoadFloat3(new XMFloat3(array));
            v.W = w ? 1.0f : 0.0f;
            this = v;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public byte X
        {
            get { return (byte)(this.v & 0x1FU); }
            set { this.v ^= (ushort)((this.v ^ value) & 0x1FU); }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public byte Y
        {
            get { return (byte)((this.v >> 5) & 0x1FU); }
            set { this.v ^= (ushort)((this.v ^ (value << 5)) & (0x1FU << 5)); }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public byte Z
        {
            get { return (byte)((this.v >> 10) & 0x1FU); }
            set { this.v ^= (ushort)((this.v ^ (value << 10)) & (0x1FU << 10)); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the w-coordinate of the vector is set.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public bool W
        {
            get { return (this.v >> 15) != 0; }
            set { this.v = (ushort)((this.v & 0x7FFFU) | (value ? 0x8000U : 0U)); }
        }

        /// <summary>
        /// Converts a <see cref="XMU555"/> to a packed value.
        /// </summary>
        /// <param name="value">A <see cref="XMU555"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator ushort(XMU555 value)
        {
            return value.v;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMU555"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMU555"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMU555(ushort value)
        {
            return new XMU555(value);
        }

        /// <summary>
        /// Converts a <see cref="XMU555"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMU555"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMU555 value)
        {
            return new XMVector(
                (float)(value.v & 0x1FU),
                (float)((value.v >> 5) & 0x1FU),
                (float)((value.v >> 10) & 0x1FU),
                (float)((value.v >> 15) & 0x1U));
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMU555"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMU555"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMU555(XMVector value)
        {
            XMVector max = XMVector.FromFloat(31.0f, 31.0f, 31.0f, 1.0f);

            XMVector n = value.Clamp(XMGlobalConstants.Zero, max);
            n = n.Round();

            ushort v = (ushort)(((uint)n.X & 0x1FU) | (((uint)n.Y & 0x1FU) << 5) | (((uint)n.Z & 0x1FU) << 10) | (n.W > 0.0f ? 0x8000U : 0U));
            return new XMU555(v);
        }

        /// <summary>
        /// Compares two <see cref="XMU555"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMU555"/> to compare.</param>
        /// <param name="right">The right <see cref="XMU555"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMU555 left, XMU555 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMU555"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMU555"/> to compare.</param>
        /// <param name="right">The right <see cref="XMU555"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMU555 left, XMU555 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMU555"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMU555"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMU555 FromPacked(ushort value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMU555"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMU555"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMU555 FromVector(XMVector value)
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
            if (!(obj is XMU555))
            {
                return false;
            }

            return this.Equals((XMU555)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMU555 other)
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
        /// Converts a <see cref="XMU555"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort ToPacked()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMU555"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
