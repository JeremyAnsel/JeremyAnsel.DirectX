// <copyright file="D2D1RectF.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a rectangle defined by the coordinates of the upper-left corner (left, top) and the coordinates of the lower-right corner (right, bottom).
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1RectF : IEquatable<D2D1RectF>
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
        size += sizeof(float) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1RectF obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1RectF>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1RectF> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.left);
            DXMarshal.Write(ref buffer, obj.top);
            DXMarshal.Write(ref buffer, obj.right);
            DXMarshal.Write(ref buffer, obj.bottom);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1RectF NativeReadFrom(nint buffer)
    {
        D2D1RectF obj;
        obj.left = DXMarshal.ReadSingle(ref buffer);
        obj.top = DXMarshal.ReadSingle(ref buffer);
        obj.right = DXMarshal.ReadSingle(ref buffer);
        obj.bottom = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1RectF> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The x-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    private float left;

    /// <summary>
    /// The y-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    private float top;

    /// <summary>
    /// The x-coordinate of the lower-right corner of the rectangle.
    /// </summary>
    private float right;

    /// <summary>
    /// The y-coordinate of the lower-right corner of the rectangle.
    /// </summary>
    private float bottom;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RectF"/> struct.
    /// </summary>
    /// <param name="left">The x-coordinate of the upper-left corner of the rectangle.</param>
    /// <param name="top">The y-coordinate of the upper-left corner of the rectangle.</param>
    /// <param name="right">The x-coordinate of the lower-right corner of the rectangle.</param>
    /// <param name="bottom">The y-coordinate of the lower-right corner of the rectangle.</param>
    public D2D1RectF(float left, float top, float right, float bottom)
    {
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
    }

    /// <summary>
    /// Gets an infinite rectangle.
    /// </summary>
    public static D2D1RectF Infinite
    {
        get { return new D2D1RectF(float.MinValue, float.MinValue, float.MaxValue, float.MaxValue); }
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public float Left
    {
        get { return this.left; }
        set { this.left = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the upper-left corner of the rectangle.
    /// </summary>
    public float Top
    {
        get { return this.top; }
        set { this.top = value; }
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the lower-right corner of the rectangle.
    /// </summary>
    public float Right
    {
        get { return this.right; }
        set { this.right = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the lower-right corner of the rectangle.
    /// </summary>
    public float Bottom
    {
        get { return this.bottom; }
        set { this.bottom = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1RectF left, D2D1RectF right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1RectF left, D2D1RectF right)
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
        return obj is D2D1RectF f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1RectF other)
    {
        return left == other.left &&
               top == other.top &&
               right == other.right &&
               bottom == other.bottom;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -971476797;
        hashCode = hashCode * -1521134295 + left.GetHashCode();
        hashCode = hashCode * -1521134295 + top.GetHashCode();
        hashCode = hashCode * -1521134295 + right.GetHashCode();
        hashCode = hashCode * -1521134295 + bottom.GetHashCode();
        return hashCode;
    }
}
