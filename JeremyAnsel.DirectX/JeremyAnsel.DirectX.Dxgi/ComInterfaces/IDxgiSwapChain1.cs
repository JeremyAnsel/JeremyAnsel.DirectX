// <copyright file="IDxgiSwapChain1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// Provides presentation capabilities that are enhanced from <c>IDXGISwapChain</c>. These presentation capabilities consist of specifying dirty rectangles and scroll rectangle to optimize the presentation.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiSwapChain"/></remarks>
[Guid("790a45f7-0d42-4876-983a-0a55cfe6f4aa")]
internal unsafe readonly struct IDxgiSwapChain1
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
    /// <param name="target">A pointer to an <c>IDXGIOutput1</c> interface for the output target that contains the swap chain.</param>
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

    /// <summary>
    /// Gets a description of the swap chain.
    /// </summary>
    /// <returns>A <c>DXGI_SWAP_CHAIN_DESC1</c> structure that describes the swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetDesc1;

    /// <summary>
    /// Gets a description of a full-screen swap chain.
    /// </summary>
    /// <returns>A <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure that describes the full-screen swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetFullscreenDesc;

    /// <summary>
    /// Retrieves the underlying <c>HWND</c> for this swap-chain object.
    /// </summary>
    /// <returns>The <c>HWND</c> for the swap-chain object.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetWindowHandle;

    /// <summary>
    /// Retrieves the underlying <c>CoreWindow</c> object for this swap-chain object.
    /// </summary>
    /// <param name="riid">The globally unique identifier (GUID) of the <c>CoreWindow</c> object.</param>
    /// <returns>A pointer to the <c>CoreWindow</c> object.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint*, int> GetCoreWindow;

    /// <summary>
    /// Presents a frame on the display screen.
    /// </summary>
    /// <param name="syncInterval">An integer that specifies how to synchronize presentation of a frame with the vertical blank.</param>
    /// <param name="options">An integer value that contains swap-chain presentation options.</param>
    /// <param name="parameters">A <c>DXGI_PRESENT_PARAMETERS</c> structure that describes updated rectangles and scroll information of the frame to present.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, DxgiPresentOptions, void*, int> Present1;

    /// <summary>
    /// Determines whether a swap chain supports “temporary mono.”
    /// </summary>
    /// <returns>Indicates whether to use the swap chain in temporary mono mode. <value>true</value> indicates that you can use temporary-mono mode; otherwise, <value>false</value>.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int> IsTemporaryMonoSupported;

    /// <summary>
    /// Gets the output (the display monitor) to which you can restrict the contents of a present operation.
    /// </summary>
    /// <returns>The <c>IDXGIOutput</c> interface for the restrict-to output.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetRestrictToOutput;

    /// <summary>
    /// Changes the background color of the swap chain.
    /// </summary>
    /// <param name="color">A <c>DXGI_RGBA</c> structure that specifies the background color to set.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> SetBackgroundColor;

    /// <summary>
    /// Retrieves the background color of the swap chain.
    /// </summary>
    /// <returns>The background color of the swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> GetBackgroundColor;

    /// <summary>
    /// Sets the rotation of the back buffers for the swap chain.
    /// </summary>
    /// <param name="rotation">A <c>DXGI_MODE_ROTATION</c>-typed value that specifies how to set the rotation of the back buffers for the swap chain.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiModeRotation, int> SetRotation;

    /// <summary>
    /// Gets the rotation of the back buffers for the swap chain.
    /// </summary>
    /// <returns>A <c>DXGI_MODE_ROTATION</c>-typed value that specifies the rotation of the back buffers for the swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiModeRotation*, int> GetRotation;
}
