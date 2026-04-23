// <copyright file="NativeMethods.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Native methods.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
internal static unsafe partial class NativeMethods
{
    /// <summary>
    /// Creates a DXGI 1.0 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <param name="riid">The globally unique identifier (GUID) of the <c>IDXGIFactory</c> object</param>
    /// <param name="factory">Address of a pointer to an <c>IDXGIFactory</c> object.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("dxgi.dll", EntryPoint = "CreateDXGIFactory")]
    public static partial int CreateDxgiFactory(in Guid riid, nint* factory);
#else
    [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory")]
    public static extern int CreateDxgiFactory(in Guid riid, nint* factory);
#endif

    /// <summary>
    /// Creates a DXGI 1.1 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <param name="riid">The globally unique identifier (GUID) of the <c>IDXGIFactory1</c> object</param>
    /// <param name="factory">Address of a pointer to an <c>IDXGIFactory1</c> object.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("dxgi.dll", EntryPoint = "CreateDXGIFactory1")]
    public static partial int CreateDxgiFactory1(in Guid riid, nint* factory);
#else
    [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory1")]
    public static extern int CreateDxgiFactory1(in Guid riid, nint* factory);
#endif

    /// <summary>
    /// Creates a DXGI 1.3 factory that you can use to generate other DXGI objects.
    /// </summary>
    /// <param name="options">The creation options.</param>
    /// <param name="riid">The globally unique identifier (GUID) of the <c>IDXGIFactory2</c> object</param>
    /// <param name="factory">Address of a pointer to an <c>IDXGIFactory2</c> object.</param>
#if NET8_0_OR_GREATER
    [LibraryImport("dxgi.dll", EntryPoint = "CreateDXGIFactory2")]
    public static partial int CreateDxgiFactory2(DxgiCreateFactoryOptions options, in Guid riid, nint* factory);
#else
    [DllImport("dxgi.dll", EntryPoint = "CreateDXGIFactory2")]
    public static extern int CreateDxgiFactory2(DxgiCreateFactoryOptions options, in Guid riid, nint* factory);
#endif
}
