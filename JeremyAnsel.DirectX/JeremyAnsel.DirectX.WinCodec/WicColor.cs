using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WicColor : IEquatable<WicColor>
{
    private uint _color;

    public WicColor(uint color)
    {
        _color = color;
    }

    public uint Color
    {
        get => _color;
        set => _color = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WicColor color && Equals(color);
    }

    public bool Equals(WicColor other)
    {
        return _color == other._color;
    }

    public override int GetHashCode()
    {
        return -1740376583 + _color.GetHashCode();
    }

    public static bool operator ==(WicColor left, WicColor right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicColor left, WicColor right)
    {
        return !(left == right);
    }

    public static implicit operator uint(WicColor color)
    {
        return color._color;
    }

    public static explicit operator WicColor(uint color)
    {
        return new WicColor(color);
    }
}
