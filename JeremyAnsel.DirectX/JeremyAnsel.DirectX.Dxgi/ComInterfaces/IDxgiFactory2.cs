// <copyright file="IDxgiFactory2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The <c>IDXGIFactory2</c> interface includes methods to create a newer version swap chain with more features than <c>IDXGISwapChain</c> and to monitor stereoscopic 3D capabilities.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiFactory1"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("50c83a1c-e072-4c48-87b0-3630fa36a6d0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiFactory2
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
        /// Enumerates the adapters (video cards).
        /// </summary>
        /// <param name="index">The index of the adapter to enumerate.</param>
        /// <param name="adapter">The address of a pointer to an <c>IDXGIAdapter</c> interface at the position specified by the index parameter.</param>
        /// <returns><value>S_OK</value> if successful; otherwise, returns <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than or equal to the number of adapters in the local system.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool EnumAdapters(
            [In] uint index,
            [Out] out IDxgiAdapter adapter);

        /// <summary>
        /// Allows DXGI to monitor an application's message queue for the alt-enter key sequence (which causes the application to switch from windowed to full screen or vice versa).
        /// </summary>
        /// <param name="windowHandle">The handle of the window that is to be monitored. This parameter can be <value>Zero</value>; but only if the flags are also 0.</param>
        /// <param name="options">One or more options.</param>
        void MakeWindowAssociation(
            [In] IntPtr windowHandle,
            [In] DxgiWindowAssociationOptions options);

        /// <summary>
        /// Get the window through which the user controls the transition to and from full screen.
        /// </summary>
        /// <returns>A window handle.</returns>
        IntPtr GetWindowAssociation();

        /// <summary>
        /// Creates a swap chain.
        /// </summary>
        /// <param name="device">A Direct3D device that will write 2D images to the swap chain.</param>
        /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC</c> structure for the swap-chain description.</param>
        /// <returns>An <c>IDXGISwapChain</c> interface for the swap chain</returns>
        IDxgiSwapChain CreateSwapChain(
            [In, MarshalAs(UnmanagedType.IUnknown)] object device,
            [In] ref DxgiSwapChainDesc desc);

        /// <summary>
        /// Create an adapter interface that represents a software adapter.
        /// </summary>
        /// <param name="module">Handle to the software adapter's dll.</param>
        /// <returns>An adapter.</returns>
        IDxgiAdapter CreateSoftwareAdapter(
            [In] IntPtr module);

        /// <summary>
        /// Enumerates both adapters (video cards) with or without outputs.
        /// </summary>
        /// <param name="index">The index of the adapter to enumerate.</param>
        /// <param name="adapter">The address of a pointer to an <c>IDXGIAdapter1</c> interface at the position specified by the index parameter.</param>
        /// <returns><value>S_OK</value> if successful; otherwise, returns <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than or equal to the number of adapters in the local system.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool EnumAdapters1(
            [In] uint index,
            [Out] out IDxgiAdapter1 adapter);

        /// <summary>
        /// Informs an application of the possible need to re-enumerate adapters.
        /// </summary>
        /// <returns><value>false</value>, if a new adapter is becoming available or the current adapter is going away. <value>true</value>, no adapter changes.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsCurrent();

        /// <summary>
        /// Determines whether to use stereo mode.
        /// </summary>
        /// <returns>Indicates whether to use stereo mode. <value>TRUE</value> indicates that you can use stereo mode; otherwise, <value>FALSE</value>.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsWindowedStereoEnabled();

        /// <summary>
        /// Creates a swap chain that is associated with an <c>HWND</c> handle to the output window for the swap chain.
        /// </summary>
        /// <param name="device">The Direct3D device for the swap chain.</param>
        /// <param name="hwnd">The <c>HWND</c> handle that is associated with the swap chain.</param>
        /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
        /// <param name="fullscreenDesc">A <c>DXGI_SWAP_CHAIN_FULLSCREEN_DESC</c> structure for the description of a full-screen swap chain.</param>
        /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
        /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
        IDxgiSwapChain1 CreateSwapChainForWindowHandle(
            [In, MarshalAs(UnmanagedType.IUnknown)] object device,
            [In] IntPtr hwnd,
            [In] ref DxgiSwapChainDesc1 desc,
            [In] IntPtr fullscreenDesc,
            [In] IDxgiOutput restrictToOutput);

        /// <summary>
        /// Creates a swap chain that is associated with the <c>CoreWindow</c> object for the output window for the swap chain.
        /// </summary>
        /// <param name="device">The Direct3D device for the swap chain.</param>
        /// <param name="window">The <c>CoreWindow</c> object that is associated with the swap chain.</param>
        /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
        /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
        /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
        IDxgiSwapChain1 CreateSwapChainForCoreWindow(
            [In, MarshalAs(UnmanagedType.IUnknown)] object device,
            [In] IntPtr window,
            [In] ref DxgiSwapChainDesc1 desc,
            [In] IDxgiOutput restrictToOutput);

        /// <summary>
        /// Identifies the adapter on which a shared resource object was created.
        /// </summary>
        /// <param name="resourceHandle">A handle to a shared resource object.</param>
        /// <returns>A locally unique identifier (LUID) value that identifies the adapter.</returns>
        ulong GetSharedResourceAdapterLuid(
            [In] IntPtr resourceHandle);

        /// <summary>
        ///  a locally unique identifier ( LUID) value that identifies the adapter.
        /// </summary>
        /// <param name="windowHandle">The handle of the window to send a notification message to when stereo status change occurs.</param>
        /// <param name="msg">Identifies the notification message to send.</param>
        /// <param name="cookie">A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister the notification message.</param>
        void RegisterStereoStatusWindow(
            [In] IntPtr windowHandle,
            [In] uint msg,
            [Out] out uint cookie);

        /// <summary>
        /// Registers to receive notification of changes in stereo status by using event signaling.
        /// </summary>
        /// <param name="eventHandle">A handle to the event object that the operating system sets when notification of stereo status change occurs.</param>
        /// <param name="cookie">A pointer to a key value that an application can pass to the <c>IDXGIFactory2::UnregisterStereoStatus</c> method to unregister the notification event.</param>
        void RegisterStereoStatusEvent(
            [In] IntPtr eventHandle,
            [Out] out uint cookie);

        /// <summary>
        /// Unregisters a window or an event to stop it from receiving notification when stereo status changes.
        /// </summary>
        /// <param name="cookie">A key value for the window or event to unregister.</param>
        [PreserveSig]
        void UnregisterStereoStatus(
            [In] uint cookie);

        /// <summary>
        /// Registers an application window to receive notification messages of changes of occlusion status.
        /// </summary>
        /// <param name="windowHandle">The handle of the window to send a notification message to when occlusion status change occurs.</param>
        /// <param name="msg">Identifies the notification message to send.</param>
        /// <param name="cookie">A key value that an application can pass to the <c>IDXGIFactory2::UnregisterOcclusionStatus</c> method to unregister the notification message.</param>
        void RegisterOcclusionStatusWindow(
            [In] IntPtr windowHandle,
            [In] uint msg,
            [Out] out uint cookie);

        /// <summary>
        /// Registers to receive notification of changes in occlusion status by using event signaling.
        /// </summary>
        /// <param name="eventHandle">A handle to the event object that the operating system sets when notification of occlusion status change occurs.</param>
        /// <param name="cookie">A key value that an application can pass to the IDXGIFactory2::UnregisterOcclusionStatus method to unregister the notification event.</param>
        void RegisterOcclusionStatusEvent(
            [In] IntPtr eventHandle,
            [Out] out uint cookie);

        /// <summary>
        /// Unregisters a window or an event to stop it from receiving notification when occlusion status changes.
        /// </summary>
        /// <param name="cookie">A key value for the window or event to unregister.</param>
        [PreserveSig]
        void UnregisterOcclusionStatus(
            [In] uint cookie);

        /// <summary>
        /// Creates a swap chain that you can use to send Direct3D content into the DirectComposition API or the <c>Windows.UI.Xaml</c> framework to compose in a window.
        /// </summary>
        /// <param name="device">The Direct3D device for the swap chain.</param>
        /// <param name="desc">A <c>DXGI_SWAP_CHAIN_DESC1</c> structure for the swap-chain description.</param>
        /// <param name="restrictToOutput">The <c>IDXGIOutput</c> interface for the output to restrict content to.</param>
        /// <returns>The <c>IDXGISwapChain1</c> interface for the swap chain.</returns>
        IDxgiSwapChain1 CreateSwapChainForComposition(
            [In, MarshalAs(UnmanagedType.IUnknown)] object device,
            [In] ref DxgiSwapChainDesc1 desc,
            [In] IDxgiOutput restrictToOutput);
    }
}
