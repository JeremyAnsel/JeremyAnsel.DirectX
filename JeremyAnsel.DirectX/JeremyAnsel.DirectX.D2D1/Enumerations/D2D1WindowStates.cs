// <copyright file="D2D1WindowStates.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Describes whether a window is occluded.
    /// </summary>
    [Flags]
    public enum D2D1WindowStates
    {
        /// <summary>
        /// The window is not occluded.
        /// </summary>
        None = 0x0000000,

        /// <summary>
        /// The window is occluded.
        /// </summary>
        Occluded = 0x0000001,
    }
}
