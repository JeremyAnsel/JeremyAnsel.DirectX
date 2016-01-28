// <copyright file="ContainmentType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    /// <summary>
    /// Indicates whether an object contains another object.
    /// </summary>
    public enum ContainmentType
    {
        /// <summary>
        /// The object does not contain the specified object.
        /// </summary>
        Disjoint = 0,

        /// <summary>
        /// The objects intersect.
        /// </summary>
        Intersects = 1,

        /// <summary>
        /// The object contains the specified object.
        /// </summary>
        Contains = 2
    }
}
