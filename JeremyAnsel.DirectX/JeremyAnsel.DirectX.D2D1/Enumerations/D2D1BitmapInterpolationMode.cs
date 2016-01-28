// <copyright file="D2D1BitmapInterpolationMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies the algorithm that is used when images are scaled or rotated.
    /// </summary>
    public enum D2D1BitmapInterpolationMode
    {
        /// <summary>
        /// Nearest Neighbor filtering. Also known as nearest pixel or nearest point
        /// sampling.
        /// </summary>
        NearestNeighbor = D2D1InterpolationModeDefinition.NearestNeighbor,

        /// <summary>
        /// Linear filtering.
        /// </summary>
        Linear = D2D1InterpolationModeDefinition.Linear,
    }
}
