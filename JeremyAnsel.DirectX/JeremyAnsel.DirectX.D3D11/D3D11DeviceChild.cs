// <copyright file="D3D11DeviceChild.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A device-child interface accesses data used by a device.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11DeviceChild : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11DeviceChildGuid = typeof(ID3D11DeviceChild).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11DeviceChild* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DeviceChild"/> class.
    /// </summary>
    public D3D11DeviceChild(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11DeviceChild**)comPtr;
    }

    /// <summary>
    /// Sets an application-defined data to the object and associates that data with a GUID.
    /// </summary>
    /// <param name="name">A GUID that identifies the data.</param>
    /// <param name="text">The object's text.</param>
    public void SetPrivateDataText(in Guid name, string? text)
    {
        if (string.IsNullOrEmpty(text))
        {
            text = "<unnamed>";
        }

        SetPrivateDataText(in name, text.AsSpan());
    }

    /// <summary>
    /// Sets an application-defined data to the object and associates that data with a GUID.
    /// </summary>
    /// <param name="name">A GUID that identifies the data.</param>
    /// <param name="text">The object's text.</param>
    public void SetPrivateDataText(in Guid name, ReadOnlySpan<char> text)
    {
        if (text.IsEmpty)
        {
            text = "<unnamed>".AsSpan();
        }

        if (text.Length > 255)
        {
            text = text[..255];
        }

        int bytesCount;
        fixed (char* textPtr = text)
        {
            bytesCount = Encoding.ASCII.GetByteCount(textPtr, text.Length);
        }

        byte* bytesPtr = stackalloc byte[bytesCount];

        fixed (char* textPtr = text)
        {
            Encoding.ASCII.GetBytes(textPtr, text.Length, bytesPtr, bytesCount);
        }

        int hr = _comImpl->SetPrivateData(_comPtr, in name, (uint)bytesCount, bytesPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <returns>The object's text.</returns>
    public string GetPrivateDataText(in Guid name)
    {
        uint dataSize = 256;
        byte* dataPtr = stackalloc byte[(int)dataSize];
        int hr = _comImpl->GetPrivateData(_comPtr, in name, &dataSize, dataPtr);
        Marshal.ThrowExceptionForHR(hr);
        string text = Encoding.ASCII.GetString(dataPtr, (int)dataSize);
        return text;
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <returns>The count.</returns>
    public int GetPrivateDataTextCharCount(in Guid name)
    {
        uint dataSize = 0;
        int hr = _comImpl->GetPrivateData(_comPtr, in name, &dataSize, null);
        Marshal.ThrowExceptionForHR(hr);
        return (int)dataSize;
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <param name="text">A char buffer.</param>
    /// <returns>The object's text.</returns>
    public int GetPrivateDataTextChars(in Guid name, Span<char> text)
    {
        uint dataSize = 256;
        byte* dataPtr = stackalloc byte[(int)dataSize];

        int hr = _comImpl->GetPrivateData(_comPtr, in name, &dataSize, dataPtr);
        Marshal.ThrowExceptionForHR(hr);

        int count;
        fixed (char* textPtr = text)
        {
            count = Encoding.ASCII.GetChars(dataPtr, (int)dataSize, textPtr, text.Length);
        }

        return count;
    }

    /// <summary>
    /// Sets a unique name to objects in order to assist the developer during debugging.
    /// </summary>
    /// <param name="name">The friendly name.</param>
    public void SetDebugName(string? name)
    {
        SetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName, name);
    }

    /// <summary>
    /// Sets a unique name to objects in order to assist the developer during debugging.
    /// </summary>
    /// <param name="name">The friendly name.</param>
    public void SetDebugName(ReadOnlySpan<char> name)
    {
        SetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName, name);
    }

    /// <summary>
    /// Gets a unique name to objects in order to assist the developer during debugging.
    /// </summary>
    /// <returns>The friendly name.</returns>
    public string GetDebugName()
    {
        return GetPrivateDataText(D3D11WellKnownPrivateDataId.DebugObjectName);
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <returns>The count.</returns>
    public int GetDebugNameCharCount()
    {
        return GetPrivateDataTextCharCount(D3D11WellKnownPrivateDataId.DebugObjectName);
    }

    /// <summary>
    /// Gets an application-defined data from the object that is associated with a GUID.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <param name="text">A char buffer.</param>
    /// <returns>The object's text.</returns>
    public int GetDebugNameChars(Span<char> text)
    {
        return GetPrivateDataTextChars(D3D11WellKnownPrivateDataId.DebugObjectName, text);
    }

    /// <summary>
    /// Get the device that created this interface.
    /// </summary>
    /// <returns>A device.</returns>
    public D3D11Device GetDevice()
    {
        nint ptr;
        _comImpl->GetDevice(_comPtr, &ptr);
        return new D3D11Device(ptr);
    }
}
