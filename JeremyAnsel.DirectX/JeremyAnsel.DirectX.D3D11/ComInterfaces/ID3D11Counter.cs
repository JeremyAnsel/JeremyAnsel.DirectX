// <copyright file="ID3D11Counter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// This interface encapsulates methods for measuring GPU performance.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID3D11Asynchronous"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("6e8c49fb-a371-4770-b440-29086022b741")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11Counter
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
        /// Get the size of the data (in bytes) that is output when calling <c>GetData</c>.
        /// </summary>
        /// <returns>The size of the data (in bytes) that is output when calling <c>GetData</c>.</returns>
        [PreserveSig]
        uint GetDataSize();

        /// <summary>
        /// Get a counter description.
        /// </summary>
        /// <param name="desc">A counter description.</param>
        [PreserveSig]
        void GetDesc(
            [Out] out D3D11CounterDesc desc);
    }
}
