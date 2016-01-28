// <copyright file="IDWritePixelSnapping.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.DWrite.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// The IDWritePixelSnapping interface defines the pixel snapping properties of a text renderer.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("eaf3a2da-ecf4-4d24-b644-b34f6842024b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IDWritePixelSnapping
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
    }
}
