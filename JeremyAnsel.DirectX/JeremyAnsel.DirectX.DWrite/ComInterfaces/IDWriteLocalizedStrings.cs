// <copyright file="IDWriteLocalizedStrings.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    /// <summary>
    /// Represents a collection of strings indexed by locale name.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("08256209-099a-4b34-b86d-c22b110e7771")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteLocalizedStrings
    {
        /// <summary>
        /// Gets the number of language/string pairs.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [PreserveSig]
        uint GetCount();

        /// <summary>
        /// Gets the index of the item with the specified locale name.
        /// </summary>
        /// <param name="localeName">Locale name to look for.</param>
        /// <param name="index">Receives the zero-based index of the locale name/string pair.</param>
        /// <param name="exists">Receives TRUE if the locale name exists or FALSE if not.</param>
        /// <remarks>
        /// If the specified locale name does not exist, the return value is S_OK, 
        /// but *index is UINT_MAX and *exists is FALSE.
        /// </remarks>
        void FindLocaleName(
            [In, MarshalAs(UnmanagedType.LPWStr)] string? localeName,
            [Out] out uint index,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool exists);

        /// <summary>
        /// Gets the length in characters (not including the null terminator) of the locale name with the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the locale name.</param>
        /// <param name="length">Receives the length in characters, not including the null terminator.</param>
        void GetLocaleNameLength(
            [In] uint index,
            [Out] out uint length);

        /// <summary>
        /// Copies the locale name with the specified index to the specified array.
        /// </summary>
        /// <param name="index">Zero-based index of the locale name.</param>
        /// <param name="localeName">Character array that receives the locale name.</param>
        /// <param name="size">Size of the array in characters. The size must include space for the terminating
        /// null character.</param>
        void GetLocaleName(
            [In] uint index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? localeName,
            [In] uint size);

        /// <summary>
        /// Gets the length in characters (not including the null terminator) of the string with the specified index.
        /// </summary>
        /// <param name="index">Zero-based index of the string.</param>
        /// <param name="length">Receives the length in characters, not including the null terminator.</param>
        void GetStringLength(
            [In] uint index,
            [Out] out uint length);

        /// <summary>
        /// Copies the string with the specified index to the specified array.
        /// </summary>
        /// <param name="index">Zero-based index of the string.</param>
        /// <param name="stringBuffer">Character array that receives the string.</param>
        /// <param name="size">Size of the array in characters. The size must include space for the terminating
        /// null character.</param>
        void GetString(
            [In] uint index,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder? stringBuffer,
            [In] uint size);
    }
}
