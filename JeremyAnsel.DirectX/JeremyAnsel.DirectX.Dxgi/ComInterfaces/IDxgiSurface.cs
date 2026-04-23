// <copyright file="IDxgiSurface.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGISurface</c> interface implements methods for image-data objects.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
[Guid("cafcb56c-6ac3-4889-bf47-9e23bbd260ec")]
internal unsafe readonly struct IDxgiSurface
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;
    private readonly nint GetDevice;

    /// <summary>
    /// Get a description of the surface.
    /// </summary>
    /// <returns>The surface description.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc;

    /// <summary>
    /// Get a pointer to the data contained in the surface, and deny GPU access to the surface.
    /// </summary>
    /// <param name="lockedRect">The surface data.</param>
    /// <param name="options">CPU read-write flags. These flags can be combined with a logical OR.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, DxgiMapOptions, int> Map;

    /// <summary>
    /// Invalidate the pointer to the surface retrieved by <c>IDXGISurface::Map</c> and re-enable GPU access to the resource.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, int> Unmap;
}
