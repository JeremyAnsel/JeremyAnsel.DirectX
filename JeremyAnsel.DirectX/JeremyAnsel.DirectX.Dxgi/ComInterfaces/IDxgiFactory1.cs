// <copyright file="IDxgiFactory1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The <c>IDXGIFactory1</c> interface implements methods for generating DXGI objects.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiFactory"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("770aae78-f26f-4dba-a829-253c83d1b387")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiFactory1
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
    }
}
