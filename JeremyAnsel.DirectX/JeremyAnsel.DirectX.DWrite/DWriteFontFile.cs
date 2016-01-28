// <copyright file="DWriteFontFile.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// The interface that represents a reference to a font file.
    /// </summary>
    public sealed class DWriteFontFile : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite font file interface.
        /// </summary>
        private IDWriteFontFile handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFontFile"/> class.
        /// </summary>
        /// <param name="handle">A DWrite font collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteFontFile(IDWriteFontFile handle)
        {
            this.handle = handle;
        }

        /// <summary>
        /// Gets an handle representing the DWrite object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle; }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteFontFile value)
        {
            return value != null && value.handle != null;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the DWrite object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM DWrite interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.handle);
        }

        /// <summary>
        /// Gets the reference key of a font file.
        /// </summary>
        /// <returns><see cref="byte"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] GetReferenceKey()
        {
            IntPtr fontFileReferenceKey;
            uint fontFileReferenceKeySize;

            this.handle.GetReferenceKey(out fontFileReferenceKey, out fontFileReferenceKeySize);

            byte[] key = new byte[fontFileReferenceKeySize];
            Marshal.Copy(fontFileReferenceKey, key, 0, (int)fontFileReferenceKeySize);

            return key;
        }

        /// <summary>
        /// Analyzes a file and returns whether it represents a font, and whether the font type is supported by the font system.
        /// </summary>
        /// <param name="isSupportedFontType">TRUE if the font type is supported by the font system, FALSE otherwise.</param>
        /// <param name="fontFileType">The type of the font file. Note that even if isSupportedFontType is FALSE,
        /// the fontFileType value may be different from DWRITE_FONT_FILE_TYPE_UNKNOWN.</param>
        /// <param name="fontFaceType">The type of the font face that can be constructed from the font file.
        /// Note that even if isSupportedFontType is FALSE, the fontFaceType value may be different from
        /// DWRITE_FONT_FACE_TYPE_UNKNOWN.</param>
        /// <param name="numberOfFaces">Number of font faces contained in the font file.</param>
        /// <remarks>
        /// IMPORTANT: certain font file types are recognized, but not supported by the font system.
        /// For example, the font system will recognize a file as a Type 1 font file,
        /// but will not be able to construct a font face object from it. In such situations, Analyze will set
        /// isSupportedFontType output parameter to FALSE.
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Analyse(out bool isSupportedFontType, out DWriteFontFileType fontFileType, out DWriteFontFaceType fontFaceType, out uint numberOfFaces)
        {
            this.handle.Analyse(out isSupportedFontType, out fontFileType, out fontFaceType, out numberOfFaces);
        }
    }
}
