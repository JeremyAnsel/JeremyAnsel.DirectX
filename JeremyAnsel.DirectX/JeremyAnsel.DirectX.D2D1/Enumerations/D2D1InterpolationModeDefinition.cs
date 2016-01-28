// <copyright file="D2D1InterpolationModeDefinition.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// This defines the superset of interpolation mode supported by D2D APIs
    /// and built-in effects
    /// </summary>
    public enum D2D1InterpolationModeDefinition
    {
        /// <summary>
        /// Samples the nearest single point and uses that exact color. This mode uses less processing time, but outputs the lowest quality image.
        /// </summary>
        NearestNeighbor = 0,

        /// <summary>
        /// Uses a four point sample and linear interpolation. This mode uses more processing time than the nearest neighbor mode, but outputs a higher quality image.
        /// </summary>
        Linear = 1,

        /// <summary>
        /// Uses a 16 sample cubic kernel for interpolation. This mode uses the most processing time, but outputs a higher quality image.
        /// </summary>
        Cubic = 2,

        /// <summary>
        /// Uses 4 linear samples within a single pixel for good edge anti-aliasing. This mode is good for scaling down by small amounts on images with few pixels.
        /// </summary>
        MultiSampleLinear = 3,

        /// <summary>
        /// Uses anisotropic filtering to sample a pattern according to the transformed shape of the bitmap.
        /// </summary>
        Anisotropic = 4,

        /// <summary>
        /// Uses a variable size high quality cubic kernel to perform a pre-downscale the image if downscaling is involved in the transform matrix. Then uses the cubic interpolation mode for the final output.
        /// </summary>
        HighQualityCubic = 5,

        /// <summary>
        /// Fant interpolation mode.
        /// </summary>
        Fant = 6,

        /// <summary>
        /// Mipmap Linear interpolation mode.
        /// </summary>
        MipmapLinear = 7
    }
}
