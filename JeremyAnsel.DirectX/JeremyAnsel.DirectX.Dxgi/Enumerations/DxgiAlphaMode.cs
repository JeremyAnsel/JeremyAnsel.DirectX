// <copyright file="DxgiAlphaMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Identifies the alpha value, transparency behavior, of a surface.
    /// </summary>
    public enum DxgiAlphaMode
    {
        /// <summary>
        /// Indicates that the transparency behavior is not specified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// Indicates that the transparency behavior is pre-multiplied. Each color is first scaled by the alpha value. The alpha value itself is the same in both straight and pre-multiplied alpha. Typically, no color channel value is greater than the alpha channel value. If a color channel value in a pre-multiplied format is greater than the alpha channel, the standard source-over blending math results in an additive blend.
        /// </summary>
        Premultiplied,
        
        /// <summary>
        /// Indicates that the transparency behavior is not pre-multiplied. The alpha channel indicates the transparency of the color.
        /// </summary>
        Straight,

        /// <summary>
        /// Indicates to ignore the transparency behavior.
        /// </summary>
        Ignore
    }
}
