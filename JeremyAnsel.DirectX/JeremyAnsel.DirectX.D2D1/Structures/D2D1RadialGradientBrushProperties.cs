// <copyright file="D2D1RadialGradientBrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the gradient origin offset and the size and position of the gradient ellipse for an <see cref="D2D1RadialGradientBrush"/>.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1RadialGradientBrushProperties : IEquatable<D2D1RadialGradientBrushProperties>
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
        size += D2D1Point2F.NativeRequiredSize(2);
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1RadialGradientBrushProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1RadialGradientBrushProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1RadialGradientBrushProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1Point2F.NativeWriteTo(buffer, obj.center);
            buffer += D2D1Point2F.NativeRequiredSize();
            D2D1Point2F.NativeWriteTo(buffer, obj.gradientOriginOffset);
            buffer += D2D1Point2F.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.radiusX);
            DXMarshal.Write(ref buffer, obj.radiusY);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1RadialGradientBrushProperties NativeReadFrom(nint buffer)
    {
        D2D1RadialGradientBrushProperties obj;
        obj.center = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.gradientOriginOffset = D2D1Point2F.NativeReadFrom(buffer);
        buffer += D2D1Point2F.NativeRequiredSize();
        obj.radiusX = DXMarshal.ReadSingle(ref buffer);
        obj.radiusY = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1RadialGradientBrushProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The center of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    private D2D1Point2F center;

    /// <summary>
    /// The offset of the gradient origin relative to the gradient ellipse's center, in the brush's coordinate space.
    /// </summary>
    private D2D1Point2F gradientOriginOffset;

    /// <summary>
    /// The x-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    private float radiusX;

    /// <summary>
    /// The y-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    private float radiusY;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RadialGradientBrushProperties"/> struct.
    /// </summary>
    /// <param name="center">The center of the gradient ellipse, in the brush's coordinate space.</param>
    /// <param name="gradientOriginOffset">The offset of the gradient origin relative to the gradient ellipse's center, in the brush's coordinate space.</param>
    /// <param name="radiusX">The x-radius of the gradient ellipse, in the brush's coordinate space.</param>
    /// <param name="radiusY">The y-radius of the gradient ellipse, in the brush's coordinate space.</param>
    public D2D1RadialGradientBrushProperties(D2D1Point2F center, D2D1Point2F gradientOriginOffset, float radiusX, float radiusY)
    {
        this.center = center;
        this.gradientOriginOffset = gradientOriginOffset;
        this.radiusX = radiusX;
        this.radiusY = radiusY;
    }

    /// <summary>
    /// Gets or sets the center of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F Center
    {
        get { return this.center; }
        set { this.center = value; }
    }

    /// <summary>
    /// Gets or sets the offset of the gradient origin relative to the gradient ellipse's center, in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F GradientOriginOffset
    {
        get { return this.gradientOriginOffset; }
        set { this.gradientOriginOffset = value; }
    }

    /// <summary>
    /// Gets or sets the x-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    public float RadiusX
    {
        get { return this.radiusX; }
        set { this.radiusX = value; }
    }

    /// <summary>
    /// Gets or sets the y-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    public float RadiusY
    {
        get { return this.radiusY; }
        set { this.radiusY = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1RadialGradientBrushProperties left, D2D1RadialGradientBrushProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1RadialGradientBrushProperties left, D2D1RadialGradientBrushProperties right)
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
        return obj is D2D1RadialGradientBrushProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1RadialGradientBrushProperties other)
    {
        return center.Equals(other.center) &&
               gradientOriginOffset.Equals(other.gradientOriginOffset) &&
               radiusX == other.radiusX &&
               radiusY == other.radiusY;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1637712241;
        hashCode = hashCode * -1521134295 + center.GetHashCode();
        hashCode = hashCode * -1521134295 + gradientOriginOffset.GetHashCode();
        hashCode = hashCode * -1521134295 + radiusX.GetHashCode();
        hashCode = hashCode * -1521134295 + radiusY.GetHashCode();
        return hashCode;
    }
}
