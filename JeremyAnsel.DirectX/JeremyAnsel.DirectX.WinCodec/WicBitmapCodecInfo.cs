// <copyright file="WicBitmapCodecInfo.cs" company="Jérémy Ansel">
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
public unsafe class WicBitmapCodecInfo : WicComponentInfo
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicBitmapCodecInfoGuid = typeof(IWicBitmapCodecInfo).GUID;

    private readonly nint _comPtr;
    private readonly IWicBitmapCodecInfo* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicBitmapCodecInfo"/> class.
    /// </summary>
    public WicBitmapCodecInfo(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicBitmapCodecInfo**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Guid GetContainerFormat()
    {
        Guid guid;
        int hr = _comImpl->GetContainerFormat(_comPtr, &guid);
        Marshal.ThrowExceptionForHR(hr);
        return guid;
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
    public Guid[] GetPixelFormats()
    {
        uint count = GetPixelFormatsCount();
        var formats = new Guid[count];
        GetPixelFormats(formats.AsSpan());
        return formats;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="formats"></param>
    public uint GetPixelFormats(Span<Guid> formats)
    {
        fixed (Guid* ptr = formats)
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
    public uint GetColorManagementVersionLength()
    {
        uint actual;
        int hr = _comImpl->GetColorManagementVersion(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetColorManagementVersion()
    {
        char* str = stackalloc char[256];
        uint actual;
        int hr = _comImpl->GetColorManagementVersion(_comPtr, 256, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetColorManagementVersion(Span<char> str)
    {
        fixed (char* ptr = str)
        {
            uint actual;
            int hr = _comImpl->GetColorManagementVersion(_comPtr, (uint)str.Length, ptr, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetDeviceManufacturerLength()
    {
        uint actual;
        int hr = _comImpl->GetDeviceManufacturer(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetDeviceManufacturer()
    {
        char* str = stackalloc char[256];
        uint actual;
        int hr = _comImpl->GetDeviceManufacturer(_comPtr, 256, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetDeviceManufacturer(Span<char> str)
    {
        fixed (char* ptr = str)
        {
            uint actual;
            int hr = _comImpl->GetDeviceManufacturer(_comPtr, (uint)str.Length, ptr, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetDeviceModelsLength()
    {
        uint actual;
        int hr = _comImpl->GetDeviceModels(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetDeviceModels()
    {
        char* str = stackalloc char[1024];
        uint actual;
        int hr = _comImpl->GetDeviceModels(_comPtr, 1024, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetDeviceModels(Span<char> str)
    {
        fixed (char* ptr = str)
        {
            uint actual;
            int hr = _comImpl->GetDeviceModels(_comPtr, (uint)str.Length, ptr, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetMimeTypesLength()
    {
        uint actual;
        int hr = _comImpl->GetMimeTypes(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetMimeTypes()
    {
        char* str = stackalloc char[1024];
        uint actual;
        int hr = _comImpl->GetMimeTypes(_comPtr, 1024, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetMimeTypes(Span<char> str)
    {
        fixed (char* ptr = str)
        {
            uint actual;
            int hr = _comImpl->GetMimeTypes(_comPtr, (uint)str.Length, ptr, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetFileExtensionsLength()
    {
        uint actual;
        int hr = _comImpl->GetFileExtensions(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetFileExtensions()
    {
        char* str = stackalloc char[1024];
        uint actual;
        int hr = _comImpl->GetFileExtensions(_comPtr, 1024, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetFileExtensions(Span<char> str)
    {
        fixed (char* ptr = str)
        {
            uint actual;
            int hr = _comImpl->GetFileExtensions(_comPtr, (uint)str.Length, ptr, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool DoesSupportAnimation()
    {
        int value;
        int hr = _comImpl->DoesSupportAnimation(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool DoesSupportChromakey()
    {
        int value;
        int hr = _comImpl->DoesSupportChromakey(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool DoesSupportLossless()
    {
        int value;
        int hr = _comImpl->DoesSupportLossless(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public bool DoesSupportMultiframe()
    {
        int value;
        int hr = _comImpl->DoesSupportMultiframe(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value != 0;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mimeType"></param>
    /// <returns></returns>
    public bool MatchesMimeType(string mimeType)
    {
        return MatchesMimeType(mimeType.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mimeType"></param>
    /// <returns></returns>
    public bool MatchesMimeType(ReadOnlySpan<char> mimeType)
    {
        fixed (char* str = mimeType)
        {
            int value;
            int hr = _comImpl->MatchesMimeType(_comPtr, str, &value);
            Marshal.ThrowExceptionForHR(hr);
            return value != 0;
        }
    }
}
