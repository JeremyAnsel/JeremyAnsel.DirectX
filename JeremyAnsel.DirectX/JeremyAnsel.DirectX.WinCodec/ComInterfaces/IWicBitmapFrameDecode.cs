// <copyright file="IWicBitmapFrameDecode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[Guid("3B16811B-6A43-4ec9-A813-3D930C13B940")]
internal unsafe readonly struct IWicBitmapFrameDecode
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetSize;
    private readonly nint GetPixelFormat;
    private readonly nint GetResolution;
    private readonly nint CopyPalette;
    private readonly nint CopyPixels;

    public readonly delegate* unmanaged[Stdcall]<nint, int> GetMetadataQueryReader;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, uint*, int> GetColorContexts;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetThumbnail;
}
