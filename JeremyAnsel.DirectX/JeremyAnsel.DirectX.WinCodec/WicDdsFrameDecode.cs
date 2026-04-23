// <copyright file="WicDdsFrameDecode.cs" company="Jérémy Ansel">
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
public unsafe class WicDdsFrameDecode : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicDdsFrameDecodeGuid = typeof(IWicDdsFrameDecode).GUID;

    private readonly nint _comPtr;
    private readonly IWicDdsFrameDecode* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicDdsFrameDecode"/> class.
    /// </summary>
    public WicDdsFrameDecode(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicDdsFrameDecode**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="decode"></param>
    /// <returns></returns>
    public static WicDdsFrameDecode CreateDdsFrameDecodeFromBitmapFrameDecode(WicBitmapFrameDecode decode)
    {
        nint ptr = DXUtils.QueryInterface(decode.Handle, WicDdsFrameDecodeGuid);
        return new WicDdsFrameDecode(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pWidthInBlocks"></param>
    /// <param name="pHeightInBlocks"></param>
    public void GetSizeInBlocks(out uint pWidthInBlocks, out uint pHeightInBlocks)
    {
        uint w;
        uint h;
        int hr = _comImpl->GetSizeInBlocks(_comPtr, &w, &h);
        Marshal.ThrowExceptionForHR(hr);
        pWidthInBlocks = w;
        pHeightInBlocks = h;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicDdsFormatInfo GetFormatInfo()
    {
        WicDdsFormatInfo info;
        int hr = _comImpl->GetFormatInfo(_comPtr, &info);
        Marshal.ThrowExceptionForHR(hr);
        return info;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="cbStride"></param>
    /// <param name="buffer"></param>
    public void CopyBlocks(WicRect? rc, uint cbStride, byte[] buffer)
    {
        CopyBlocks(rc, cbStride, buffer.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="cbStride"></param>
    /// <param name="buffer"></param>
    public void CopyBlocks(WicRect? rc, uint cbStride, ReadOnlySpan<byte> buffer)
    {
        if (rc is null)
        {
            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyBlocks(_comPtr, null, cbStride, (uint)buffer.Length, ptr);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        else
        {
            fixed (byte* ptr = buffer)
            {
                WicRect prc = rc.Value;
                int hr = _comImpl->CopyBlocks(_comPtr, &prc, cbStride, (uint)buffer.Length, ptr);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
    }
}
