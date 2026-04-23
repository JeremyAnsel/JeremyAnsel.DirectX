// <copyright file="WicDdsEncoder.cs" company="Jérémy Ansel">
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
public unsafe class WicDdsEncoder : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicDdsEncoderGuid = typeof(IWicDdsEncoder).GUID;

    private readonly nint _comPtr;
    private readonly IWicDdsEncoder* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicDdsEncoder"/> class.
    /// </summary>
    public WicDdsEncoder(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicDdsEncoder**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="encoder"></param>
    /// <returns></returns>
    public static WicDdsEncoder CreatDdsDecoderFromBitmapDecoder(WicBitmapEncoder encoder)
    {
        nint ptr = DXUtils.QueryInterface(encoder.Handle, WicDdsEncoderGuid);
        return new WicDdsEncoder(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pParameters"></param>
    public void SetParameters(in WicDdsParameters pParameters)
    {
        int hr = _comImpl->SetParameters(_comPtr, pParameters);
        Marshal.ThrowExceptionForHR(hr);
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
    /// <returns></returns>
    public WicBitmapFrameEncode CreateNewFrame()
    {
        return CreateNewFrame(out _, out _, out _);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pArrayIndex"></param>
    /// <param name="pMipLevel"></param>
    /// <param name="pSliceIndex"></param>
    /// <returns></returns>
    public WicBitmapFrameEncode CreateNewFrame(out uint pArrayIndex, out uint pMipLevel, out uint pSliceIndex)
    {
        nint ptr;
        uint arrayIndex;
        uint mipLevel;
        uint sliceIndex;
        int hr = _comImpl->CreateNewFrame(_comPtr, &ptr, &arrayIndex, &mipLevel, &sliceIndex);
        Marshal.ThrowExceptionForHR(hr);
        pArrayIndex = arrayIndex;
        pMipLevel = mipLevel;
        pSliceIndex = sliceIndex;
        return new WicBitmapFrameEncode(ptr);
    }
}
