// <copyright file="D2D1SizeF.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Stores an ordered pair of floats, typically the width and height of a rectangle.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1SizeF : IEquatable<D2D1SizeF>
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
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1SizeF obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1SizeF>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1SizeF> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.width);
            DXMarshal.Write(ref buffer, obj.height);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1SizeF NativeReadFrom(nint buffer)
    {
        D2D1SizeF obj;
        obj.width = DXMarshal.ReadSingle(ref buffer);
        obj.height = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1SizeF> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The horizontal component of this size.
    /// </summary>
    private float width;

    /// <summary>
    /// The vertical component of this size.
    /// </summary>
    private float height;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1SizeF"/> struct.
    /// </summary>
    /// <param name="width">The horizontal component of this size.</param>
    /// <param name="height">The vertical component of this size.</param>
    public D2D1SizeF(float width, float height)
    {
        this.width = width;
        this.height = height;
    }

    /// <summary>
    /// Gets or sets the horizontal component of this size.
    /// </summary>
    public float Width
    {
        get { return this.width; }
        set { this.width = value; }
    }

    /// <summary>
    /// Gets or sets the vertical component of this size.
    /// </summary>
    public float Height
    {
        get { return this.height; }
        set { this.height = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1SizeF left, D2D1SizeF right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1SizeF left, D2D1SizeF right)
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
        return obj is D2D1SizeF f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1SizeF other)
    {
        return width == other.width &&
               height == other.height;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1263118649;
        hashCode = hashCode * -1521134295 + width.GetHashCode();
        hashCode = hashCode * -1521134295 + height.GetHashCode();
        return hashCode;
    }
}
