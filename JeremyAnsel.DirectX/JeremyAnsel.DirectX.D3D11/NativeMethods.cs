// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Native methods.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
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
        [DllImport("d3d11.dll", EntryPoint = "D3D11CreateDevice", PreserveSig = false)]
        public static extern void D3D11CreateDevice(
            [In, MarshalAs(UnmanagedType.IUnknown)] object? adapter,
            [In] D3D11DriverType driverType,
            [In] IntPtr software,
            [In] D3D11CreateDeviceOptions options,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11FeatureLevel[]? featureLevels,
            [In] uint numFeatureLevels,
            [In] uint sdkVersion,
            [Out] out ID3D11Device? device,
            [Out] out D3D11FeatureLevel featureLevel,
            [Out] out ID3D11DeviceContext? immediateContext);

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
        [DllImport("d3d11.dll", EntryPoint = "D3D11CreateDeviceAndSwapChain", PreserveSig = false)]
        public static extern void D3D11CreateDeviceAndSwapChain(
            [In, MarshalAs(UnmanagedType.IUnknown)] object? adapter,
            [In] D3D11DriverType driverType,
            [In] IntPtr software,
            [In] D3D11CreateDeviceOptions options,
            [In, MarshalAs(UnmanagedType.LPArray)] D3D11FeatureLevel[]? featureLevels,
            [In] uint numFeatureLevels,
            [In] uint sdkVersion,
            [In] ref DxgiSwapChainDesc swapChainDesc,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object? swapChain,
            [Out] out ID3D11Device? device,
            [Out] out D3D11FeatureLevel featureLevel,
            [Out] out ID3D11DeviceContext? immediateContext);
    }
}
