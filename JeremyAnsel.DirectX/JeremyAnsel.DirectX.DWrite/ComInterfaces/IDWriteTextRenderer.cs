// <copyright file="IDWriteTextRenderer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteTextRenderer interface represents a set of application-defined
    /// callbacks that perform rendering of text, inline objects, and decorations
    /// such as underlines.
    /// </summary>
    /// <remarks>Inherited from <see cref="IDWritePixelSnapping"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("ef8a8135-5cc6-45fe-8825-c5a0724eb819")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteTextRenderer
    {
        /// <summary>
        /// Determines whether pixel snapping is disabled. The recommended default is FALSE,
        /// unless doing animation that requires subpixel vertical placement.
        /// </summary>
        /// <param name="clientDrawingContext">The context passed to <see cref="IDWriteTextLayout.Draw"/>.</param>
        /// <param name="isDisabled">Receives TRUE if pixel snapping is disabled or FALSE if it not.</param>
        void IsPixelSnappingDisabled(
            [In] IntPtr clientDrawingContext,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool isDisabled);

        /// <summary>
        /// Gets the current transform that maps abstract coordinates to DIPs,
        /// which may disable pixel snapping upon any rotation or shear.
        /// </summary>
        /// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
        /// <param name="transform">Receives the transform.</param>
        void GetCurrentTransform(
            [In] IntPtr clientDrawingContext,
            [Out] out DWriteMatrix transform);

        /// <summary>
        /// Gets the number of physical pixels per DIP. A DIP (device-independent pixel) is 1/96 inch,
        /// so the pixelsPerDip value is the number of logical pixels per inch divided by 96 (yielding
        /// a value of 1 for 96 DPI and 1.25 for 120).
        /// </summary>
        /// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
        /// <param name="pixelsPerDip">Receives the number of physical pixels per DIP.</param>
        void GetPixelsPerDip(
            [In] IntPtr clientDrawingContext,
            [Out] out float pixelsPerDip);

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
        void DrawGlyphRun(
            [In] IntPtr clientDrawingContext,
            [In] float baselineOriginX,
            [In] float baselineOriginY,
            [In] DWriteMeasuringMode measuringMode,
            [In] ref DWriteGlyphRun glyphRun,
            [In] ref DWriteGlyphRunDescription glyphRunDescription,
            [In, MarshalAs(UnmanagedType.IUnknown)] object clientDrawingEffect);

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
        void DrawUnderline(
            [In] IntPtr clientDrawingContext,
            [In] float baselineOriginX,
            [In] float baselineOriginY,
            [In] ref DWriteUnderline underline,
            [In, MarshalAs(UnmanagedType.IUnknown)] object clientDrawingEffect);

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
        void DrawStrikethrough(
            [In] IntPtr clientDrawingContext,
            [In] float baselineOriginX,
            [In] float baselineOriginY,
            [In] ref DWriteStrikethrough strikethrough,
            [In, MarshalAs(UnmanagedType.IUnknown)] object clientDrawingEffect);

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
        void DrawInlineObject(
            [In] IntPtr clientDrawingContext,
            [In] float originX,
            [In] float originY,
            [In] IDWriteInlineObject inlineObject,
            [In, MarshalAs(UnmanagedType.Bool)] bool isSideways,
            [In, MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
            [In, MarshalAs(UnmanagedType.IUnknown)] object clientDrawingEffect);
    }
}
