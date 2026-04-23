// <copyright file="DxgiDevice.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// An <c>IDXGIDevice</c> interface implements a derived class for DXGI objects that produce image data.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiDevice : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiDeviceGuid = typeof(IDxgiDevice).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiDevice* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice"/> class.
    /// </summary>
    public DxgiDevice(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiDevice**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice"/> class.
    /// </summary>
    /// <param name="device">A device interface which implements the <c>IDxgiDevice</c> interface.</param>
    public static DxgiDevice CreateDeviceFromDevice(DXComObject device)
    {
        return CreateDeviceFromDevice(device.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice"/> class.
    /// </summary>
    /// <param name="device">A device interface which implements the <c>IDxgiDevice</c> interface.</param>
    public static DxgiDevice CreateDeviceFromDevice(nint device)
    {
        if (device == 0)
        {
            throw new ArgumentNullException(nameof(device));
        }

        nint ptr = DXUtils.QueryInterface(device, DxgiDeviceGuid);
        return new DxgiDevice(ptr);
    }

    /// <summary>
    /// Returns the adapter for the specified device.
    /// </summary>
    /// <returns>The adapter for the specified device.</returns>
    public DxgiAdapter GetAdapter()
    {
        nint ptr;
        int hr = _comImpl->GetAdapter(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new DxgiAdapter(ptr);
    }

    /// <summary>
    /// Gets the residency status of an array of resources.
    /// </summary>
    /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
    /// <returns>An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</returns>
    public DxgiResidency[] QueryResourceResidency(DxgiResource?[]? resources)
    {
        if (resources is null)
        {
            throw new ArgumentNullException(nameof(resources));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource? resource = resources[i];
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
    public void QueryResourceResidency(ReadOnlySpan<DxgiResource> resources, Span<DxgiResidency> residencies)
    {
        if (resources.Length != residencies.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(residencies));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource? resource = resources[i];
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
    public DxgiResidency QueryResourceResidency(DxgiResource resource)
    {
        nint ptr = resource.Handle;
        DxgiResidency residency;
        int hr = _comImpl->QueryResourceResidency(_comPtr, &ptr, &residency, 1);
        Marshal.ThrowExceptionForHR(hr);
        return residency;
    }
}
