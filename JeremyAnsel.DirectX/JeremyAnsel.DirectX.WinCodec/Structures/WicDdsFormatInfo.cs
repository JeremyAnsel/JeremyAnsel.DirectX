using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WicDdsFormatInfo : IEquatable<WicDdsFormatInfo>
{
    private WicDxgiFormat _dxgiFormat;

    private uint _bytesPerBlock;

    private uint _blockWidth;

    private uint _blockHeight;

    public WicDxgiFormat DxgiFormat
    {
        get => _dxgiFormat;
        set => _dxgiFormat = value;
    }

    public uint BytesPerBlock
    {
        get => _bytesPerBlock;
        set => _bytesPerBlock = value;
    }

    public uint BlockWidth
    {
        get => _blockWidth;
        set => _blockWidth = value;
    }

    public uint BlockHeight
    {
        get => _blockHeight;
        set => _blockHeight = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WicDdsFormatInfo info && Equals(info);
    }

    public bool Equals(WicDdsFormatInfo other)
    {
        return _dxgiFormat == other._dxgiFormat &&
               _bytesPerBlock == other._bytesPerBlock &&
               _blockWidth == other._blockWidth &&
               _blockHeight == other._blockHeight;
    }

    public override int GetHashCode()
    {
        int hashCode = 1602030783;
        hashCode = hashCode * -1521134295 + _dxgiFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + _bytesPerBlock.GetHashCode();
        hashCode = hashCode * -1521134295 + _blockWidth.GetHashCode();
        hashCode = hashCode * -1521134295 + _blockHeight.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(WicDdsFormatInfo left, WicDdsFormatInfo right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicDdsFormatInfo left, WicDdsFormatInfo right)
    {
        return !(left == right);
    }
}
