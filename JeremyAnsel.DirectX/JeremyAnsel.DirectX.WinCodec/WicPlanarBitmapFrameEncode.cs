// <copyright file="WicPlanarBitmapFrameEncode.cs" company="Jérémy Ansel">
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
public unsafe class WicPlanarBitmapFrameEncode : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicPlanarBitmapFrameEncodeGuid = typeof(IWicPlanarBitmapFrameEncode).GUID;

    private readonly nint _comPtr;
    private readonly IWicPlanarBitmapFrameEncode* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicPlanarBitmapFrameEncode"/> class.
    /// </summary>
    public WicPlanarBitmapFrameEncode(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicPlanarBitmapFrameEncode**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="encode"></param>
    /// <returns></returns>
    public static WicPlanarBitmapFrameEncode CreatePlanarBitmapFrameEncodeFromBitmapFrameEncode(WicBitmapFrameEncode encode)
    {
        nint ptr = encode.QueryInterface(WicPlanarBitmapFrameEncodeGuid);
        return new WicPlanarBitmapFrameEncode(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineCount"></param>
    /// <param name="planes"></param>
    public void WritePixels(uint lineCount, WicBitmapPlane[] planes)
    {
        WritePixels(lineCount, planes.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineCount"></param>
    /// <param name="planes"></param>
    public void WritePixels(uint lineCount, ReadOnlySpan<WicBitmapPlane> planes)
    {
        WicBitmapPlanePtr* pPlanes = stackalloc WicBitmapPlanePtr[planes.Length];

        for (int i = 0; i < planes.Length; i++)
        {
            pPlanes[i] = new WicBitmapPlanePtr(planes[i].Format, Marshal.UnsafeAddrOfPinnedArrayElement(planes[i].Buffer, 0), planes[i].Stride, planes[i].BufferSize);
        }

        int hr = _comImpl->WritePixels(_comPtr, lineCount, pPlanes, (uint)planes.Length);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppPlanes"></param>
    /// <param name="rc"></param>
    public void WriteSource(WicBitmapSource[] ppPlanes, WicRect? rc)
    {
        WriteSource(ppPlanes.AsSpan(), rc);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppPlanes"></param>
    /// <param name="rc"></param>
    public void WriteSource(ReadOnlySpan<WicBitmapSource> ppPlanes, WicRect? rc)
    {
        nint* ptr = stackalloc nint[ppPlanes.Length];
        for (int i = 0; i < ppPlanes.Length; i++)
        {
            ptr[i] = ppPlanes[i].Handle;
        }

        if (rc is null)
        {
            int hr = _comImpl->WriteSource(_comPtr, ptr, (uint)ppPlanes.Length, null);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            WicRect prc = rc.Value;
            int hr = _comImpl->WriteSource(_comPtr, ptr, (uint)ppPlanes.Length, &prc);
            Marshal.ThrowExceptionForHR(hr);
        }
    }
}
