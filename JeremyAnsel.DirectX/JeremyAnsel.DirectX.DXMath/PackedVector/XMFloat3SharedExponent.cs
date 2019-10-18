// <copyright file="XMFloat3SharedExponent.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 3D vector of three floating-point components with 9 bit mantissas, each sharing the same 5-bit exponent.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMFloat3SharedExponent : IEquatable<XMFloat3SharedExponent>
    {
        /// <summary>
        /// A packed value representing the vector.
        /// </summary>
        private uint v;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3SharedExponent"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3SharedExponent(uint packed)
        {
            this.v = packed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3SharedExponent"/> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3SharedExponent(float x, float y, float z)
        {
            this = new XMVector(x, y, z, 0.0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3SharedExponent"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3SharedExponent(float[] array)
        {
            this = XMVector.LoadFloat3(new XMFloat3(array));
        }

        /// <summary>
        /// Gets or sets the 9-bit x component.
        /// </summary>
        public uint XM
        {
            get { return this.v & 0x1FFU; }
            set { this.v ^= (this.v ^ (uint)value) & 0x1FFU; }
        }

        /// <summary>
        /// Gets or sets the 9-bit y component.
        /// </summary>
        public byte YM
        {
            get { return (byte)((this.v >> 9) & 0x1FFU); }
            set { this.v ^= (this.v ^ ((uint)value << 9)) & (0x1FFU << 9); }
        }

        /// <summary>
        /// Gets or sets the 9-bit z component.
        /// </summary>
        public byte ZM
        {
            get { return (byte)((this.v >> 18) & 0x1FFU); }
            set { this.v ^= (this.v ^ ((uint)value << 18)) & (0x1FFU << 18); }
        }

        /// <summary>
        /// Gets or sets the 5-bit shared exponent.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "E", Justification = "Reviewed")]
        public byte E
        {
            get { return (byte)((this.v >> 27) & 0x1FU); }
            set { this.v ^= (this.v ^ ((uint)value << 27)) & (0x1FU << 27); }
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3SharedExponent"/> to a packed value.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat3SharedExponent"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(XMFloat3SharedExponent value)
        {
            return value.v;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMFloat3SharedExponent"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMFloat3SharedExponent"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMFloat3SharedExponent(uint value)
        {
            return new XMFloat3SharedExponent(value);
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3SharedExponent"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat3SharedExponent"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMVector(XMFloat3SharedExponent value)
        {
            float scale;
            *(uint*)&scale = 0x33800000U + (uint)(value.E << 23);

            return new XMVector(
                scale * (float)value.XM,
                scale * (float)value.YM,
                scale * (float)value.ZM,
                1.0f);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMFloat3SharedExponent"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMFloat3SharedExponent"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator XMFloat3SharedExponent(XMVector value)
        {
            XMFloat3 tmp;
            value.StoreFloat3(out tmp);

            const float Maxf9 = (float)(0x1FF << 7);
            const float Minf9 = (float)(1.0f / (1 << 16));

            float x = (tmp.X >= 0.0f) ? ((tmp.X > Maxf9) ? Maxf9 : tmp.X) : 0.0f;
            float y = (tmp.Y >= 0.0f) ? ((tmp.Y > Maxf9) ? Maxf9 : tmp.Y) : 0.0f;
            float z = (tmp.Z >= 0.0f) ? ((tmp.Z > Maxf9) ? Maxf9 : tmp.Z) : 0.0f;

            float max_xy = (x > y) ? x : y;
            float max_xyz = (max_xy > z) ? max_xy : z;

            float maxColor = (max_xyz > Minf9) ? max_xyz : Minf9;
            uint fi = *(uint*)&maxColor + 0x4000U; // round up leaving 9 bits in fraction (including assumed 1)

            uint e = (fi - 0x37800000U) >> 23;

            float scaleR;
            *(uint*)&scaleR = 0x83000000 - fi;

            uint xm = (uint)XMVector.RoundToNearest(x * scaleR);
            uint ym = (uint)XMVector.RoundToNearest(y * scaleR);
            uint zm = (uint)XMVector.RoundToNearest(z * scaleR);

            uint v = (xm & 0x1FFU) | ((ym & 0x1FFU) << 9) | ((zm & 0x1FFU) << 18) | ((e & 0x1FU) << 27);
            return new XMFloat3SharedExponent(v);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat3SharedExponent"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat3SharedExponent"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat3SharedExponent"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMFloat3SharedExponent left, XMFloat3SharedExponent right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat3SharedExponent"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat3SharedExponent"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat3SharedExponent"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMFloat3SharedExponent left, XMFloat3SharedExponent right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMFloat3SharedExponent"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMFloat3SharedExponent"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat3SharedExponent FromPacked(uint value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMFloat3SharedExponent"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMFloat3SharedExponent"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat3SharedExponent FromVector(XMVector value)
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
            if (!(obj is XMFloat3SharedExponent))
            {
                return false;
            }

            return this.Equals((XMFloat3SharedExponent)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMFloat3SharedExponent other)
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
        /// Converts a <see cref="XMFloat3SharedExponent"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint ToPacked()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3SharedExponent"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
