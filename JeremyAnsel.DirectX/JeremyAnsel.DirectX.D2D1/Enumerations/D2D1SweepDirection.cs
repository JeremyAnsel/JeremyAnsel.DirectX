// <copyright file="D2D1SweepDirection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Defines the direction that an elliptical arc is drawn.
    /// </summary>
    public enum D2D1SweepDirection
    {
        /// <summary>
        /// Arcs are drawn in a counterclockwise (negative-angle) direction.
        /// </summary>
        CounterClockwise = 0,

        /// <summary>
        /// Arcs are drawn in a clockwise (positive-angle) direction.
        /// </summary>
        Clockwise = 1,
    }
}
