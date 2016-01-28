// <copyright file="IDxgiResource1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// An <c>IDXGIResource1</c> interface extends the <c>IDXGIResource</c> interface by adding support for creating a sub-resource surface object and for creating a handle to a shared resource.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiResource"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("30961379-4609-4a41-998e-54fe567ee0c1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiResource1
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

        /// <summary>
        /// Creates a sub-resource surface object.
        /// </summary>
        /// <param name="index">The index of the sub-resource surface object to enumerate.</param>
        /// <returns>A <c>IDXGISurface2</c> interface that represents the created sub-resource surface object at the position specified.</returns>
        IDxgiSurface2 CreateSubresourceSurface(
            [In] uint index);

        /// <summary>
        /// Creates a handle to a shared resource. You can then use the returned handle with multiple Direct3D devices.
        /// </summary>
        /// <param name="securityAttributes">A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether child processes can inherit the returned handle.</param>
        /// <param name="access">The requested access rights to the resource.</param>
        /// <param name="name">The name of the resource to share. The name is limited to <value>MAX_PATH</value> characters. Name comparison is case sensitive.</param>
        /// <returns>The <c>NT HANDLE</c> value to the resource to share. You can use this handle in calls to access the resource.</returns>
        IntPtr CreateSharedHandle(
            [In] IntPtr securityAttributes,
            [In] DxgiSharedResourceAccess access,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name);
    }
}
