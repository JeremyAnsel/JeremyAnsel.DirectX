// <copyright file="D2D1LineJoin.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes the shape that joins two lines or segments.
    /// </summary>
    public enum D2D1LineJoin
    {
        /// <summary>
        /// Regular angular vertices.
        /// </summary>
        Miter = 0,

        /// <summary>
        /// Beveled vertices.
        /// </summary>
        Bevel = 1,

        /// <summary>
        /// Rounded vertices.
        /// </summary>
        Round = 2,

        /// <summary>
        /// Regular angular vertices unless the join would extend beyond the miter limit; otherwise, beveled vertices.
        /// </summary>
        MiterOrBevel = 3,
    }
}
