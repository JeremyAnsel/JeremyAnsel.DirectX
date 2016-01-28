// <copyright file="D2D1ArcSize.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Specifies whether an arc should be greater than 180 degrees.
    /// </summary>
    public enum D2D1ArcSize
    {
        /// <summary>
        /// An arc's sweep should be 180 degrees or less.
        /// </summary>
        Small = 0,

        /// <summary>
        /// An arc's sweep should be 180 degrees or greater.
        /// </summary>
        Large = 1,
    }
}
