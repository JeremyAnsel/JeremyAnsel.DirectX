// <copyright file="D2D1AlphaMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Qualifies how alpha is to be treated in a bitmap or render target containing alpha.
    /// </summary>
    public enum D2D1AlphaMode
    {
        /// <summary>
        /// Alpha mode should be determined implicitly. Some target surfaces do not supply
        /// or imply this information in which case alpha must be specified.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Treat the alpha as premultipled.
        /// </summary>
        Premultiplied = 1,

        /// <summary>
        /// Opacity is in the 'A' component only.
        /// </summary>
        Straight = 2,

        /// <summary>
        /// Ignore any alpha channel information.
        /// </summary>
        Ignore = 3,
    }
}
