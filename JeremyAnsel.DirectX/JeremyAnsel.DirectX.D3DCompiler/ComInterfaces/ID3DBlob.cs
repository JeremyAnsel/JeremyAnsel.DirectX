// <copyright file="ID3DBlob.cs" company="Jérémy Ansel">
// Copyright (c) 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3DCompiler.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// This interface is used to return data of arbitrary length.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("8BA5FB08-5195-40e2-AC58-0D989C3A0102")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID3DBlob
    {
        /// <summary>
        /// Retrieves a pointer to the blob's data.
        /// </summary>
        /// <returns>Returns a pointer to the blob's data.</returns>
        [PreserveSig]
        IntPtr GetBufferPointer();

        /// <summary>
        /// Retrieves the size, in bytes, of the blob's data.
        /// </summary>
        /// <returns>Returns the size of the blob's data, in bytes.</returns>
        [PreserveSig]
        UIntPtr GetBufferSize();
    }
}
