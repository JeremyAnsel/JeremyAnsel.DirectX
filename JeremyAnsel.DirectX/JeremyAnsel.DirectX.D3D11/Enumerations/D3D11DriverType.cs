// <copyright file="D3D11DriverType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Driver type options.
    /// </summary>
    public enum D3D11DriverType
    {
        /// <summary>
        /// The driver type is unknown.
        /// </summary>
        Unknown,

        /// <summary>
        /// A hardware driver, which implements Direct3D features in hardware. This is the primary driver that you should use in your Direct3D applications because it provides the best performance. A hardware driver uses hardware acceleration (on supported hardware) but can also use software for parts of the pipeline that are not supported in hardware. This driver type is often referred to as a hardware abstraction layer or HAL.
        /// </summary>
        Hardware,

        /// <summary>
        /// A reference driver, which is a software implementation that supports every Direct3D feature. A reference driver is designed for accuracy rather than speed and as a result is slow but accurate. The rasterizer portion of the driver does make use of special CPU instructions whenever it can, but it is not intended for retail applications; use it only for feature testing, demonstration of functionality, debugging, or verifying bugs in other drivers.
        /// </summary>
        Reference,

        /// <summary>
        /// A NULL driver, which is a reference driver without render capability. This driver is commonly used for debugging non-rendering API calls, it is not appropriate for retail applications.
        /// </summary>
        Null,

        /// <summary>
        /// A software driver, which is a driver implemented completely in software. The software implementation is not intended for a high-performance application due to its very slow performance.
        /// </summary>
        Software,

        /// <summary>
        /// A WARP driver, which is a high-performance software rasterizer.
        /// </summary>
        Warp
    }
}
