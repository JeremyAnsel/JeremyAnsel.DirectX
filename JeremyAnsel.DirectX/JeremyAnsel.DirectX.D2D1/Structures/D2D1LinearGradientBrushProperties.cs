// <copyright file="D2D1LinearGradientBrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the starting point and endpoint of the gradient axis for an <see cref="D2D1LinearGradientBrush"/>.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1LinearGradientBrushProperties : IEquatable<D2D1LinearGradientBrushProperties>
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
    public static void NativeWriteTo(nint buffer, in D2D1LinearGradientBrushProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1LinearGradientBrushProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1LinearGradientBrushProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1Point2F.NativeWriteTo(buffer, obj.startPoint);
            buffer += D2D1Point2F.NativeRequiredSize();
            D2D1Point2F.NativeWriteTo(buffer, obj.endPoint);
            buffer += D2D1Point2F.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1LinearGradientBrushProperties NativeReadFrom(nint buffer)
    {
        D2D1LinearGradientBrushProperties obj;
        obj.startPoint = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.endPoint = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1LinearGradientBrushProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// In the brush's coordinate space, the starting point of the gradient axis.
    /// </summary>
    private D2D1Point2F startPoint;

    /// <summary>
    /// In the brush's coordinate space, the endpoint of the gradient axis.
    /// </summary>
    private D2D1Point2F endPoint;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1LinearGradientBrushProperties"/> struct.
    /// </summary>
    /// <param name="startPoint">The starting point of the gradient axis, in the brush's coordinate space.</param>
    /// <param name="endPoint">The endpoint of the gradient axis, in the brush's coordinate space.</param>
    public D2D1LinearGradientBrushProperties(D2D1Point2F startPoint, D2D1Point2F endPoint)
    {
        this.startPoint = startPoint;
        this.endPoint = endPoint;
    }

    /// <summary>
    /// Gets or sets the starting point of the gradient axis, in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F StartPoint
    {
        get { return this.startPoint; }
        set { this.startPoint = value; }
    }

    /// <summary>
    /// Gets or sets the endpoint of the gradient axis, in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F EndPoint
    {
        get { return this.endPoint; }
        set { this.endPoint = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1LinearGradientBrushProperties left, D2D1LinearGradientBrushProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1LinearGradientBrushProperties left, D2D1LinearGradientBrushProperties right)
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
        return obj is D2D1LinearGradientBrushProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1LinearGradientBrushProperties other)
    {
        return startPoint.Equals(other.startPoint) &&
               endPoint.Equals(other.endPoint);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -2085048181;
        hashCode = hashCode * -1521134295 + startPoint.GetHashCode();
        hashCode = hashCode * -1521134295 + endPoint.GetHashCode();
        return hashCode;
    }
}
