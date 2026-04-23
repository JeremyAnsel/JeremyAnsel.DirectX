// <copyright file="WicBitmapScaler.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapScaler : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapScalerGuid = typeof(IWicBitmapScaler).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapScaler* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapScaler"/> class.
    /// </summary>
    public WicBitmapScaler(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapScaler**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="mode"></param>
    public void Initialize(WicBitmapSource source, uint width, uint height, WicBitmapInterpolationMode mode)
    {
        int hr = _comImpl->Initialize(_comPtr, source.Handle, width, height, mode);
        Marshal.ThrowExceptionForHR(hr);
    }
}
