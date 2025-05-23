﻿// <copyright file="D2D1Factory.cs" company="Jérémy Ansel">
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
    using JeremyAnsel.DirectX.Dxgi;

    /// <summary>
    /// Creates Direct2D resources.
    /// </summary>
    public sealed class D2D1Factory : IDisposable, ID2D1Releasable
    {
        /// <summary>
        /// The D2D1 factory interface.
        /// </summary>
        private readonly ID2D1Factory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Factory"/> class.
        /// </summary>
        /// <param name="factory">A D2D1 factory interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Factory(ID2D1Factory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.factory; }
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D2D1 object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D2D1Factory value)
        {
            return value != null && value.Handle != null;
        }

        /// <summary>
        /// Creates a factory object that can be used to create Direct2D resources.
        /// </summary>
        /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
        /// <returns>The new factory.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Factory Create(D2D1FactoryType factoryType)
        {
            NativeMethods.D2D1CreateFactory(factoryType, typeof(ID2D1Factory).GUID, IntPtr.Zero, out ID2D1Factory factory);

            if (factory == null)
            {
                return null;
            }

            return new D2D1Factory(factory);
        }

        /// <summary>
        /// Creates a factory object that can be used to create Direct2D resources.
        /// </summary>
        /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
        /// <param name="factoryOptions">The level of detail provided to the debugging layer.</param>
        /// <returns>The new factory.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Factory Create(D2D1FactoryType factoryType, D2D1FactoryOptions factoryOptions)
        {
            ID2D1Factory factory;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1FactoryOptions)));

            try
            {
                Marshal.StructureToPtr(factoryOptions, ptr, false);

                NativeMethods.D2D1CreateFactory(factoryType, typeof(ID2D1Factory).GUID, ptr, out factory);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (factory == null)
            {
                return null;
            }

            return new D2D1Factory(factory);
        }

        /// <summary>
        /// Creates a factory object that can be used to create Direct2D resources.
        /// </summary>
        /// <param name="factoryType">The threading model of the factory and the resources it creates.</param>
        /// <param name="debugLevel">The level of detail provided to the debugging layer.</param>
        /// <returns>The new factory.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static D2D1Factory Create(D2D1FactoryType factoryType, D2D1DebugLevel debugLevel)
        {
            var factoryOptions = new D2D1FactoryOptions(debugLevel);
            return D2D1Factory.Create(factoryType, factoryOptions);
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.Handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the <see cref="D2D1Factory"/> object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM D2D1 interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Forces the factory to refresh any system defaults that it might have changed since factory creation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ReloadSystemMetrics()
        {
            this.factory.ReloadSystemMetrics();
        }

        /// <summary>
        /// Retrieves the current desktop dots per inch (DPI). To refresh this value, call <see cref="ReloadSystemMetrics"/>.
        /// </summary>
        /// <param name="dpiX">The horizontal DPI of the desktop.</param>
        /// <param name="dpiY">The vertical DPI of the desktop.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "0#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void GetDesktopDpi(out float dpiX, out float dpiY)
        {
            this.factory.GetDesktopDpi(out dpiX, out dpiY);
        }

        /// <summary>
        /// Creates an <see cref="D2D1RectangleGeometry"/>.
        /// </summary>
        /// <param name="rectangle">The coordinates of the rectangle geometry.</param>
        /// <returns>The rectangle geometry created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectangleGeometry CreateRectangleGeometry(D2D1RectF rectangle)
        {
            this.factory.CreateRectangleGeometry(ref rectangle, out ID2D1RectangleGeometry rectangleGeometry);

            if (rectangleGeometry == null)
            {
                return null;
            }

            return new D2D1RectangleGeometry(rectangleGeometry);
        }

        /// <summary>
        /// Creates an <see cref="D2D1RoundedRectangleGeometry"/>.
        /// </summary>
        /// <param name="roundedRectangle">The coordinates and corner radii of the rounded rectangle geometry.</param>
        /// <returns>The rounded rectangle geometry created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RoundedRectangleGeometry CreateRoundedRectangleGeometry(D2D1RoundedRect roundedRectangle)
        {
            this.factory.CreateRoundedRectangleGeometry(ref roundedRectangle, out ID2D1RoundedRectangleGeometry roundedRectangleGeometry);

            if (roundedRectangleGeometry == null)
            {
                return null;
            }

            return new D2D1RoundedRectangleGeometry(roundedRectangleGeometry);
        }

        /// <summary>
        /// Creates an <see cref="D2D1EllipseGeometry"/>.
        /// </summary>
        /// <param name="ellipse">A value that describes the center point, x-radius, and y-radius of the ellipse geometry.</param>
        /// <returns>The ellipse geometry created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1EllipseGeometry CreateEllipseGeometry(D2D1Ellipse ellipse)
        {
            this.factory.CreateEllipseGeometry(ref ellipse, out ID2D1EllipseGeometry ellipseGeometry);

            if (ellipseGeometry == null)
            {
                return null;
            }

            return new D2D1EllipseGeometry(ellipseGeometry);
        }

        /// <summary>
        /// Creates an <see cref="D2D1GeometryGroup"/>, which is an object that holds other geometries.
        /// </summary>
        /// <param name="fillMode">A value that specifies the rule that a composite shape uses to determine whether a given point is part of the geometry.</param>
        /// <param name="geometries">An array containing the geometry objects to add to the geometry group.</param>
        /// <returns>The geometry group created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GeometryGroup CreateGeometryGroup(D2D1FillMode fillMode, D2D1Geometry[] geometries)
        {
            if (geometries == null)
            {
                throw new ArgumentNullException(nameof(geometries));
            }

            this.factory.CreateGeometryGroup(fillMode, Array.ConvertAll(geometries, t => t.GetHandle<ID2D1Geometry>()), (uint)geometries.Length, out ID2D1GeometryGroup geometryGroup);

            if (geometryGroup == null)
            {
                return null;
            }

            return new D2D1GeometryGroup(geometryGroup);
        }

        /// <summary>
        /// Transforms the specified geometry and stores the result as an <see cref="D2D1TransformedGeometry"/> object.
        /// </summary>
        /// <param name="sourceGeometry">The geometry to transform.</param>
        /// <param name="transform">The transformation to apply.</param>
        /// <returns>The new transformed geometry object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1TransformedGeometry CreateTransformedGeometry(D2D1Geometry sourceGeometry, D2D1Matrix3X2F transform)
        {
            if (sourceGeometry == null)
            {
                throw new ArgumentNullException(nameof(sourceGeometry));
            }

            this.factory.CreateTransformedGeometry(sourceGeometry.GetHandle<ID2D1Geometry>(), ref transform, out ID2D1TransformedGeometry transformedGeometry);

            if (transformedGeometry == null)
            {
                return null;
            }

            return new D2D1TransformedGeometry(transformedGeometry);
        }

        /// <summary>
        /// Creates an empty <see cref="D2D1PathGeometry"/>.
        /// </summary>
        /// <returns>The path geometry created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1PathGeometry CreatePathGeometry()
        {
            this.factory.CreatePathGeometry(out ID2D1PathGeometry pathGeometry);

            if (pathGeometry == null)
            {
                return null;
            }

            return new D2D1PathGeometry(pathGeometry);
        }

        /// <summary>
        /// Creates an <see cref="D2D1StrokeStyle"/> that describes start cap, dash pattern, and other features of a stroke.
        /// </summary>
        /// <param name="strokeStyleProperties">A structure that describes the stroke's line cap, dash offset, and other details of a stroke.</param>
        /// <param name="dashes">An array whose elements are set to the length of each dash and space in the dash pattern. The first element sets the length of a dash, the second element sets the length of a space, the third element sets the length of a dash, and so on. The length of each dash and space in the dash pattern is the product of the element value in the array and the stroke width.</param>
        /// <returns>The stroke style created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1StrokeStyle CreateStrokeStyle(D2D1StrokeStyleProperties strokeStyleProperties, float[] dashes)
        {
            this.factory.CreateStrokeStyle(ref strokeStyleProperties, dashes, dashes == null ? 0U : (uint)dashes.Length, out ID2D1StrokeStyle strokeStyle);

            if (strokeStyle == null)
            {
                return null;
            }

            return new D2D1StrokeStyle(strokeStyle);
        }

        /// <summary>
        /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
        /// </summary>
        /// <returns>The new drawing state block created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1DrawingStateBlock CreateDrawingStateBlock()
        {
            this.factory.CreateDrawingStateBlock(IntPtr.Zero, null, out ID2D1DrawingStateBlock drawingStateBlock);

            if (drawingStateBlock == null)
            {
                return null;
            }

            return new D2D1DrawingStateBlock(drawingStateBlock);
        }

        /// <summary>
        /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
        /// </summary>
        /// <param name="drawingStateDescription">A structure that contains antialiasing, transform, and tags information.</param>
        /// <returns>The new drawing state block created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1DrawingStateBlock CreateDrawingStateBlock(D2D1DrawingStateDescription drawingStateDescription)
        {
            ID2D1DrawingStateBlock drawingStateBlock;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1DrawingStateDescription)));

            try
            {
                Marshal.StructureToPtr(drawingStateDescription, ptr, false);

                this.factory.CreateDrawingStateBlock(ptr, null, out drawingStateBlock);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (drawingStateBlock == null)
            {
                return null;
            }

            return new D2D1DrawingStateBlock(drawingStateBlock);
        }

        /// <summary>
        /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
        /// </summary>
        /// <param name="textRenderingParams">Optional text parameters that indicate how text should be rendered.</param>
        /// <returns>The new drawing state block created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1DrawingStateBlock CreateDrawingStateBlock(DWriteRenderingParams textRenderingParams)
        {
            this.factory.CreateDrawingStateBlock(IntPtr.Zero, textRenderingParams == null ? null : (IDWriteRenderingParams)textRenderingParams.Handle, out ID2D1DrawingStateBlock drawingStateBlock);

            if (drawingStateBlock == null)
            {
                return null;
            }

            return new D2D1DrawingStateBlock(drawingStateBlock);
        }

        /// <summary>
        /// Creates an <see cref="D2D1DrawingStateBlock"/> that can be used with the <see cref="D2D1RenderTarget.SaveDrawingState"/> and <see cref="D2D1RenderTarget.RestoreDrawingState"/> methods of a render target.
        /// </summary>
        /// <param name="drawingStateDescription">A structure that contains antialiasing, transform, and tags information.</param>
        /// <param name="textRenderingParams">Optional text parameters that indicate how text should be rendered.</param>
        /// <returns>The new drawing state block created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1DrawingStateBlock CreateDrawingStateBlock(D2D1DrawingStateDescription drawingStateDescription, DWriteRenderingParams textRenderingParams)
        {
            ID2D1DrawingStateBlock drawingStateBlock;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1DrawingStateDescription)));

            try
            {
                Marshal.StructureToPtr(drawingStateDescription, ptr, false);

                this.factory.CreateDrawingStateBlock(ptr, textRenderingParams == null ? null : (IDWriteRenderingParams)textRenderingParams.Handle, out drawingStateBlock);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            if (drawingStateBlock == null)
            {
                return null;
            }

            return new D2D1DrawingStateBlock(drawingStateBlock);
        }

        /// <summary>
        /// Creates a render target that renders to a Microsoft Windows Imaging Component (WIC) bitmap.
        /// </summary>
        /// <param name="target">The bitmap that receives the rendering output of the render target.</param>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RenderTarget CreateWicBitmapRenderTarget(object target, D2D1RenderTargetProperties renderTargetProperties)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            this.factory.CreateWicBitmapRenderTarget((IWICBitmap)target, ref renderTargetProperties, out ID2D1RenderTarget renderTarget);

            if (renderTarget == null)
            {
                return null;
            }

            return new D2D1RenderTargetBase(renderTarget);
        }

        /// <summary>
        /// Creates an <see cref="D2D1HwndRenderTarget"/>, a render target that renders to a window.
        /// </summary>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <param name="hwndRenderTargetProperties">The window handle, initial size (in pixels), and present options.</param>
        /// <returns>The <see cref="D2D1HwndRenderTarget"/> object created by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1HwndRenderTarget CreateHwndRenderTarget(D2D1RenderTargetProperties renderTargetProperties, D2D1HwndRenderTargetProperties hwndRenderTargetProperties)
        {
            this.factory.CreateHwndRenderTarget(ref renderTargetProperties, ref hwndRenderTargetProperties, out ID2D1HwndRenderTarget hwndRenderTarget);

            if (hwndRenderTarget == null)
            {
                return null;
            }

            return new D2D1HwndRenderTarget(hwndRenderTarget);
        }

        /// <summary>
        /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
        /// </summary>
        /// <param name="dxgiSurface">The <see cref="DxgiSurface"/> to which the render target will draw.</param>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface dxgiSurface, D2D1RenderTargetProperties renderTargetProperties)
        {
            if (dxgiSurface == null)
            {
                throw new ArgumentNullException(nameof(dxgiSurface));
            }

            this.factory.CreateDxgiSurfaceRenderTarget((IDxgiSurface)dxgiSurface.Handle, ref renderTargetProperties, out ID2D1RenderTarget renderTarget);

            if (renderTarget == null)
            {
                return null;
            }

            return new D2D1RenderTargetBase(renderTarget);
        }

        /// <summary>
        /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
        /// </summary>
        /// <param name="dxgiSurface">The <see cref="DxgiSurface1"/> to which the render target will draw.</param>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface1 dxgiSurface, D2D1RenderTargetProperties renderTargetProperties)
        {
            if (dxgiSurface == null)
            {
                throw new ArgumentNullException(nameof(dxgiSurface));
            }

            this.factory.CreateDxgiSurfaceRenderTarget((IDxgiSurface)dxgiSurface.Handle, ref renderTargetProperties, out ID2D1RenderTarget renderTarget);

            if (renderTarget == null)
            {
                return null;
            }

            return new D2D1RenderTargetBase(renderTarget);
        }

        /// <summary>
        /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
        /// </summary>
        /// <param name="dxgiSurface">The <see cref="DxgiSurface2"/> to which the render target will draw.</param>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface2 dxgiSurface, D2D1RenderTargetProperties renderTargetProperties)
        {
            if (dxgiSurface == null)
            {
                throw new ArgumentNullException(nameof(dxgiSurface));
            }

            this.factory.CreateDxgiSurfaceRenderTarget((IDxgiSurface)dxgiSurface.Handle, ref renderTargetProperties, out ID2D1RenderTarget renderTarget);

            if (renderTarget == null)
            {
                return null;
            }

            return new D2D1RenderTargetBase(renderTarget);
        }

        /// <summary>
        /// Creates a render target that draws to a DirectX Graphics Infrastructure (DXGI) surface.
        /// </summary>
        /// <param name="dxgiSurface">The <see cref="DxgiSurface3"/> to which the render target will draw.</param>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <returns>The <see cref="D2D1RenderTarget"/> object created by this method.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RenderTarget CreateDxgiSurfaceRenderTarget(DxgiSurface3 dxgiSurface, D2D1RenderTargetProperties renderTargetProperties)
        {
            if (dxgiSurface == null)
            {
                throw new ArgumentNullException(nameof(dxgiSurface));
            }

            this.factory.CreateDxgiSurfaceRenderTarget((IDxgiSurface)dxgiSurface.Handle, ref renderTargetProperties, out ID2D1RenderTarget renderTarget);

            if (renderTarget == null)
            {
                return null;
            }

            return new D2D1RenderTargetBase(renderTarget);
        }

        /// <summary>
        /// Creates a render target that draws to a Windows Graphics Device Interface (GDI) device context.
        /// </summary>
        /// <param name="renderTargetProperties">The rendering mode, pixel format, remoting options, DPI information, and the minimum DirectX support required for hardware rendering.</param>
        /// <returns>The <see cref="D2D1DCRenderTarget"/> created by the method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1DCRenderTarget CreateDCRenderTarget(D2D1RenderTargetProperties renderTargetProperties)
        {
            this.factory.CreateDCRenderTarget(ref renderTargetProperties, out ID2D1DCRenderTarget renderTarget);

            if (renderTarget == null)
            {
                return null;
            }

            return new D2D1DCRenderTarget(renderTarget);
        }
    }
}
