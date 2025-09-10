// <copyright file="IDxgiAdapter2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The <c>IDXGIAdapter2</c> interface represents a display sub-system, which includes one or more GPUs, DACs, and video memory.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDxgiAdapter1"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("0AA1AE0A-FA0E-4B84-8644-E05FF8E5ACB5")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDxgiAdapter2
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
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Set an interface in the object's private data.
        /// </summary>
        /// <param name="name">A GUID identifying the interface.</param>
        /// <param name="unknown">The interface to set.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object? unknown);

        /// <summary>
        /// Get a pointer to the object's data.
        /// </summary>
        /// <param name="name">A GUID identifying the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">Pointer to the data.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <param name="riid">The ID of the requested interface.</param>
        /// <returns>The address of a pointer to the parent object.</returns>
        [return: MarshalAs(UnmanagedType.IUnknown)]
        object? GetParent(
            [In] ref Guid riid);

        /// <summary>
        /// Enumerate adapter (video card) outputs.
        /// </summary>
        /// <param name="uindex">The index of the output.</param>
        /// <param name="output">The address of a pointer to an <c>IDXGIOutput</c> interface at the position specified by the Output parameter.</param>
        /// <returns>A code that indicates success or failure. Will return <value>DXGI_ERROR_NOT_FOUND</value> if the index is greater than the number of outputs.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool EnumOutputs(
            [In] uint uindex,
            [Out] out IDxgiOutput? output);

        /// <summary>
        /// Gets a DXGI 1.0 description of an adapter (or video card).
        /// </summary>
        /// <returns>A <c>DXGI_ADAPTER_DESC</c> structure that describes the adapter.</returns>
        DxgiAdapterDesc GetDesc();

        /// <summary>
        /// Checks whether the system supports a device interface for a graphics component.
        /// </summary>
        /// <param name="name">The GUID of the interface of the device version for which support is being checked.</param>
        /// <param name="umdVersion">The user mode driver version of interface's name.</param>
        /// <returns><value>S_OK</value> indicates that the interface is supported, otherwise <value>DXGI_ERROR_UNSUPPORTED</value>.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool CheckInterfaceSupport(
            [In] ref Guid name,
            [Out] out long umdVersion);

        /// <summary>
        /// Gets a DXGI 1.1 description of an adapter (or video card).
        /// </summary>
        /// <returns>A <c>DXGI_ADAPTER_DESC1</c> structure that describes the adapter.</returns>
        DxgiAdapterDesc1 GetDesc1();

        /// <summary>
        /// Gets a Microsoft DirectX Graphics Infrastructure (DXGI) 1.2 description of an adapter or video card. This description includes information about the granularity at which the graphics processing unit (GPU) can be preempted from performing its current task.
        /// </summary>
        /// <returns>A <c>DXGI_ADAPTER_DESC2</c> structure that describes the adapter.</returns>
        DxgiAdapterDesc2 GetDesc2();
    }
}
