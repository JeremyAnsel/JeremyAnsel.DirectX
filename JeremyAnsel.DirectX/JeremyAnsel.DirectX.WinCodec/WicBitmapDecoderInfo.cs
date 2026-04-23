// <copyright file="WicBitmapDecoderInfo.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using JeremyAnsel.DirectX.WinCodec.Interop;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class WicBitmapDecoderInfo : WicBitmapCodecInfo
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapDecoderInfoGuid = typeof(IWicBitmapDecoderInfo).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapDecoderInfo* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapDecoderInfo"/> class.
    /// </summary>
    public WicBitmapDecoderInfo(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapDecoderInfo**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public bool MatchesPattern(Stream stream)
    {
        var comStream = new WicWin32ComStream(stream);
        int value;
        int hr = _comImpl->MatchesPattern(_comPtr, comStream.Handle, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapDecoder CreateInstance()
    {
        nint ptr;
        int hr = _comImpl->CreateInstance(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapDecoder(ptr);
    }
}
