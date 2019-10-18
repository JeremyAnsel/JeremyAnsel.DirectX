// <copyright file="DWriteFontSimulations.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;

    /// <summary>
    /// Specifies algorithmic style simulations to be applied to the font face.
    /// Bold and oblique simulations can be combined via bitwise OR operation.
    /// </summary>
    [Flags]
    public enum DWriteFontSimulations
    {
        /// <summary>
        /// No simulations are performed.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Algorithmic emboldening is performed.
        /// </summary>
        Bold = 0x0001,

        /// <summary>
        /// Algorithmic italicization is performed.
        /// </summary>
        Oblique = 0x0002
    }
}
