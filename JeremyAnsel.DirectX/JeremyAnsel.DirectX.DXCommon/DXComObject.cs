// <copyright file="DXComObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DXCommon;

/// <summary>
/// A COM object.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DXComObject : IDisposable
{
    private readonly nint _comPtr;
    private readonly IDXUnknown* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DXComObject"/> class.
    /// </summary>
    /// <param name="comPtr">A COM pointer.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public DXComObject(nint comPtr)
    {
        if (comPtr == 0)
        {
            throw new ArgumentNullException(nameof(comPtr));
        }

        _comPtr = comPtr;
        _comImpl = *(IDXUnknown**)comPtr;
    }

    /// <summary>
    /// Gets an handle representing the COM object interface.
    /// </summary>
    public nint Handle => _comPtr;

    /// <summary>
    /// Dispose the COM object.
    /// </summary>
    public void Dispose()
    {
        _comImpl->Release(_comPtr);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Add reference to COM object.
    /// </summary>
    /// <returns>The reference count.</returns>
    public int AddRef()
    {
        return _comImpl->AddRef(_comPtr);
    }

    /// <summary>
    /// Release a COM object.
    /// </summary>
    /// <returns>The reference count.</returns>
    public int Release()
    {
        return _comImpl->Release(_comPtr);
    }

    /// <summary>
    /// Query a COM interface.
    /// </summary>
    /// <param name="iid">The GUID identifier of the interface.</param>
    /// <returns>The interface pointer.</returns>
    public nint QueryInterface(in Guid iid)
    {
        nint ptr = 0;
        int hr = _comImpl->QueryInterface(_comPtr, iid, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }
}
