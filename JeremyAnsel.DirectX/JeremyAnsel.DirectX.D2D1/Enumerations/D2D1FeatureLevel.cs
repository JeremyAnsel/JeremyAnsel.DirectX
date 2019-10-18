// <copyright file="D2D1FeatureLevel.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes the minimum DirectX support required for hardware rendering by a render target.
    /// </summary>
    public enum D2D1FeatureLevel
    {
        /// <summary>
        /// The caller does not require a particular underlying D3D device level.
        /// </summary>
        Default = 0,

        /// <summary>
        /// The D3D device level is DX9 compatible.
        /// </summary>
        FeatureLevel91 = 0x9100,

        /// <summary>
        /// The D3D device level is DX10 compatible.
        /// </summary>
        FeatureLevel100 = 0xa000,
    }
}
