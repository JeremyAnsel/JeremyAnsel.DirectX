// <copyright file="DxgiUsages.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// Surface and resource creation options.
    /// </summary>
    [Flags]
    public enum DxgiUsages
    {
        /// <summary>
        /// Use the surface or resource as an input to a shader.
        /// </summary>
        ShaderInput = 1 << (0 + 4),

        /// <summary>
        /// Use the surface or resource as an output render target.
        /// </summary>
        RenderTargetOutput = 1 << (1 + 4),

        /// <summary>
        /// The surface or resource is used as a back buffer.
        /// </summary>
        BackBuffer = 1 << (2 + 4),

        /// <summary>
        /// Share the surface or resource.
        /// </summary>
        Shared = 1 << (3 + 4),

        /// <summary>
        /// Use the surface or resource for reading only.
        /// </summary>
        ReadOnly = 1 << (4 + 4),

        /// <summary>
        /// This flag is for internal use only.
        /// </summary>
        DiscardOnPresent = 1 << (5 + 4),

        /// <summary>
        /// Use the surface or resource for unordered access.
        /// </summary>
        UnorderedAcess = 1 << (6 + 4)
    }
}
