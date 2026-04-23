// <copyright file="IDxgiSwapChain.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// An <c>IDXGISwapChain</c> interface implements one or more surfaces for storing rendered data before presenting it to an output.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
[Guid("310d36a0-d2e7-4c0a-aa04-6a9d23b8886a")]
internal unsafe readonly struct IDxgiSwapChain
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;
    private readonly nint GetDevice;

    /// <summary>
    /// Presents a rendered image to the user.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">The swap-chain presentation options.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, DxgiPresentOptions, int> Present;

    /// <summary>
    /// Accesses one of the swap-chain's back buffers.
    /// </summary>
    /// <param name="buffer">A zero-based buffer index.</param>
    /// <param name="riid">The type of interface used to manipulate the buffer.</param>
    /// <returns>A pointer to a back-buffer interface.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, in Guid, nint*, int> GetBuffer;

    /// <summary>
    /// Sets the display state to windowed or full screen.
    /// </summary>
    /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
    /// <param name="target">A pointer to an <c>IDXGIOutput</c> interface for the output target that contains the swap chain.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, int, nint, int> SetFullscreenState;

    /// <summary>
    /// Get the state associated with full-screen mode.
    /// </summary>
    /// <param name="fullscreen">A value indicating whether to set the display state to windowed or full screen.</param>
    /// <param name="target">The output target when the mode is full screen.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, int*, nint*, int> GetFullscreenState;

    /// <summary>
    /// Get a description of the swap chain.
    /// </summary>
    /// <returns>The swap-chain description.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc;

    /// <summary>
    /// Changes the swap chain's back buffer size, format, and number of buffers. This should be called when the application window is resized.
    /// </summary>
    /// <param name="bufferCount">The number of buffers in the swap chain (including all back and front buffers). This number can be different from the number of buffers with which you created the swap chain.</param>
    /// <param name="width">New width of the back buffer. If you specify zero, DXGI will use the width of the client area of the target window.</param>
    /// <param name="height">New height of the back buffer. If you specify zero, DXGI will use the height of the client area of the target window.</param>
    /// <param name="format">A <c>DXGI_FORMAT</c>-typed value for the new format of the back buffer. Set this value to <value>DXGI_FORMAT_UNKNOWN</value> to preserve the existing format of the back buffer.</param>
    /// <param name="options">The options for swap-chain behavior.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, uint, DxgiFormat, DxgiSwapChainOptions, int> ResizeBuffers;

    /// <summary>
    /// Resizes the output target.
    /// </summary>
    /// <param name="targetParameters">A <c>DXGI_MODE_DESC</c> structure that describes the mode, which specifies the new width, height, format, and refresh rate of the target. If the format is <value>DXGI_FORMAT_UNKNOWN</value>, ResizeTarget uses the existing format.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> ResizeTarget;

    /// <summary>
    /// Get the output (the display monitor) that contains the majority of the client area of the target window.
    /// </summary>
    /// <returns>The output interface.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetContainingOutput;

    /// <summary>
    /// Gets performance statistics about the last render frame.
    /// </summary>
    /// <returns>The frame statistics.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetFrameStatistics;

    /// <summary>
    /// Gets the number of times that <c>IDXGISwapChain::Present</c> or <c>IDXGISwapChain1::Present1</c> has been called.
    /// </summary>
    /// <returns>The number of calls.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetLastPresentCount;
}
