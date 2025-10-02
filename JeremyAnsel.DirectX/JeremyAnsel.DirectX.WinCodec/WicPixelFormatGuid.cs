using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WicPixelFormatGuid : IEquatable<WicPixelFormatGuid>
{
    private Guid _format;

    public WicPixelFormatGuid(Guid format)
    {
        _format = format;
    }

    public Guid PixelFormat
    {
        get => _format;
        set => _format = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WicPixelFormatGuid guid && Equals(guid);
    }

    public bool Equals(WicPixelFormatGuid other)
    {
        return _format.Equals(other._format);
    }

    public override int GetHashCode()
    {
        return 1923152933 + _format.GetHashCode();
    }

    public static bool operator ==(WicPixelFormatGuid left, WicPixelFormatGuid right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicPixelFormatGuid left, WicPixelFormatGuid right)
    {
        return !(left == right);
    }

    public static implicit operator Guid(WicPixelFormatGuid format)
    {
        return format._format;
    }

    public static explicit operator WicPixelFormatGuid(Guid format)
    {
        return new WicPixelFormatGuid(format);
    }

    public override string ToString()
    {
        return _format.ToString();
    }
}
