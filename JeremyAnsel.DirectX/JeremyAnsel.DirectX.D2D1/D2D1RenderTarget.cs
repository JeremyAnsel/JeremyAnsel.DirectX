// <copyright file="D2D1RenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;
    using JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;
    using JeremyAnsel.DirectX.DWrite;

    /// <summary>
    /// Represents an object that can receive drawing commands.
    /// </summary>
    public abstract class D2D1RenderTarget : D2D1Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RenderTarget"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1RenderTarget()
        {
        }

        /// <summary>
        /// Gets or sets the current transform of the render target.
        /// </summary>
        public D2D1Matrix3X2F Transform
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.GetHandle<ID2D1RenderTarget>().GetTransform(out D2D1Matrix3X2F transform);
                return transform;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set
            {
                this.GetHandle<ID2D1RenderTarget>().SetTransform(ref value);
            }
        }

        /// <summary>
        /// Gets or sets the current antialiasing mode for nontext drawing operations.
        /// </summary>
        public D2D1AntialiasMode AntialiasMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.GetHandle<ID2D1RenderTarget>().GetAntialiasMode(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.GetHandle<ID2D1RenderTarget>().SetAntialiasMode(value); }
        }

        /// <summary>
        /// Gets or sets the current antialiasing mode for text and glyph drawing operations.
        /// </summary>
        public D2D1TextAntialiasMode TextAntialiasMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.GetHandle<ID2D1RenderTarget>().GetTextAntialiasMode(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.GetHandle<ID2D1RenderTarget>().SetTextAntialiasMode(value); }
        }

        /// <summary>
        /// Gets the pixel format and alpha mode of the render target.
        /// </summary>
        public D2D1PixelFormat PixelFormat
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.GetHandle<ID2D1RenderTarget>().GetPixelFormat(); }
        }

        /// <summary>
        /// Gets the size of the render target in device-independent pixels.
        /// </summary>
        public D2D1SizeF Size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.GetHandle<ID2D1RenderTarget>().GetSize(out D2D1SizeF size);
                return size;
            }
        }

        /// <summary>
        /// Gets the size of the render target in device pixels.
        /// </summary>
        public D2D1SizeU PixelSize
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.GetHandle<ID2D1RenderTarget>().GetPixelSize(out D2D1SizeU size);
                return size;
            }
        }

        /// <summary>
        /// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
        /// </summary>
        public uint MaximumBitmapSize
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.GetHandle<ID2D1RenderTarget>().GetMaximumBitmapSize(); }
        }

        /// <summary>
        /// Creates a Direct2D bitmap from a pointer to in-memory source data.
        /// </summary>
        /// <param name="size">The dimension of the bitmap to create in pixels.</param>
        /// <param name="srcData">A pointer to the memory location of the image data, or NULL to create an uninitialized bitmap.</param>
        /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If <paramref name="srcData"/> is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
        /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateBitmap(D2D1SizeU size, IntPtr srcData, uint pitch, D2D1BitmapProperties bitmapProperties)
        {
            this.GetHandle<ID2D1RenderTarget>().CreateBitmap(size, srcData, pitch, ref bitmapProperties, out ID2D1Bitmap bitmap);

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates a Direct2D bitmap from a pointer to in-memory source data.
        /// </summary>
        /// <param name="size">The dimension of the bitmap to create in pixels.</param>
        /// <param name="srcData">The image data, or null to create an uninitialized bitmap.</param>
        /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If <paramref name="srcData"/> is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
        /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateBitmap(D2D1SizeU size, byte[] srcData, uint pitch, D2D1BitmapProperties bitmapProperties)
        {
            this.GetHandle<ID2D1RenderTarget>().CreateBitmap(size, srcData == null ? IntPtr.Zero : Marshal.UnsafeAddrOfPinnedArrayElement(srcData, 0), pitch, ref bitmapProperties, out ID2D1Bitmap bitmap);

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates a Direct2D bitmap from a pointer to in-memory source data.
        /// </summary>
        /// <param name="size">The dimension of the bitmap to create in pixels.</param>
        /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateBitmap(D2D1SizeU size, D2D1BitmapProperties bitmapProperties)
        {
            this.GetHandle<ID2D1RenderTarget>().CreateBitmap(size, IntPtr.Zero, 0U, ref bitmapProperties, out ID2D1Bitmap bitmap);

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates an <see cref="D2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
        /// </summary>
        /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateBitmapFromWicBitmap(object wicBitmapSource)
        {
            if (wicBitmapSource == null)
            {
                throw new ArgumentNullException(nameof(wicBitmapSource));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateBitmapFromWicBitmap((IWICBitmapSource)wicBitmapSource, IntPtr.Zero, out ID2D1Bitmap bitmap);

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates an <see cref="D2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
        /// </summary>
        /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
        /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateBitmapFromWicBitmap(object wicBitmapSource, D2D1BitmapProperties bitmapProperties)
        {
            if (wicBitmapSource == null)
            {
                throw new ArgumentNullException(nameof(wicBitmapSource));
            }

            ID2D1Bitmap bitmap;

            GCHandle bitmapPropertiesHandle = GCHandle.Alloc(bitmapProperties, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateBitmapFromWicBitmap((IWICBitmapSource)wicBitmapSource, bitmapPropertiesHandle.AddrOfPinnedObject(), out bitmap);
            }
            finally
            {
                bitmapPropertiesHandle.Free();
            }

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates an <see cref="D2D1Bitmap"/> whose data is shared with another resource.
        /// </summary>
        /// <param name="riid">The interface ID of the object supplying the source data.</param>
        /// <param name="data">The data to share.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateSharedBitmap(Guid riid, object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateSharedBitmap(ref riid, data, IntPtr.Zero, out ID2D1Bitmap bitmap);

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates an <see cref="D2D1Bitmap"/> whose data is shared with another resource.
        /// </summary>
        /// <param name="riid">The interface ID of the object supplying the source data.</param>
        /// <param name="data">The data to share.</param>
        /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
        /// <returns>The new bitmap.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Bitmap CreateSharedBitmap(Guid riid, object data, D2D1BitmapProperties bitmapProperties)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ID2D1Bitmap bitmap;

            GCHandle bitmapPropertiesHandle = GCHandle.Alloc(bitmapProperties, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateSharedBitmap(ref riid, data, bitmapPropertiesHandle.AddrOfPinnedObject(), out bitmap);
            }
            finally
            {
                bitmapPropertiesHandle.Free();
            }

            if (bitmap == null)
            {
                return null;
            }

            return new D2D1Bitmap(bitmap);
        }

        /// <summary>
        /// Creates an <see cref="D2D1BitmapBrush"/> from the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap contents of the new brush.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapBrush CreateBitmapBrush(D2D1Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateBitmapBrush(bitmap.GetHandle<ID2D1Bitmap>(), IntPtr.Zero, IntPtr.Zero, out ID2D1BitmapBrush bitmapBrush);

            if (bitmapBrush == null)
            {
                return null;
            }

            return new D2D1BitmapBrush(bitmapBrush);
        }

        /// <summary>
        /// Creates an <see cref="D2D1BitmapBrush"/> from the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap contents of the new brush.</param>
        /// <param name="bitmapBrushProperties">The extend modes and interpolation mode of the new brush.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapBrush CreateBitmapBrush(D2D1Bitmap bitmap, D2D1BitmapBrushProperties bitmapBrushProperties)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            ID2D1BitmapBrush bitmapBrush;

            GCHandle bitmapBrushPropertiesHandle = GCHandle.Alloc(bitmapBrushProperties, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateBitmapBrush(bitmap.GetHandle<ID2D1Bitmap>(), bitmapBrushPropertiesHandle.AddrOfPinnedObject(), IntPtr.Zero, out bitmapBrush);
            }
            finally
            {
                bitmapBrushPropertiesHandle.Free();
            }

            if (bitmapBrush == null)
            {
                return null;
            }

            return new D2D1BitmapBrush(bitmapBrush);
        }

        /// <summary>
        /// Creates an <see cref="D2D1BitmapBrush"/> from the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap contents of the new brush.</param>
        /// <param name="bitmapBrushProperties">The extend modes and interpolation mode of the new brush.</param>
        /// <param name="brushProperties">A structure that contains the opacity and transform of the new brush.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapBrush CreateBitmapBrush(D2D1Bitmap bitmap, D2D1BitmapBrushProperties bitmapBrushProperties, D2D1BrushProperties brushProperties)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            ID2D1BitmapBrush bitmapBrush;

            GCHandle bitmapBrushPropertiesHandle = GCHandle.Alloc(bitmapBrushProperties, GCHandleType.Pinned);
            GCHandle brushPropertiesHandle = GCHandle.Alloc(brushProperties, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateBitmapBrush(bitmap.GetHandle<ID2D1Bitmap>(), bitmapBrushPropertiesHandle.AddrOfPinnedObject(), brushPropertiesHandle.AddrOfPinnedObject(), out bitmapBrush);
            }
            finally
            {
                bitmapBrushPropertiesHandle.Free();
                brushPropertiesHandle.Free();
            }

            if (bitmapBrush == null)
            {
                return null;
            }

            return new D2D1BitmapBrush(bitmapBrush);
        }

        /// <summary>
        /// Creates a new <see cref="D2D1SolidColorBrush"/> that has the specified color and opacity.
        /// </summary>
        /// <param name="color">The red, green, blue, and alpha values of the brush's color.</param>
        /// <returns>The new brush.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1SolidColorBrush CreateSolidColorBrush(D2D1ColorF color)
        {
            this.GetHandle<ID2D1RenderTarget>().CreateSolidColorBrush(ref color, IntPtr.Zero, out ID2D1SolidColorBrush solidColorBrush);

            if (solidColorBrush == null)
            {
                return null;
            }

            return new D2D1SolidColorBrush(solidColorBrush);
        }

        /// <summary>
        /// Creates a new <see cref="D2D1SolidColorBrush"/> that has the specified color and opacity.
        /// </summary>
        /// <param name="color">The red, green, blue, and alpha values of the brush's color.</param>
        /// <param name="brushProperties">The base opacity of the brush.</param>
        /// <returns>The new brush.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1SolidColorBrush CreateSolidColorBrush(D2D1ColorF color, D2D1BrushProperties brushProperties)
        {
            ID2D1SolidColorBrush solidColorBrush;

            GCHandle brushPropertiesHandle = GCHandle.Alloc(brushProperties);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateSolidColorBrush(ref color, brushPropertiesHandle.AddrOfPinnedObject(), out solidColorBrush);
            }
            finally
            {
                brushPropertiesHandle.Free();
            }

            if (solidColorBrush == null)
            {
                return null;
            }

            return new D2D1SolidColorBrush(solidColorBrush);
        }

        /// <summary>
        /// Creates an <see cref="D2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
        /// </summary>
        /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
        /// <param name="colorInterpolationGamma">The space in which color interpolation between the gradient stops is performed.</param>
        /// <param name="extendMode">The behavior of the gradient outside the [0,1] normalized range.</param>
        /// <returns>The new gradient stop collection.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GradientStopCollection CreateGradientStopCollection(D2D1GradientStop[] gradientStops, D2D1Gamma colorInterpolationGamma, D2D1ExtendMode extendMode)
        {
            if (gradientStops == null)
            {
                throw new ArgumentNullException(nameof(gradientStops));
            }

            if (gradientStops.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(gradientStops));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateGradientStopCollection(gradientStops, (uint)gradientStops.Length, colorInterpolationGamma, extendMode, out ID2D1GradientStopCollection gradientStopCollection);

            if (gradientStopCollection == null)
            {
                return null;
            }

            return new D2D1GradientStopCollection(gradientStopCollection);
        }

        /// <summary>
        /// Creates an <see cref="D2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
        /// </summary>
        /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
        /// <returns>The new gradient stop collection.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GradientStopCollection CreateGradientStopCollection(D2D1GradientStop[] gradientStops)
        {
            if (gradientStops == null)
            {
                throw new ArgumentNullException(nameof(gradientStops));
            }

            if (gradientStops.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(gradientStops));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateGradientStopCollection(gradientStops, (uint)gradientStops.Length, D2D1Gamma.Gamma22, D2D1ExtendMode.Clamp, out ID2D1GradientStopCollection gradientStopCollection);

            if (gradientStopCollection == null)
            {
                return null;
            }

            return new D2D1GradientStopCollection(gradientStopCollection);
        }

        /// <summary>
        /// Creates an <see cref="D2D1LinearGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
        /// </summary>
        /// <param name="linearGradientBrushProperties">The start and end points of the gradient.</param>
        /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient line.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1LinearGradientBrush CreateLinearGradientBrush(D2D1LinearGradientBrushProperties linearGradientBrushProperties, D2D1GradientStopCollection gradientStopCollection)
        {
            if (gradientStopCollection == null)
            {
                throw new ArgumentNullException(nameof(gradientStopCollection));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateLinearGradientBrush(ref linearGradientBrushProperties, IntPtr.Zero, gradientStopCollection.GetHandle<ID2D1GradientStopCollection>(), out ID2D1LinearGradientBrush linearGradientBrush);

            if (linearGradientBrush == null)
            {
                return null;
            }

            return new D2D1LinearGradientBrush(linearGradientBrush);
        }

        /// <summary>
        /// Creates an <see cref="D2D1LinearGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
        /// </summary>
        /// <param name="linearGradientBrushProperties">The start and end points of the gradient.</param>
        /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
        /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient line.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1LinearGradientBrush CreateLinearGradientBrush(D2D1LinearGradientBrushProperties linearGradientBrushProperties, D2D1BrushProperties brushProperties, D2D1GradientStopCollection gradientStopCollection)
        {
            if (gradientStopCollection == null)
            {
                throw new ArgumentNullException(nameof(gradientStopCollection));
            }

            ID2D1LinearGradientBrush linearGradientBrush;

            GCHandle brushPropertiesHandle = GCHandle.Alloc(brushProperties, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateLinearGradientBrush(ref linearGradientBrushProperties, brushPropertiesHandle.AddrOfPinnedObject(), gradientStopCollection.GetHandle<ID2D1GradientStopCollection>(), out linearGradientBrush);
            }
            finally
            {
                brushPropertiesHandle.Free();
            }

            if (linearGradientBrush == null)
            {
                return null;
            }

            return new D2D1LinearGradientBrush(linearGradientBrush);
        }

        /// <summary>
        /// Creates an <see cref="D2D1RadialGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
        /// </summary>
        /// <param name="radialGradientBrushProperties">The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</param>
        /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RadialGradientBrush CreateRadialGradientBrush(D2D1RadialGradientBrushProperties radialGradientBrushProperties, D2D1GradientStopCollection gradientStopCollection)
        {
            if (gradientStopCollection == null)
            {
                throw new ArgumentOutOfRangeException(nameof(gradientStopCollection));
            }

            this.GetHandle<ID2D1RenderTarget>().CreateRadialGradientBrush(ref radialGradientBrushProperties, IntPtr.Zero, gradientStopCollection.GetHandle<ID2D1GradientStopCollection>(), out ID2D1RadialGradientBrush radialGradientBrush);

            if (radialGradientBrush == null)
            {
                return null;
            }

            return new D2D1RadialGradientBrush(radialGradientBrush);
        }

        /// <summary>
        /// Creates an <see cref="D2D1RadialGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
        /// </summary>
        /// <param name="radialGradientBrushProperties">The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</param>
        /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
        /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient.</param>
        /// <returns>The new brush.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RadialGradientBrush CreateRadialGradientBrush(D2D1RadialGradientBrushProperties radialGradientBrushProperties, D2D1BrushProperties brushProperties, D2D1GradientStopCollection gradientStopCollection)
        {
            if (gradientStopCollection == null)
            {
                throw new ArgumentOutOfRangeException(nameof(gradientStopCollection));
            }

            ID2D1RadialGradientBrush radialGradientBrush;

            GCHandle brushPropertiesHandle = GCHandle.Alloc(brushProperties, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateRadialGradientBrush(ref radialGradientBrushProperties, brushPropertiesHandle.AddrOfPinnedObject(), gradientStopCollection.GetHandle<ID2D1GradientStopCollection>(), out radialGradientBrush);
            }
            finally
            {
                brushPropertiesHandle.Free();
            }

            if (radialGradientBrush == null)
            {
                return null;
            }

            return new D2D1RadialGradientBrush(radialGradientBrush);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1CompatibleRenderTargetOptions options)
        {
            this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero,
                options,
                out ID2D1BitmapRenderTarget bitmapRenderTarget);

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    desiredSizeHandle.AddrOfPinnedObject(),
                    IntPtr.Zero,
                    IntPtr.Zero,
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeU desiredPixelSize, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredPixelSizeHandle = GCHandle.Alloc(desiredPixelSize, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    IntPtr.Zero,
                    desiredPixelSizeHandle.AddrOfPinnedObject(),
                    IntPtr.Zero,
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredPixelSizeHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize, D2D1SizeU desiredPixelSize, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);
            GCHandle desiredPixelSizeHandle = GCHandle.Alloc(desiredPixelSize, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    desiredSizeHandle.AddrOfPinnedObject(),
                    desiredPixelSizeHandle.AddrOfPinnedObject(),
                    IntPtr.Zero,
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
                desiredPixelSizeHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredFormatHandle = GCHandle.Alloc(desiredFormat, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    IntPtr.Zero,
                    IntPtr.Zero,
                    desiredFormatHandle.AddrOfPinnedObject(),
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredFormatHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize, D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);
            GCHandle desiredFormatHandle = GCHandle.Alloc(desiredFormat, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    desiredSizeHandle.AddrOfPinnedObject(),
                    IntPtr.Zero,
                    desiredFormatHandle.AddrOfPinnedObject(),
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
                desiredFormatHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeU desiredPixelSize, D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredPixelSizeHandle = GCHandle.Alloc(desiredPixelSize, GCHandleType.Pinned);
            GCHandle desiredFormatHandle = GCHandle.Alloc(desiredFormat, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    IntPtr.Zero,
                    desiredPixelSizeHandle.AddrOfPinnedObject(),
                    desiredFormatHandle.AddrOfPinnedObject(),
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredPixelSizeHandle.Free();
                desiredFormatHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize, D2D1SizeU desiredPixelSize, D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);
            GCHandle desiredPixelSizeHandle = GCHandle.Alloc(desiredPixelSize, GCHandleType.Pinned);
            GCHandle desiredFormatHandle = GCHandle.Alloc(desiredFormat, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    desiredSizeHandle.AddrOfPinnedObject(),
                    desiredPixelSizeHandle.AddrOfPinnedObject(),
                    desiredFormatHandle.AddrOfPinnedObject(),
                    options,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
                desiredPixelSizeHandle.Free();
                desiredFormatHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget()
        {
            this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                IntPtr.Zero,
                IntPtr.Zero,
                IntPtr.Zero,
                D2D1CompatibleRenderTargetOptions.None,
                out ID2D1BitmapRenderTarget bitmapRenderTarget);

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    D2D1CompatibleRenderTargetOptions.None,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize, D2D1SizeU desiredPixelSize)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);
            GCHandle desiredPixelSizeHandle = GCHandle.Alloc(desiredPixelSize, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    desiredSizeHandle.AddrOfPinnedObject(),
                    desiredPixelSizeHandle.AddrOfPinnedObject(),
                    IntPtr.Zero,
                    D2D1CompatibleRenderTargetOptions.None,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
                desiredPixelSizeHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
        /// <returns>The new bitmap render target.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1SizeF desiredSize, D2D1SizeU desiredPixelSize, D2D1PixelFormat desiredFormat)
        {
            ID2D1BitmapRenderTarget bitmapRenderTarget;

            GCHandle desiredSizeHandle = GCHandle.Alloc(desiredSize, GCHandleType.Pinned);
            GCHandle desiredPixelSizeHandle = GCHandle.Alloc(desiredPixelSize, GCHandleType.Pinned);
            GCHandle desiredFormatHandle = GCHandle.Alloc(desiredFormat, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateCompatibleRenderTarget(
                    desiredSizeHandle.AddrOfPinnedObject(),
                    desiredPixelSizeHandle.AddrOfPinnedObject(),
                    desiredFormatHandle.AddrOfPinnedObject(),
                    D2D1CompatibleRenderTargetOptions.None,
                    out bitmapRenderTarget);
            }
            finally
            {
                desiredSizeHandle.Free();
                desiredPixelSizeHandle.Free();
                desiredFormatHandle.Free();
            }

            if (bitmapRenderTarget == null)
            {
                return null;
            }

            return new D2D1BitmapRenderTarget(bitmapRenderTarget);
        }

        /// <summary>
        /// Creates a layer resource that can be used with this render target and its compatible render targets. The new layer has the specified initial size.
        /// </summary>
        /// <returns>The new layer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Layer CreateLayer()
        {
            this.GetHandle<ID2D1RenderTarget>().CreateLayer(IntPtr.Zero, out ID2D1Layer layer);

            if (layer == null)
            {
                return null;
            }

            return new D2D1Layer(layer);
        }

        /// <summary>
        /// Creates a layer resource that can be used with this render target and its compatible render targets. The new layer has the specified initial size.
        /// </summary>
        /// <param name="size">The initial size of the layer in device-independent pixels.</param>
        /// <returns>The new layer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Layer CreateLayer(D2D1SizeF size)
        {
            ID2D1Layer layer;

            GCHandle sizeHandle = GCHandle.Alloc(size, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().CreateLayer(sizeHandle.AddrOfPinnedObject(), out layer);
            }
            finally
            {
                sizeHandle.Free();
            }

            if (layer == null)
            {
                return null;
            }

            return new D2D1Layer(layer);
        }

        /// <summary>
        /// Create a mesh that uses triangles to describe a shape.
        /// </summary>
        /// <returns>The new mesh.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Mesh CreateMesh()
        {
            this.GetHandle<ID2D1RenderTarget>().CreateMesh(out ID2D1Mesh mesh);

            if (mesh == null)
            {
                return null;
            }

            return new D2D1Mesh(mesh);
        }

        /// <summary>
        /// Draws a line between the specified points using the specified stroke style.
        /// </summary>
        /// <param name="point0">The start point of the line, in device-independent pixels.</param>
        /// <param name="point1">The end point of the line, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the line's stroke.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(D2D1Point2F point0, D2D1Point2F point1, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawLine(point0, point1, brush.GetHandle<ID2D1Brush>(), 1.0f, null);
        }

        /// <summary>
        /// Draws a line between the specified points using the specified stroke style.
        /// </summary>
        /// <param name="point0">The start point of the line, in device-independent pixels.</param>
        /// <param name="point1">The end point of the line, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the line's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(D2D1Point2F point0, D2D1Point2F point1, D2D1Brush brush, float strokeWidth)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawLine(point0, point1, brush.GetHandle<ID2D1Brush>(), strokeWidth, null);
        }

        /// <summary>
        /// Draws a line between the specified points using the specified stroke style.
        /// </summary>
        /// <param name="point0">The start point of the line, in device-independent pixels.</param>
        /// <param name="point1">The end point of the line, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the line's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to paint.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawLine(D2D1Point2F point0, D2D1Point2F point1, D2D1Brush brush, float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawLine(point0, point1, brush.GetHandle<ID2D1Brush>(), strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>());
        }

        /// <summary>
        /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
        /// </summary>
        /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRectangle(D2D1RectF rect, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawRectangle(ref rect, brush.GetHandle<ID2D1Brush>(), 1.0f, null);
        }

        /// <summary>
        /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
        /// </summary>
        /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRectangle(D2D1RectF rect, D2D1Brush brush, float strokeWidth)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawRectangle(ref rect, brush.GetHandle<ID2D1Brush>(), strokeWidth, null);
        }

        /// <summary>
        /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
        /// </summary>
        /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to paint.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRectangle(D2D1RectF rect, D2D1Brush brush, float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawRectangle(ref rect, brush.GetHandle<ID2D1Brush>(), strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>());
        }

        /// <summary>
        /// Paints the interior of the specified rectangle.
        /// </summary>
        /// <param name="rect">The dimension of the rectangle to paint, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rectangle's interior.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillRectangle(D2D1RectF rect, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillRectangle(ref rect, brush.GetHandle<ID2D1Brush>());
        }

        /// <summary>
        /// Draws the outline of the specified rounded rectangle using the specified stroke style.
        /// </summary>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRoundedRectangle(D2D1RoundedRect roundedRect, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawRoundedRectangle(ref roundedRect, brush.GetHandle<ID2D1Brush>(), 1.0f, null);
        }

        /// <summary>
        /// Draws the outline of the specified rounded rectangle using the specified stroke style.
        /// </summary>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRoundedRectangle(D2D1RoundedRect roundedRect, D2D1Brush brush, float strokeWidth)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawRoundedRectangle(ref roundedRect, brush.GetHandle<ID2D1Brush>(), strokeWidth, null);
        }

        /// <summary>
        /// Draws the outline of the specified rounded rectangle using the specified stroke style.
        /// </summary>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of the rounded rectangle's stroke.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawRoundedRectangle(D2D1RoundedRect roundedRect, D2D1Brush brush, float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawRoundedRectangle(ref roundedRect, brush.GetHandle<ID2D1Brush>(), strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>());
        }

        /// <summary>
        /// Paints the interior of the specified rounded rectangle.
        /// </summary>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to paint, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the interior of the rounded rectangle.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillRoundedRectangle(D2D1RoundedRect roundedRect, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillRoundedRectangle(ref roundedRect, brush.GetHandle<ID2D1Brush>());
        }

        /// <summary>
        /// Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the ellipse's outline.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(D2D1Ellipse ellipse, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawEllipse(ref ellipse, brush.GetHandle<ID2D1Brush>(), 1.0f, null);
        }

        /// <summary>
        /// Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the ellipse's outline.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(D2D1Ellipse ellipse, D2D1Brush brush, float strokeWidth)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawEllipse(ref ellipse, brush.GetHandle<ID2D1Brush>(), strokeWidth, null);
        }

        /// <summary>
        /// Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the ellipse's outline.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the ellipse's outline.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawEllipse(D2D1Ellipse ellipse, D2D1Brush brush, float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawEllipse(ref ellipse, brush.GetHandle<ID2D1Brush>(), strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>());
        }

        /// <summary>
        /// Paints the interior of the specified ellipse.
        /// </summary>
        /// <param name="ellipse">The position and radius, in device-independent pixels, of the ellipse to paint.</param>
        /// <param name="brush">The brush used to paint the interior of the ellipse.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillEllipse(D2D1Ellipse ellipse, D2D1Brush brush)
        {
            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillEllipse(ref ellipse, brush.GetHandle<ID2D1Brush>());
        }

        /// <summary>
        /// Draws the outline of the specified geometry using the specified stroke style.
        /// </summary>
        /// <param name="geometry">The geometry to draw.</param>
        /// <param name="brush">The brush used to paint the geometry's stroke.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawGeometry(D2D1Geometry geometry, D2D1Brush brush)
        {
            if (geometry == null)
            {
                throw new ArgumentNullException(nameof(geometry));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawGeometry(geometry.GetHandle<ID2D1Geometry>(), brush.GetHandle<ID2D1Brush>(), 1.0f, null);
        }

        /// <summary>
        /// Draws the outline of the specified geometry using the specified stroke style.
        /// </summary>
        /// <param name="geometry">The geometry to draw.</param>
        /// <param name="brush">The brush used to paint the geometry's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawGeometry(D2D1Geometry geometry, D2D1Brush brush, float strokeWidth)
        {
            if (geometry == null)
            {
                throw new ArgumentNullException(nameof(geometry));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawGeometry(geometry.GetHandle<ID2D1Geometry>(), brush.GetHandle<ID2D1Brush>(), strokeWidth, null);
        }

        /// <summary>
        /// Draws the outline of the specified geometry using the specified stroke style.
        /// </summary>
        /// <param name="geometry">The geometry to draw.</param>
        /// <param name="brush">The brush used to paint the geometry's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry's outline.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawGeometry(D2D1Geometry geometry, D2D1Brush brush, float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            if (geometry == null)
            {
                throw new ArgumentNullException(nameof(geometry));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawGeometry(geometry.GetHandle<ID2D1Geometry>(), brush.GetHandle<ID2D1Brush>(), strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>());
        }

        /// <summary>
        /// Paints the interior of the specified geometry.
        /// </summary>
        /// <param name="geometry">The geometry to paint.</param>
        /// <param name="brush">The brush used to paint the geometry's interior.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillGeometry(D2D1Geometry geometry, D2D1Brush brush)
        {
            if (geometry == null)
            {
                throw new ArgumentNullException(nameof(geometry));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillGeometry(geometry.GetHandle<ID2D1Geometry>(), brush.GetHandle<ID2D1Brush>(), null);
        }

        /// <summary>
        /// Paints the interior of the specified geometry.
        /// </summary>
        /// <param name="geometry">The geometry to paint.</param>
        /// <param name="brush">The brush used to paint the geometry's interior.</param>
        /// <param name="opacityBrush">The opacity mask to apply to the geometry.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillGeometry(D2D1Geometry geometry, D2D1Brush brush, D2D1Brush opacityBrush)
        {
            if (geometry == null)
            {
                throw new ArgumentNullException(nameof(geometry));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillGeometry(geometry.GetHandle<ID2D1Geometry>(), brush.GetHandle<ID2D1Brush>(), opacityBrush?.GetHandle<ID2D1Brush>());
        }

        /// <summary>
        /// Paints the interior of the specified mesh.
        /// </summary>
        /// <param name="mesh">The mesh to paint.</param>
        /// <param name="brush">The brush used to paint the mesh.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillMesh(D2D1Mesh mesh, D2D1Brush brush)
        {
            if (mesh == null)
            {
                throw new ArgumentNullException(nameof(mesh));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillMesh(mesh.GetHandle<ID2D1Mesh>(), brush.GetHandle<ID2D1Brush>());
        }

        /// <summary>
        /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
        /// </summary>
        /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
        /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
        /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillOpacityMask(D2D1Bitmap opacityMask, D2D1Brush brush, D2D1OpacityMaskContent content)
        {
            if (opacityMask == null)
            {
                throw new ArgumentNullException(nameof(opacityMask));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            this.GetHandle<ID2D1RenderTarget>().FillOpacityMask(opacityMask.GetHandle<ID2D1Bitmap>(), brush.GetHandle<ID2D1Brush>(), content, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
        /// </summary>
        /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
        /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
        /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
        /// <param name="destinationRectangle">The region of the render target to paint, in device-independent pixels.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillOpacityMask(D2D1Bitmap opacityMask, D2D1Brush brush, D2D1OpacityMaskContent content, D2D1RectF destinationRectangle)
        {
            if (opacityMask == null)
            {
                throw new ArgumentNullException(nameof(opacityMask));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            GCHandle destinationRectangleHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().FillOpacityMask(opacityMask.GetHandle<ID2D1Bitmap>(), brush.GetHandle<ID2D1Brush>(), content, destinationRectangleHandle.AddrOfPinnedObject(), IntPtr.Zero);
            }
            finally
            {
                destinationRectangleHandle.Free();
            }
        }

        /// <summary>
        /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
        /// </summary>
        /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
        /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
        /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
        /// <param name="destinationRectangle">The region of the render target to paint, in device-independent pixels.</param>
        /// <param name="sourceRectangle">The region of the bitmap to use as the opacity mask, in device-independent pixels.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void FillOpacityMask(D2D1Bitmap opacityMask, D2D1Brush brush, D2D1OpacityMaskContent content, D2D1RectF destinationRectangle, D2D1RectF sourceRectangle)
        {
            if (opacityMask == null)
            {
                throw new ArgumentNullException(nameof(opacityMask));
            }

            if (brush == null)
            {
                throw new ArgumentNullException(nameof(brush));
            }

            GCHandle destinationRectangleHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);
            GCHandle sourceRectangleHandle = GCHandle.Alloc(sourceRectangle, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().FillOpacityMask(opacityMask.GetHandle<ID2D1Bitmap>(), brush.GetHandle<ID2D1Brush>(), content, destinationRectangleHandle.AddrOfPinnedObject(), sourceRectangleHandle.AddrOfPinnedObject());
            }
            finally
            {
                destinationRectangleHandle.Free();
                sourceRectangleHandle.Free();
            }
        }

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">The bitmap to render.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBitmap(D2D1Bitmap bitmap)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), IntPtr.Zero, 1.0f, D2D1BitmapInterpolationMode.Linear, IntPtr.Zero);
        }

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">The bitmap to render.</param>
        /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBitmap(D2D1Bitmap bitmap, D2D1RectF destinationRectangle)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            GCHandle destinationRectangleHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), destinationRectangleHandle.AddrOfPinnedObject(), 1.0f, D2D1BitmapInterpolationMode.Linear, IntPtr.Zero);
            }
            finally
            {
                destinationRectangleHandle.Free();
            }
        }

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">The bitmap to render.</param>
        /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
        /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBitmap(D2D1Bitmap bitmap, D2D1RectF destinationRectangle, float opacity)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            GCHandle destinationRectangleHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), destinationRectangleHandle.AddrOfPinnedObject(), opacity, D2D1BitmapInterpolationMode.Linear, IntPtr.Zero);
            }
            finally
            {
                destinationRectangleHandle.Free();
            }
        }

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">The bitmap to render.</param>
        /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
        /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
        /// <param name="interpolationMode">The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBitmap(D2D1Bitmap bitmap, D2D1RectF destinationRectangle, float opacity, D2D1BitmapInterpolationMode interpolationMode)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            GCHandle destinationRectangleHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), destinationRectangleHandle.AddrOfPinnedObject(), opacity, interpolationMode, IntPtr.Zero);
            }
            finally
            {
                destinationRectangleHandle.Free();
            }
        }

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">The bitmap to render.</param>
        /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
        /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
        /// <param name="interpolationMode">The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</param>
        /// <param name="sourceRectangle">The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to be drawn.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawBitmap(D2D1Bitmap bitmap, D2D1RectF destinationRectangle, float opacity, D2D1BitmapInterpolationMode interpolationMode, D2D1RectF sourceRectangle)
        {
            if (bitmap == null)
            {
                throw new ArgumentNullException(nameof(bitmap));
            }

            GCHandle destinationRectangleHandle = GCHandle.Alloc(destinationRectangle, GCHandleType.Pinned);
            GCHandle sourceRectangleHandle = GCHandle.Alloc(sourceRectangle, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().DrawBitmap(bitmap.GetHandle<ID2D1Bitmap>(), destinationRectangleHandle.AddrOfPinnedObject(), opacity, interpolationMode, sourceRectangleHandle.AddrOfPinnedObject());
            }
            finally
            {
                destinationRectangleHandle.Free();
                sourceRectangleHandle.Free();
            }
        }

        /// <summary>
        /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
        /// </summary>
        /// <param name="text">An array of Unicode characters to draw.</param>
        /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawText(string text, DWriteTextFormat textFormat, D2D1RectF layoutRect, D2D1Brush defaultForegroundBrush)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (textFormat == null)
            {
                throw new ArgumentNullException(nameof(textFormat));
            }

            if (defaultForegroundBrush == null)
            {
                throw new ArgumentNullException(nameof(defaultForegroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawText(text, (uint)text.Length, (IDWriteTextFormat)textFormat.Handle, ref layoutRect, defaultForegroundBrush.GetHandle<ID2D1Brush>(), D2D1DrawTextOptions.None, DWriteMeasuringMode.Natural);
        }

        /// <summary>
        /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
        /// </summary>
        /// <param name="text">An array of Unicode characters to draw.</param>
        /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
        /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawText(string text, DWriteTextFormat textFormat, D2D1RectF layoutRect, D2D1Brush defaultForegroundBrush, D2D1DrawTextOptions options)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (textFormat == null)
            {
                throw new ArgumentNullException(nameof(textFormat));
            }

            if (defaultForegroundBrush == null)
            {
                throw new ArgumentNullException(nameof(defaultForegroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawText(text, (uint)text.Length, (IDWriteTextFormat)textFormat.Handle, ref layoutRect, defaultForegroundBrush.GetHandle<ID2D1Brush>(), options, DWriteMeasuringMode.Natural);
        }

        /// <summary>
        /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
        /// </summary>
        /// <param name="text">An array of Unicode characters to draw.</param>
        /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
        /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
        /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawText(string text, DWriteTextFormat textFormat, D2D1RectF layoutRect, D2D1Brush defaultForegroundBrush, D2D1DrawTextOptions options, DWriteMeasuringMode measuringMode)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (textFormat == null)
            {
                throw new ArgumentNullException(nameof(textFormat));
            }

            if (defaultForegroundBrush == null)
            {
                throw new ArgumentNullException(nameof(defaultForegroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawText(text, (uint)text.Length, (IDWriteTextFormat)textFormat.Handle, ref layoutRect, defaultForegroundBrush.GetHandle<ID2D1Brush>(), options, measuringMode);
        }

        /// <summary>
        /// Draws the formatted text described by the specified <see cref="DWriteTextLayout"/> object.
        /// </summary>
        /// <param name="origin">The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.</param>
        /// <param name="textLayout">The formatted text to draw.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawTextLayout(D2D1Point2F origin, DWriteTextLayout textLayout, D2D1Brush defaultForegroundBrush)
        {
            if (textLayout == null)
            {
                throw new ArgumentNullException(nameof(textLayout));
            }

            if (defaultForegroundBrush == null)
            {
                throw new ArgumentNullException(nameof(defaultForegroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawTextLayout(origin, (IDWriteTextLayout)textLayout.Handle, defaultForegroundBrush.GetHandle<ID2D1Brush>(), D2D1DrawTextOptions.None);
        }

        /// <summary>
        /// Draws the formatted text described by the specified <see cref="DWriteTextLayout"/> object.
        /// </summary>
        /// <param name="origin">The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.</param>
        /// <param name="textLayout">The formatted text to draw.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect.</param>
        /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawTextLayout(D2D1Point2F origin, DWriteTextLayout textLayout, D2D1Brush defaultForegroundBrush, D2D1DrawTextOptions options)
        {
            if (textLayout == null)
            {
                throw new ArgumentNullException(nameof(textLayout));
            }

            if (defaultForegroundBrush == null)
            {
                throw new ArgumentNullException(nameof(defaultForegroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawTextLayout(origin, (IDWriteTextLayout)textLayout.Handle, defaultForegroundBrush.GetHandle<ID2D1Brush>(), options);
        }

        /// <summary>
        /// Draws the specified glyphs.
        /// </summary>
        /// <param name="baselineOrigin">The origin, in device-independent pixels, of the glyphs' baseline.</param>
        /// <param name="glyphRun">The glyphs to render.</param>
        /// <param name="foregroundBrush">The brush used to paint the specified glyphs.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawGlyphRun(D2D1Point2F baselineOrigin, DWriteGlyphRun glyphRun, D2D1Brush foregroundBrush)
        {
            if (foregroundBrush == null)
            {
                throw new ArgumentNullException(nameof(foregroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawGlyphRun(baselineOrigin, ref glyphRun, foregroundBrush.GetHandle<ID2D1Brush>(), DWriteMeasuringMode.Natural);
        }

        /// <summary>
        /// Draws the specified glyphs.
        /// </summary>
        /// <param name="baselineOrigin">The origin, in device-independent pixels, of the glyphs' baseline.</param>
        /// <param name="glyphRun">The glyphs to render.</param>
        /// <param name="foregroundBrush">The brush used to paint the specified glyphs.</param>
        /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DrawGlyphRun(D2D1Point2F baselineOrigin, DWriteGlyphRun glyphRun, D2D1Brush foregroundBrush, DWriteMeasuringMode measuringMode)
        {
            if (foregroundBrush == null)
            {
                throw new ArgumentNullException(nameof(foregroundBrush));
            }

            this.GetHandle<ID2D1RenderTarget>().DrawGlyphRun(baselineOrigin, ref glyphRun, foregroundBrush.GetHandle<ID2D1Brush>(), measuringMode);
        }

        /// <summary>
        /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
        /// </summary>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTextRenderingParams()
        {
            this.GetHandle<ID2D1RenderTarget>().SetTextRenderingParams(null);
        }

        /// <summary>
        /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
        /// </summary>
        /// <param name="textRenderingParams">The text rendering options to be applied to all subsequent text and glyph drawing operations.</param>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTextRenderingParams(DWriteRenderingParams textRenderingParams)
        {
            this.GetHandle<ID2D1RenderTarget>().SetTextRenderingParams(textRenderingParams == null ? null : (IDWriteRenderingParams)textRenderingParams.Handle);
        }

        /// <summary>
        /// Retrieves the render target's current text rendering options.
        /// </summary>
        /// <returns>The render target's current text rendering options.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DWriteRenderingParams GetTextRenderingParams()
        {
            this.GetHandle<ID2D1RenderTarget>().GetTextRenderingParams(out IDWriteRenderingParams textRenderingParams);

            if (textRenderingParams == null)
            {
                return null;
            }

            return new DWriteRenderingParams(textRenderingParams);
        }

        /// <summary>
        /// Specifies a label for subsequent drawing operations.
        /// </summary>
        /// <param name="tag1">The first to apply to subsequent drawing operations.</param>
        /// <param name="tag2">The second to apply to subsequent drawing operations.</param>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTags(ulong tag1, ulong tag2)
        {
            this.GetHandle<ID2D1RenderTarget>().SetTags(tag1, tag2);
        }

        /// <summary>
        /// Gets the label for subsequent drawing operations.
        /// </summary>
        /// <param name="tag1">The first label for subsequent drawing operations.</param>
        /// <param name="tag2">The second label for subsequent drawing operations.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetTags(out ulong tag1, out ulong tag2)
        {
            this.GetHandle<ID2D1RenderTarget>().GetTags(out tag1, out tag2);
        }

        /// <summary>
        /// Adds the specified layer to the render target so that it receives all subsequent drawing operations until <see cref="PopLayer"/> is called.
        /// </summary>
        /// <param name="layerParameters">The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</param>
        /// <param name="layer">The layer that receives subsequent drawing operations.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PushLayer(D2D1LayerParameters layerParameters, D2D1Layer layer)
        {
            this.GetHandle<ID2D1RenderTarget>().PushLayer(ref layerParameters, layer?.GetHandle<ID2D1Layer>());
        }

        /// <summary>
        /// Stops redirecting drawing operations to the layer that is specified by the last <see cref="PushLayer"/> call.
        /// </summary>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PopLayer()
        {
            this.GetHandle<ID2D1RenderTarget>().PopLayer();
        }

        /// <summary>
        /// Executes all pending drawing commands.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Flush()
        {
            this.GetHandle<ID2D1RenderTarget>().Flush(out _, out _);
        }

        /// <summary>
        /// Executes all pending drawing commands.
        /// </summary>
        /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
        /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Flush(out ulong tag1, out ulong tag2)
        {
            this.GetHandle<ID2D1RenderTarget>().Flush(out tag1, out tag2);
        }

        /// <summary>
        /// Saves the current drawing state to the specified <see cref="D2D1DrawingStateBlock"/>.
        /// </summary>
        /// <param name="drawingStateBlock">The current drawing state of the render target.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SaveDrawingState(D2D1DrawingStateBlock drawingStateBlock)
        {
            if (drawingStateBlock == null)
            {
                throw new ArgumentNullException(nameof(drawingStateBlock));
            }

            this.GetHandle<ID2D1RenderTarget>().SaveDrawingState(drawingStateBlock.GetHandle<ID2D1DrawingStateBlock>());
        }

        /// <summary>
        /// Sets the render target's drawing state to that of the specified <see cref="D2D1DrawingStateBlock"/>.
        /// </summary>
        /// <param name="drawingStateBlock">The new drawing state of the render target.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RestoreDrawingState(D2D1DrawingStateBlock drawingStateBlock)
        {
            if (drawingStateBlock == null)
            {
                throw new ArgumentNullException(nameof(drawingStateBlock));
            }

            this.GetHandle<ID2D1RenderTarget>().RestoreDrawingState(drawingStateBlock.GetHandle<ID2D1DrawingStateBlock>());
        }

        /// <summary>
        /// Specifies a rectangle to which all subsequent drawing operations are clipped.
        /// </summary>
        /// <param name="clipRect">The size and position of the clipping area, in device-independent pixels.</param>
        /// <param name="antialiasMode">The antialiasing mode that is used to draw the edges of clip rectangles that have subpixel boundaries, and to blend the clip with the scene contents. The blending is performed once when the <see cref="PopAxisAlignedClip"/> method is called, and does not apply to each primitive within the layer.</param>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void PushAxisAlignedClip(D2D1RectF clipRect, D2D1AntialiasMode antialiasMode)
        {
            this.GetHandle<ID2D1RenderTarget>().PushAxisAlignedClip(ref clipRect, antialiasMode);
        }

        /// <summary>
        /// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to subsequent drawing operations.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void PopAxisAlignedClip()
        {
            this.GetHandle<ID2D1RenderTarget>().PopAxisAlignedClip();
        }

        /// <summary>
        /// Clears the drawing area to the specified color.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void Clear()
        {
            this.GetHandle<ID2D1RenderTarget>().Clear(IntPtr.Zero);
        }

        /// <summary>
        /// Clears the drawing area to the specified color.
        /// </summary>
        /// <param name="clearColor">The color to which the drawing area is cleared.</param>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear(D2D1ColorF clearColor)
        {
            GCHandle clearColorHandle = GCHandle.Alloc(clearColor, GCHandleType.Pinned);

            try
            {
                this.GetHandle<ID2D1RenderTarget>().Clear(clearColorHandle.AddrOfPinnedObject());
            }
            finally
            {
                clearColorHandle.Free();
            }
        }

        /// <summary>
        /// Initiates drawing on this render target.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void BeginDraw()
        {
            this.GetHandle<ID2D1RenderTarget>().BeginDraw();
        }

        /// <summary>
        /// Ends drawing operations on the render target and indicates the current error state and associated tags.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EndDraw()
        {
            this.GetHandle<ID2D1RenderTarget>().EndDraw(out _, out _);
        }

        /// <summary>
        /// Ends drawing operations on the render target and indicates the current error state and associated tags.
        /// </summary>
        /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
        /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void EndDraw(out ulong tag1, out ulong tag2)
        {
            this.GetHandle<ID2D1RenderTarget>().EndDraw(out tag1, out tag2);
        }

        /// <summary>
        /// Ends drawing operations on the render target, ignoring the recreate target error.
        /// </summary>
        public void EndDrawIgnoringRecreateTargetError()
        {
            try
            {
                this.EndDraw();
            }
            catch (Exception ex)
            {
                if (ex.HResult != D2D1Error.RecreateTarget)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Sets the dots per inch (DPI) of the render target.
        /// </summary>
        /// <param name="dpiX">A value greater than or equal to zero that specifies the horizontal DPI of the render target.</param>
        /// <param name="dpiY">A value greater than or equal to zero that specifies the vertical DPI of the render target.</param>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetDpi(float dpiX, float dpiY)
        {
            this.GetHandle<ID2D1RenderTarget>().SetDpi(dpiX, dpiY);
        }

        /// <summary>
        /// Return the render target's dots per inch (DPI).
        /// </summary>
        /// <param name="dpiX">The horizontal DPI of the render target.</param>
        /// <param name="dpiY">The vertical DPI of the render target.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetDpi(out float dpiX, out float dpiY)
        {
            this.GetHandle<ID2D1RenderTarget>().GetDpi(out dpiX, out dpiY);
        }

        /// <summary>
        /// Indicates whether the render target supports the specified properties.
        /// </summary>
        /// <param name="renderTargetProperties">The render target properties to test.</param>
        /// <returns><value>true</value> if the specified render target properties are supported by this render target; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSupported(D2D1RenderTargetProperties renderTargetProperties)
        {
            return this.GetHandle<ID2D1RenderTarget>().IsSupported(ref renderTargetProperties);
        }
    }
}
