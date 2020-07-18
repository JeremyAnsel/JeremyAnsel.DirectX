// <copyright file="DxgiSwapChain3.cs" company="Jérémy Ansel">
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
    /// Extends <c>IDXGISwapChain1</c> with methods to support swap back buffer scaling and lower-latency swap chains.
    /// </summary>
    public sealed class DxgiSwapChain3 : DxgiDeviceSubObject
    {
        /// <summary>
        /// The DXGI swap chain interface.
        /// </summary>
        private readonly IDxgiSwapChain2 swapChain;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiSwapChain3"/> class.
        /// </summary>
        /// <param name="swapChain">A DXGI output interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiSwapChain3(IDxgiSwapChain2 swapChain)
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
        /// Gets or sets the number of frames that the swap chain is allowed to queue for rendering.
        /// </summary>
        public uint MaximumFrameLatency
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetMaximumFrameLatency();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.swapChain.SetMaximumFrameLatency(value);
            }
        }

        /// <summary>
        /// Gets or sets the transform matrix that will be applied to a composition swap chain upon the next present.
        /// </summary>
        public DxgiMatrix3x2F MatrixTransform
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.swapChain.GetMatrixTransform();
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                this.swapChain.SetMatrixTransform(ref value);
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
            DxgiPresentParameters parameters = default;

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

            try
            {
                DxgiPresentParameters parameters = new DxgiPresentParameters
                {
                    DirtyRectsCount = (uint)dirtyRects.Length,
                    DirtyRects = dirtyRectsHandle.AddrOfPinnedObject(),
                    ScrollRect = scrollRectHandle.AddrOfPinnedObject(),
                    ScrollOffset = scrollOffsetHandle.AddrOfPinnedObject()
                };

                this.swapChain.Present1(syncInterval, options, ref parameters);
            }
            finally
            {
                dirtyRectsHandle.Free();
                scrollRectHandle.Free();
                scrollOffsetHandle.Free();
            }
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
        public DxgiSurface3 GetSurface(uint buffer)
        {
            Guid riid = typeof(IDxgiSurface2).GUID;
            object surface = this.swapChain.GetBuffer(buffer, ref riid);

            if (surface == null)
            {
                return null;
            }

            return new DxgiSurface3((IDxgiSurface2)surface);
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
        /// <param name="target">A pointer to an <c>DXGIOutput3</c> interface for the output target that contains the swap chain.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetFullscreenState(bool fullscreen, DxgiOutput3 target)
        {
            this.swapChain.SetFullscreenState(fullscreen, target?.GetHandle<IDxgiOutput2>());
        }

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <returns>A value indicating whether to set the display state to windowed or full screen.</returns>
        public bool GetFullscreenState()
        {
            this.swapChain.GetFullscreenState(out bool fullscreen, out IDxgiOutput2 itarget);

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
        public bool GetFullscreenState(out DxgiOutput3 target)
        {
            this.swapChain.GetFullscreenState(out bool fullscreen, out IDxgiOutput2 itarget);
            target = itarget == null ? null : new DxgiOutput3(itarget);
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
        public DxgiOutput3 GetContainingOutput()
        {
            IDxgiOutput2 output = this.swapChain.GetContainingOutput();

            if (output == null)
            {
                return null;
            }

            return new DxgiOutput3(output);
        }

        /// <summary>
        /// Gets the output (the display monitor) to which you can restrict the contents of a present operation.
        /// </summary>
        /// <returns>The <c>DXGIOutput3</c> interface for the restrict-to output.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiOutput3 GetRestrictToOutput()
        {
            IDxgiOutput2 output = this.swapChain.GetRestrictToOutput();

            if (output == null)
            {
                return null;
            }

            return new DxgiOutput3(output);
        }

        /// <summary>
        /// Sets the source region to be used for the swap chain.
        /// </summary>
        /// <param name="width">Source width to use for the swap chain. This value must be greater than zero, and must be less than or equal to the overall width of the swap chain.</param>
        /// <param name="height">Source height to use for the swap chain. This value must be greater than zero, and must be less than or equal to the overall height of the swap chain.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetSourceSize(uint width, uint height)
        {
            this.swapChain.SetSourceSize(width, height);
        }

        /// <summary>
        /// Gets the source region used for the swap chain.
        /// </summary>
        /// <param name="width">The current width of the source region of the swap chain. This value can range from 1 to the overall width of the swap chain.</param>
        /// <param name="height">The current height of the source region of the swap chain. This value can range from 1 to the overall height of the swap chain.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetSourceSize(out uint width, out uint height)
        {
            this.swapChain.GetSourceSize(out width, out height);
        }
    }
}
