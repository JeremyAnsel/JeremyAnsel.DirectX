// <copyright file="IDWriteFontFile.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The interface that represents a reference to a font file.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("739d886a-cef5-47dc-8769-1a8b41bebbb0")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteFontFile
    {
        /// <summary>
        /// This method obtains the pointer to the reference key of a font file. The pointer is only valid until the object that refers to it is released.
        /// </summary>
        /// <param name="fontFileReferenceKey">Pointer to the font file reference key.
        /// IMPORTANT: The pointer value is valid until the font file reference object it is obtained from is released.</param>
        /// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        void GetReferenceKey(
            [Out] out IntPtr fontFileReferenceKey,
            [Out] out uint fontFileReferenceKeySize);

        /// <summary>
        /// Obtains the file loader associated with a font file object.
        /// </summary>
        /// <param name="fontFileLoader">The font file loader associated with the font file object.</param>
        void GetLoader(
            [Out] out IDWriteFontFileLoader fontFileLoader);

        /// <summary>
        /// Analyzes a file and returns whether it represents a font, and whether the font type is supported by the font system.
        /// </summary>
        /// <param name="isSupportedFontType">TRUE if the font type is supported by the font system, FALSE otherwise.</param>
        /// <param name="fontFileType">The type of the font file. Note that even if isSupportedFontType is FALSE,
        /// the fontFileType value may be different from DWRITE_FONT_FILE_TYPE_UNKNOWN.</param>
        /// <param name="fontFaceType">The type of the font face that can be constructed from the font file.
        /// Note that even if isSupportedFontType is FALSE, the fontFaceType value may be different from
        /// DWRITE_FONT_FACE_TYPE_UNKNOWN.</param>
        /// <param name="numberOfFaces">Number of font faces contained in the font file.</param>
        /// <remarks>
        /// IMPORTANT: certain font file types are recognized, but not supported by the font system.
        /// For example, the font system will recognize a file as a Type 1 font file,
        /// but will not be able to construct a font face object from it. In such situations, Analyze will set
        /// isSupportedFontType output parameter to FALSE.
        /// </remarks>
        void Analyse(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isSupportedFontType,
            [Out] out DWriteFontFileType fontFileType,
            [Out] out DWriteFontFaceType fontFaceType,
            [Out] out uint numberOfFaces);
    }
}
