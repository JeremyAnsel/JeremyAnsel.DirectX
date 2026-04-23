// <copyright file="ID2D1Bitmap.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Root bitmap resource, linearly scaled on a draw call.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Image"/></remarks>
[Guid("a2296057-ea42-4099-983b-539fb6505426")]
internal unsafe readonly struct ID2D1Bitmap
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Returns the size of the bitmap in resolution independent units.
    /// </summary>
    /// <param name="size">The size of the bitmap in resolution independent units</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetSize;

    /// <summary>
    /// Returns the size of the bitmap in resolution dependent units, (pixels).
    /// </summary>
    /// <param name="size">The size of the bitmap in resolution dependent units.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetPixelSize;

    /// <summary>
    /// Retrieve the format of the bitmap.
    /// </summary>
    /// <param name="pixelFormat">The format of the bitmap.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetPixelFormat;

    /// <summary>
    /// Return the dots per inch (DPI) of the bitmap.
    /// </summary>
    /// <param name="dpiX">The horizontal DPI of the image.</param>
    /// <param name="dpiY">The vertical DPI of the image.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float*, float*, void> GetDpi;

    /// <summary>
    /// Copies the specified region from the specified bitmap into the current bitmap.
    /// </summary>
    /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by srcRect is copied.</param>
    /// <param name="bitmap">The bitmap to copy from.</param>
    /// <param name="srcRect">The area of bitmap to copy.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, void*, int> CopyFromBitmap;

    /// <summary>
    /// Copies the specified region from the specified render target into the current bitmap.
    /// </summary>
    /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by srcRect is copied.</param>
    /// <param name="renderTarget">The render target that contains the region to copy.</param>
    /// <param name="srcRect">The area of renderTarget to copy.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, void*, int> CopyFromRenderTarget;

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by srcData is copied.</param>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in srcData. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, uint, int> CopyFromMemory;
}
