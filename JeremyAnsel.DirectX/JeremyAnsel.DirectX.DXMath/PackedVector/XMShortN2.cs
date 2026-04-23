// <copyright file="XMShortN2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath.PackedVector;

/// <summary>
/// A 2D vector for storing signed, normalized values as signed 16-bit integers.
/// </summary>
[SkipLocalsInit]
public unsafe struct XMShortN2 : IEquatable<XMShortN2>
{
    /// <summary>
    /// The x-coordinate of the vector.
    /// </summary>
    private short x;

    /// <summary>
    /// The y-coordinate of the vector.
    /// </summary>
    private short y;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="packed">A packed value representing the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(uint packed)
    {
        fixed (XMShortN2* v = &this)
        {
            *(uint*)v = packed;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="x">The x-coordinate of the vector.</param>
    /// <param name="y">The y-coordinate of the vector.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(short x, short y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(short[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(ReadOnlySpan<short> array)
    {
        if (array.Length != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="x">The x-coordinate of the vector.</param>
    /// <param name="y">The y-coordinate of the vector.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(float x, float y)
    {
        this = new XMVector(x, y, 0.0f, 0.0f);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(float[] array)
    {
        this = XMVector.LoadFloat2(new XMFloat2(array));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMShortN2(ReadOnlySpan<float> array)
    {
        this = XMVector.LoadFloat2(new XMFloat2(array));
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
    public short X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
    public short Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// Converts a <see cref="XMShortN2"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMShortN2"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMShortN2 value)
    {
        return new XMVector(
            (value.x == -32768) ? -1.0f : ((float)value.x * (1.0f / 32767.0f)),
            (value.y == -32768) ? -1.0f : ((float)value.y * (1.0f / 32767.0f)),
            0.0f,
            0.0f);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMShortN2"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMShortN2"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMShortN2(XMVector value)
    {
        XMVector n = value.Clamp(XMGlobalConstants.NegativeOne, XMGlobalConstants.One);
        n = XMVector.Multiply(n, XMGlobalConstants.ShortMax);
        n = n.Round();

        return new XMShortN2(
            (short)n.X,
            (short)n.Y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMShortN2 left, XMShortN2 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMShortN2 left, XMShortN2 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMShortN2"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMShortN2"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMShortN2 FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMShortN2"/> to a <see cref="XMVector"/>.
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
        return obj is XMShortN2 n && Equals(n);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMShortN2 other)
    {
        return x == other.x &&
               y == other.y;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1502939027;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        return hashCode;
    }
}
