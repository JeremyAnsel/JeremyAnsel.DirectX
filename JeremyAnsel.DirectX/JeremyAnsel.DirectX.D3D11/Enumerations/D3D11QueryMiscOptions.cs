// <copyright file="D3D11QueryMiscOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System;

    /// <summary>
    /// Flags that describe miscellaneous query behavior.
    /// </summary>
    [Flags]
    public enum D3D11QueryMiscOptions
    {
        /// <summary>
        /// No option.
        /// </summary>
        None = 0,

        /// <summary>
        /// Tell the hardware that if it is not yet sure if something is hidden or not to draw it anyway. This is only used with an occlusion predicate.
        /// </summary>
        PredicateHint = 0x1,
    }
}
