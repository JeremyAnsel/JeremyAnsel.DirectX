// <copyright file="DxgiDevice1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIDevice1</c> interface implements a derived class for DXGI objects that produce image data.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiDevice1 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiDevice1Guid = typeof(IDxgiDevice1).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiDevice1* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice1"/> class.
    /// </summary>
    public DxgiDevice1(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiDevice1**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice1"/> class.
    /// </summary>
    /// <param name="device">A device interface which implements the <c>IDxgiDevice1</c> interface.</param>
    public static DxgiDevice1 CreateDeviceFromDevice(DXComObject device)
    {
        return CreateDeviceFromDevice(device.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice1"/> class.
    /// </summary>
    /// <param name="device">A device interface which implements the <c>IDxgiDevice1</c> interface.</param>
    public static DxgiDevice1 CreateDeviceFromDevice(nint device)
    {
        if (device == 0)
        {
            throw new ArgumentNullException(nameof(device));
        }

        nint ptr = DXUtils.QueryInterface(device, DxgiDevice1Guid);
        return new DxgiDevice1(ptr);
    }

    /// <summary>
    /// Gets or sets the number of frames that the system is allowed to queue for rendering.
    /// </summary>
    /// <returns>The number of frames that can be queued for render. This value defaults to 3, but can range from 1 to 16.</returns>
    public uint MaximumFrameLatency
    {
        get
        {
            uint value;
            int hr = _comImpl->GetMaximumFrameLatency(_comPtr, &value);
            Marshal.ThrowExceptionForHR(hr);
            return value;
        }

        set
        {
            int hr = _comImpl->SetMaximumFrameLatency(_comPtr, value);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Returns the adapter for the specified device.
    /// </summary>
    /// <returns>The adapter for the specified device.</returns>
    public DxgiAdapter1 GetAdapter()
    {
        nint ptr;
        int hr = _comImpl->GetAdapter(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiAdapter1(DXUtils.QueryInterface(ptr, DxgiAdapter1.DxgiAdapter1Guid));
        }
        finally
        {
            DXUtils.Release(ptr);
        }
    }

    /// <summary>
    /// Gets the residency status of an array of resources.
    /// </summary>
    /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
    /// <returns>An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</returns>
    public DxgiResidency[] QueryResourceResidency(DxgiResource1?[]? resources)
    {
        if (resources is null)
        {
            throw new ArgumentNullException(nameof(resources));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource1? resource = resources[i];
            resourcesPtr[i] = resource is null ? 0 : resource.Handle;
        }

        DxgiResidency* residenciesPtr = stackalloc DxgiResidency[count];
        int hr = _comImpl->QueryResourceResidency(_comPtr, resourcesPtr, residenciesPtr, (uint)count);
        Marshal.ThrowExceptionForHR(hr);

        var residencies = new DxgiResidency[count];
        new ReadOnlySpan<DxgiResidency>(residenciesPtr, count)
            .CopyTo(residencies);

        return residencies;
    }

    /// <summary>
    /// Gets the residency status of an array of resources.
    /// </summary>
    /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
    /// <param name="residencies">An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</param>
    public void QueryResourceResidency(ReadOnlySpan<DxgiResource1> resources, Span<DxgiResidency> residencies)
    {
        if (resources.Length != residencies.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(residencies));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource1? resource = resources[i];
            resourcesPtr[i] = resource is null ? 0 : resource.Handle;
        }

        fixed (void* residenciesPtr = residencies)
        {
            int hr = _comImpl->QueryResourceResidency(_comPtr, resourcesPtr, residenciesPtr, (uint)count);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Gets the residency status of a resource.
    /// </summary>
    /// <param name="resource">An <c>IDXGIResource</c> interfaces.</param>
    /// <returns>A <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</returns>
    public DxgiResidency QueryResourceResidency(DxgiResource1 resource)
    {
        nint ptr = resource.Handle;
        DxgiResidency residency;
        int hr = _comImpl->QueryResourceResidency(_comPtr, &ptr, &residency, 1);
        Marshal.ThrowExceptionForHR(hr);
        return residency;
    }
}
