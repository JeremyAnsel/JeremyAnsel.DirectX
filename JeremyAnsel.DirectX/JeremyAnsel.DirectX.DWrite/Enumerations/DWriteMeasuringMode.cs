// <copyright file="DWriteMeasuringMode.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// The measuring method used for text layout.
    /// </summary>
    public enum DWriteMeasuringMode
    {
        /// <summary>
        /// Text is measured using glyph ideal metrics whose values are independent to the current display resolution.
        /// </summary>
        Natural,

        /// <summary>
        /// Text is measured using glyph display compatible metrics whose values tuned for the current display resolution.
        /// </summary>
        GdiClassic,

        /// <summary>
        /// Text is measured using the same glyph display metrics as text measured by GDI using a font
        /// created with CLEARTYPE_NATURAL_QUALITY.
        /// </summary>
        GdiNatural
    }
}
