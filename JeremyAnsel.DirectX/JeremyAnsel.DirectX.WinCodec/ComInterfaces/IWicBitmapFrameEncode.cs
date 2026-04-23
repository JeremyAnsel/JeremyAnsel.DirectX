// <copyright file="IWicBitmapFrameEncode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("00000105-a8f2-4877-ba0a-fd2b6645fb94")]
internal unsafe readonly struct IWicBitmapFrameEncode
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, int> SetSize;

    public readonly delegate* unmanaged[Stdcall]<nint, double, double, int> SetResolution;

    public readonly delegate* unmanaged[Stdcall]<nint, in WicPixelFormatGuid, int> SetPixelFormat;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> SetColorContexts;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetPalette;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetThumbnail;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint, void*, int> WritePixels;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, WicRect*, int> WriteSource;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Commit;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetMetadataQueryWriter;
}
