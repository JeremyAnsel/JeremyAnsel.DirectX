// <copyright file="DxgiEnumModes.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;

    /// <summary>
    /// Options for enumerating display modes.
    /// </summary>
    [Flags]
    public enum DxgiEnumModes
    {
        /// <summary>
        /// Include centered modes.
        /// </summary>
        None = 0,

        /// <summary>
        /// Include interlaced modes.
        /// </summary>
        Interlaced = 1 << 0,

        /// <summary>
        /// Include stretched-scaling modes.
        /// </summary>
        Scaling = 1 << 1,

        /// <summary>
        /// Include stereo modes.
        /// </summary>
        Stereo = 1 << 2,

        /// <summary>
        /// Include stereo modes that are hidden because the user has disabled stereo. Control panel applications can use this option to show stereo capabilities that have been disabled as part of a user interface that enables and disables stereo.
        /// </summary>
        DisabledStereo = 1 << 3
    }
}
