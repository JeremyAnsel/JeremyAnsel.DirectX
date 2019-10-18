// <copyright file="D3D11UavDimension.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Unordered-access view options.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags", Justification = "Reviewed")]
    public enum D3D11UavDimension
    {
        /// <summary>
        /// The view type is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// View the resource as a buffer.
        /// </summary>
        Buffer = 1,

        /// <summary>
        /// View the resource as a 1D texture.
        /// </summary>
        Texture1D = 2,

        /// <summary>
        /// View the resource as a 1D texture array.
        /// </summary>
        Texture1DArray = 3,

        /// <summary>
        /// View the resource as a 2D texture.
        /// </summary>
        Texture2D = 4,

        /// <summary>
        /// View the resource as a 2D texture array.
        /// </summary>
        Texture2DArray = 5,

        /// <summary>
        /// View the resource as a 3D texture array.
        /// </summary>
        Texture3D = 8,
    }
}
