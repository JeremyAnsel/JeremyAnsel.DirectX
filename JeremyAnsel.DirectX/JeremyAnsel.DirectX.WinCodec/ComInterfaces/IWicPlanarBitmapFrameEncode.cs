// <copyright file="IWicPlanarBitmapFrameEncode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.WinCodec.ComInterfaces;

[Guid("F928B7B8-2221-40C1-B72E-7E82F1974D1A")]
internal unsafe readonly struct IWicPlanarBitmapFrameEncode
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    public readonly delegate* unmanaged[Stdcall]<nint, uint, WicBitmapPlanePtr*, uint, int> WritePixels;

    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint, WicRect*, int> WriteSource;
}
