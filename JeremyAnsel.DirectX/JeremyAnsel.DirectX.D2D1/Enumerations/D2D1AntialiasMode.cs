// <copyright file="D2D1AntialiasMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies how the edges of nontext primitives are rendered.
    /// </summary>
    public enum D2D1AntialiasMode
    {
        /// <summary>
        /// The edges of each primitive are antialiased sequentially.
        /// </summary>
        PerPrimitive = 0,

        /// <summary>
        /// Each pixel is rendered if its pixel center is contained by the geometry.
        /// </summary>
        Aliased = 1,
    }
}
