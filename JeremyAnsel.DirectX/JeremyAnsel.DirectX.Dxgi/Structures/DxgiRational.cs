// <copyright file="DxgiRational.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Represents a rational number.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiRational : IEquatable<DxgiRational>
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static int NativeRequiredSize()
    {
        return NativeRequiredSize(1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    public static int NativeRequiredSize(int count)
    {
        int size = 0;
        size += sizeof(uint) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiRational obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiRational>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiRational> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.numerator);
            DXMarshal.Write(ref buffer, obj.denominator);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiRational NativeReadFrom(nint buffer)
    {
        DxgiRational obj;
        obj.numerator = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.denominator = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiRational> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// An unsigned integer value representing the top of the rational number.
    /// </summary>
    private uint numerator;

    /// <summary>
    /// An unsigned integer value representing the bottom of the rational number.
    /// </summary>
    private uint denominator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiRational"/> struct.
    /// </summary>
    /// <param name="numerator">An unsigned integer value representing the top of the rational number.</param>
    /// <param name="denominator">An unsigned integer value representing the bottom of the rational number.</param>
    public DxgiRational(uint numerator, uint denominator)
    {
        this.numerator = numerator;
        this.denominator = denominator;
    }

    /// <summary>
    /// Gets an unsigned integer value representing the top of the rational number.
    /// </summary>
    public uint Numerator
    {
        get { return this.numerator; }
        set { this.numerator = value; }
    }

    /// <summary>
    /// Gets an unsigned integer value representing the bottom of the rational number.
    /// </summary>
    public uint Denominator
    {
        get { return this.denominator; }
        set { this.denominator = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiRational left, DxgiRational right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiRational left, DxgiRational right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        if (this.numerator == 0)
        {
            return "0";
        }

        if (this.denominator == 0 || this.denominator == 1)
        {
            return this.numerator.ToString(CultureInfo.InvariantCulture);
        }

        return string.Format(CultureInfo.InvariantCulture, "{0}/{1}", this.numerator, this.denominator);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiRational rational && Equals(rational);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiRational other)
    {
        return numerator == other.numerator &&
               denominator == other.denominator;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -671859081;
        hashCode = hashCode * -1521134295 + numerator.GetHashCode();
        hashCode = hashCode * -1521134295 + denominator.GetHashCode();
        return hashCode;
    }
}
