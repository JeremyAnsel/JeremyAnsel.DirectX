﻿// <copyright file="DWriteTextAlignment.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// Alignment of paragraph text along the reading direction axis relative to 
    /// the leading and trailing edge of the layout box.
    /// </summary>
    public enum DWriteTextAlignment
    {
        /// <summary>
        /// The leading edge of the paragraph text is aligned to the layout box's leading edge.
        /// </summary>
        Leading,

        /// <summary>
        /// The trailing edge of the paragraph text is aligned to the layout box's trailing edge.
        /// </summary>
        Trailing,

        /// <summary>
        /// The center of the paragraph text is aligned to the center of the layout box.
        /// </summary>
        Center,

        /// <summary>
        /// Align text to the leading side, and also justify text to fill the lines.
        /// </summary>
        Justified
    }
}
