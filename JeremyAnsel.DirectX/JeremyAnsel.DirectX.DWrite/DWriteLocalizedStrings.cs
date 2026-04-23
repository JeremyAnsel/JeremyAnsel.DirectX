// <copyright file="DWriteLocalizedStrings.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// Represents a collection of strings indexed by locale name.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteLocalizedStrings : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteLocalizedStringsGuid = typeof(IDWriteLocalizedStrings).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteLocalizedStrings* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteLocalizedStrings"/> class.
    /// </summary>
    public DWriteLocalizedStrings(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteLocalizedStrings**)comPtr;
    }

    /// <summary>
    /// Gets the number of language/string pairs.
    /// </summary>
    /// <returns><see cref="uint"/></returns>
    public uint GetCount()
    {
        return _comImpl->GetCount(_comPtr);
    }

    /// <summary>
    /// Gets the index of the item with the specified locale name.
    /// </summary>
    /// <param name="localeName">Locale name to look for.</param>
    /// <returns>Receives the zero-based index of the locale name/string pair.</returns>
    public uint FindLocaleName(string localeName)
    {
        return FindLocaleName(localeName.AsSpan());
    }

    /// <summary>
    /// Gets the index of the item with the specified locale name.
    /// </summary>
    /// <param name="localeName">Locale name to look for.</param>
    /// <returns>Receives the zero-based index of the locale name/string pair.</returns>
    public uint FindLocaleName(ReadOnlySpan<char> localeName)
    {
        uint index;
        int exists;
        fixed (char* ptr = localeName)
        {
            int hr = _comImpl->FindLocaleName(_comPtr, ptr, &index, &exists);
            Marshal.ThrowExceptionForHR(hr);
        }
        return index;
    }

    /// <summary>
    /// Gets the length in characters (not including the null terminator) of the locale name with the specified index.
    /// </summary>
    /// <param name="index">Zero-based index of the locale name.</param>
    /// <returns>Receives the length in characters, not including the null terminator.</returns>
    public uint GetLocaleNameLength(uint index)
    {
        uint length;
        int hr = _comImpl->GetLocaleNameLength(_comPtr, index, &length);
        Marshal.ThrowExceptionForHR(hr);
        return length;
    }

    /// <summary>
    /// Copies the locale name with the specified index to the specified array.
    /// </summary>
    /// <param name="index">Zero-based index of the locale name.</param>
    /// <returns><see cref="string"/></returns>
    public string GetLocaleName(uint index)
    {
        uint length = GetLocaleNameLength(index) + 1;
        char* ptr = stackalloc char[(int)length];
        int hr = _comImpl->GetLocaleName(_comPtr, index, ptr, length);
        Marshal.ThrowExceptionForHR(hr);
        return new string(ptr, 0, (int)length - 1);
    }

    /// <summary>
    /// Copies the locale name with the specified index to the specified array.
    /// </summary>
    /// <param name="index">Zero-based index of the locale name.</param>
    /// <param name="name">The locale name.</param>
    public void GetLocaleName(uint index, Span<char> name)
    {
        fixed (char* ptr = name)
        {
            int hr = _comImpl->GetLocaleName(_comPtr, index, ptr, (uint)name.Length);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Gets the length in characters (not including the null terminator) of the string with the specified index.
    /// </summary>
    /// <param name="index">Zero-based index of the string.</param>
    /// <returns>Receives the length in characters, not including the null terminator.</returns>
    public uint GetStringLength(uint index)
    {
        uint length;
        int hr = _comImpl->GetStringLength(_comPtr, index, &length);
        Marshal.ThrowExceptionForHR(hr);
        return length;
    }

    /// <summary>
    /// Copies the string with the specified index to the specified array.
    /// </summary>
    /// <param name="index">Zero-based index of the string.</param>
    /// <returns><see cref="string"/></returns>
    public string GetString(uint index)
    {
        uint length = GetStringLength(index) + 1;
        char* ptr = stackalloc char[(int)length];
        int hr = _comImpl->GetString(_comPtr, index, ptr, length);
        Marshal.ThrowExceptionForHR(hr);
        return new string(ptr, 0, (int)length - 1);
    }

    /// <summary>
    /// Copies the string with the specified index to the specified array.
    /// </summary>
    /// <param name="index">Zero-based index of the string.</param>
    /// <param name="str">The string.</param>
    public void GetString(uint index, Span<char> str)
    {
        fixed (char* ptr = str)
        {
            int hr = _comImpl->GetString(_comPtr, index, ptr, (uint)str.Length);
            Marshal.ThrowExceptionForHR(hr);
        }
    }
}
