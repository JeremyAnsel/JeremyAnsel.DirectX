// <copyright file="DxgiFactory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// An <c>IDXGIFactory</c> interface implements methods for generating DXGI objects (which handle full screen transitions).
    /// </summary>
    public sealed class DxgiFactory : DxgiObject
    {
        /// <summary>
        /// The DXGI factory interface.
        /// </summary>
        private IDxgiFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiFactory"/> class.
        /// </summary>
        /// <param name="factory">A DXGI factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiFactory(IDxgiFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.factory; }
        }

        /// <summary>
        /// Gets the window through which the user controls the transition to and from full screen.
        /// </summary>
        public IntPtr WindowAssociation
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.factory.GetWindowAssociation();
            }
        }

        /// <summary>
        /// Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <returns>A <see cref="DxgiFactory"/> object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DxgiFactory Create()
        {
            IDxgiFactory factory;
            NativeMethods.CreateDxgiFactory(typeof(IDxgiFactory).GUID, out factory);
            return new DxgiFactory(factory);
        }

        /// <summary>
        /// Enumerates the adapters (video cards).
        /// </summary>
        /// <returns>An IEnumerable of <see cref="DxgiAdapter"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<DxgiAdapter> EnumAdapters()
        {
            IDxgiAdapter adapter;

            for (uint i = 0; !this.factory.EnumAdapters(i, out adapter); i++)
            {
                yield return new DxgiAdapter(adapter);
            }
        }

        /// <summary>
        /// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch from windowed to full screen or vice versa).
        /// </summary>
        /// <param name="windowHandle">The handle of the window that is to be monitored. This parameter can be <value>Zero</value>; but only if the flags are also 0.</param>
        /// <param name="options">One or more options.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MakeWindowAssociation(IntPtr windowHandle, DxgiWindowAssociationOptions options)
        {
            this.factory.MakeWindowAssociation(windowHandle, options);
        }

        /// <summary>
        /// Creates a swap chain.
        /// </summary>
        /// <param name="device">A Direct3D device that will write 2D images to the swap chain.</param>
        /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC</c> structure for the swap-chain description.</param>
        /// <returns>An <c>IDXGISwapChain</c> interface for the swap chain</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSwapChain CreateSwapChain(object device, DxgiSwapChainDesc desc)
        {
            return new DxgiSwapChain(this.factory.CreateSwapChain(device, ref desc));
        }
    }
}
