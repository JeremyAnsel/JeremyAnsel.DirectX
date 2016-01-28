// <copyright file="D2D1ExtendMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies how a brush paints areas outside of its normal content area.
    /// </summary>
    public enum D2D1ExtendMode
    {
        /// <summary>
        /// Repeat the edge pixels of the brush's content for all regions outside the normal content area.
        /// </summary>
        Clamp = 0,

        /// <summary>
        /// Repeat the brush's content.
        /// </summary>
        Wrap = 1,

        /// <summary>
        /// The same as wrap, but alternate tiles are flipped  The base tile is drawn
        /// untransformed.
        /// </summary>
        Mirror = 2,
    }
}
