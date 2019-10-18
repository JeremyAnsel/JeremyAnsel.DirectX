// <copyright file="D3D11InputClassification.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Type of data contained in an input slot.
    /// </summary>
    public enum D3D11InputClassification
    {
        /// <summary>
        /// Input data is per-vertex data.
        /// </summary>
        PerVertexData = 0,

        /// <summary>
        /// Input data is per-instance data.
        /// </summary>
        PerInstanceData = 1
    }
}
