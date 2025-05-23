﻿// <copyright file="D2D1Bitmap.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Root bitmap resource, linearly scaled on a draw call.
    /// </summary>
    public sealed class D2D1Bitmap : D2D1Image
    {
        /// <summary>
        /// The D2D1 bitmap interface.
        /// </summary>
        private readonly ID2D1Bitmap bitmap;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Bitmap"/> class.
        /// </summary>
        /// <param name="resource">A resource interface which implements the <c>ID2D1Bitmap</c> interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap(object resource)
        {
            IntPtr ptr = Marshal.GetIUnknownForObject(resource);

            try
            {
                this.bitmap = (ID2D1Bitmap)Marshal.GetObjectForIUnknown(ptr);
            }
            finally
            {
                Marshal.Release(ptr);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Bitmap"/> class.
        /// </summary>
        /// <param name="bitmap">A D2D1 bitmap interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Bitmap(ID2D1Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.bitmap; }
        }

        /// <summary>
        /// Gets the size of the bitmap in resolution independent units.
        /// </summary>
        public D2D1SizeF Size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.bitmap.GetSize(out D2D1SizeF size);
                return size;
            }
        }

        /// <summary>
        /// Gets the size of the bitmap in resolution dependent units, (pixels).
        /// </summary>
        public D2D1SizeU PixelSize
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.bitmap.GetPixelSize(out D2D1SizeU size);
                return size;
            }
        }

        /// <summary>
        /// Gets the format of the bitmap.
        /// </summary>
        public D2D1PixelFormat PixelFormat
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.bitmap.GetPixelFormat(out D2D1PixelFormat pixelFormat);
                return pixelFormat;
            }
        }

        /// <summary>
        /// Return the dots per inch (DPI) of the bitmap.
        /// </summary>
        /// <param name="dpiX">The horizontal DPI of the image.</param>
        /// <param name="dpiY">The vertical DPI of the image.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetDpi(out float dpiX, out float dpiY)
        {
            this.bitmap.GetDpi(out dpiX, out dpiY);
        }

        /// <summary>
        /// Copies the specified region from the specified bitmap into the current bitmap.
        /// </summary>
        /// <param name="srcBitmap">The bitmap to copy from.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromBitmap(D2D1Bitmap srcBitmap)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException(nameof(srcBitmap));
            }

            this.bitmap.CopyFromBitmap(IntPtr.Zero, srcBitmap.bitmap, IntPtr.Zero);
        }

        /// <summary>
        /// Copies the specified region from the specified bitmap into the current bitmap.
        /// </summary>
        /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region is copied.</param>
        /// <param name="srcBitmap">The bitmap to copy from.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromBitmap(D2D1Point2U destPoint, D2D1Bitmap srcBitmap)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException(nameof(srcBitmap));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Point2U)));

            try
            {
                Marshal.StructureToPtr(destPoint, ptr, false);

                this.bitmap.CopyFromBitmap(ptr, srcBitmap.bitmap, IntPtr.Zero);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Copies the specified region from the specified bitmap into the current bitmap.
        /// </summary>
        /// <param name="srcBitmap">The bitmap to copy from.</param>
        /// <param name="srcRect">The area of bitmap to copy.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromBitmap(D2D1Bitmap srcBitmap, D2D1RectU srcRect)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException(nameof(srcBitmap));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1RectU)));

            try
            {
                Marshal.StructureToPtr(srcRect, ptr, false);

                this.bitmap.CopyFromBitmap(IntPtr.Zero, srcBitmap.bitmap, ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Copies the specified region from the specified bitmap into the current bitmap.
        /// </summary>
        /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcRect"/> is copied.</param>
        /// <param name="srcBitmap">The bitmap to copy from.</param>
        /// <param name="srcRect">The area of bitmap to copy.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromBitmap(D2D1Point2U destPoint, D2D1Bitmap srcBitmap, D2D1RectU srcRect)
        {
            if (srcBitmap == null)
            {
                throw new ArgumentNullException(nameof(srcBitmap));
            }

            IntPtr destPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Point2U)));
            IntPtr srcPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1RectU)));

            try
            {
                Marshal.StructureToPtr(destPoint, destPtr, false);
                Marshal.StructureToPtr(srcRect, srcPtr, false);

                this.bitmap.CopyFromBitmap(destPtr, srcBitmap.bitmap, srcPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(destPtr);
                Marshal.FreeHGlobal(srcPtr);
            }
        }

        /// <summary>
        /// Copies the specified region from the specified render target into the current bitmap.
        /// </summary>
        /// <param name="renderTarget">The render target that contains the region to copy.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromRenderTarget(D2D1RenderTarget renderTarget)
        {
            if (renderTarget == null)
            {
                throw new ArgumentNullException(nameof(renderTarget));
            }

            this.bitmap.CopyFromRenderTarget(IntPtr.Zero, renderTarget.GetHandle<ID2D1RenderTarget>(), IntPtr.Zero);
        }

        /// <summary>
        /// Copies the specified region from the specified render target into the current bitmap.
        /// </summary>
        /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region is copied.</param>
        /// <param name="renderTarget">The render target that contains the region to copy.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromRenderTarget(D2D1Point2U destPoint, D2D1RenderTarget renderTarget)
        {
            if (renderTarget == null)
            {
                throw new ArgumentNullException(nameof(renderTarget));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Point2U)));

            try
            {
                Marshal.StructureToPtr(destPoint, ptr, false);

                this.bitmap.CopyFromRenderTarget(ptr, renderTarget.GetHandle<ID2D1RenderTarget>(), IntPtr.Zero);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Copies the specified region from the specified render target into the current bitmap.
        /// </summary>
        /// <param name="renderTarget">The render target that contains the region to copy.</param>
        /// <param name="srcRect">The area of renderTarget to copy.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromRenderTarget(D2D1RenderTarget renderTarget, D2D1RectU srcRect)
        {
            if (renderTarget == null)
            {
                throw new ArgumentNullException(nameof(renderTarget));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1RectU)));

            try
            {
                Marshal.StructureToPtr(srcRect, ptr, false);

                this.bitmap.CopyFromRenderTarget(IntPtr.Zero, renderTarget.GetHandle<ID2D1RenderTarget>(), ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Copies the specified region from the specified render target into the current bitmap.
        /// </summary>
        /// <param name="destPoint">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcRect"/> is copied.</param>
        /// <param name="renderTarget">The render target that contains the region to copy.</param>
        /// <param name="srcRect">The area of renderTarget to copy.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromRenderTarget(D2D1Point2U destPoint, D2D1RenderTarget renderTarget, D2D1RectU srcRect)
        {
            if (renderTarget == null)
            {
                throw new ArgumentNullException(nameof(renderTarget));
            }

            IntPtr destPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Point2U)));
            IntPtr srcPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1RectU)));

            try
            {
                Marshal.StructureToPtr(destPoint, destPtr, false);
                Marshal.StructureToPtr(srcRect, srcPtr, false);

                this.bitmap.CopyFromRenderTarget(destPtr, renderTarget.GetHandle<ID2D1RenderTarget>(), srcPtr);
            }
            finally
            {
                Marshal.FreeHGlobal(destPtr);
                Marshal.FreeHGlobal(srcPtr);
            }
        }

        /// <summary>
        /// Copies the specified region from memory into the current bitmap.
        /// </summary>
        /// <param name="srcData">The data to copy.</param>
        /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromMemory(IntPtr srcData, uint pitch)
        {
            this.bitmap.CopyFromMemory(IntPtr.Zero, srcData, pitch);
        }

        /// <summary>
        /// Copies the specified region from memory into the current bitmap.
        /// </summary>
        /// <param name="srcData">The data to copy.</param>
        /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromMemory(byte[] srcData, uint pitch)
        {
            if (srcData == null)
            {
                throw new ArgumentNullException(nameof(srcData));
            }

            this.bitmap.CopyFromMemory(IntPtr.Zero, Marshal.UnsafeAddrOfPinnedArrayElement(srcData, 0), pitch);
        }

        /// <summary>
        /// Copies the specified region from memory into the current bitmap.
        /// </summary>
        /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcData"/> is copied.</param>
        /// <param name="srcData">The data to copy.</param>
        /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromMemory(D2D1RectU destRect, IntPtr srcData, uint pitch)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1RectU)));

            try
            {
                Marshal.StructureToPtr(destRect, ptr, false);

                this.bitmap.CopyFromMemory(ptr, srcData, pitch);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Copies the specified region from memory into the current bitmap.
        /// </summary>
        /// <param name="destRect">In the current bitmap, the upper-left corner of the area to which the region specified by <paramref name="srcData"/> is copied.</param>
        /// <param name="srcData">The data to copy.</param>
        /// <param name="pitch">The stride, or pitch, of the source bitmap stored in <paramref name="srcData"/>. The stride is the byte count of a scanline (one row of pixels in memory). The stride can be computed from the following formula: <c>pixel width * bytes per pixel + memory padding</c>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CopyFromMemory(D2D1RectU destRect, byte[] srcData, uint pitch)
        {
            if (srcData == null)
            {
                throw new ArgumentNullException(nameof(srcData));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1RectU)));

            try
            {
                Marshal.StructureToPtr(destRect, ptr, false);

                this.bitmap.CopyFromMemory(ptr, Marshal.UnsafeAddrOfPinnedArrayElement(srcData, 0), pitch);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
