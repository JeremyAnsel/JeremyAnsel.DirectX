// <copyright file="XMUDecN4XR.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath.PackedVector;

/// <summary>
/// A 4D vector for storing unsigned, normalized integer values as 10 bit unsigned x-, y-, and z-components and a 2-bit unsigned w-component.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
[SkipLocalsInit]
public struct XMUDecN4XR : IEquatable<XMUDecN4XR>
{
    /// <summary>
    /// A packed value representing the vector.
    /// </summary>
    private uint v;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUDecN4XR"/> struct.
    /// </summary>
    /// <param name="packed">A packed value representing the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUDecN4XR(uint packed)
    {
        this.v = packed;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUDecN4XR"/> struct.
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
    public XMUDecN4XR(float x, float y, float z, float w)
    {
        this = new XMVector(x, y, z, w);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUDecN4XR"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUDecN4XR(float[] array)
    {
        this = XMVector.LoadFloat4(new XMFloat4(array));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUDecN4XR"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUDecN4XR(ReadOnlySpan<float> array)
    {
        this = XMVector.LoadFloat4(new XMFloat4(array));
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
    public uint X
    {
        get { return this.v & 0x3FFU; }
        set { this.v ^= (this.v ^ value) & 0x3FF; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
    public uint Y
    {
        get { return (this.v >> 10) & 0x3FFU; }
        set { this.v ^= (this.v ^ (value << 10)) & (0x3FFU << 10); }
    }

    /// <summary>
    /// Gets or sets the z-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
    public uint Z
    {
        get { return (this.v >> 20) & 0x3FFU; }
        set { this.v ^= (this.v ^ (value << 20)) & (0x3FFU << 20); }
    }

    /// <summary>
    /// Gets or sets the w-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
    public uint W
    {
        get { return (this.v >> 30) & 0x3U; }
        set { this.v = (this.v & 0x3FFFFFFFU) | (value << 30); }
    }

    /// <summary>
    /// Converts a <see cref="XMUDecN4XR"/> to a packed value.
    /// </summary>
    /// <param name="value">A <see cref="XMUDecN4XR"/>.</param>
    /// <returns>A packed value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator uint(XMUDecN4XR value)
    {
        return value.v;
    }

    /// <summary>
    /// Converts a packed value to a <see cref="XMUDecN4XR"/>.
    /// </summary>
    /// <param name="value">A packed value.</param>
    /// <returns>A <see cref="XMUDecN4XR"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMUDecN4XR(uint value)
    {
        return new XMUDecN4XR(value);
    }

    /// <summary>
    /// Converts a <see cref="XMUDecN4XR"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMUDecN4XR"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMUDecN4XR value)
    {
        uint elementX = value.v & 0x3FFU;
        uint elementY = (value.v >> 10) & 0x3FFU;
        uint elementZ = (value.v >> 20) & 0x3FFU;
        uint elementW = value.v >> 30;

        return new XMVector(
            (float)((int)elementX - 0x180) / 510.0f,
            (float)((int)elementY - 0x180) / 510.0f,
            (float)((int)elementZ - 0x180) / 510.0f,
            (float)elementW / 3.0f);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUDecN4XR"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUDecN4XR"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMUDecN4XR(XMVector value)
    {
        XMVector scale = XMVector.FromFloat(510.0f, 510.0f, 510.0f, 3.0f);
        XMVector bias = XMVector.FromFloat(384.0f, 384.0f, 384.0f, 0.0f);
        XMVector c = XMVector.FromFloat(1023.0f, 1023.0f, 1023.0f, 3.0f);

        XMVector n = XMVector.MultiplyAdd(value, scale, bias);
        n = n.Clamp(XMGlobalConstants.Zero, c);

        uint v = ((uint)n.W << 30) | (((uint)n.Z & 0x3FFU) << 20) | (((uint)n.Y & 0x3FFU) << 10) | ((uint)n.X & 0x3FFU);
        return new XMUDecN4XR(v);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMUDecN4XR left, XMUDecN4XR right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMUDecN4XR left, XMUDecN4XR right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a packed value to a <see cref="XMUDecN4XR"/>.
    /// </summary>
    /// <param name="value">A packed value.</param>
    /// <returns>A <see cref="XMUDecN4XR"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMUDecN4XR FromPacked(uint value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUDecN4XR"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUDecN4XR"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMUDecN4XR FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMUDecN4XR"/> to a packed value.
    /// </summary>
    /// <returns>A packed value.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public uint ToPacked()
    {
        return this;
    }

    /// <summary>
    /// Converts a <see cref="XMUDecN4XR"/> to a <see cref="XMVector"/>.
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
        return obj is XMUDecN4XR xR && Equals(xR);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMUDecN4XR other)
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
