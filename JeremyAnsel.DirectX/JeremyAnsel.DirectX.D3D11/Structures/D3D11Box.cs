// <copyright file="D3D11Box.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Defines a 3D box.
/// </summary>
[SkipLocalsInit]
public unsafe struct D3D11Box : IEquatable<D3D11Box>
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
        size += sizeof(uint) * 6;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D3D11Box obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D3D11Box>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D3D11Box> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.left);
            DXMarshal.Write(ref buffer, obj.top);
            DXMarshal.Write(ref buffer, obj.front);
            DXMarshal.Write(ref buffer, obj.right);
            DXMarshal.Write(ref buffer, obj.bottom);
            DXMarshal.Write(ref buffer, obj.back);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D3D11Box NativeReadFrom(nint buffer)
    {
        D3D11Box obj;
        obj.left = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.top = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.front = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.right = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.bottom = DXMarshal.ReadUnsignedInt32(ref buffer);
        obj.back = DXMarshal.ReadUnsignedInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D3D11Box> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The x position of the left hand side of the box.
    /// </summary>
    private uint left;

    /// <summary>
    /// The y position of the top of the box.
    /// </summary>
    private uint top;

    /// <summary>
    /// The z position of the front of the box.
    /// </summary>
    private uint front;

    /// <summary>
    /// The x position of the right hand side of the box.
    /// </summary>
    private uint right;

    /// <summary>
    /// The y position of the bottom of the box.
    /// </summary>
    private uint bottom;

    /// <summary>
    /// The z position of the back of the box.
    /// </summary>
    private uint back;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Box"/> struct.
    /// </summary>
    /// <param name="left">The x position of the left hand side of the box.</param>
    /// <param name="top">The y position of the top of the box.</param>
    /// <param name="front">The z position of the front of the box.</param>
    /// <param name="right">The x position of the right hand side of the box.</param>
    /// <param name="bottom">The y position of the bottom of the box.</param>
    /// <param name="back">The z position of the back of the box.</param>
    public D3D11Box(uint left, uint top, uint front, uint right, uint bottom, uint back)
    {
        this.left = left;
        this.top = top;
        this.front = front;
        this.right = right;
        this.bottom = bottom;
        this.back = back;
    }

    /// <summary>
    /// Gets or sets the x position of the left hand side of the box.
    /// </summary>
    public uint Left
    {
        get { return this.left; }
        set { this.left = value; }
    }

    /// <summary>
    /// Gets or sets the y position of the top of the box.
    /// </summary>
    public uint Top
    {
        get { return this.top; }
        set { this.top = value; }
    }

    /// <summary>
    /// Gets or sets the z position of the front of the box.
    /// </summary>
    public uint Front
    {
        get { return this.front; }
        set { this.front = value; }
    }

    /// <summary>
    /// Gets or sets the x position of the right hand side of the box.
    /// </summary>
    public uint Right
    {
        get { return this.right; }
        set { this.right = value; }
    }

    /// <summary>
    /// Gets or sets the y position of the bottom of the box.
    /// </summary>
    public uint Bottom
    {
        get { return this.bottom; }
        set { this.bottom = value; }
    }

    /// <summary>
    /// Gets or sets the z position of the back of the box.
    /// </summary>
    public uint Back
    {
        get { return this.back; }
        set { this.back = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D3D11Box left, D3D11Box right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D3D11Box left, D3D11Box right)
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
        return obj is D3D11Box box && Equals(box);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D3D11Box other)
    {
        return left == other.left &&
               top == other.top &&
               front == other.front &&
               right == other.right &&
               bottom == other.bottom &&
               back == other.back;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1435850453;
        hashCode = hashCode * -1521134295 + left.GetHashCode();
        hashCode = hashCode * -1521134295 + top.GetHashCode();
        hashCode = hashCode * -1521134295 + front.GetHashCode();
        hashCode = hashCode * -1521134295 + right.GetHashCode();
        hashCode = hashCode * -1521134295 + bottom.GetHashCode();
        hashCode = hashCode * -1521134295 + back.GetHashCode();
        return hashCode;
    }
}
