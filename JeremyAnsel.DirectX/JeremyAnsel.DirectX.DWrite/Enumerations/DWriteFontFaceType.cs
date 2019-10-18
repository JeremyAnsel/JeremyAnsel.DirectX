// <copyright file="DWriteFontFaceType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// The file format of a complete font face.
    /// Font formats that consist of multiple files a single entry.
    /// </summary>
    public enum DWriteFontFaceType
    {
        /// <summary>
        /// OpenType font face with CFF outlines.
        /// </summary>
        Cff,

        /// <summary>
        /// OpenType font face with TrueType outlines.
        /// </summary>
        TrueType,

        /// <summary>
        /// OpenType font face that is a part of a TrueType collection.
        /// </summary>
        TrueTypeCollection,

        /// <summary>
        /// A Type 1 font face.
        /// </summary>
        Type1,

        /// <summary>
        /// A vector .FON format font face.
        /// </summary>
        Vector,

        /// <summary>
        /// A bitmap .FON format font face.
        /// </summary>
        Bitmap,

        /// <summary>
        /// Font face type is not recognized by the DirectWrite font system.
        /// </summary>
        Unknown,

        /// <summary>
        /// The font data includes only the CFF table from an OpenType CFF font.
        /// This font face type can be used only for embedded fonts (i.e., custom
        /// font file loaders) and the resulting font face object supports only the
        /// minimum functionality necessary to render glyphs.
        /// </summary>
        RawCff
    }
}
