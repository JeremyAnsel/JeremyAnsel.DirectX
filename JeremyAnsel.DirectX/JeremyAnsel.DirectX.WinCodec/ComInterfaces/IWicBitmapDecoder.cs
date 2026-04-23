// <copyright file="IWicBitmapDecoder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("9EDDE9E7-8DEE-47ea-99DF-E6FAF2ED44BF")]
internal unsafe readonly struct IWicBitmapDecoder
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, WicBitmapDecoderCapabilities*, int> QueryCapability;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, WicDecodeOptions, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, Guid*, int> GetContainerFormat;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetDecoderInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> CopyPalette;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetMetadataQueryReader;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetPreview;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, uint*, int> GetColorContexts;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetThumbnail;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetFrameCount;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> GetFrame;
}
