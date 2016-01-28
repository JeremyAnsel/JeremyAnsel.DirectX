// <copyright file="DxgiFactory2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
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
    /// The <c>IDXGIFactory2</c> interface includes methods to create a newer version swap chain with more features than <c>IDXGISwapChain</c> and to monitor stereoscopic 3D capabilities.
    /// </summary>
    public sealed class DxgiFactory2 : DxgiObject
    {
        /// <summary>
        /// The DXGI factory interface.
        /// </summary>
        private IDxgiFactory2 factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiFactory2"/> class.
        /// </summary>
        /// <param name="factory">A DXGI factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiFactory2(IDxgiFactory2 factory)
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
        /// Creates a DXGI 1.2 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <returns>A <see cref="DxgiFactory2"/> object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DxgiFactory2 Create()
        {
            IDxgiFactory1 factory;
            NativeMethods.CreateDxgiFactory1(typeof(IDxgiFactory1).GUID, out factory);
            return new DxgiFactory2((IDxgiFactory2)factory);
        }

        /// <summary>
        /// Enumerates both adapters (video cards) with or without outputs.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="DxgiAdapter2"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<DxgiAdapter2> EnumAdapters()
        {
            IDxgiAdapter1 adapter;

            for (uint i = 0; !this.factory.EnumAdapters1(i, out adapter); i++)
            {
                yield return new DxgiAdapter2((IDxgiAdapter2)adapter);
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
        public DxgiSwapChain2 CreateSwapChainForWindowHandle(
            object device,
            IntPtr hwnd,
            DxgiSwapChainDesc1 desc,
            DxgiSwapChainFullscreenDesc? fullscreenDesc,
            DxgiOutput2 restrictToOutput)
        {
            if (fullscreenDesc == null)
            {
                return new DxgiSwapChain2(this.factory.CreateSwapChainForWindowHandle(
                    device,
                    hwnd,
                    ref desc,
                    IntPtr.Zero,
                    restrictToOutput == null ? null : restrictToOutput.GetHandle<IDxgiOutput>()));
            }
            else
            {
                IntPtr fullscreenDescPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DxgiSwapChainFullscreenDesc)));

                try
                {
                    Marshal.StructureToPtr(fullscreenDesc.Value, fullscreenDescPtr, false);
                    return new DxgiSwapChain2(this.factory.CreateSwapChainForWindowHandle(
                        device,
                        hwnd,
                        ref desc,
                        fullscreenDescPtr,
                        restrictToOutput == null ? null : restrictToOutput.GetHandle<IDxgiOutput>()));
                }
                finally
                {
                    Marshal.FreeHGlobal(fullscreenDescPtr);
                }
            }
        }
    }
}
