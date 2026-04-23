// <copyright file="D2D1BitmapProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes the pixel format and dpi of a bitmap.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1BitmapProperties : IEquatable<D2D1BitmapProperties>
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
        size += D2D1PixelFormat.NativeRequiredSize();
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1BitmapProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1BitmapProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1BitmapProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            D2D1PixelFormat.NativeWriteTo(buffer, obj.pixelFormat);
            buffer += D2D1PixelFormat.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.dpiX);
            DXMarshal.Write(ref buffer, obj.dpiY);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1BitmapProperties NativeReadFrom(nint buffer)
    {
        D2D1BitmapProperties obj;
        obj.pixelFormat = D2D1PixelFormat.NativeReadFrom(buffer);
        buffer += D2D1PixelFormat.NativeRequiredSize();
        obj.dpiX = DXMarshal.ReadSingle(ref buffer);
        obj.dpiY = DXMarshal.ReadSingle(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1BitmapProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// The bitmap's pixel format and alpha mode.
    /// </summary>
    private D2D1PixelFormat pixelFormat;

    /// <summary>
    /// The horizontal dpi of the bitmap.
    /// </summary>
    private float dpiX;

    /// <summary>
    /// The vertical dpi of the bitmap.
    /// </summary>
    private float dpiY;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1BitmapProperties"/> struct.
    /// </summary>
    /// <param name="pixelFormat">The bitmap's pixel format and alpha mode.</param>
    /// <param name="dpiX">The horizontal dpi of the bitmap.</param>
    /// <param name="dpiY">The vertical dpi of the bitmap.</param>
    public D2D1BitmapProperties(D2D1PixelFormat pixelFormat, float dpiX, float dpiY)
    {
        this.pixelFormat = pixelFormat;
        this.dpiX = dpiX;
        this.dpiY = dpiY;
    }

    /// <summary>
    /// Gets default properties (Default, 96, 96).
    /// </summary>
    public static D2D1BitmapProperties Default
    {
        get { return new D2D1BitmapProperties(D2D1PixelFormat.Default, 96.0f, 96.0f); }
    }

    /// <summary>
    /// Gets or sets the bitmap's pixel format and alpha mode.
    /// </summary>
    public D2D1PixelFormat PixelFormat
    {
        get { return this.pixelFormat; }
        set { this.pixelFormat = value; }
    }

    /// <summary>
    /// Gets or sets the horizontal dpi of the bitmap.
    /// </summary>
    public float DpiX
    {
        get { return this.dpiX; }
        set { this.dpiX = value; }
    }

    /// <summary>
    /// Gets or sets the vertical dpi of the bitmap.
    /// </summary>
    public float DpiY
    {
        get { return this.dpiY; }
        set { this.dpiY = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1BitmapProperties left, D2D1BitmapProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1BitmapProperties left, D2D1BitmapProperties right)
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
        return obj is D2D1BitmapProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1BitmapProperties other)
    {
        return pixelFormat.Equals(other.pixelFormat) &&
               dpiX == other.dpiX &&
               dpiY == other.dpiY;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = 272834979;
        hashCode = hashCode * -1521134295 + pixelFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + dpiX.GetHashCode();
        hashCode = hashCode * -1521134295 + dpiY.GetHashCode();
        return hashCode;
    }
}
