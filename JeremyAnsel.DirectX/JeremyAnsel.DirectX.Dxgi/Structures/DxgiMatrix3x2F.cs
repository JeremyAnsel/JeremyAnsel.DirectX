// <copyright file="DxgiMatrix3x2F.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Represents a 3x2 matrix.
/// </summary>
[SkipLocalsInit]
public unsafe struct DxgiMatrix3x2F : IEquatable<DxgiMatrix3x2F>
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
        size += sizeof(float) * 6;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in DxgiMatrix3x2F obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DxgiMatrix3x2F>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DxgiMatrix3x2F> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.m11);
            DXMarshal.Write(ref buffer, obj.m12);
            DXMarshal.Write(ref buffer, obj.m21);
            DXMarshal.Write(ref buffer, obj.m22);
            DXMarshal.Write(ref buffer, obj.m31);
            DXMarshal.Write(ref buffer, obj.m32);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DxgiMatrix3x2F NativeReadFrom(nint buffer)
    {
        DxgiMatrix3x2F obj;
        obj.m11 = DXMarshal.ReadSingle(ref buffer);
        obj.m12 = DXMarshal.ReadSingle(ref buffer);
        obj.m21 = DXMarshal.ReadSingle(ref buffer);
        obj.m22 = DXMarshal.ReadSingle(ref buffer);
        obj.m31 = DXMarshal.ReadSingle(ref buffer);
        obj.m32 = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DxgiMatrix3x2F> objects)
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
    /// The value in the second row and first column of the matrix.
    /// </summary>
    private float m21;

    /// <summary>
    /// The value in the second row and second column of the matrix.
    /// </summary>
    private float m22;

    /// <summary>
    /// The value in the third row and first column of the matrix.
    /// </summary>
    private float m31;

    /// <summary>
    /// The value in the third row and second column of the matrix.
    /// </summary>
    private float m32;

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
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public float this[int index]
    {
        get
        {
            return index switch
            {
                0 => this.m11,
                1 => this.m12,
                2 => this.m21,
                3 => this.m22,
                4 => this.m31,
                5 => this.m32,
                _ => throw new ArgumentOutOfRangeException(nameof(index))
            };
        }

        set
        {
            switch (index)
            {
                case 0:
                    this.m11 = value;
                    break;

                case 1:
                    this.m12 = value;
                    break;

                case 2:
                    this.m21 = value;
                    break;

                case 3:
                    this.m22 = value;
                    break;

                case 4:
                    this.m31 = value;
                    break;

                case 5:
                    this.m32 = value;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(index));
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DxgiMatrix3x2F left, DxgiMatrix3x2F right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DxgiMatrix3x2F left, DxgiMatrix3x2F right)
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
            "{0};{1};{2};{3};{4};{5}",
            this.m11,
            this.m12,
            this.m21,
            this.m22,
            this.m31,
            this.m32);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public readonly override bool Equals(object? obj)
    {
        return obj is DxgiMatrix3x2F f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DxgiMatrix3x2F other)
    {
        return m11 == other.m11 &&
               m12 == other.m12 &&
               m21 == other.m21 &&
               m22 == other.m22 &&
               m31 == other.m31 &&
               m32 == other.m32;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 1986762283;
        hashCode = hashCode * -1521134295 + m11.GetHashCode();
        hashCode = hashCode * -1521134295 + m12.GetHashCode();
        hashCode = hashCode * -1521134295 + m21.GetHashCode();
        hashCode = hashCode * -1521134295 + m22.GetHashCode();
        hashCode = hashCode * -1521134295 + m31.GetHashCode();
        hashCode = hashCode * -1521134295 + m32.GetHashCode();
        return hashCode;
    }
}
