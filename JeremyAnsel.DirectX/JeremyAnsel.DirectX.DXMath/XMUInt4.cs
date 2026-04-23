// <copyright file="XMUInt4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath;

/// <summary>
/// A 4D vector where each component is an unsigned integer.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
[SkipLocalsInit]
public struct XMUInt4 : IFormattable, IEquatable<XMUInt4>
{
    /// <summary>
    /// The x-coordinate of the vector.
    /// </summary>
    private uint x;

    /// <summary>
    /// The y-coordinate of the vector.
    /// </summary>
    private uint y;

    /// <summary>
    /// The z-coordinate of the vector.
    /// </summary>
    private uint z;

    /// <summary>
    /// The w-coordinate of the vector.
    /// </summary>
    private uint w;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUInt4"/> struct.
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
    public XMUInt4(uint x, uint y, uint z, uint w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUInt4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUInt4(uint[]? array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
        this.z = array[2];
        this.w = array[3];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUInt4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUInt4(ReadOnlySpan<uint> array)
    {
        if (array.Length != 4)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
        this.z = array[2];
        this.w = array[3];
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
    public uint X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
    public uint Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// Gets or sets the z-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
    public uint Z
    {
        get { return this.z; }
        set { this.z = value; }
    }

    /// <summary>
    /// Gets or sets the w-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
    public uint W
    {
        get { return this.w; }
        set { this.w = value; }
    }

    /// <summary>
    /// Converts a <see cref="XMUInt4"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMUInt4"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMUInt4 value)
    {
        return XMVector.LoadUInt4(value);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUInt4"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUInt4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMUInt4(XMVector value)
    {
        value.StoreUInt4(out XMUInt4 ret);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMUInt4 left, XMUInt4 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMUInt4 left, XMUInt4 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUInt4"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUInt4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMUInt4 FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMUInt4"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMVector ToVector()
    {
        return this;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return ToString(null, CultureInfo.InvariantCulture);
    }

    /// <inheritdoc/>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return string.Concat(
            "(",
            x.ToString(format, formatProvider),
            ";",
            y.ToString(format, formatProvider),
            ";",
            z.ToString(format, formatProvider),
            ";",
            w.ToString(format, formatProvider),
            ")"
            );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is XMUInt4 @int && Equals(@int);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMUInt4 other)
    {
        return x == other.x &&
               y == other.y &&
               z == other.z &&
               w == other.w;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1743314642;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        hashCode = hashCode * -1521134295 + w.GetHashCode();
        return hashCode;
    }
}
