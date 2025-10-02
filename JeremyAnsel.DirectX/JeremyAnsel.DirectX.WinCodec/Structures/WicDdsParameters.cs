using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
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

    public uint Width
    {
        get => _width;
        set => _width = value;
    }

    public uint Height
    {
        get => _height;
        set => _height = value;
    }

    public uint Depth
    {
        get => _depth;
        set => _depth = value;
    }

    public uint MipLevels
    {
        get => _mipLevels;
        set => _mipLevels = value;
    }

    public uint ArraySize
    {
        get => _arraySize;
        set => _arraySize = value;
    }

    public WicDxgiFormat DxgiFormat
    {
        get => _dxgiFormat;
        set => _dxgiFormat = value;
    }

    public WicDdsDimension Dimension
    {
        get => _dimension;
        set => _dimension = value;
    }

    public WicDdsAlphaMode AlphaMode
    {
        get => _alphaMode;
        set => _alphaMode = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WicDdsParameters parameters && Equals(parameters);
    }

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

    public static bool operator ==(WicDdsParameters left, WicDdsParameters right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicDdsParameters left, WicDdsParameters right)
    {
        return !(left == right);
    }
}
