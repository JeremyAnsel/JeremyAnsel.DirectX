// <copyright file="D2D1OpacityMaskContent.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes whether an opacity mask contains graphics or text. Direct2D uses this information to determine which gamma space to use when blending the opacity mask.
    /// </summary>
    public enum D2D1OpacityMaskContent
    {
        /// <summary>
        /// The opacity mask contains graphics. The opacity mask is blended in the gamma 2.2 color space.
        /// </summary>
        Graphics = 0,

        /// <summary>
        /// The opacity mask contains non-GDI text. The gamma space used for blending is obtained from the render target's text rendering parameters.
        /// </summary>
        TextNatural = 1,

        /// <summary>
        /// The opacity mask contains text rendered using the GDI-compatible rendering mode. The opacity mask is blended using the gamma for GDI rendering.
        /// </summary>
        TextGdiCompatible = 2,
    }
}
