// <copyright file="XMUShortN2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath.PackedVector;

/// <summary>
/// A 2D vector for storing unsigned, normalized values as unsigned 16-bit integers.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
[SkipLocalsInit]
public unsafe struct XMUShortN2 : IEquatable<XMUShortN2>
{
    /// <summary>
    /// The x-coordinate of the vector.
    /// </summary>
    private ushort x;

    /// <summary>
    /// The y-coordinate of the vector.
    /// </summary>
    private ushort y;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="packed">A packed value representing the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(uint packed)
    {
        fixed (XMUShortN2* v = &this)
        {
            *(uint*)v = packed;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="x">The x-coordinate of the vector.</param>
    /// <param name="y">The y-coordinate of the vector.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(ushort x, ushort y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(ushort[] array)
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
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(ReadOnlySpan<ushort> array)
    {
        if (array.Length != 2)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="x">The x-coordinate of the vector.</param>
    /// <param name="y">The y-coordinate of the vector.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(float x, float y)
    {
        this = new XMVector(x, y, 0.0f, 0.0f);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(float[] array)
    {
        this = XMVector.LoadFloat2(new XMFloat2(array));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShortN2"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShortN2(ReadOnlySpan<float> array)
    {
        this = XMVector.LoadFloat2(new XMFloat2(array));
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
    public ushort X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
    public ushort Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// Converts a <see cref="XMUShortN2"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMUShortN2"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMUShortN2 value)
    {
        return new XMVector(
                (float)value.x / 65535.0f,
                (float)value.y / 65535.0f,
                0.0f,
                0.0f);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUShortN2"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUShortN2"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMUShortN2(XMVector value)
    {
        XMVector n = value.Saturate();
        n = XMVector.MultiplyAdd(n, XMGlobalConstants.UShortMax, XMGlobalConstants.OneHalf);
        n = n.Truncate();

        return new XMUShortN2(
            (ushort)(short)n.X,
            (ushort)(short)n.Y);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMUShortN2 left, XMUShortN2 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMUShortN2 left, XMUShortN2 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUShortN2"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUShortN2"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMUShortN2 FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMUShortN2"/> to a <see cref="XMVector"/>.
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
        return obj is XMUShortN2 n && Equals(n);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMUShortN2 other)
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
