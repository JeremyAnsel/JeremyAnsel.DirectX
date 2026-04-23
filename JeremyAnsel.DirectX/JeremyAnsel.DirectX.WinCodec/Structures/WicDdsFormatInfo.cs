// <copyright file="WicDdsFormatInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
public struct WicDdsFormatInfo : IEquatable<WicDdsFormatInfo>
{
    private WicDxgiFormat _dxgiFormat;

    private uint _bytesPerBlock;

    private uint _blockWidth;

    private uint _blockHeight;

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
    public uint BytesPerBlock
    {
        get => _bytesPerBlock;
        set => _bytesPerBlock = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint BlockWidth
    {
        get => _blockWidth;
        set => _blockWidth = value;
    }

    /// <summary>
    /// 
    /// </summary>
    public uint BlockHeight
    {
        get => _blockHeight;
        set => _blockHeight = value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is WicDdsFormatInfo info && Equals(info);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    public bool Equals(WicDdsFormatInfo other)
    {
        return _dxgiFormat == other._dxgiFormat &&
               _bytesPerBlock == other._bytesPerBlock &&
               _blockWidth == other._blockWidth &&
               _blockHeight == other._blockHeight;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        int hashCode = 1602030783;
        hashCode = hashCode * -1521134295 + _dxgiFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + _bytesPerBlock.GetHashCode();
        hashCode = hashCode * -1521134295 + _blockWidth.GetHashCode();
        hashCode = hashCode * -1521134295 + _blockHeight.GetHashCode();
        return hashCode;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(WicDdsFormatInfo left, WicDdsFormatInfo right)
    {
        return left.Equals(right);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(WicDdsFormatInfo left, WicDdsFormatInfo right)
    {
        return !(left == right);
    }
}
