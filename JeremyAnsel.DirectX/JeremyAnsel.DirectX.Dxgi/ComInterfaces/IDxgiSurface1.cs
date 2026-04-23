// <copyright file="IDxgiSurface1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// The <c>IDXGISurface1</c> interface extends the <c>IDXGISurface</c> by adding support for using Windows Graphics Device Interface (GDI) to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiSurface"/></remarks>
[Guid("4AE63092-6327-4c1b-80AE-BFE12EA32B86")]
internal unsafe readonly struct IDxgiSurface1
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

    /// <summary>
    /// Returns a device context (DC) that allows you to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface using Windows Graphics Device Interface (GDI).
    /// </summary>
    /// <param name="discard">A value indicating whether to preserve Direct3D contents in the GDI DC.</param>
    /// <returns>An HDC handle that represents the current device context for GDI rendering.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int, nint*, int> GetDC;

    /// <summary>
    /// Releases the GDI device context (DC) that is associated with the current surface and allows you to use Direct3D to render.
    /// </summary>
    /// <param name="dirtyRect">A RECT structure that identifies the dirty region of the surface. A dirty region is any part of the surface that you used for GDI rendering and that you want to preserve. This area is used as a performance hint to graphics subsystem in certain scenarios. Do not use this parameter to restrict rendering to the specified rectangular region.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> ReleaseDC;
}
