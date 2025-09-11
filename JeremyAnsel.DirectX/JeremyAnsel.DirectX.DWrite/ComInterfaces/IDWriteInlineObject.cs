// <copyright file="IDWriteInlineObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWriteInlineObject interface wraps an application defined inline graphic,
    /// allowing DWrite to query metrics as if it was a glyph inline with the text.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("8339FDE3-106F-47ab-8373-1C6295EB10B3")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteInlineObject
    {
        /// <summary>
        /// The application implemented rendering callback (IDWriteTextRenderer::DrawInlineObject)
        /// can use this to draw the inline object without needing to cast or query the object
        /// type. The text layout does not call this method directly.
        /// </summary>
        /// <param name="clientDrawingContext">The context passed to IDWriteTextLayout::Draw.</param>
        /// <param name="renderer">The renderer passed to IDWriteTextLayout::Draw as the object's containing parent.</param>
        /// <param name="originX">X-coordinate at the top-left corner of the inline object.</param>
        /// <param name="originY">Y-coordinate at the top-left corner of the inline object.</param>
        /// <param name="isSideways">The object should be drawn on its side.</param>
        /// <param name="isRightToLeft">The object is in an right-to-left context and should be drawn flipped.</param>
        /// <param name="clientDrawingEffect">The drawing effect set in IDWriteTextLayout::SetDrawingEffect.</param>
        void Draw(
            [In] IntPtr clientDrawingContext,
            [In] IDWriteTextRenderer? renderer,
            [In] float originX,
            [In] float originY,
            [In, MarshalAs(UnmanagedType.Bool)] bool isSideways,
            [In, MarshalAs(UnmanagedType.Bool)] bool isRightToLeft,
            [In, MarshalAs(UnmanagedType.IUnknown)] object? clientDrawingEffect);

        /// <summary>
        /// TextLayout calls this callback function to get the measurement of the inline object.
        /// </summary>
        /// <param name="metrics">Returned metrics</param>
        void GetMetrics(
            [Out] out DWriteInlineObjectMetrics? metrics);

        /// <summary>
        /// TextLayout calls this callback function to get the visible extents (in DIPs) of the inline object.
        /// In the case of a simple bitmap, with no padding and no overhang, all the overhangs will
        /// simply be zeroes.
        /// </summary>
        /// <param name="overhangs">Overshoot of visible extents (in DIPs) outside the object.</param>
        /// <remarks>
        /// The overhangs should be returned relative to the reported size of the object
        /// (DWRITE_INLINE_OBJECT_METRICS::width/height), and should not be baseline
        /// adjusted. If you have an image that is actually 100x100 DIPs, but you want it
        /// slightly inset (perhaps it has a glow) by 20 DIPs on each side, you would
        /// return a width/height of 60x60 and four overhangs of 20 DIPs.
        /// </remarks>
        void GetOverhangMetrics(
            [Out] out DWriteOverhangMetrics? overhangs);

        /// <summary>
        /// Layout uses this to determine the line breaking behavior of the inline object
        /// amidst the text.
        /// </summary>
        /// <param name="breakConditionBefore">Line-breaking condition between the object and the content immediately preceding it.</param>
        /// <param name="breakConditionAfter" >Line-breaking condition between the object and the content immediately following it.</param>
        void GetBreakConditions(
            [Out] out DWriteBreakCondition breakConditionBefore,
            [Out] out DWriteBreakCondition breakConditionAfter);
    }
}
