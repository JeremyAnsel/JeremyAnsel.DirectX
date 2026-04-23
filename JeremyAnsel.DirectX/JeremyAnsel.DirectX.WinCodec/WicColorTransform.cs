// <copyright file="WicColorTransform.cs" company="Jérémy Ansel">
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
public unsafe class WicColorTransform : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicColorTransformGuid = typeof(IWicColorTransform).GUID;

    private readonly nint _comPtr;
    private readonly IWicColorTransform* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicColorTransform"/> class.
    /// </summary>
    public WicColorTransform(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicColorTransform**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pIBitmapSource"></param>
    /// <param name="pIContextSource"></param>
    /// <param name="pIContextDest"></param>
    /// <param name="pixelFmtDest"></param>
    public void Initialize(
        WicBitmapSource pIBitmapSource,
        WicColorContext pIContextSource,
        WicColorContext pIContextDest,
        in WicPixelFormatGuid pixelFmtDest)
    {
        int hr = _comImpl->Initialize(_comPtr, pIBitmapSource.Handle, pIContextSource.Handle, pIContextDest.Handle, pixelFmtDest);
        Marshal.ThrowExceptionForHR(hr);
    }
}
