// <copyright file="D2D1TextAntialiasMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    /// <summary>
    /// Describes the antialiasing mode used for drawing text.
    /// </summary>
    public enum D2D1TextAntialiasMode
    {
        /// <summary>
        /// Render text using the current system setting.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Render text using ClearType.
        /// </summary>
        ClearType = 1,

        /// <summary>
        /// Render text using gray-scale.
        /// </summary>
        Grayscale = 2,

        /// <summary>
        /// Render text aliased.
        /// </summary>
        Aliased = 3,
    }
}
