// <copyright file="IWicBitmapFlipRotator.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

/// <remarks>Inherited from <see cref="IWicBitmapSource"/></remarks>
[Guid("00000302-a8f2-4877-ba0a-fd2b6645fb94")]
internal unsafe readonly struct IWicBitmapScaler
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetSize;
    private readonly nint GetPixelFormat;
    private readonly nint GetResolution;
    private readonly nint CopyPalette;
    private readonly nint CopyPixels;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint, WicBitmapInterpolationMode, int> Initialize;
}
