// <copyright file="D2D1CompatibleRenderTargetOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Specifies additional features supportable by a compatible render target when it is created.
    /// </summary>
    [Flags]
    public enum D2D1CompatibleRenderTargetOptions
    {
        /// <summary>
        /// The render target supports no additional features.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// The render target supports interoperability with the Windows Graphics Device Interface (GDI).
        /// </summary>
        GdiCompatible = 0x00000001,
    }
}
