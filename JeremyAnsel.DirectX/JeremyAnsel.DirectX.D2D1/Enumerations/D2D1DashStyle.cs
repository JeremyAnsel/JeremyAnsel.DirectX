// <copyright file="D2D1DashStyle.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes the sequence of dashes and gaps in a stroke.
    /// </summary>
    public enum D2D1DashStyle
    {
        /// <summary>
        /// A solid line with no breaks.
        /// </summary>
        Solid = 0,

        /// <summary>
        /// A dash followed by a gap of equal length. The dash and the gap are each twice as long as the stroke thickness.
        /// </summary>
        Dash = 1,

        /// <summary>
        /// A dot followed by a longer gap.
        /// </summary>
        Dot = 2,

        /// <summary>
        /// A dash, followed by a gap, followed by a dot, followed by another gap.
        /// </summary>
        DashDot = 3,

        /// <summary>
        /// A dash, followed by a gap, followed by a dot, followed by another gap, followed by another dot, followed by another gap.
        /// </summary>
        DashDotDot = 4,

        /// <summary>
        /// The dash pattern is specified by an array of floating-point values.
        /// </summary>
        Custom = 5,
    }
}
