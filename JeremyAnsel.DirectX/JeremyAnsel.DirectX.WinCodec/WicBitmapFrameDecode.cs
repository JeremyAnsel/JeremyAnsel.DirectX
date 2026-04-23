// <copyright file="WicBitmapFrameDecode.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapFrameDecode : WicBitmapSource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapFrameDecodeGuid = typeof(IWicBitmapFrameDecode).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapFrameDecode* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapFrameDecode"/> class.
    /// </summary>
    public WicBitmapFrameDecode(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapFrameDecode**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetColorContextsCount()
    {
        uint actualCount;
        int hr = _comImpl->GetColorContexts(_comPtr, 0, null, &actualCount);
        Marshal.ThrowExceptionForHR(hr);
        return actualCount;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColorContext[] GetColorContexts()
    {
        uint count = GetColorContextsCount();
        nint* ptr = stackalloc nint[(int)count];
        uint actualCount;
        int hr = _comImpl->GetColorContexts(_comPtr, count, ptr, &actualCount);
        Marshal.ThrowExceptionForHR(hr);

        var contexts = new WicColorContext[count];
        for (int i = 0; i < count; i++)
        {
            contexts[i] = new WicColorContext(ptr[i]);
        }

        return contexts;
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
}
