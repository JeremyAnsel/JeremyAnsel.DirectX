// <copyright file="D2D1Point2U.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents an x-coordinate and y-coordinate pair in two-dimensional space.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Point2U : IEquatable<D2D1Point2U>
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
    public static void NativeWriteTo(nint buffer, in D2D1Point2U obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Point2U>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Point2U> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.x);
            DXMarshal.Write(ref buffer, obj.y);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Point2U NativeReadFrom(nint buffer)
    {
        D2D1Point2U obj;
        obj.x = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.y = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Point2U> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The x-coordinate of the point.
    /// </summary>
    private uint x;

    /// <summary>
    /// The y-coordinate of the point.
    /// </summary>
    private uint y;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Point2U"/> struct.
    /// </summary>
    /// <param name="x">The x-coordinate of the point.</param>
    /// <param name="y">The y-coordinate of the point.</param>
    public D2D1Point2U(uint x, uint y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the point.
    /// </summary>
    public uint X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the point.
    /// </summary>
    public uint Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Point2U left, D2D1Point2U right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Point2U left, D2D1Point2U right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is D2D1Point2U u && Equals(u);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Point2U other)
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
