// <copyright file="ID2D1DCRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;
    using JeremyAnsel.DirectX.DWrite;

    /// <summary>
    /// Issues drawing commands to a GDI device context.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1RenderTarget"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("1c51bc64-de61-46fd-9899-63a5d8f03950")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1DCRenderTarget
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory factory);

        /// <summary>
        /// Creates a Direct2D bitmap from a pointer to in-memory source data.
        /// </summary>
        /// <param name="size">The dimension of the bitmap to create in pixels.</param>
        /// <param name="srcData">A pointer to the memory location of the image data, or NULL to create an uninitialized bitmap</param>
        /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If <paramref name="srcData"/> is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
        /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
        /// <param name="bitmap">The new bitmap.</param>
        void CreateBitmap(
            [In] D2D1SizeU size,
            [In] IntPtr srcData,
            [In] uint pitch,
            [In] ref D2D1BitmapProperties bitmapProperties,
            [Out] out ID2D1Bitmap bitmap);

        /// <summary>
        /// Creates an <see cref="ID2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
        /// </summary>
        /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
        /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
        /// <param name="bitmap">The new bitmap.</param>
        void CreateBitmapFromWicBitmap(
            [In] IWICBitmapSource wicBitmapSource,
            [In] IntPtr bitmapProperties,
            [Out] out ID2D1Bitmap bitmap);

        /// <summary>
        /// Creates an <see cref="ID2D1Bitmap"/> whose data is shared with another resource.
        /// </summary>
        /// <param name="riid">The interface ID of the object supplying the source data.</param>
        /// <param name="data">The data to share.</param>
        /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
        /// <param name="bitmap">The new bitmap.</param>
        void CreateSharedBitmap(
            [In] ref Guid riid,
            [In, Out] IntPtr data,
            [In] IntPtr bitmapProperties,
            [Out] out ID2D1Bitmap bitmap);

        /// <summary>
        /// Creates an ID2D1BitmapBrush from the specified bitmap.
        /// </summary>
        /// <param name="bitmap">The bitmap contents of the new brush.</param>
        /// <param name="bitmapBrushProperties">The extend modes and interpolation mode of the new brush.</param>
        /// <param name="brushProperties">A structure that contains the opacity and transform of the new brush.</param>
        /// <param name="bitmapBrush">The new brush.</param>
        void CreateBitmapBrush(
            [In] ID2D1Bitmap bitmap,
            [In] IntPtr bitmapBrushProperties,
            [In] IntPtr brushProperties,
            [Out] out ID2D1BitmapBrush bitmapBrush);

        /// <summary>
        /// Creates a new <see cref="ID2D1SolidColorBrush"/> that has the specified color and opacity.
        /// </summary>
        /// <param name="color">The red, green, blue, and alpha values of the brush's color.</param>
        /// <param name="brushProperties">The base opacity of the brush.</param>
        /// <param name="solidColorBrush">The new brush.</param>
        void CreateSolidColorBrush(
            [In] ref D2D1ColorF color,
            [In] IntPtr brushProperties,
            [Out] out ID2D1SolidColorBrush solidColorBrush);

        /// <summary>
        /// Creates an <see cref="ID2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
        /// </summary>
        /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
        /// <param name="gradientStopsCount">A value greater than or equal to 1 that specifies the number of gradient stops in the gradientStops array.</param>
        /// <param name="colorInterpolationGamma">The space in which color interpolation between the gradient stops is performed.</param>
        /// <param name="extendMode">The behavior of the gradient outside the [0,1] normalized range.</param>
        /// <param name="gradientStopCollection">The new gradient stop collection.</param>
        void CreateGradientStopCollection(
            [In, MarshalAs(UnmanagedType.LPArray)] D2D1GradientStop[] gradientStops,
            [In] uint gradientStopsCount,
            [In] D2D1Gamma colorInterpolationGamma,
            [In] D2D1ExtendMode extendMode,
            [Out] out ID2D1GradientStopCollection gradientStopCollection);

        /// <summary>
        /// Creates an <see cref="ID2D1LinearGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
        /// </summary>
        /// <param name="linearGradientBrushProperties">The start and end points of the gradient.</param>
        /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
        /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient line.</param>
        /// <param name="linearGradientBrush">The new brush.</param>
        void CreateLinearGradientBrush(
            [In] ref D2D1LinearGradientBrushProperties linearGradientBrushProperties,
            [In] IntPtr brushProperties,
            [In] ID2D1GradientStopCollection gradientStopCollection,
            [Out] out ID2D1LinearGradientBrush linearGradientBrush);

        /// <summary>
        /// Creates an <see cref="ID2D1RadialGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
        /// </summary>
        /// <param name="radialGradientBrushProperties">The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</param>
        /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
        /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient.</param>
        /// <param name="radialGradientBrush">The new brush.</param>
        void CreateRadialGradientBrush(
            [In] ref D2D1RadialGradientBrushProperties radialGradientBrushProperties,
            [In] IntPtr brushProperties,
            [In] ID2D1GradientStopCollection gradientStopCollection,
            [Out] out ID2D1RadialGradientBrush radialGradientBrush);

        /// <summary>
        /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
        /// </summary>
        /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
        /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
        /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
        /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
        /// <param name="bitmapRenderTarget">The new bitmap render target.</param>
        void CreateCompatibleRenderTarget(
            [In] IntPtr desiredSize,
            [In] IntPtr desiredPixelSize,
            [In] IntPtr desiredFormat,
            [In] D2D1CompatibleRenderTargetOptions options,
            [Out] out ID2D1BitmapRenderTarget bitmapRenderTarget);

        /// <summary>
        /// Creates a layer resource that can be used with this render target and its compatible render targets. The new layer has the specified initial size.
        /// </summary>
        /// <param name="size">The initial size of the layer in device-independent pixels.</param>
        /// <param name="layer">The new layer.</param>
        void CreateLayer(
            [In] IntPtr size,
            [Out] out ID2D1Layer layer);

        /// <summary>
        /// Create a mesh that uses triangles to describe a shape.
        /// </summary>
        /// <param name="mesh">The new mesh.</param>
        void CreateMesh(
            [Out] out ID2D1Mesh mesh);

        /// <summary>
        /// Draws a line between the specified points using the specified stroke style.
        /// </summary>
        /// <param name="point0">The start point of the line, in device-independent pixels.</param>
        /// <param name="point1">The end point of the line, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the line's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to paint.</param>
        [PreserveSig]
        void DrawLine(
            [In] D2D1Point2F point0,
            [In] D2D1Point2F point1,
            [In] ID2D1Brush brush,
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle strokeStyle);

        /// <summary>
        /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
        /// </summary>
        /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to paint.</param>
        [PreserveSig]
        void DrawRectangle(
            [In] ref D2D1RectF rect,
            [In] ID2D1Brush brush,
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle strokeStyle);

        /// <summary>
        /// Paints the interior of the specified rectangle.
        /// </summary>
        /// <param name="rect">The dimension of the rectangle to paint, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rectangle's interior.</param>
        [PreserveSig]
        void FillRectangle(
            [In] ref D2D1RectF rect,
            [In] ID2D1Brush brush);

        /// <summary>
        /// Draws the outline of the specified rounded rectangle using the specified stroke style.
        /// </summary>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of the rounded rectangle's stroke.</param>
        [PreserveSig]
        void DrawRoundedRectangle(
            [In] ref D2D1RoundedRect roundedRect,
            [In] ID2D1Brush brush,
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle strokeStyle);

        /// <summary>
        /// Paints the interior of the specified rounded rectangle.
        /// </summary>
        /// <param name="roundedRect">The dimensions of the rounded rectangle to paint, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the interior of the rounded rectangle.</param>
        [PreserveSig]
        void FillRoundedRectangle(
            [In] ref D2D1RoundedRect roundedRect,
            [In] ID2D1Brush brush);

        /// <summary>
        /// Draws the outline of the specified ellipse using the specified stroke style.
        /// </summary>
        /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
        /// <param name="brush">The brush used to paint the ellipse's outline.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the ellipse's outline.</param>
        [PreserveSig]
        void DrawEllipse(
            [In] ref D2D1Ellipse ellipse,
            [In] ID2D1Brush brush,
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle strokeStyle);

        /// <summary>
        /// Paints the interior of the specified ellipse.
        /// </summary>
        /// <param name="ellipse">The position and radius, in device-independent pixels, of the ellipse to paint.</param>
        /// <param name="brush">The brush used to paint the interior of the ellipse.</param>
        [PreserveSig]
        void FillEllipse(
            [In] ref D2D1Ellipse ellipse,
            [In] ID2D1Brush brush);

        /// <summary>
        /// Draws the outline of the specified geometry using the specified stroke style.
        /// </summary>
        /// <param name="geometry">The geometry to draw.</param>
        /// <param name="brush">The brush used to paint the geometry's stroke.</param>
        /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry's outline.</param>
        [PreserveSig]
        void DrawGeometry(
            [In] ID2D1Geometry geometry,
            [In] ID2D1Brush brush,
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle strokeStyle);

        /// <summary>
        /// Paints the interior of the specified geometry.
        /// </summary>
        /// <param name="geometry">The geometry to paint.</param>
        /// <param name="brush">The brush used to paint the geometry's interior.</param>
        /// <param name="opacityBrush">The opacity mask to apply to the geometry.</param>
        [PreserveSig]
        void FillGeometry(
            [In] ID2D1Geometry geometry,
            [In] ID2D1Brush brush,
            [In] ID2D1Brush opacityBrush);

        /// <summary>
        /// Paints the interior of the specified mesh.
        /// </summary>
        /// <param name="mesh">The mesh to paint.</param>
        /// <param name="brush">The brush used to paint the mesh.</param>
        [PreserveSig]
        void FillMesh(
            [In] ID2D1Mesh mesh,
            [In] ID2D1Brush brush);

        /// <summary>
        /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
        /// </summary>
        /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
        /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
        /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
        /// <param name="destinationRectangle">The region of the render target to paint, in device-independent pixels.</param>
        /// <param name="sourceRectangle">The region of the bitmap to use as the opacity mask, in device-independent pixels.</param>
        [PreserveSig]
        void FillOpacityMask(
            [In] ID2D1Bitmap opacityMask,
            [In] ID2D1Brush brush,
            [In] D2D1OpacityMaskContent content,
            [In] IntPtr destinationRectangle,
            [In] IntPtr sourceRectangle);

        /// <summary>
        /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
        /// </summary>
        /// <param name="bitmap">The bitmap to render.</param>
        /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
        /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
        /// <param name="interpolationMode">The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</param>
        /// <param name="sourceRectangle">The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to be drawn.</param>
        [PreserveSig]
        void DrawBitmap(
            [In] ID2D1Bitmap bitmap,
            [In] IntPtr destinationRectangle,
            [In] float opacity,
            [In] D2D1BitmapInterpolationMode interpolationMode,
            [In] IntPtr sourceRectangle);

        /// <summary>
        /// Draws the specified text using the format information provided by an <see cref="IDWriteTextFormat"/> object.
        /// </summary>
        /// <param name="text">An array of Unicode characters to draw.</param>
        /// <param name="textLength">The number of characters in string.</param>
        /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
        /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
        /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
        /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
        [PreserveSig]
        void DrawText(
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            [In] uint textLength,
            [In] IDWriteTextFormat textFormat,
            [In] ref D2D1RectF layoutRect,
            [In] ID2D1Brush defaultForegroundBrush,
            [In] D2D1DrawTextOptions options,
            [In] DWriteMeasuringMode measuringMode);

        /// <summary>
        /// Draws the formatted text described by the specified <see cref="IDWriteTextLayout"/> object.
        /// </summary>
        /// <param name="origin">The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.</param>
        /// <param name="textLayout">The formatted text to draw.</param>
        /// <param name="defaultForegroundBrush">The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect.</param>
        /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
        [PreserveSig]
        void DrawTextLayout(
            [In] D2D1Point2F origin,
            [In] IDWriteTextLayout textLayout,
            [In] ID2D1Brush defaultForegroundBrush,
            [In] D2D1DrawTextOptions options);

        /// <summary>
        /// Draws the specified glyphs.
        /// </summary>
        /// <param name="baselineOrigin">The origin, in device-independent pixels, of the glyphs' baseline.</param>
        /// <param name="glyphRun">The glyphs to render.</param>
        /// <param name="foregroundBrush">The brush used to paint the specified glyphs.</param>
        /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
        [PreserveSig]
        void DrawGlyphRun(
            [In] D2D1Point2F baselineOrigin,
            [In] ref DWriteGlyphRun glyphRun,
            [In] ID2D1Brush foregroundBrush,
            [In] DWriteMeasuringMode measuringMode);

        /// <summary>
        /// Applies the specified transform to the render target, replacing the existing transformation. All subsequent drawing operations occur in the transformed space.
        /// </summary>
        /// <param name="transform">The transform to apply to the render target.</param>
        [PreserveSig]
        void SetTransform(
            [In] ref D2D1Matrix3X2F transform);

        /// <summary>
        /// Gets the current transform of the render target.
        /// </summary>
        /// <param name="transform">The current transform of the render target.</param>
        [PreserveSig]
        void GetTransform(
            [Out] out D2D1Matrix3X2F transform);

        /// <summary>
        /// Sets the antialiasing mode of the render target. The antialiasing mode applies to all subsequent drawing operations, excluding text and glyph drawing operations.
        /// </summary>
        /// <param name="antialiasMode">The antialiasing mode for future drawing operations.</param>
        [PreserveSig]
        void SetAntialiasMode(
            [In] D2D1AntialiasMode antialiasMode);

        /// <summary>
        /// Retrieves the current antialiasing mode for nontext drawing operations.
        /// </summary>
        /// <returns>The current antialiasing mode for nontext drawing operations.</returns>
        [PreserveSig]
        D2D1AntialiasMode GetAntialiasMode();

        /// <summary>
        /// Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.
        /// </summary>
        /// <param name="textAntialiasMode">The antialiasing mode to use for subsequent text and glyph drawing operations.</param>
        [PreserveSig]
        void SetTextAntialiasMode(
            [In] D2D1TextAntialiasMode textAntialiasMode);

        /// <summary>
        /// Gets the current antialiasing mode for text and glyph drawing operations.
        /// </summary>
        /// <returns>The current antialiasing mode for text and glyph drawing operations.</returns>
        [PreserveSig]
        D2D1TextAntialiasMode GetTextAntialiasMode();

        /// <summary>
        /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
        /// </summary>
        /// <param name="textRenderingParams">The text rendering options to be applied to all subsequent text and glyph drawing operations.</param>
        [PreserveSig]
        void SetTextRenderingParams(
            [In] IDWriteRenderingParams textRenderingParams);

        /// <summary>
        /// Retrieves the render target's current text rendering options.
        /// </summary>
        /// <param name="textRenderingParams">The render target's current text rendering options.</param>
        [PreserveSig]
        void GetTextRenderingParams(
            [Out] out IDWriteRenderingParams textRenderingParams);

        /// <summary>
        /// Specifies a label for subsequent drawing operations.
        /// </summary>
        /// <param name="tag1">The first label to apply to subsequent drawing operations.</param>
        /// <param name="tag2">The second label to apply to subsequent drawing operations.</param>
        [PreserveSig]
        void SetTags(
            [In] ulong tag1,
            [In] ulong tag2);

        /// <summary>
        /// Gets the label for subsequent drawing operations.
        /// </summary>
        /// <param name="tag1">The first label for subsequent drawing operations.</param>
        /// <param name="tag2">The second label for subsequent drawing operations.</param>
        [PreserveSig]
        void GetTags(
            [Out] out ulong tag1,
            [Out] out ulong tag2);

        /// <summary>
        /// Adds the specified layer to the render target so that it receives all subsequent drawing operations until <see cref="PopLayer"/> is called.
        /// </summary>
        /// <param name="layerParameters">The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</param>
        /// <param name="layer">The layer that receives subsequent drawing operations.</param>
        [PreserveSig]
        void PushLayer(
            [In] ref D2D1LayerParameters layerParameters,
            [In] ID2D1Layer layer);

        /// <summary>
        /// Stops redirecting drawing operations to the layer that is specified by the last <see cref="PushLayer"/> call.
        /// </summary>
        [PreserveSig]
        void PopLayer();

        /// <summary>
        /// Executes all pending drawing commands.
        /// </summary>
        /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
        /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
        void Flush(
            [Out] out ulong tag1,
            [Out] out ulong tag2);

        /// <summary>
        /// Saves the current drawing state to the specified <see cref="ID2D1DrawingStateBlock"/>.
        /// </summary>
        /// <param name="drawingStateBlock">The current drawing state of the render target.</param>
        [PreserveSig]
        void SaveDrawingState(
            [In, Out] ID2D1DrawingStateBlock drawingStateBlock);

        /// <summary>
        /// Sets the render target's drawing state to that of the specified <see cref="ID2D1DrawingStateBlock"/>.
        /// </summary>
        /// <param name="drawingStateBlock">The new drawing state of the render target.</param>
        [PreserveSig]
        void RestoreDrawingState(
            [In] ID2D1DrawingStateBlock drawingStateBlock);

        /// <summary>
        /// Specifies a rectangle to which all subsequent drawing operations are clipped.
        /// </summary>
        /// <param name="clipRect">The size and position of the clipping area, in device-independent pixels.</param>
        /// <param name="antialiasMode">The antialiasing mode that is used to draw the edges of clip rectangles that have subpixel boundaries, and to blend the clip with the scene contents. The blending is performed once when the <see cref="PopAxisAlignedClip"/> method is called, and does not apply to each primitive within the layer.</param>
        [PreserveSig]
        void PushAxisAlignedClip(
            [In] ref D2D1RectF clipRect,
            [In] D2D1AntialiasMode antialiasMode);

        /// <summary>
        /// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to subsequent drawing operations.
        /// </summary>
        [PreserveSig]
        void PopAxisAlignedClip();

        /// <summary>
        /// Clears the drawing area to the specified color.
        /// </summary>
        /// <param name="clearColor">The color to which the drawing area is cleared.</param>
        [PreserveSig]
        void Clear(
            [In] IntPtr clearColor);

        /// <summary>
        /// Initiates drawing on this render target.
        /// </summary>
        [PreserveSig]
        void BeginDraw();

        /// <summary>
        /// Ends drawing operations on the render target and indicates the current error state and associated tags.
        /// </summary>
        /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
        /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
        void EndDraw(
            [Out] out ulong tag1,
            [Out] out ulong tag2);

        /// <summary>
        /// Retrieves the pixel format and alpha mode of the render target.
        /// </summary>
        /// <returns>The pixel format and alpha mode of the render target.</returns>
        [PreserveSig]
        D2D1PixelFormat GetPixelFormat();

        /// <summary>
        /// Sets the dots per inch (DPI) of the render target.
        /// </summary>
        /// <param name="dpiX">A value greater than or equal to zero that specifies the horizontal DPI of the render target.</param>
        /// <param name="dpiY">A value greater than or equal to zero that specifies the vertical DPI of the render target.</param>
        [PreserveSig]
        void SetDpi(
            [In] float dpiX,
            [In] float dpiY);

        /// <summary>
        /// Return the render target's dots per inch (DPI).
        /// </summary>
        /// <param name="dpiX">The horizontal DPI of the render target.</param>
        /// <param name="dpiY">The vertical DPI of the render target.</param>
        [PreserveSig]
        void GetDpi(
            [Out] out float dpiX,
            [Out] out float dpiY);

        /// <summary>
        /// Returns the size of the render target in device-independent pixels.
        /// </summary>
        /// <param name="size">The current size of the render target in device-independent pixels.</param>
        [PreserveSig]
        void GetSize(
            [Out] out D2D1SizeF size);

        /// <summary>
        /// Returns the size of the render target in device pixels.
        /// </summary>
        /// <param name="size">The size of the render target in device pixels.</param>
        [PreserveSig]
        void GetPixelSize(
            [Out] out D2D1SizeU size);

        /// <summary>
        /// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
        /// </summary>
        /// <returns>The maximum size, in pixels, of any one bitmap dimension supported by the render target.</returns>
        [PreserveSig]
        uint GetMaximumBitmapSize();

        /// <summary>
        /// Indicates whether the render target supports the specified properties.
        /// </summary>
        /// <param name="renderTargetProperties">The render target properties to test.</param>
        /// <returns><value>true</value> if the specified render target properties are supported by this render target; otherwise, <value>false</value>.</returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Bool)]
        bool IsSupported(
            [In] ref D2D1RenderTargetProperties renderTargetProperties);

        /// <summary>
        /// Binds the render target to the device context to which it issues drawing commands.
        /// </summary>
        /// <param name="hdc">The device context to which the render target issues drawing commands.</param>
        /// <param name="subRect">The dimensions of the handle to a device context (HDC) to which the render target is bound.</param>
        void BindDC(
            [In] IntPtr hdc,
            [In] ref D2D1RectL subRect);
    }
}
