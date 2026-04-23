// <copyright file="IWicPalette.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("00000040-a8f2-4877-ba0a-fd2b6645fb94")]
internal unsafe readonly struct IWicPalette
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, WicBitmapPaletteType, int, int> InitializePredefined;

    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, int> InitializeCustom;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, int, int> InitializeFromBitmap;

    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> InitializeFromPalette;

    public readonly delegate* unmanaged[Stdcall]<nint, WicBitmapPaletteType*, int> GetPaletteType;

    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetColorCount;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, uint*, int> GetColors;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> IsBlackWhite;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> IsGrayscale;

    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> HasAlpha;
}
