// <copyright file="DWriteFontFace.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.DWrite;

/// <summary>
/// The interface that represents an absolute reference to a font face.
/// It contains font face type, appropriate file references and face identification data.
/// Various font data such as metrics, names and glyph outlines is obtained from IDWriteFontFace.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DWriteFontFace : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DWriteFontFaceGuid = typeof(IDWriteFontFace).GUID;

    private readonly nint _comPtr;
    private readonly IDWriteFontFace* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DWriteFontFace"/> class.
    /// </summary>
    public DWriteFontFace(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDWriteFontFace**)comPtr;
    }

    /// <summary>
    /// Gets the file format type of a font face.
    /// </summary>
    public DWriteFontFaceType FaceType
    {
        get { return _comImpl->GetFaceType(_comPtr); }
    }

    /// <summary>
    /// Gets the zero-based index of the font face in its font file or files. If the font files contain a single face,
    /// the return value is zero.
    /// </summary>
    public uint Index
    {
        get { return _comImpl->GetIndex(_comPtr); }
    }

    /// <summary>
    /// Gets the algorithmic style simulation flags of a font face.
    /// </summary>
    public DWriteFontSimulations Simulations
    {
        get { return _comImpl->GetSimulations(_comPtr); }
    }

    /// <summary>
    /// Gets a value indicating whether the font is a symbol font.
    /// </summary>
    public bool IsSymbolFont
    {
        get { return _comImpl->IsSymbolFont(_comPtr) != 0; }
    }

    /// <summary>
    /// Gets the number of glyphs in the font face.
    /// </summary>
    public ushort GlyphCount
    {
        get
        {
            return _comImpl->GetGlyphCount(_comPtr);
        }
    }

    /// <summary>
    /// Obtains the font files count representing a font face.
    /// </summary>
    public uint GetFilesCount()
    {
        uint count = 0;
        int hr = _comImpl->GetFiles(_comPtr, &count, null);
        Marshal.ThrowExceptionForHR(hr);
        return count;
    }

    /// <summary>
    /// Obtains the font files representing a font face.
    /// </summary>
    /// <returns><see cref="DWriteFontFile"/></returns>
    public DWriteFontFile[] GetFiles()
    {
        uint count = GetFilesCount();
        var files = new DWriteFontFile[count];
        GetFiles(files.AsSpan());
        return files;
    }

    /// <summary>
    /// Obtains the font files representing a font face.
    /// </summary>
    /// <returns><see cref="DWriteFontFile"/></returns>
    public void GetFiles(Span<DWriteFontFile> files)
    {
        if (files.Length == 0)
        {
            return;
        }

        uint count = (uint)files.Length;
        nint* ptr = stackalloc nint[files.Length];
        int hr = _comImpl->GetFiles(_comPtr, &count, ptr);
        Marshal.ThrowExceptionForHR(hr);
        for (int i = 0; i < files.Length; i++)
        {
            files[i] = new DWriteFontFile(ptr[i]);
        }
    }

    /// <summary>
    /// Obtains design units and common metrics for the font face.
    /// These metrics are applicable to all the glyphs within a font face and are used by applications for layout calculations.
    /// </summary>
    /// <remarks>The metrics returned by this function are in font design units.</remarks>
    /// <returns><see cref="DWriteFontMetrics"/></returns>
    public DWriteFontMetrics GetMetrics()
    {
        int size = DWriteFontMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        _comImpl->GetMetrics(_comPtr, ptr);
        return DWriteFontMetrics.NativeReadFrom((nint)ptr);
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
    public DWriteGlyphMetrics[] GetDesignGlyphMetrics(ushort[]? glyphIndices, bool isSideways)
    {
        if (glyphIndices is null)
        {
            throw new ArgumentNullException(nameof(glyphIndices));
        }

        DWriteGlyphMetrics[] glyphMetrics = new DWriteGlyphMetrics[glyphIndices.Length];
        GetDesignGlyphMetrics(glyphIndices.AsSpan(), glyphMetrics.AsSpan(), isSideways);
        return glyphMetrics;
    }

    /// <summary>
    /// Obtains ideal glyph metrics in font design units. Design glyphs metrics are used for glyph positioning.
    /// </summary>
    /// <remarks>The metrics returned by this function are in font design units.</remarks>
    /// <param name="glyphIndices">An array of glyph indices to compute the metrics for.</param>
    /// <param name="glyphMetrics">Array of <see cref="DWriteGlyphMetrics"/> structures filled by this function</param>
    /// <param name="isSideways">Indicates whether the font is being used in a sideways run.
    /// This can affect the glyph metrics if the font has oblique simulation
    /// because sideways oblique simulation differs from non-sideways oblique simulation.</param>
    public void GetDesignGlyphMetrics(ReadOnlySpan<ushort> glyphIndices, Span<DWriteGlyphMetrics> glyphMetrics, bool isSideways)
    {
        if (glyphIndices.Length == 0)
        {
            throw new ArgumentNullException(nameof(glyphIndices));
        }

        if (glyphIndices.Length != glyphMetrics.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(glyphMetrics));
        }

        int size = DWriteGlyphMetrics.NativeRequiredSize(glyphMetrics.Length);
        byte* ptr = stackalloc byte[size];

        fixed (ushort* glyphIndicesPtr = glyphIndices)
        {
            int hr = _comImpl->GetDesignGlyphMetrics(_comPtr, glyphIndicesPtr, (uint)glyphMetrics.Length, ptr, isSideways ? 1 : 0);
            Marshal.ThrowExceptionForHR(hr);
            DWriteGlyphMetrics.NativeReadFrom((nint)ptr, glyphMetrics);
        }
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
    public DWriteGlyphMetrics GetDesignGlyphMetrics(ushort glyphIndices, bool isSideways)
    {
        int size = DWriteGlyphMetrics.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetDesignGlyphMetrics(_comPtr, &glyphIndices, 1, ptr, isSideways ? 1 : 0);
        Marshal.ThrowExceptionForHR(hr);
        return DWriteGlyphMetrics.NativeReadFrom((nint)ptr);
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
    public ushort[] GetGlyphIndices(uint[]? codePoints)
    {
        if (codePoints is null)
        {
            throw new ArgumentNullException(nameof(codePoints));
        }

        ushort[] glyphIndices = new ushort[codePoints.Length];
        return glyphIndices;
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
    /// <param name="glyphIndices">Array of nominal glyph indices filled by this function.</param>
    public void GetGlyphIndices(ReadOnlySpan<uint> codePoints, Span<ushort> glyphIndices)
    {
        if (codePoints.Length == 0)
        {
            throw new ArgumentNullException(nameof(codePoints));
        }

        if (codePoints.Length != glyphIndices.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(glyphIndices));
        }

        fixed (uint* codePointsPtr = codePoints)
        fixed (ushort* glyphIndicesPtr = glyphIndices)
        {
            int hr = _comImpl->GetGlyphIndices(_comPtr, codePointsPtr, (uint)codePoints.Length, glyphIndicesPtr);
            Marshal.ThrowExceptionForHR(hr);
        }
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
    public ushort GetGlyphIndices(uint codePoints)
    {
        ushort glyphIndices;
        int hr = _comImpl->GetGlyphIndices(_comPtr, &codePoints, 1, &glyphIndices);
        Marshal.ThrowExceptionForHR(hr);
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
    public bool TryGetFontTable(uint openTypeTableTag, out nint tableData, out uint tableSize, out nint tableContext)
    {
        nint tableDataValue;
        uint tableSizeValue;
        nint tableContextValue;
        int exists;
        int hr = _comImpl->TryGetFontTable(_comPtr, openTypeTableTag, &tableDataValue, &tableSizeValue, &tableContextValue, &exists);
        Marshal.ThrowExceptionForHR(hr);
        tableData = tableDataValue;
        tableSize = tableSizeValue;
        tableContext = tableContextValue;
        return exists != 0;
    }

    /// <summary>
    /// Releases the table obtained earlier from TryGetFontTable.
    /// </summary>
    /// <param name="tableContext">Opaque context from <see cref="TryGetFontTable"/>.</param>
    public void ReleaseFontTable(nint tableContext)
    {
        _comImpl->ReleaseFontTable(_comPtr, tableContext);
    }

    /// <summary>
    /// Computes the outline of a run of glyphs by calling back to the outline sink interface.
    /// </summary>
    /// <param name="size">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
    /// <param name="glyphIndices">Array of glyph indices.</param>
    /// <param name="isSideways">If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used.
    /// A client can render a vertical run by specifying isSideways = true and rotating the resulting geometry 90 degrees to the
    /// right using a transform.</param>
    /// <param name="isRightToLeft">If true, specifies that the advance direction is right to left. By default, the advance direction
    /// is left to right.</param>
    /// <param name="geometrySink">Interface the function calls back to draw each element of the geometry.</param>
    public void GetGlyphRunOutline(float size, ushort[]? glyphIndices, bool isSideways, bool isRightToLeft, nint geometrySink)
    {
        GetGlyphRunOutline(size, glyphIndices.AsSpan(), [], [], isSideways, isRightToLeft, geometrySink);
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
    public void GetGlyphRunOutline(float size, ushort[]? glyphIndices, float[]? glyphAdvances, DWriteGlyphOffset[]? glyphOffsets, bool isSideways, bool isRightToLeft, nint geometrySink)
    {
        GetGlyphRunOutline(size, glyphIndices.AsSpan(), glyphAdvances.AsSpan(), glyphOffsets.AsSpan(), isSideways, isRightToLeft, geometrySink);
    }

    /// <summary>
    /// Computes the outline of a run of glyphs by calling back to the outline sink interface.
    /// </summary>
    /// <param name="size">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
    /// <param name="glyphIndices">Array of glyph indices.</param>
    /// <param name="isSideways">If true, specifies that glyphs are rotated 90 degrees to the left and vertical metrics are used.
    /// A client can render a vertical run by specifying isSideways = true and rotating the resulting geometry 90 degrees to the
    /// right using a transform.</param>
    /// <param name="isRightToLeft">If true, specifies that the advance direction is right to left. By default, the advance direction
    /// is left to right.</param>
    /// <param name="geometrySink">Interface the function calls back to draw each element of the geometry.</param>
    public void GetGlyphRunOutline(float size, ReadOnlySpan<ushort> glyphIndices, bool isSideways, bool isRightToLeft, nint geometrySink)
    {
        GetGlyphRunOutline(size, glyphIndices, [], [], isSideways, isRightToLeft, geometrySink);
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
    public void GetGlyphRunOutline(float size, ReadOnlySpan<ushort> glyphIndices, ReadOnlySpan<float> glyphAdvances, ReadOnlySpan<DWriteGlyphOffset> glyphOffsets, bool isSideways, bool isRightToLeft, nint geometrySink)
    {
        if (glyphIndices.Length == 0)
        {
            throw new ArgumentNullException(nameof(glyphIndices));
        }

        if (glyphAdvances.Length != 0 && glyphAdvances.Length != glyphIndices.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(glyphAdvances));
        }

        if (glyphOffsets.Length != 0 && glyphOffsets.Length != glyphIndices.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(glyphOffsets));
        }

        if (geometrySink == 0)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int glyphOffsetsSize = DWriteGlyphOffset.NativeRequiredSize(glyphOffsets.Length);
        byte* glyphOffsetsPtr = stackalloc byte[glyphOffsetsSize];
        DWriteGlyphOffset.NativeWriteTo((nint)glyphOffsetsPtr, glyphOffsets);

        fixed (ushort* glyphIndicesPtr = glyphIndices)
        fixed (float* glyphAdvancesPtr = glyphAdvances)
        {
            int hr = _comImpl->GetGlyphRunOutline(_comPtr, size, glyphIndicesPtr, glyphAdvancesPtr, glyphOffsetsPtr, (uint)glyphIndices.Length, isSideways ? 1 : 0, isRightToLeft ? 1 : 0, geometrySink);
            Marshal.ThrowExceptionForHR(hr);
        }
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
    /// <returns><see cref="DWriteRenderingMode"/></returns>
    public DWriteRenderingMode GetRecommendedRenderingMode(
        float size,
        float pixelsPerDip,
        DWriteMeasuringMode measuringMode)
    {
        return GetRecommendedRenderingMode(size, pixelsPerDip, measuringMode, null);
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
    public DWriteRenderingMode GetRecommendedRenderingMode(
        float size,
        float pixelsPerDip,
        DWriteMeasuringMode measuringMode,
        DWriteRenderingParams? renderingParams)
    {
        DWriteRenderingMode mode;
        nint renderingParamsPtr = renderingParams is null ? 0 : renderingParams.Handle;
        int hr = _comImpl->GetRecommendedRenderingMode(_comPtr, size, pixelsPerDip, measuringMode, renderingParamsPtr, &mode);
        Marshal.ThrowExceptionForHR(hr);
        return mode;
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
    public DWriteFontMetrics GetGdiCompatibleMetrics(float size, float pixelsPerDip, in DWriteMatrix? transform)
    {
        int fontFaceMetricsSize = DWriteFontMetrics.NativeRequiredSize();
        byte* fontFaceMetricsPtr = stackalloc byte[fontFaceMetricsSize];

        if (transform is null)
        {
            int hr = _comImpl->GetGdiCompatibleMetrics(_comPtr, size, pixelsPerDip, null, fontFaceMetricsPtr);
            Marshal.ThrowExceptionForHR(hr);
        }
        else
        {
            int transformSize = DWriteMatrix.NativeRequiredSize();
            byte* transformPtr = stackalloc byte[transformSize];
            DWriteMatrix.NativeWriteTo((nint)transformPtr, transform.Value);
            int hr = _comImpl->GetGdiCompatibleMetrics(_comPtr, size, pixelsPerDip, transformPtr, fontFaceMetricsPtr);
            Marshal.ThrowExceptionForHR(hr);
        }

        return DWriteFontMetrics.NativeReadFrom((nint)fontFaceMetricsPtr);
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
    /// <param name="isSideways">Indicates whether the font is being used in a sideways run.
    /// This can affect the glyph metrics if the font has oblique simulation
    /// because sideways oblique simulation differs from non-sideways oblique simulation.</param>
    /// <remarks>
    /// If any of the input glyph indices are outside of the valid glyph index range
    /// for the current font face, E_INVALIDARG will be returned.
    /// The metrics returned by this function are in font design units.
    /// </remarks>
    /// <returns>Array of DWRITE_GLYPH_METRICS structures filled by this function.</returns>
    public DWriteGlyphMetrics[] GetGdiCompatibleGlyphMetrics(float size, float pixelsPerDip, DWriteMatrix? transform, bool useGdiNatural, ushort[]? glyphIndices, bool isSideways)
    {
        if (glyphIndices is null)
        {
            throw new ArgumentNullException(nameof(glyphIndices));
        }

        DWriteGlyphMetrics[] glyphMetrics = new DWriteGlyphMetrics[glyphIndices.Length];
        GetGdiCompatibleGlyphMetrics(size, pixelsPerDip, transform, useGdiNatural, glyphIndices.AsSpan(), isSideways, glyphMetrics.AsSpan());
        return glyphMetrics;
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
    /// <param name="isSideways">Indicates whether the font is being used in a sideways run.
    /// This can affect the glyph metrics if the font has oblique simulation
    /// because sideways oblique simulation differs from non-sideways oblique simulation.</param>
    /// <param name="glyphMetrics">Array of DWRITE_GLYPH_METRICS structures filled by this function.</param>
    /// <remarks>
    /// If any of the input glyph indices are outside of the valid glyph index range
    /// for the current font face, E_INVALIDARG will be returned.
    /// The metrics returned by this function are in font design units.
    /// </remarks>
    public void GetGdiCompatibleGlyphMetrics(float size, float pixelsPerDip, DWriteMatrix? transform, bool useGdiNatural, ReadOnlySpan<ushort> glyphIndices, bool isSideways, Span<DWriteGlyphMetrics> glyphMetrics)
    {
        if (glyphIndices.Length == 0)
        {
            throw new ArgumentNullException(nameof(glyphIndices));
        }

        if (glyphMetrics.Length != glyphIndices.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(glyphMetrics));
        }

        int glyphMetricsSize = DWriteGlyphMetrics.NativeRequiredSize(glyphMetrics.Length);
        byte* glyphMetricsPtr = stackalloc byte[glyphMetricsSize];

        if (transform is null)
        {
            fixed (ushort* glyphIndicesPtr = glyphIndices)
            {
                int hr = _comImpl->GetGdiCompatibleGlyphMetrics(_comPtr, size, pixelsPerDip, null, useGdiNatural ? 1 : 0, glyphIndicesPtr, (uint)glyphIndices.Length, glyphMetricsPtr, isSideways ? 1 : 0);
                Marshal.ThrowExceptionForHR(hr);
            }
        }
        else
        {
            int transformSize = DWriteMatrix.NativeRequiredSize();
            byte* transformPtr = stackalloc byte[transformSize];
            DWriteMatrix.NativeWriteTo((nint)transformPtr, transform.Value);

            fixed (ushort* glyphIndicesPtr = glyphIndices)
            {
                int hr = _comImpl->GetGdiCompatibleGlyphMetrics(_comPtr, size, pixelsPerDip, transformPtr, useGdiNatural ? 1 : 0, glyphIndicesPtr, (uint)glyphIndices.Length, glyphMetricsPtr, isSideways ? 1 : 0);
                Marshal.ThrowExceptionForHR(hr);
            }
        }

        DWriteGlyphMetrics.NativeReadFrom((nint)glyphMetricsPtr, glyphMetrics);
    }
}
