// <copyright file="D2D1CapStyle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes the shape at the end of a line or segment.
    /// </summary>
    public enum D2D1CapStyle
    {
        /// <summary>
        /// Flat line cap.
        /// </summary>
        Flat = 0,

        /// <summary>
        /// Square line cap.
        /// </summary>
        Square = 1,

        /// <summary>
        /// Round line cap.
        /// </summary>
        Round = 2,

        /// <summary>
        /// Triangle line cap.
        /// </summary>
        Triangle = 3,
    }
}
