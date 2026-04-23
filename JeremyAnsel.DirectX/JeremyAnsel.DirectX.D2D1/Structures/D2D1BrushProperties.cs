// <copyright file="D2D1BrushProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the opacity and transformation of a brush.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1BrushProperties : IEquatable<D2D1BrushProperties>
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
        size += sizeof(float);
        size += D2D1Matrix3X2F.NativeRequiredSize();
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1BrushProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1BrushProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1BrushProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.opacity);
            D2D1Matrix3X2F.NativeWriteTo(buffer, obj.transform);
            buffer += D2D1Matrix3X2F.NativeRequiredSize();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1BrushProperties NativeReadFrom(nint buffer)
    {
        D2D1BrushProperties obj;
        obj.opacity = DXMarshal.ReadSingle(ref buffer);
        obj.transform = D2D1Matrix3X2F.NativeReadFrom(buffer);
        buffer += D2D1Matrix3X2F.NativeRequiredSize();
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1BrushProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.
    /// </summary>
    private float opacity;

    /// <summary>
    /// The transformation that is applied to the brush.
    /// </summary>
    private D2D1Matrix3X2F transform;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1BrushProperties"/> struct.
    /// </summary>
    /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.</param>
    public D2D1BrushProperties(float opacity)
    {
        this.opacity = opacity;
        this.transform = D2D1Matrix3X2F.Identity;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1BrushProperties"/> struct.
    /// </summary>
    /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.</param>
    /// <param name="transform">The transformation that is applied to the brush.</param>
    public D2D1BrushProperties(float opacity, D2D1Matrix3X2F transform)
    {
        this.opacity = opacity;
        this.transform = transform;
    }

    /// <summary>
    /// Gets default properties (1.0f, Identity).
    /// </summary>
    public static D2D1BrushProperties Default
    {
        get { return new D2D1BrushProperties(1.0f, D2D1Matrix3X2F.Identity); }
    }

    /// <summary>
    /// Gets or sets a value between 0.0f and 1.0f, inclusive, that specifies the degree of opacity of the brush.
    /// </summary>
    public float Opacity
    {
        get { return this.opacity; }
        set { this.opacity = value; }
    }

    /// <summary>
    /// Gets or sets the transformation that is applied to the brush.
    /// </summary>
    public D2D1Matrix3X2F Transform
    {
        get { return this.transform; }
        set { this.transform = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1BrushProperties left, D2D1BrushProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1BrushProperties left, D2D1BrushProperties right)
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
        return obj is D2D1BrushProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1BrushProperties other)
    {
        return opacity == other.opacity &&
               transform.Equals(other.transform);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1421613455;
        hashCode = hashCode * -1521134295 + opacity.GetHashCode();
        hashCode = hashCode * -1521134295 + transform.GetHashCode();
        return hashCode;
    }
}
