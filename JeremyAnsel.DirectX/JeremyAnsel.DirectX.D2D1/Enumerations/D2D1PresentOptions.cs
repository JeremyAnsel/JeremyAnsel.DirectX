// <copyright file="D2D1PresentOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Describes how a render target behaves when it presents its content.
    /// </summary>
    [Flags]
    public enum D2D1PresentOptions
    {
        /// <summary>
        /// The render target waits until the display refreshes to present and discards the frame upon presenting.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// The render target does not discard the frame upon presenting.
        /// </summary>
        RetainContents = 0x00000001,

        /// <summary>
        /// The render target does not wait until the display refreshes to present.
        /// </summary>
        Immediately = 0x00000002,
    }
}
