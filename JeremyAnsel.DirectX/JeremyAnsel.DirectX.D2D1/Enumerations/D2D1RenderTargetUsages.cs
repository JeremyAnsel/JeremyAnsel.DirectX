// <copyright file="D2D1RenderTargetUsages.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Describes how a render target is remoted and whether it should be GDI-compatible.
    /// </summary>
    [Flags]
    public enum D2D1RenderTargetUsages
    {
        /// <summary>
        /// The render target attempts to use Direct3D command-stream remoting and uses bitmap remoting if stream remoting fails. The render target is not GDI-compatible.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// The render target renders content locally and sends it to the terminal services client as a bitmap.
        /// </summary>
        ForceBitmapRemoting = 0x00000001,

        /// <summary>
        /// The render target can be used efficiently with GDI.
        /// </summary>
        GdiCompatible = 0x00000002,
    }
}
