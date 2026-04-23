// <copyright file="WicFormatConverter.cs" company="Jérémy Ansel">
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
public unsafe class WicFormatConverter : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicFormatConverterGuid = typeof(IWicFormatConverter).GUID;

    private readonly nint _comPtr;
    private readonly IWicFormatConverter* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicFormatConverter"/> class.
    /// </summary>
    public WicFormatConverter(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicFormatConverter**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pISource"></param>
    /// <param name="dstFormat"></param>
    /// <param name="dither"></param>
    /// <param name="pIPalette"></param>
    /// <param name="alphaThresholdPercent"></param>
    /// <param name="paletteTranslate"></param>
    public void Initialize(
        WicBitmapSource pISource,
        in WicPixelFormatGuid dstFormat,
        WicBitmapDitherType dither,
        WicPalette? pIPalette,
        double alphaThresholdPercent,
        WicBitmapPaletteType paletteTranslate)
    {
        int hr = _comImpl->Initialize(
            _comPtr,
            pISource.Handle,
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
    /// <param name="srcPixelFormat"></param>
    /// <param name="dstPixelFormat"></param>
    /// <returns></returns>
    public bool CanConvert(in WicPixelFormatGuid srcPixelFormat, in WicPixelFormatGuid dstPixelFormat)
    {
        int canConvert;
        int hr = _comImpl->CanConvert(_comPtr, srcPixelFormat, dstPixelFormat, &canConvert);
        Marshal.ThrowExceptionForHR(hr);
        return canConvert != 0;
    }
}
