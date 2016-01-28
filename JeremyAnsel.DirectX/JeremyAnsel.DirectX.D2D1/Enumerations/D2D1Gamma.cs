// <copyright file="D2D1Gamma.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies which gamma is used for interpolation.
    /// </summary>
    public enum D2D1Gamma
    {
        /// <summary>
        /// Interpolation is performed in the standard RGB (sRGB) gamma.
        /// </summary>
        Gamma22 = 0,

        /// <summary>
        /// Interpolation is performed in the linear-gamma color space.
        /// </summary>
        Gamma10 = 1,
    }
}
