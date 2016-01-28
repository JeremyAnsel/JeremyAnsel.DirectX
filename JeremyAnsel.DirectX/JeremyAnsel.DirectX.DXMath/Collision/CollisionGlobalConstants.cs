// <copyright file="CollisionGlobalConstants.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DXMath.Collision
{
    /// <summary>
    /// Global constants for collision.
    /// </summary>
    internal static class CollisionGlobalConstants
    {
        /// <summary>
        /// The offsets of a box.
        /// </summary>
        public static readonly XMVector[] BoxOffsets = new XMVector[8]
        {
            new XMVector(-1.0f, -1.0f,  1.0f, 0.0f),
            new XMVector(1.0f, -1.0f,  1.0f, 0.0f),
            new XMVector(1.0f,  1.0f,  1.0f, 0.0f),
            new XMVector(-1.0f,  1.0f,  1.0f, 0.0f),
            new XMVector(-1.0f, -1.0f, -1.0f, 0.0f),
            new XMVector(1.0f, -1.0f, -1.0f, 0.0f),
            new XMVector(1.0f,  1.0f, -1.0f, 0.0f),
            new XMVector(-1.0f,  1.0f, -1.0f, 0.0f)
        };

        /// <summary>
        /// The ray epsilon vector.
        /// </summary>
        public static readonly XMVector RayEpsilon = XMVector.FromFloat(1e-20f, 1e-20f, 1e-20f, 1e-20f);

        /// <summary>
        /// The ray negative epsilon vector.
        /// </summary>
        public static readonly XMVector RayNegEpsilon = XMVector.FromFloat(-1e-20f, -1e-20f, -1e-20f, -1e-20f);

        /// <summary>
        /// The min vector.
        /// </summary>
        public static readonly XMVector FltMin = XMVector.FromFloat(float.MinValue, float.MinValue, float.MinValue, float.MinValue);

        /// <summary>
        /// The max vector.
        /// </summary>
        public static readonly XMVector FltMax = XMVector.FromFloat(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
    }
}
