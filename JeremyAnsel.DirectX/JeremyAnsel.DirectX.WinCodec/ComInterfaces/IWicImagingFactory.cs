// <copyright file="IWicImagingFactory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("7B816B45-1996-4476-B132-DE9E247C8AF0")]
internal unsafe readonly struct IWicImagingFactory
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, char*, void*, WicWin32GenericAccessRights, WicDecodeOptions, nint*, int> CreateDecoderFromFilename;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, WicDecodeOptions, nint*, int> CreateDecoderFromStream;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, WicDecodeOptions, nint*, int> CreateDecoderFromFileHandle;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint*, int> CreateComponentInfo;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, void*, nint*, int> CreateDecoder;

    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, void*, nint*, int> CreateEncoder;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreatePalette;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateFormatConverter;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateBitmapScaler;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateBitmapClipper;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateBitmapFlipRotator;

    public readonly delegate* unmanaged[Stdcall]<nint, int> CreateStream;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateColorContext;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateColorTransformer;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, in WicPixelFormatGuid, WicBitmapCreateCacheOption, nint*, int> CreateBitmap;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, WicBitmapCreateCacheOption, nint*, int> CreateBitmapFromSource;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint, uint, uint, nint*, int> CreateBitmapFromSourceRect;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, in WicPixelFormatGuid, uint, uint, void*, nint*, int> CreateBitmapFromMemory;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, WicBitmapAlphaChannelOption, nint*, int> CreateBitmapFromHBITMAP;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, int> CreateBitmapFromHICON;

    public readonly delegate* unmanaged[Stdcall]<nint, int> CreateComponentEnumerator;

    public readonly delegate* unmanaged[Stdcall]<nint, int> CreateFastMetadataEncoderFromDecoder;

    public readonly delegate* unmanaged[Stdcall]<nint, int> CreateFastMetadataEncoderFromFrameDecode;

    public readonly delegate* unmanaged[Stdcall]<nint, int> CreateQueryWriter;

    public readonly delegate* unmanaged[Stdcall]<nint, int> CreateQueryWriterFromReader;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, int> CreateImageEncoder;
}
