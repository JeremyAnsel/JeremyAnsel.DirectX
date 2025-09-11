// <copyright file="IDWriteFontList.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteFontList interface represents a list of fonts.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("1a0d8438-1d97-4ec1-aef9-a2fb86ed6acb")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteFontList
    {
        /// <summary>
        /// Gets the font collection that contains the fonts.
        /// </summary>
        /// <param name="fontCollection">Receives a pointer to the font collection object.</param>
        void GetFontCollection(
            [Out] out IDWriteFontCollection? fontCollection);

        /// <summary>
        /// Gets the number of fonts in the font list.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetFontCount();

        /// <summary>
        /// Gets a font given its zero-based index.
        /// </summary>
        /// <param name="index">Zero-based index of the font in the font list.</param>
        /// <param name="font">Receives a pointer to the newly created font object.</param>
        void GetFont(
            [In] uint index,
            [Out] out IDWriteFont? font);
    }
}
