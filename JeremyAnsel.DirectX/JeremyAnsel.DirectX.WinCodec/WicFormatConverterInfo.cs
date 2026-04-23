// <copyright file="WicFormatConverterInfo.cs" company="Jérémy Ansel">
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
public unsafe class WicFormatConverterInfo : WicComponentInfo
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicFormatConverterInfoGuid = typeof(IWicFormatConverterInfo).GUID;

    private readonly nint _comPtr;
    private readonly IWicFormatConverterInfo* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicFormatConverterInfo"/> class.
    /// </summary>
    public WicFormatConverterInfo(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicFormatConverterInfo**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetPixelFormatsCount()
    {
        uint actual;
        int hr = _comImpl->GetPixelFormats(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicPixelFormatGuid[] GetPixelFormats()
    {
        uint count = GetPixelFormatsCount();
        var formats = new WicPixelFormatGuid[(int)count];
        GetPixelFormats(formats.AsSpan());
        return formats;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formats"></param>
    /// <returns></returns>
    public uint GetPixelFormats(Span<WicPixelFormatGuid> formats)
    {
        fixed (WicPixelFormatGuid* ptr = formats)
        {
            uint actual;
            int hr = _comImpl->GetPixelFormats(_comPtr, (uint)formats.Length, ptr, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicFormatConverter CreateInstance()
    {
        nint ptr;
        int hr = _comImpl->CreateInstance(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new WicFormatConverter(ptr);
    }
}
