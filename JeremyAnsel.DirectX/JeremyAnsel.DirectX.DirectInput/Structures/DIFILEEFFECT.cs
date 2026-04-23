// <copyright file="DIFILEEFFECT.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DirectInput;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
internal struct DIFILEEFFECT
{
    public int Size;

    public Guid GuidEffect;

    public nint DiEffect;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
    public string FriendlyName;
}
