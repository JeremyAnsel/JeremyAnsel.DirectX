// <copyright file="D3D11Rect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Defines the coordinates of the upper-left and lower-right corners of a rectangle.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Rect : IEquatable<D3D11Rect>
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
        size += sizeof(int) * 4;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Rect obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Rect>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Rect> objects)
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
    public static D3D11Rect NativeReadFrom(nint buffer)
    {
        D3D11Rect obj;
        obj.left = DXMarshal.ReadInt32(ref buffer);
        obj.top = DXMarshal.ReadInt32(ref buffer);
        obj.right = DXMarshal.ReadInt32(ref buffer);
        obj.bottom = DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Rect> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The x-coordinate of the upper-left corner of a rectangle.
    /// </summary>
    private int left;

    /// <summary>
    /// The y-coordinate of the upper-left corner of a rectangle.
    /// </summary>
    private int top;

    /// <summary>
    /// The x-coordinate of the lower-right corner of a rectangle.
    /// </summary>
    private int right;

    /// <summary>
    /// The y-coordinate of the lower-right corner of a rectangle.
    /// </summary>
    private int bottom;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Rect"/> struct.
    /// </summary>
    /// <param name="left">The x-coordinate of the upper-left corner of a rectangle.</param>
    /// <param name="top">The y-coordinate of the upper-left corner of a rectangle.</param>
    /// <param name="right">The x-coordinate of the lower-right corner of a rectangle.</param>
    /// <param name="bottom">The y-coordinate of the lower-right corner of a rectangle.</param>
    public D3D11Rect(int left, int top, int right, int bottom)
    {
        this.left = left;
        this.top = top;
        this.right = right;
        this.bottom = bottom;
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the upper-left corner of a rectangle.
    /// </summary>
    public int Left
    {
        get { return this.left; }
        set { this.left = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the upper-left corner of a rectangle.
    /// </summary>
    public int Top
    {
        get { return this.top; }
        set { this.top = value; }
    }

    /// <summary>
    /// Gets or sets the x-coordinate of the lower-right corner of a rectangle.
    /// </summary>
    public int Right
    {
        get { return this.right; }
        set { this.right = value; }
    }

    /// <summary>
    /// Gets or sets the y-coordinate of the lower-right corner of a rectangle.
    /// </summary>
    public int Bottom
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
    public static bool operator ==(D3D11Rect left, D3D11Rect right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Rect left, D3D11Rect right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string that represents the current object.
    /// </summary>
    /// <returns>A string that represents the current object.</returns>
    public readonly override string ToString()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0};{1};{2};{3}",
            this.left,
            this.top,
            this.right,
            this.bottom);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is D3D11Rect rect && Equals(rect);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Rect other)
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
