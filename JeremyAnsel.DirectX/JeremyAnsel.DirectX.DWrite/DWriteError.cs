// <copyright file="DWriteError.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    /// <summary>
    /// DWrite error codes.
    /// </summary>
    public static class DWriteError
    {
        /// <summary>
        /// Indicates an error in an input file such as a font file.
        /// </summary>
        public const int FileFormat = unchecked((int)0x88985000L);

        /// <summary>
        /// Indicates an error originating in DirectWrite code, which is not expected to occur but is safe to recover from.
        /// </summary>
        public const int Unexpected = unchecked((int)0x88985001L);

        /// <summary>
        /// Indicates the specified font does not exist.
        /// </summary>
        public const int NoFont = unchecked((int)0x88985002L);

        /// <summary>
        /// A font file could not be opened because the file, directory, network location, drive, or other storage location does not exist or is unavailable.
        /// </summary>
        public const int FileNotFound = unchecked((int)0x88985003L);

        /// <summary>
        /// A font file exists but could not be opened due to access denied, sharing violation, or similar error.
        /// </summary>
        public const int FileAccess = unchecked((int)0x88985004L);

        /// <summary>
        /// A font collection is obsolete due to changes in the system.
        /// </summary>
        public const int FontCollectionObsolete = unchecked((int)0x88985005L);

        /// <summary>
        /// The given interface is already registered.
        /// </summary>
        public const int AlreadyRegistered = unchecked((int)0x88985006L);

        /// <summary>
        /// The font cache contains invalid data.
        /// </summary>
        public const int CacheFormat = unchecked((int)0x88985007L);

        /// <summary>
        /// A font cache file corresponds to a different version of DirectWrite.
        /// </summary>
        public const int CacheVersion = unchecked((int)0x88985008L);

        /// <summary>
        /// The operation is not supported for this type of font.
        /// </summary>
        public const int UnsupportedOperation = unchecked((int)0x88985009L);

        /// <summary>
        /// The version of the text renderer interface is not compatible.
        /// </summary>
        public const int TextRendererIncompatible = unchecked((int)0x8898500AL);

        /// <summary>
        /// The flow direction conflicts with the reading direction. They must be perpendicular to each other.
        /// </summary>
        public const int FlowDirectionConflicts = unchecked((int)0x8898500BL);

        /// <summary>
        /// The font or glyph run does not contain any colored glyphs.
        /// </summary>
        public const int NoColor = unchecked((int)0x8898500CL);
    }
}
