// <copyright file="ID2D1Bitmap.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Root bitmap resource, linearly scaled on a draw call.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Image"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("a2296057-ea42-4099-983b-539fb6505426")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1Bitmap
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory factory);

        /// <summary>
        /// Returns the size of the bitmap in resolution independent units.
        /// </summary>
        /// <returns><see cref="D2D1SizeF"/></returns>
        [PreserveSig]
        D2D1SizeF GetSize();

        /// <summary>
        /// Returns the size of the bitmap in resolution dependent units, (pixels).
        /// </summary>
        /// <returns><see cref="D2D1SizeU"/></returns>
        [PreserveSig]
        D2D1SizeU GetPixelSize();

        /// <summary>
        /// Retrieve the format of the bitmap.
        /// </summary>
        /// <returns><see cref="D2D1PixelFormat"/></returns>
        [PreserveSig]
        D2D1PixelFormat GetPixelFormat();

        /// <summary>
        /// Return the dots per inch (DPI) of the bitmap.
        /// </summary>
        /// <param name="dpiX">The horizontal DPI of the image.</param>
        /// <param name="dpiY">The vertical DPI of the image.</param>
        [PreserveSig]
        void GetDpi(
            [Out] out float dpiX,
            [Out] out float dpiY);

        /// <summary>
        /// Copies the specified region from the specified bitmap into the current bitmap.
        /// </summary>
        /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcRect"/> is copied.</param>
        /// <param name="bitmap">The bitmap to copy from.</param>
        /// <param name="srcRect">The area of bitmap to copy.</param>
        void CopyFromBitmap(
            [In] IntPtr destPoint,
            [In] ID2D1Bitmap bitmap,
            [In] IntPtr srcRect);

        /// <summary>
        /// Copies the specified region from the specified render target into the current bitmap.
        /// </summary>
        /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcRect"/> is copied.</param>
        /// <param name="renderTarget">The render target that contains the region to copy.</param>
        /// <param name="srcRect">The area of renderTarget to copy.</param>
        void CopyFromRenderTarget(
            [In] IntPtr destPoint,
            [In] ID2D1RenderTarget renderTarget,
            [In] IntPtr srcRect);

        /// <summary>
        /// Copies the specified region from memory into the current bitmap.
        /// </summary>
        /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcData"/> is copied.</param>
        /// <param name="srcData">The data to copy.</param>
        /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
        void CopyFromMemory(
            [In] IntPtr destRect,
            [In] IntPtr srcData,
            [In] uint pitch);
    }
}
