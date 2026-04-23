// <copyright file="STATSTG.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.WinCodec.Interop;

internal unsafe struct STATSTG
{
    public void* pwcsName;
    public int type;
    public ulong cbSize;
    public ulong mtime;
    public ulong ctime;
    public ulong atime;
    public int grfMode;
    public int grfLocksSupported;
    public Guid clsid;
    public int grfStateBits;
    public int reserved;
}
