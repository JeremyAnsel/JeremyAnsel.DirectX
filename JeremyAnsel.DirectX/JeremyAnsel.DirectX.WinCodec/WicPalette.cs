// <copyright file="WicPalette.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
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
public unsafe class WicPalette : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicPaletteGuid = typeof(IWicPalette).GUID;

    private readonly nint _comPtr;
    private readonly IWicPalette* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicPalette"/> class.
    /// </summary>
    public WicPalette(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicPalette**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ePaletteType"></param>
    /// <param name="fAddTransparentColor"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void InitializePredefined(WicBitmapPaletteType ePaletteType, bool fAddTransparentColor)
    {
        int hr = _comImpl->InitializePredefined(_comPtr, ePaletteType, fAddTransparentColor ? 1 : 0);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="colors"></param>
    public void InitializeCustom(WicColor[] colors)
    {
        InitializeCustom(colors.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="colors"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void InitializeCustom(ReadOnlySpan<WicColor> colors)
    {
        fixed (WicColor* ptr = colors)
        {
            int hr = _comImpl->InitializeCustom(_comPtr, ptr, (uint)colors.Length);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="surface"></param>
    /// <param name="colorCount"></param>
    /// <param name="fAddTransparentColor"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void InitializeFromBitmap(WicBitmapSource surface, uint colorCount, bool fAddTransparentColor)
    {
        int hr = _comImpl->InitializeFromBitmap(_comPtr, surface.Handle, colorCount, fAddTransparentColor ? 1 : 0);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="palette"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void InitializeFromPalette(WicPalette palette)
    {
        int hr = _comImpl->InitializeFromPalette(_comPtr, palette.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    public WicBitmapPaletteType GetPaletteType()
    {
        WicBitmapPaletteType type;
        int hr = _comImpl->GetPaletteType(_comPtr, &type);
        Marshal.ThrowExceptionForHR(hr);
        return type;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    public uint GetColorCount()
    {
        uint count = 0;
        int hr = _comImpl->GetColorCount(_comPtr, &count);
        Marshal.ThrowExceptionForHR(hr);
        return count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColor[] GetColors()
    {
        return GetColors(out _);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="actualColors"></param>
    /// <returns></returns>
    public WicColor[] GetColors(out uint actualColors)
    {
        uint count = GetColorCount();
        var colors = new WicColor[count];
        actualColors = GetColors(colors.AsSpan());
        return colors;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="colors"></param>
    /// <returns>The actual colors count.</returns>
    public uint GetColors(Span<WicColor> colors)
    {
        fixed (WicColor* ptr = colors)
        {
            uint actualColors;
            int hr = _comImpl->GetColors(_comPtr, (uint)colors.Length, ptr, &actualColors);
            Marshal.ThrowExceptionForHR(hr);
            return actualColors;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsBlackWhite()
    {
        int isBlackWhite;
        int hr = _comImpl->IsBlackWhite(_comPtr, &isBlackWhite);
        Marshal.ThrowExceptionForHR(hr);
        return isBlackWhite != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool IsGrayscale()
    {
        int isGrayscale;
        int hr = _comImpl->IsGrayscale(_comPtr, &isGrayscale);
        Marshal.ThrowExceptionForHR(hr);
        return isGrayscale != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool HasAlpha()
    {
        int hasAlpha;
        int hr = _comImpl->HasAlpha(_comPtr, &hasAlpha);
        Marshal.ThrowExceptionForHR(hr);
        return hasAlpha != 0;
    }
}
