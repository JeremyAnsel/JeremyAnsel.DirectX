// <copyright file="D2D1Matrix5X4F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a 5-by-4 matrix.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1Matrix5X4F : IEquatable<D2D1Matrix5X4F>
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
        size += sizeof(float) * 20;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1Matrix5X4F obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1Matrix5X4F>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1Matrix5X4F> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.m11);
            DXMarshal.Write(ref buffer, obj.m12);
            DXMarshal.Write(ref buffer, obj.m13);
            DXMarshal.Write(ref buffer, obj.m14);
            DXMarshal.Write(ref buffer, obj.m21);
            DXMarshal.Write(ref buffer, obj.m22);
            DXMarshal.Write(ref buffer, obj.m23);
            DXMarshal.Write(ref buffer, obj.m24);
            DXMarshal.Write(ref buffer, obj.m31);
            DXMarshal.Write(ref buffer, obj.m32);
            DXMarshal.Write(ref buffer, obj.m33);
            DXMarshal.Write(ref buffer, obj.m34);
            DXMarshal.Write(ref buffer, obj.m41);
            DXMarshal.Write(ref buffer, obj.m42);
            DXMarshal.Write(ref buffer, obj.m43);
            DXMarshal.Write(ref buffer, obj.m44);
            DXMarshal.Write(ref buffer, obj.m51);
            DXMarshal.Write(ref buffer, obj.m52);
            DXMarshal.Write(ref buffer, obj.m53);
            DXMarshal.Write(ref buffer, obj.m54);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1Matrix5X4F NativeReadFrom(nint buffer)
    {
        D2D1Matrix5X4F obj;
        obj.m11 = DXMarshal.ReadSingle(ref buffer);
        obj.m12 = DXMarshal.ReadSingle(ref buffer);
        obj.m13 = DXMarshal.ReadSingle(ref buffer);
        obj.m14 = DXMarshal.ReadSingle(ref buffer);
        obj.m21 = DXMarshal.ReadSingle(ref buffer);
        obj.m22 = DXMarshal.ReadSingle(ref buffer);
        obj.m23 = DXMarshal.ReadSingle(ref buffer);
        obj.m24 = DXMarshal.ReadSingle(ref buffer);
        obj.m31 = DXMarshal.ReadSingle(ref buffer);
        obj.m32 = DXMarshal.ReadSingle(ref buffer);
        obj.m33 = DXMarshal.ReadSingle(ref buffer);
        obj.m34 = DXMarshal.ReadSingle(ref buffer);
        obj.m41 = DXMarshal.ReadSingle(ref buffer);
        obj.m42 = DXMarshal.ReadSingle(ref buffer);
        obj.m43 = DXMarshal.ReadSingle(ref buffer);
        obj.m44 = DXMarshal.ReadSingle(ref buffer);
        obj.m51 = DXMarshal.ReadSingle(ref buffer);
        obj.m52 = DXMarshal.ReadSingle(ref buffer);
        obj.m53 = DXMarshal.ReadSingle(ref buffer);
        obj.m54 = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1Matrix5X4F> objects)
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
    /// The value in the first row and fourth column of the matrix.
    /// </summary>
    private float m14;

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
    /// The value in the second row and fourth column of the matrix.
    /// </summary>
    private float m24;

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
    /// The value in the third row and fourth column of the matrix.
    /// </summary>
    private float m34;

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
    /// The value in the fourth row and fourth column of the matrix.
    /// </summary>
    private float m44;

    /// <summary>
    /// The value in the fifth row and first column of the matrix.
    /// </summary>
    private float m51;

    /// <summary>
    /// The value in the fifth row and second column of the matrix.
    /// </summary>
    private float m52;

    /// <summary>
    /// The value in the fifth row and third column of the matrix.
    /// </summary>
    private float m53;

    /// <summary>
    /// The value in the fifth row and fourth column of the matrix.
    /// </summary>
    private float m54;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m11"></param>
    /// <param name="m12"></param>
    /// <param name="m13"></param>
    /// <param name="m14"></param>
    /// <param name="m21"></param>
    /// <param name="m22"></param>
    /// <param name="m23"></param>
    /// <param name="m24"></param>
    /// <param name="m31"></param>
    /// <param name="m32"></param>
    /// <param name="m33"></param>
    /// <param name="m34"></param>
    /// <param name="m41"></param>
    /// <param name="m42"></param>
    /// <param name="m43"></param>
    /// <param name="m44"></param>
    /// <param name="m51"></param>
    /// <param name="m52"></param>
    /// <param name="m53"></param>
    /// <param name="m54"></param>
    public D2D1Matrix5X4F(
        float m11,
        float m12,
        float m13,
        float m14,
        float m21,
        float m22,
        float m23,
        float m24,
        float m31,
        float m32,
        float m33,
        float m34,
        float m41,
        float m42,
        float m43,
        float m44,
        float m51,
        float m52,
        float m53,
        float m54
        )
    {
        this.m11 = m11;
        this.m12 = m12;
        this.m13 = m13;
        this.m14 = m14;
        this.m21 = m21;
        this.m22 = m22;
        this.m23 = m23;
        this.m24 = m24;
        this.m31 = m31;
        this.m32 = m32;
        this.m33 = m33;
        this.m34 = m34;
        this.m41 = m41;
        this.m42 = m42;
        this.m43 = m43;
        this.m44 = m44;
        this.m51 = m51;
        this.m52 = m52;
        this.m53 = m53;
        this.m54 = m54;
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
    /// Gets or sets the value in the first row and fourth column of the matrix.
    /// </summary>
    public float M14
    {
        get { return this.m14; }
        set { this.m14 = value; }
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
    /// Gets or sets the value in the second row and fourth column of the matrix.
    /// </summary>
    public float M24
    {
        get { return this.m24; }
        set { this.m24 = value; }
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
    /// Gets or sets the value in the third row and fourth column of the matrix.
    /// </summary>
    public float M34
    {
        get { return this.m34; }
        set { this.m34 = value; }
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
    /// Gets or sets the value in the fourth row and fourth column of the matrix.
    /// </summary>
    public float M44
    {
        get { return this.m44; }
        set { this.m44 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fifth row and first column of the matrix.
    /// </summary>
    public float M51
    {
        get { return this.m51; }
        set { this.m51 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fifth row and second column of the matrix.
    /// </summary>
    public float M52
    {
        get { return this.m52; }
        set { this.m52 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fifth row and third column of the matrix.
    /// </summary>
    public float M53
    {
        get { return this.m53; }
        set { this.m53 = value; }
    }

    /// <summary>
    /// Gets or sets the value in the fifth row and fourth column of the matrix.
    /// </summary>
    public float M54
    {
        get { return this.m54; }
        set { this.m54 = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1Matrix5X4F left, D2D1Matrix5X4F right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1Matrix5X4F left, D2D1Matrix5X4F right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is D2D1Matrix5X4F f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1Matrix5X4F other)
    {
        return m11 == other.m11 &&
               m12 == other.m12 &&
               m13 == other.m13 &&
               m14 == other.m14 &&
               m21 == other.m21 &&
               m22 == other.m22 &&
               m23 == other.m23 &&
               m24 == other.m24 &&
               m31 == other.m31 &&
               m32 == other.m32 &&
               m33 == other.m33 &&
               m34 == other.m34 &&
               m41 == other.m41 &&
               m42 == other.m42 &&
               m43 == other.m43 &&
               m44 == other.m44 &&
               m51 == other.m51 &&
               m52 == other.m52 &&
               m53 == other.m53 &&
               m54 == other.m54;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -2025489826;
        hashCode = hashCode * -1521134295 + m11.GetHashCode();
        hashCode = hashCode * -1521134295 + m12.GetHashCode();
        hashCode = hashCode * -1521134295 + m13.GetHashCode();
        hashCode = hashCode * -1521134295 + m14.GetHashCode();
        hashCode = hashCode * -1521134295 + m21.GetHashCode();
        hashCode = hashCode * -1521134295 + m22.GetHashCode();
        hashCode = hashCode * -1521134295 + m23.GetHashCode();
        hashCode = hashCode * -1521134295 + m24.GetHashCode();
        hashCode = hashCode * -1521134295 + m31.GetHashCode();
        hashCode = hashCode * -1521134295 + m32.GetHashCode();
        hashCode = hashCode * -1521134295 + m33.GetHashCode();
        hashCode = hashCode * -1521134295 + m34.GetHashCode();
        hashCode = hashCode * -1521134295 + m41.GetHashCode();
        hashCode = hashCode * -1521134295 + m42.GetHashCode();
        hashCode = hashCode * -1521134295 + m43.GetHashCode();
        hashCode = hashCode * -1521134295 + m44.GetHashCode();
        hashCode = hashCode * -1521134295 + m51.GetHashCode();
        hashCode = hashCode * -1521134295 + m52.GetHashCode();
        hashCode = hashCode * -1521134295 + m53.GetHashCode();
        hashCode = hashCode * -1521134295 + m54.GetHashCode();
        return hashCode;
    }
}
