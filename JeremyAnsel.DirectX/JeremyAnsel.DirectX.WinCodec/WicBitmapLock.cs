// <copyright file="WicBitmapLock.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapLock : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapLockGuid = typeof(IWicBitmapLock).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapLock* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapLock"/> class.
    /// </summary>
    public WicBitmapLock(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapLock**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void GetSize(out uint width, out uint height)
    {
        uint w;
        uint h;
        int hr = _comImpl->GetSize(_comPtr, &w, &h);
        Marshal.ThrowExceptionForHR(hr);
        width = w;
        height = h;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetStride()
    {
        uint stride;
        int hr = _comImpl->GetStride(_comPtr, &stride);
        Marshal.ThrowExceptionForHR(hr);
        return stride;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="size"></param>
    /// <param name="data"></param>
    public void GetDataPointer(out uint size, out nint data)
    {
        uint s;
        nint d;
        int hr = _comImpl->GetDataPointer(_comPtr, &s, &d);
        Marshal.ThrowExceptionForHR(hr);
        size = s;
        data = d;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicPixelFormatGuid GetPixelFormat()
    {
        WicPixelFormatGuid format;
        int hr = _comImpl->GetPixelFormat(_comPtr, &format);
        Marshal.ThrowExceptionForHR(hr);
        return format;
    }
}
