// <copyright file="D2D1LayerOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Specifies options that can be applied when a layer resource is applied to create a layer.
    /// </summary>
    [Flags]
    public enum D2D1LayerOptions
    {
        /// <summary>
        /// The text in this layer does not use ClearType antialiasing.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// The layer renders correctly for ClearType text. If the render target is set to ClearType, the layer continues to render ClearType. If the render target is set to ClearType and this option is not specified, the render target will be set to render gray-scale until the layer is popped.
        /// </summary>
        InitializeForClearType = 0x00000001,
    }
}
