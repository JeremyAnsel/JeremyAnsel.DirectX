// <copyright file="WicBitmapSource.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapSource : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapSourceGuid = typeof(IWicBitmapSource).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapSource* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapSource"/> class.
    /// </summary>
    public WicBitmapSource(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapSource**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <exception cref="ObjectDisposedException"></exception>
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
    /// <exception cref="ObjectDisposedException"></exception>
    public WicPixelFormatGuid GetPixelFormat()
    {
        WicPixelFormatGuid format;
        int hr = _comImpl->GetPixelFormat(_comPtr, &format);
        Marshal.ThrowExceptionForHR(hr);
        return format;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dpiX"></param>
    /// <param name="dpiY"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void GetResolution(out double dpiX, out double dpiY)
    {
        double x;
        double y;
        int hr = _comImpl->GetResolution(_comPtr, &x, &y);
        Marshal.ThrowExceptionForHR(hr);
        dpiX = x;
        dpiY = y;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="palette"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void CopyPalette(WicPalette palette)
    {
        int hr = _comImpl->CopyPalette(_comPtr, palette.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="stride"></param>
    /// <param name="buffer"></param>
    /// <param name="length"></param>
    public void CopyPixels(WicRect? rc, uint stride, nint buffer, int length)
    {
        if (rc is null)
        {
            int hr = _comImpl->CopyPixels(_comPtr, null, stride, (uint)length, buffer);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            WicRect rect = rc.Value;
            int hr = _comImpl->CopyPixels(_comPtr, &rect, stride, (uint)length, buffer);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="stride"></param>
    /// <param name="buffer"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void CopyPixels(WicRect? rc, uint stride, byte[] buffer)
    {
        if (rc is null)
        {
            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyPixels(_comPtr, null, stride, (uint)buffer.Length, (nint)ptr);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        else
        {
            WicRect rect = rc.Value;

            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyPixels(_comPtr, &rect, stride, (uint)buffer.Length, (nint)ptr);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="stride"></param>
    /// <param name="buffer"></param>
    /// <param name="start"></param>
    /// <param name="length"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void CopyPixels(WicRect? rc, uint stride, byte[] buffer, int start, int length)
    {
        if (rc is null)
        {
            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyPixels(_comPtr, null, stride, (uint)length, (nint)ptr + start);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        else
        {
            WicRect rect = rc.Value;

            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyPixels(_comPtr, &rect, stride, (uint)length, (nint)ptr + start);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rc"></param>
    /// <param name="stride"></param>
    /// <param name="buffer"></param>
    public void CopyPixels(WicRect? rc, uint stride, Span<byte> buffer)
    {
        if (rc is null)
        {
            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyPixels(_comPtr, null, stride, (uint)buffer.Length, (nint)ptr);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        else
        {
            WicRect rect = rc.Value;

            fixed (byte* ptr = buffer)
            {
                int hr = _comImpl->CopyPixels(_comPtr, &rect, stride, (uint)buffer.Length, (nint)ptr);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
    }
}
