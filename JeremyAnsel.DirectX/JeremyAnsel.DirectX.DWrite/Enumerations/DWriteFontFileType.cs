// <copyright file="DWriteFontFileType.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// The type of a font represented by a single font file.
    /// Font formats that consist of multiple files, e.g. Type 1 .PFM and .PFB, have
    /// separate values for each of the file type.
    /// </summary>
    public enum DWriteFontFileType
    {
        /// <summary>
        /// Font type is not recognized by the DirectWrite font system.
        /// </summary>
        Unknown,

        /// <summary>
        /// OpenType font with CFF outlines.
        /// </summary>
        Cff,

        /// <summary>
        /// OpenType font with TrueType outlines.
        /// </summary>
        TrueType,

        /// <summary>
        /// OpenType font that contains a TrueType collection.
        /// </summary>
        TrueTypeCollection,

        /// <summary>
        /// Type 1 PFM font.
        /// </summary>
        Type1Pfm,

        /// <summary>
        /// Type 1 PFB font.
        /// </summary>
        Type1Pfb,

        /// <summary>
        /// Vector .FON font.
        /// </summary>
        Vector,

        /// <summary>
        /// Bitmap .FON font.
        /// </summary>
        Bitmap
    }
}
