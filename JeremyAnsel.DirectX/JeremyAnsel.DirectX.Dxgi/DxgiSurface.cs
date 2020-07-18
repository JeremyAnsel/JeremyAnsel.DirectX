// <copyright file="DxgiSurface.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// The <c>IDXGISurface</c> interface implements methods for image-data objects.
    /// </summary>
    public sealed class DxgiSurface : DxgiDeviceSubObject
    {
        /// <summary>
        /// The interface GUID.
        /// </summary>
        public static readonly Guid InterfaceGuid = typeof(IDxgiSurface).GUID;

        /// <summary>
        /// The DXGI surface interface.
        /// </summary>
        private readonly IDxgiSurface surface;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSurface"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>IDXGISurface</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurface(object resource)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(resource);

            try
            {
                this.surface = (IDxgiSurface)Marshal.GetObjectForIUnknown(ptr);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSurface"/> class.
        /// </summary>
        /// <param name="surface">A resource interface which implements the <c>IDXGISurface</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiSurface(IDxgiSurface surface)
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
            this.surface.Map(out DxgiMappedRect lockedRect, options);
            return lockedRect;
        }

        /// <summary>
        /// Invalidate the pointer to the surface retrieved by <c>IDXGISurface::Map</c> and re-enable GPU access to the resource.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Unmap()
        {
            this.surface.Unmap();
        }
    }
}
