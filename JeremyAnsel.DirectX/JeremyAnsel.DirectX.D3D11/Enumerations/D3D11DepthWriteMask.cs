// <copyright file="D3D11DepthWriteMask.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Identify the portion of a depth-stencil buffer for writing depth data.
    /// </summary>
    public enum D3D11DepthWriteMask
    {
        /// <summary>
        /// Turn off writes to the depth-stencil buffer.
        /// </summary>
        Zero = 0,

        /// <summary>
        /// Turn on writes to the depth-stencil buffer.
        /// </summary>
        All = 1
    }
}
