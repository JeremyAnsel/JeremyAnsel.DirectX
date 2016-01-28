// <copyright file="PlaneIntersectionType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    /// <summary>
    /// Indicates whether an object intersects a plane.
    /// </summary>
    public enum PlaneIntersectionType
    {
        /// <summary>
        /// The object is in front of the plane.
        /// </summary>
        Front = 0,

        /// <summary>
        /// The object intersects the plane.
        /// </summary>
        Intersecting = 1,

        /// <summary>
        /// The object is behind the plane.
        /// </summary>
        Back = 2
    }
}
