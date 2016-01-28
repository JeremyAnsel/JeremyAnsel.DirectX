// <copyright file="D2D1DrawTextOptions.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;

    /// <summary>
    /// Specifies whether text snapping is suppressed or clipping to the layout rectangle is enabled.
    /// </summary>
    [Flags]
    public enum D2D1DrawTextOptions
    {
        /// <summary>
        /// Text is vertically snapped to pixel boundaries and is not clipped to the layout rectangle.
        /// </summary>
        None = 0x00000000,

        /// <summary>
        /// Text is not vertically snapped to pixel boundaries. This setting is recommended for text that is being animated.
        /// </summary>
        NoSnap = 0x00000001,

        /// <summary>
        /// Text is clipped to the layout rectangle.
        /// </summary>
        Clip = 0x00000002,

        /// <summary>
        /// In Windows 8.1 and later, text is rendered using color versions of glyphs, if defined by the font.
        /// </summary>
        EnableColorFont = 0x00000004,
    }
}
