// <copyright file="D3D11ClearOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Specifies the parts of the depth stencil to clear.
    /// </summary>
    [Flags]
    public enum D3D11ClearOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Clear the depth buffer.
        /// </summary>
        Depth = 0x01,

        /// <summary>
        /// Clear the stencil buffer.
        /// </summary>
        Stencil = 0x02,
    }
}
