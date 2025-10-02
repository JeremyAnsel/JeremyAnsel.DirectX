using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WicRect : IEquatable<WicRect>
{
    private int _x;

    private int _y;

    private int _width;

    private int _height;

    public WicRect(int x, int y, int width, int height)
    {
        _x = x;
        _y = y;
        _width = width;
        _height = height;
    }

    public int X
    {
        get => _x;
        set => _x = value;
    }

    public int Y
    {
        get => _y;
        set => _y = value;
    }

    public int Width
    {
        get => _width;
        set => _width = value;
    }

    public int Height
    {
        get => _height;
        set => _height = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WicRect rect && Equals(rect);
    }

    public bool Equals(WicRect other)
    {
        return _x == other._x &&
               _y == other._y &&
               _width == other._width &&
               _height == other._height;
    }

    public override int GetHashCode()
    {
        int hashCode = -2100647786;
        hashCode = hashCode * -1521134295 + _x.GetHashCode();
        hashCode = hashCode * -1521134295 + _y.GetHashCode();
        hashCode = hashCode * -1521134295 + _width.GetHashCode();
        hashCode = hashCode * -1521134295 + _height.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(WicRect left, WicRect right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicRect left, WicRect right)
    {
        return !(left == right);
    }
}
