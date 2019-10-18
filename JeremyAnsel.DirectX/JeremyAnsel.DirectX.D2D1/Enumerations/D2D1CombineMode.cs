// <copyright file="D2D1CombineMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// This enumeration describes the type of combine operation to be performed.
    /// </summary>
    public enum D2D1CombineMode
    {
        /// <summary>
        /// Produce a geometry representing the set of points contained in either
        /// the first or the second geometry.
        /// </summary>
        Union = 0,

        /// <summary>
        /// Produce a geometry representing the set of points common to the first
        /// and the second geometries.
        /// </summary>
        Intersect = 1,

        /// <summary>
        /// Produce a geometry representing the set of points contained in the
        /// first geometry or the second geometry, but not both.
        /// </summary>
        Xor = 2,

        /// <summary>
        /// Produce a geometry representing the set of points contained in the
        /// first geometry but not the second geometry.
        /// </summary>
        Exclude = 3,
    }
}
