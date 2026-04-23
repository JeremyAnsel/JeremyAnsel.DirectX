// <copyright file="WicBitmapEncoder.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapEncoder : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapEncoderGuid = typeof(IWicBitmapEncoder).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapEncoder* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapEncoder"/> class.
    /// </summary>
    public WicBitmapEncoder(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapEncoder**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cacheOption"></param>
    public void Initialize(Stream stream, WicBitmapEncoderCacheOption cacheOption)
    {
        var comStream = new WicWin32ComStream(stream);
        int hr = _comImpl->Initialize(_comPtr, comStream.Handle, cacheOption);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Guid GetContainerFormat()
    {
        Guid format;
        int hr = _comImpl->GetContainerFormat(_comPtr, &format);
        Marshal.ThrowExceptionForHR(hr);
        return format;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapEncoderInfo GetEncoderInfo()
    {
        nint ptr;
        int hr = _comImpl->GetEncoderInfo(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapEncoderInfo(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppIColorContext"></param>
    public void SetColorContexts(WicColorContext[] ppIColorContext)
    {
        SetColorContexts(ppIColorContext.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ppIColorContext"></param>
    public void SetColorContexts(ReadOnlySpan<WicColorContext> ppIColorContext)
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
    /// <param name="pIPalette"></param>
    public void SetPalette(WicPalette pIPalette)
    {
        int hr = _comImpl->SetPalette(_comPtr, pIPalette.Handle);
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
    /// <param name="pIPreview"></param>
    public void SetPreview(WicBitmapSource pIPreview)
    {
        int hr = _comImpl->SetPreview(_comPtr, pIPreview.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapFrameEncode CreateNewFrame()
    {
        nint ptr;
        int hr = _comImpl->CreateNewFrame(_comPtr, &ptr, null);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapFrameEncode(ptr);
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
