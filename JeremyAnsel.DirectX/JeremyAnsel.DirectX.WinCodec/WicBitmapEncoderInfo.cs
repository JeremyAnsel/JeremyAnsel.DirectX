// <copyright file="WicBitmapEncoderInfo.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapEncoderInfo : WicBitmapCodecInfo
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapEncoderInfoGuid = typeof(IWicBitmapEncoderInfo).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapEncoderInfo* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapEncoderInfo"/> class.
    /// </summary>
    public WicBitmapEncoderInfo(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapEncoderInfo**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapEncoder CreateInstance()
    {
        nint ptr;
        int hr = _comImpl->CreateInstance(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapEncoder(ptr);
    }
}
