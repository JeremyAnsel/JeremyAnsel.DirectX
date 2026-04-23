// <copyright file="WicDdsDecoder.cs" company="Jérémy Ansel">
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
public unsafe class WicDdsDecoder : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicDdsDecoderGuid = typeof(IWicDdsDecoder).GUID;

    private readonly nint _comPtr;
    private readonly IWicDdsDecoder* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicDdsDecoder"/> class.
    /// </summary>
    public WicDdsDecoder(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicDdsDecoder**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="decoder"></param>
    /// <returns></returns>
    public static WicDdsDecoder CreatDdsDecoderFromBitmapDecoder(WicBitmapDecoder decoder)
    {
        nint ptr = DXUtils.QueryInterface(decoder.Handle, WicDdsDecoderGuid);
        return new WicDdsDecoder(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicDdsParameters GetParameters()
    {
        WicDdsParameters parameters;
        int hr = _comImpl->GetParameters(_comPtr, &parameters);
        Marshal.ThrowExceptionForHR(hr);
        return parameters;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrayIndex"></param>
    /// <param name="mipLevel"></param>
    /// <param name="sliceIndex"></param>
    /// <returns></returns>
    public WicBitmapFrameDecode GetFrame(uint arrayIndex, uint mipLevel, uint sliceIndex)
    {
        nint ptr;
        int hr = _comImpl->GetFrame(_comPtr, arrayIndex, mipLevel, sliceIndex, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapFrameDecode(ptr);
    }
}
