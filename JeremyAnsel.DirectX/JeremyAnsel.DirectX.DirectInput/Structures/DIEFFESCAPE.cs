// <copyright file="DIEFFESCAPE.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIEFFESCAPE
{
    public int Size;

    public int Command;

    [MarshalAs(UnmanagedType.LPArray)]
    byte[] lpvInBuffer;

    public int InBufferSize;

    [MarshalAs(UnmanagedType.LPArray)]
    public byte[] OutBuffer;

    public int OutBufferSize;
}
