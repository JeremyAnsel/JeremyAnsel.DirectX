// <copyright file="D2D1RenderTargetProperties.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Contains rendering options (hardware or software), pixel format, DPI information, remoting options, and Direct3D support requirements for a render target.
/// </summary>
[SkipLocalsInit]
public unsafe struct D2D1RenderTargetProperties : IEquatable<D2D1RenderTargetProperties>
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
        size += D2D1PixelFormat.NativeRequiredSize();
        size += sizeof(float) * 2;
        return size * count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="obj"></param>
    public static void NativeWriteTo(nint buffer, in D2D1RenderTargetProperties obj)
    {
        fixed (void* ptr = &obj)
        {
            var span = new ReadOnlySpan<D2D1RenderTargetProperties>(ptr, 1);
            NativeWriteTo(buffer, span);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeWriteTo(nint buffer, ReadOnlySpan<D2D1RenderTargetProperties> objects)
    {
        for (int index = 0; index < objects.Length; index++)
        {
            ref readonly var obj = ref objects[index];

            DXMarshal.Write(ref buffer, (int)obj.renderTargetType);
            D2D1PixelFormat.NativeWriteTo(buffer, obj.pixelFormat);
            buffer += D2D1PixelFormat.NativeRequiredSize();
            DXMarshal.Write(ref buffer, obj.dpiX);
            DXMarshal.Write(ref buffer, obj.dpiY);
            DXMarshal.Write(ref buffer, (int)obj.usage);
            DXMarshal.Write(ref buffer, (int)obj.minLevel);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <returns></returns>
    public static D2D1RenderTargetProperties NativeReadFrom(nint buffer)
    {
        D2D1RenderTargetProperties obj;
        obj.renderTargetType = (D2D1RenderTargetType)DXMarshal.ReadInt32(ref buffer);
        obj.pixelFormat = D2D1PixelFormat.NativeReadFrom(buffer);
        buffer += D2D1PixelFormat.NativeRequiredSize();
        obj.dpiX = DXMarshal.ReadSingle(ref buffer);
        obj.dpiY = DXMarshal.ReadSingle(ref buffer);
        obj.usage = (D2D1RenderTargetUsages)DXMarshal.ReadInt32(ref buffer);
        obj.minLevel = (D2D1FeatureLevel)DXMarshal.ReadInt32(ref buffer);
        return obj;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    /// <param name="objects"></param>
    public static void NativeReadFrom(nint buffer, Span<D2D1RenderTargetProperties> objects)
    {
        int size = NativeRequiredSize();
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i] = NativeReadFrom(buffer);
            buffer += size;
        }
    }

    /// <summary>
    /// A value that specifies whether the render target should force hardware or software rendering.
    /// </summary>
    private D2D1RenderTargetType renderTargetType;

    /// <summary>
    /// The pixel format and alpha mode of the render target.
    /// </summary>
    private D2D1PixelFormat pixelFormat;

    /// <summary>
    /// The horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
    /// </summary>
    private float dpiX;

    /// <summary>
    /// The vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
    /// </summary>
    private float dpiY;

    /// <summary>
    /// A value that specifies how the render target is remoted and whether it should be GDI-compatible.
    /// </summary>
    private D2D1RenderTargetUsages usage;

    /// <summary>
    /// A value that specifies the minimum Direct3D feature level required for hardware rendering.
    /// </summary>
    private D2D1FeatureLevel minLevel;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RenderTargetProperties"/> struct.
    /// </summary>
    /// <param name="renderTargetType">A value that specifies whether the render target should force hardware or software rendering.</param>
    /// <param name="pixelFormat">The pixel format and alpha mode of the render target.</param>
    /// <param name="dpiX">The horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.</param>
    /// <param name="dpiY">The vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.</param>
    /// <param name="usage">A value that specifies how the render target is remoted and whether it should be GDI-compatible.</param>
    /// <param name="minLevel">A value that specifies the minimum Direct3D feature level required for hardware rendering.</param>
    public D2D1RenderTargetProperties(D2D1RenderTargetType renderTargetType, D2D1PixelFormat pixelFormat, float dpiX, float dpiY, D2D1RenderTargetUsages usage, D2D1FeatureLevel minLevel)
    {
        this.renderTargetType = renderTargetType;
        this.pixelFormat = pixelFormat;
        this.dpiX = dpiX;
        this.dpiY = dpiY;
        this.usage = usage;
        this.minLevel = minLevel;
    }

    /// <summary>
    /// Gets default properties.
    /// </summary>
    public static D2D1RenderTargetProperties Default
    {
        get { return new D2D1RenderTargetProperties(D2D1RenderTargetType.Default, D2D1PixelFormat.Default, 0.0f, 0.0f, D2D1RenderTargetUsages.None, D2D1FeatureLevel.Default); }
    }

    /// <summary>
    /// Gets or sets a value that specifies whether the render target should force hardware or software rendering.
    /// </summary>
    public D2D1RenderTargetType RenderTargetType
    {
        get { return this.renderTargetType; }
        set { this.renderTargetType = value; }
    }

    /// <summary>
    /// Gets or sets the pixel format and alpha mode of the render target.
    /// </summary>
    public D2D1PixelFormat PixelFormat
    {
        get { return this.pixelFormat; }
        set { this.pixelFormat = value; }
    }

    /// <summary>
    /// Gets or sets the horizontal DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
    /// </summary>
    public float DpiX
    {
        get { return this.dpiX; }
        set { this.dpiX = value; }
    }

    /// <summary>
    /// Gets or sets the vertical DPI of the render target. To use the default DPI, set dpiX and dpiY to 0.
    /// </summary>
    public float DpiY
    {
        get { return this.dpiY; }
        set { this.dpiY = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies how the render target is remoted and whether it should be GDI-compatible.
    /// </summary>
    public D2D1RenderTargetUsages Usage
    {
        get { return this.usage; }
        set { this.usage = value; }
    }

    /// <summary>
    /// Gets or sets a value that specifies the minimum Direct3D feature level required for hardware rendering.
    /// </summary>
    public D2D1FeatureLevel MinLevel
    {
        get { return this.minLevel; }
        set { this.minLevel = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(D2D1RenderTargetProperties left, D2D1RenderTargetProperties right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(D2D1RenderTargetProperties left, D2D1RenderTargetProperties right)
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
        return obj is D2D1RenderTargetProperties properties && Equals(properties);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public readonly bool Equals(D2D1RenderTargetProperties other)
    {
        return renderTargetType == other.renderTargetType &&
               pixelFormat.Equals(other.pixelFormat) &&
               dpiX == other.dpiX &&
               dpiY == other.dpiY &&
               usage == other.usage &&
               minLevel == other.minLevel;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public readonly override int GetHashCode()
    {
        int hashCode = -1613062694;
        hashCode = hashCode * -1521134295 + renderTargetType.GetHashCode();
        hashCode = hashCode * -1521134295 + pixelFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + dpiX.GetHashCode();
        hashCode = hashCode * -1521134295 + dpiY.GetHashCode();
        hashCode = hashCode * -1521134295 + usage.GetHashCode();
        hashCode = hashCode * -1521134295 + minLevel.GetHashCode();
        return hashCode;
    }
}
