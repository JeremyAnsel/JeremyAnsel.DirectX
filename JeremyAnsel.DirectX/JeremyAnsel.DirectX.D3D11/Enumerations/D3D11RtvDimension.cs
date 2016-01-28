// <copyright file="D3D11RtvDimension.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// These flags identify the type of resource that will be viewed as a render target.
    /// </summary>
    public enum D3D11RtvDimension
    {
        /// <summary>
        /// Do not use this value, as it will cause <see cref="D3D11Device.CreateRenderTargetView"/> to fail.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// The resource will be accessed as a buffer.
        /// </summary>
        Buffer = 1,

        /// <summary>
        /// The resource will be accessed as a 1D texture.
        /// </summary>
        Texture1D = 2,

        /// <summary>
        /// The resource will be accessed as an array of 1D textures.
        /// </summary>
        Texture1DArray = 3,

        /// <summary>
        /// The resource will be accessed as a 2D texture.
        /// </summary>
        Texture2D = 4,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures.
        /// </summary>
        Texture2DArray = 5,

        /// <summary>
        /// The resource will be accessed as a 2D texture with multisampling.
        /// </summary>
        Texture2DMs = 6,

        /// <summary>
        /// The resource will be accessed as an array of 2D textures with multisampling.
        /// </summary>
        Texture2DMsArray = 7,

        /// <summary>
        /// The resource will be accessed as a 3D texture.
        /// </summary>
        Texture3D = 8,
    }
}
