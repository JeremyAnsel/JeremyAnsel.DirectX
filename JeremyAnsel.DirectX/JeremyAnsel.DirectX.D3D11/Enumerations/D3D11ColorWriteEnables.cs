// <copyright file="D3D11ColorWriteEnables.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Identify which components of each pixel of a render target are writable during blending.
    /// </summary>
    [Flags]
    public enum D3D11ColorWriteEnables
    {
        /// <summary>
        /// No value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Allow data to be stored in the red component.
        /// </summary>
        Red = 1,

        /// <summary>
        /// Allow data to be stored in the green component.
        /// </summary>
        Green = 2,

        /// <summary>
        /// Allow data to be stored in the blue component.
        /// </summary>
        Blue = 4,

        /// <summary>
        /// Allow data to be stored in the alpha component.
        /// </summary>
        Alpha = 8,

        /// <summary>
        /// Allow data to be stored in all components.
        /// </summary>
        All = Red | Green | Blue | Alpha,
    }
}
