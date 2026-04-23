// <copyright file="DIDATAFORMAT.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal struct DIDATAFORMAT
{
    public int Size;

    public int ObjSize;

    public DIDF Flags;

    public int DataSize;

    public int NumObjs;

    public nint rgodf;
}
