// <copyright file="IDWriteTextRenderer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces;

/// <summary>
/// The IDWriteTextRenderer interface represents a set of application-defined
/// callbacks that perform rendering of text, inline objects, and decorations
/// such as underlines.
/// </summary>
/// <remarks>Inherited from <see cref="IDWritePixelSnapping"/></remarks>
[Guid("ef8a8135-5cc6-45fe-8825-c5a0724eb819")]
internal unsafe readonly struct IDWriteTextRenderer
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint IsPixelSnappingDisabled;
    private readonly nint GetCurrentTransform;
    private readonly nint GetPixelsPerDip;

    /// <summary>
    /// IDWriteTextLayout::Draw calls this function to instruct the client to
    /// render a run of glyphs.
    /// </summary>
    /// <param name="clientDrawingContext">The context passed to 
    /// IDWriteTextLayout::Draw.</param>
    /// <param name="baselineOriginX">X-coordinate of the baseline.</param>
    /// <param name="baselineOriginY">Y-coordinate of the baseline.</param>
    /// <param name="measuringMode">Specifies measuring mode for glyphs in the run.
    /// Renderer implementations may choose different rendering modes for given measuring modes,
    /// but best results are seen when the rendering mode matches the corresponding measuring mode:
    /// DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL
    /// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC
    /// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL
    /// </param>
    /// <param name="glyphRun">The glyph run to draw.</param>
    /// <param name="glyphRunDescription">Properties of the characters 
    /// associated with this run.</param>
    /// <param name="clientDrawingEffect">The drawing effect set in
    /// IDWriteTextLayout::SetDrawingEffect.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float, float, DWriteMeasuringMode, void*, void*, nint, int> DrawGlyphRun;

    /// <summary>
    /// <see cref="IDWriteTextLayout.Draw"/> calls this function to instruct the client to draw
    /// an underline.
    /// </summary>
    /// <param name="clientDrawingContext">The context passed to 
    /// <see cref="IDWriteTextLayout.Draw"/>.</param>
    /// <param name="baselineOriginX">X-coordinate of the baseline.</param>
    /// <param name="baselineOriginY">Y-coordinate of the baseline.</param>
    /// <param name="underline">Underline logical information.</param>
    /// <param name="clientDrawingEffect">The drawing effect set in
    /// <see cref="IDWriteTextLayout.SetDrawingEffect"/>.</param>
    /// <remarks>
    /// A single underline can be broken into multiple calls, depending on
    /// how the formatting changes attributes. If font sizes/styles change
    /// within an underline, the thickness and offset will be averaged
    /// weighted according to characters.
    /// To get the correct top coordinate of the underline rectangle, add <c>underline::offset</c>
    /// to the baseline's Y. Otherwise the underline will be immediately under the text.
    /// The x coordinate will always be passed as the left side, regardless
    /// of text directionality. This simplifies drawing and reduces the
    /// problem of round-off that could potentially cause gaps or a double
    /// stamped alpha blend. To avoid alpha overlap, round the end points
    /// to the nearest device pixel.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float, float, void*, nint, int> DrawUnderline;

    /// <summary>
    /// <see cref="IDWriteTextLayout.Draw"/> calls this function to instruct the client to draw
    /// a strikethrough.
    /// </summary>
    /// <param name="clientDrawingContext">The context passed to 
    /// <see cref="IDWriteTextLayout.Draw"/>.</param>
    /// <param name="baselineOriginX">X-coordinate of the baseline.</param>
    /// <param name="baselineOriginY">Y-coordinate of the baseline.</param>
    /// <param name="strikethrough">Strikethrough logical information.</param>
    /// <param name="clientDrawingEffect">The drawing effect set in
    /// <see cref="IDWriteTextLayout.SetDrawingEffect"/>.</param>
    /// <remarks>
    /// A single strikethrough can be broken into multiple calls, depending on
    /// how the formatting changes attributes. Strikethrough is not averaged
    /// across font sizes/styles changes.
    /// To get the correct top coordinate of the strikethrough rectangle,
    /// add <c>strikethrough::offset</c> to the baseline's Y.
    /// Like underlines, the x coordinate will always be passed as the left side,
    /// regardless of text directionality.
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float, float, void*, nint, int> DrawStrikethrough;

    /// <summary>
    /// <see cref="IDWriteTextLayout.Draw"/> calls this application callback when it needs to
    /// draw an inline object.
    /// </summary>
    /// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
    /// <param name="originX">X-coordinate at the top-left corner of the inline object.</param>
    /// <param name="originY">Y-coordinate at the top-left corner of the inline object.</param>
    /// <param name="inlineObject">The object set using IDWriteTextLayout::SetInlineObject.</param>
    /// <param name="isSideways">The object should be drawn on its side.</param>
    /// <param name="isRightToLeft">The object is in an right-to-left context and should be drawn flipped.</param>
    /// <param name="clientDrawingEffect">The drawing effect set in
    /// <see cref="IDWriteTextLayout.SetDrawingEffect"/>.</param>
    /// <remarks>
    /// The right-to-left flag is a hint for those cases where it would look
    /// strange for the image to be shown normally (like an arrow pointing to
    /// right to indicate a submenu).
    /// </remarks>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, float, float, nint, int, int, nint, int> DrawInlineObject;
}
