// <copyright file="D2D1RoundedRect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the dimensions and corner radii of a rounded rectangle.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1RoundedRect : IEquatable<D2D1RoundedRect>
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
        size += D2D1RectF.NativeRequiredSize();
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1RoundedRect obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1RoundedRect>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1RoundedRect> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1RectF.NativeWriteTo(buffer, obj.rect);
            buffer += D2D1RectF.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.radiusX);
            DXMarshal.Write(ref buffer, obj.radiusY);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1RoundedRect NativeReadFrom(nint buffer)
    {
        D2D1RoundedRect obj;
        obj.rect = D2D1RectF.NativeReadFrom(buffer);
        buffer += D2D1RectF.NativeRequiredSize();
        obj.radiusX = DXMarshal.ReadSingle(ref buffer);
        obj.radiusY = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1RoundedRect> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The coordinates of the rectangle.
    /// </summary>
    private D2D1RectF rect;

    /// <summary>
    /// The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
    /// </summary>
    private float radiusX;

    /// <summary>
    /// The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
    /// </summary>
    private float radiusY;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RoundedRect"/> struct.
    /// </summary>
    /// <param name="rect">The coordinates of the rectangle.</param>
    /// <param name="radiusX">The x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</param>
    /// <param name="radiusY">The y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.</param>
    public D2D1RoundedRect(D2D1RectF rect, float radiusX, float radiusY)
    {
        this.rect = rect;
        this.radiusX = radiusX;
        this.radiusY = radiusY;
    }

    /// <summary>
    /// Gets or sets the coordinates of the rectangle.
    /// </summary>
    public D2D1RectF Rect
    {
        get { return this.rect; }
        set { this.rect = value; }
    }

    /// <summary>
    /// Gets or sets the x-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
    /// </summary>
    public float RadiusX
    {
        get { return this.radiusX; }
        set { this.radiusX = value; }
    }

    /// <summary>
    /// Gets or sets the y-radius for the quarter ellipse that is drawn to replace every corner of the rectangle.
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
    public static bool operator ==(D2D1RoundedRect left, D2D1RoundedRect right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1RoundedRect left, D2D1RoundedRect right)
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
        return obj is D2D1RoundedRect rect && Equals(rect);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1RoundedRect other)
    {
        return rect.Equals(other.rect) &&
               radiusX == other.radiusX &&
               radiusY == other.radiusY;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -697631250;
        hashCode = hashCode * -1521134295 + rect.GetHashCode();
        hashCode = hashCode * -1521134295 + radiusX.GetHashCode();
        hashCode = hashCode * -1521134295 + radiusY.GetHashCode();
        return hashCode;
    }
}
