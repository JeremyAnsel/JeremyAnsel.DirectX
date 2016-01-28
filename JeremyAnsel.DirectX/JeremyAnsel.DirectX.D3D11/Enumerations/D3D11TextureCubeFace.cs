// <copyright file="D3D11TextureCubeFace.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// The different faces of a cube texture.
    /// </summary>
    public enum D3D11TextureCubeFace
    {
        /// <summary>
        /// Positive X face.
        /// </summary>
        PositiveX = 0,

        /// <summary>
        /// Negative X face.
        /// </summary>
        NegativeX = 1,

        /// <summary>
        /// Positive Y face.
        /// </summary>
        PositiveY = 2,

        /// <summary>
        /// Negative Y face.
        /// </summary>
        NegativeY = 3,

        /// <summary>
        /// Positive Z face.
        /// </summary>
        PositiveZ = 4,

        /// <summary>
        /// Negative Z face.
        /// </summary>
        NegativeZ = 5
    }
}
