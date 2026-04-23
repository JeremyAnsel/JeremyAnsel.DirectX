// <copyright file="WicPixelFormatGuid.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public struct WicPixelFormatGuid : IEquatable<WicPixelFormatGuid>
{
    private Guid _format;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    public WicPixelFormatGuid(in Guid format)
    {
        _format = format;
    }

    /// <summary>
    /// 
    /// </summary>
    public Guid PixelFormat
    {
        get => _format;
        set => _format = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is WicPixelFormatGuid guid && Equals(guid);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicPixelFormatGuid other)
    {
        return _format.Equals(other._format);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return 1923152933 + _format.GetHashCode();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(WicPixelFormatGuid left, WicPixelFormatGuid right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicPixelFormatGuid left, WicPixelFormatGuid right)
    {
        return !(left == right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    public static implicit operator Guid(WicPixelFormatGuid format)
    {
        return format._format;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    public static explicit operator WicPixelFormatGuid(Guid format)
    {
        return new WicPixelFormatGuid(format);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return _format.ToString();
    }
}
