// <copyright file="WicImageEncoder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.WinCodec.ComInterfaces;
using JeremyAnsel.DirectX.WinCodec.ComInteropInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// 
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class WicImageEncoder : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicImageEncoderGuid = typeof(IWicImageEncoder).GUID;

    private readonly nint _comPtr;
    private readonly IWicImageEncoder* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicImageEncoder"/> class.
    /// </summary>
    public WicImageEncoder(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicImageEncoder**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Image"></param>
    /// <param name="encode"></param>
    /// <param name="parameters"></param>
    public void WriteFrame(DXComObject d2d1Image, WicBitmapFrameEncode encode, WicImageParameters? parameters)
    {
        WriteFrame(d2d1Image.Handle, encode, parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Image"></param>
    /// <param name="encode"></param>
    /// <param name="parameters"></param>
    /// <exception cref="ObjectDisposedException"></exception>
    public void WriteFrame(nint d2d1Image, WicBitmapFrameEncode encode, WicImageParameters? parameters)
    {
        nint ptr = DXUtils.QueryInterface(d2d1Image, ComInteropInterfacesGuids.D2D1ImageGuid);

        try
        {
            if (parameters is null)
            {
                int hr = _comImpl->WriteFrame(_comPtr, ptr, encode.Handle, null);
                Marshal.ThrowExceptionForHR(hr);
            }
            else
            {
                WicImageParameters pParameters = parameters.Value;
                int hr = _comImpl->WriteFrame(_comPtr, ptr, encode.Handle, &pParameters);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Image"></param>
    /// <param name="encode"></param>
    /// <param name="parameters"></param>
    public void WriteFrameThumbnail(DXComObject d2d1Image, WicBitmapFrameEncode encode, WicImageParameters? parameters)
    {
        WriteFrameThumbnail(d2d1Image.Handle, encode, parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Image"></param>
    /// <param name="encode"></param>
    /// <param name="parameters"></param>
    public void WriteFrameThumbnail(nint d2d1Image, WicBitmapFrameEncode encode, WicImageParameters? parameters)
    {
        nint ptr = DXUtils.QueryInterface(d2d1Image, ComInteropInterfacesGuids.D2D1ImageGuid);

        try
        {
            if (parameters is null)
            {
                int hr = _comImpl->WriteFrameThumbnail(_comPtr, ptr, encode.Handle, null);
                Marshal.ThrowExceptionForHR(hr);
            }
            else
            {
                WicImageParameters pParameters = parameters.Value;
                int hr = _comImpl->WriteFrameThumbnail(_comPtr, ptr, encode.Handle, &pParameters);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Image"></param>
    /// <param name="encode"></param>
    /// <param name="parameters"></param>
    public void WriteThumbnail(DXComObject d2d1Image, WicBitmapEncoder encode, WicImageParameters? parameters)
    {
        WriteThumbnail(d2d1Image.Handle, encode, parameters);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="d2d1Image"></param>
    /// <param name="encode"></param>
    /// <param name="parameters"></param>
    public void WriteThumbnail(nint d2d1Image, WicBitmapEncoder encode, WicImageParameters? parameters)
    {
        nint ptr = DXUtils.QueryInterface(d2d1Image, ComInteropInterfacesGuids.D2D1ImageGuid);

        try
        {
            if (parameters is null)
            {
                int hr = _comImpl->WriteThumbnail(_comPtr, ptr, encode.Handle, null);
                Marshal.ThrowExceptionForHR(hr);
            }
            else
            {
                WicImageParameters pParameters = parameters.Value;
                int hr = _comImpl->WriteThumbnail(_comPtr, ptr, encode.Handle, &pParameters);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }
}
