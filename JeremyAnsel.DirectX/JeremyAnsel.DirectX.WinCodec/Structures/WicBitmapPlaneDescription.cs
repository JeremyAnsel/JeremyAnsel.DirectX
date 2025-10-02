using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WicBitmapPlaneDescription : IEquatable<WicBitmapPlaneDescription>
{
    private WicPixelFormatGuid _format;

    private uint _width;

    private uint _height;

    public WicBitmapPlaneDescription(in WicPixelFormatGuid format, uint width, uint height)
    {
        _format = format;
        _width = width;
        _height = height;
    }

    public WicPixelFormatGuid Format
    {
        get => _format;
        set => _format = value;
    }

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

    public override bool Equals(object? obj)
    {
        return obj is WicBitmapPlaneDescription description && Equals(description);
    }

    public bool Equals(WicBitmapPlaneDescription other)
    {
        return _format.Equals(other._format) &&
               _width == other._width &&
               _height == other._height;
    }

    public override int GetHashCode()
    {
        int hashCode = 1016763756;
        hashCode = hashCode * -1521134295 + _format.GetHashCode();
        hashCode = hashCode * -1521134295 + _width.GetHashCode();
        hashCode = hashCode * -1521134295 + _height.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(WicBitmapPlaneDescription left, WicBitmapPlaneDescription right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicBitmapPlaneDescription left, WicBitmapPlaneDescription right)
    {
        return !(left == right);
    }
}
