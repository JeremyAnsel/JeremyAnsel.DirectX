// <copyright file="ID3D11ClassInstance.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// This interface encapsulates an HLSL class.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11ClassInstance
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
        /// Gets the <see cref="ID3D11ClassLinkage"/> object associated with the current HLSL class.
        /// </summary>
        /// <param name="linkage">A <see cref="ID3D11ClassLinkage"/> interface.</param>
        [PreserveSig]
        void GetClassLinkage(
            [Out] out ID3D11ClassLinkage linkage);

        /// <summary>
        /// Gets a description of the current HLSL class.
        /// </summary>
        /// <param name="desc">A description of the current HLSL class.</param>
        [PreserveSig]
        void GetDesc(
            [Out] out D3D11ClassInstanceDesc desc);

        /// <summary>
        /// Gets the instance name of the current HLSL class.
        /// </summary>
        /// <param name="instanceName">The instance name of the current HLSL class.</param>
        /// <param name="bufferLength">The length of the <paramref name="instanceName"/> parameter.</param>
        [PreserveSig]
        void GetInstanceName(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder instanceName,
            [In, Out] ref UIntPtr bufferLength);

        /// <summary>
        /// Gets the type of the current HLSL class.
        /// </summary>
        /// <param name="typeName">The type of the current HLSL class.</param>
        /// <param name="bufferLength">The length of the <paramref name="typeName"/> parameter.</param>
        [PreserveSig]
        void GetTypeName(
            [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder typeName,
            [In, Out] ref UIntPtr bufferLength);
    }
}
