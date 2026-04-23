// <copyright file="D2D1QuadraticBezierSegment.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the control point and end point for a quadratic Bezier segment.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1QuadraticBezierSegment : IEquatable<D2D1QuadraticBezierSegment>
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
        size += D2D1Point2F.NativeRequiredSize(2);
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1QuadraticBezierSegment obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1QuadraticBezierSegment>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1QuadraticBezierSegment> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1Point2F.NativeWriteTo(buffer, obj.point1);
            buffer += D2D1Point2F.NativeRequiredSize();
            D2D1Point2F.NativeWriteTo(buffer, obj.point2);
            buffer += D2D1Point2F.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1QuadraticBezierSegment NativeReadFrom(nint buffer)
    {
        D2D1QuadraticBezierSegment obj;
        obj.point1 = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.point2 = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1QuadraticBezierSegment> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The control point of the quadratic Bezier segment.
    /// </summary>
    private D2D1Point2F point1;

    /// <summary>
    /// The end point of the quadratic Bezier segment.
    /// </summary>
    private D2D1Point2F point2;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1QuadraticBezierSegment"/> struct.
    /// </summary>
    /// <param name="point1">The control point of the quadratic Bezier segment.</param>
    /// <param name="point2">The end point of the quadratic Bezier segment.</param>
    public D2D1QuadraticBezierSegment(D2D1Point2F point1, D2D1Point2F point2)
    {
        this.point1 = point1;
        this.point2 = point2;
    }

    /// <summary>
    /// Gets or sets the control point of the quadratic Bezier segment.
    /// </summary>
    public D2D1Point2F Point1
    {
        get { return this.point1; }
        set { this.point1 = value; }
    }

    /// <summary>
    /// Gets or sets the end point of the quadratic Bezier segment.
    /// </summary>
    public D2D1Point2F Point2
    {
        get { return this.point2; }
        set { this.point2 = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1QuadraticBezierSegment left, D2D1QuadraticBezierSegment right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1QuadraticBezierSegment left, D2D1QuadraticBezierSegment right)
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
        return obj is D2D1QuadraticBezierSegment segment && Equals(segment);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1QuadraticBezierSegment other)
    {
        return point1.Equals(other.point1) &&
               point2.Equals(other.point2);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -305700999;
        hashCode = hashCode * -1521134295 + point1.GetHashCode();
        hashCode = hashCode * -1521134295 + point2.GetHashCode();
        return hashCode;
    }
}
