// <copyright file="D3D11ShaderMinPrecisionSupports.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Values that specify minimum precision levels at shader stages.
    /// </summary>
    [Flags]
    public enum D3D11ShaderMinPrecisionSupports
    {
        /// <summary>
        /// No option. Only full 32-bit precision.
        /// </summary>
        None = 0,

        /// <summary>
        /// Minimum precision level is 10-bit.
        /// </summary>
        TenBit = 0x1,

        /// <summary>
        /// Minimum precision level is 16-bit.
        /// </summary>
        SixteenBit = 0x2
    }
}
