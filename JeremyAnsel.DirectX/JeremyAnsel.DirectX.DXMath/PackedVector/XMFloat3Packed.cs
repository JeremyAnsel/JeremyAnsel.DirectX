// <copyright file="XMFloat3Packed.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.PackedVector
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    /// <summary>
    /// A 3D vector with X and Y components stored as 11 bit floating point number, and Z component stored as a 10 bit floating-point value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct XMFloat3Packed : IEquatable<XMFloat3Packed>
    {
        /// <summary>
        /// A packed value representing the vector.
        /// </summary>
        private uint v;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3Packed"/> struct.
        /// </summary>
        /// <param name="packed">A packed value representing the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3Packed(uint packed)
        {
            this.v = packed;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3Packed"/> struct.
        /// </summary>
        /// <param name="x">The x component.</param>
        /// <param name="y">The y component.</param>
        /// <param name="z">The z component.</param>
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3Packed(float x, float y, float z)
        {
            this = new XMVector(x, y, z, 0.0f);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XMFloat3Packed"/> struct.
        /// </summary>
        /// <param name="array">The components of the vector.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMFloat3Packed(float[] array)
        {
            this = XMVector.LoadFloat3(new XMFloat3(array));
        }

        /// <summary>
        /// Gets or sets the 6-bit mantissa for the x component.
        /// </summary>
        public byte XM
        {
            get { return (byte)(this.v & 0x3FU); }
            set { this.v ^= (this.v ^ (uint)value) & 0x3FU; }
        }

        /// <summary>
        /// Gets or sets the 5-bit biased exponent for the x component.
        /// </summary>
        public byte XE
        {
            get { return (byte)((this.v >> 6) & 0x1FU); }
            set { this.v ^= (this.v ^ ((uint)value << 6)) & (0x1FU << 6); }
        }

        /// <summary>
        /// Gets or sets the 6-bit mantissa for the y component.
        /// </summary>
        public byte YM
        {
            get { return (byte)((this.v >> 11) & 0x3FU); }
            set { this.v ^= (this.v ^ ((uint)value << 11)) & (0x3FU << 11); }
        }

        /// <summary>
        /// Gets or sets the 5-bit biased exponent for the y component.
        /// </summary>
        public byte YE
        {
            get { return (byte)((this.v >> 17) & 0x1FU); }
            set { this.v ^= (this.v ^ ((uint)value << 17)) & (0x1FU << 17); }
        }

        /// <summary>
        /// Gets or sets the 5-bit mantissa for the z component.
        /// </summary>
        public byte ZM
        {
            get { return (byte)((this.v >> 22) & 0x1FU); }
            set { this.v ^= (this.v ^ ((uint)value << 22)) & (0x1FU << 22); }
        }

        /// <summary>
        /// Gets or sets the 5-bit biased exponent for the z component.
        /// </summary>
        public byte ZE
        {
            get { return (byte)((this.v >> 27) & 0x1FU); }
            set { this.v ^= (this.v ^ ((uint)value << 27)) & (0x1FU << 27); }
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3Packed"/> to a packed value.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat3Packed"/>.</param>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator uint(XMFloat3Packed value)
        {
            return value.v;
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMFloat3Packed"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMFloat3Packed"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMFloat3Packed(uint value)
        {
            return new XMFloat3Packed(value);
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3Packed"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMFloat3Packed"/>.</param>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMVector(XMFloat3Packed value)
        {
            XMFloat3 result;
            uint mantissa;
            uint exponent;

            // X Channel (6-bit mantissa)
            mantissa = value.XM;

            if (value.XE == 0x1FU)
            {
                //// INF or NAN

                ((uint*)&result)[0] = 0x7f800000U | ((uint)value.XM << 17);
            }
            else
            {
                if (value.XE != 0)
                {
                    // The value is normalized
                    exponent = value.XE;
                }
                else if (mantissa != 0)
                {
                    //// The value is denormalized

                    // Normalize the value in the resulting float
                    exponent = 1;

                    do
                    {
                        exponent--;
                        mantissa <<= 1;
                    }
                    while ((mantissa & 0x40U) == 0);

                    mantissa &= 0x3FU;
                }
                else
                {
                    //// The value is zero

                    exponent = unchecked((uint)(-112));
                }

                ((uint*)&result)[0] = ((exponent + 112) << 23) | (mantissa << 17);
            }

            // Y Channel (6-bit mantissa)
            mantissa = value.YM;

            if (value.YE == 0x1FU)
            {
                //// INF or NAN

                ((uint*)&result)[1] = 0x7f800000U | ((uint)value.YM << 17);
            }
            else
            {
                if (value.YE != 0)
                {
                    //// The value is normalized

                    exponent = value.YE;
                }
                else if (mantissa != 0)
                {
                    //// The value is denormalized

                    // Normalize the value in the resulting float
                    exponent = 1;

                    do
                    {
                        exponent--;
                        mantissa <<= 1;
                    }
                    while ((mantissa & 0x40U) == 0);

                    mantissa &= 0x3FU;
                }
                else
                {
                    //// The value is zero

                    exponent = unchecked((uint)(-112));
                }

                ((uint*)&result)[1] = ((exponent + 112) << 23) | (mantissa << 17);
            }

            // Z Channel (5-bit mantissa)
            mantissa = value.ZM;

            if (value.ZE == 0x1FU)
            {
                //// INF or NAN

                ((uint*)&result)[2] = 0x7f800000U | ((uint)value.ZM << 17);
            }
            else
            {
                if (value.ZE != 0)
                {
                    //// The value is normalized

                    exponent = value.ZE;
                }
                else if (mantissa != 0)
                {
                    //// The value is denormalized

                    // Normalize the value in the resulting float
                    exponent = 1;

                    do
                    {
                        exponent--;
                        mantissa <<= 1;
                    }
                    while ((mantissa & 0x20U) == 0);

                    mantissa &= 0x1FU;
                }
                else
                {
                    //// The value is zero

                    exponent = unchecked((uint)(-112));
                }

                ((uint*)&result)[2] = ((exponent + 112) << 23) | (mantissa << 18);
            }

            return XMVector.LoadFloat3(result);
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMFloat3Packed"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMFloat3Packed"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
        public static implicit operator XMFloat3Packed(XMVector value)
        {
            value.StoreFloat3(out XMFloat3 i_value);

            XMUInt3 result;
            uint sign;
            uint i;

            // X & Y Channels (5-bit exponent, 6-bit mantissa)
            for (uint j = 0; j < 2; ++j)
            {
                sign = ((uint*)&i_value)[j] & 0x80000000U;
                i = ((uint*)&i_value)[j] & 0x7FFFFFFFU;

                if ((i & 0x7F800000U) == 0x7F800000U)
                {
                    // INF or NAN
                    ((uint*)&result)[j] = 0x7c0U;
                    if ((i & 0x7FFFFFU) != 0)
                    {
                        ((uint*)&result)[j] = 0x7c0U | (((i >> 17) | (i >> 11) | (i >> 6) | i) & 0x3fU);
                    }
                    else if (sign != 0)
                    {
                        // -INF is clamped to 0 since 3PK is positive only
                        ((uint*)&result)[j] = 0;
                    }
                }
                else if (sign != 0)
                {
                    // 3PK is positive only, so clamp to zero
                    ((uint*)&result)[j] = 0;
                }
                else if (i > 0x477E0000U)
                {
                    // The number is too large to be represented as a float11, set to max
                    ((uint*)&result)[j] = 0x7BFU;
                }
                else
                {
                    if (i < 0x38800000U)
                    {
                        // The number is too small to be represented as a normalized float11
                        // Convert it to a denormalized value.
                        int shift = 113 - (int)(i >> 23);
                        i = (0x800000U | (i & 0x7FFFFFU)) >> shift;
                    }
                    else
                    {
                        // Rebias the exponent to represent the value as a normalized float11
                        i += 0xC8000000U;
                    }

                    ((uint*)&result)[j] = ((i + 0xFFFFU + ((i >> 17) & 1U)) >> 17) & 0x7ffU;
                }
            }

            // Z Channel (5-bit exponent, 5-bit mantissa)
            sign = ((uint*)&i_value)[2] & 0x80000000U;
            i = ((uint*)&i_value)[2] & 0x7FFFFFFFU;

            if ((i & 0x7F800000U) == 0x7F800000U)
            {
                // INF or NAN
                ((uint*)&result)[2] = 0x3e0U;
                if ((i & 0x7FFFFFU) != 0)
                {
                    ((uint*)&result)[2] = 0x3e0U | (((i >> 18) | (i >> 13) | (i >> 3) | i) & 0x1fU);
                }
                else if (sign != 0)
                {
                    // -INF is clamped to 0 since 3PK is positive only
                    ((uint*)&result)[2] = 0;
                }
            }
            else if (sign != 0)
            {
                // 3PK is positive only, so clamp to zero
                ((uint*)&result)[2] = 0;
            }
            else if (i > 0x477C0000U)
            {
                // The number is too large to be represented as a float10, set to max
                ((uint*)&result)[2] = 0x3dfU;
            }
            else
            {
                if (i < 0x38800000U)
                {
                    // The number is too small to be represented as a normalized float10
                    // Convert it to a denormalized value.
                    int shift = 113 - (int)(i >> 23);
                    i = (0x800000U | (i & 0x7FFFFFU)) >> shift;
                }
                else
                {
                    // Rebias the exponent to represent the value as a normalized float10
                    i += 0xC8000000U;
                }

                ((uint*)&result)[2] = ((i + 0x1FFFFU + ((i >> 18) & 1U)) >> 18) & 0x3ffU;
            }

            // Pack Result into memory
            uint v = (((uint*)&result)[0] & 0x7ffU) | ((((uint*)&result)[1] & 0x7ffU) << 11) | ((((uint*)&result)[2] & 0x3ffU) << 22);
            return new XMFloat3Packed(v);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat3Packed"/> objects. The result specifies whether the values of the two objects are equal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat3Packed"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat3Packed"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right are equal; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(XMFloat3Packed left, XMFloat3Packed right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="XMFloat3Packed"/> objects. The result specifies whether the values of the two objects are unequal.
        /// </summary>
        /// <param name="left">The left <see cref="XMFloat3Packed"/> to compare.</param>
        /// <param name="right">The right <see cref="XMFloat3Packed"/> to compare.</param>
        /// <returns><value>true</value> if the values of left and right differ; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(XMFloat3Packed left, XMFloat3Packed right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Converts a packed value to a <see cref="XMFloat3Packed"/>.
        /// </summary>
        /// <param name="value">A packed value.</param>
        /// <returns>A <see cref="XMFloat3Packed"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat3Packed FromPacked(uint value)
        {
            return value;
        }

        /// <summary>
        /// Converts a <see cref="XMVector"/> to a <see cref="XMFloat3Packed"/>.
        /// </summary>
        /// <param name="value">A <see cref="XMVector"/>.</param>
        /// <returns>A <see cref="XMFloat3Packed"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XMFloat3Packed FromVector(XMVector value)
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
            if (!(obj is XMFloat3Packed))
            {
                return false;
            }

            return this.Equals((XMFloat3Packed)obj);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><value>true</value> if the specified object is equal to the current object; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(XMFloat3Packed other)
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
        /// Converts a <see cref="XMFloat3Packed"/> to a packed value.
        /// </summary>
        /// <returns>A packed value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint ToPacked()
        {
            return this;
        }

        /// <summary>
        /// Converts a <see cref="XMFloat3Packed"/> to a <see cref="XMVector"/>.
        /// </summary>
        /// <returns>A <see cref="XMVector"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public XMVector ToVector()
        {
            return this;
        }
    }
}
