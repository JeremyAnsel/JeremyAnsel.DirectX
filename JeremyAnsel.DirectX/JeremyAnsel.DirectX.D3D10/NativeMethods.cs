// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.D3D10.ComInterfaces;

    /// <summary>
    /// Native methods.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        [DllImport("D3D10_1.dll", EntryPoint = "D3D10CreateDevice1", PreserveSig = false)]
        public static extern void D3D10CreateDevice1(
            [In, MarshalAs(UnmanagedType.IUnknown)] object adapter,
            [In] D3D10DriverType driverType,
            [In] IntPtr software,
            [In] D3D10CreateDeviceOptions options,
            [In] D3D10FeatureLevel featureLevel,
            [In] uint sdkVersion,
            [Out] out ID3D10Device1 device);
    }
}
