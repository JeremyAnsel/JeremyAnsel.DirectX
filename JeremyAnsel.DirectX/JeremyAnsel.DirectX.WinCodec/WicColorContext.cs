// <copyright file="WicColorContext.cs" company="Jérémy Ansel">
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
public unsafe class WicColorContext : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid WicColorContextGuid = typeof(IWicColorContext).GUID;

    private readonly nint _comPtr;
    private readonly IWicColorContext* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="WicColorContext"/> class.
    /// </summary>
    public WicColorContext(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IWicColorContext**)comPtr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename"></param>
    public void InitializeFromFilename(string filename)
    {
        InitializeFromFilename(filename.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filename"></param>
    public void InitializeFromFilename(ReadOnlySpan<char> filename)
    {
        fixed (char* str = filename)
        {
            int hr = _comImpl->InitializeFromFilename(_comPtr, str);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    public void InitializeFromMemory(byte[] buffer)
    {
        InitializeFromMemory(buffer.AsSpan());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buffer"></param>
    public void InitializeFromMemory(ReadOnlySpan<byte> buffer)
    {
        fixed (byte* ptr = buffer)
        {
            int hr = _comImpl->InitializeFromMemory(_comPtr, ptr, (uint)buffer.Length);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public void InitializeFromExifColorSpace(uint value)
    {
        int hr = _comImpl->InitializeFromExifColorSpace(_comPtr, value);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public WicColorContextType GetContextType()
    {
        WicColorContextType type;
        int hr = _comImpl->GetContextType(_comPtr, &type);
        Marshal.ThrowExceptionForHR(hr);
        return type;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetProfileBytesCount()
    {
        uint actualSize;
        int hr = _comImpl->GetProfileBytes(_comPtr, 0, null, &actualSize);
        Marshal.ThrowExceptionForHR(hr);
        return actualSize;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public byte[] GetProfileBytes()
    {
        uint count = GetProfileBytesCount();
        var bytes = new byte[count];
        GetProfileBytes(bytes.AsSpan());
        return bytes;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public uint GetProfileBytes(Span<byte> bytes)
    {
        fixed (byte* ptr = bytes)
        {
            uint actualSize;
            int hr = _comImpl->GetProfileBytes(_comPtr, (uint)bytes.Length, ptr, &actualSize);
            Marshal.ThrowExceptionForHR(hr);
            return actualSize;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public uint GetExifColorSpace()
    {
        uint value;
        int hr = _comImpl->GetExifColorSpace(_comPtr, &value);
        Marshal.ThrowExceptionForHR(hr);
        return value;
    }
}
