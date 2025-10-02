using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public readonly struct WicBitmapPlane : IEquatable<WicBitmapPlane>
{
    private readonly WicPixelFormatGuid _format;

    [MarshalAs(UnmanagedType.LPArray)]
    private readonly Array _buffer;

    private readonly uint _stride;

    private readonly uint _bufferSize;

    public WicBitmapPlane(in WicPixelFormatGuid format, Array buffer, uint stride, uint bufferSize)
    {
        _format = format;
        _buffer = buffer;
        _stride = stride;
        _bufferSize = bufferSize;
    }

    public WicPixelFormatGuid Format => _format;

    public Array Buffer => _buffer;

    public uint Stride => _stride;

    public uint BufferSize => _bufferSize;

    public override bool Equals(object? obj)
    {
        return obj is WicBitmapPlane plane && Equals(plane);
    }

    public bool Equals(WicBitmapPlane other)
    {
        return _format.Equals(other._format) &&
               EqualityComparer<Array>.Default.Equals(_buffer, other._buffer) &&
               _stride == other._stride &&
               _bufferSize == other._bufferSize;
    }

    public override int GetHashCode()
    {
        int hashCode = 1564312497;
        hashCode = hashCode * -1521134295 + _format.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<Array>.Default.GetHashCode(_buffer);
        hashCode = hashCode * -1521134295 + _stride.GetHashCode();
        hashCode = hashCode * -1521134295 + _bufferSize.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(WicBitmapPlane left, WicBitmapPlane right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicBitmapPlane left, WicBitmapPlane right)
    {
        return !(left == right);
    }
}
