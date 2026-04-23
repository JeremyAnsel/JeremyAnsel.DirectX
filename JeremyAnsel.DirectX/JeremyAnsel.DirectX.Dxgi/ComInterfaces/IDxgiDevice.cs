// <copyright file="IDxgiDevice.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// An <c>IDXGIDevice</c> interface implements a derived class for DXGI objects that produce image data.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiObject"/></remarks>
[Guid("54ec77fa-1377-44e6-8c32-88fd5f44c84c")]
internal unsafe readonly struct IDxgiDevice
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
}
