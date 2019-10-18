// <copyright file="XMU565.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 3D vector with x- and z- components represented as 5-bit unsigned integer values, and the y- component as a 6-bit unsigned integer value.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Sequential)]
    public struct XMU565 : IEquatable<XMU565>
    {
        /// <summary>
        /// A packed value representing the vector.
        /// </summary>
        private ushort v;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU565"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU565(ushort packed)
        {
            this.v = packed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU565"/> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU565(byte x, byte y, byte z)
        {
            this.v = (ushort)((x & 0x1FU) | ((y & 0x3FU) << 5) | ((z & 0x1FU) << 11));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU565"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU565(byte[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length != 3)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            this.v = (ushort)((array[0] & 0x1FU) | ((array[1] & 0x3FU) << 5) | ((array[2] & 0x1FU) << 11));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU565"/> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU565(float x, float y, float z)
        {
            this = new XMVector(x, y, z, 0.0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMU565"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMU565(float[] array)
        {
            this = XMVector.LoadFloat3(new XMFloat3(array));
        }

        /// <summary>
        /// Gets or sets the x component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public byte X
        {
            get { return (byte)(this.v & 0x1FU); }
            set { this.v ^= (ushort)((this.v ^ value) & 0x1FU); }
        }

        /// <summary>
        /// Gets or sets the y component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public byte Y
        {
            get { return (byte)((this.v >> 5) & 0x3FU); }
            set { this.v ^= (ushort)((this.v ^ (value << 5)) & (0x3FU << 5)); }
        }

        /// <summary>
        /// Gets or sets the z component.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public byte Z
        {
            get { return (byte)((this.v >> 11) & 0x1FU); }
            set { this.v ^= (ushort)((this.v ^ (value << 11)) & (0x1FU << 11)); }
        }

        /// <summary>
        /// Converts a <see cref="XMU565"/> to a packed value.
        /// </summary>
        /// <param name="value">A <see cref="XMU565"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator ushort(XMU565 value)
        {
            return value.v;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMU565"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMU565"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMU565(ushort value)
        {
            return new XMU565(value);
        }

        /// <summary>
        /// Converts a <see cref="XMU565"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMU565"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMU565 value)
        {
            return new XMVector(
                    (float)(value.v & 0x1FU),
                    (float)((value.v >> 5) & 0x3FU),
                    (float)((value.v >> 11) & 0x1FU),
                    0.0f);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMU565"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMU565"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMU565(XMVector value)
        {
            XMVector max = XMVector.FromFloat(31.0f, 63.0f, 31.0f, 0.0f);

            XMVector n = value.Clamp(XMGlobalConstants.Zero, max);
            n = n.Round();

            ushort v = (ushort)((((ushort)n.Z & 0x1FU) << 11) | (((ushort)n.Y & 0x3FU) << 5) | ((ushort)n.X & 0x1FU));
            return new XMU565(v);
        }

        /// <summary>
        /// Compares two <see cref="XMU565"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMU565"/> to compare.</param>
        /// <param name="right">The right <see cref="XMU565"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMU565 left, XMU565 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMU565"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMU565"/> to compare.</param>
        /// <param name="right">The right <see cref="XMU565"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMU565 left, XMU565 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMU565"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMU565"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMU565 FromPacked(ushort value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMU565"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMU565"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMU565 FromVector(XMVector value)
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
            if (!(obj is XMU565))
            {
                return false;
            }

            return this.Equals((XMU565)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMU565 other)
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
        /// Converts a <see cref="XMU565"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort ToPacked()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMU565"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
