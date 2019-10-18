// <copyright file="IDWriteFontFileEnumerator.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The font file enumerator interface encapsulates a collection of font files. The font system uses this interface
    /// to enumerate font files when building a font collection.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("72755049-5ff7-435d-8348-4be97cfa6c7c")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteFontFileEnumerator
    {
        /// <summary>
        /// Advances to the next font file in the collection. When it is first created, the enumerator is positioned
        /// before the first element of the collection and the first call to MoveNext advances to the first file.
        /// </summary>
        /// <param name="hasCurrentFile">Receives the value TRUE if the enumerator advances to a file, or FALSE if
        /// the enumerator advanced past the last file in the collection.</param>
        void MoveNext(
            [Out, MarshalAs(UnmanagedType.Bool)] out bool hasCurrentFile);

        /// <summary>
        /// Gets a reference to the current font file.
        /// </summary>
        /// <param name="fontFile">Pointer to the newly created font file object.</param>
        void GetCurrentFontFile(
            [Out] out IDWriteFontFile fontFile);
    }
}
