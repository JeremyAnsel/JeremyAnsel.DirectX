// <copyright file="XMDec4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath.PackedVector;

/// <summary>
/// A 4D vector with x-,y-, and z- components represented as 10 bit signed integer values, and the w-component as a 2 bit signed integer value.
/// </summary>
[SkipLocalsInit]
public unsafe struct XMDec4 : IEquatable<XMDec4>
{
    /// <summary>
    /// A packed value representing the vector.
    /// </summary>
    private uint v;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMDec4"/> struct.
    /// </summary>
    /// <param name="packed">A packed value representing the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMDec4(uint packed)
    {
        this.v = packed;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMDec4"/> struct.
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
    public XMDec4(float x, float y, float z, float w)
    {
        this = new XMVector(x, y, z, w);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMDec4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMDec4(float[] array)
    {
        this = XMVector.LoadFloat4(new XMFloat4(array));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMDec4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMDec4(ReadOnlySpan<float> array)
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
    public int W
    {
        get { return (int)this.v >> 30; }
        set { this.v = (this.v & 0x3FFFFFFFU) | ((uint)value << 30); }
    }

    /// <summary>
    /// Converts a <see cref="XMDec4"/> to a packed value.
    /// </summary>
    /// <param name="value">A <see cref="XMDec4"/>.</param>
    /// <returns>A packed value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator uint(XMDec4 value)
    {
        return value.v;
    }

    /// <summary>
    /// Converts a packed value to a <see cref="XMDec4"/>.
    /// </summary>
    /// <param name="value">A packed value.</param>
    /// <returns>A <see cref="XMDec4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMDec4(uint value)
    {
        return new XMDec4(value);
    }

    /// <summary>
    /// Converts a <see cref="XMDec4"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMDec4"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMDec4 value)
    {
        XMUInt2 signExtend = new XMUInt2(0x00000000U, 0xFFFFFC00U);
        XMUInt2 signExtendW = new XMUInt2(0x00000000U, 0xFFFFFFFCU);

        uint elementX = value.v & 0x3FFU;
        uint elementY = (value.v >> 10) & 0x3FFU;
        uint elementZ = (value.v >> 20) & 0x3FFU;
        uint elementW = value.v >> 30;

        return new XMVector(
            (float)(short)(elementX | ((uint*)&signExtend)[elementX >> 9]),
            (float)(short)(elementY | ((uint*)&signExtend)[elementY >> 9]),
            (float)(short)(elementZ | ((uint*)&signExtend)[elementZ >> 9]),
            (float)(short)(elementW | ((uint*)&signExtendW)[elementW >> 1]));
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMDec4"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMDec4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMDec4(XMVector value)
    {
        XMVector min = XMVector.FromFloat(-511.0f, -511.0f, -511.0f, -1.0f);
        XMVector max = XMVector.FromFloat(511.0f, 511.0f, 511.0f, 1.0f);

        XMVector n = value.Clamp(min, max);

        uint v = (uint)((int)n.W << 30) | ((uint)((int)n.Z & 0x3FF) << 20) | ((uint)((int)n.Y & 0x3FF) << 10) | (uint)((int)n.X & 0x3FF);
        return new XMDec4(v);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMDec4 left, XMDec4 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMDec4 left, XMDec4 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a packed value to a <see cref="XMDec4"/>.
    /// </summary>
    /// <param name="value">A packed value.</param>
    /// <returns>A <see cref="XMDec4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMDec4 FromPacked(uint value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMDec4"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMDec4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMDec4 FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMDec4"/> to a packed value.
    /// </summary>
    /// <returns>A packed value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ToPacked()
    {
        return this;
    }

    /// <summary>
    /// Converts a <see cref="XMDec4"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMVector ToVector()
    {
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is XMDec4 dec && Equals(dec);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMDec4 other)
    {
        return v == other.v;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        return 238427441 + v.GetHashCode();
    }
}
