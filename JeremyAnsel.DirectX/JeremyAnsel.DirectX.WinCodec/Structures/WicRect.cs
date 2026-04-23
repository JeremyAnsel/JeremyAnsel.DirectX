// <copyright file="WicRect.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public struct WicRect : IEquatable<WicRect>
{
    private int _x;

    private int _y;

    private int _width;

    private int _height;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public WicRect(int x, int y, int width, int height)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
    }

    /// <summary>
    /// 
    /// </summary>
    public int X
    {
        get => _x;
        set => _x = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Y
    {
        get => _y;
        set => _y = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Width
    {
        get => _width;
        set => _width = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public int Height
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
        return obj is WicRect rect && Equals(rect);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicRect other)
    {
        return _x == other._x &&
               _y == other._y &&
               _width == other._width &&
               _height == other._height;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        int hashCode = -2100647786;
        hashCode = hashCode * -1521134295 + _x.GetHashCode();
        hashCode = hashCode * -1521134295 + _y.GetHashCode();
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
    public static bool operator ==(WicRect left, WicRect right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicRect left, WicRect right)
    {
        return !(left == right);
    }
}
