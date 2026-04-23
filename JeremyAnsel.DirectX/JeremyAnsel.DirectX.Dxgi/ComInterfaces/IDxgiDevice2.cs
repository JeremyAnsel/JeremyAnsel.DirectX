// <copyright file="IDxgiDevice2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGIDevice2</c> interface implements a derived class for DXGI objects that produce image data. The interface exposes methods to block CPU processing until the GPU completes processing, and to offer resources to the operating system.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiDevice1"/></remarks>
[Guid("05008617-fbfd-4051-a790-144884b4f6a9")]
internal unsafe readonly struct IDxgiDevice2
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;

    /// <summary>
    /// Returns the adapter for the specified device.
    /// </summary>
    /// <returns>The adapter for the specified device.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetAdapter;

    /// <summary>
    /// Returns a surface. This method is used internally and you should not call it directly in your application.
    /// </summary>
    /// <param name="desc">A <c>DXGI_SURFACE_DESC</c> structure that describes the surface.</param>
    /// <param name="numSurfaces">The number of surfaces to create.</param>
    /// <param name="usage">A <c>DXGI_USAGE</c> flag that specifies how the surface is expected to be used.</param>
    /// <param name="sharedResource">An optional <c>DXGI_SHARED_RESOURCE</c> structure that contains shared resource information for opening views of such resources.</param>
    /// <param name="surface">The address of an <c>IDXGISurface</c> interface pointer to the first created surface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, DxgiUsages, void*, void*, int> CreateSurface;

    /// <summary>
    /// Gets the residency status of an array of resources.
    /// </summary>
    /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
    /// <param name="residencyStatus">An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</param>
    /// <param name="numResources">The number of resources in the argument arrays.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, uint, int> QueryResourceResidency;

    /// <summary>
    /// Sets the GPU thread priority.
    /// </summary>
    /// <param name="priority">A value that specifies the required GPU thread priority. This value must be between -7 and 7, inclusive, where 0 represents normal priority.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, int, int> SetGpuThreadPriority;

    /// <summary>
    /// Gets the GPU thread priority.
    /// </summary>
    /// <returns>A value that indicates the current GPU thread priority. The value will be between -7 and 7, inclusive, where 0 represents normal priority.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int*, int> GetGpuThreadPriority;

    /// <summary>
    /// Sets the number of frames that the system is allowed to queue for rendering.
    /// </summary>
    /// <param name="maxLatency">The maximum number of back buffer frames that a driver can queue. The value defaults to 3, but can range from 1 to 16. A value of 0 will reset latency to the default. For multi-head devices, this value is specified per-head.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, int> SetMaximumFrameLatency;

    /// <summary>
    /// Gets the number of frames that the system is allowed to queue for rendering.
    /// </summary>
    /// <returns>The number of frames that can be queued for render. This value defaults to 3, but can range from 1 to 16.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetMaximumFrameLatency;

    /// <summary>
    /// Allows the operating system to free the video memory of resources by discarding their content.
    /// </summary>
    /// <param name="numResources">The number of resources in the <c>resources</c> argument array.</param>
    /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to offer.</param>
    /// <param name="priority">A <c>DXGI_OFFER_RESOURCE_PRIORITY</c>-typed value that indicates how valuable data is.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, DxgiOfferResourcePriority, int> OfferResources;

    /// <summary>
    /// Restores access to resources that were previously offered by calling <c>IDXGIDevice2::OfferResources</c>.
    /// </summary>
    /// <param name="numResources">The number of resources in the <c>resources</c> argument and <c>discarded</c> argument arrays.</param>
    /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to reclaim.</param>
    /// <param name="discarded">A pointer to an array that receives Boolean values. Each value in the array corresponds to a resource at the same index that the ppResources parameter specifies. The runtime sets each Boolean value to <value>TRUE</value> if the corresponding resource’s content was discarded and is now undefined, or to <value>FALSE</value> if the corresponding resource’s old content is still intact. The caller can pass in <value>NULL</value>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void*, void*, int> ReclaimResources;

    /// <summary>
    /// Flushes any outstanding rendering commands and sets the specified event object to the signaled state after all previously submitted rendering commands complete.
    /// </summary>
    /// <param name="eventHandle">A handle to the event object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> EnqueueSetEvent;
}
