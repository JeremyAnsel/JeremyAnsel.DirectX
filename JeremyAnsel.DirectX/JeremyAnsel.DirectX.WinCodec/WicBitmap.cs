// <copyright file="WicBitmap.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmap : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapGuid = typeof(IWicBitmap).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmap* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmap"/> class.
    /// </summary>
    public WicBitmap(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmap**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public WicBitmapLock Lock(in WicRect rc, WicBitmapLockFlags flags)
    {
        nint ptr;
        int hr = _comImpl->Lock(_comPtr, rc, flags, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapLock(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pIPalette"></param>
    public void SetPalette(WicPalette pIPalette)
    {
        int hr = _comImpl->SetPalette(_comPtr, pIPalette.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dpiX"></param>
    /// <param name="dpiY"></param>
    public void SetResolution(double dpiX, double dpiY)
    {
        int hr = _comImpl->SetResolution(_comPtr, dpiX, dpiY);
        Marshal.ThrowExceptionForHR(hr);
    }
}
