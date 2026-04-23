// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D10;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
#if NET8_0_OR_GREATER
    [LibraryImport("D3D10_1.dll", EntryPoint = "D3D10CreateDevice1")]
    public static partial int D3D10CreateDevice1(
#else
    [DllImport("D3D10_1.dll", EntryPoint = "D3D10CreateDevice1")]
    public static extern int D3D10CreateDevice1(
#endif
        nint adapter,
        D3D10DriverType driverType,
        nint software,
        D3D10CreateDeviceOptions options,
        D3D10FeatureLevel featureLevel,
        uint sdkVersion,
        nint* device);
}
