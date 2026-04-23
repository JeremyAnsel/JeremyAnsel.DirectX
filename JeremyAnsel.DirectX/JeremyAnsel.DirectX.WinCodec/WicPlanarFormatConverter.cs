// <copyright file="WicPlanarFormatConverter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class WicPlanarFormatConverter : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicPlanarFormatConverterGuid = typeof(IWicPlanarFormatConverter).GUID;

    private readonly nint _comPtr;
    private readonly IWicPlanarFormatConverter* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicPlanarFormatConverter"/> class.
    /// </summary>
    public WicPlanarFormatConverter(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicPlanarFormatConverter**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="converter"></param>
    /// <returns></returns>
    public static WicPlanarFormatConverter CreatePlanarFormatConverterFromFormatConverter(WicFormatConverter converter)
    {
        nint ptr = converter.QueryInterface(WicPlanarFormatConverterGuid);
        return new WicPlanarFormatConverter(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppPlanes"></param>
    /// <param name="dstFormat"></param>
    /// <param name="dither"></param>
    /// <param name="pIPalette"></param>
    /// <param name="alphaThresholdPercent"></param>
    /// <param name="paletteTranslate"></param>
    public void Initialize(
        WicBitmapSource[] ppPlanes,
        in WicPixelFormatGuid dstFormat,
        WicBitmapDitherType dither,
        WicPalette? pIPalette,
        double alphaThresholdPercent,
        WicBitmapPaletteType paletteTranslate)
    {
        Initialize(ppPlanes.AsSpan(), dstFormat, dither, pIPalette, alphaThresholdPercent, paletteTranslate);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppPlanes"></param>
    /// <param name="dstFormat"></param>
    /// <param name="dither"></param>
    /// <param name="pIPalette"></param>
    /// <param name="alphaThresholdPercent"></param>
    /// <param name="paletteTranslate"></param>
    public void Initialize(
        ReadOnlySpan<WicBitmapSource> ppPlanes,
        in WicPixelFormatGuid dstFormat,
        WicBitmapDitherType dither,
        WicPalette? pIPalette,
        double alphaThresholdPercent,
        WicBitmapPaletteType paletteTranslate)
    {
        nint* ptr = stackalloc nint[ppPlanes.Length];
        for (int i = 0; i < ppPlanes.Length; i++)
        {
            ptr[i] = ppPlanes[i].Handle;
        }

        int hr = _comImpl->Initialize(
            _comPtr,
            ptr,
            (uint)ppPlanes.Length,
            dstFormat,
            dither,
            pIPalette is null ? 0 : pIPalette.Handle,
            alphaThresholdPercent,
            paletteTranslate);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pSrcPixelFormats"></param>
    /// <param name="dstPixelFormat"></param>
    /// <returns></returns>
    public bool CanConvert(WicPixelFormatGuid[] pSrcPixelFormats, in WicPixelFormatGuid dstPixelFormat)
    {
        return CanConvert(pSrcPixelFormats.AsSpan(), dstPixelFormat);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pSrcPixelFormats"></param>
    /// <param name="dstPixelFormat"></param>
    /// <returns></returns>
    public bool CanConvert(ReadOnlySpan<WicPixelFormatGuid> pSrcPixelFormats, in WicPixelFormatGuid dstPixelFormat)
    {
        fixed (WicPixelFormatGuid* ptr = pSrcPixelFormats)
        {
            int canConvert;
            int hr = _comImpl->CanConvert(_comPtr, ptr, (uint)pSrcPixelFormats.Length, dstPixelFormat, &canConvert);
            Marshal.ThrowExceptionForHR(hr);
            return canConvert != 0;
        }
    }
}
