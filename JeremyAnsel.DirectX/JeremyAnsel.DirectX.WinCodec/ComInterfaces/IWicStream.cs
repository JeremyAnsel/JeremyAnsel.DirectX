// <copyright file="IWicStream.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from IStream</remarks>
[Guid("135FF860-22B7-4ddf-B0F6-218F4F299A43")]
internal unsafe readonly struct IWicStream
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int, void*, int> Read;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int, void*, int> Write;

    public readonly delegate* unmanaged[Stdcall]<nint, long, int, void*, int> Seek;

    public readonly delegate* unmanaged[Stdcall]<nint, long, int> SetSize;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, long, void*, void*, int> CopyTo;

    public readonly delegate* unmanaged[Stdcall]<nint, int, int> Commit;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Revert;

    public readonly delegate* unmanaged[Stdcall]<nint, long, long, int, int> LockRegion;

    public readonly delegate* unmanaged[Stdcall]<nint, long, long, int, int> UnlockRegion;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, int, int> Stat;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> Clone;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> InitializeFromIStream;

    public readonly delegate* unmanaged[Stdcall]<nint, char*, WicWin32GenericAccessRights, int> InitializeFromFilename;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int> InitializeFromMemory;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, ulong, ulong, int> InitializeFromIStreamRegion;
}
