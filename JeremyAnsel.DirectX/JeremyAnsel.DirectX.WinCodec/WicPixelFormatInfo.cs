// <copyright file="WicPixelFormatInfo.cs" company="Jérémy Ansel">
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
public unsafe class WicPixelFormatInfo : WicComponentInfo
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicPixelFormatInfoGuid = typeof(IWicPixelFormatInfo2).GUID;

    private readonly nint _comPtr;
    private readonly IWicPixelFormatInfo2* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicPixelFormatInfo"/> class.
    /// </summary>
    public WicPixelFormatInfo(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicPixelFormatInfo2**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Guid GetFormatGUID()
    {
        Guid format;
        int hr = _comImpl->GetFormatGUID(_comPtr, &format);
        Marshal.ThrowExceptionForHR(hr);
        return format;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColorContext GetColorContext()
    {
        nint ptr;
        int hr = _comImpl->GetColorContext(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicColorContext(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetBitsPerPixel()
    {
        uint bpp;
        int hr = _comImpl->GetBitsPerPixel(_comPtr, &bpp);
        Marshal.ThrowExceptionForHR(hr);
        return bpp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetChannelCount()
    {
        uint channels;
        int hr = _comImpl->GetChannelCount(_comPtr, &channels);
        Marshal.ThrowExceptionForHR(hr);
        return channels;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ObjectDisposedException"></exception>
    public bool SupportsTransparency()
    {
        int value;
        int hr = _comImpl->SupportsTransparency(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicPixelFormatNumericRepresentation GetNumericRepresentation()
    {
        WicPixelFormatNumericRepresentation numericRepresentation;
        int hr = _comImpl->GetNumericRepresentation(_comPtr, &numericRepresentation);
        Marshal.ThrowExceptionForHR(hr);
        return numericRepresentation;
    }
}
