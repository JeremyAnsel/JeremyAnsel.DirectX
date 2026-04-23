// <copyright file="WicDdsParameters.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public struct WicDdsParameters : IEquatable<WicDdsParameters>
{
    private uint _width;

    private uint _height;

    private uint _depth;

    private uint _mipLevels;

    private uint _arraySize;

    private WicDxgiFormat _dxgiFormat;

    private WicDdsDimension _dimension;

    private WicDdsAlphaMode _alphaMode;

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
    public uint Depth
    {
        get => _depth;
        set => _depth = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint MipLevels
    {
        get => _mipLevels;
        set => _mipLevels = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint ArraySize
    {
        get => _arraySize;
        set => _arraySize = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public WicDxgiFormat DxgiFormat
    {
        get => _dxgiFormat;
        set => _dxgiFormat = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public WicDdsDimension Dimension
    {
        get => _dimension;
        set => _dimension = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public WicDdsAlphaMode AlphaMode
    {
        get => _alphaMode;
        set => _alphaMode = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is WicDdsParameters parameters && Equals(parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicDdsParameters other)
    {
        return _width == other._width &&
               _height == other._height &&
               _depth == other._depth &&
               _mipLevels == other._mipLevels &&
               _arraySize == other._arraySize &&
               _dxgiFormat == other._dxgiFormat &&
               _dimension == other._dimension &&
               _alphaMode == other._alphaMode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        int hashCode = 993474631;
        hashCode = hashCode * -1521134295 + _width.GetHashCode();
        hashCode = hashCode * -1521134295 + _height.GetHashCode();
        hashCode = hashCode * -1521134295 + _depth.GetHashCode();
        hashCode = hashCode * -1521134295 + _mipLevels.GetHashCode();
        hashCode = hashCode * -1521134295 + _arraySize.GetHashCode();
        hashCode = hashCode * -1521134295 + _dxgiFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + _dimension.GetHashCode();
        hashCode = hashCode * -1521134295 + _alphaMode.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(WicDdsParameters left, WicDdsParameters right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicDdsParameters left, WicDdsParameters right)
    {
        return !(left == right);
    }
}
