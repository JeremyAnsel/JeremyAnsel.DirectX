// <copyright file="XMXDec4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 4D vector with x-,y-, and z- components represented as 10 bit signed integer values, and the w-component as a 2 bit unsigned integer value.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMX", Justification = "Reviewed")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMXDec4 : IEquatable<XMXDec4>
    {
        /// <summary>
        /// A packed value representing the vector.
        /// </summary>
        private uint v;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMXDec4"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMXDec4(uint packed)
        {
            this.v = packed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMXDec4"/> struct.
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
        public XMXDec4(float x, float y, float z, float w)
        {
            this = new XMVector(x, y, z, w);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMXDec4"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMXDec4(float[] array)
        {
            this = XMVector.LoadFloat4(new XMFloat4(array));
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
        public int X
        {
            get { return (int)(this.v << 22) >> 22; }
            set { this.v ^= (this.v ^ (uint)value) & 0x3FF; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
        public int Y
        {
            get { return (int)(this.v << 12) >> 22; }
            set { this.v ^= (this.v ^ ((uint)value << 10)) & (0x3FFU << 10); }
        }

        /// <summary>
        /// Gets or sets the z-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
        public int Z
        {
            get { return (int)(this.v << 2) >> 22; }
            set { this.v ^= (this.v ^ ((uint)value << 20)) & (0x3FFU << 20); }
        }

        /// <summary>
        /// Gets or sets the w-coordinate of the vector.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
        public uint W
        {
            get { return this.v >> 30; }
            set { this.v = (this.v & 0x3FFFFFFFU) | (value << 30); }
        }

        /// <summary>
        /// Converts a <see cref="XMXDec4"/> to a packed value.
        /// </summary>
        /// <param name="value">A <see cref="XMXDec4"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(XMXDec4 value)
        {
            return value.v;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMXDec4"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMXDec4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMXDec4(uint value)
        {
            return new XMXDec4(value);
        }

        /// <summary>
        /// Converts a <see cref="XMXDec4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMXDec4"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMVector(XMXDec4 value)
        {
            XMUInt2 signExtend = new XMUInt2(0x00000000U, 0xFFFFFC00U);

            uint elementX = value.v & 0x3FFU;
            uint elementY = (value.v >> 10) & 0x3FFU;
            uint elementZ = (value.v >> 20) & 0x3FFU;

            return new XMVector(
                (float)(short)(elementX | ((uint*)&signExtend)[elementX >> 9]),
                (float)(short)(elementY | ((uint*)&signExtend)[elementY >> 9]),
                (float)(short)(elementZ | ((uint*)&signExtend)[elementZ >> 9]),
                (float)(value.v >> 30));
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMXDec4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMXDec4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMXDec4(XMVector value)
        {
            XMVector min = XMVector.FromFloat(-511.0f, -511.0f, -511.0f, 0.0f);
            XMVector max = XMVector.FromFloat(511.0f, 511.0f, 511.0f, 3.0f);

            XMVector n = value.Clamp(min, max);

            uint v = ((uint)n.X << 30) | ((uint)((int)n.Z & 0x3FF) << 20) | ((uint)((int)n.Y & 0x3FF) << 10) | (uint)((int)n.X & 0x3FF);
            return new XMXDec4(v);
        }

        /// <summary>
        /// Compares two <see cref="XMXDec4"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMXDec4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMXDec4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMXDec4 left, XMXDec4 right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMXDec4"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMXDec4"/> to compare.</param>
        /// <param name="right">The right <see cref="XMXDec4"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMXDec4 left, XMXDec4 right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMXDec4"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMXDec4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMXDec4 FromPacked(uint value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMXDec4"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMXDec4"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMXDec4 FromVector(XMVector value)
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
            if (!(obj is XMXDec4))
            {
                return false;
            }

            return this.Equals((XMXDec4)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMXDec4 other)
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
        /// Converts a <see cref="XMXDec4"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint ToPacked()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMXDec4"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
