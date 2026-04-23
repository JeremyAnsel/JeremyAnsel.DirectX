// <copyright file="IDxgiFactory3.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// Enables creating Microsoft DirectX Graphics Infrastructure (DXGI) objects.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiFactory2"/></remarks>
[Guid("25483823-cd46-4c7d-86ca-47aa95b837bd")]
internal unsafe readonly struct IDxgiFactory3
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;

    /// <summary>
    /// Enumerates the adapters (video cards).
    /// </summary>
    /// <param name="index">The index of the adapter to enumerate.</param>
    /// <param name="adapter">The address of a pointer to an <c>IDXGIAdapter</c> interface at the position specified by the index parameter.</param>
    /// <returns><value>S_OK</value> if successful; otherwise, returns <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than or equal to the number of adapters in the local system.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> EnumAdapters;

    /// <summary>
    /// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch from windowed to full screen or vice versa).
    /// </summary>
    /// <param name="windowHandle">The handle of the window that is to be monitored. This parameter can be <value>Zero</value>; but only if the flags are also 0.</param>
    /// <param name="options">One or more options.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, DxgiWindowAssociationOptions, int> MakeWindowAssociation;

    /// <summary>
    /// Get the window through which the user controls the transition to and from full screen.
    /// </summary>
    /// <returns>A window handle.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetWindowAssociation;

    /// <summary>
    /// Creates a swap chain.
    /// </summary>
    /// <param name="device">A Direct3D device that will write 2D images to the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC</c> structure for the swap-chain description.</param>
    /// <returns>An <c>IDXGISwapChain</c> interface for the swap chain</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint*, int> CreateSwapChain;

    /// <summary>
    /// Create an adapter interface that represents a software adapter.
    /// </summary>
    /// <param name="module">Handle to the software adapter's dll.</param>
    /// <returns>An adapter.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint*, int> CreateSoftwareAdapter;

    /// <summary>
    /// Enumerates both adapters (video cards) with or without outputs.
    /// </summary>
    /// <param name="index">The index of the adapter to enumerate.</param>
    /// <param name="adapter">The address of a pointer to an <c>IDXGIAdapter1</c> interface at the position specified by the index parameter.</param>
    /// <returns><value>S_OK</value> if successful; otherwise, returns <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than or equal to the number of adapters in the local system.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> EnumAdapters1;

    /// <summary>
    /// Informs an application of the possible need to re-enumerate adapters.
    /// </summary>
    /// <returns><value>false</value>, if a new adapter is becoming available or the current adapter is going away. <value>true</value>, no adapter changes.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int> IsCurrent;

    /// <summary>
    /// Determines whether to use stereo mode.
    /// </summary>
    /// <returns>Indicates whether to use stereo mode. <value>TRUE</value> indicates that you can use stereo mode; otherwise, <value>FALSE</value>.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, int> IsWindowedStereoEnabled;

    /// <summary>
    /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <param name="fullscreenDesc">A <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain.</param>
    /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, void*, void*, nint, nint*, int> CreateSwapChainForWindowHandle;

    /// <summary>
    /// Creates a swap chain that is associated with the <c>CoreWindow</c> object for the output window for the swap chain.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="window">The <c>CoreWindow</c> object that is associated with the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, void*, nint, nint*, int> CreateSwapChainForCoreWindow;

    /// <summary>
    /// Identifies the adapter on which a shared resource object was created.
    /// </summary>
    /// <param name="resourceHandle">A handle to a shared resource object.</param>
    /// <returns>A locally unique identifier (LUID) value that identifies the adapter.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, ulong*, int> GetSharedResourceAdapterLuid;

    /// <summary>
    /// Registers an application window to receive notification messages of changes of stereo status.
    /// </summary>
    /// <param name="windowHandle">The handle of the window to send a notification message to when stereo status change occurs.</param>
    /// <param name="msg">Identifies the notification message to send.</param>
    /// <param name="cookie">A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister the notification message.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint*, int> RegisterStereoStatusWindow;

    /// <summary>
    /// Registers to receive notification of changes in stereo status by using event signaling.
    /// </summary>
    /// <param name="eventHandle">A handle to the event object that the operating system sets when notification of stereo status change occurs.</param>
    /// <param name="cookie">A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister the notification event.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint*, int> RegisterStereoStatusEvent;

    /// <summary>
    /// Unregisters a window or an event to stop it from receiving notification when stereo status changes.
    /// </summary>
    /// <param name="cookie">A key value for the window or event to unregister.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void> UnregisterStereoStatus;

    /// <summary>
    /// Registers an application window to receive notification messages of changes of occlusion status.
    /// </summary>
    /// <param name="windowHandle">The handle of the window to send a notification message to when occlusion status change occurs.</param>
    /// <param name="msg">Identifies the notification message to send.</param>
    /// <param name="cookie">A key value that an application can pass to the <c>IDXGIFactory2::UnregisterOcclusionStatus</c> method to unregister the notification message.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint, uint*, int> RegisterOcclusionStatusWindow;

    /// <summary>
    /// Registers to receive notification of changes in occlusion status by using event signaling.
    /// </summary>
    /// <param name="eventHandle">A handle to the event object that the operating system sets when notification of occlusion status change occurs.</param>
    /// <param name="cookie">A key value that an application can pass to the IDXGIFactory2::UnregisterOcclusionStatus method to unregister the notification event.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, uint*, int> RegisterOcclusionStatusEvent;

    /// <summary>
    /// Unregisters a window or an event to stop it from receiving notification when occlusion status changes.
    /// </summary>
    /// <param name="cookie">A key value for the window or event to unregister.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, void> UnregisterOcclusionStatus;

    /// <summary>
    /// Creates a swap chain that you can use to send Direct3D content into the DirectComposition API or the <c>Windows.UI.Xaml</c> framework to compose in a window.
    /// </summary>
    /// <param name="device">The Direct3D device for the swap chain.</param>
    /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
    /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
    /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint, nint*, int> CreateSwapChainForComposition;

    /// <summary>
    /// Gets the flags that were used when a Microsoft DirectX Graphics Infrastructure (DXGI) object was created.
    /// </summary>
    /// <returns>The creation flags.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiCreateFactoryOptions> GetCreationOptions;
}
