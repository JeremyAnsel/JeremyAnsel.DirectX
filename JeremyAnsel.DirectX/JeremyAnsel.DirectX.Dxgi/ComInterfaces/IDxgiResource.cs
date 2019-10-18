// <copyright file="IDxgiResource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// An <c>IDXGIResource</c> interface allows resource sharing and identifies the memory that a resource resides in.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiResource
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
        /// Gets the handle to a shared resource.
        /// </summary>
        /// <returns>A handle.</returns>
        IntPtr GetSharedHandle();

        /// <summary>
        /// Get the expected resource usage.
        /// </summary>
        /// <returns>A usage flag.</returns>
        DxgiUsages GetUsage();

        /// <summary>
        /// Set the priority for evicting the resource from memory.
        /// </summary>
        /// <param name="evictionPriority">The eviction priority, which determines when a resource can be evicted from memory.</param>
        void SetEvictionPriority(
            [In] DxgiResourceEvictionPriority evictionPriority);

        /// <summary>
        /// Get the eviction priority.
        /// </summary>
        /// <returns>The eviction priority, which determines when a resource can be evicted from memory.</returns>
        DxgiResourceEvictionPriority GetEvictionPriority();
    }
}
