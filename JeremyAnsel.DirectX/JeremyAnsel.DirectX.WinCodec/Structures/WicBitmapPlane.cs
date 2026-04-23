// <copyright file="WicBitmapPlane.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public readonly struct WicBitmapPlane : IEquatable<WicBitmapPlane>
{
    private readonly WicPixelFormatGuid _format;

    private readonly Array _buffer;

    private readonly uint _stride;

    private readonly uint _bufferSize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    /// <param name="buffer"></param>
    /// <param name="stride"></param>
    /// <param name="bufferSize"></param>
    public WicBitmapPlane(in WicPixelFormatGuid format, Array buffer, uint stride, uint bufferSize)
    {
        _format = format;
        _buffer = buffer;
        _stride = stride;
        _bufferSize = bufferSize;
    }

    /// <summary>
    /// 
    /// </summary>
    public WicPixelFormatGuid Format => _format;

    /// <summary>
    /// 
    /// </summary>
    public Array Buffer => _buffer;

    /// <summary>
    /// 
    /// </summary>
    public uint Stride => _stride;

    /// <summary>
    /// 
    /// </summary>
    public uint BufferSize => _bufferSize;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is WicBitmapPlane plane && Equals(plane);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicBitmapPlane other)
    {
        return _format.Equals(other._format) &&
               EqualityComparer<Array>.Default.Equals(_buffer, other._buffer) &&
               _stride == other._stride &&
               _bufferSize == other._bufferSize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        int hashCode = 1564312497;
        hashCode = hashCode * -1521134295 + _format.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<Array>.Default.GetHashCode(_buffer);
        hashCode = hashCode * -1521134295 + _stride.GetHashCode();
        hashCode = hashCode * -1521134295 + _bufferSize.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(WicBitmapPlane left, WicBitmapPlane right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicBitmapPlane left, WicBitmapPlane right)
    {
        return !(left == right);
    }
}
