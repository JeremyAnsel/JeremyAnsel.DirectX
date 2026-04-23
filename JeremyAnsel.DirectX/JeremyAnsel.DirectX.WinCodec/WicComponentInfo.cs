// <copyright file="WicComponentInfo.cs" company="Jérémy Ansel">
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
public unsafe class WicComponentInfo : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicComponentInfoGuid = typeof(IWicComponentInfo).GUID;

    private readonly nint _comPtr;
    private readonly IWicComponentInfo* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicComponentInfo"/> class.
    /// </summary>
    public WicComponentInfo(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicComponentInfo**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicComponentType GetComponentType()
    {
        WicComponentType type;
        int hr = _comImpl->GetComponentType(_comPtr, &type);
        Marshal.ThrowExceptionForHR(hr);
        return type;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Guid GetCLSID()
    {
        Guid guid;
        int hr = _comImpl->GetCLSID(_comPtr, &guid);
        Marshal.ThrowExceptionForHR(hr);
        return guid;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicComponentSigning GetSigningStatus()
    {
        WicComponentSigning status;
        int hr = _comImpl->GetSigningStatus(_comPtr, &status);
        Marshal.ThrowExceptionForHR(hr);
        return status;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetAuthorLength()
    {
        uint actual;
        int hr = _comImpl->GetAuthor(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetAuthor()
    {
        char* str = stackalloc char[256];
        uint actual;
        int hr = _comImpl->GetAuthor(_comPtr, 256, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetAuthor(Span<char> str)
    {
        fixed (char* s = str)
        {
            uint actual;
            int hr = _comImpl->GetAuthor(_comPtr, (uint)str.Length, s, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Guid GetVendorGUID()
    {
        Guid guid;
        int hr = _comImpl->GetVendorGUID(_comPtr, &guid);
        Marshal.ThrowExceptionForHR(hr);
        return guid;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetVersionLength()
    {
        uint actual;
        int hr = _comImpl->GetVersion(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetVersion()
    {
        char* str = stackalloc char[256];
        uint actual;
        int hr = _comImpl->GetVersion(_comPtr, 256, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetVersion(Span<char> str)
    {
        fixed (char* s = str)
        {
            uint actual;
            int hr = _comImpl->GetVersion(_comPtr, (uint)str.Length, s, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetSpecVersionLength()
    {
        uint actual;
        int hr = _comImpl->GetSpecVersion(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetSpecVersion()
    {
        char* str = stackalloc char[256];
        uint actual;
        int hr = _comImpl->GetSpecVersion(_comPtr, 256, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetSpecVersion(Span<char> str)
    {
        fixed (char* s = str)
        {
            uint actual;
            int hr = _comImpl->GetSpecVersion(_comPtr, (uint)str.Length, s, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetFriendlyNameLength()
    {
        uint actual;
        int hr = _comImpl->GetFriendlyName(_comPtr, 0, null, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return actual;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GetFriendlyName()
    {
        char* str = stackalloc char[256];
        uint actual;
        int hr = _comImpl->GetFriendlyName(_comPtr, 256, str, &actual);
        Marshal.ThrowExceptionForHR(hr);
        return new string(str);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public uint GetFriendlyName(Span<char> str)
    {
        fixed (char* s = str)
        {
            uint actual;
            int hr = _comImpl->GetFriendlyName(_comPtr, (uint)str.Length, s, &actual);
            Marshal.ThrowExceptionForHR(hr);
            return actual;
        }
    }
}
