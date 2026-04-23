// <copyright file="StreamHelpers.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec;

[SkipLocalsInit]
internal unsafe static class StreamHelpers
{
    private const int BufferLength = 32768;

    private static readonly byte[] _buffer = new byte[BufferLength];

    public static int CopyTo(Stream source, nint destination, int length)
    {
        int read = 0;

        while (length > 0)
        {
            int count = Math.Min(BufferLength, length);
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

    public static int CopyTo(nint source, Stream destination, int length)
    {
        int read = 0;

        while (length > 0)
        {
            int count = Math.Min(BufferLength, length);
            Marshal.Copy(source + read, _buffer, 0, count);
            destination.Write(_buffer, 0, count);
            length -= count;
            read += count;
        }

        return read;
    }
}
