// <copyright file="D2D1PixelFormat.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains the data format and alpha mode for a bitmap or render target.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1PixelFormat : IEquatable<D2D1PixelFormat>
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
        size += sizeof(int) * 2; // enum
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1PixelFormat obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1PixelFormat>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1PixelFormat> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.format);
            DXMarshal.Write(ref buffer, (int)obj.alphaMode);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1PixelFormat NativeReadFrom(nint buffer)
    {
        D2D1PixelFormat obj;
        obj.format = (DxgiFormat)DXMarshal.ReadInt32(ref buffer);
        obj.alphaMode = (D2D1AlphaMode)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1PixelFormat> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that specifies the size and arrangement of channels in each pixel.
    /// </summary>
    private DxgiFormat format;

    /// <summary>
    /// A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored and considered opaque, or whether it is unknown.
    /// </summary>
    private D2D1AlphaMode alphaMode;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1PixelFormat"/> struct.
    /// </summary>
    /// <param name="format">A value that specifies the size and arrangement of channels in each pixel.</param>
    /// <param name="alphaMode">A value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored and considered opaque, or whether it is unknown.</param>
    public D2D1PixelFormat(DxgiFormat format, D2D1AlphaMode alphaMode)
    {
        this.format = format;
        this.alphaMode = alphaMode;
    }

    /// <summary>
    /// Gets default format (Unknown, Unknown).
    /// </summary>
    public static D2D1PixelFormat Default
    {
        get { return new D2D1PixelFormat(DxgiFormat.Unknown, D2D1AlphaMode.Unknown); }
    }

    /// <summary>
    /// Gets or sets a value that specifies the size and arrangement of channels in each pixel.
    /// </summary>
    public DxgiFormat Format
    {
        get { return this.format; }
        set { this.format = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the alpha channel is using pre-multiplied alpha, straight alpha, whether it should be ignored and considered opaque, or whether it is unknown.
    /// </summary>
    public D2D1AlphaMode AlphaMode
    {
        get { return this.alphaMode; }
        set { this.alphaMode = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1PixelFormat left, D2D1PixelFormat right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1PixelFormat left, D2D1PixelFormat right)
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
        return obj is D2D1PixelFormat format && Equals(format);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1PixelFormat other)
    {
        return format == other.format &&
               alphaMode == other.alphaMode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -995962922;
        hashCode = hashCode * -1521134295 + format.GetHashCode();
        hashCode = hashCode * -1521134295 + alphaMode.GetHashCode();
        return hashCode;
    }
}
