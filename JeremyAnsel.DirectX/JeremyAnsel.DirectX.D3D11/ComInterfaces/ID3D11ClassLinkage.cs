// <copyright file="ID3D11ClassLinkage.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// This interface encapsulates an HLSL dynamic linkage.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("ddf57cba-9543-46e4-a12b-f207a0fe7fed")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3D11ClassLinkage
    {
        /// <summary>
        /// Get a pointer to the device that created this interface.
        /// </summary>
        /// <param name="device">A device.</param>
        [PreserveSig]
        void GetDevice(
            [Out] out ID3D11Device? device);

        /// <summary>
        /// Get application-defined data from a device.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">A pointer to a variable that on input contains the size, in bytes, of the buffer.</param>
        /// <param name="data">A pointer to a buffer that will be filled with data from the device.</param>
        void GetPrivateData(
            [In] ref Guid name,
            [In, Out] ref uint dataSize,
            [Out, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Set data to a device and associate that data with a guid.
        /// </summary>
        /// <param name="name">The Guid associated with the data.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <param name="data">The data to be stored with this device.</param>
        void SetPrivateData(
            [In] ref Guid name,
            [In] uint dataSize,
            [In, MarshalAs(UnmanagedType.LPArray)] byte[]? data);

        /// <summary>
        /// Associate an IUnknown-derived interface with this device child and associate that interface with an application-defined guid.
        /// </summary>
        /// <param name="name">The Guid associated with the interface.</param>
        /// <param name="unknown">An <c>IUnknown</c>-derived interface to be associated with the device child.</param>
        void SetPrivateDataInterface(
            [In] ref Guid name,
            [In, MarshalAs(UnmanagedType.IUnknown)] object? unknown);

        /// <summary>
        /// Gets the class-instance object that represents the specified HLSL class.
        /// </summary>
        /// <param name="classInstanceName">The name of a class for which to get the class instance.</param>
        /// <param name="instanceIndex">The index of the class instance.</param>
        /// <returns>An <see cref="ID3D11ClassInstance"/> interface.</returns>
        ID3D11ClassInstance? GetClassInstance(
            [In, MarshalAs(UnmanagedType.LPStr)] string classInstanceName,
            [In] uint instanceIndex);

        /// <summary>
        /// Initializes a class-instance object that represents an HLSL class instance.
        /// </summary>
        /// <param name="classTypeName">The type name of a class to initialize.</param>
        /// <param name="constantBufferOffset">Identifies the constant buffer that contains the class data.</param>
        /// <param name="constantVectorOffset">The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is not a byte offset.</param>
        /// <param name="textureOffset">The texture slot for the first texture; there may be multiple textures following the offset.</param>
        /// <param name="samplerOffset">The sampler slot for the first sampler; there may be multiple samplers following the offset.</param>
        /// <returns>An <see cref="ID3D11ClassInstance"/> interface.</returns>
        ID3D11ClassInstance? CreateClassInstance(
            [In, MarshalAs(UnmanagedType.LPStr)] string classTypeName,
            [In] uint constantBufferOffset,
            [In] uint constantVectorOffset,
            [In] uint textureOffset,
            [In] uint samplerOffset);
    }
}
