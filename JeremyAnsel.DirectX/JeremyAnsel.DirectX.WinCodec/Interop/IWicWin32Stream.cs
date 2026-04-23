// <copyright file="IWicWin32Stream.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.Interop;

[Guid("0000000C-0000-0000-C000-000000000046")]
internal unsafe struct IWicWin32Stream
{
    public delegate* unmanaged[Stdcall]<nint, in Guid, nint*, int> QueryInterface;
    public delegate* unmanaged[Stdcall]<nint, int> AddRef;
    public delegate* unmanaged[Stdcall]<nint, int> Release;
    public delegate* unmanaged[Stdcall]<nint, void*, int, ulong*, int> Read;
    public delegate* unmanaged[Stdcall]<nint, void*, int, ulong*, int> Write;
    public delegate* unmanaged[Stdcall]<nint, ulong, int, ulong*, int> Seek;
    public delegate* unmanaged[Stdcall]<nint, ulong, int> SetSize;
    public delegate* unmanaged[Stdcall]<nint, nint, ulong, ulong*, ulong*, int> CopyTo;
    public delegate* unmanaged[Stdcall]<nint, int, int> Commit;
    public delegate* unmanaged[Stdcall]<nint, int> Revert;
    public delegate* unmanaged[Stdcall]<nint, ulong, ulong, int, int> LockRegion;
    public delegate* unmanaged[Stdcall]<nint, ulong, ulong, int, int> UnlockRegion;
    public delegate* unmanaged[Stdcall]<nint, STATSTG*, int, int> Stat;
    public delegate* unmanaged[Stdcall]<nint, nint*, int> Clone;
}
