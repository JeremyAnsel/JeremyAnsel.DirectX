// <copyright file="DIOBJECTDATAFORMAT.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

internal struct DIOBJECTDATAFORMAT
{
    public nint Guid;

    public int Ofs;

    public DIDFT Type;

    public DIDOI Flags;
}
