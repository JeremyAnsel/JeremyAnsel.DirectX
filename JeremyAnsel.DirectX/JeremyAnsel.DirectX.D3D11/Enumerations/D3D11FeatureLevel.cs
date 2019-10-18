// <copyright file="D3D11FeatureLevel.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Describes the set of features targeted by a Direct3D device.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "Reviewed")]
    public enum D3D11FeatureLevel
    {
        /// <summary>
        /// Targets features supported by feature level 9.1 including shader model 2.
        /// </summary>
        FeatureLevel91 = 0x9100,

        /// <summary>
        /// Targets features supported by feature level 9.2 including shader model 2.
        /// </summary>
        FeatureLevel92 = 0x9200,

        /// <summary>
        /// Targets features supported by feature level 9.3 including shader model 2.0b.
        /// </summary>
        FeatureLevel93 = 0x9300,

        /// <summary>
        /// Targets features supported by Direct3D 10.0 including shader model 4.
        /// </summary>
        FeatureLevel100 = 0xa000,

        /// <summary>
        /// Targets features supported by Direct3D 10.1 including shader model 4.
        /// </summary>
        FeatureLevel101 = 0xa100,

        /// <summary>
        /// Targets features supported by Direct3D 11.0 including shader model 5.
        /// </summary>
        FeatureLevel110 = 0xb000,

        /// <summary>
        /// Targets features supported by Direct3D 11.1 including shader model 5 and logical blend operations.
        /// </summary>
        FeatureLevel111 = 0xb100
    }
}
