// <copyright file="DWriteFont.cs" company="Jérémy Ansel">
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
    /// The IDWriteFont interface represents a physical font in a font collection.
    /// </summary>
    public sealed class DWriteFont : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite font interface.
        /// </summary>
        private readonly IDWriteFont handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFont"/> class.
        /// </summary>
        /// <param name="handle">A DWrite font collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteFont(IDWriteFont handle)
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
        /// Gets the weight of the specified font.
        /// </summary>
        public DWriteFontWeight Weight
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetWeight(); }
        }

        /// <summary>
        /// Gets the stretch (aka. width) of the specified font.
        /// </summary>
        public DWriteFontStretch Stretch
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetStretch(); }
        }

        /// <summary>
        /// Gets the style (aka. slope) of the specified font.
        /// </summary>
        public DWriteFontStyle Style
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetStyle(); }
        }

        /// <summary>
        /// Gets a value indicating whether the font is a symbol font.
        /// </summary>
        public bool IsSymbolFont
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.IsSymbolFont(); }
        }

        /// <summary>
        /// Gets a value that indicates what simulation are applied to the specified font.
        /// </summary>
        public DWriteFontSimulations Simulations
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetSimulations(); }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteFont value)
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
        /// Gets the font family to which the specified font belongs.
        /// </summary>
        /// <returns><see cref="DWriteFontFamily"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFamily GetFontFamily()
        {
            this.handle.GetFontFamily(out IDWriteFontFamily fontFamily);

            if (fontFamily == null)
            {
                return null;
            }

            return new DWriteFontFamily(fontFamily);
        }

        /// <summary>
        /// Gets a localized strings collection containing the face names for the font (e.g., Regular or Bold), indexed by locale name.
        /// </summary>
        /// <returns><see cref="DWriteLocalizedStrings"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteLocalizedStrings GetFaceNames()
        {
            this.handle.GetFaceNames(out IDWriteLocalizedStrings names);

            if (names == null)
            {
                return null;
            }

            return new DWriteLocalizedStrings(names);
        }

        /// <summary>
        /// Gets a localized strings collection containing the specified informational strings, indexed by locale name.
        /// </summary>
        /// <param name="informationalStringId">Identifies the string to get.</param>
        /// <remarks>
        /// If the font does not contain the specified string, the return value is S_OK but 
        /// informationalStrings receives a NULL pointer and exists receives the value FALSE.
        /// </remarks>
        /// <returns><see cref="DWriteLocalizedStrings"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteLocalizedStrings GetInformationalStrings(DWriteInformationalStringId informationalStringId)
        {
            this.handle.GetInformationalStrings(informationalStringId, out IDWriteLocalizedStrings informationalStrings, out bool exists);

            if (!exists)
            {
                return null;
            }

            if (informationalStrings == null)
            {
                return null;
            }

            return new DWriteLocalizedStrings(informationalStrings);
        }

        /// <summary>
        /// Gets the metrics for the font.
        /// </summary>
        /// <returns><see cref="DWriteFontMetrics"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontMetrics GetMetrics()
        {
            this.handle.GetMetrics(out DWriteFontMetrics fontMetrics);
            return fontMetrics;
        }

        /// <summary>
        /// Determines whether the font supports the specified character.
        /// </summary>
        /// <param name="unicodeValue">Unicode (UCS-4) character value.</param>
        /// <returns><see cref="bool"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool HasCharacter(uint unicodeValue)
        {
            this.handle.HasCharacter(unicodeValue, out bool exists);
            return exists;
        }

        /// <summary>
        /// Creates a font face object for the font.
        /// </summary>
        /// <returns><see cref="DWriteFontFace"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFace CreateFontFace()
        {
            this.handle.CreateFontFace(out IDWriteFontFace fontFace);

            if (fontFace == null)
            {
                return null;
            }

            return new DWriteFontFace(fontFace);
        }
    }
}
