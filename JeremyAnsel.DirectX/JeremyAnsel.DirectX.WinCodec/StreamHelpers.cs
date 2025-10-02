using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

internal static class StreamHelpers
{
    private static byte[] _buffer = new byte[32768];

    public static int CopyTo(Stream source, IntPtr destination, int length)
    {
        int bufferLength = _buffer.Length;
        int read = 0;

        while (length > 0)
        {
            int count = Math.Min(bufferLength, length);
            count = source.Read(_buffer, 0, count);

            if (count == 0)
            {
                break;
            }

            Marshal.Copy(_buffer, 0, destination + read, count);
            length -= count;
            read += count;
        }

        return read;
    }

    public static int CopyTo(IntPtr source, Stream destination, int length)
    {
        int bufferLength = _buffer.Length;
        int read = 0;

        while (length > 0)
        {
            int count = Math.Min(bufferLength, length);
            Marshal.Copy(source + read, _buffer, 0, count);
            destination.Write(_buffer, 0, count);
            length -= count;
            read += count;
        }

        return read;
    }
}
