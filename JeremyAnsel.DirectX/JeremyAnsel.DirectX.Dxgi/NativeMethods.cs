// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// Native methods.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        /// <summary>
        /// Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <param name="riid">The globally unique identifier (GUID) of the <c>IDXGIFactory</c> object</param>
        /// <param name="factory">Address of a pointer to an <c>IDXGIFactory</c> object.</param>
        [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory", PreserveSig = false)]
        public static extern void CreateDxgiFactory(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out] out IDxgiFactory? factory);

        /// <summary>
        /// Creates a DXGI 1.1 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <param name="riid">The globally unique identifier (GUID) of the <c>IDXGIFactory1</c> object</param>
        /// <param name="factory">Address of a pointer to an <c>IDXGIFactory1</c> object.</param>
        [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory1", PreserveSig = false)]
        public static extern void CreateDxgiFactory1(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out] out IDxgiFactory1? factory);

        /// <summary>
        /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
        /// </summary>
        /// <param name="options">The creation options.</param>
        /// <param name="riid">The globally unique identifier (GUID) of the <c>IDXGIFactory2</c> object</param>
        /// <param name="factory">Address of a pointer to an <c>IDXGIFactory2</c> object.</param>
        [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory2", PreserveSig = false)]
        public static extern void CreateDxgiFactory2(
            [In] DxgiCreateFactoryOptions options,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [Out] out IDxgiFactory2? factory);
    }
}
