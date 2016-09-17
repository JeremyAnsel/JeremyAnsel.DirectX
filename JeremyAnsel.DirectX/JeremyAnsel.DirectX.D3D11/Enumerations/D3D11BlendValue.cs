// <copyright file="D3D11BlendValue.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Blend factors, which modulate values for the pixel shader and render target.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags", Justification = "Reviewed")]
    public enum D3D11BlendValue
    {
        /// <summary>
        /// No value.
        /// </summary>
        None = 0,

        /// <summary>
        /// The blend factor is <c>(0, 0, 0, 0)</c>. No pre-blend operation.
        /// </summary>
        Zero = 1,

        /// <summary>
        /// The blend factor is <c>(1, 1, 1, 1)</c>. No pre-blend operation.
        /// </summary>
        One = 2,

        /// <summary>
        /// The blend factor is <c>(Rs, Gs, Bs, As)</c>, that is color data (RGB) from a pixel shader. No pre-blend operation.
        /// </summary>
        SourceColor = 3,

        /// <summary>
        /// The blend factor is <c>(1 - Rs, 1 - Gs, 1 - Bs, 1 - As)</c>, that is color data (RGB) from a pixel shader. The pre-blend operation inverts the data, generating <c>1 - RGB</c>.
        /// </summary>
        InverseSourceColor = 4,

        /// <summary>
        /// The blend factor is <c>(As, As, As, As)</c>, that is alpha data (A) from a pixel shader. No pre-blend operation.
        /// </summary>
        SourceAlpha = 5,

        /// <summary>
        /// The blend factor is <c>( 1 - As, 1 - As, 1 - As, 1 - As)</c>, that is alpha data (A) from a pixel shader. The pre-blend operation inverts the data, generating <c>1 - A</c>.
        /// </summary>
        InverseSourceAlpha = 6,

        /// <summary>
        /// The blend factor is <c>(Ad, Ad, Ad, Ad)</c>, that is alpha data from a render target. No pre-blend operation.
        /// </summary>
        DestinationAlpha = 7,

        /// <summary>
        /// The blend factor is <c>(1 - Ad, 1 - Ad, 1 - Ad, 1 - Ad)</c>, that is alpha data from a render target. The pre-blend operation inverts the data, generating <c>1 - A</c>.
        /// </summary>
        InverseDestinationAlpha = 8,

        /// <summary>
        /// The blend factor is <c>(Rd, Gd, Bd, Ad)</c>, that is color data from a render target. No pre-blend operation.
        /// </summary>
        DestinationColor = 9,

        /// <summary>
        /// The blend factor is <c>(1 - Rd, 1 - Gd, 1 - Bd, 1 - Ad)</c>, that is color data from a render target. The pre-blend operation inverts the data, generating <c>1 - RGB</c>.
        /// </summary>
        InverseDestinationColor = 10,

        /// <summary>
        /// The blend factor is <c>(f, f, f, 1)</c>, where <c>f = min(As, 1 - Ad)</c>. The pre-blend operation clamps the data to 1 or less.
        /// </summary>
        SourceAlphaSaturate = 11,

        /// <summary>
        /// The blend factor is the blend factor set with <see cref="D3D11DeviceContext.OutputMergerSetBlendState"/>. No pre-blend operation.
        /// </summary>
        BlendFactor = 14,

        /// <summary>
        /// The blend factor is the blend factor set with <see cref="D3D11DeviceContext.OutputMergerSetBlendState"/>. The pre-blend operation inverts the blend factor, generating <c>1 - blend_factor</c>.
        /// </summary>
        InverseBlendFactor = 15,

        /// <summary>
        /// The blend factor is data sources both as color data output by a pixel shader. There is no pre-blend operation. This blend factor supports dual-source color blending.
        /// </summary>
        Source1Color = 16,

        /// <summary>
        /// The blend factor is data sources both as color data output by a pixel shader. The pre-blend operation inverts the data, generating <c>1 - RGB</c>. This blend factor supports dual-source color blending.
        /// </summary>
        InverseSource1Color = 17,

        /// <summary>
        /// The blend factor is data sources as alpha data output by a pixel shader. There is no pre-blend operation. This blend factor supports dual-source color blending.
        /// </summary>
        Source1Alpha = 18,

        /// <summary>
        /// The blend factor is data sources as alpha data output by a pixel shader. The pre-blend operation inverts the data, generating <c>1 - A</c>. This blend factor supports dual-source color blending.
        /// </summary>
        InverseSource1Alpha = 19,
    }
}
