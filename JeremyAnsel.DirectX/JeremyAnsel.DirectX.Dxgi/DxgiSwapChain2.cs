// <copyright file="DxgiSwapChain2.cs" company="Jérémy Ansel">
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
    /// Provides presentation capabilities that are enhanced from <c>IDXGISwapChain</c>. These presentation capabilities consist of specifying dirty rectangles and scroll rectangle to optimize the presentation.
    /// </summary>
    public sealed class DxgiSwapChain2 : DxgiDeviceSubObject
    {
        /// <summary>
        /// The DXGI swap chain interface.
        /// </summary>
        private readonly IDxgiSwapChain1 swapChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSwapChain2"/> class.
        /// </summary>
        /// <param name="swapChain">A DXGI output interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiSwapChain2(IDxgiSwapChain1 swapChain)
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
        public DxgiSwapChainDesc1 Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetDesc1();
            }
        }

        /// <summary>
        /// Gets a description of a full-screen swap chain.
        /// </summary>
        public DxgiSwapChainFullscreenDesc FullscreenDescription
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetFullscreenDesc();
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
        /// Gets the underlying <c>HWND</c> for this swap-chain object.
        /// </summary>
        public IntPtr WindowHandle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetWindowHandle();
            }
        }

        /// <summary>
        /// Gets a value indicating whether a swap chain supports “temporary mono.”
        /// </summary>
        public bool IsTemporaryMonoSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.IsTemporaryMonoSupported();
            }
        }

        /// <summary>
        /// Gets or sets the background color of the swap chain.
        /// </summary>
        public DxgiColorRgba BackgroundColor
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetBackgroundColor();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.swapChain.SetBackgroundColor(ref value);
            }
        }

        /// <summary>
        /// Gets or sets the rotation of the back buffers for the swap chain.
        /// </summary>
        public DxgiModeRotation Rotation
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetRotation();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.swapChain.SetRotation(value);
            }
        }

        /// <summary>
        /// Presents a frame on the display screen.
        /// </summary>
        /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
        /// <param name="options">An integer value that contains swap-chain presentation options.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Present(uint syncInterval, DxgiPresentOptions options)
        {
            DxgiPresentParameters parameters = default(DxgiPresentParameters);

            this.swapChain.Present1(syncInterval, options, ref parameters);
        }

        /// <summary>
        /// Presents a frame on the display screen.
        /// </summary>
        /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
        /// <param name="options">An integer value that contains swap-chain presentation options.</param>
        /// <param name="dirtyRects">A list of updated rectangles that you update in the back buffer for the presented frame.</param>
        /// <param name="scrollRect">The rectangle of the previous frame from which the runtime bit-block transfers content.</param>
        /// <param name="scrollOffset">The offset of the scrolled area that goes from the source rectangle (of previous frame) to the destination rectangle (of current frame).</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Present(uint syncInterval, DxgiPresentOptions options, DxgiRect[] dirtyRects, DxgiRect scrollRect, DxgiPoint scrollOffset)
        {
            if (dirtyRects == null)
            {
                throw new ArgumentNullException(nameof(dirtyRects));
            }

            var dirtyRectsHandle = GCHandle.Alloc(dirtyRects[0], GCHandleType.Pinned);
            var scrollRectHandle = GCHandle.Alloc(scrollRect, GCHandleType.Pinned);
            var scrollOffsetHandle = GCHandle.Alloc(scrollOffset, GCHandleType.Pinned);

            DxgiPresentParameters parameters = new DxgiPresentParameters();
            parameters.DirtyRectsCount = (uint)dirtyRects.Length;
            parameters.DirtyRects = dirtyRectsHandle.AddrOfPinnedObject();
            parameters.ScrollRect = scrollRectHandle.AddrOfPinnedObject();
            parameters.ScrollOffset = scrollOffsetHandle.AddrOfPinnedObject();

            this.swapChain.Present1(syncInterval, options, ref parameters);

            dirtyRectsHandle.Free();
            scrollRectHandle.Free();
            scrollOffsetHandle.Free();
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers.
        /// </summary>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <param name="riid">The type of interface used to manipulate the buffer.</param>
        /// <returns>A pointer to a back-buffer interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetBuffer(uint buffer, Guid riid)
        {
            return this.swapChain.GetBuffer(buffer, ref riid);
        }

        /// <summary>
        /// Accesses one of the swap-chain's back buffers.
        /// </summary>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <returns>A back-buffer surface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiSurface2 GetSurface(uint buffer)
        {
            Guid riid = typeof(IDxgiSurface2).GUID;
            return new DxgiSurface2((IDxgiSurface2)this.swapChain.GetBuffer(buffer, ref riid));
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
        /// <param name="target">A pointer to an <c>DXGIOutput2</c> interface for the output target that contains the swap chain.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFullscreenState(bool fullscreen, DxgiOutput2 target)
        {
            this.swapChain.SetFullscreenState(fullscreen, target == null ? null : target.GetHandle<IDxgiOutput1>());
        }

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
        public bool GetFullscreenState()
        {
            bool fullscreen;
            IDxgiOutput1 itarget;
            this.swapChain.GetFullscreenState(out fullscreen, out itarget);
            return fullscreen;
        }

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <param name="target">The output target when the mode is full screen.</param>
        /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        public bool GetFullscreenState(out DxgiOutput2 target)
        {
            bool fullscreen;
            IDxgiOutput1 itarget;
            this.swapChain.GetFullscreenState(out fullscreen, out itarget);
            target = new DxgiOutput2(itarget);
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
        public DxgiOutput2 GetContainingOutput()
        {
            return new DxgiOutput2(this.swapChain.GetContainingOutput());
        }

        /// <summary>
        /// Gets the output (the display monitor) to which you can restrict the contents of a present operation.
        /// </summary>
        /// <returns>The <c>DXGIOutput2</c> interface for the restrict-to output.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiOutput2 GetRestrictToOutput()
        {
            return new DxgiOutput2(this.swapChain.GetRestrictToOutput());
        }
    }
}
