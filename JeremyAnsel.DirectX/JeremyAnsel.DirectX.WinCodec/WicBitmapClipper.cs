// <copyright file="WicBitmapClipper.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapClipper : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapClipperGuid = typeof(IWicBitmapClipper).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapClipper* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapClipper"/> class.
    /// </summary>
    public WicBitmapClipper(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapClipper**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="source"></param>
    /// <param name="rc"></param>
    public void Initialize(WicBitmapSource source, in WicRect rc)
    {
        int hr = _comImpl->Initialize(_comPtr, source.Handle, rc);
        Marshal.ThrowExceptionForHR(hr);
    }
}
