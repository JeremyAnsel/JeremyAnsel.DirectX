// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
    /// <summary>
    /// Creates a device that represents the display adapter.
    /// </summary>
    /// <param name="adapter">A pointer to the video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="software">A handle to a DLL that implements a software rasterizer.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <param name="numFeatureLevels">The number of elements in <paramref name="featureLevels"/>.</param>
    /// <param name="sdkVersion">The SDK version.</param>
    /// <param name="device">The created device.</param>
    /// <param name="featureLevel">If successful, returns the first feature level from the <paramref name="featureLevels"/> array which succeeded.</param>
    /// <param name="immediateContext">The device context.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("d3d11.dll", EntryPoint = "D3D11CreateDevice")]
    public static partial int D3D11CreateDevice(
#else
    [DllImport("d3d11.dll", EntryPoint = "D3D11CreateDevice")]
    public static extern int D3D11CreateDevice(
#endif
        nint adapter,
        D3D11DriverType driverType,
        nint software,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel* featureLevels,
        uint numFeatureLevels,
        uint sdkVersion,
        nint* device,
        D3D11FeatureLevel* featureLevel,
        nint* immediateContext);

    /// <summary>
    /// Creates a device that represents the display adapter and a swap chain used for rendering.
    /// </summary>
    /// <param name="adapter">The video adapter to use when creating a device.</param>
    /// <param name="driverType">The driver type to create.</param>
    /// <param name="software">A handle to a DLL that implements a software rasterizer.</param>
    /// <param name="options">The runtime layers to enable.</param>
    /// <param name="featureLevels">Determine the order of feature levels to attempt to create.</param>
    /// <param name="numFeatureLevels">The number of elements in <paramref name="featureLevels"/>.</param>
    /// <param name="sdkVersion">The SDK version.</param>
    /// <param name="swapChainDesc">A swap chain description that contains initialization parameters for the swap chain.</param>
    /// <param name="swapChain">The swap chain used for rendering.</param>
    /// <param name="device">The created device.</param>
    /// <param name="featureLevel">If successful, returns the first feature level from the <paramref name="featureLevels"/> array which succeeded.</param>
    /// <param name="immediateContext">The device context.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("d3d11.dll", EntryPoint = "D3D11CreateDeviceAndSwapChain")]
    public static partial int D3D11CreateDeviceAndSwapChain(
#else
    [DllImport("d3d11.dll", EntryPoint = "D3D11CreateDeviceAndSwapChain")]
    public static extern int D3D11CreateDeviceAndSwapChain(
#endif
        nint adapter,
        D3D11DriverType driverType,
        nint software,
        D3D11CreateDeviceOptions options,
        D3D11FeatureLevel* featureLevels,
        uint numFeatureLevels,
        uint sdkVersion,
        void* swapChainDesc,
        nint* swapChain,
        nint* device,
        D3D11FeatureLevel* featureLevel,
        nint* immediateContext);
}
