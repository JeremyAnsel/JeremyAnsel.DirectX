// <copyright file="IDWriteLocalizedStrings.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// Represents a collection of strings indexed by locale name.
/// </summary>
[Guid("08256209-099a-4b34-b86d-c22b110e7771")]
internal unsafe readonly struct IDWriteLocalizedStrings
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Gets the number of language/string pairs.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetCount;

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
    public readonly delegate* unmanaged[Stdcall]<nint, char*, uint*, int*, int> FindLocaleName;

    /// <summary>
    /// Gets the length in characters (not including the null terminator) of the locale name with the specified index.
    /// </summary>
    /// <param name="index">Zero-based index of the locale name.</param>
    /// <param name="length">Receives the length in characters, not including the null terminator.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, int> GetLocaleNameLength;

    /// <summary>
    /// Copies the locale name with the specified index to the specified array.
    /// </summary>
    /// <param name="index">Zero-based index of the locale name.</param>
    /// <param name="localeName">Character array that receives the locale name.</param>
    /// <param name="size">Size of the array in characters. The size must include space for the terminating
    /// null character.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint, int> GetLocaleName;

    /// <summary>
    /// Gets the length in characters (not including the null terminator) of the string with the specified index.
    /// </summary>
    /// <param name="index">Zero-based index of the string.</param>
    /// <param name="length">Receives the length in characters, not including the null terminator.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint*, int> GetStringLength;

    /// <summary>
    /// Copies the string with the specified index to the specified array.
    /// </summary>
    /// <param name="index">Zero-based index of the string.</param>
    /// <param name="stringBuffer">Character array that receives the string.</param>
    /// <param name="size">Size of the array in characters. The size must include space for the terminating
    /// null character.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, char*, uint, int> GetString;
}
