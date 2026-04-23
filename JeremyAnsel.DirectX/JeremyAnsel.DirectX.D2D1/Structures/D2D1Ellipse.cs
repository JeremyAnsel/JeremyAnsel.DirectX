// <copyright file="D2D1Ellipse.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the center point, x-radius, and y-radius of an ellipse.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Ellipse : IEquatable<D2D1Ellipse>
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
        size += D2D1Point2F.NativeRequiredSize();
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1Ellipse obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Ellipse>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Ellipse> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1Point2F.NativeWriteTo(buffer, obj.point);
            buffer += D2D1Point2F.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.radiusX);
            DXMarshal.Write(ref buffer, obj.radiusY);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Ellipse NativeReadFrom(nint buffer)
    {
        D2D1Ellipse obj;
        obj.point = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.radiusX = DXMarshal.ReadSingle(ref buffer);
        obj.radiusY = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Ellipse> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The center point of the ellipse.
    /// </summary>
    private D2D1Point2F point;

    /// <summary>
    /// The X-radius of the ellipse.
    /// </summary>
    private float radiusX;

    /// <summary>
    /// The Y-radius of the ellipse.
    /// </summary>
    private float radiusY;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Ellipse"/> struct.
    /// </summary>
    /// <param name="point">The center point of the ellipse.</param>
    /// <param name="radiusX">The X-radius of the ellipse.</param>
    /// <param name="radiusY">The Y-radius of the ellipse.</param>
    public D2D1Ellipse(D2D1Point2F point, float radiusX, float radiusY)
    {
        this.point = point;
        this.radiusX = radiusX;
        this.radiusY = radiusY;
    }

    /// <summary>
    /// Gets or sets the center point of the ellipse.
    /// </summary>
    public D2D1Point2F Point
    {
        get { return this.point; }
        set { this.point = value; }
    }

    /// <summary>
    /// Gets or sets the X-radius of the ellipse.
    /// </summary>
    public float RadiusX
    {
        get { return this.radiusX; }
        set { this.radiusX = value; }
    }

    /// <summary>
    /// Gets or sets the Y-radius of the ellipse.
    /// </summary>
    public float RadiusY
    {
        get { return this.radiusY; }
        set { this.radiusY = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Ellipse left, D2D1Ellipse right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Ellipse left, D2D1Ellipse right)
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
        return obj is D2D1Ellipse ellipse && Equals(ellipse);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Ellipse other)
    {
        return point.Equals(other.point) &&
               radiusX == other.radiusX &&
               radiusY == other.radiusY;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1783978776;
        hashCode = hashCode * -1521134295 + point.GetHashCode();
        hashCode = hashCode * -1521134295 + radiusX.GetHashCode();
        hashCode = hashCode * -1521134295 + radiusY.GetHashCode();
        return hashCode;
    }
}
