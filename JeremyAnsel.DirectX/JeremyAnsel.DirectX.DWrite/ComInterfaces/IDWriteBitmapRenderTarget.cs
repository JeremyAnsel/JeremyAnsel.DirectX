// <copyright file="IDWriteBitmapRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Encapsulates a 32-bit device independent bitmap and device context, which can be used for rendering glyphs.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("5e5a32a3-8dff-4773-9ff6-0696eab77267")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWriteBitmapRenderTarget
    {
        /// <summary>
        /// Draws a run of glyphs to the bitmap.
        /// </summary>
        /// <param name="baselineOriginX">Horizontal position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</param>
        /// <param name="baselineOriginY">Vertical position of the baseline origin, in DIPs, relative to the upper-left corner of the DIB.</param>
        /// <param name="measuringMode">Specifies measuring mode for glyphs in the run.
        /// Renderer implementations may choose different rendering modes for different measuring modes, for example
        /// DWRITE_RENDERING_MODE_CLEARTYPE_NATURAL for DWRITE_MEASURING_MODE_NATURAL,
        /// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_CLASSIC for DWRITE_MEASURING_MODE_GDI_CLASSIC, and
        /// DWRITE_RENDERING_MODE_CLEARTYPE_GDI_NATURAL for DWRITE_MEASURING_MODE_GDI_NATURAL.
        /// </param>
        /// <param name="glyphRun">Structure containing the properties of the glyph run.</param>
        /// <param name="renderingParams">Object that controls rendering behavior.</param>
        /// <param name="textColor">Specifies the foreground color of the text.</param>
        /// <param name="blackBoxRect">Optional rectangle that receives the bounding box (in pixels not DIPs) of all the pixels affected by 
        /// drawing the glyph run. The black box rectangle may extend beyond the dimensions of the bitmap.</param>
        void DrawGlyphRun(
            [In] float baselineOriginX,
            [In] float baselineOriginY,
            [In] DWriteMeasuringMode measuringMode,
            [In] ref DWriteGlyphRun glyphRun,
            [In] IDWriteRenderingParams renderingParams,
            [In] uint textColor,
            [Out] out DWriteRect blackBoxRect);

        /// <summary>
        /// Gets a handle to the memory device context.
        /// </summary>
        /// <returns>
        /// Returns the device context handle.
        /// </returns>
        /// <remarks>
        /// An application can use the device context to draw using GDI functions. An application can obtain the bitmap handle
        /// (HBITMAP) by calling GetCurrentObject. An application that wants information about the underlying bitmap, including
        /// a pointer to the pixel data, can call GetObject to fill in a DIBSECTION structure. The bitmap is always a 32-bit 
        /// top-down DIB.
        /// </remarks>
        [PreserveSig]
        IntPtr GetMemoryDC();

        /// <summary>
        /// Gets the number of bitmap pixels per DIP. A DIP (device-independent pixel) is 1/96 inch so this value is the number
        /// if pixels per inch divided by 96.
        /// </summary>
        /// <returns>
        /// Returns the number of bitmap pixels per DIP.
        /// </returns>
        [PreserveSig]
        float GetPixelsPerDip();

        /// <summary>
        /// Sets the number of bitmap pixels per DIP. A DIP (device-independent pixel) is 1/96 inch so this value is the number
        /// if pixels per inch divided by 96.
        /// </summary>
        /// <param name="pixelsPerDip">Specifies the number of pixels per DIP.</param>
        void SetPixelsPerDip(
            [In] float pixelsPerDip);

        /// <summary>
        /// Gets the transform that maps abstract coordinate to DIPs. By default this is the identity 
        /// transform. Note that this is unrelated to the world transform of the underlying device
        /// context.
        /// </summary>
        /// <param name="transform">Receives the transform.</param>
        void GetCurrentTransform(
            [Out] out DWriteMatrix transform);

        /// <summary>
        /// Sets the transform that maps abstract coordinate to DIPs. This does not affect the world
        /// transform of the underlying device context.
        /// </summary>
        /// <param name="transform">Specifies the new transform. This parameter can be NULL, in which
        /// case the identity transform is implied.</param>
        void SetCurrentTransform(
            [In] ref DWriteMatrix transform);

        /// <summary>
        /// Gets the dimensions of the bitmap.
        /// </summary>
        /// <param name="size">Receives the size of the bitmap in pixels.</param>
        void GetSize(
            [Out] out DWriteSize size);

        /// <summary>
        /// Resizes the bitmap.
        /// </summary>
        /// <param name="width">New bitmap width, in pixels.</param>
        /// <param name="height">New bitmap height, in pixels.</param>
        void Resize(
            [In] uint width,
            [In] uint height);
    }
}
