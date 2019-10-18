// <copyright file="IDxgiSwapChain.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// An <c>IDXGISwapChain</c> interface implements one or more surfaces for storing rendered data before presenting it to an output.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiSwapChain
    {
        /// <summary>
        /// Sets application-defined data to the object and associates that data with a GUID.
        /// </summary>
        /// <param name="name">A GUID that identifies the data.</param>
        /// <param name="dataSize">The size of the object's data.</param>
        /// <param name="data">A pointer to the object's data.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Set an interface in the object's private data.
        /// </summary>
        /// <param name="name">A GUID identifying the interface.</param>
        /// <param name="unknown">The interface to set.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object unknown);

        /// <summary>
        /// Get a pointer to the object's data.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">Pointer to the data.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <param name="riid">The ID of the requested interface.</param>
        /// <returns>The address of a pointer to the parent object.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetParent(
            [In] ref Guid riid);

        /// <summary>
        /// Retrieves the device.
        /// </summary>
        /// <param name="riid">The reference id for the device.</param>
        /// <returns>The address of a pointer to the device.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetDevice(
            [In] ref Guid riid);

        /// <summary>
        /// Presents a rendered image to the user.
        /// </summary>
        /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
        /// <param name="options">The swap-chain presentation options.</param>
        void Present(
            [In] uint syncInterval,
            [In] DxgiPresentOptions options);

        /// <summary>
        /// Accesses one of the swap-chain's back buffers.
        /// </summary>
        /// <param name="buffer">A zero-based buffer index.</param>
        /// <param name="riid">The type of interface used to manipulate the buffer.</param>
        /// <returns>A pointer to a back-buffer interface.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object GetBuffer(
            [In] uint buffer,
            [In] ref Guid riid);

        /// <summary>
        /// Sets the display state to windowed or full screen.
        /// </summary>
        /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
        /// <param name="target">A pointer to an <c>IDXGIOutput</c> interface for the output target that contains the swap chain.</param>
        void SetFullscreenState(
            [In, MarshalAs(UnmanagedType.Bool)] bool fullscreen,
            [In] IDxgiOutput target);

        /// <summary>
        /// Get the state associated with full-screen mode.
        /// </summary>
        /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
        /// <param name="target">The output target when the mode is full screen.</param>
        void GetFullscreenState(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool fullscreen,
            [Out] out IDxgiOutput target);

        /// <summary>
        /// Get a description of the swap chain.
        /// </summary>
        /// <returns>The swap-chain description.</returns>
        DxgiSwapChainDesc GetDesc();

        /// <summary>
        /// Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.
        /// </summary>
        /// <param name="bufferCount">The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of buffers with which you created the swap chain.</param>
        /// <param name="width">New width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window.</param>
        /// <param name="height">New height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window.</param>
        /// <param name="format">A <c>DXGI_FORMAT</c>-typed value for the new format of the back buffer. Set this value to <value>DXGI_FORMAT_UNKNOWN</value> to preserve the existing format of the back buffer.</param>
        /// <param name="options">The options for swap-chain behavior.</param>
        void ResizeBuffers(
            [In] uint bufferCount,
            [In] uint width,
            [In] uint height,
            [In] DxgiFormat format,
            [In] DxgiSwapChainOptions options);

        /// <summary>
        /// Resizes the output target.
        /// </summary>
        /// <param name="targetParameters">A <c>DXGI_MODE_DESC</c> structure that describes the mode, which specifies the new width, height, format, and refresh rate of the target. If the format is <value>DXGI_FORMAT_UNKNOWN</value>, ResizeTarget uses the existing format.</param>
        void ResizeTarget(
            [In] ref DxgiModeDesc targetParameters);

        /// <summary>
        /// Get the output (the display monitor) that contains the majority of the client area of the target window.
        /// </summary>
        /// <returns>The output interface.</returns>
        IDxgiOutput GetContainingOutput();

        /// <summary>
        /// Gets performance statistics about the last render frame.
        /// </summary>
        /// <returns>The frame statistics.</returns>
        DxgiFrameStatistics GetFrameStatistics();

        /// <summary>
        /// Gets the number of times that <c>IDXGISwapChain::Present</c> or <c>IDXGISwapChain1::Present1</c> has been called.
        /// </summary>
        /// <returns>The number of calls.</returns>
        uint GetLastPresentCount();
    }
}
