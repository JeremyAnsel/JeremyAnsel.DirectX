// <copyright file="IDWriteGdiInterop.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The GDI interop interface provides interoperability with GDI.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("1edd9491-9853-4299-898f-6432983b6f3a")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteGdiInterop
    {
        /// <summary>
        /// Creates a font object that matches the properties specified by the LOGFONT structure.
        /// </summary>
        /// <param name="logFont">Structure containing a GDI-compatible font description.</param>
        /// <param name="font">Receives a newly created font object if successful, or NULL in case of error.</param>
        void CreateFontFromLogFont(
            [In] IntPtr logFont,
            [Out] out IDWriteFont font);

        /// <summary>
        /// Initializes a LOGFONT structure based on the GDI-compatible properties of the specified font.
        /// </summary>
        /// <param name="font">Specifies a font in the system font collection.</param>
        /// <param name="logFont">Structure that receives a GDI-compatible font description.</param>
        /// <param name="isSystemFont">Contains TRUE if the specified font object is part of the system font collection
        /// or FALSE otherwise.</param>
        void ConvertFontToLogFont(
            [In] IDWriteFont font,
            [Out] IntPtr logFont,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isSystemFont);

        /// <summary>
        /// Initializes a LOGFONT structure based on the GDI-compatible properties of the specified font.
        /// </summary>
        /// <param name="font">Specifies a font face.</param>
        /// <param name="logFont">Structure that receives a GDI-compatible font description.</param>
        void ConvertFontFaceToLogFont(
            [In] IDWriteFontFace font,
            [Out] IntPtr logFont);

        /// <summary>
        /// Creates a font face object that corresponds to the currently selected HFONT.
        /// </summary>
        /// <param name="hdc">Handle to a device context into which a font has been selected. It is assumed that the client
        /// has already performed font mapping and that the font selected into the DC is the actual font that would be used 
        /// for rendering glyphs.</param>
        /// <param name="fontFace">Contains the newly created font face object, or NULL in case of failure.</param>
        void CreateFontFaceFromHdc(
            [In] IntPtr hdc,
            [Out] out IDWriteFontFace fontFace);

        /// <summary>
        /// Creates an object that encapsulates a bitmap and memory DC which can be used for rendering glyphs.
        /// </summary>
        /// <param name="hdc">Optional device context used to create a compatible memory DC.</param>
        /// <param name="width">Width of the bitmap.</param>
        /// <param name="height">Height of the bitmap.</param>
        /// <param name="renderTarget">Receives a pointer to the newly created render target.</param>
        void CreateBitmapRenderTarget(
            [In] IntPtr hdc,
            [In] uint width,
            [In] uint height,
            [Out] out IDWriteBitmapRenderTarget renderTarget);
    }
}
