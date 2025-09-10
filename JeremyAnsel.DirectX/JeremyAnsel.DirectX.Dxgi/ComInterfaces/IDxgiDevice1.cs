// <copyright file="IDxgiDevice1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// An <c>IDXGIDevice1</c> interface implements a derived class for DXGI objects that produce image data.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiDevice"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("77db970f-6276-48ba-ba28-070143b4392c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiDevice1
    {
        /// <summary>
        /// Sets application-defined data to the object and associates that data with a GUID.
        /// </summary>
        /// <param name="name">A GUID that identifies the data.</param>
        /// <param name="dataSize">The size of the object's data.</param>
        /// <param name="data">A pointer to the object's data.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Set an interface in the object's private data.
        /// </summary>
        /// <param name="name">A GUID identifying the interface.</param>
        /// <param name="unknown">The interface to set.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object? unknown);

        /// <summary>
        /// Get a pointer to the object's data.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">Pointer to the data.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <param name="riid">The ID of the requested interface.</param>
        /// <returns>The address of a pointer to the parent object.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object? GetParent(
            [In] ref Guid riid);

        /// <summary>
        /// Returns the adapter for the specified device.
        /// </summary>
        /// <returns>The adapter for the specified device.</returns>
        IDxgiAdapter? GetAdapter();

        /// <summary>
        /// Returns a surface. This method is used internally and you should not call it directly in your application.
        /// </summary>
        /// <param name="desc">A <c>DXGI_SURFACE_DESC</c> structure that describes the surface.</param>
        /// <param name="numSurfaces">The number of surfaces to create.</param>
        /// <param name="usage">A <c>DXGI_USAGE</c> flag that specifies how the surface is expected to be used.</param>
        /// <param name="sharedResource">An optional <c>DXGI_SHARED_RESOURCE</c> structure that contains shared resource information for opening views of such resources.</param>
        /// <param name="surface">The address of an <c>IDXGISurface</c> interface pointer to the first created surface.</param>
        void CreateSurface(
            [In] ref DxgiSurfaceDesc desc,
            [In] uint numSurfaces,
            [In] DxgiUsages usage,
            [In] ref DxgiSharedResource sharedResource,
            [Out, MarshalAs(UnmanagedType.LPArray)] IDxgiSurface[]? surface);

        /// <summary>
        /// Gets the residency status of an array of resources.
        /// </summary>
        /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
        /// <param name="residencyStatus">An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</param>
        /// <param name="numResources">The number of resources in the argument arrays.</param>
        void QueryResourceResidency(
            [In, MarshalAs(UnmanagedType.LPArray)] IDxgiResource?[]? resources,
            [Out, MarshalAs(UnmanagedType.LPArray)] DxgiResidency?[]? residencyStatus,
            [In] uint numResources);

        /// <summary>
        /// Sets the GPU thread priority.
        /// </summary>
        /// <param name="priority">A value that specifies the required GPU thread priority. This value must be between -7 and 7, inclusive, where 0 represents normal priority.</param>
        void SetGpuThreadPriority(
            [In] int priority);

        /// <summary>
        /// Gets the GPU thread priority.
        /// </summary>
        /// <returns>A value that indicates the current GPU thread priority. The value will be between -7 and 7, inclusive, where 0 represents normal priority.</returns>
        int GetGpuThreadPriority();

        /// <summary>
        /// Sets the number of frames that the system is allowed to queue for rendering.
        /// </summary>
        /// <param name="maxLatency">The maximum number of back buffer frames that a driver can queue. The value defaults to 3, but can range from 1 to 16. A value of 0 will reset latency to the default. For multi-head devices, this value is specified per-head.</param>
        void SetMaximumFrameLatency(
            [In] uint maxLatency);

        /// <summary>
        /// Gets the number of frames that the system is allowed to queue for rendering.
        /// </summary>
        /// <returns>The number of frames that can be queued for render. This value defaults to 3, but can range from 1 to 16.</returns>
        uint GetMaximumFrameLatency();
    }
}
