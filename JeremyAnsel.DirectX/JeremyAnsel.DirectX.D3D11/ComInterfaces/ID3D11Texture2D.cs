﻿// <copyright file="ID3D11Texture2D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// A 2D texture interface manages texel data, which is structured memory.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID3D11Resource"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11Texture2D
    {
        /// <summary>
        /// Get a pointer to the device that created this interface.
        /// </summary>
        /// <param name="device">A device.</param>
        [PreserveSig]
        void GetDevice(
            [Out] out ID3D11Device device);

        /// <summary>
        /// Get application-defined data from a device.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">A pointer to a variable that on input contains the size, in bytes, of the buffer.</param>
        /// <param name="data">A pointer to a buffer that will be filled with data from the device.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Set data to a device and associate that data with a guid.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">The data to be stored with this device.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] data);

        /// <summary>
        /// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
        /// </summary>
        /// <param name="name">The Guid associated with the interface.</param>
        /// <param name="unknown">An <c>IUnknown</c>-derived interface to be associated with the device child.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object unknown);

        /// <summary>
        /// Get the type of the resource.
        /// </summary>
        /// <param name="dimension">The resource type.</param>
        [PreserveSig]
        void GetDimension(
            [Out] out D3D11ResourceDimension dimension);

        /// <summary>
        /// Set the eviction priority of a resource.
        /// </summary>
        /// <param name="evictionPriority">The eviction priority for the resource.</param>
        [PreserveSig]
        void SetEvictionPriority(
            [In] DxgiResourceEvictionPriority evictionPriority);

        /// <summary>
        /// Get the eviction priority of a resource.
        /// </summary>
        /// <returns>The eviction priority for the resource.</returns>
        [PreserveSig]
        DxgiResourceEvictionPriority GetEvictionPriority();

        /// <summary>
        /// Get the properties of the texture resource.
        /// </summary>
        /// <param name="desc">A resource description.</param>
        [PreserveSig]
        void GetDesc(
            [Out] out D3D11Texture2DDesc desc);
    }
}
