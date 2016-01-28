// <copyright file="DxgiModeScanlineOrder.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    /// <summary>
    /// Indicate the method the raster uses to create an image on a surface.
    /// </summary>
    public enum DxgiModeScanlineOrder
    {
        /// <summary>
        /// Scanline order is unspecified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The image is created from the first scanline to the last without skipping any.
        /// </summary>
        Progressive,

        /// <summary>
        /// The image is created beginning with the upper field.
        /// </summary>
        UpperFieldFirst,

        /// <summary>
        /// The image is created beginning with the lower field.
        /// </summary>
        LowerFieldFirst
    }
}
