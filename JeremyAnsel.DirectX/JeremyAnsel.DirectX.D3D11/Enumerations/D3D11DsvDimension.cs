// <copyright file="D3D11DsvDimension.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Specifies how to access a resource used in a depth-stencil view.
    /// </summary>
    public enum D3D11DsvDimension
    {
        /// <summary>
        /// No value.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The resource will be accessed as a 1D texture.
        /// </summary>
        Texture1D = 1,

        /// <summary>
        /// The resource will be accessed as an array of 1D textures.
        /// </summary>
        Texture1DArray = 2,

        /// <summary>
        /// The resource will be accessed as a 2D texture.
        /// </summary>
        Texture2D = 3,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures.
        /// </summary>
        Texture2DArray = 4,

        /// <summary>
        /// The resource will be accessed as a 2D texture with multisampling.
        /// </summary>
        Texture2DMs = 5,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures with multisampling.
        /// </summary>
        Texture2DMsArray = 6,
    }
}
