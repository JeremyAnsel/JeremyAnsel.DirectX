// <copyright file="WicBitmapDecoder.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapDecoder : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapDecoderGuid = typeof(IWicBitmapDecoder).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapDecoder* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapDecoder"/> class.
    /// </summary>
    public WicBitmapDecoder(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapDecoder**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public WicBitmapDecoderCapabilities QueryCapability(Stream stream)
    {
        var comStream = new WicWin32ComStream(stream);
        WicBitmapDecoderCapabilities pdwCapability;
        int hr = _comImpl->QueryCapability(_comPtr, comStream.Handle, &pdwCapability);
        Marshal.ThrowExceptionForHR(hr);
        return pdwCapability;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cacheOptions"></param>
    public void Initialize(Stream stream, WicDecodeOptions cacheOptions)
    {
        var comStream = new WicWin32ComStream(stream);
        int hr = _comImpl->Initialize(_comPtr, comStream.Handle, cacheOptions);
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
    public WicBitmapDecoderInfo GetDecoderInfo()
    {
        nint ptr;
        int hr = _comImpl->GetDecoderInfo(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapDecoderInfo(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="palette"></param>
    public void CopyPalette(WicPalette palette)
    {
        int hr = _comImpl->CopyPalette(_comPtr, palette.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapSource GetPreview()
    {
        nint ptr;
        int hr = _comImpl->GetPreview(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapSource(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetColorContextsCount()
    {
        uint pcActualCount;
        int hr = _comImpl->GetColorContexts(_comPtr, 0, null, &pcActualCount);
        Marshal.ThrowExceptionForHR(hr);
        return pcActualCount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColorContext[] GetColorContexts()
    {
        uint count = GetColorContextsCount();
        var contexts = new WicColorContext[count];
        GetColorContexts(contexts.AsSpan());
        return contexts;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contexts"></param>
    /// <returns></returns>
    public uint GetColorContexts(Span<WicColorContext> contexts)
    {
        nint* ptr = stackalloc nint[contexts.Length];
        uint pcActualCount;
        int hr = _comImpl->GetColorContexts(_comPtr, (uint)contexts.Length, ptr, &pcActualCount);
        Marshal.ThrowExceptionForHR(hr);

        for (int i = 0; i < contexts.Length; i++)
        {
            contexts[i] = new WicColorContext(ptr[i]);
        }

        return pcActualCount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicBitmapSource GetThumbnail()
    {
        nint ptr;
        int hr = _comImpl->GetThumbnail(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapSource(ptr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetFrameCount()
    {
        uint count;
        int hr = _comImpl->GetFrameCount(_comPtr, &count);
        Marshal.ThrowExceptionForHR(hr);
        return count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public WicBitmapFrameDecode GetFrame(uint index)
    {
        nint ptr;
        int hr = _comImpl->GetFrame(_comPtr, index, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicBitmapFrameDecode(ptr);
    }
}
