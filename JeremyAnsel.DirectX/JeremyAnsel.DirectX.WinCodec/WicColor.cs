// <copyright file="WicColor.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public struct WicColor : IEquatable<WicColor>
{
    private uint _color;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    public WicColor(uint color)
    {
        _color = color;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint Color
    {
        get => _color;
        set => _color = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is WicColor color && Equals(color);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicColor other)
    {
        return _color == other._color;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return -1740376583 + _color.GetHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(WicColor left, WicColor right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicColor left, WicColor right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    public static implicit operator uint(WicColor color)
    {
        return color._color;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="color"></param>
    public static explicit operator WicColor(uint color)
    {
        return new WicColor(color);
    }
}
