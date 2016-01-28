// <copyright file="D3D11DepthStencilViewOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Depth-stencil view options.
    /// </summary>
    [Flags]
    public enum D3D11DepthStencilViewOptions
    {
        /// <summary>
        /// No option. Not read only.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that depth values are read only.
        /// </summary>
        ReadOnlyDepth = 0x1,

        /// <summary>
        /// Indicates that stencil values are read only.
        /// </summary>
        ReadOnlyStencil = 0x2,
    }
}
