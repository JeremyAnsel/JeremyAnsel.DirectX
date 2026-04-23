// <copyright file="D2D1Factory.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;
using JeremyAnsel.DirectX.DWrite;
using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Creates Direct2D resources.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Factory : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1FactoryGuid = typeof(ID2D1Factory).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Factory* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Factory"/> class.
    /// </summary>
    public D2D1Factory(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Factory**)comPtr;
    }

    /// <summary>
    /// Creates a factory object that can be used to create Direct2D resources.
    /// </summary>
    /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
    /// <returns>The new factory.</returns>
    public static D2D1Factory Create(D2D1FactoryType factoryType)
    {
        nint ptr;
        int hr = NativeMethods.D2D1CreateFactory(factoryType, typeof(ID2D1Factory).GUID, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Factory(ptr);
    }

    /// <summary>
    /// Creates a factory object that can be used to create Direct2D resources.
    /// </summary>
    /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
    /// <param name="factoryOptions">The level of detail provided to the debugging layer.</param>
    /// <returns>The new factory.</returns>
    public static D2D1Factory Create(D2D1FactoryType factoryType, in D2D1FactoryOptions factoryOptions)
    {
        int size = D2D1FactoryOptions.NativeRequiredSize();
        byte* factoryOptionsPtr = stackalloc byte[size];
        D2D1FactoryOptions.NativeWriteTo((nint)factoryOptionsPtr, factoryOptions);
        nint ptr;
        int hr = NativeMethods.D2D1CreateFactory(factoryType, typeof(ID2D1Factory).GUID, factoryOptionsPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Factory(ptr);
    }

    /// <summary>
    /// Creates a factory object that can be used to create Direct2D resources.
    /// </summary>
    /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
    /// <param name="debugLevel">The level of detail provided to the debugging layer.</param>
    /// <returns>The new factory.</returns>
    public static D2D1Factory Create(D2D1FactoryType factoryType, D2D1DebugLevel debugLevel)
    {
        D2D1FactoryOptions factoryOptions = new(debugLevel);
        return Create(factoryType, factoryOptions);
    }

    /// <summary>
    /// Forces the factory to refresh any system defaults that it might have changed since factory creation.
    /// </summary>
    public void ReloadSystemMetrics()
    {
        int hr = _comImpl->ReloadSystemMetrics(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Retrieves the current desktop dots per inch (DPI). To refresh this value, call <see cref="ReloadSystemMetrics"/>.
    /// </summary>
    /// <param name="dpiX">The horizontal DPI of the desktop.</param>
    /// <param name="dpiY">The vertical DPI of the desktop.</param>
    public void GetDesktopDpi(out float dpiX, out float dpiY)
    {
        float x;
        float y;
        _comImpl->GetDesktopDpi(_comPtr, &x, &y);
        dpiX = x;
        dpiY = y;
    }

    /// <summary>
    /// Creates an <see cref="D2D1RectangleGeometry"/>.
    /// </summary>
    /// <param name="rectangle">The coordinates of the rectangle geometry.</param>
    /// <returns>The rectangle geometry created by this method.</returns>
    public D2D1RectangleGeometry CreateRectangleGeometry(in D2D1RectF rectangle)
    {
        int size = D2D1RectF.NativeRequiredSize();
        byte* rectanglePtr = stackalloc byte[size];
        D2D1RectF.NativeWriteTo((nint)rectanglePtr, rectangle);
        nint ptr;
        int hr = _comImpl->CreateRectangleGeometry(_comPtr, rectanglePtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RectangleGeometry(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1RoundedRectangleGeometry"/>.
    /// </summary>
    /// <param name="roundedRectangle">The coordinates and corner radii of the rounded rectangle geometry.</param>
    /// <returns>The rounded rectangle geometry created by this method.</returns>
    public D2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(in D2D1RoundedRect roundedRectangle)
    {
        int size = D2D1RoundedRect.NativeRequiredSize();
        byte* roundedRectanglePtr = stackalloc byte[size];
        D2D1RoundedRect.NativeWriteTo((nint)roundedRectanglePtr, roundedRectangle);
        nint ptr;
        int hr = _comImpl->CreateRoundedRectangleGeometry(_comPtr, roundedRectanglePtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RoundedRectangleGeometry(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1EllipseGeometry"/>.
    /// </summary>
    /// <param name="ellipse">A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</param>
    /// <returns>The ellipse geometry created by this method.</returns>
    public D2D1EllipseGeometry CreateEllipseGeometry(in D2D1Ellipse ellipse)
    {
        int size = D2D1Ellipse.NativeRequiredSize();
        byte* ellipsePtr = stackalloc byte[size];
        D2D1Ellipse.NativeWriteTo((nint)ellipsePtr, ellipse);
        nint ptr;
        int hr = _comImpl->CreateEllipseGeometry(_comPtr, ellipsePtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1EllipseGeometry(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1GeometryGroup"/>, which is an object that holds other geometries.
    /// </summary>
    /// <param name="fillMode">A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</param>
    /// <param name="geometries">An array containing the geometry objects to add to the geometry group.</param>
    /// <returns>The geometry group created by this method.</returns>
    public D2D1GeometryGroup CreateGeometryGroup(D2D1FillMode fillMode, D2D1Geometry[]? geometries)
    {
        return CreateGeometryGroup(fillMode, geometries.AsSpan());
    }

    /// <summary>
    /// Creates an <see cref="D2D1GeometryGroup"/>, which is an object that holds other geometries.
    /// </summary>
    /// <param name="fillMode">A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</param>
    /// <param name="geometries">An array containing the geometry objects to add to the geometry group.</param>
    /// <returns>The geometry group created by this method.</returns>
    public D2D1GeometryGroup CreateGeometryGroup(D2D1FillMode fillMode, ReadOnlySpan<D2D1Geometry> geometries)
    {
        if (geometries.Length == 0)
        {
            throw new ArgumentNullException(nameof(geometries));
        }

        nint* geometriesPtr = stackalloc nint[geometries.Length];
        for (int i = 0; i < geometries.Length; i++)
        {
            geometriesPtr[i] = geometries[i].Handle;
        }

        nint ptr;
        int hr = _comImpl->CreateGeometryGroup(_comPtr, fillMode, geometriesPtr, (uint)geometries.Length, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1GeometryGroup(ptr);
    }

    /// <summary>
    /// Transforms the specified geometry and stores the result as an <see cref="D2D1TransformedGeometry"/> object.
    /// </summary>
    /// <param name="sourceGeometry">The geometry to transform.</param>
    /// <param name="transform">The transformation to apply.</param>
    /// <returns>The new transformed geometry object.</returns>
    public D2D1TransformedGeometry CreateTransformedGeometry(D2D1Geometry? sourceGeometry, in D2D1Matrix3X2F transform)
    {
        if (sourceGeometry is null)
        {
            throw new ArgumentNullException(nameof(sourceGeometry));
        }

        int size = D2D1Matrix3X2F.NativeRequiredSize();
        byte* transformPtr = stackalloc byte[size];
        D2D1Matrix3X2F.NativeWriteTo((nint)transformPtr, transform);
        nint ptr;
        int hr = _comImpl->CreateTransformedGeometry(_comPtr, sourceGeometry.Handle, transformPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1TransformedGeometry(ptr);

    }

    /// <summary>
    /// Creates an empty <see cref="D2D1PathGeometry"/>.
    /// </summary>
    /// <returns>The path geometry created by this method.</returns>
    public D2D1PathGeometry CreatePathGeometry()
    {
        nint ptr;
        int hr = _comImpl->CreatePathGeometry(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1PathGeometry(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1StrokeStyle"/> that describes start cap, dash pattern, and other features of a stroke.
    /// </summary>
    /// <param name="strokeStyleProperties">A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</param>
    /// <param name="dashes">An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each dash and space in the dash pattern is the product of the element value in the array and the stroke width.</param>
    /// <returns>The stroke style created by this method.</returns>
    public D2D1StrokeStyle CreateStrokeStyle(in D2D1StrokeStyleProperties strokeStyleProperties, float[]? dashes)
    {
        return CreateStrokeStyle(strokeStyleProperties, dashes.AsSpan());
    }

    /// <summary>
    /// Creates an <see cref="D2D1StrokeStyle"/> that describes start cap, dash pattern, and other features of a stroke.
    /// </summary>
    /// <param name="strokeStyleProperties">A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</param>
    /// <param name="dashes">An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each dash and space in the dash pattern is the product of the element value in the array and the stroke width.</param>
    /// <returns>The stroke style created by this method.</returns>
    public D2D1StrokeStyle CreateStrokeStyle(in D2D1StrokeStyleProperties strokeStyleProperties, ReadOnlySpan<float> dashes)
    {
        int size = D2D1StrokeStyleProperties.NativeRequiredSize();
        byte* strokeStylePropertiesPtr = stackalloc byte[size];
        D2D1StrokeStyleProperties.NativeWriteTo((nint)strokeStylePropertiesPtr, strokeStyleProperties);

        fixed (float* dashesPtr = dashes)
        {
            nint ptr;
            int hr = _comImpl->CreateStrokeStyle(_comPtr, strokeStylePropertiesPtr, dashesPtr, (uint)dashes.Length, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1StrokeStyle(ptr);
        }
    }

    /// <summary>
    /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
    /// </summary>
    /// <returns>The new drawing state block created by this method.</returns>
    public D2D1DrawingStateBlock CreateDrawingStateBlock()
    {
        nint ptr;
        int hr = _comImpl->CreateDrawingStateBlock(_comPtr, null, 0, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1DrawingStateBlock(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
    /// </summary>
    /// <param name="drawingStateDescription">A structure that contains antialiasing, transform, and tags information.</param>
    /// <returns>The new drawing state block created by this method.</returns>
    public D2D1DrawingStateBlock CreateDrawingStateBlock(in D2D1DrawingStateDescription drawingStateDescription)
    {
        int size = D2D1DrawingStateDescription.NativeRequiredSize();
        byte* drawingStateDescriptionPtr = stackalloc byte[size];
        nint ptr;
        int hr = _comImpl->CreateDrawingStateBlock(_comPtr, drawingStateDescriptionPtr, 0, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1DrawingStateBlock(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
    /// </summary>
    /// <param name="textRenderingParams">Optional text parameters that indicate how text should be rendered.</param>
    /// <returns>The new drawing state block created by this method.</returns>
    public D2D1DrawingStateBlock CreateDrawingStateBlock(DWriteRenderingParams? textRenderingParams)
    {
        nint textRenderingParamsPtr = textRenderingParams is null ? 0 : textRenderingParams.Handle;
        nint ptr;
        int hr = _comImpl->CreateDrawingStateBlock(_comPtr, null, textRenderingParamsPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1DrawingStateBlock(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
    /// </summary>
    /// <param name="drawingStateDescription">A structure that contains antialiasing, transform, and tags information.</param>
    /// <param name="textRenderingParams">Optional text parameters that indicate how text should be rendered.</param>
    /// <returns>The new drawing state block created by this method.</returns>
    public D2D1DrawingStateBlock CreateDrawingStateBlock(in D2D1DrawingStateDescription drawingStateDescription, DWriteRenderingParams? textRenderingParams)
    {
        int size = D2D1DrawingStateDescription.NativeRequiredSize();
        byte* drawingStateDescriptionPtr = stackalloc byte[size];
        nint textRenderingParamsPtr = textRenderingParams is null ? 0 : textRenderingParams.Handle;
        nint ptr;
        int hr = _comImpl->CreateDrawingStateBlock(_comPtr, drawingStateDescriptionPtr, textRenderingParamsPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1DrawingStateBlock(ptr);
    }

    /// <summary>
    /// Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="target">The bitmap that receives the rendering output of the render target.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
    public D2D1RenderTarget CreateWicBitmapRenderTarget(DXComObject target, in D2D1RenderTargetProperties renderTargetProperties)
    {
        return CreateWicBitmapRenderTarget(target.Handle, renderTargetProperties);
    }

    /// <summary>
    /// Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="target">The bitmap that receives the rendering output of the render target.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
    public D2D1RenderTarget CreateWicBitmapRenderTarget(nint target, in D2D1RenderTargetProperties renderTargetProperties)
    {
        if (target == 0)
        {
            throw new ArgumentNullException(nameof(target));
        }

        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);

        nint targetPtr = DXUtils.QueryInterface(target, ComInteropInterfacesGuids.WICBitmapGuid);

        try
        {
            nint ptr;
            int hr = _comImpl->CreateWicBitmapRenderTarget(_comPtr, targetPtr, renderTargetPropertiesPtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1RenderTarget(ptr);
        }
        finally
        {
            DXUtils.Release(targetPtr);
        }
    }

    /// <summary>
    /// Creates an <see cref="D2D1HwndRenderTarget"/>, a render target that renders to a window.
    /// </summary>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <param name="hwndRenderTargetProperties">The window handle, initial size (in pixels), and present options.</param>
    /// <returns>The <see cref="D2D1HwndRenderTarget"/> object created by this method.</returns>
    public D2D1HwndRenderTarget CreateHwndRenderTarget(in D2D1RenderTargetProperties renderTargetProperties, in D2D1HwndRenderTargetProperties hwndRenderTargetProperties)
    {
        int renderTargetPropertiesSize = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[renderTargetPropertiesSize];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);
        int hwndRenderTargetPropertiesSize = D2D1HwndRenderTargetProperties.NativeRequiredSize();
        byte* hwndRenderTargetPropertiesPtr = stackalloc byte[hwndRenderTargetPropertiesSize];
        D2D1HwndRenderTargetProperties.NativeWriteTo((nint)hwndRenderTargetPropertiesPtr, hwndRenderTargetProperties);
        nint ptr;
        int hr = _comImpl->CreateHwndRenderTarget(_comPtr, renderTargetPropertiesPtr, hwndRenderTargetPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1HwndRenderTarget(hr);
    }

    /// <summary>
    /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
    /// </summary>
    /// <param name="dxgiSurface">The <see cref="DxgiSurface"/> to which the render target will draw.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
    public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface? dxgiSurface, in D2D1RenderTargetProperties renderTargetProperties)
    {
        if (dxgiSurface is null)
        {
            throw new ArgumentNullException(nameof(dxgiSurface));
        }

        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);
        nint ptr;
        int hr = _comImpl->CreateDxgiSurfaceRenderTarget(_comPtr, dxgiSurface.Handle, renderTargetPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RenderTarget(ptr);
    }

    /// <summary>
    /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
    /// </summary>
    /// <param name="dxgiSurface">The <see cref="DxgiSurface1"/> to which the render target will draw.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
    public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface1? dxgiSurface, in D2D1RenderTargetProperties renderTargetProperties)
    {
        if (dxgiSurface is null)
        {
            throw new ArgumentNullException(nameof(dxgiSurface));
        }

        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);
        nint ptr;
        int hr = _comImpl->CreateDxgiSurfaceRenderTarget(_comPtr, dxgiSurface.Handle, renderTargetPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RenderTarget(ptr);
    }

    /// <summary>
    /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
    /// </summary>
    /// <param name="dxgiSurface">The <see cref="DxgiSurface2"/> to which the render target will draw.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
    public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface2? dxgiSurface, in D2D1RenderTargetProperties renderTargetProperties)
    {
        if (dxgiSurface is null)
        {
            throw new ArgumentNullException(nameof(dxgiSurface));
        }

        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);
        nint ptr;
        int hr = _comImpl->CreateDxgiSurfaceRenderTarget(_comPtr, dxgiSurface.Handle, renderTargetPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RenderTarget(ptr);
    }

    /// <summary>
    /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
    /// </summary>
    /// <param name="dxgiSurface">The <see cref="DxgiSurface3"/> to which the render target will draw.</param>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
    public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface3? dxgiSurface, in D2D1RenderTargetProperties renderTargetProperties)
    {
        if (dxgiSurface is null)
        {
            throw new ArgumentNullException(nameof(dxgiSurface));
        }

        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);
        nint ptr;
        int hr = _comImpl->CreateDxgiSurfaceRenderTarget(_comPtr, dxgiSurface.Handle, renderTargetPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RenderTarget(ptr);
    }

    /// <summary>
    /// Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.
    /// </summary>
    /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
    /// <returns>The <see cref="D2D1DCRenderTarget"/> created by the method.</returns>
    public D2D1DCRenderTarget CreateDCRenderTarget(in D2D1RenderTargetProperties renderTargetProperties)
    {
        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* renderTargetPropertiesPtr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)renderTargetPropertiesPtr, renderTargetProperties);
        nint ptr;
        int hr = _comImpl->CreateDCRenderTarget(_comPtr, renderTargetPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1DCRenderTarget(ptr);
    }
}
