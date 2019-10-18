// <copyright file="DWriteFontFamily.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.DWrite.ComInterfaces;

    /// <summary>
    /// The IDWriteFontFamily interface represents a set of fonts that share the same design but are differentiated
    /// by weight, stretch, and style.
    /// </summary>
    public sealed class DWriteFontFamily : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite font family interface.
        /// </summary>
        private IDWriteFontFamily handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFontFamily"/> class.
        /// </summary>
        /// <param name="handle">A DWrite font collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteFontFamily(IDWriteFontFamily handle)
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
        public static implicit operator bool(DWriteFontFamily value)
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
        /// Gets the font collection that contains the fonts.
        /// </summary>
        /// <returns><see cref="DWriteFontCollection"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontCollection GetFontCollection()
        {
            IDWriteFontCollection fontCollection;
            this.handle.GetFontCollection(out fontCollection);
            return new DWriteFontCollection(fontCollection);
        }

        /// <summary>
        /// Gets the number of fonts in the font list.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetFontCount()
        {
            return this.handle.GetFontCount();
        }

        /// <summary>
        /// Gets a font given its zero-based index.
        /// </summary>
        /// <param name="index">Zero-based index of the font in the font list.</param>
        /// <returns><see cref="DWriteFont"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFont GetFont(uint index)
        {
            IDWriteFont font;
            this.handle.GetFont(index, out font);
            return new DWriteFont(font);
        }

        /// <summary>
        /// Creates a localized strings object that contains the family names for the font family, indexed by locale name.
        /// </summary>
        /// <returns><see cref="DWriteLocalizedStrings"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteLocalizedStrings GetFamilyNames()
        {
            IDWriteLocalizedStrings names;
            this.handle.GetFamilyNames(out names);
            return new DWriteLocalizedStrings(names);
        }

        /// <summary>
        /// Gets the font that best matches the specified properties.
        /// </summary>
        /// <param name="weight">Requested font weight.</param>
        /// <param name="stretch">Requested font stretch.</param>
        /// <param name="style">Requested font style.</param>
        /// <returns><see cref="DWriteFont"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFont GetFirstMatchingFont(DWriteFontWeight weight, DWriteFontStretch stretch, DWriteFontStyle style)
        {
            IDWriteFont matchingFont;
            this.handle.GetFirstMatchingFont(weight, stretch, style, out matchingFont);
            return new DWriteFont(matchingFont);
        }

        /// <summary>
        /// Gets a list of fonts in the font family ranked in order of how well they match the specified properties.
        /// </summary>
        /// <param name="weight">Requested font weight.</param>
        /// <param name="stretch">Requested font stretch.</param>
        /// <param name="style">Requested font style.</param>
        /// <returns><see cref="DWriteFontList"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontList GetMatchingFonts(DWriteFontWeight weight, DWriteFontStretch stretch, DWriteFontStyle style)
        {
            IDWriteFontList matchingFonts;
            this.handle.GetMatchingFonts(weight, stretch, style, out matchingFonts);
            return new DWriteFontList(matchingFonts);
        }
    }
}
