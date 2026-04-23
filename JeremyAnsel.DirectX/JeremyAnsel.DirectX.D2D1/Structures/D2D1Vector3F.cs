// <copyright file="D2D1Vector3F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// A vector of 3 FLOAT values (x, y, z).
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Vector3F : IEquatable<D2D1Vector3F>
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
        size += sizeof(float) * 3;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1Vector3F obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Vector3F>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Vector3F> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.x);
            DXMarshal.Write(ref buffer, obj.y);
            DXMarshal.Write(ref buffer, obj.z);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Vector3F NativeReadFrom(nint buffer)
    {
        D2D1Vector3F obj;
        obj.x = DXMarshal.ReadSingle(ref buffer);
        obj.y = DXMarshal.ReadSingle(ref buffer);
        obj.z = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Vector3F> objects)
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
    /// Initializes a new instance of the <see cref="D2D1Vector3F"/> struct.
    /// </summary>
    /// <param name="x">The x value of the vector.</param>
    /// <param name="y">The y value of the vector.</param>
    /// <param name="z">The z value of the vector.</param>
    public D2D1Vector3F(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
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
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Vector3F left, D2D1Vector3F right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Vector3F left, D2D1Vector3F right)
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
        return obj is D2D1Vector3F f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Vector3F other)
    {
        return x == other.x &&
               y == other.y &&
               z == other.z;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 373119288;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + z.GetHashCode();
        return hashCode;
    }
}
