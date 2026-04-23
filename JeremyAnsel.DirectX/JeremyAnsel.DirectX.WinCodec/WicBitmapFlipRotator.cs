// <copyright file="WicBitmapFlipRotator.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapFlipRotator : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapFlipRotatorGuid = typeof(IWicBitmapFlipRotator).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapFlipRotator* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapFlipRotator"/> class.
    /// </summary>
    public WicBitmapFlipRotator(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapFlipRotator**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="options"></param>
    public void Initialize(WicBitmapSource source, WicBitmapTransformOptions options)
    {
        int hr = _comImpl->Initialize(_comPtr, source.Handle, options);
        Marshal.ThrowExceptionForHR(hr);
    }
}
