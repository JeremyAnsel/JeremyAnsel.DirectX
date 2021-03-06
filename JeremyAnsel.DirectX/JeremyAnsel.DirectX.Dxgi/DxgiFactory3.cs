﻿// <copyright file="DxgiFactory3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// Enables creating Microsoft DirectX Graphics Infrastructure (DXGI) objects.
    /// </summary>
    public sealed class DxgiFactory3 : DxgiObject
    {
        /// <summary>
        /// The DXGI factory interface.
        /// </summary>
        private readonly IDxgiFactory3 factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiFactory3"/> class.
        /// </summary>
        /// <param name="factory">A DXGI factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiFactory3(IDxgiFactory3 factory)
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
        /// Gets a value indicating whether the adapter has not changed.
        /// </summary>
        public bool IsCurrent
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.factory.IsCurrent();
            }
        }

        /// <summary>
        /// Gets a value indicating whether to use stereo mode.
        /// </summary>
        public bool IsWindowedStereoEnabled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.factory.IsWindowedStereoEnabled();
            }
        }

        /// <summary>
        /// Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.
        /// </summary>
        public DxgiCreateFactoryOptions CreationOptions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.factory.GetCreationOptions();
            }
        }

        /// <summary>
        /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <returns>A <see cref="DxgiFactory3"/> object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DxgiFactory3 Create()
        {
            NativeMethods.CreateDxgiFactory2(DxgiCreateFactoryOptions.None, typeof(IDxgiFactory3).GUID, out IDxgiFactory2 factory);

            if (factory == null)
            {
                return null;
            }

            return new DxgiFactory3((IDxgiFactory3)factory);
        }

        /// <summary>
        /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <param name="options">The creation options.</param>
        /// <returns>A <see cref="DxgiFactory3"/> object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DxgiFactory3 Create(DxgiCreateFactoryOptions options)
        {
            NativeMethods.CreateDxgiFactory2(options, typeof(IDxgiFactory3).GUID, out IDxgiFactory2 factory);

            if (factory == null)
            {
                return null;
            }

            return new DxgiFactory3((IDxgiFactory3)factory);
        }

        /// <summary>
        /// Enumerates both adapters (video cards) with or without outputs.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="DxgiAdapter3"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<DxgiAdapter3> EnumAdapters()
        {
            for (uint i = 0; !this.factory.EnumAdapters1(i, out IDxgiAdapter1 adapter); i++)
            {
                yield return adapter == null ? null : new DxgiAdapter3((IDxgiAdapter2)adapter);
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
        /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
        /// </summary>
        /// <param name="device">The Direct3D device for the swap chain.</param>
        /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
        /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
        /// <param name="fullscreenDesc">A <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain.</param>
        /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
        /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Reliability", "CA2000:Supprimer les objets avant la mise hors de portée", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSwapChain3 CreateSwapChainForWindowHandle(
            object device,
            IntPtr hwnd,
            DxgiSwapChainDesc1 desc,
            DxgiSwapChainFullscreenDesc? fullscreenDesc,
            DxgiOutput3 restrictToOutput)
        {
            IDxgiSwapChain1 swapChain;

            if (fullscreenDesc == null)
            {
                swapChain = this.factory.CreateSwapChainForWindowHandle(
                    device,
                    hwnd,
                    ref desc,
                    IntPtr.Zero,
                    restrictToOutput?.GetHandle<IDxgiOutput>());
            }
            else
            {
                IntPtr fullscreenDescPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DxgiSwapChainFullscreenDesc)));

                try
                {
                    Marshal.StructureToPtr(fullscreenDesc.Value, fullscreenDescPtr, false);

                    swapChain = this.factory.CreateSwapChainForWindowHandle(
                        device,
                        hwnd,
                        ref desc,
                        fullscreenDescPtr,
                        restrictToOutput?.GetHandle<IDxgiOutput>());
                }
                finally
                {
                    Marshal.FreeHGlobal(fullscreenDescPtr);
                }
            }

            if (swapChain == null)
            {
                return null;
            }

            return new DxgiSwapChain3((IDxgiSwapChain2)swapChain);
        }
    }
}
