// <copyright file="Half.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath.PackedVector;

/// <summary>
/// An alias to <c>ushort</c> packed with a 16-bit floating-point number consisting of a sign bit, a 5-bit biased exponent, and a 10-bit mantissa.
/// </summary>
/// <remarks>
/// The <see cref="Half"/> data type is equivalent to the IEEE 754 binary16 format.
/// </remarks>
[SkipLocalsInit]
public unsafe struct Half : IEquatable<Half>
{
    /// <summary>
    /// The packed data.
    /// </summary>
    private ushort half;

    /// <summary>
    /// Converts a <see cref="Half"/> value to a <see cref="float"/> value.
    /// </summary>
    /// <param name="value">The <see cref="Half"/> value.</param>
    /// <returns>The <see cref="float"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator float(Half value)
    {
        uint mantissa = value.half & 0x3FFU;

        uint exponent = value.half & 0x7C00U;

        // INF/NAN
        if (exponent == 0x7C00U)
        {
            exponent = 0x8FU;
        }
        else if (exponent != 0)
        {
            //// The value is normalized

            exponent = (uint)(value.half >> 10) & 0x1FU;
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
            while ((mantissa & 0x400U) == 0);

            mantissa &= 0x3FFU;
        }
        else
        {
            //// The value is zero

            exponent = 0xFFFFFF90U;
        }

        // Sign, Exponent, // Mantissa
        uint result = ((value.half & 0x8000U) << 16) | ((exponent + 112) << 23) | (mantissa << 13);

        return *(float*)&result;
    }

    /// <summary>
    /// Converts a <see cref="Half"/> value to a <see cref="double"/> value.
    /// </summary>
    /// <param name="value">The <see cref="Half"/> value.</param>
    /// <returns>The <see cref="double"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator double(Half value)
    {
        return (float)value;
    }

    /// <summary>
    /// Converts a <see cref="float"/> value to a <see cref="Half"/> value.
    /// </summary>
    /// <param name="value">The <see cref="float"/> value.</param>
    /// <returns>The <see cref="Half"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static explicit operator Half(float value)
    {
        uint result;

        uint i_value = *(uint*)&value;
        uint sign = (i_value & 0x80000000U) >> 16;
        i_value &= 0x7FFFFFFFU; // Hack off the sign

        if (i_value > 0x477FE000U)
        {
            // The number is too large to be represented as a half.  Saturate to infinity.
            if (((i_value & 0x7F800000U) == 0x7F800000U) && ((i_value & 0x7FFFFFU) != 0))
            {
                result = 0x7FFFU; // NAN
            }
            else
            {
                result = 0x7C00U; // INF
            }
        }
        else
        {
            if (i_value < 0x38800000U)
            {
                // The number is too small to be represented as a normalized half.
                // Convert it to a denormalized value.
                int shift = 113 - (int)(i_value >> 23);
                i_value = (0x800000U | (i_value & 0x7FFFFFU)) >> shift;
            }
            else
            {
                // Rebias the exponent to represent the value as a normalized half.
                i_value += 0xC8000000U;
            }

            result = ((i_value + 0x0FFFU + ((i_value >> 13) & 1U)) >> 13) & 0x7FFFU;
        }

        result |= sign;

        return *(Half*)&result;
    }

    /// <summary>
    /// Converts a <see cref="double"/> value to a <see cref="Half"/> value.
    /// </summary>
    /// <param name="value">The <see cref="double"/> value.</param>
    /// <returns>The <see cref="Half"/> value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static explicit operator Half(double value)
    {
        return (Half)(float)value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(Half left, Half right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(Half left, Half right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return string.Format(CultureInfo.InvariantCulture, "{0}", (float)this);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is Half half && Equals(half);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(Half other)
    {
        return half == other.half;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 262182468 + half.GetHashCode();
    }
}
