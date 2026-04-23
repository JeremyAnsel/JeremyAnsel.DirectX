// <copyright file="D2D1Bitmap.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Root bitmap resource, linearly scaled on a draw call.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Bitmap : D2D1Image
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1BitmapGuid = typeof(ID2D1Bitmap).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Bitmap* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Bitmap"/> class.
    /// </summary>
    public D2D1Bitmap(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Bitmap**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Bitmap"/> class.
    /// </summary>
    /// <param name="resource">A resource interface which implements the <c>ID2D1Bitmap</c> interface.</param>
    public static D2D1Bitmap CreateBitmapFromResource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, D2D1BitmapGuid);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Gets the size of the bitmap in resolution independent units.
    /// </summary>
    public D2D1SizeF Size
    {
        get
        {
            int size = D2D1SizeF.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetSize(_comPtr, ptr);
            return D2D1SizeF.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the size of the bitmap in resolution dependent units, (pixels).
    /// </summary>
    public D2D1SizeU PixelSize
    {
        get
        {
            int size = D2D1SizeU.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetPixelSize(_comPtr, ptr);
            return D2D1SizeU.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the format of the bitmap.
    /// </summary>
    public D2D1PixelFormat PixelFormat
    {
        get
        {
            int size = D2D1PixelFormat.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetPixelFormat(_comPtr, ptr);
            return D2D1PixelFormat.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Return the dots per inch (DPI) of the bitmap.
    /// </summary>
    /// <param name="dpiX">The horizontal DPI of the image.</param>
    /// <param name="dpiY">The vertical DPI of the image.</param>
    public void GetDpi(out float dpiX, out float dpiY)
    {
        float x;
        float y;
        _comImpl->GetDpi(_comPtr, &x, &y);
        dpiX = x;
        dpiY = y;
    }

    /// <summary>
    /// Copies the specified region from the specified bitmap into the current bitmap.
    /// </summary>
    /// <param name="srcBitmap">The bitmap to copy from.</param>
    public void CopyFromBitmap(D2D1Bitmap? srcBitmap)
    {
        if (srcBitmap is null)
        {
            throw new ArgumentNullException(nameof(srcBitmap));
        }

        int hr = _comImpl->CopyFromBitmap(_comPtr, null, srcBitmap.Handle, null);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified bitmap into the current bitmap.
    /// </summary>
    /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region is copied.</param>
    /// <param name="srcBitmap">The bitmap to copy from.</param>
    public void CopyFromBitmap(in D2D1Point2U destPoint, D2D1Bitmap? srcBitmap)
    {
        if (srcBitmap is null)
        {
            throw new ArgumentNullException(nameof(srcBitmap));
        }

        int size = D2D1Point2U.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1Point2U.NativeWriteTo((nint)ptr, destPoint);
        int hr = _comImpl->CopyFromBitmap(_comPtr, ptr, srcBitmap.Handle, null);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified bitmap into the current bitmap.
    /// </summary>
    /// <param name="srcBitmap">The bitmap to copy from.</param>
    /// <param name="srcRect">The area of bitmap to copy.</param>
    public void CopyFromBitmap(D2D1Bitmap? srcBitmap, in D2D1RectU srcRect)
    {
        if (srcBitmap is null)
        {
            throw new ArgumentNullException(nameof(srcBitmap));
        }

        int size = D2D1RectU.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectU.NativeWriteTo((nint)ptr, srcRect);
        int hr = _comImpl->CopyFromBitmap(_comPtr, null, srcBitmap.Handle, ptr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified bitmap into the current bitmap.
    /// </summary>
    /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcRect"/> is copied.</param>
    /// <param name="srcBitmap">The bitmap to copy from.</param>
    /// <param name="srcRect">The area of bitmap to copy.</param>
    public void CopyFromBitmap(in D2D1Point2U destPoint, D2D1Bitmap? srcBitmap, in D2D1RectU srcRect)
    {
        if (srcBitmap is null)
        {
            throw new ArgumentNullException(nameof(srcBitmap));
        }

        int destSize = D2D1Point2U.NativeRequiredSize();
        byte* destPtr = stackalloc byte[destSize];
        D2D1Point2U.NativeWriteTo((nint)destPtr, destPoint);
        int srcSize = D2D1RectU.NativeRequiredSize();
        byte* srcPtr = stackalloc byte[srcSize];
        D2D1RectU.NativeWriteTo((nint)srcPtr, srcRect);
        int hr = _comImpl->CopyFromBitmap(_comPtr, destPtr, srcBitmap.Handle, srcPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified render target into the current bitmap.
    /// </summary>
    /// <param name="renderTarget">The render target that contains the region to copy.</param>
    public void CopyFromRenderTarget(D2D1RenderTarget? renderTarget)
    {
        if (renderTarget is null)
        {
            throw new ArgumentNullException(nameof(renderTarget));
        }

        int hr = _comImpl->CopyFromRenderTarget(_comPtr, null, renderTarget.Handle, null);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified render target into the current bitmap.
    /// </summary>
    /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region is copied.</param>
    /// <param name="renderTarget">The render target that contains the region to copy.</param>
    public void CopyFromRenderTarget(in D2D1Point2U destPoint, D2D1RenderTarget? renderTarget)
    {
        if (renderTarget is null)
        {
            throw new ArgumentNullException(nameof(renderTarget));
        }

        int size = D2D1Point2U.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1Point2U.NativeWriteTo((nint)ptr, destPoint);
        int hr = _comImpl->CopyFromRenderTarget(_comPtr, ptr, renderTarget.Handle, null);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified render target into the current bitmap.
    /// </summary>
    /// <param name="renderTarget">The render target that contains the region to copy.</param>
    /// <param name="srcRect">The area of renderTarget to copy.</param>
    public void CopyFromRenderTarget(D2D1RenderTarget? renderTarget, in D2D1RectU srcRect)
    {
        if (renderTarget is null)
        {
            throw new ArgumentNullException(nameof(renderTarget));
        }

        int size = D2D1RectU.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectU.NativeWriteTo((nint)ptr, srcRect);
        int hr = _comImpl->CopyFromRenderTarget(_comPtr, null, renderTarget.Handle, ptr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from the specified render target into the current bitmap.
    /// </summary>
    /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcRect"/> is copied.</param>
    /// <param name="renderTarget">The render target that contains the region to copy.</param>
    /// <param name="srcRect">The area of renderTarget to copy.</param>
    public void CopyFromRenderTarget(in D2D1Point2U destPoint, D2D1RenderTarget? renderTarget, in D2D1RectU srcRect)
    {
        if (renderTarget is null)
        {
            throw new ArgumentNullException(nameof(renderTarget));
        }

        int destSize = D2D1Point2U.NativeRequiredSize();
        byte* destPtr = stackalloc byte[destSize];
        D2D1Point2U.NativeWriteTo((nint)destPtr, destPoint);
        int srcSize = D2D1RectU.NativeRequiredSize();
        byte* srcPtr = stackalloc byte[srcSize];
        D2D1RectU.NativeWriteTo((nint)srcPtr, srcRect);
        int hr = _comImpl->CopyFromRenderTarget(_comPtr, destPtr, renderTarget.Handle, srcPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public void CopyFromMemory(nint srcData, uint pitch)
    {
        int hr = _comImpl->CopyFromMemory(_comPtr, null, (void*)srcData, pitch);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public void CopyFromMemory(byte[]? srcData, uint pitch)
    {
        if (srcData is null)
        {
            throw new ArgumentNullException(nameof(srcData));
        }

        fixed (byte* ptr = srcData)
        {
            int hr = _comImpl->CopyFromMemory(_comPtr, null, ptr, pitch);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public void CopyFromMemory(ReadOnlySpan<byte> srcData, uint pitch)
    {
        if (srcData.Length == 0)
        {
            throw new ArgumentNullException(nameof(srcData));
        }

        fixed (byte* ptr = srcData)
        {
            int hr = _comImpl->CopyFromMemory(_comPtr, null, ptr, pitch);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcData"/> is copied.</param>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public void CopyFromMemory(in D2D1RectU destRect, nint srcData, uint pitch)
    {
        int size = D2D1RectU.NativeRequiredSize();
        byte* destPtr = stackalloc byte[size];
        D2D1RectU.NativeWriteTo((nint)destPtr, destRect);
        int hr = _comImpl->CopyFromMemory(_comPtr, destPtr, (void*)srcData, pitch);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcData"/> is copied.</param>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public void CopyFromMemory(in D2D1RectU destRect, byte[]? srcData, uint pitch)
    {
        if (srcData is null)
        {
            throw new ArgumentNullException(nameof(srcData));
        }

        int size = D2D1RectU.NativeRequiredSize();
        byte* destPtr = stackalloc byte[size];
        D2D1RectU.NativeWriteTo((nint)destPtr, destRect);

        fixed (byte* ptr = srcData)
        {
            int hr = _comImpl->CopyFromMemory(_comPtr, destPtr, ptr, pitch);
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Copies the specified region from memory into the current bitmap.
    /// </summary>
    /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcData"/> is copied.</param>
    /// <param name="srcData">The data to copy.</param>
    /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
    public void CopyFromMemory(in D2D1RectU destRect, ReadOnlySpan<byte> srcData, uint pitch)
    {
        if (srcData.Length == 0)
        {
            throw new ArgumentNullException(nameof(srcData));
        }

        int size = D2D1RectU.NativeRequiredSize();
        byte* destPtr = stackalloc byte[size];
        D2D1RectU.NativeWriteTo((nint)destPtr, destRect);

        fixed (byte* ptr = srcData)
        {
            int hr = _comImpl->CopyFromMemory(_comPtr, destPtr, ptr, pitch);
            Marshal.ThrowExceptionForHR(hr);
        }
    }
}
