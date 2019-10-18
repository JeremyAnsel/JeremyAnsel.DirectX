// <copyright file="D3D11BlendOperation.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// RGB or alpha blending operation.
    /// </summary>
    public enum D3D11BlendOperation
    {
        /// <summary>
        /// No operation.
        /// </summary>
        None = 0,

        /// <summary>
        /// Add source 1 and source 2.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Subtract source 1 from source 2.
        /// </summary>
        Subtract = 2,

        /// <summary>
        /// Subtract source 2 from source 1.
        /// </summary>
        ReverseSubtract = 3,

        /// <summary>
        /// Find the minimum of source 1 and source 2.
        /// </summary>
        Mininum = 4,

        /// <summary>
        /// Find the maximum of source 1 and source 2.
        /// </summary>
        Maximum = 5,
    }
}
