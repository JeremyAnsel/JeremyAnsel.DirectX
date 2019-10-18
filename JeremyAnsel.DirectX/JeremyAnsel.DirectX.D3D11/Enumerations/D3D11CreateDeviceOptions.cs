// <copyright file="D3D11CreateDeviceOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Describes parameters that are used to create a device.
    /// </summary>
    [Flags]
    public enum D3D11CreateDeviceOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Use this flag if your application will only call methods of Direct3D 11 interfaces from a single thread. By default, the <see cref="D3D11Device"/> object is thread-safe.
        /// </summary>
        SingleThreaded = 0x1,

        /// <summary>
        /// Creates a device that supports the debug layer.
        /// </summary>
        Debug = 0x2,

        /// <summary>
        /// This flag is not supported in Direct3D 11.
        /// </summary>
        SwitchToRef = 0x4,

        /// <summary>
        /// Prevents multiple threads from being created.
        /// </summary>
        PreventInternalThreadingOptimizations = 0x8,

        /// <summary>
        /// Required for Direct2D interoperability with Direct3D resources.
        /// </summary>
        BgraSupport = 0x20,

        /// <summary>
        /// Causes the device and driver to keep information that you can use for shader debugging. The exact impact from this flag will vary from driver to driver.
        /// </summary>
        Debuggable = 0x40,

        /// <summary>
        /// Causes the Direct3D runtime to ignore registry settings that turn on the debug layer.
        /// </summary>
        PreventAlteringLayerSettingsFromRegistry = 0x0080,

        /// <summary>
        /// Use this flag if the device will produce GPU workloads that take more than two seconds to complete, and you want the operating system to allow them to successfully finish. 
        /// </summary>
        DisableGpuTimeout = 0x0100,

        /// <summary>
        /// Forces the creation of the Direct3D device to fail if the display driver is not implemented to the WDDM.
        /// </summary>
        VideoSupport = 0x0800,
    }
}
