// <copyright file="DXUtils.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DXCommon.ComInterfaces;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DXCommon;

/// <summary>
/// Utility methods.
/// </summary>
public unsafe static class DXUtils
{
    /// <summary>
    /// Immediately releases the unmanaged resources.
    /// </summary>
    /// <typeparam name="T">A releasable type.</typeparam>
    /// <param name="o">The object.</param>
    public static void DisposeAndNull<T>(ref T? o) where T : class, IDisposable
    {
        if (o is not null)
        {
            o.Dispose();
            o = null;
        }
    }

    /// <summary>
    /// Immediately releases the unmanaged resources.
    /// </summary>
    /// <typeparam name="T">A releasable type.</typeparam>
    /// <param name="array">The objects.</param>
    public static void DisposeAndNull<T>(T?[]? array) where T : class, IDisposable
    {
        if (array is null)
        {
            return;
        }

        for (int i = 0; i < array.Length; i++)
        {
            DisposeAndNull(ref array[i]);
        }
    }

    /// <summary>
    /// Immediately releases the unmanaged resources.
    /// </summary>
    /// <typeparam name="T">A releasable type.</typeparam>
    /// <param name="array">The objects.</param>
    public static void DisposeAndNull<T>(Span<T?> array) where T : class, IDisposable
    {
        for (int i = 0; i < array.Length; i++)
        {
            DisposeAndNull(ref array[i]);
        }
    }

    /// <summary>
    /// Add reference to COM object.
    /// </summary>
    /// <param name="comPtr">The com interface.</param>
    /// <returns>The reference count.</returns>
    public static int AddRef(nint comPtr)
    {
        if (comPtr == 0)
        {
            return 0;
        }

        IDXUnknown* comImpl = *(IDXUnknown**)comPtr;
        return comImpl->AddRef(comPtr);
    }

    /// <summary>
    /// Release a COM object.
    /// </summary>
    /// <param name="comPtr">The com interface.</param>
    /// <returns>The reference count.</returns>
    public static int Release(nint comPtr)
    {
        if (comPtr == 0)
        {
            return 0;
        }

        IDXUnknown* comImpl = *(IDXUnknown**)comPtr;
        return comImpl->Release(comPtr);
    }

    /// <summary>
    /// Query a COM interface.
    /// </summary>
    /// <param name="comPtr">The com interface.</param>
    /// <param name="iid">The GUID identifier of the interface.</param>
    /// <returns>The interface pointer.</returns>
    public static nint QueryInterface(nint comPtr, in Guid iid)
    {
        if (comPtr == 0)
        {
            throw new ArgumentNullException(nameof(comPtr));
        }

        IDXUnknown* comImpl = *(IDXUnknown**)comPtr;
        nint ptr = 0;
        int hr = comImpl->QueryInterface(comPtr, in iid, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filesize"></param>
    /// <returns></returns>
    public unsafe static string StrFormatByteSize(long filesize)
    {
        char* buffer = stackalloc char[32];
        NativeMethods.StrFormatByteSize(filesize, buffer, 32);
        var s = new string(buffer);
        return s;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="filesize"></param>
    /// <param name="buffer"></param>
    public unsafe static void StrFormatByteSize(long filesize, Span<char> buffer)
    {
        fixed (char* ptr = buffer)
        {
            NativeMethods.StrFormatByteSize(filesize, ptr, 32);
        }
    }
}
