// <copyright file="D3D10DriverType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    /// <summary>
    /// The device-driver type.
    /// </summary>
    public enum D3D10DriverType
    {
        /// <summary>
        /// A hardware device; commonly called a HAL device.
        /// </summary>
        Hardware = 0,

        /// <summary>
        /// A reference device; commonly called a REF device.
        /// </summary>
        Reference = 1,

        /// <summary>
        /// A NULL device; which is a reference device without render capability.
        /// </summary>
        Null = 2,

        /// <summary>
        /// Reserved for later use.
        /// </summary>
        Software = 3,

        /// <summary>
        /// A WARP driver, which is a high-performance software rasterizer. The rasterizer supports feature level 9_1 through level 10.1 with a high performance software implementation when hardware is not available.
        /// </summary>
        Warp = 5,
    }
}
