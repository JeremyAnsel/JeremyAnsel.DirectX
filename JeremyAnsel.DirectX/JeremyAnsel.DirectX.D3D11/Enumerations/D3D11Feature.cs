// <copyright file="D3D11Feature.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    /// <summary>
    /// Direct3D 11 feature options.
    /// </summary>
    public enum D3D11Feature
    {
        /// <summary>
        /// The driver supports multithreading.
        /// </summary>
        Threading,

        /// <summary>
        /// Supports the use of the double-precision shaders in HLSL.
        /// </summary>
        Doubles,

        /// <summary>
        /// Supports the formats in <see cref="D3D11FormatSupport"/>.
        /// </summary>
        FormatSupport,

        /// <summary>
        /// Supports the formats in <see cref="D3D11FormatSupport2"/>.
        /// </summary>
        FormatSupport2,

        /// <summary>
        /// Supports compute shaders and raw and structured buffers.
        /// </summary>
        D3D10XHardwareOptions,

        /// <summary>
        /// Supports Direct3D 11.1 feature options.
        /// </summary>
        D3D11Options,

        /// <summary>
        /// Supports specific adapter architecture.
        /// </summary>
        ArchitectureInfo,

        /// <summary>
        /// Supports Direct3D 9 feature options.
        /// </summary>
        D3D9Options,

        /// <summary>
        /// Supports minimum precision of shaders.
        /// </summary>
        ShaderMinPrecisionSupport,

        /// <summary>
        /// Supports Direct3D 9 shadowing feature.
        /// </summary>
        D3D9ShadowSupport,

        /// <summary>
        /// Supports Direct3D 11.2 feature options.
        /// </summary>
        D3D11Options1,

        /// <summary>
        /// Supports Direct3D 11.2 instancing options.
        /// </summary>
        D3D9SimpleInstancingSupport,

        /// <summary>
        /// Supports Direct3D 11.2 marker options.
        /// </summary>
        MarkerSupport,

        /// <summary>
        /// Supports Direct3D 9 feature options, which includes the Direct3D 9 shadowing feature and instancing support.
        /// </summary>
        D3D9Options1,
    }
}
