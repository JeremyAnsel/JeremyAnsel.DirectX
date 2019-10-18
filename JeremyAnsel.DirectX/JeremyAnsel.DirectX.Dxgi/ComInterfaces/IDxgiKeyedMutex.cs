// <copyright file="IDxgiKeyedMutex.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Represents a keyed mutex, which allows exclusive access to a shared resource that is used by multiple devices.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("9d8e1289-d7b3-465f-8126-250e349af85d")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiKeyedMutex
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
        /// Using a key, acquires exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="key">A value that indicates which device to give access to.</param>
        /// <param name="milliseconds">The time-out interval, in milliseconds.</param>
        void AcquireSync(
            [In] ulong key,
            [In] uint milliseconds);

        /// <summary>
        /// Using a key, releases exclusive rendering access to a shared resource.
        /// </summary>
        /// <param name="key">A value that indicates which device to give access to.</param>
        void ReleaseSync(
            [In] ulong key);
    }
}
