// <copyright file="D3D10FeatureLevel.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D10
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The version of hardware acceleration requested.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "Reviewed")]
    public enum D3D10FeatureLevel
    {
        /// <summary>
        /// The hardware supports Direct3D 10.0 features.
        /// </summary>
        FeatureLevel100 = 0xa000,

        /// <summary>
        /// The hardware supports Direct3D 10.1 features.
        /// </summary>
        FeatureLevel101 = 0xa100,

        /// <summary>
        /// The hardware supports 9.1 feature level.
        /// </summary>
        FeatureLevel91 = 0x9100,

        /// <summary>
        /// The hardware supports 9.2 feature level.
        /// </summary>
        FeatureLevel92 = 0x9200,

        /// <summary>
        /// The hardware supports 9.3 feature level.
        /// </summary>
        FeatureLevel93 = 0x9300
    }
}
