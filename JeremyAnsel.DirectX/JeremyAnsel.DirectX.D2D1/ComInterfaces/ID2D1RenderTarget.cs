// <copyright file="ID2D1RenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.DWrite;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents an object that can receive drawing commands.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd90694-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1RenderTarget
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Creates a Direct2D bitmap from a pointer to in-memory source data.
    /// </summary>
    /// <param name="size">The dimension of the bitmap to create in pixels.</param>
    /// <param name="srcData">A pointer to the memory location of the image data, or NULL to create an uninitialized bitmap</param>
    /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If srcData is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
    /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
    /// <param name="bitmap">The new bitmap.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, uint, void*, uint, void*, nint*, int> CreateBitmap;

    /// <summary>
    /// Creates an <see cref="ID2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
    /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
    /// <param name="bitmap">The new bitmap.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint*, int> CreateBitmapFromWicBitmap;

    /// <summary>
    /// Creates an <see cref="ID2D1Bitmap"/> whose data is shared with another resource.
    /// </summary>
    /// <param name="riid">The interface ID of the object supplying the source data.</param>
    /// <param name="data">The data to share.</param>
    /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
    /// <param name="bitmap">The new bitmap.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint, void*, nint*, int> CreateSharedBitmap;

    /// <summary>
    /// Creates an <see cref="ID2D1BitmapBrush"/> from the specified bitmap.
    /// </summary>
    /// <param name="bitmap">The bitmap contents of the new brush.</param>
    /// <param name="bitmapBrushProperties">The extend modes and interpolation mode of the new brush.</param>
    /// <param name="brushProperties">A structure that contains the opacity and transform of the new brush.</param>
    /// <param name="bitmapBrush">The new brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, void*, nint*, int> CreateBitmapBrush;

    /// <summary>
    /// Creates a new <see cref="ID2D1SolidColorBrush"/> that has the specified color and opacity.
    /// </summary>
    /// <param name="color">The red, green, blue, and alpha values of the brush's color.</param>
    /// <param name="brushProperties">The base opacity of the brush.</param>
    /// <param name="solidColorBrush">The new brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, nint*, int> CreateSolidColorBrush;

    /// <summary>
    /// Creates an <see cref="ID2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
    /// </summary>
    /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
    /// <param name="gradientStopsCount">A value greater than or equal to 1 that specifies the number of gradient stops in the gradientStops array.</param>
    /// <param name="colorInterpolationGamma">The space in which color interpolation between the gradient stops is performed.</param>
    /// <param name="extendMode">The behavior of the gradient outside the [0,1] normalized range.</param>
    /// <param name="gradientStopCollection">The new gradient stop collection.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, D2D1Gamma, D2D1ExtendMode, nint*, int> CreateGradientStopCollection;

    /// <summary>
    /// Creates an <see cref="ID2D1LinearGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
    /// </summary>
    /// <param name="linearGradientBrushProperties">The start and end points of the gradient.</param>
    /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
    /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient line.</param>
    /// <param name="linearGradientBrush">The new brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, nint, nint*, int> CreateLinearGradientBrush;

    /// <summary>
    /// Creates an <see cref="ID2D1RadialGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
    /// </summary>
    /// <param name="radialGradientBrushProperties">The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</param>
    /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
    /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient.</param>
    /// <param name="radialGradientBrush">The new brush.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, nint, nint*, int> CreateRadialGradientBrush;

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <param name="bitmapRenderTarget">The new bitmap render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, void*, D2D1CompatibleRenderTargetOptions, nint*, int> CreateCompatibleRenderTarget;

    /// <summary>
    /// Creates a layer resource that can be used with this render target and its compatible render targets. The new layer has the specified initial size.
    /// </summary>
    /// <param name="size">The initial size of the layer in device-independent pixels.</param>
    /// <param name="layer">The new layer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, int> CreateLayer;

    /// <summary>
    /// Create a mesh that uses triangles to describe a shape.
    /// </summary>
    /// <param name="mesh">The new mesh.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreateMesh;

    /// <summary>
    /// Draws a line between the specified points using the specified stroke style.
    /// </summary>
    /// <param name="point0">The start point of the line, in device-independent pixels.</param>
    /// <param name="point1">The end point of the line, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the line's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to paint.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, float, float, nint, float, nint, void> DrawLine;

    /// <summary>
    /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
    /// </summary>
    /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to paint.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, float, nint, void> DrawRectangle;

    /// <summary>
    /// Paints the interior of the specified rectangle.
    /// </summary>
    /// <param name="rect">The dimension of the rectangle to paint, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rectangle's interior.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, void> FillRectangle;

    /// <summary>
    /// Draws the outline of the specified rounded rectangle using the specified stroke style.
    /// </summary>
    /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of the rounded rectangle's stroke.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, float, nint, void> DrawRoundedRectangle;

    /// <summary>
    /// Paints the interior of the specified rounded rectangle.
    /// </summary>
    /// <param name="roundedRect">The dimensions of the rounded rectangle to paint, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the interior of the rounded rectangle.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, void> FillRoundedRectangle;

    /// <summary>
    /// Draws the outline of the specified ellipse using the specified stroke style.
    /// </summary>
    /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the ellipse's outline.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the ellipse's outline.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, float, nint, void> DrawEllipse;

    /// <summary>
    /// Paints the interior of the specified ellipse.
    /// </summary>
    /// <param name="ellipse">The position and radius, in device-independent pixels, of the ellipse to paint.</param>
    /// <param name="brush">The brush used to paint the interior of the ellipse.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, void> FillEllipse;

    /// <summary>
    /// Draws the outline of the specified geometry using the specified stroke style.
    /// </summary>
    /// <param name="geometry">The geometry to draw.</param>
    /// <param name="brush">The brush used to paint the geometry's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry's outline.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, float, nint, void> DrawGeometry;

    /// <summary>
    /// Paints the interior of the specified geometry.
    /// </summary>
    /// <param name="geometry">The geometry to paint.</param>
    /// <param name="brush">The brush used to paint the geometry's interior.</param>
    /// <param name="opacityBrush">The opacity mask to apply to the geometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, nint, void> FillGeometry;

    /// <summary>
    /// Paints the interior of the specified mesh.
    /// </summary>
    /// <param name="mesh">The mesh to paint.</param>
    /// <param name="brush">The brush used to paint the mesh.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, void> FillMesh;

    /// <summary>
    /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
    /// </summary>
    /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
    /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
    /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
    /// <param name="destinationRectangle">The region of the render target to paint, in device-independent pixels.</param>
    /// <param name="sourceRectangle">The region of the bitmap to use as the opacity mask, in device-independent pixels.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, nint, D2D1OpacityMaskContent, void*, void*, void> FillOpacityMask;

    /// <summary>
    /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
    /// </summary>
    /// <param name="bitmap">The bitmap to render.</param>
    /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
    /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
    /// <param name="interpolationMode">The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</param>
    /// <param name="sourceRectangle">The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to be drawn.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, float, D2D1BitmapInterpolationMode, void*, void> DrawBitmap;

    /// <summary>
    /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
    /// </summary>
    /// <param name="text">An array of Unicode characters to draw.</param>
    /// <param name="textLength">The number of characters in string.</param>
    /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
    /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
    /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
    /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, char*, uint, nint, void*, nint, D2D1DrawTextOptions, DWriteMeasuringMode, void> DrawText;

    /// <summary>
    /// Draws the formatted text described by the specified <see cref="DWriteTextLayout"/> object.
    /// </summary>
    /// <param name="origin">The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.</param>
    /// <param name="textLayout">The formatted text to draw.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect.</param>
    /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, nint, nint, D2D1DrawTextOptions, void> DrawTextLayout;

    /// <summary>
    /// Draws the specified glyphs.
    /// </summary>
    /// <param name="baselineOrigin">The origin, in device-independent pixels, of the glyphs' baseline.</param>
    /// <param name="glyphRun">The glyphs to render.</param>
    /// <param name="foregroundBrush">The brush used to paint the specified glyphs.</param>
    /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, void*, nint, DWriteMeasuringMode, void> DrawGlyphRun;

    /// <summary>
    /// Applies the specified transform to the render target, replacing the existing transformation. All subsequent drawing operations occur in the transformed space.
    /// </summary>
    /// <param name="transform">The transform to apply to the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> SetTransform;

    /// <summary>
    /// Gets the current transform of the render target.
    /// </summary>
    /// <param name="transform">The current transform of the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetTransform;

    /// <summary>
    /// Sets the antialiasing mode of the render target. The antialiasing mode applies to all subsequent drawing operations, excluding text and glyph drawing operations.
    /// </summary>
    /// <param name="antialiasMode">The antialiasing mode for future drawing operations.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1AntialiasMode, void> SetAntialiasMode;

    /// <summary>
    /// Retrieves the current antialiasing mode for nontext drawing operations.
    /// </summary>
    /// <returns>The current antialiasing mode for nontext drawing operations.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1AntialiasMode> GetAntialiasMode;

    /// <summary>
    /// Specifies the antialiasing mode to use for subsequent text and glyph drawing operations.
    /// </summary>
    /// <param name="textAntialiasMode">The antialiasing mode to use for subsequent text and glyph drawing operations.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1TextAntialiasMode, void> SetTextAntialiasMode;

    /// <summary>
    /// Gets the current antialiasing mode for text and glyph drawing operations.
    /// </summary>
    /// <returns>The current antialiasing mode for text and glyph drawing operations.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1TextAntialiasMode> GetTextAntialiasMode;

    /// <summary>
    /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
    /// </summary>
    /// <param name="textRenderingParams">The text rendering options to be applied to all subsequent text and glyph drawing operations.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> SetTextRenderingParams;

    /// <summary>
    /// Retrieves the render target's current text rendering options.
    /// </summary>
    /// <param name="textRenderingParams">The render target's current text rendering options.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetTextRenderingParams;

    /// <summary>
    /// Specifies a label for subsequent drawing operations.
    /// </summary>
    /// <param name="tag1">A first label to apply to subsequent drawing operations.</param>
    /// <param name="tag2">A second label to apply to subsequent drawing operations.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, ulong, ulong, void> SetTags;

    /// <summary>
    /// Gets the label for subsequent drawing operations.
    /// </summary>
    /// <param name="tag1">The first label for subsequent drawing operations.</param>
    /// <param name="tag2">The second label for subsequent drawing operations.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, ulong*, ulong*, void> GetTags;

    /// <summary>
    /// Adds the specified layer to the render target so that it receives all subsequent drawing operations until <see cref="PopLayer"/> is called.
    /// </summary>
    /// <param name="layerParameters">The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</param>
    /// <param name="layer">The layer that receives subsequent drawing operations.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, void> PushLayer;

    /// <summary>
    /// Stops redirecting drawing operations to the layer that is specified by the last <see cref="PushLayer"/> call.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> PopLayer;

    /// <summary>
    /// Executes all pending drawing commands.
    /// </summary>
    /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
    /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, ulong*, ulong*, int> Flush;

    /// <summary>
    /// Saves the current drawing state to the specified <see cref="ID2D1DrawingStateBlock"/>.
    /// </summary>
    /// <param name="drawingStateBlock">The current drawing state of the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> SaveDrawingState;

    /// <summary>
    /// Sets the render target's drawing state to that of the specified <see cref="ID2D1DrawingStateBlock"/>.
    /// </summary>
    /// <param name="drawingStateBlock">The new drawing state of the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void> RestoreDrawingState;

    /// <summary>
    /// Specifies a rectangle to which all subsequent drawing operations are clipped.
    /// </summary>
    /// <param name="clipRect">The size and position of the clipping area, in device-independent pixels.</param>
    /// <param name="antialiasMode">The antialiasing mode that is used to draw the edges of clip rectangles that have subpixel boundaries, and to blend the clip with the scene contents. The blending is performed once when the <see cref="PopAxisAlignedClip"/> method is called, and does not apply to each primitive within the layer.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, D2D1AntialiasMode, void> PushAxisAlignedClip;

    /// <summary>
    /// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to subsequent drawing operations.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> PopAxisAlignedClip;

    /// <summary>
    /// Clears the drawing area to the specified color.
    /// </summary>
    /// <param name="clearColor">The color to which the drawing area is cleared.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> Clear;

    /// <summary>
    /// Initiates drawing on this render target.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> BeginDraw;

    /// <summary>
    /// Ends drawing operations on the render target and indicates the current error state and associated tags.
    /// </summary>
    /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
    /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, ulong*, ulong*, int> EndDraw;

    /// <summary>
    /// Retrieves the pixel format and alpha mode of the render target.
    /// </summary>
    /// <param name="pixelFormat">The pixel format and alpha mode of the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetPixelFormat;

    /// <summary>
    /// Sets the dots per inch (DPI) of the render target.
    /// </summary>
    /// <param name="dpiX">A value greater than or equal to zero that specifies the horizontal DPI of the render target.</param>
    /// <param name="dpiY">A value greater than or equal to zero that specifies the vertical DPI of the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, float, void> SetDpi;

    /// <summary>
    /// Return the render target's dots per inch (DPI).
    /// </summary>
    /// <param name="dpiX">The horizontal DPI of the render target.</param>
    /// <param name="dpiY">The vertical DPI of the render target.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float*, float*, void> GetDpi;

    /// <summary>
    /// Returns the size of the render target in device-independent pixels.
    /// </summary>
    /// <param name="size">The current size of the render target in device-independent pixels.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetSize;

    /// <summary>
    /// Returns the size of the render target in device pixels.
    /// </summary>
    /// <param name="size">The size of the render target in device pixels.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetPixelSize;

    /// <summary>
    /// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
    /// </summary>
    /// <returns>The maximum size, in pixels, of any one bitmap dimension supported by the render target.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetMaximumBitmapSize;

    /// <summary>
    /// Indicates whether the render target supports the specified properties.
    /// </summary>
    /// <param name="renderTargetProperties">The render target properties to test.</param>
    /// <returns><value>true</value> if the specified render target properties are supported by this render target; otherwise, <value>false</value>.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, int> IsSupported;
}
