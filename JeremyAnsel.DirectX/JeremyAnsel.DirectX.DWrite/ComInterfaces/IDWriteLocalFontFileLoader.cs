// <copyright file="IDWriteLocalFontFileLoader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// A built-in implementation of IDWriteFontFileLoader interface that operates on local font files
    /// and exposes local font file information from the font file reference key.
    /// Font file references created using CreateFontFileReference use this font file loader.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDWriteFontFileLoader"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("b2d9f3ec-c9fe-4a11-a2ec-d86208f7c0a2")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteLocalFontFileLoader
    {
        /// <summary>
        /// Creates a font file stream object that encapsulates an open file resource.
        /// The resource is closed when the last reference to fontFileStream is released.
        /// </summary>
        /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the font file resource
        /// within the scope of the font loader being used.</param>
        /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        /// <param name="fontFileStream">Pointer to the newly created font file stream.</param>
        void CreateStreamFromKey(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] fontFileReferenceKey,
            [In] uint fontFileReferenceKeySize,
            [Out] out IDWriteFontFileStream fontFileStream);

        /// <summary>
        /// Obtains the length of the absolute file path from the font file reference key.
        /// </summary>
        /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the local font file
        /// within the scope of the font loader being used.</param>
        /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        /// <param name="filePathLength">Length of the file path string not including the terminated NULL character.</param>
        void GetFilePathLengthFromKey(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] fontFileReferenceKey,
            [In] uint fontFileReferenceKeySize,
            [Out] out uint filePathLength);

        /// <summary>
        /// Obtains the absolute font file path from the font file reference key.
        /// </summary>
        /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the local font file
        /// within the scope of the font loader being used.</param>
        /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        /// <param name="filePath">Character array that receives the local file path.</param>
        /// <param name="filePathSize">Size of the filePath array in character count including the terminated NULL character.</param>
        void GetFilePathFromKey(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] fontFileReferenceKey,
            [In] uint fontFileReferenceKeySize,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder filePath,
            [In] uint filePathSize);

        /// <summary>
        /// Obtains the last write time of the file from the font file reference key.
        /// </summary>
        /// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the local font file
        /// within the scope of the font loader being used.</param>
        /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        /// <param name="lastWriteTime">Last modified time of the font file.</param>
        void GetLastWriteTimeFromKey(
            [In, MarshalAs(UnmanagedType.LPArray)] byte[] fontFileReferenceKey,
            [In] uint fontFileReferenceKeySize,
            [Out] out ulong lastWriteTime);
    }
}
