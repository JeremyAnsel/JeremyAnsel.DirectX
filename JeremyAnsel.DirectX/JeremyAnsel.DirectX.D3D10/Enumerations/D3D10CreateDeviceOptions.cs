// <copyright file="D3D10CreateDeviceOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    using System;

    /// <summary>
    /// Device creation options.
    /// </summary>
    [Flags]
    public enum D3D10CreateDeviceOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Use this flag if an application will only be calling D3D10 from a single thread. If this flag is not specified, the default behavior of D3D10 is to enter a lock during each API call to prevent multiple threads altering internal state. By using this flag no locks will be taken which can slightly increase performance, but could result in undefine behavior if D3D10 is called from multiple threads.
        /// </summary>
        SingleThreaded = 0x1,

        /// <summary>
        /// Create a device that supports the debug layer.
        /// </summary>
        Debug = 0x2,

        /// <summary>
        /// Create both a software (REF) and hardware (HAL) version of the device simultaneously, which allows an application to switch to a reference device to enable debugging.
        /// </summary>
        SwitchToRef = 0x4,

        /// <summary>
        /// Prevents multiple threads from being created. When this flag is used with a WARP device, no additional threads will be created by WARP and all rasterization will occur on the calling thread. This flag is not recommended for general use.
        /// </summary>
        PreventInternalThreadingOptimizations = 0x8,

        /// <summary>
        /// Return a NULL pointer instead of triggering an exception on memory exhaustion during invocations to Map. Without this flag an exception will be raised on memory exhaustion.
        /// </summary>
        AllowNullFromMap = 0x10,

        /// <summary>
        /// Causes device creation to fail if BGRA support is not available.
        /// </summary>
        BgraSupport = 0x20,

        /// <summary>
        /// Causes the Direct3D runtime to ignore registry settings that turn on the debug layer.
        /// </summary>
        PreventAlteringLayerSettingsFromRegistry = 0x0080,

        /// <summary>
        /// Reserved. This flag is currently not supported. Do not use.
        /// </summary>
        StrictValidation = 0x0200,

        /// <summary>
        /// Causes the device and driver to keep information that you can use for shader debugging. The exact impact from this flag will vary from driver to driver. To use this flag, you must have <c>D3D11_1SDKLayers.dll</c> installed; otherwise, device creation fails. The created device supports the debug layer.
        /// </summary>
        Debuggable = 0x0400,
    }
}
