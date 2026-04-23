// <copyright file="XMInt3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath;

/// <summary>
/// A 3D vector where each component is a signed integer.
/// </summary>
[SkipLocalsInit]
public struct XMInt3 : IFormattable, IEquatable<XMInt3>
{
    /// <summary>
    /// The x-coordinate of the vector.
    /// </summary>
    private int x;

    /// <summary>
    /// The y-coordinate of the vector.
    /// </summary>
    private int y;

    /// <summary>
    /// The z-coordinate of the vector.
    /// </summary>
    private int z;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMInt3"/> struct.
    /// </summary>
    /// <param name="x">The x-coordinate of the vector.</param>
    /// <param name="y">The y-coordinate of the vector.</param>
    /// <param name="z">The z-coordinate of the vector.</param>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "x", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "y", Justification = "Reviewed")]
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "z", Justification = "Reviewed")]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMInt3(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMInt3"/> struct.
    /// </summary>
    /// <param name="array">The components of the array.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMInt3(int[]? array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (array.Length != 3)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
        this.z = array[2];
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMInt3"/> struct.
    /// </summary>
    /// <param name="array">The components of the array.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMInt3(ReadOnlySpan<int> array)
    {
        if (array.Length != 3)
        {
            throw new ArgumentOutOfRangeException(nameof(array));
        }

        this.x = array[0];
        this.y = array[1];
        this.z = array[2];
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "X", Justification = "Reviewed")]
    public int X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
    public int Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// Gets or sets the z-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
    public int Z
    {
        get { return this.z; }
        set { this.z = value; }
    }

    /// <summary>
    /// Converts a <see cref="XMInt3"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMInt3"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMInt3 value)
    {
        return XMVector.LoadSInt3(value);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMInt3"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMInt3"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMInt3(XMVector value)
    {
        value.StoreSInt3(out XMInt3 ret);
        return ret;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMInt3 left, XMInt3 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMInt3 left, XMInt3 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMInt3"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMInt3"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMInt3 FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMInt3"/> to a <see cref="XMVector"/>.
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
        return obj is XMInt3 @int && Equals(@int);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMInt3 other)
    {
        return x == other.x &&
               y == other.y &&
               z == other.z;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 373119288;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        return hashCode;
    }
}
