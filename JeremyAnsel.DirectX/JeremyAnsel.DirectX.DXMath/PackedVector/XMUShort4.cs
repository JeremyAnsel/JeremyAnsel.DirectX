// <copyright file="XMUShort4.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DXMath.PackedVector;

/// <summary>
/// A 4D vector consisting of 16-bit unsigned integer components.
/// </summary>
[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "XMU", Justification = "Reviewed")]
[SkipLocalsInit]
public unsafe struct XMUShort4 : IEquatable<XMUShort4>
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
    /// The z-coordinate of the vector.
    /// </summary>
    private ushort z;

    /// <summary>
    /// The w-coordinate of the vector.
    /// </summary>
    private ushort w;

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
    /// </summary>
    /// <param name="packed">A packed value representing the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShort4(ulong packed)
    {
        fixed (XMUShort4* v = &this)
        {
            *(ulong*)v = packed;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
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
    public XMUShort4(ushort x, ushort y, ushort z, ushort w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShort4(ushort[] array)
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
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShort4(ReadOnlySpan<ushort> array)
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
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
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
    public XMUShort4(float x, float y, float z, float w)
    {
        this = new XMVector(x, y, z, w);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShort4(float[] array)
    {
        this = XMVector.LoadFloat4(new XMFloat4(array));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XMUShort4"/> struct.
    /// </summary>
    /// <param name="array">The components of the vector.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public XMUShort4(ReadOnlySpan<float> array)
    {
        this = XMVector.LoadFloat4(new XMFloat4(array));
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
    /// Gets or sets the y-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Y", Justification = "Reviewed")]
    public ushort Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// Gets or sets the z-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Z", Justification = "Reviewed")]
    public ushort Z
    {
        get { return this.z; }
        set { this.z = value; }
    }

    /// <summary>
    /// Gets or sets the w-coordinate of the vector.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "W", Justification = "Reviewed")]
    public ushort W
    {
        get { return this.w; }
        set { this.w = value; }
    }

    /// <summary>
    /// Converts a <see cref="XMUShort4"/> to a <see cref="XMVector"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMUShort4"/>.</param>
    /// <returns>A <see cref="XMVector"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMVector(XMUShort4 value)
    {
        return new XMVector(
            (float)value.x,
            (float)value.y,
            (float)value.z,
            (float)value.w);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUShort4"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUShort4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [SuppressMessage("Usage", "CA2225:Les surcharges d'opérateur offrent d'autres méthodes nommées", Justification = "Reviewed.")]
    public static implicit operator XMUShort4(XMVector value)
    {
        XMVector n = value.Clamp(XMGlobalConstants.Zero, XMGlobalConstants.UShortMax);
        n = n.Round();

        return new XMUShort4(
            (ushort)(short)n.X,
            (ushort)(short)n.Y,
            (ushort)(short)n.Z,
            (ushort)(short)n.W);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(XMUShort4 left, XMUShort4 right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(XMUShort4 left, XMUShort4 right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Converts a <see cref="XMVector"/> to a <see cref="XMUShort4"/>.
    /// </summary>
    /// <param name="value">A <see cref="XMVector"/>.</param>
    /// <returns>A <see cref="XMUShort4"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static XMUShort4 FromVector(XMVector value)
    {
        return value;
    }

    /// <summary>
    /// Converts a <see cref="XMUShort4"/> to a <see cref="XMVector"/>.
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
        return obj is XMUShort4 @short && Equals(@short);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(XMUShort4 other)
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
