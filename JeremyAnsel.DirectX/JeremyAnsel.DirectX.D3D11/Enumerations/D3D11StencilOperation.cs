// <copyright file="D3D11StencilOperation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// The stencil operations that can be performed during depth-stencil testing.
    /// </summary>
    public enum D3D11StencilOperation
    {
        /// <summary>
        /// No value.
        /// </summary>
        None = 0,

        /// <summary>
        /// Keep the existing stencil data.
        /// </summary>
        Keep = 1,

        /// <summary>
        /// Set the stencil data to 0.
        /// </summary>
        Zero = 2,

        /// <summary>
        /// Set the stencil data to the reference value.
        /// </summary>
        Replace = 3,

        /// <summary>
        /// Increment the stencil value by 1, and clamp the result.
        /// </summary>
        IncrementSaturate = 4,

        /// <summary>
        /// Decrement the stencil value by 1, and clamp the result.
        /// </summary>
        DecrementSaturate = 5,

        /// <summary>
        /// Invert the stencil data.
        /// </summary>
        Invert = 6,

        /// <summary>
        /// Increment the stencil value by 1, and wrap the result if necessary.
        /// </summary>
        Increment = 7,

        /// <summary>
        /// Decrement the stencil value by 1, and wrap the result if necessary.
        /// </summary>
        Decrement = 8
    }
}
