using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct WicImageParameters : IEquatable<WicImageParameters>
{
    private WicD2D1PixelFormat _pixelFormat;

    private float _dpiX;

    private float _dpiY;

    private float _top;

    private float _left;

    private uint _pixelWidth;

    private uint _pixelHeight;

    public WicImageParameters(WicD2D1PixelFormat pixelFormat, float dpiX, float dpiY, float top, float left, uint width, uint height)
    {
        _pixelFormat = pixelFormat;
        _dpiX = dpiX;
        _dpiY = dpiY;
        _top = top;
        _left = left;
        _pixelWidth = width;
        _pixelHeight = height;
    }

    public WicImageParameters(WicDxgiFormat format, WicD2D1AlphaMode alphaMode, float dpiX, float dpiY, float top, float left, uint width, uint height)
    {
        _pixelFormat = new WicD2D1PixelFormat(format, alphaMode);
        _dpiX = dpiX;
        _dpiY = dpiY;
        _top = top;
        _left = left;
        _pixelWidth = width;
        _pixelHeight = height;
    }

    public WicD2D1PixelFormat PixelFormat
    {
        get => _pixelFormat;
        set => _pixelFormat = value;
    }

    public float DpiX
    {
        get => _dpiX;
        set => _dpiX = value;
    }

    public float DpiY
    {
        get => _dpiY;
        set => _dpiY = value;
    }

    public float Top
    {
        get => _top;
        set => _top = value;
    }

    public float Left
    {
        get => _left;
        set => _left = value;
    }

    public uint PixelWidth
    {
        get => _pixelWidth;
        set => _pixelWidth = value;
    }

    public uint PixelHeight
    {
        get => _pixelHeight;
        set => _pixelHeight = value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WicImageParameters parameters && Equals(parameters);
    }

    public bool Equals(WicImageParameters other)
    {
        return _pixelFormat.Equals(other._pixelFormat) &&
               _dpiX == other._dpiX &&
               _dpiY == other._dpiY &&
               _top == other._top &&
               _left == other._left &&
               _pixelWidth == other._pixelWidth &&
               _pixelHeight == other._pixelHeight;
    }

    public override int GetHashCode()
    {
        int hashCode = -392116673;
        hashCode = hashCode * -1521134295 + _pixelFormat.GetHashCode();
        hashCode = hashCode * -1521134295 + _dpiX.GetHashCode();
        hashCode = hashCode * -1521134295 + _dpiY.GetHashCode();
        hashCode = hashCode * -1521134295 + _top.GetHashCode();
        hashCode = hashCode * -1521134295 + _left.GetHashCode();
        hashCode = hashCode * -1521134295 + _pixelWidth.GetHashCode();
        hashCode = hashCode * -1521134295 + _pixelHeight.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(WicImageParameters left, WicImageParameters right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicImageParameters left, WicImageParameters right)
    {
        return !(left == right);
    }
}
