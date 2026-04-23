// <copyright file="D2D1Triangle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the three vertices that describe a triangle.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Triangle : IEquatable<D2D1Triangle>
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
        size += D2D1Point2F.NativeRequiredSize(3);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1Triangle obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Triangle>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Triangle> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1Point2F.NativeWriteTo(buffer, obj.point1);
            buffer += D2D1Point2F.NativeRequiredSize();
            D2D1Point2F.NativeWriteTo(buffer, obj.point2);
            buffer += D2D1Point2F.NativeRequiredSize();
            D2D1Point2F.NativeWriteTo(buffer, obj.point3);
            buffer += D2D1Point2F.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Triangle NativeReadFrom(nint buffer)
    {
        D2D1Triangle obj;
        obj.point1 = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.point2 = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.point3 = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Triangle> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The first vertex of a triangle.
    /// </summary>
    private D2D1Point2F point1;

    /// <summary>
    /// The second vertex of a triangle.
    /// </summary>
    private D2D1Point2F point2;

    /// <summary>
    /// The third vertex of a triangle.
    /// </summary>
    private D2D1Point2F point3;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Triangle"/> struct.
    /// </summary>
    /// <param name="point1">The first vertex of a triangle.</param>
    /// <param name="point2">The second vertex of a triangle.</param>
    /// <param name="point3">The third vertex of a triangle.</param>
    public D2D1Triangle(D2D1Point2F point1, D2D1Point2F point2, D2D1Point2F point3)
    {
        this.point1 = point1;
        this.point2 = point2;
        this.point3 = point3;
    }

    /// <summary>
    /// Gets or sets the first vertex of a triangle.
    /// </summary>
    public D2D1Point2F Point1
    {
        get { return this.point1; }
        set { this.point1 = value; }
    }

    /// <summary>
    /// Gets or sets the second vertex of a triangle.
    /// </summary>
    public D2D1Point2F Point2
    {
        get { return this.point2; }
        set { this.point2 = value; }
    }

    /// <summary>
    /// Gets or sets the third vertex of a triangle.
    /// </summary>
    public D2D1Point2F Point3
    {
        get { return this.point3; }
        set { this.point3 = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Triangle left, D2D1Triangle right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Triangle left, D2D1Triangle right)
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
        return obj is D2D1Triangle triangle && Equals(triangle);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Triangle other)
    {
        return point1.Equals(other.point1) &&
               point2.Equals(other.point2) &&
               point3.Equals(other.point3);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1952676455;
        hashCode = hashCode * -1521134295 + point1.GetHashCode();
        hashCode = hashCode * -1521134295 + point2.GetHashCode();
        hashCode = hashCode * -1521134295 + point3.GetHashCode();
        return hashCode;
    }
}
