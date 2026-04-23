// <copyright file="ID2D1Factory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Creates Direct2D resources.
/// </summary>
[Guid("06152247-6f50-465a-9245-118bfd3b6007")]
internal unsafe readonly struct ID2D1Factory
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Forces the factory to refresh any system defaults that it might have changed since factory creation.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, int> ReloadSystemMetrics;

    /// <summary>
    /// Retrieves the current desktop dots per inch (DPI). To refresh this value, call <see cref="ReloadSystemMetrics"/>.
    /// </summary>
    /// <param name="dpiX">The horizontal DPI of the desktop.</param>
    /// <param name="dpiY">The vertical DPI of the desktop.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float*, float*, void> GetDesktopDpi;

    /// <summary>
    /// Creates an <see cref="ID2D1RectangleGeometry"/>.
    /// </summary>
    /// <param name="rectangle">The coordinates of the rectangle geometry.</param>
    /// <param name="rectangleGeometry">The rectangle geometry created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, int> CreateRectangleGeometry;

    /// <summary>
    /// Creates an <see cref="ID2D1RoundedRectangleGeometry"/>.
    /// </summary>
    /// <param name="roundedRectangle">The coordinates and corner radii of the rounded rectangle geometry.</param>
    /// <param name="roundedRectangleGeometry">The rounded rectangle geometry created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, int> CreateRoundedRectangleGeometry;

    /// <summary>
    /// Creates an <see cref="ID2D1EllipseGeometry"/>.
    /// </summary>
    /// <param name="ellipse">A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</param>
    /// <param name="ellipseGeometry">The ellipse geometry created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, int> CreateEllipseGeometry;

    /// <summary>
    /// Creates an <see cref="ID2D1GeometryGroup"/>, which is an object that holds other geometries.
    /// </summary>
    /// <param name="fillMode">A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</param>
    /// <param name="geometries">An array containing the geometry objects to add to the geometry group.</param>
    /// <param name="geometriesCount">The number of elements in geometries.</param>
    /// <param name="geometryGroup">The geometry group created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1FillMode, nint*, uint, nint*, int> CreateGeometryGroup;

    /// <summary>
    /// Transforms the specified geometry and stores the result as an <see cref="ID2D1TransformedGeometry"/> object.
    /// </summary>
    /// <param name="sourceGeometry">The geometry to transform.</param>
    /// <param name="transform">The transformation to apply.</param>
    /// <param name="transformedGeometry">The new transformed geometry object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint*, int> CreateTransformedGeometry;

    /// <summary>
    /// Creates an empty <see cref="ID2D1PathGeometry"/>.
    /// </summary>
    /// <param name="pathGeometry">The path geometry created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> CreatePathGeometry;

    /// <summary>
    /// Creates an <see cref="ID2D1StrokeStyle"/> that describes start cap, dash pattern, and other features of a stroke.
    /// </summary>
    /// <param name="strokeStyleProperties">A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</param>
    /// <param name="dashes">An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each dash and space in the dash pattern is the product of the element value in the array and the stroke width.</param>
    /// <param name="dashesCount">The number of elements in the dashes array.</param>
    /// <param name="strokeStyle">The stroke style created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, float*, uint, nint*, int> CreateStrokeStyle;

    /// <summary>
    /// Creates an <see cref="ID2D1DrawingStateBlock"/> that can be used with the <see cref="ID2D1RenderTarget.SaveDrawingState"/> and <see cref="ID2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
    /// </summary>
    /// <param name="drawingStateDescription">A structure that contains antialiasing, transform, and tags information.</param>
    /// <param name="textRenderingParams">Optional text parameters that indicate how text should be rendered.</param>
    /// <param name="drawingStateBlock">The new drawing state block created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint, nint*, int> CreateDrawingStateBlock;

    /// <summary>
    /// Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="target">The bitmap that receives the rendering output of the render target.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <param name="renderTarget">The <see cref="ID2D1RenderTarget"/> object created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint*, int> CreateWicBitmapRenderTarget;

    /// <summary>
    /// Creates an <see cref="ID2D1HwndRenderTarget"/>, a render target that renders to a window.
    /// </summary>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <param name="hwndRenderTargetProperties">The window handle, initial size (in pixels), and present options.</param>
    /// <param name="hwndRenderTarget">The <see cref="ID2D1HwndRenderTarget"/> object created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, nint*, int> CreateHwndRenderTarget;

    /// <summary>
    /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
    /// </summary>
    /// <param name="dxgiSurface">The <see cref="DxgiSurface"/> to which the render target will draw.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <param name="renderTarget">The <see cref="ID2D1RenderTarget"/> object created by this method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, nint*, int> CreateDxgiSurfaceRenderTarget;

    /// <summary>
    /// Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.
    /// </summary>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <param name="renderTarget">The <see cref="ID2D1DCRenderTarget"/> created by the method.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nint*, int> CreateDCRenderTarget;
}
