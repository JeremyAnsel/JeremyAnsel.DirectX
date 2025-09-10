// <copyright file="DxgiSwapChain1.cs" company="Jérémy Ansel">
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
    /// An <c>IDXGISwapChain</c> interface implements one or more surfaces for storing rendered data before presenting it to an output.
    /// </summary>
    public sealed class DxgiSwapChain1 : DxgiDeviceSubObject
    {
        /// <summary>
        /// The DXGI swap chain interface.
        /// </summary>
        private readonly IDxgiSwapChain swapChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSwapChain1"/> class.
        /// </summary>
        /// <param name="swapChain">A DXGI output interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiSwapChain1(IDxgiSwapChain swapChain)
        {
            this.swapChain = swapChain;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.swapChain; }
        }

        /// <summary>
        /// Gets a description of the swap chain.
        /// </summary>
        public DxgiSwapChainDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetDesc();
            }
        }

        /// <summary>
        /// Gets performance statistics about the last render frame.
        /// </summary>
        public DxgiFrameStatistics FrameStatistics
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetFrameStatistics();
            }
        }

        /// <summary>
        /// Gets the number of times that <c>IDXGISwapChain::Present</c> or <c>IDXGISwapChain1::Present1</c> has been called.
        /// </summary>
        public uint LastPresentCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetLastPresentCount();
            }
        }

        /// <summary>
        /// Presents a rendered image to the user.
        /// </summary>
        /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
        /// <param name="options">The swap-chain presentation options.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Present(uint syncInterval, DxgiPresentOptions options)
        {
            this.swapChain.Present(syncInterval, options);
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers.
        /// </summary>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <param name="riid">The type of interface used to manipulate the buffer.</param>
        /// <returns>A pointer to a back-buffer interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object? GetBuffer(uint buffer, Guid riid)
        {
            return this.swapChain.GetBuffer(buffer, ref riid);
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers.
        /// </summary>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <returns>A back-buffer surface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurface1? GetSurface(uint buffer)
        {
            Guid riid = typeof(IDxgiSurface1).GUID;
            object? surface = this.swapChain.GetBuffer(buffer, ref riid);

            if (surface == null)
            {
                return null;
            }

            return new DxgiSurface1((IDxgiSurface1)surface);
        }

        /// <summary>
        /// Sets the display state to windowed or full screen.
        /// </summary>
        /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFullscreenState(bool fullscreen)
        {
            this.swapChain.SetFullscreenState(fullscreen, null);
        }

        /// <summary>
        /// Sets the display state to windowed or full screen.
        /// </summary>
        /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
        /// <param name="target">A pointer to an <c>DXGIOutput1</c> interface for the output target that contains the swap chain.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFullscreenState(bool fullscreen, DxgiOutput1? target)
        {
            this.swapChain.SetFullscreenState(fullscreen, target?.GetHandle<IDxgiOutput>());
        }

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
        public bool GetFullscreenState()
        {
            this.swapChain.GetFullscreenState(out bool fullscreen, out IDxgiOutput? itarget);

            if (itarget != null)
            {
                Marshal.ReleaseComObject(itarget);
            }

            return fullscreen;
        }

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <param name="target">The output target when the mode is full screen.</param>
        /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        public bool GetFullscreenState(out DxgiOutput1? target)
        {
            this.swapChain.GetFullscreenState(out bool fullscreen, out IDxgiOutput? itarget);
            target = itarget == null ? null : new DxgiOutput1(itarget);
            return fullscreen;
        }

        /// <summary>
        /// Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.
        /// </summary>
        /// <param name="bufferCount">The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of buffers with which you created the swap chain.</param>
        /// <param name="width">New width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window.</param>
        /// <param name="height">New height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window.</param>
        /// <param name="format">A <c>DXGI_FORMAT</c>-typed value for the new format of the back buffer. Set this value to <value>DXGI_FORMAT_UNKNOWN</value> to preserve the existing format of the back buffer.</param>
        /// <param name="options">The options for swap-chain behavior.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ResizeBuffers(uint bufferCount, uint width, uint height, DxgiFormat format, DxgiSwapChainOptions options)
        {
            this.swapChain.ResizeBuffers(bufferCount, width, height, format, options);
        }

        /// <summary>
        /// Resizes the output target.
        /// </summary>
        /// <param name="targetParameters">A <c>DXGI_MODE_DESC</c> structure that describes the mode, which specifies the new width, height, format, and refresh rate of the target. If the format is <value>DXGI_FORMAT_UNKNOWN</value>, ResizeTarget uses the existing format.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ResizeTarget(DxgiModeDesc targetParameters)
        {
            this.swapChain.ResizeTarget(ref targetParameters);
        }

        /// <summary>
        /// Get the output (the display monitor) that contains the majority of the client area of the target window.
        /// </summary>
        /// <returns>The output interface.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiOutput1? GetContainingOutput()
        {
            IDxgiOutput? output = this.swapChain.GetContainingOutput();

            if (output == null)
            {
                return null;
            }

            return new DxgiOutput1(output);
        }
    }
}
