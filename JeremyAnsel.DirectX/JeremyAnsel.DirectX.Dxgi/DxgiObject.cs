// <copyright file="DxgiObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIObject</c> interface is a base interface for all DXGI objects. <c>IDXGIObject</c> supports associating caller-defined (private data) with an object and retrieval of an interface to the parent object.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiObject : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiObjectGuid = typeof(IDxgiObject).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiObject* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiObject"/> class.
    /// </summary>
    public DxgiObject(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiObject**)comPtr;
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
    /// Gets the parent of the object.
    /// </summary>
    /// <param name="riid">The ID of the requested interface.</param>
    /// <returns>The address of a pointer to the parent object.</returns>
    public nint GetParent(in Guid riid)
    {
        nint ptr;
        int hr = _comImpl->GetParent(_comPtr, in riid, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }
}
