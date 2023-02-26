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
        private readonly IDWriteFontFace handle;

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
        /// Gets the number of glyphs in the font face.
        /// </summary>
        public ushort GlyphCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.handle.GetGlyphCount();
            }
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

            return Array.ConvertAll(fontFiles, t => t == null ? null : new DWriteFontFile(t));
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
            this.handle.GetMetrics(out DWriteFontMetrics fontFaceMetrics);
            return fontFaceMetrics;
        }

        /// <summary>
        /// Obtains ideal glyph metrics in font design units. Design glyphs metrics are used for glyph positioning.
        /// </summary>
        /// <remarks>The metrics returned by this function are in font design units.</remarks>
        /// <param name="glyphIndices">An array of glyph indices to compute the metrics for.</param>
        /// <param name="isSideways">Indicates whether the font is being used in a sideways run.
        /// This can affect the glyph metrics if the font has oblique simulation
        /// because sideways oblique simulation differs from non-sideways oblique simulation.</param>
        /// <returns>Array of <see cref="DWriteGlyphMetrics"/> structures filled by this function.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteGlyphMetrics[] GetDesignGlyphMetrics(ushort[] glyphIndices, bool isSideways)
        {
            if (glyphIndices == null)
            {
                throw new ArgumentNullException(nameof(glyphIndices));
            }

            DWriteGlyphMetrics[] glyphMetrics = new DWriteGlyphMetrics[glyphIndices.Length];
            this.handle.GetDesignGlyphMetrics(glyphIndices, (uint)glyphIndices.Length, glyphMetrics, isSideways);
            return glyphMetrics;
        }

        /// <summary>
        /// Returns the nominal mapping of UTF-32 Unicode code points to glyph indices as defined by the font 'cmap' table.
        /// Note that this mapping is primarily provided for line layout engines built on top of the physical font API.
        /// Because of OpenType glyph substitution and line layout character substitution, the nominal conversion does not always correspond
        /// to how a Unicode string will map to glyph indices when rendering using a particular font face.
        /// Also, note that Unicode Variation Selectors provide for alternate mappings for character to glyph.
        /// This call will always return the default variant.
        /// </summary>
        /// <param name="codePoints">An array of UTF-32 code points to obtain nominal glyph indices from.</param>
        /// <returns>Array of nominal glyph indices filled by this function.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ushort[] GetGlyphIndices(uint[] codePoints)
        {
            if (codePoints == null)
            {
                throw new ArgumentNullException(nameof(codePoints));
            }

            ushort[] glyphIndices = new ushort[codePoints.Length];
            this.handle.GetGlyphIndices(codePoints, (uint)codePoints.Length, glyphIndices);
            return glyphIndices;
        }

        /// <summary>
        /// Finds the specified OpenType font table if it exists and returns a pointer to it.
        /// The function accesses the underlying font data via the IDWriteFontFileStream interface
        /// implemented by the font file loader.
        /// </summary>
        /// <param name="openTypeTableTag">Four character tag of table to find.
        /// Use the DWRITE_MAKE_OPENTYPE_TAG() macro to create it.
        /// Unlike GDI, it does not support the special TTCF and null tags to access the whole font.</param>
        /// <param name="tableData">
        /// Pointer to base of table in memory.
        /// The pointer is only valid so long as the FontFace used to get the font table still exists
        /// (not any other FontFace, even if it actually refers to the same physical font).
        /// </param>
        /// <param name="tableSize">Byte size of table.</param>
        /// <param name="tableContext">
        /// Opaque context which must be freed by calling ReleaseFontTable.
        /// The context actually comes from the lower level IDWriteFontFileStream,
        /// which may be implemented by the application or DWrite itself.
        /// It is possible for a NULL tableContext to be returned, especially if
        /// the implementation directly memory maps the whole file.
        /// Nevertheless, always release it later, and do not use it as a test for function success.
        /// The same table can be queried multiple times,
        /// but each returned context can be different, so release each separately.
        /// </param>
        /// <returns>>True if table exists.</returns>
        /// <remarks>
        /// If a table can not be found, the function will not return an error, but the size will be 0, table NULL, and exists = FALSE.
        /// The context does not need to be freed if the table was not found.
        /// The context for the same tag may be different for each call,
        /// so each one must be held and released separately.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetFontTable(uint openTypeTableTag, out IntPtr tableData, out uint tableSize, out IntPtr tableContext)
        {
            this.handle.TryGetFontTable(openTypeTableTag, out tableData, out tableSize, out tableContext, out bool exists);
            return exists;
        }

        /// <summary>
        /// Releases the table obtained earlier from TryGetFontTable.
        /// </summary>
        /// <param name="tableContext">Opaque context from <see cref="TryGetFontTable"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReleaseFontTable(IntPtr tableContext)
        {
            this.handle.ReleaseFontTable(tableContext);
        }

        /// <summary>
        /// Computes the outline of a run of glyphs by calling back to the outline sink interface.
        /// </summary>
        /// <param name="size">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
        /// <param name="glyphIndices">Array of glyph indices.</param>
        /// <param name="glyphAdvances">Optional array of glyph advances in DIPs.</param>
        /// <param name="glyphOffsets">Optional array of glyph offsets.</param>
        /// <param name="isSideways">If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used.
        /// A client can render a vertical run by specifying isSideways = true and rotating the resulting geometry 90 degrees to the
        /// right using a transform.</param>
        /// <param name="isRightToLeft">If true, specifies that the advance direction is right to left. By default, the advance direction
        /// is left to right.</param>
        /// <param name="geometrySink">Interface the function calls back to draw each element of the geometry.</param>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetGlyphRunOutline(float size, ushort[] glyphIndices, float[] glyphAdvances, DWriteGlyphOffset[] glyphOffsets, bool isSideways, bool isRightToLeft, object geometrySink)
        {
            if (glyphIndices == null)
            {
                throw new ArgumentNullException(nameof(glyphIndices));
            }

            if (glyphAdvances != null && glyphAdvances.Length != glyphIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(glyphAdvances));
            }

            if (glyphOffsets != null && glyphOffsets.Length != glyphIndices.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(glyphOffsets));
            }

            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.handle.GetGlyphRunOutline(size, glyphIndices, glyphAdvances, glyphOffsets, (uint)glyphIndices.Length, isSideways, isRightToLeft, geometrySink);
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
            this.handle.GetRecommendedRenderingMode(
                size,
                pixelsPerDip,
                measuringMode,
                renderingParams == null ? null : (IDWriteRenderingParams)renderingParams.Handle,
                out DWriteRenderingMode renderingMode);

            return renderingMode;
        }

        /// <summary>
        /// Obtains design units and common metrics for the font face.
        /// These metrics are applicable to all the glyphs within a font face and are used by applications for layout calculations.
        /// </summary>
        /// <remarks>The metrics returned by this function are in font design units.</remarks>
        /// <param name="size">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
        /// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this 
        /// value is 1.0f. If the DPI is 120, this value is 120.0f/96.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the
        /// scaling specified by the font size and pixelsPerDip.</param>
        /// <returns>A <see cref="DWriteFontMetrics"/> structure.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteFontMetrics GetGdiCompatibleMetrics(float size, float pixelsPerDip, DWriteMatrix? transform)
        {
            DWriteFontMetrics fontFaceMetrics;

            if (transform == null)
            {
                this.handle.GetGdiCompatibleMetrics(size, pixelsPerDip, IntPtr.Zero, out fontFaceMetrics);
            }
            else
            {
                IntPtr transformPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DWriteMatrix)));

                try
                {
                    Marshal.StructureToPtr(transform.Value, transformPtr, false);

                    this.handle.GetGdiCompatibleMetrics(size, pixelsPerDip, transformPtr, out fontFaceMetrics);
                }
                finally
                {
                    Marshal.FreeHGlobal(transformPtr);
                }
            }

            return fontFaceMetrics;
        }

        /// <summary>
        /// Obtains glyph metrics in font design units with the return values compatible with what GDI would produce.
        /// Glyphs metrics are used for positioning of individual glyphs.
        /// </summary>
        /// <param name="size">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
        /// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if the DPI of the rendering surface is 96 this 
        /// value is 1.0f. If the DPI is 120, this value is 120.0f/96.</param>
        /// <param name="transform">Optional transform applied to the glyphs and their positions. This transform is applied after the
        /// scaling specified by the font size and pixelsPerDip.</param>
        /// <param name="useGdiNatural">
        /// When set to FALSE, the metrics are the same as the metrics of GDI aliased text.
        /// When set to TRUE, the metrics are the same as the metrics of text measured by GDI using a font
        /// created with CLEARTYPE_NATURAL_QUALITY.
        /// </param>
        /// <param name="glyphIndices">An array of glyph indices to compute the metrics for.</param>
        /// <param name="glyphCount">The number of elements in the glyphIndices array.</param>
        /// <param name="isSideways">Indicates whether the font is being used in a sideways run.
        /// This can affect the glyph metrics if the font has oblique simulation
        /// because sideways oblique simulation differs from non-sideways oblique simulation.</param>
        /// <remarks>
        /// If any of the input glyph indices are outside of the valid glyph index range
        /// for the current font face, E_INVALIDARG will be returned.
        /// The metrics returned by this function are in font design units.
        /// </remarks>
        /// <returns>Array of DWRITE_GLYPH_METRICS structures filled by this function.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteGlyphMetrics[] GetGdiCompatibleGlyphMetrics(float size, float pixelsPerDip, DWriteMatrix? transform, bool useGdiNatural, ushort[] glyphIndices, bool isSideways)
        {
            if (glyphIndices == null)
            {
                throw new ArgumentNullException(nameof(glyphIndices));
            }

            DWriteGlyphMetrics[] glyphMetrics = new DWriteGlyphMetrics[glyphIndices.Length];

            if (transform == null)
            {
                this.handle.GetGdiCompatibleGlyphMetrics(size, pixelsPerDip, IntPtr.Zero, useGdiNatural, glyphIndices, (uint)glyphIndices.Length, glyphMetrics, isSideways);
            }
            else
            {
                IntPtr transformPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(DWriteMatrix)));

                try
                {
                    Marshal.StructureToPtr(transform.Value, transformPtr, false);

                    this.handle.GetGdiCompatibleGlyphMetrics(size, pixelsPerDip, transformPtr, useGdiNatural, glyphIndices, (uint)glyphIndices.Length, glyphMetrics, isSideways);
                }
                finally
                {
                    Marshal.FreeHGlobal(transformPtr);
                }
            }

            return glyphMetrics;
        }
    }
}
