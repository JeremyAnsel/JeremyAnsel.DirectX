// <copyright file="DWriteFontCollection.cs" company="Jérémy Ansel">
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
    /// The DWriteFontCollection encapsulates a collection of fonts.
    /// </summary>
    public sealed class DWriteFontCollection : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite font collection interface.
        /// </summary>
        private readonly IDWriteFontCollection handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFontCollection"/> class.
        /// </summary>
        /// <param name="handle">A DWrite font collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteFontCollection(IDWriteFontCollection handle)
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
        public static implicit operator bool(DWriteFontCollection? value)
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
        /// Gets the number of font families in the collection.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetFontFamilyCount()
        {
            return this.handle.GetFontFamilyCount();
        }

        /// <summary>
        /// Creates a font family object given a zero-based font family index.
        /// </summary>
        /// <param name="index">Zero-based index of the font family.</param>
        /// <returns><see cref="DWriteFontFamily"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFamily? GetFontFamily(uint index)
        {
            this.handle.GetFontFamily(index, out IDWriteFontFamily? fontFamily);

            if (fontFamily == null)
            {
                return null;
            }

            return new DWriteFontFamily(fontFamily);
        }

        /// <summary>
        /// Finds the font family with the specified family name.
        /// </summary>
        /// <param name="familyName">Name of the font family. The name is not case-sensitive but must otherwise exactly match a family name in the collection.</param>
        /// <param name="index">Receives the zero-based index of the matching font family if the family name was found or UINT_MAX otherwise.</param>
        /// <returns>TRUE if the family name exists or FALSE otherwise.</returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FindFontFamily(string familyName, out uint index)
        {
            this.handle.FindFontFamily(familyName, out index, out bool exists);
            return exists;
        }

        /// <summary>
        /// Gets the font object that corresponds to the same physical font as the specified font face object. The specified physical font must belong 
        /// to the font collection.
        /// </summary>
        /// <param name="fontFace">Font face object that specifies the physical font.</param>
        /// <remarks>
        /// If the specified physical font is not part of the font collection the return value is DWRITE_E_NOFONT.
        /// </remarks>
        /// <returns><see cref="DWriteFont"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFont? GetFontFromFontFace(DWriteFontFace? fontFace)
        {
            if (fontFace == null)
            {
                throw new ArgumentNullException(nameof(fontFace));
            }

            this.handle.GetFontFromFontFace((IDWriteFontFace)fontFace.Handle, out IDWriteFont? font);

            if (font == null)
            {
                return null;
            }

            return new DWriteFont(font);
        }
    }
}
