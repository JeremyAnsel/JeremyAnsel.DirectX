// <copyright file="D3D11TiledResourcesTier.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Indicates the tier level at which tiled resources are supported.
    /// </summary>
    public enum D3D11TiledResourcesTier
    {
        /// <summary>
        /// Tiled resources are not supported.
        /// </summary>
        NotSupported = 0,

        /// <summary>
        /// Tier_1 tiled resources are supported.
        /// </summary>
        Tier1 = 1,

        /// <summary>
        /// Tier_2 tiled resources are supported.
        /// </summary>
        Tier2 = 2,
    }
}
