// <copyright file="D2D1Matrix4X3F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a 4-by-3 matrix.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Matrix4X3F : IEquatable<D2D1Matrix4X3F>
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
        size += sizeof(float) * 12;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1Matrix4X3F obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Matrix4X3F>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Matrix4X3F> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.m11);
            DXMarshal.Write(ref buffer, obj.m12);
            DXMarshal.Write(ref buffer, obj.m13);
            DXMarshal.Write(ref buffer, obj.m21);
            DXMarshal.Write(ref buffer, obj.m22);
            DXMarshal.Write(ref buffer, obj.m23);
            DXMarshal.Write(ref buffer, obj.m31);
            DXMarshal.Write(ref buffer, obj.m32);
            DXMarshal.Write(ref buffer, obj.m33);
            DXMarshal.Write(ref buffer, obj.m41);
            DXMarshal.Write(ref buffer, obj.m42);
            DXMarshal.Write(ref buffer, obj.m43);
        }
    }

    /// <summary>
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Matrix4X3F NativeReadFrom(nint buffer)
    {
        D2D1Matrix4X3F obj;
        obj.m11 = DXMarshal.ReadSingle(ref buffer);
        obj.m12 = DXMarshal.ReadSingle(ref buffer);
        obj.m13 = DXMarshal.ReadSingle(ref buffer);
        obj.m21 = DXMarshal.ReadSingle(ref buffer);
        obj.m22 = DXMarshal.ReadSingle(ref buffer);
        obj.m23 = DXMarshal.ReadSingle(ref buffer);
        obj.m31 = DXMarshal.ReadSingle(ref buffer);
        obj.m32 = DXMarshal.ReadSingle(ref buffer);
        obj.m33 = DXMarshal.ReadSingle(ref buffer);
        obj.m41 = DXMarshal.ReadSingle(ref buffer);
        obj.m42 = DXMarshal.ReadSingle(ref buffer);
        obj.m43 = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Matrix4X3F> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The value in the first row and first column of the matrix.
    /// </summary>
    private float m11;

    /// <summary>
    /// The value in the first row and second column of the matrix.
    /// </summary>
    private float m12;

    /// <summary>
    /// The value in the first row and third column of the matrix.
    /// </summary>
    private float m13;

    /// <summary>
    /// The value in the second row and first column of the matrix.
    /// </summary>
    private float m21;

    /// <summary>
    /// The value in the second row and second column of the matrix.
    /// </summary>
    private float m22;

    /// <summary>
    /// The value in the second row and third column of the matrix.
    /// </summary>
    private float m23;

    /// <summary>
    /// The value in the third row and first column of the matrix.
    /// </summary>
    private float m31;

    /// <summary>
    /// The value in the third row and second column of the matrix.
    /// </summary>
    private float m32;

    /// <summary>
    /// The value in the third row and third column of the matrix.
    /// </summary>
    private float m33;

    /// <summary>
    /// The value in the fourth row and first column of the matrix.
    /// </summary>
    private float m41;

    /// <summary>
    /// The value in the fourth row and second column of the matrix.
    /// </summary>
    private float m42;

    /// <summary>
    /// The value in the fourth row and third column of the matrix.
    /// </summary>
    private float m43;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m11"></param>
    /// <param name="m12"></param>
    /// <param name="m13"></param>
    /// <param name="m21"></param>
    /// <param name="m22"></param>
    /// <param name="m23"></param>
    /// <param name="m31"></param>
    /// <param name="m32"></param>
    /// <param name="m33"></param>
    /// <param name="m41"></param>
    /// <param name="m42"></param>
    /// <param name="m43"></param>
    public D2D1Matrix4X3F(
        float m11,
        float m12,
        float m13,
        float m21,
        float m22,
        float m23,
        float m31,
        float m32,
        float m33,
        float m41,
        float m42,
        float m43
        )
    {
        this.m11 = m11;
        this.m12 = m12;
        this.m13 = m13;
        this.m21 = m21;
        this.m22 = m22;
        this.m23 = m23;
        this.m31 = m31;
        this.m32 = m32;
        this.m33 = m33;
        this.m41 = m41;
        this.m42 = m42;
        this.m43 = m43;
    }

    /// <summary>
    /// Gets or sets the value in the first row and first column of the matrix.
    /// </summary>
    public float M11
    {
        get { return this.m11; }
        set { this.m11 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the first row and second column of the matrix.
    /// </summary>
    public float M12
    {
        get { return this.m12; }
        set { this.m12 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the first row and third column of the matrix.
    /// </summary>
    public float M13
    {
        get { return this.m13; }
        set { this.m13 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the second row and first column of the matrix.
    /// </summary>
    public float M21
    {
        get { return this.m21; }
        set { this.m21 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the second row and second column of the matrix.
    /// </summary>
    public float M22
    {
        get { return this.m22; }
        set { this.m22 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the second row and third column of the matrix.
    /// </summary>
    public float M23
    {
        get { return this.m23; }
        set { this.m23 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the third row and first column of the matrix.
    /// </summary>
    public float M31
    {
        get { return this.m31; }
        set { this.m31 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the third row and second column of the matrix.
    /// </summary>
    public float M32
    {
        get { return this.m32; }
        set { this.m32 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the third row and third column of the matrix.
    /// </summary>
    public float M33
    {
        get { return this.m33; }
        set { this.m33 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fourth row and first column of the matrix.
    /// </summary>
    public float M41
    {
        get { return this.m41; }
        set { this.m41 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fourth row and second column of the matrix.
    /// </summary>
    public float M42
    {
        get { return this.m42; }
        set { this.m42 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fourth row and third column of the matrix.
    /// </summary>
    public float M43
    {
        get { return this.m43; }
        set { this.m43 = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Matrix4X3F left, D2D1Matrix4X3F right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Matrix4X3F left, D2D1Matrix4X3F right)
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
        return obj is D2D1Matrix4X3F f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Matrix4X3F other)
    {
        return m11 == other.m11 &&
               m12 == other.m12 &&
               m13 == other.m13 &&
               m21 == other.m21 &&
               m22 == other.m22 &&
               m23 == other.m23 &&
               m31 == other.m31 &&
               m32 == other.m32 &&
               m33 == other.m33 &&
               m41 == other.m41 &&
               m42 == other.m42 &&
               m43 == other.m43;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1053303246;
        hashCode = hashCode * -1521134295 + m11.GetHashCode();
        hashCode = hashCode * -1521134295 + m12.GetHashCode();
        hashCode = hashCode * -1521134295 + m13.GetHashCode();
        hashCode = hashCode * -1521134295 + m21.GetHashCode();
        hashCode = hashCode * -1521134295 + m22.GetHashCode();
        hashCode = hashCode * -1521134295 + m23.GetHashCode();
        hashCode = hashCode * -1521134295 + m31.GetHashCode();
        hashCode = hashCode * -1521134295 + m32.GetHashCode();
        hashCode = hashCode * -1521134295 + m33.GetHashCode();
        hashCode = hashCode * -1521134295 + m41.GetHashCode();
        hashCode = hashCode * -1521134295 + m42.GetHashCode();
        hashCode = hashCode * -1521134295 + m43.GetHashCode();
        return hashCode;
    }
}
