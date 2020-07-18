// <copyright file="DxgiDevice2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// The <c>IDXGIDevice2</c> interface implements a derived class for DXGI objects that produce image data. The interface exposes methods to block CPU processing until the GPU completes processing, and to offer resources to the operating system.
    /// </summary>
    public sealed class DxgiDevice2 : DxgiObject
    {
        /// <summary>
        /// The DXGI device interface.
        /// </summary>
        private readonly IDxgiDevice2 device;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiDevice2"/> class.
        /// </summary>
        /// <param name="device">A device interface which implements the <c>IDxgiDevice2</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiDevice2(object device)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(device);

            try
            {
                this.device = (IDxgiDevice2)Marshal.GetObjectForIUnknown(ptr);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.device; }
        }

        /// <summary>
        /// Gets or sets the number of frames that the system is allowed to queue for rendering.
        /// </summary>
        /// <returns>The number of frames that can be queued for render. This value defaults to 3, but can range from 1 to 16.</returns>
        public uint MaximumFrameLatency
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.device.GetMaximumFrameLatency();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.device.SetMaximumFrameLatency(value);
            }
        }

        /// <summary>
        /// Returns the adapter for the specified device.
        /// </summary>
        /// <returns>The adapter for the specified device.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiAdapter2 GetAdapter()
        {
            IDxgiAdapter adapter = this.device.GetAdapter();

            if (adapter == null)
            {
                return null;
            }

            return new DxgiAdapter2((IDxgiAdapter2)adapter);
        }

        /// <summary>
        /// Gets the residency status of an array of resources.
        /// </summary>
        /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
        /// <returns>An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiResidency[] QueryResourceResidency(DxgiResource2[] resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            DxgiResidency[] residencies = new DxgiResidency[resources.Length];

            this.device.QueryResourceResidency(
                Array.ConvertAll(resources, t => t?.GetHandle<IDxgiResource>()),
                residencies,
                (uint)resources.Length);

            return residencies;
        }

        /// <summary>
        /// Allows the operating system to free the video memory of resources by discarding their content.
        /// </summary>
        /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to offer.</param>
        /// <param name="priority">A <c>DXGI_OFFER_RESOURCE_PRIORITY</c>-typed value that indicates how valuable data is.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OfferResources(DxgiResource2[] resources, DxgiOfferResourcePriority priority)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            this.device.OfferResources(
                (uint)resources.Length,
                Array.ConvertAll(resources, t => t?.GetHandle<IDxgiResource>()),
                priority);
        }

        /// <summary>
        /// Restores access to resources that were previously offered by calling <c>IDXGIDevice2::OfferResources</c>.
        /// </summary>
        /// <param name="resources">An array of pointers to <c>IDXGIResource</c> interfaces for the resources to reclaim.</param>
        /// <returns>A pointer to an array that receives Boolean values. Each value in the array corresponds to a resource at the same index that the ppResources parameter specifies. The runtime sets each Boolean value to <value>TRUE</value> if the corresponding resource’s content was discarded and is now undefined, or to <value>FALSE</value> if the corresponding resource’s old content is still intact. The caller can pass in <value>NULL</value>, if the caller intends to fill the resources with new content regardless of whether the old content was discarded.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool[] ReclaimResources(DxgiResource2[] resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            bool[] discarded = new bool[resources.Length];

            this.device.ReclaimResources(
                (uint)resources.Length,
                Array.ConvertAll(resources, t => t?.GetHandle<IDxgiResource>()),
                discarded);

            return discarded;
        }
    }
}
