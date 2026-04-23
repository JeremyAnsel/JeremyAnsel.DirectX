// <copyright file="IWicPlanarFormatConverter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[Guid("BEBEE9CB-83B0-4DCC-8132-B0AAA55EAC96")]
internal unsafe readonly struct IWicPlanarFormatConverter
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetSize;
    private readonly nint GetPixelFormat;
    private readonly nint GetResolution;
    private readonly nint CopyPalette;
    private readonly nint CopyPixels;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint, in WicPixelFormatGuid, WicBitmapDitherType, nint, double, WicBitmapPaletteType, int> Initialize;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, in WicPixelFormatGuid, int*, int> CanConvert;
}
