// <copyright file="IWicBitmapSource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94")]
internal unsafe readonly struct IWicBitmapSource
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, uint*, int> GetSize;

    public readonly delegate* unmanaged[Stdcall]<nint, WicPixelFormatGuid*, int> GetPixelFormat;

    public readonly delegate* unmanaged[Stdcall]<nint, double*, double*, int> GetResolution;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> CopyPalette;

    public readonly delegate* unmanaged[Stdcall]<nint, WicRect*, uint, uint, nint, int> CopyPixels;
}
