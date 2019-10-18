// <copyright file="DxgiDevice1.cs" company="Jérémy Ansel">
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
    /// An <c>IDXGIDevice1</c> interface implements a derived class for DXGI objects that produce image data.
    /// </summary>
    public sealed class DxgiDevice1 : DxgiObject
    {
        /// <summary>
        /// The DXGI device interface.
        /// </summary>
        private readonly IDxgiDevice1 device;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiDevice1"/> class.
        /// </summary>
        /// <param name="device">A device interface which implements the <c>IDxgiDevice1</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiDevice1(object device)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(device);

            try
            {
                this.device = (IDxgiDevice1)Marshal.GetObjectForIUnknown(ptr);
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
        public DxgiAdapter1 GetAdapter()
        {
            return new DxgiAdapter1((IDxgiAdapter1)this.device.GetAdapter());
        }

        /// <summary>
        /// Gets the residency status of an array of resources.
        /// </summary>
        /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
        /// <returns>An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiResidency[] QueryResourceResidency(DxgiResource1[] resources)
        {
            if (resources == null)
            {
                throw new ArgumentNullException(nameof(resources));
            }

            DxgiResidency[] residencies = new DxgiResidency[resources.Length];

            this.device.QueryResourceResidency(
                Array.ConvertAll(resources, t => t.GetHandle<IDxgiResource>()),
                residencies,
                (uint)resources.Length);

            return residencies;
        }
    }
}
