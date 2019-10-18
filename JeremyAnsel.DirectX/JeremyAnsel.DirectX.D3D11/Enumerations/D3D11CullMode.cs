// <copyright file="D3D11CullMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Indicates triangles facing a particular direction are not drawn.
    /// </summary>
    public enum D3D11CullMode
    {
        /// <summary>
        /// Unspecified mode.
        /// </summary>
        Unspecified = 0,

        /// <summary>
        /// Always draw all triangles.
        /// </summary>
        None = 1,

        /// <summary>
        /// Do not draw triangles that are front-facing.
        /// </summary>
        Front = 2,

        /// <summary>
        /// Do not draw triangles that are back-facing.
        /// </summary>
        Back = 3
    }
}
