// <copyright file="D2D1RenderTargetType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes whether a render target uses hardware or software rendering, or if Direct2D should select the rendering mode.
    /// </summary>
    public enum D2D1RenderTargetType
    {
        /// <summary>
        /// The render target uses hardware rendering, if available; otherwise, it uses software rendering.
        /// </summary>
        Default = 0,

        /// <summary>
        /// The render target uses software rendering only.
        /// </summary>
        Software = 1,

        /// <summary>
        /// The render target uses hardware rendering only.
        /// </summary>
        Hardware = 2,
    }
}
