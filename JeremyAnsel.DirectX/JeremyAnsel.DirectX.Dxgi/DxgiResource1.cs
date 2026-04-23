// <copyright file="DxgiResource1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIResource</c> interface allows resource sharing and identifies the memory that a resource resides in.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiResource1 : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiResource1Guid = typeof(IDxgiResource).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiResource* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiResource1"/> class.
    /// </summary>
    public DxgiResource1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiResource**)comPtr;
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
}
