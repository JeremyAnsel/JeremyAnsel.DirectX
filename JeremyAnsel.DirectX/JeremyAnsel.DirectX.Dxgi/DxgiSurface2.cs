// <copyright file="DxgiSurface2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// The <c>IDXGISurface2</c> interface extends the <c>IDXGISurface1</c> interface by adding support for sub-resource surfaces and getting a handle to a shared resource.
    /// </summary>
    public sealed class DxgiSurface2 : DxgiDeviceSubObject
    {
        /// <summary>
        /// The interface GUID.
        /// </summary>
        public static readonly Guid InterfaceGuid = typeof(IDxgiSurface2).GUID;

        /// <summary>
        /// The DXGI surface interface.
        /// </summary>
        private readonly IDxgiSurface2 surface;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSurface2"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>IDXGISurface2</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurface2(object resource)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(resource);

            try
            {
                this.surface = (IDxgiSurface2)Marshal.GetObjectForIUnknown(ptr);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSurface2"/> class.
        /// </summary>
        /// <param name="surface">A resource interface which implements the <c>IDXGISurface2</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiSurface2(IDxgiSurface2 surface)
        {
            this.surface = surface;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.surface; }
        }

        /// <summary>
        /// Gets a description of the surface.
        /// </summary>
        public DxgiSurfaceDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.surface.GetDesc();
            }
        }

        /// <summary>
        /// Get a pointer to the data contained in the surface, and deny GPU access to the surface.
        /// </summary>
        /// <param name="options">CPU read-write flags. These flags can be combined with a logical OR.</param>
        /// <returns>The surface data.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiMappedRect Map(DxgiMapOptions options)
        {
            DxgiMappedRect lockedRec;
            this.surface.Map(out lockedRec, options);
            return lockedRec;
        }

        /// <summary>
        /// Invalidate the pointer to the surface retrieved by <c>IDXGISurface::Map</c> and re-enable GPU access to the resource.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Unmap()
        {
            this.surface.Unmap();
        }

        /// <summary>
        /// Returns a device context (DC) that allows you to render to a Microsoft DirectX Graphics Infrastructure (DXGI) surface using Windows Graphics Device Interface (GDI).
        /// </summary>
        /// <param name="discard">A value indicating whether to preserve Direct3D contents in the GDI DC.</param>
        /// <returns>An HDC handle that represents the current device context for GDI rendering.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IntPtr GetDC(bool discard)
        {
            return this.surface.GetDC(discard);
        }

        /// <summary>
        /// Releases the GDI device context (DC) that is associated with the current surface and allows you to use Direct3D to render.
        /// </summary>
        /// <param name="dirtyRect">A RECT structure that identifies the dirty region of the surface. A dirty region is any part of the surface that you used for GDI rendering and that you want to preserve. This area is used as a performance hint to graphics subsystem in certain scenarios. Do not use this parameter to restrict rendering to the specified rectangular region.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseDC(DxgiRect dirtyRect)
        {
            this.surface.ReleaseDC(ref dirtyRect);
        }
    }
}
