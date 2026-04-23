// <copyright file="DWriteMatrix.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The DWRITE_MATRIX structure specifies the graphics transform to be applied
/// to rendered glyphs.
/// </summary>
[SkipLocalsInit]
public unsafe struct DWriteMatrix : IEquatable<DWriteMatrix>
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
    public static void NativeWriteTo(nint buffer, in DWriteMatrix obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<DWriteMatrix>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<DWriteMatrix> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.m11);
            DXMarshal.Write(ref buffer, obj.m12);
            DXMarshal.Write(ref buffer, obj.m21);
            DXMarshal.Write(ref buffer, obj.m22);
            DXMarshal.Write(ref buffer, obj.dx);
            DXMarshal.Write(ref buffer, obj.dy);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static DWriteMatrix NativeReadFrom(nint buffer)
    {
        DWriteMatrix obj;
        obj.m11 = DXMarshal.ReadSingle(ref buffer);
        obj.m12 = DXMarshal.ReadSingle(ref buffer);
        obj.m21 = DXMarshal.ReadSingle(ref buffer);
        obj.m22 = DXMarshal.ReadSingle(ref buffer);
        obj.dx = DXMarshal.ReadSingle(ref buffer);
        obj.dy = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<DWriteMatrix> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// Horizontal scaling / cosine of rotation
    /// </summary>
    private float m11;

    /// <summary>
    /// Vertical shear / sine of rotation
    /// </summary>
    private float m12;

    /// <summary>
    /// Horizontal shear / negative sine of rotation
    /// </summary>
    private float m21;

    /// <summary>
    /// Vertical scaling / cosine of rotation
    /// </summary>
    private float m22;

    /// <summary>
    /// Horizontal shift (always orthogonal regardless of rotation)
    /// </summary>
    private float dx;

    /// <summary>
    /// Vertical shift (always orthogonal regardless of rotation)
    /// </summary>
    private float dy;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m11"></param>
    /// <param name="m12"></param>
    /// <param name="m21"></param>
    /// <param name="m22"></param>
    /// <param name="dx"></param>
    /// <param name="dy"></param>
    public DWriteMatrix(float m11, float m12, float m21, float m22, float dx, float dy)
    {
        this.m11 = m11;
        this.m12 = m12;
        this.m21 = m21;
        this.m22 = m22;
        this.dx = dx;
        this.dy = dy;
    }

    /// <summary>
    /// Gets or sets the horizontal scaling / cosine of rotation
    /// </summary>
    public float M11
    {
        get { return this.m11; }
        set { this.m11 = value; }
    }

    /// <summary>
    /// Gets or sets the vertical shear / sine of rotation
    /// </summary>
    public float M12
    {
        get { return this.m12; }
        set { this.m12 = value; }
    }

    /// <summary>
    /// Gets or sets the horizontal shear / negative sine of rotation
    /// </summary>
    public float M21
    {
        get { return this.m21; }
        set { this.m21 = value; }
    }

    /// <summary>
    /// Gets or sets the vertical scaling / cosine of rotation
    /// </summary>
    public float M22
    {
        get { return this.m22; }
        set { this.m22 = value; }
    }

    /// <summary>
    /// Gets or sets the horizontal shift (always orthogonal regardless of rotation)
    /// </summary>
    public float DX
    {
        get { return this.dx; }
        set { this.dx = value; }
    }

    /// <summary>
    /// Gets or sets the vertical shift (always orthogonal regardless of rotation)
    /// </summary>
    public float DY
    {
        get { return this.dy; }
        set { this.dy = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(DWriteMatrix left, DWriteMatrix right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(DWriteMatrix left, DWriteMatrix right)
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
        return obj is DWriteMatrix matrix && Equals(matrix);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(DWriteMatrix other)
    {
        return m11 == other.m11 &&
               m12 == other.m12 &&
               m21 == other.m21 &&
               m22 == other.m22 &&
               dx == other.dx &&
               dy == other.dy;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1808996759;
        hashCode = hashCode * -1521134295 + m11.GetHashCode();
        hashCode = hashCode * -1521134295 + m12.GetHashCode();
        hashCode = hashCode * -1521134295 + m21.GetHashCode();
        hashCode = hashCode * -1521134295 + m22.GetHashCode();
        hashCode = hashCode * -1521134295 + dx.GetHashCode();
        hashCode = hashCode * -1521134295 + dy.GetHashCode();
        return hashCode;
    }
}
