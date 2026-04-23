// <copyright file="WicBitmapFrameEncode.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapFrameEncode : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapFrameEncodeGuid = typeof(IWicBitmapFrameEncode).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapFrameEncode* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapFrameEncode"/> class.
    /// </summary>
    public WicBitmapFrameEncode(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapFrameEncode**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Initialize()
    {
        int hr = _comImpl->Initialize(_comPtr, 0);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void SetSize(uint width, uint height)
    {
        int hr = _comImpl->SetSize(_comPtr, width, height);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dpiX"></param>
    /// <param name="dpiY"></param>
    public void SetResolution(double dpiX, double dpiY)
    {
        int hr = _comImpl->SetResolution(_comPtr, dpiX, dpiY);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="format"></param>
    public void SetPixelFormat(in WicPixelFormatGuid format)
    {
        int hr = _comImpl->SetPixelFormat(_comPtr, format);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppIColorContext"></param>
    public void SetColorContexts(WicColorContext[] ppIColorContext)
    {
        nint* ptr = stackalloc nint[ppIColorContext.Length];
        for (int i = 0; i < ppIColorContext.Length; i++)
        {
            ptr[i] = ppIColorContext[i].Handle;
        }

        int hr = _comImpl->SetColorContexts(_comPtr, (uint)ppIColorContext.Length, ptr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="palette"></param>
    public void SetPalette(WicPalette palette)
    {
        int hr = _comImpl->SetPalette(_comPtr, palette.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pIThumbnail"></param>
    public void SetThumbnail(WicBitmapSource pIThumbnail)
    {
        int hr = _comImpl->SetThumbnail(_comPtr, pIThumbnail.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineCount"></param>
    /// <param name="cbStride"></param>
    /// <param name="pixels"></param>
    /// <param name="length"></param>
    public void WritePixels(uint lineCount, uint cbStride, nint pixels, int length)
    {
        int hr = _comImpl->WritePixels(_comPtr, lineCount, cbStride, (uint)length, (void*)pixels);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineCount"></param>
    /// <param name="cbStride"></param>
    /// <param name="pixels"></param>
    public void WritePixels(uint lineCount, uint cbStride, byte[] pixels)
    {
        fixed (byte* ptr = pixels)
        {
            int hr = _comImpl->WritePixels(_comPtr, lineCount, cbStride, (uint)pixels.Length, ptr);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineCount"></param>
    /// <param name="cbStride"></param>
    /// <param name="pixels"></param>
    /// <param name="start"></param>
    /// <param name="length"></param>
    public void WritePixels(uint lineCount, uint cbStride, byte[] pixels, int start, int length)
    {
        fixed (byte* ptr = pixels)
        {
            int hr = _comImpl->WritePixels(_comPtr, lineCount, cbStride, (uint)length, ptr + start);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="lineCount"></param>
    /// <param name="cbStride"></param>
    /// <param name="pixels"></param>
    public void WritePixels(uint lineCount, uint cbStride, ReadOnlySpan<byte> pixels)
    {
        fixed (byte* ptr = pixels)
        {
            int hr = _comImpl->WritePixels(_comPtr, lineCount, cbStride, (uint)pixels.Length, ptr);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pIBitmapSource"></param>
    /// <param name="rc"></param>
    public void WriteSource(WicBitmapSource pIBitmapSource, WicRect? rc)
    {
        if (rc is null)
        {
            int hr = _comImpl->WriteSource(_comPtr, pIBitmapSource.Handle, null);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            WicRect prc = rc.Value;
            int hr = _comImpl->WriteSource(_comPtr, pIBitmapSource.Handle, &prc);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void Commit()
    {
        int hr = _comImpl->Commit(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
