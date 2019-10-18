// <copyright file="DWriteFontFace.cs" company="Jérémy Ansel">
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
    /// The interface that represents an absolute reference to a font face.
    /// It contains font face type, appropriate file references and face identification data.
    /// Various font data such as metrics, names and glyph outlines is obtained from IDWriteFontFace.
    /// </summary>
    public sealed class DWriteFontFace : IDisposable, IDWriteReleasable
    {
        /// <summary>
        /// The DWrite font face interface.
        /// </summary>
        private IDWriteFontFace handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="DWriteFontFace"/> class.
        /// </summary>
        /// <param name="handle">A DWrite font collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DWriteFontFace(IDWriteFontFace handle)
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
        /// Gets the file format type of a font face.
        /// </summary>
        public DWriteFontFaceType FaceType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetFaceType(); }
        }

        /// <summary>
        /// Gets the zero-based index of the font face in its font file or files. If the font files contain a single face,
        /// the return value is zero.
        /// </summary>
        public uint Index
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetIndex(); }
        }

        /// <summary>
        /// Gets the algorithmic style simulation flags of a font face.
        /// </summary>
        public DWriteFontSimulations Simulations
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.handle.GetSimulations(); }
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
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A DWrite object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(DWriteFontFace value)
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
        /// Obtains the font files representing a font face.
        /// </summary>
        /// <returns><see cref="DWriteFontFile"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontFile[] GetFiles()
        {
            uint numberOfFiles = 0;
            this.handle.GetFiles(ref numberOfFiles, null);

            IDWriteFontFile[] fontFiles = new IDWriteFontFile[numberOfFiles];
            this.handle.GetFiles(ref numberOfFiles, fontFiles);

            return Array.ConvertAll(fontFiles, t => new DWriteFontFile(t));
        }

        /// <summary>
        /// Obtains design units and common metrics for the font face.
        /// These metrics are applicable to all the glyphs within a font face and are used by applications for layout calculations.
        /// </summary>
        /// <remarks>The metrics returned by this function are in font design units.</remarks>
        /// <returns><see cref="DWriteFontMetrics"/></returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontMetrics GetMetrics()
        {
            DWriteFontMetrics fontFaceMetrics;
            this.handle.GetMetrics(out fontFaceMetrics);
            return fontFaceMetrics;
        }

        /// <summary>
        /// Determines the recommended rendering mode for the font given the specified size and rendering parameters.
        /// </summary>
        /// <param name="size">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
        /// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this 
        /// value is 1.0f. If the DPI is 120, this value is 120.0f/96.</param>
        /// <param name="measuringMode">Specifies measuring mode that will be used for glyphs in the font.
        /// Renderer implementations may choose different rendering modes for given measuring modes, but
        /// best results are seen when the corresponding modes match:
        /// DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL
        /// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC
        /// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL
        /// </param>
        /// <param name="renderingParams">Rendering parameters object. This parameter is necessary in case the rendering parameters 
        /// object overrides the rendering mode.</param>
        /// <returns><see cref="DWriteRenderingMode"/></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteRenderingMode GetRecommendedRenderingMode(
            float size,
            float pixelsPerDip,
            DWriteMeasuringMode measuringMode,
            DWriteRenderingParams renderingParams)
        {
            DWriteRenderingMode renderingMode;
            this.handle.GetRecommendedRenderingMode(
                size,
                pixelsPerDip,
                measuringMode,
                renderingParams == null ? null : (IDWriteRenderingParams)renderingParams.Handle,
                out renderingMode);
            return renderingMode;
        }
    }
}
