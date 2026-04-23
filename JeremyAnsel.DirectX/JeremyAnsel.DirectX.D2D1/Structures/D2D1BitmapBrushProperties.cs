// <copyright file="D2D1BitmapBrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the extend modes and the interpolation mode of an <see cref="D2D1BitmapBrush"/>.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1BitmapBrushProperties : IEquatable<D2D1BitmapBrushProperties>
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
        size += sizeof(int) * 3; // enum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1BitmapBrushProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1BitmapBrushProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1BitmapBrushProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.extendModeX);
            DXMarshal.Write(ref buffer, (int)obj.extendModeY);
            DXMarshal.Write(ref buffer, (int)obj.interpolationMode);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1BitmapBrushProperties NativeReadFrom(nint buffer)
    {
        D2D1BitmapBrushProperties obj;
        obj.extendModeX = (D2D1ExtendMode)DXMarshal.ReadInt32(ref buffer);
        obj.extendModeY = (D2D1ExtendMode)DXMarshal.ReadInt32(ref buffer);
        obj.interpolationMode = (D2D1BitmapInterpolationMode)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1BitmapBrushProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that describes how the brush horizontally tiles those areas that extend past its bitmap.
    /// </summary>
    private D2D1ExtendMode extendModeX;

    /// <summary>
    /// A value that describes how the brush vertically tiles those areas that extend past its bitmap.
    /// </summary>
    private D2D1ExtendMode extendModeY;

    /// <summary>
    /// A value that specifies how the bitmap is interpolated when it is scaled or rotated.
    /// </summary>
    private D2D1BitmapInterpolationMode interpolationMode;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1BitmapBrushProperties"/> struct.
    /// </summary>
    /// <param name="extendModeX">A value that describes how the brush horizontally tiles those areas that extend past its bitmap.</param>
    /// <param name="extendModeY">A value that describes how the brush vertically tiles those areas that extend past its bitmap.</param>
    /// <param name="interpolationMode">A value that specifies how the bitmap is interpolated when it is scaled or rotated.</param>
    public D2D1BitmapBrushProperties(D2D1ExtendMode extendModeX, D2D1ExtendMode extendModeY, D2D1BitmapInterpolationMode interpolationMode)
    {
        this.extendModeX = extendModeX;
        this.extendModeY = extendModeY;
        this.interpolationMode = interpolationMode;
    }

    /// <summary>
    /// Gets default properties (Clamp, Clamp, Linear).
    /// </summary>
    public static D2D1BitmapBrushProperties Default
    {
        get { return new D2D1BitmapBrushProperties(D2D1ExtendMode.Clamp, D2D1ExtendMode.Clamp, D2D1BitmapInterpolationMode.Linear); }
    }

    /// <summary>
    /// Gets or sets a value that describes how the brush horizontally tiles those areas that extend past its bitmap.
    /// </summary>
    public D2D1ExtendMode ExtendModeX
    {
        get { return this.extendModeX; }
        set { this.extendModeX = value; }
    }

    /// <summary>
    /// Gets or sets a value that describes how the brush vertically tiles those areas that extend past its bitmap.
    /// </summary>
    public D2D1ExtendMode ExtendModeY
    {
        get { return this.extendModeY; }
        set { this.extendModeY = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies how the bitmap is interpolated when it is scaled or rotated.
    /// </summary>
    public D2D1BitmapInterpolationMode InterpolationMode
    {
        get { return this.interpolationMode; }
        set { this.interpolationMode = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1BitmapBrushProperties left, D2D1BitmapBrushProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1BitmapBrushProperties left, D2D1BitmapBrushProperties right)
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
        return obj is D2D1BitmapBrushProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1BitmapBrushProperties other)
    {
        return extendModeX == other.extendModeX &&
               extendModeY == other.extendModeY &&
               interpolationMode == other.interpolationMode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 653322201;
        hashCode = hashCode * -1521134295 + extendModeX.GetHashCode();
        hashCode = hashCode * -1521134295 + extendModeY.GetHashCode();
        hashCode = hashCode * -1521134295 + interpolationMode.GetHashCode();
        return hashCode;
    }
}
