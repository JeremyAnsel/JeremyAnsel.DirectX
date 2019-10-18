// <copyright file="DWriteTrimmingGranularity.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// Text granularity used to trim text overflowing the layout box.
    /// </summary>
    public enum DWriteTrimmingGranularity
    {
        /// <summary>
        /// No trimming occurs. Text flows beyond the layout width.
        /// </summary>
        None,

        /// <summary>
        /// Trimming occurs at character cluster boundary.
        /// </summary>
        Character,

        /// <summary>
        /// Trimming occurs at word boundary.
        /// </summary>
        Word
    }
}
