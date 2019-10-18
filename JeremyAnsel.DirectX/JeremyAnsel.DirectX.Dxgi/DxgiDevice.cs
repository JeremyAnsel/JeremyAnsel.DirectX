// <copyright file="DxgiDevice.cs" company="Jérémy Ansel">
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
    /// An <c>IDXGIDevice</c> interface implements a derived class for DXGI objects that produce image data.
    /// </summary>
    public sealed class DxgiDevice : DxgiObject
    {
        /// <summary>
        /// The DXGI device interface.
        /// </summary>
        private readonly IDxgiDevice device;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiDevice"/> class.
        /// </summary>
        /// <param name="device">A device interface which implements the <c>IDxgiDevice</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiDevice(object device)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(device);

            try
            {
                this.device = (IDxgiDevice)Marshal.GetObjectForIUnknown(ptr);
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
        /// Returns the adapter for the specified device.
        /// </summary>
        /// <returns>The adapter for the specified device.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiAdapter GetAdapter()
        {
            return new DxgiAdapter(this.device.GetAdapter());
        }

        /// <summary>
        /// Gets the residency status of an array of resources.
        /// </summary>
        /// <param name="resources">An array of <c>IDXGIResource</c> interfaces.</param>
        /// <returns>An array of <c>DXGI_RESIDENCY</c> flags. Each element describes the residency status for corresponding element in the <c>resources</c> argument array.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiResidency[] QueryResourceResidency(DxgiResource[] resources)
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
