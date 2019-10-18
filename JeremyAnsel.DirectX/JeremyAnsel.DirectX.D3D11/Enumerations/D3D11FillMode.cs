// <copyright file="D3D11FillMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Determines the fill mode to use when rendering triangles.
    /// </summary>
    public enum D3D11FillMode
    {
        /// <summary>
        /// No mode.
        /// </summary>
        None = 0,

        /// <summary>
        /// Draw lines connecting the vertices. Adjacent vertices are not drawn.
        /// </summary>
        WireFrame = 2,

        /// <summary>
        /// Fill the triangles formed by the vertices. Adjacent vertices are not drawn.
        /// </summary>
        Solid = 3
    }
}
