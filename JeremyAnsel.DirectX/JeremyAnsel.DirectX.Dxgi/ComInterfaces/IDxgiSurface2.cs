// <copyright file="IDxgiSurface2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The <c>IDXGISurface2</c> interface extends the <c>IDXGISurface1</c> interface by adding support for sub-resource surfaces and getting a handle to a shared resource.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiSurface1"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("aba496dd-b617-4cb8-a866-bc44d7eb1fa2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiSurface2
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
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Set an interface in the object's private data.
        /// </summary>
        /// <param name="name">A GUID identifying the interface.</param>
        /// <param name="unknown">The interface to set.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object unknown);

        /// <summary>
        /// Get a pointer to the object's data.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">Pointer to the data.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <param name="riid">The ID of the requested interface.</param>
        /// <returns>The address of a pointer to the parent object.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetParent(
            [In] ref Guid riid);

        /// <summary>
        /// Retrieves the device.
        /// </summary>
        /// <param name="riid">The reference id for the device.</param>
        /// <returns>The address of a pointer to the device.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetDevice(
            [In] ref Guid riid);

        /// <summary>
        /// Get a description of the surface.
        /// </summary>
        /// <returns>The surface description.</returns>
        DxgiSurfaceDesc GetDesc();

        /// <summary>
        /// Get a pointer to the data contained in the surface, and deny GPU access to the surface.
        /// </summary>
        /// <param name="lockedRect">The surface data.</param>
        /// <param name="options">CPU read-write flags. These flags can be combined with a logical OR.</param>
        void Map(
            [Out] out DxgiMappedRect lockedRect,
            [In] DxgiMapOptions options);

        /// <summary>
        /// Invalidate the pointer to the surface retrieved by <c>IDXGISurface::Map</c> and re-enable GPU access to the resource.
        /// </summary>
        void Unmap();

        /// <summary>
        /// Returns a device context (DC) that allows you to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface using Windows Graphics Device Interface (GDI).
        /// </summary>
        /// <param name="discard">A value indicating whether to preserve Direct3D contents in the GDI DC.</param>
        /// <returns>An HDC handle that represents the current device context for GDI rendering.</returns>
        IntPtr GetDC(
            [In, MarshalAs(UnmanagedType.Bool)] bool discard);

        /// <summary>
        /// Releases the GDI device context (DC) that is associated with the current surface and allows you to use Direct3D to render.
        /// </summary>
        /// <param name="dirtyRect">A RECT structure that identifies the dirty region of the surface. A dirty region is any part of the surface that you used for GDI rendering and that you want to preserve. This area is used as a performance hint to graphics subsystem in certain scenarios. Do not use this parameter to restrict rendering to the specified rectangular region.</param>
        void ReleaseDC(
            [In] ref DxgiRect dirtyRect);

        /// <summary>
        /// Gets the parent resource and sub-resource index that support a sub-resource surface.
        /// </summary>
        /// <param name="riid">The globally unique identifier (GUID) of the requested interface type.</param>
        /// <param name="parentResource">A pointer to the parent resource object for the sub-resource surface.</param>
        /// <param name="subresourceIndex">A variable that receives the index of the sub-resource surface.</param>
        void GetResource(
            [In] ref Guid riid,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object parentResource,
            [Out] out uint subresourceIndex);
    }
}
