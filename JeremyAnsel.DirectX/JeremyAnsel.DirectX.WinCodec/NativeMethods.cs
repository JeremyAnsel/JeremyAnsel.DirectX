// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.WinCodec;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
    public const int CLSCTX_INPROC_SERVER = 1;

#if NET8_0_OR_GREATER
    [LibraryImport("Windowscodecs.dll", EntryPoint = "WICConvertBitmapSource")]
    public static partial int WICConvertBitmapSource(
#else
    [DllImport("Windowscodecs.dll", EntryPoint = "WICConvertBitmapSource")]
    public static extern int WICConvertBitmapSource(
#endif
        in WicPixelFormatGuid dstPixelFormat,
        nint sourceBitmap,
        nint* destinationBitmap);

#if NET8_0_OR_GREATER
    [LibraryImport("Ole32.dll", EntryPoint = "CoCreateInstance")]
    public static partial int CoCreateInstance(
#else
    [DllImport("Ole32.dll", EntryPoint = "CoCreateInstance")]
    public static extern int CoCreateInstance(
#endif
        in Guid clsid,
        nint inner,
        uint context,
        in Guid uuid,
        nint* rReturnedComObject);
}
