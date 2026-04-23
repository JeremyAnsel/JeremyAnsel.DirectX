// <copyright file="D2D1Vector4F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// A vector of 4 FLOAT values (x, y, z, w).
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Vector4F : IEquatable<D2D1Vector4F>
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
    public static void NativeWriteTo(nint buffer, in D2D1Vector4F obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Vector4F>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Vector4F> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.x);
            DXMarshal.Write(ref buffer, obj.y);
            DXMarshal.Write(ref buffer, obj.z);
            DXMarshal.Write(ref buffer, obj.w);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Vector4F NativeReadFrom(nint buffer)
    {
        D2D1Vector4F obj;
        obj.x = DXMarshal.ReadSingle(ref buffer);
        obj.y = DXMarshal.ReadSingle(ref buffer);
        obj.z = DXMarshal.ReadSingle(ref buffer);
        obj.w = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Vector4F> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The x value of the vector.
    /// </summary>
    private float x;

    /// <summary>
    /// The y value of the vector.
    /// </summary>
    private float y;

    /// <summary>
    /// The z value of the vector.
    /// </summary>
    private float z;

    /// <summary>
    /// The w value of the vector.
    /// </summary>
    private float w;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Vector4F"/> struct.
    /// </summary>
    /// <param name="x">The x value of the vector.</param>
    /// <param name="y">The y value of the vector.</param>
    /// <param name="z">The z value of the vector.</param>
    /// <param name="w">The w value of the vector.</param>
    public D2D1Vector4F(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;
    }

    /// <summary>
    /// Gets or sets the x value of the vector.
    /// </summary>
    public float X
    {
        get { return this.x; }
        set { this.x = value; }
    }

    /// <summary>
    /// Gets or sets the y value of the vector.
    /// </summary>
    public float Y
    {
        get { return this.y; }
        set { this.y = value; }
    }

    /// <summary>
    /// Gets or sets the z value of the vector.
    /// </summary>
    public float Z
    {
        get { return this.z; }
        set { this.z = value; }
    }

    /// <summary>
    /// Gets or sets the w value of the vector.
    /// </summary>
    public float W
    {
        get { return this.w; }
        set { this.w = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Vector4F left, D2D1Vector4F right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Vector4F left, D2D1Vector4F right)
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
        return obj is D2D1Vector4F f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Vector4F other)
    {
        return x == other.x &&
               y == other.y &&
               z == other.z &&
               w == other.w;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1743314642;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        hashCode = hashCode * -1521134295 + w.GetHashCode();
        return hashCode;
    }
}
