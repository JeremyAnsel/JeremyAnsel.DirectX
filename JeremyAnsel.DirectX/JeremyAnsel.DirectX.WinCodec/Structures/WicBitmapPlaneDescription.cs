// <copyright file="WicBitmapPlaneDescription.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public struct WicBitmapPlaneDescription : IEquatable<WicBitmapPlaneDescription>
{
    private WicPixelFormatGuid _format;

    private uint _width;

    private uint _height;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public WicBitmapPlaneDescription(in WicPixelFormatGuid format, uint width, uint height)
    {
        _format = format;
        _width = width;
        _height = height;
    }

    /// <summary>
    /// 
    /// </summary>
    public WicPixelFormatGuid Format
    {
        get => _format;
        set => _format = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint Width
    {
        get => _width;
        set => _width = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint Height
    {
        get => _height;
        set => _height = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is WicBitmapPlaneDescription description && Equals(description);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicBitmapPlaneDescription other)
    {
        return _format.Equals(other._format) &&
               _width == other._width &&
               _height == other._height;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        int hashCode = 1016763756;
        hashCode = hashCode * -1521134295 + _format.GetHashCode();
        hashCode = hashCode * -1521134295 + _width.GetHashCode();
        hashCode = hashCode * -1521134295 + _height.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(WicBitmapPlaneDescription left, WicBitmapPlaneDescription right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicBitmapPlaneDescription left, WicBitmapPlaneDescription right)
    {
        return !(left == right);
    }
}
