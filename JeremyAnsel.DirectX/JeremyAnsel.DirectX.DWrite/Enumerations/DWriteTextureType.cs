// <copyright file="DWriteTextureType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// Identifies a type of alpha texture. An alpha texture is a bitmap of alpha values, each
    /// representing the darkness (i.e., opacity) of a pixel or subpixel.
    /// </summary>
    public enum DWriteTextureType
    {
        /// <summary>
        /// Specifies an alpha texture for aliased text rendering (i.e., bi-level, where each pixel is either fully opaque or fully transparent),
        /// with one byte per pixel.
        /// </summary>
        Aliased1X1,

        /// <summary>
        /// Specifies an alpha texture for ClearType text rendering, with three bytes per pixel in the horizontal dimension and 
        /// one byte per pixel in the vertical dimension.
        /// </summary>
        ClearType3X1
    }
}
