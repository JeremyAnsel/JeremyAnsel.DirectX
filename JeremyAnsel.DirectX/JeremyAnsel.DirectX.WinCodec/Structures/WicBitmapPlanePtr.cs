using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal readonly struct WicBitmapPlanePtr : IEquatable<WicBitmapPlanePtr>
{
    private readonly WicPixelFormatGuid _format;

    private readonly IntPtr _buffer;

    private readonly uint _stride;

    private readonly uint _bufferSize;

    public WicBitmapPlanePtr(in WicPixelFormatGuid format, IntPtr buffer, uint stride, uint bufferSize)
    {
        _format = format;
        _buffer = buffer;
        _stride = stride;
        _bufferSize = bufferSize;
    }

    public WicPixelFormatGuid Format => _format;

    public IntPtr Buffer => _buffer;

    public uint Stride => _stride;

    public uint BufferSize => _bufferSize;

    public override bool Equals(object? obj)
    {
        return obj is WicBitmapPlanePtr ptr && Equals(ptr);
    }

    public bool Equals(WicBitmapPlanePtr other)
    {
        return _format.Equals(other._format) &&
               EqualityComparer<IntPtr>.Default.Equals(_buffer, other._buffer) &&
               _stride == other._stride &&
               _bufferSize == other._bufferSize;
    }

    public override int GetHashCode()
    {
        int hashCode = 1564312497;
        hashCode = hashCode * -1521134295 + _format.GetHashCode();
        hashCode = hashCode * -1521134295 + _buffer.GetHashCode();
        hashCode = hashCode * -1521134295 + _stride.GetHashCode();
        hashCode = hashCode * -1521134295 + _bufferSize.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(WicBitmapPlanePtr left, WicBitmapPlanePtr right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WicBitmapPlanePtr left, WicBitmapPlanePtr right)
    {
        return !(left == right);
    }
}
