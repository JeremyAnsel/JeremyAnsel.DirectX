// <copyright file="DxgiDevice3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// The <c>IDXGIDevice3</c> interface implements a derived class for DXGI objects that produce image data. The interface exposes a method to trim graphics memory usage by the DXGI device.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiDevice3 : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiDevice3Guid = typeof(IDxgiDevice3).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiDevice3* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice3"/> class.
    /// </summary>
    public DxgiDevice3(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiDevice3**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice3"/> class.
    /// </summary>
    /// <param name="device">A device interface which implements the <c>IDxgiDevice3</c> interface.</param>
    public static DxgiDevice3 CreateDeviceFromDevice(DXComObject device)
    {
        return CreateDeviceFromDevice(device.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDevice3"/> class.
    /// </summary>
    /// <param name="device">A device interface which implements the <c>IDxgiDevice3</c> interface.</param>
    public static DxgiDevice3 CreateDeviceFromDevice(nint device)
    {
        if (device == 0)
        {
            throw new ArgumentNullException(nameof(device));
        }

        nint ptr = DXUtils.QueryInterface(device, DxgiDevice3Guid);
        return new DxgiDevice3(ptr);
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
    public DxgiAdapter3 GetAdapter()
    {
        nint ptr;
        int hr = _comImpl->GetAdapter(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);

        try
        {
            return new DxgiAdapter3(DXUtils.QueryInterface(ptr, DxgiAdapter3.DxgiAdapter3Guid));
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
    public DxgiResidency[] QueryResourceResidency(DxgiResource3?[]? resources)
    {
        if (resources is null)
        {
            throw new ArgumentNullException(nameof(resources));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource3? resource = resources[i];
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
    public void QueryResourceResidency(ReadOnlySpan<DxgiResource3> resources, Span<DxgiResidency> residencies)
    {
        if (resources.Length != residencies.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(residencies));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource3? resource = resources[i];
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
    public DxgiResidency QueryResourceResidency(DxgiResource3 resource)
    {
        nint ptr = resource.Handle;
        DxgiResidency residency;
        int hr = _comImpl->QueryResourceResidency(_comPtr, &ptr, &residency, 1);
        Marshal.ThrowExceptionForHR(hr);
        return residency;
    }

    /// <summary>
    /// Allows the operating system to free the video memory of resources by discarding their content.
    /// </summary>
    /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to offer.</param>
    /// <param name="priority">A <c>DXGI_OFFER_RESOURCE_PRIORITY</c>-typed value that indicates how valuable data is.</param>
    public void OfferResources(DxgiResource3?[]? resources, DxgiOfferResourcePriority priority)
    {
        if (resources == null)
        {
            throw new ArgumentNullException(nameof(resources));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource3? resource = resources[i];
            resourcesPtr[i] = resource is null ? 0 : resource.Handle;
        }

        int hr = _comImpl->OfferResources(_comPtr, (uint)count, resourcesPtr, priority);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Allows the operating system to free the video memory of resources by discarding their content.
    /// </summary>
    /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to offer.</param>
    /// <param name="priority">A <c>DXGI_OFFER_RESOURCE_PRIORITY</c>-typed value that indicates how valuable data is.</param>
    public void OfferResources(ReadOnlySpan<DxgiResource3> resources, DxgiOfferResourcePriority priority)
    {
        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource3? resource = resources[i];
            resourcesPtr[i] = resource is null ? 0 : resource.Handle;
        }

        int hr = _comImpl->OfferResources(_comPtr, (uint)count, resourcesPtr, priority);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Allows the operating system to free the video memory of resources by discarding their content.
    /// </summary>
    /// <param name="resource">A <c>IDXGIResource</c> interface for the resource to offer.</param>
    /// <param name="priority">A <c>DXGI_OFFER_RESOURCE_PRIORITY</c>-typed value that indicates how valuable data is.</param>
    public void OfferResources(DxgiResource3 resource, DxgiOfferResourcePriority priority)
    {
        nint ptr = resource.Handle;
        int hr = _comImpl->OfferResources(_comPtr, 1, &ptr, priority);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Restores access to resources that were previously offered by calling <c>IDXGIDevice3::OfferResources</c>.
    /// </summary>
    /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to reclaim.</param>
    /// <returns>A pointer to an array that receives Boolean values. Each value in the array corresponds to a resource at the same index that the ppResources parameter specifies. The runtime sets each Boolean value to <value>TRUE</value> if the corresponding resource’s content was discarded and is now undefined, or to <value>FALSE</value> if the corresponding resource’s old content is still intact. The caller can pass in <value>NULL</value>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.</returns>
    public bool[] ReclaimResources(DxgiResource3?[]? resources)
    {
        if (resources is null)
        {
            throw new ArgumentNullException(nameof(resources));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource3? resource = resources[i];
            resourcesPtr[i] = resource is null ? 0 : resource.Handle;
        }

        int* discardedPtr = stackalloc int[count];
        int hr = _comImpl->ReclaimResources(_comPtr, (uint)count, resourcesPtr, discardedPtr);
        Marshal.ThrowExceptionForHR(hr);

        var discarded = new bool[count];
        for (int i = 0; i < count; i++)
        {
            discarded[i] = discardedPtr[i] != 0;
        }

        return discarded;
    }

    /// <summary>
    /// Restores access to resources that were previously offered by calling <c>IDXGIDevice3::OfferResources</c>.
    /// </summary>
    /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to reclaim.</param>
    /// <param name="discarded">A pointer to an array that receives Boolean values. Each value in the array corresponds to a resource at the same index that the ppResources parameter specifies. The runtime sets each Boolean value to <value>TRUE</value> if the corresponding resource’s content was discarded and is now undefined, or to <value>FALSE</value> if the corresponding resource’s old content is still intact. The caller can pass in <value>NULL</value>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.</param>
    public void ReclaimResources(ReadOnlySpan<DxgiResource3> resources, Span<bool> discarded)
    {
        if (resources.Length != discarded.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(discarded));
        }

        int count = resources.Length;
        nint* resourcesPtr = stackalloc nint[count];
        for (int i = 0; i < count; i++)
        {
            DxgiResource3? resource = resources[i];
            resourcesPtr[i] = resource is null ? 0 : resource.Handle;
        }

        int* discardedPtr = stackalloc int[count];
        int hr = _comImpl->ReclaimResources(_comPtr, (uint)count, resourcesPtr, discardedPtr);
        Marshal.ThrowExceptionForHR(hr);

        for (int i = 0; i < count; i++)
        {
            discarded[i] = discardedPtr[i] != 0;
        }
    }

    /// <summary>
    /// Restores access to resources that were previously offered by calling <c>IDXGIDevice3::OfferResources</c>.
    /// </summary>
    /// <param name="resource">An <c>IDXGIResource</c> interface for the resources to reclaim.</param>
    /// <returns>A pointer to an array that receives Boolean values. Each value in the array corresponds to a resource at the same index that the ppResources parameter specifies. The runtime sets each Boolean value to <value>TRUE</value> if the corresponding resource’s content was discarded and is now undefined, or to <value>FALSE</value> if the corresponding resource’s old content is still intact. The caller can pass in <value>NULL</value>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.</returns>
    public bool ReclaimResources(DxgiResource3 resource)
    {
        nint ptr = resource.Handle;
        int discarded;
        int hr = _comImpl->ReclaimResources(_comPtr, 1, &ptr, &discarded);
        Marshal.ThrowExceptionForHR(hr);
        return discarded != 0;
    }

    /// <summary>
    /// Trims the graphics memory allocated by the <c>IDXGIDevice3</c> DXGI device on the app's behalf.
    /// </summary>
    public void Trim()
    {
        _comImpl->Trim(_comPtr);
    }
}
