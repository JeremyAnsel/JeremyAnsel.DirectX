// <copyright file="IDWriteFontCollection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteFontCollection encapsulates a collection of fonts.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("a84cee02-3eea-4eee-a827-87c1a02a0fcc")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteFontCollection
    {
        /// <summary>
        /// Gets the number of font families in the collection.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetFontFamilyCount();

        /// <summary>
        /// Creates a font family object given a zero-based font family index.
        /// </summary>
        /// <param name="index">Zero-based index of the font family.</param>
        /// <param name="fontFamily">Receives a pointer the newly created font family object.</param>
        void GetFontFamily(
            [In] uint index,
            [Out] out IDWriteFontFamily fontFamily);

        /// <summary>
        /// Finds the font family with the specified family name.
        /// </summary>
        /// <param name="familyName">Name of the font family. The name is not case-sensitive but must otherwise exactly match a family name in the collection.</param>
        /// <param name="index">Receives the zero-based index of the matching font family if the family name was found or UINT_MAX otherwise.</param>
        /// <param name="exists">Receives TRUE if the family name exists or FALSE otherwise.</param>
        /// <remarks>
        /// If the specified family name does not exist, the return value is S_OK, but *index is UINT_MAX and *exists is FALSE.
        /// </remarks>
        void FindFontFamily(
            [In, MarshalAs(UnmanagedType.LPWStr)] string familyName,
            [Out] out uint index,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool exists);

        /// <summary>
        /// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical font must belong 
        /// to the font collection.
        /// </summary>
        /// <param name="fontFace">Font face object that specifies the physical font.</param>
        /// <param name="font">Receives a pointer to the newly created font object if successful or NULL otherwise.</param>
        /// <remarks>
        /// If the specified physical font is not part of the font collection the return value is DWRITE_E_NOFONT.
        /// </remarks>
        void GetFontFromFontFace(
            [In] IDWriteFontFace fontFace,
            [Out] out IDWriteFont font);
    }
}
