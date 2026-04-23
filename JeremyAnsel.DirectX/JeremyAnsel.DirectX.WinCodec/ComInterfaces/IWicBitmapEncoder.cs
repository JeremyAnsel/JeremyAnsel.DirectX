// <copyright file="IWicBitmapEncoder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("00000103-a8f2-4877-ba0a-fd2b6645fb94")]
internal unsafe readonly struct IWicBitmapEncoder
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, WicBitmapEncoderCacheOption, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetContainerFormat;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetEncoderInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> SetColorContexts;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetPalette;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetThumbnail;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> SetPreview;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void*, int> CreateNewFrame;

    public readonly delegate* unmanaged[Stdcall]<nint, int> Commit;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetMetadataQueryWriter;
}
