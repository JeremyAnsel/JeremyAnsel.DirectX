// <copyright file="IWicBitmapLock.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("00000123-a8f2-4877-ba0a-fd2b6645fb94")]
internal unsafe readonly struct IWicBitmapLock
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, uint*, int> GetSize;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetStride;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*,  nint*, int> GetDataPointer;

    public readonly delegate* unmanaged[Stdcall]<nint, WicPixelFormatGuid*, int> GetPixelFormat;
}
