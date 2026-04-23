// <copyright file="DxgiResource1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIResource1</c> interface extends the <c>IDXGIResource</c> interface by adding support for creating a sub-resource surface object and for creating a handle to a shared resource.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiResource2 : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiResource2Guid = typeof(IDxgiResource1).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiResource1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiResource2"/> class.
    /// </summary>
    public DxgiResource2(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiResource1**)comPtr;
    }

    /// <summary>
    /// Gets the expected resource usage.
    /// </summary>
    public DxgiUsages Usage
    {
        get
        {
            DxgiUsages usage;
            int hr = _comImpl->GetUsage(_comPtr, &usage);
            Marshal.ThrowExceptionForHR(hr);
            return usage;
        }
    }

    /// <summary>
    /// Gets or sets the eviction priority.
    /// </summary>
    public DxgiResourceEvictionPriority EvictionPriority
    {
        get
        {
            DxgiResourceEvictionPriority priority;
            int hr = _comImpl->GetEvictionPriority(_comPtr, &priority);
            Marshal.ThrowExceptionForHR(hr);
            return priority;
        }

        set
        {
            int hr = _comImpl->SetEvictionPriority(_comPtr, value);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Gets the handle to a shared resource.
    /// </summary>
    /// <returns>A handle.</returns>
    public nint GetSharedHandle()
    {
        nint handle;
        int hr = _comImpl->GetSharedHandle(_comPtr, &handle);
        Marshal.ThrowExceptionForHR(hr);
        return handle;
    }

    /// <summary>
    /// Creates a sub-resource surface object.
    /// </summary>
    /// <param name="index">The index of the sub-resource surface object to enumerate.</param>
    /// <returns>A <c>IDXGISurface2</c> interface that represents the created sub-resource surface object at the position specified.</returns>
    public DxgiSurface2 CreateSubresourceSurface(uint index)
    {
        nint ptr;
        int hr = _comImpl->CreateSubresourceSurface(_comPtr, index, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiSurface2(ptr);
    }
}
