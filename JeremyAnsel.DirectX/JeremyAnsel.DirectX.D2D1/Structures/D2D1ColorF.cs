// <copyright file="D2D1ColorF.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the red, green, blue, and alpha components of a color.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1ColorF : IEquatable<D2D1ColorF>
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
    public static void NativeWriteTo(nint buffer, in D2D1ColorF obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1ColorF>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1ColorF> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, obj.r);
            DXMarshal.Write(ref buffer, obj.g);
            DXMarshal.Write(ref buffer, obj.b);
            DXMarshal.Write(ref buffer, obj.a);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1ColorF NativeReadFrom(nint buffer)
    {
        D2D1ColorF obj;
        obj.r = DXMarshal.ReadSingle(ref buffer);
        obj.g = DXMarshal.ReadSingle(ref buffer);
        obj.b = DXMarshal.ReadSingle(ref buffer);
        obj.a = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1ColorF> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The red shift.
    /// </summary>
    private const int RedShift = 16;

    /// <summary>
    /// The green shift.
    /// </summary>
    private const int GreenShift = 8;

    /// <summary>
    /// The blue shift.
    /// </summary>
    private const int BlueShift = 0;

    /// <summary>
    /// The red mask.
    /// </summary>
    private const uint RedMask = 0xff << RedShift;

    /// <summary>
    /// The green mask.
    /// </summary>
    private const uint GreenMask = 0xff << GreenShift;

    /// <summary>
    /// The blue mask.
    /// </summary>
    private const uint BlueMask = 0xff << BlueShift;

    /// <summary>
    /// Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
    /// </summary>
    private float r;

    /// <summary>
    /// Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
    /// </summary>
    private float g;

    /// <summary>
    /// Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
    /// </summary>
    private float b;

    /// <summary>
    /// Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
    /// </summary>
    private float a;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
    /// </summary>
    /// <param name="rgb">The red, green, blue components.</param>
    public D2D1ColorF(uint rgb)
    {
        this.r = (float)((rgb & RedMask) >> RedShift) / 255.0f;
        this.g = (float)((rgb & GreenMask) >> GreenShift) / 255.0f;
        this.b = (float)((rgb & BlueMask) >> BlueShift) / 255.0f;
        this.a = 1.0f;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
    /// </summary>
    /// <param name="rgb">The red, green, blue components.</param>
    /// <param name="a">Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</param>
    public D2D1ColorF(uint rgb, float a)
    {
        this.r = (float)((rgb & RedMask) >> RedShift) / 255.0f;
        this.g = (float)((rgb & GreenMask) >> GreenShift) / 255.0f;
        this.b = (float)((rgb & BlueMask) >> BlueShift) / 255.0f;
        this.a = a;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
    /// </summary>
    /// <param name="knownColor">A known color.</param>
    public D2D1ColorF(D2D1KnownColor knownColor)
    {
        this.r = (float)(((uint)knownColor & RedMask) >> RedShift) / 255.0f;
        this.g = (float)(((uint)knownColor & GreenMask) >> GreenShift) / 255.0f;
        this.b = (float)(((uint)knownColor & BlueMask) >> BlueShift) / 255.0f;
        this.a = 1.0f;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
    /// </summary>
    /// <param name="knownColor">A known color.</param>
    /// <param name="a">Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</param>
    public D2D1ColorF(D2D1KnownColor knownColor, float a)
    {
        this.r = (float)(((uint)knownColor & RedMask) >> RedShift) / 255.0f;
        this.g = (float)(((uint)knownColor & GreenMask) >> GreenShift) / 255.0f;
        this.b = (float)(((uint)knownColor & BlueMask) >> BlueShift) / 255.0f;
        this.a = a;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
    /// </summary>
    /// <param name="r">Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.</param>
    /// <param name="g">Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.</param>
    /// <param name="b">Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.</param>
    public D2D1ColorF(float r, float g, float b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = 1.0f;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1ColorF"/> struct.
    /// </summary>
    /// <param name="r">Floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.</param>
    /// <param name="g">Floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.</param>
    /// <param name="b">Floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.</param>
    /// <param name="a">Floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.</param>
    public D2D1ColorF(float r, float g, float b, float a)
    {
        this.r = r;
        this.g = g;
        this.b = b;
        this.a = a;
    }

    /// <summary>
    /// Gets or sets a floating-point value that specifies the red component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the red component, while a value of 1.0 indicates that red is fully present.
    /// </summary>
    public float R
    {
        get { return this.r; }
        set { this.r = value; }
    }

    /// <summary>
    /// Gets or sets a floating-point value that specifies the green component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the green component, while a value of 1.0 indicates that green is fully present.
    /// </summary>
    public float G
    {
        get { return this.g; }
        set { this.g = value; }
    }

    /// <summary>
    /// Gets or sets a floating-point value that specifies the blue component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates the complete absence of the blue component, while a value of 1.0 indicates that blue is fully present.
    /// </summary>
    public float B
    {
        get { return this.b; }
        set { this.b = value; }
    }

    /// <summary>
    /// Gets or sets a floating-point value that specifies the alpha component of a color. This value generally is in the range from 0.0 through 1.0. A value of 0.0 indicates fully transparent, while a value of 1.0 indicates fully opaque.
    /// </summary>
    public float A
    {
        get { return this.a; }
        set { this.a = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1ColorF left, D2D1ColorF right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1ColorF left, D2D1ColorF right)
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
        return obj is D2D1ColorF f && Equals(f);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1ColorF other)
    {
        return r == other.r &&
               g == other.g &&
               b == other.b &&
               a == other.a;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -490236692;
        hashCode = hashCode * -1521134295 + r.GetHashCode();
        hashCode = hashCode * -1521134295 + g.GetHashCode();
        hashCode = hashCode * -1521134295 + b.GetHashCode();
        hashCode = hashCode * -1521134295 + a.GetHashCode();
        return hashCode;
    }
}
