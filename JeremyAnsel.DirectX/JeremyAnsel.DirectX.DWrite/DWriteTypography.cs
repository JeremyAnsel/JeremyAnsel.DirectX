// <copyright file="DWriteTypography.cs" company="Jérémy Ansel">
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
    /// Font typography setting.
    /// </summary>
    public sealed class DWriteTypography : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite typography interface.
        /// </summary>
        private IDWriteTypography handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteTypography"/> class.
        /// </summary>
        /// <param name="handle">A DWrite factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteTypography(IDWriteTypography handle)
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
        public static implicit operator bool(DWriteTypography value)
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
        /// Add font feature.
        /// </summary>
        /// <param name="fontFeature">The font feature to add.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AddFontFeature(DWriteFontFeature fontFeature)
        {
            this.handle.AddFontFeature(fontFeature);
        }

        /// <summary>
        /// Get the number of font features.
        /// </summary>
        /// <returns><see cref="uint"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetFontFeatureCount()
        {
            return this.handle.GetFontFeatureCount();
        }

        /// <summary>
        /// Get the font feature at the specified index.
        /// </summary>
        /// <param name="fontFeatureIndex">The zero-based index of the font feature to get.</param>
        /// <returns><see cref="DWriteFontFeature"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFeature GetFontFeature(uint fontFeatureIndex)
        {
            DWriteFontFeature fontFeature;
            this.handle.GetFontFeature(fontFeatureIndex, out fontFeature);
            return fontFeature;
        }
    }
}
