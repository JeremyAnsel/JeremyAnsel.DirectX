// <copyright file="D2D1RenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.D2D1.ComInteropInterfaces;
using JeremyAnsel.DirectX.DWrite;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents an object that can receive drawing commands.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1RenderTarget : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1RenderTargetGuid = typeof(ID2D1RenderTarget).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1RenderTarget* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RenderTarget"/> class.
    /// </summary>
    public D2D1RenderTarget(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1RenderTarget**)comPtr;
    }

    /// <summary>
    /// Gets or sets the current transform of the render target.
    /// </summary>
    public D2D1Matrix3X2F Transform
    {
        get
        {
            int size = D2D1Matrix3X2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetTransform(_comPtr, ptr);
            return D2D1Matrix3X2F.NativeReadFrom((nint)ptr);
        }

        set
        {
            int size = D2D1Matrix3X2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D2D1Matrix3X2F.NativeWriteTo((nint)ptr, value);
            _comImpl->SetTransform(_comPtr, ptr);
        }
    }

    /// <summary>
    /// Gets or sets the current antialiasing mode for nontext drawing operations.
    /// </summary>
    public D2D1AntialiasMode AntialiasMode
    {
        get { return _comImpl->GetAntialiasMode(_comPtr); }
        set { _comImpl->SetAntialiasMode(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the current antialiasing mode for text and glyph drawing operations.
    /// </summary>
    public D2D1TextAntialiasMode TextAntialiasMode
    {
        get { return _comImpl->GetTextAntialiasMode(_comPtr); }
        set { _comImpl->SetTextAntialiasMode(_comPtr, value); }
    }

    /// <summary>
    /// Gets the pixel format and alpha mode of the render target.
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
    /// Gets the size of the render target in device-independent pixels.
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
    /// Gets the size of the render target in device pixels.
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
    /// Gets the maximum size, in device-dependent units (pixels), of any one bitmap dimension supported by the render target.
    /// </summary>
    public uint MaximumBitmapSize
    {
        get { return _comImpl->GetMaximumBitmapSize(_comPtr); }
    }

    /// <summary>
    /// Creates a Direct2D bitmap from a pointer to in-memory source data.
    /// </summary>
    /// <param name="size">The dimension of the bitmap to create in pixels.</param>
    /// <param name="srcData">A pointer to the memory location of the image data, or NULL to create an uninitialized bitmap.</param>
    /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If <paramref name="srcData"/> is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
    /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmap(in D2D1SizeU size, nint srcData, uint pitch, in D2D1BitmapProperties bitmapProperties)
    {
        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);
        nint ptr;
        int hr = _comImpl->CreateBitmap(_comPtr, size.Width, size.Height, (void*)srcData, pitch, bitmapPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Creates a Direct2D bitmap from a pointer to in-memory source data.
    /// </summary>
    /// <param name="size">The dimension of the bitmap to create in pixels.</param>
    /// <param name="srcData">The image data, or null to create an uninitialized bitmap.</param>
    /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If <paramref name="srcData"/> is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
    /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmap(in D2D1SizeU size, byte[]? srcData, uint pitch, in D2D1BitmapProperties bitmapProperties)
    {
        return CreateBitmap(size, srcData.AsSpan(), pitch, bitmapProperties);
    }

    /// <summary>
    /// Creates a Direct2D bitmap from a pointer to in-memory source data.
    /// </summary>
    /// <param name="size">The dimension of the bitmap to create in pixels.</param>
    /// <param name="srcData">The image data, or null to create an uninitialized bitmap.</param>
    /// <param name="pitch">The byte count of each scanline, which is equal to <c>(the image width in pixels × the number of bytes per pixel) + memory padding</c>. If <paramref name="srcData"/> is NULL, this value is ignored. (Note that pitch is also sometimes called stride.)</param>
    /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmap(in D2D1SizeU size, ReadOnlySpan<byte> srcData, uint pitch, in D2D1BitmapProperties bitmapProperties)
    {
        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);

        fixed (byte* srcDataPtr = srcData)
        {
            nint ptr;
            int hr = _comImpl->CreateBitmap(_comPtr, size.Width, size.Height, srcDataPtr, pitch, bitmapPropertiesPtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1Bitmap(ptr);
        }
    }

    /// <summary>
    /// Creates a Direct2D bitmap from a pointer to in-memory source data.
    /// </summary>
    /// <param name="size">The dimension of the bitmap to create in pixels.</param>
    /// <param name="bitmapProperties">The pixel format and dots per inch (DPI) of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmap(in D2D1SizeU size, in D2D1BitmapProperties bitmapProperties)
    {
        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);
        nint ptr;
        int hr = _comImpl->CreateBitmap(_comPtr, size.Width, size.Height, null, 0, bitmapPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmapFromWicBitmap(nint wicBitmapSource)
    {
        if (wicBitmapSource == 0)
        {
            throw new ArgumentNullException(nameof(wicBitmapSource));
        }

        nint wicBitmapSourcePtr = DXUtils.QueryInterface(wicBitmapSource, ComInteropInterfacesGuids.WICBitmapSourceGuid);

        try
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromWicBitmap(_comPtr, wicBitmapSourcePtr, null, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1Bitmap(ptr);
        }
        finally
        {
            DXUtils.Release(wicBitmapSourcePtr);
        }
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmapFromWicBitmap(DXComObject wicBitmapSource)
    {
        nint wicBitmapSourcePtr = DXUtils.QueryInterface(wicBitmapSource.Handle, ComInteropInterfacesGuids.WICBitmapSourceGuid);

        try
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromWicBitmap(_comPtr, wicBitmapSourcePtr, null, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1Bitmap(ptr);
        }
        finally
        {
            DXUtils.Release(wicBitmapSourcePtr);
        }
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
    /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmapFromWicBitmap(nint wicBitmapSource, in D2D1BitmapProperties bitmapProperties)
    {
        if (wicBitmapSource == 0)
        {
            throw new ArgumentNullException(nameof(wicBitmapSource));
        }

        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);

        nint wicBitmapSourcePtr = DXUtils.QueryInterface(wicBitmapSource, ComInteropInterfacesGuids.WICBitmapSourceGuid);

        try
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromWicBitmap(_comPtr, wicBitmapSourcePtr, bitmapPropertiesPtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1Bitmap(ptr);
        }
        finally
        {
            DXUtils.Release(wicBitmapSourcePtr);
        }
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> by copying the specified Microsoft Windows Imaging Component (WIC) bitmap.
    /// </summary>
    /// <param name="wicBitmapSource">The WIC bitmap to copy.</param>
    /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateBitmapFromWicBitmap(DXComObject wicBitmapSource, in D2D1BitmapProperties bitmapProperties)
    {
        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);

        nint wicBitmapSourcePtr = DXUtils.QueryInterface(wicBitmapSource.Handle, ComInteropInterfacesGuids.WICBitmapSourceGuid);

        try
        {
            nint ptr;
            int hr = _comImpl->CreateBitmapFromWicBitmap(_comPtr, wicBitmapSourcePtr, bitmapPropertiesPtr, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D2D1Bitmap(ptr);
        }
        finally
        {
            DXUtils.Release(wicBitmapSourcePtr);
        }
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> whose data is shared with another resource.
    /// </summary>
    /// <param name="riid">The interface ID of the object supplying the source data.</param>
    /// <param name="data">The data to share.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateSharedBitmap(in Guid riid, nint data)
    {
        if (data == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        nint ptr;
        int hr = _comImpl->CreateSharedBitmap(_comPtr, riid, data, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> whose data is shared with another resource.
    /// </summary>
    /// <param name="riid">The interface ID of the object supplying the source data.</param>
    /// <param name="data">The data to share.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateSharedBitmap(in Guid riid, DXComObject data)
    {
        nint ptr;
        int hr = _comImpl->CreateSharedBitmap(_comPtr, riid, data.Handle, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> whose data is shared with another resource.
    /// </summary>
    /// <param name="riid">The interface ID of the object supplying the source data.</param>
    /// <param name="data">The data to share.</param>
    /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateSharedBitmap(in Guid riid, nint data, in D2D1BitmapProperties bitmapProperties)
    {
        if (data == 0)
        {
            throw new ArgumentNullException(nameof(data));
        }

        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);
        nint ptr;
        int hr = _comImpl->CreateSharedBitmap(_comPtr, riid, data, bitmapPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1Bitmap"/> whose data is shared with another resource.
    /// </summary>
    /// <param name="riid">The interface ID of the object supplying the source data.</param>
    /// <param name="data">The data to share.</param>
    /// <param name="bitmapProperties">The pixel format and DPI of the bitmap to create.</param>
    /// <returns>The new bitmap.</returns>
    public D2D1Bitmap CreateSharedBitmap(in Guid riid, DXComObject data, in D2D1BitmapProperties bitmapProperties)
    {
        int bitmapPropertiesSize = D2D1BitmapProperties.NativeRequiredSize();
        byte* bitmapPropertiesPtr = stackalloc byte[bitmapPropertiesSize];
        D2D1BitmapProperties.NativeWriteTo((nint)bitmapPropertiesPtr, bitmapProperties);
        nint ptr;
        int hr = _comImpl->CreateSharedBitmap(_comPtr, riid, data.Handle, bitmapPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Bitmap(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1BitmapBrush"/> from the specified bitmap.
    /// </summary>
    /// <param name="bitmap">The bitmap contents of the new brush.</param>
    /// <returns>The new brush.</returns>
    public D2D1BitmapBrush CreateBitmapBrush(D2D1Bitmap? bitmap)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        nint ptr;
        int hr = _comImpl->CreateBitmapBrush(_comPtr, bitmap.Handle, null, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapBrush(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1BitmapBrush"/> from the specified bitmap.
    /// </summary>
    /// <param name="bitmap">The bitmap contents of the new brush.</param>
    /// <param name="bitmapBrushProperties">The extend modes and interpolation mode of the new brush.</param>
    /// <returns>The new brush.</returns>
    public D2D1BitmapBrush CreateBitmapBrush(D2D1Bitmap? bitmap, in D2D1BitmapBrushProperties bitmapBrushProperties)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        int bitmapBrushPropertiesSize = D2D1BitmapBrushProperties.NativeRequiredSize();
        byte* bitmapBrushPropertiesPtr = stackalloc byte[bitmapBrushPropertiesSize];
        D2D1BitmapBrushProperties.NativeWriteTo((nint)bitmapBrushPropertiesPtr, bitmapBrushProperties);
        nint ptr;
        int hr = _comImpl->CreateBitmapBrush(_comPtr, bitmap.Handle, bitmapBrushPropertiesPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapBrush(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1BitmapBrush"/> from the specified bitmap.
    /// </summary>
    /// <param name="bitmap">The bitmap contents of the new brush.</param>
    /// <param name="bitmapBrushProperties">The extend modes and interpolation mode of the new brush.</param>
    /// <param name="brushProperties">A structure that contains the opacity and transform of the new brush.</param>
    /// <returns>The new brush.</returns>
    public D2D1BitmapBrush CreateBitmapBrush(D2D1Bitmap? bitmap, in D2D1BitmapBrushProperties bitmapBrushProperties, in D2D1BrushProperties brushProperties)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        int bitmapBrushPropertiesSize = D2D1BitmapBrushProperties.NativeRequiredSize();
        byte* bitmapBrushPropertiesPtr = stackalloc byte[bitmapBrushPropertiesSize];
        D2D1BitmapBrushProperties.NativeWriteTo((nint)bitmapBrushPropertiesPtr, bitmapBrushProperties);
        int brushPropertiesSize = D2D1BrushProperties.NativeRequiredSize();
        byte* brushPropertiesPtr = stackalloc byte[brushPropertiesSize];
        D2D1BrushProperties.NativeWriteTo((nint)brushPropertiesPtr, brushProperties);
        nint ptr;
        int hr = _comImpl->CreateBitmapBrush(_comPtr, bitmap.Handle, bitmapBrushPropertiesPtr, brushPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapBrush(ptr);
    }

    /// <summary>
    /// Creates a new <see cref="D2D1SolidColorBrush"/> that has the specified color and opacity.
    /// </summary>
    /// <param name="color">The red, green, blue, and alpha values of the brush's color.</param>
    /// <returns>The new brush.</returns>
    public D2D1SolidColorBrush CreateSolidColorBrush(in D2D1ColorF color)
    {
        int colorSize = D2D1ColorF.NativeRequiredSize();
        byte* colorPtr = stackalloc byte[colorSize];
        D2D1ColorF.NativeWriteTo((nint)colorPtr, color);
        nint ptr;
        int hr = _comImpl->CreateSolidColorBrush(_comPtr, colorPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1SolidColorBrush(ptr);
    }

    /// <summary>
    /// Creates a new <see cref="D2D1SolidColorBrush"/> that has the specified color and opacity.
    /// </summary>
    /// <param name="color">The red, green, blue, and alpha values of the brush's color.</param>
    /// <param name="brushProperties">The base opacity of the brush.</param>
    /// <returns>The new brush.</returns>
    public D2D1SolidColorBrush CreateSolidColorBrush(in D2D1ColorF color, in D2D1BrushProperties brushProperties)
    {
        int colorSize = D2D1ColorF.NativeRequiredSize();
        byte* colorPtr = stackalloc byte[colorSize];
        D2D1ColorF.NativeWriteTo((nint)colorPtr, color);
        int brushPropertiesSize = D2D1BrushProperties.NativeRequiredSize();
        byte* brushPropertiesPtr = stackalloc byte[brushPropertiesSize];
        D2D1BrushProperties.NativeWriteTo((nint)brushPropertiesPtr, brushProperties);
        nint ptr;
        int hr = _comImpl->CreateSolidColorBrush(_comPtr, colorPtr, brushPropertiesPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1SolidColorBrush(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
    /// </summary>
    /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
    /// <param name="colorInterpolationGamma">The space in which color interpolation between the gradient stops is performed.</param>
    /// <param name="extendMode">The behavior of the gradient outside the [0,1] normalized range.</param>
    /// <returns>The new gradient stop collection.</returns>
    public D2D1GradientStopCollection CreateGradientStopCollection(D2D1GradientStop[]? gradientStops, D2D1Gamma colorInterpolationGamma, D2D1ExtendMode extendMode)
    {
        return CreateGradientStopCollection(gradientStops.AsSpan(), colorInterpolationGamma, extendMode);
    }

    /// <summary>
    /// Creates an <see cref="D2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
    /// </summary>
    /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
    /// <param name="colorInterpolationGamma">The space in which color interpolation between the gradient stops is performed.</param>
    /// <param name="extendMode">The behavior of the gradient outside the [0,1] normalized range.</param>
    /// <returns>The new gradient stop collection.</returns>
    public D2D1GradientStopCollection CreateGradientStopCollection(ReadOnlySpan<D2D1GradientStop> gradientStops, D2D1Gamma colorInterpolationGamma, D2D1ExtendMode extendMode)
    {
        if (gradientStops.Length == 0)
        {
            throw new ArgumentNullException(nameof(gradientStops));
        }

        if (gradientStops.Length < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(gradientStops));
        }

        int gradientStopsSize = D2D1GradientStop.NativeRequiredSize(gradientStops.Length);
        byte* gradientStopsPtr = stackalloc byte[gradientStopsSize];
        D2D1GradientStop.NativeWriteTo((nint)gradientStopsPtr, gradientStops);
        nint ptr;
        int hr = _comImpl->CreateGradientStopCollection(_comPtr, gradientStopsPtr, (uint)gradientStops.Length, colorInterpolationGamma, extendMode, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1GradientStopCollection(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
    /// </summary>
    /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
    /// <returns>The new gradient stop collection.</returns>
    public D2D1GradientStopCollection CreateGradientStopCollection(D2D1GradientStop[]? gradientStops)
    {
        return CreateGradientStopCollection(gradientStops.AsSpan());
    }

    /// <summary>
    /// Creates an <see cref="D2D1GradientStopCollection"/> from the specified gradient stops, color interpolation gamma, and extend mode.
    /// </summary>
    /// <param name="gradientStops">An array of <see cref="D2D1GradientStop"/> structures.</param>
    /// <returns>The new gradient stop collection.</returns>
    public D2D1GradientStopCollection CreateGradientStopCollection(ReadOnlySpan<D2D1GradientStop> gradientStops)
    {
        if (gradientStops.Length == 0)
        {
            throw new ArgumentNullException(nameof(gradientStops));
        }

        if (gradientStops.Length < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(gradientStops));
        }

        int gradientStopsSize = D2D1GradientStop.NativeRequiredSize(gradientStops.Length);
        byte* gradientStopsPtr = stackalloc byte[gradientStopsSize];
        D2D1GradientStop.NativeWriteTo((nint)gradientStopsPtr, gradientStops);
        nint ptr;
        int hr = _comImpl->CreateGradientStopCollection(_comPtr, gradientStopsPtr, (uint)gradientStops.Length, D2D1Gamma.Gamma22, D2D1ExtendMode.Clamp, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1GradientStopCollection(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1LinearGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
    /// </summary>
    /// <param name="linearGradientBrushProperties">The start and end points of the gradient.</param>
    /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient line.</param>
    /// <returns>The new brush.</returns>
    public D2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1LinearGradientBrushProperties linearGradientBrushProperties, D2D1GradientStopCollection? gradientStopCollection)
    {
        if (gradientStopCollection is null)
        {
            throw new ArgumentNullException(nameof(gradientStopCollection));
        }

        int linearGradientBrushPropertiesSize = D2D1LinearGradientBrushProperties.NativeRequiredSize();
        byte* linearGradientBrushPropertiesPtr = stackalloc byte[linearGradientBrushPropertiesSize];
        D2D1LinearGradientBrushProperties.NativeWriteTo((nint)linearGradientBrushPropertiesPtr, linearGradientBrushProperties);
        nint ptr;
        int hr = _comImpl->CreateLinearGradientBrush(_comPtr, linearGradientBrushPropertiesPtr, null, gradientStopCollection.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1LinearGradientBrush(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1LinearGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
    /// </summary>
    /// <param name="linearGradientBrushProperties">The start and end points of the gradient.</param>
    /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
    /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient line.</param>
    /// <returns>The new brush.</returns>
    public D2D1LinearGradientBrush CreateLinearGradientBrush(in D2D1LinearGradientBrushProperties linearGradientBrushProperties, in D2D1BrushProperties brushProperties, D2D1GradientStopCollection? gradientStopCollection)
    {
        if (gradientStopCollection is null)
        {
            throw new ArgumentNullException(nameof(gradientStopCollection));
        }

        int linearGradientBrushPropertiesSize = D2D1LinearGradientBrushProperties.NativeRequiredSize();
        byte* linearGradientBrushPropertiesPtr = stackalloc byte[linearGradientBrushPropertiesSize];
        D2D1LinearGradientBrushProperties.NativeWriteTo((nint)linearGradientBrushPropertiesPtr, linearGradientBrushProperties);
        int brushPropertiesSize = D2D1BrushProperties.NativeRequiredSize();
        byte* brushPropertiesPtr = stackalloc byte[brushPropertiesSize];
        D2D1BrushProperties.NativeWriteTo((nint)brushPropertiesPtr, brushProperties);
        nint ptr;
        int hr = _comImpl->CreateLinearGradientBrush(_comPtr, linearGradientBrushPropertiesPtr, brushPropertiesPtr, gradientStopCollection.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1LinearGradientBrush(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1RadialGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
    /// </summary>
    /// <param name="radialGradientBrushProperties">The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</param>
    /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient.</param>
    /// <returns>The new brush.</returns>
    public D2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1RadialGradientBrushProperties radialGradientBrushProperties, D2D1GradientStopCollection? gradientStopCollection)
    {
        if (gradientStopCollection is null)
        {
            throw new ArgumentOutOfRangeException(nameof(gradientStopCollection));
        }

        int radialGradientBrushPropertiesSize = D2D1RadialGradientBrushProperties.NativeRequiredSize();
        byte* radialGradientBrushPropertiesPtr = stackalloc byte[radialGradientBrushPropertiesSize];
        D2D1RadialGradientBrushProperties.NativeWriteTo((nint)radialGradientBrushPropertiesPtr, radialGradientBrushProperties);
        nint ptr;
        int hr = _comImpl->CreateRadialGradientBrush(_comPtr, radialGradientBrushPropertiesPtr, null, gradientStopCollection.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RadialGradientBrush(ptr);
    }

    /// <summary>
    /// Creates an <see cref="D2D1RadialGradientBrush"/> that contains the specified gradient stops and has the specified transform and base opacity.
    /// </summary>
    /// <param name="radialGradientBrushProperties">The center, gradient origin offset, and x-radius and y-radius of the brush's gradient.</param>
    /// <param name="brushProperties">The transform and base opacity of the new brush.</param>
    /// <param name="gradientStopCollection">A collection of <see cref="D2D1GradientStop"/> structures that describe the colors in the brush's gradient and their locations along the gradient.</param>
    /// <returns>The new brush.</returns>
    public D2D1RadialGradientBrush CreateRadialGradientBrush(in D2D1RadialGradientBrushProperties radialGradientBrushProperties, in D2D1BrushProperties brushProperties, D2D1GradientStopCollection? gradientStopCollection)
    {
        if (gradientStopCollection is null)
        {
            throw new ArgumentOutOfRangeException(nameof(gradientStopCollection));
        }

        int radialGradientBrushPropertiesSize = D2D1RadialGradientBrushProperties.NativeRequiredSize();
        byte* radialGradientBrushPropertiesPtr = stackalloc byte[radialGradientBrushPropertiesSize];
        D2D1RadialGradientBrushProperties.NativeWriteTo((nint)radialGradientBrushPropertiesPtr, radialGradientBrushProperties);
        int brushPropertiesSize = D2D1BrushProperties.NativeRequiredSize();
        byte* brushPropertiesPtr = stackalloc byte[brushPropertiesSize];
        D2D1BrushProperties.NativeWriteTo((nint)brushPropertiesPtr, brushProperties);
        nint ptr;
        int hr = _comImpl->CreateRadialGradientBrush(_comPtr, radialGradientBrushPropertiesPtr, brushPropertiesPtr, gradientStopCollection.Handle, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1RadialGradientBrush(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(D2D1CompatibleRenderTargetOptions options)
    {
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, null, null, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, null, null, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget? CreateCompatibleRenderTarget(in D2D1SizeU desiredPixelSize, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, desiredPixelSizePtr, null, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, in D2D1SizeU desiredPixelSize, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, desiredPixelSizePtr, null, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, null, desiredFormatPtr, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, in D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, null, desiredFormatPtr, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeU desiredPixelSize, in D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, desiredPixelSizePtr, desiredFormatPtr, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <param name="options">A value that specifies whether the new render target must be compatible with GDI.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, in D2D1SizeU desiredPixelSize, in D2D1PixelFormat desiredFormat, D2D1CompatibleRenderTargetOptions options)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, desiredPixelSizePtr, desiredFormatPtr, options, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget()
    {
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, null, null, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, null, null, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget? CreateCompatibleRenderTarget(in D2D1SizeU desiredPixelSize)
    {
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, desiredPixelSizePtr, null, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, in D2D1SizeU desiredPixelSize)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, desiredPixelSizePtr, null, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1PixelFormat desiredFormat)
    {
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, null, desiredFormatPtr, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, in D2D1PixelFormat desiredFormat)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, null, desiredFormatPtr, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeU desiredPixelSize, in D2D1PixelFormat desiredFormat)
    {
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, null, desiredPixelSizePtr, desiredFormatPtr, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a bitmap render target for use during intermediate offscreen drawing that is compatible with the current render target.
    /// </summary>
    /// <param name="desiredSize">The desired size of the new render target in device-independent pixels if it should be different from the original render target.</param>
    /// <param name="desiredPixelSize">The desired size of the new render target in pixels if it should be different from the original render target.</param>
    /// <param name="desiredFormat">The desired pixel format and alpha mode of the new render target.</param>
    /// <returns>The new bitmap render target.</returns>
    public D2D1BitmapRenderTarget CreateCompatibleRenderTarget(in D2D1SizeF desiredSize, in D2D1SizeU desiredPixelSize, in D2D1PixelFormat desiredFormat)
    {
        int desiredSizeSize = D2D1SizeF.NativeRequiredSize();
        byte* desiredSizePtr = stackalloc byte[desiredSizeSize];
        D2D1SizeF.NativeWriteTo((nint)desiredSizePtr, desiredSize);
        int desiredPixelSizeSize = D2D1SizeU.NativeRequiredSize();
        byte* desiredPixelSizePtr = stackalloc byte[desiredPixelSizeSize];
        D2D1SizeU.NativeWriteTo((nint)desiredPixelSizePtr, desiredPixelSize);
        int desiredFormatSize = D2D1PixelFormat.NativeRequiredSize();
        byte* desiredFormatPtr = stackalloc byte[desiredFormatSize];
        D2D1PixelFormat.NativeWriteTo((nint)desiredFormatPtr, desiredFormat);
        nint ptr;
        int hr = _comImpl->CreateCompatibleRenderTarget(_comPtr, desiredSizePtr, desiredPixelSizePtr, desiredFormatPtr, D2D1CompatibleRenderTargetOptions.None, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1BitmapRenderTarget(ptr);
    }

    /// <summary>
    /// Creates a layer resource that can be used with this render target and its compatible render targets. The new layer has the specified initial size.
    /// </summary>
    /// <returns>The new layer.</returns>
    public D2D1Layer CreateLayer()
    {
        nint ptr;
        int hr = _comImpl->CreateLayer(_comPtr, null, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Layer(ptr);
    }

    /// <summary>
    /// Creates a layer resource that can be used with this render target and its compatible render targets. The new layer has the specified initial size.
    /// </summary>
    /// <param name="size">The initial size of the layer in device-independent pixels.</param>
    /// <returns>The new layer.</returns>
    public D2D1Layer CreateLayer(in D2D1SizeF size)
    {
        int sizeSize = D2D1SizeF.NativeRequiredSize();
        byte* sizePtr = stackalloc byte[sizeSize];
        D2D1SizeF.NativeWriteTo((nint)sizePtr, size);
        nint ptr;
        int hr = _comImpl->CreateLayer(_comPtr, sizePtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Layer(ptr);
    }

    /// <summary>
    /// Create a mesh that uses triangles to describe a shape.
    /// </summary>
    /// <returns>The new mesh.</returns>
    public D2D1Mesh CreateMesh()
    {
        nint ptr;
        int hr = _comImpl->CreateMesh(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1Mesh(ptr);
    }

    /// <summary>
    /// Draws a line between the specified points using the specified stroke style.
    /// </summary>
    /// <param name="point0">The start point of the line, in device-independent pixels.</param>
    /// <param name="point1">The end point of the line, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the line's stroke.</param>
    public void DrawLine(in D2D1Point2F point0, in D2D1Point2F point1, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->DrawLine(_comPtr, point0.X, point0.Y, point1.X, point1.Y, brush.Handle, 1.0f, 0);
    }

    /// <summary>
    /// Draws a line between the specified points using the specified stroke style.
    /// </summary>
    /// <param name="point0">The start point of the line, in device-independent pixels.</param>
    /// <param name="point1">The end point of the line, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the line's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    public void DrawLine(in D2D1Point2F point0, in D2D1Point2F point1, D2D1Brush? brush, float strokeWidth)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->DrawLine(_comPtr, point0.X, point0.Y, point1.X, point1.Y, brush.Handle, strokeWidth, 0);
    }

    /// <summary>
    /// Draws a line between the specified points using the specified stroke style.
    /// </summary>
    /// <param name="point0">The start point of the line, in device-independent pixels.</param>
    /// <param name="point1">The end point of the line, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the line's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to paint.</param>
    public void DrawLine(in D2D1Point2F point0, in D2D1Point2F point1, D2D1Brush? brush, float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        _comImpl->DrawLine(_comPtr, point0.X, point0.Y, point1.X, point1.Y, brush.Handle, strokeWidth, strokeStylePtr);
    }

    /// <summary>
    /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
    /// </summary>
    /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
    public void DrawRectangle(in D2D1RectF rect, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int rectSize = D2D1RectF.NativeRequiredSize();
        byte* rectPtr = stackalloc byte[rectSize];
        D2D1RectF.NativeWriteTo((nint)rectPtr, rect);
        _comImpl->DrawRectangle(_comPtr, rectPtr, brush.Handle, 1.0f, 0);
    }

    /// <summary>
    /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
    /// </summary>
    /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    public void DrawRectangle(in D2D1RectF rect, D2D1Brush? brush, float strokeWidth)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int rectSize = D2D1RectF.NativeRequiredSize();
        byte* rectPtr = stackalloc byte[rectSize];
        D2D1RectF.NativeWriteTo((nint)rectPtr, rect);
        _comImpl->DrawRectangle(_comPtr, rectPtr, brush.Handle, strokeWidth, 0);
    }

    /// <summary>
    /// Draws the outline of a rectangle that has the specified dimensions and stroke style.
    /// </summary>
    /// <param name="rect">The dimensions of the rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rectangle's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to paint.</param>
    public void DrawRectangle(in D2D1RectF rect, D2D1Brush? brush, float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int rectSize = D2D1RectF.NativeRequiredSize();
        byte* rectPtr = stackalloc byte[rectSize];
        D2D1RectF.NativeWriteTo((nint)rectPtr, rect);
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        _comImpl->DrawRectangle(_comPtr, rectPtr, brush.Handle, strokeWidth, strokeStylePtr);
    }

    /// <summary>
    /// Paints the interior of the specified rectangle.
    /// </summary>
    /// <param name="rect">The dimension of the rectangle to paint, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rectangle's interior.</param>
    public void FillRectangle(in D2D1RectF rect, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int rectSize = D2D1RectF.NativeRequiredSize();
        byte* rectPtr = stackalloc byte[rectSize];
        D2D1RectF.NativeWriteTo((nint)rectPtr, rect);
        _comImpl->FillRectangle(_comPtr, rectPtr, brush.Handle);
    }

    /// <summary>
    /// Draws the outline of the specified rounded rectangle using the specified stroke style.
    /// </summary>
    /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
    public void DrawRoundedRectangle(in D2D1RoundedRect roundedRect, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int roundedRectSize = D2D1RoundedRect.NativeRequiredSize();
        byte* roundedRectPtr = stackalloc byte[roundedRectSize];
        D2D1RoundedRect.NativeWriteTo((nint)roundedRectPtr, roundedRect);
        _comImpl->DrawRoundedRectangle(_comPtr, roundedRectPtr, brush.Handle, 1.0f, 0);
    }

    /// <summary>
    /// Draws the outline of the specified rounded rectangle using the specified stroke style.
    /// </summary>
    /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    public void DrawRoundedRectangle(in D2D1RoundedRect roundedRect, D2D1Brush? brush, float strokeWidth)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int roundedRectSize = D2D1RoundedRect.NativeRequiredSize();
        byte* roundedRectPtr = stackalloc byte[roundedRectSize];
        D2D1RoundedRect.NativeWriteTo((nint)roundedRectPtr, roundedRect);
        _comImpl->DrawRoundedRectangle(_comPtr, roundedRectPtr, brush.Handle, strokeWidth, 0);
    }

    /// <summary>
    /// Draws the outline of the specified rounded rectangle using the specified stroke style.
    /// </summary>
    /// <param name="roundedRect">The dimensions of the rounded rectangle to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the rounded rectangle's outline.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of the rounded rectangle's stroke.</param>
    public void DrawRoundedRectangle(in D2D1RoundedRect roundedRect, D2D1Brush? brush, float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int roundedRectSize = D2D1RoundedRect.NativeRequiredSize();
        byte* roundedRectPtr = stackalloc byte[roundedRectSize];
        D2D1RoundedRect.NativeWriteTo((nint)roundedRectPtr, roundedRect);
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        _comImpl->DrawRoundedRectangle(_comPtr, roundedRectPtr, brush.Handle, strokeWidth, strokeStylePtr);
    }

    /// <summary>
    /// Paints the interior of the specified rounded rectangle.
    /// </summary>
    /// <param name="roundedRect">The dimensions of the rounded rectangle to paint, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the interior of the rounded rectangle.</param>
    public void FillRoundedRectangle(in D2D1RoundedRect roundedRect, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int roundedRectSize = D2D1RoundedRect.NativeRequiredSize();
        byte* roundedRectPtr = stackalloc byte[roundedRectSize];
        D2D1RoundedRect.NativeWriteTo((nint)roundedRectPtr, roundedRect);
        _comImpl->FillRoundedRectangle(_comPtr, roundedRectPtr, brush.Handle);
    }

    /// <summary>
    /// Draws the outline of the specified ellipse using the specified stroke style.
    /// </summary>
    /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the ellipse's outline.</param>
    public void DrawEllipse(in D2D1Ellipse ellipse, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int ellipseSize = D2D1Ellipse.NativeRequiredSize();
        byte* ellipsePtr = stackalloc byte[ellipseSize];
        D2D1Ellipse.NativeWriteTo((nint)ellipsePtr, ellipse);
        _comImpl->DrawEllipse(_comPtr, ellipsePtr, brush.Handle, 1.0f, 0);
    }

    /// <summary>
    /// Draws the outline of the specified ellipse using the specified stroke style.
    /// </summary>
    /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the ellipse's outline.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    public void DrawEllipse(in D2D1Ellipse ellipse, D2D1Brush? brush, float strokeWidth)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int ellipseSize = D2D1Ellipse.NativeRequiredSize();
        byte* ellipsePtr = stackalloc byte[ellipseSize];
        D2D1Ellipse.NativeWriteTo((nint)ellipsePtr, ellipse);
        _comImpl->DrawEllipse(_comPtr, ellipsePtr, brush.Handle, strokeWidth, 0);
    }

    /// <summary>
    /// Draws the outline of the specified ellipse using the specified stroke style.
    /// </summary>
    /// <param name="ellipse">The position and radius of the ellipse to draw, in device-independent pixels.</param>
    /// <param name="brush">The brush used to paint the ellipse's outline.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the ellipse's outline.</param>
    public void DrawEllipse(in D2D1Ellipse ellipse, D2D1Brush? brush, float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int ellipseSize = D2D1Ellipse.NativeRequiredSize();
        byte* ellipsePtr = stackalloc byte[ellipseSize];
        D2D1Ellipse.NativeWriteTo((nint)ellipsePtr, ellipse);
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        _comImpl->DrawEllipse(_comPtr, ellipsePtr, brush.Handle, strokeWidth, strokeStylePtr);
    }

    /// <summary>
    /// Paints the interior of the specified ellipse.
    /// </summary>
    /// <param name="ellipse">The position and radius, in device-independent pixels, of the ellipse to paint.</param>
    /// <param name="brush">The brush used to paint the interior of the ellipse.</param>
    public void FillEllipse(in D2D1Ellipse ellipse, D2D1Brush? brush)
    {
        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int ellipseSize = D2D1Ellipse.NativeRequiredSize();
        byte* ellipsePtr = stackalloc byte[ellipseSize];
        D2D1Ellipse.NativeWriteTo((nint)ellipsePtr, ellipse);
        _comImpl->FillEllipse(_comPtr, ellipsePtr, brush.Handle);
    }

    /// <summary>
    /// Draws the outline of the specified geometry using the specified stroke style.
    /// </summary>
    /// <param name="geometry">The geometry to draw.</param>
    /// <param name="brush">The brush used to paint the geometry's stroke.</param>
    public void DrawGeometry(D2D1Geometry? geometry, D2D1Brush? brush)
    {
        if (geometry is null)
        {
            throw new ArgumentNullException(nameof(geometry));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->DrawGeometry(_comPtr, geometry.Handle, brush.Handle, 1.0f, 0);
    }

    /// <summary>
    /// Draws the outline of the specified geometry using the specified stroke style.
    /// </summary>
    /// <param name="geometry">The geometry to draw.</param>
    /// <param name="brush">The brush used to paint the geometry's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    public void DrawGeometry(D2D1Geometry? geometry, D2D1Brush? brush, float strokeWidth)
    {
        if (geometry is null)
        {
            throw new ArgumentNullException(nameof(geometry));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->DrawGeometry(_comPtr, geometry.Handle, brush.Handle, strokeWidth, 0);
    }

    /// <summary>
    /// Draws the outline of the specified geometry using the specified stroke style.
    /// </summary>
    /// <param name="geometry">The geometry to draw.</param>
    /// <param name="brush">The brush used to paint the geometry's stroke.</param>
    /// <param name="strokeWidth">The width of the stroke, in device-independent pixels. The value must be greater than or equal to 0.0f. If this parameter isn't specified, it defaults to 1.0f. The stroke is centered on the line.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry's outline.</param>
    public void DrawGeometry(D2D1Geometry? geometry, D2D1Brush? brush, float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        if (geometry is null)
        {
            throw new ArgumentNullException(nameof(geometry));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        _comImpl->DrawGeometry(_comPtr, geometry.Handle, brush.Handle, strokeWidth, strokeStylePtr);
    }

    /// <summary>
    /// Paints the interior of the specified geometry.
    /// </summary>
    /// <param name="geometry">The geometry to paint.</param>
    /// <param name="brush">The brush used to paint the geometry's interior.</param>
    public void FillGeometry(D2D1Geometry? geometry, D2D1Brush? brush)
    {
        if (geometry is null)
        {
            throw new ArgumentNullException(nameof(geometry));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->FillGeometry(_comPtr, geometry.Handle, brush.Handle, 0);
    }

    /// <summary>
    /// Paints the interior of the specified geometry.
    /// </summary>
    /// <param name="geometry">The geometry to paint.</param>
    /// <param name="brush">The brush used to paint the geometry's interior.</param>
    /// <param name="opacityBrush">The opacity mask to apply to the geometry.</param>
    public void FillGeometry(D2D1Geometry? geometry, D2D1Brush? brush, D2D1Brush? opacityBrush)
    {
        if (geometry is null)
        {
            throw new ArgumentNullException(nameof(geometry));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        nint opacityBrushPtr = opacityBrush is null ? 0 : opacityBrush.Handle;
        _comImpl->FillGeometry(_comPtr, geometry.Handle, brush.Handle, opacityBrushPtr);
    }

    /// <summary>
    /// Paints the interior of the specified mesh.
    /// </summary>
    /// <param name="mesh">The mesh to paint.</param>
    /// <param name="brush">The brush used to paint the mesh.</param>
    public void FillMesh(D2D1Mesh? mesh, D2D1Brush? brush)
    {
        if (mesh is null)
        {
            throw new ArgumentNullException(nameof(mesh));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->FillMesh(_comPtr, mesh.Handle, brush.Handle);
    }

    /// <summary>
    /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
    /// </summary>
    /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
    /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
    /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
    public void FillOpacityMask(D2D1Bitmap? opacityMask, D2D1Brush? brush, D2D1OpacityMaskContent content)
    {
        if (opacityMask is null)
        {
            throw new ArgumentNullException(nameof(opacityMask));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        _comImpl->FillOpacityMask(_comPtr, opacityMask.Handle, brush.Handle, content, null, null);
    }

    /// <summary>
    /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
    /// </summary>
    /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
    /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
    /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
    /// <param name="destinationRectangle">The region of the render target to paint, in device-independent pixels.</param>
    public void FillOpacityMask(D2D1Bitmap? opacityMask, D2D1Brush? brush, D2D1OpacityMaskContent content, in D2D1RectF destinationRectangle)
    {
        if (opacityMask is null)
        {
            throw new ArgumentNullException(nameof(opacityMask));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int destinationRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* destinationRectanglePtr = stackalloc byte[destinationRectangleSize];
        D2D1RectF.NativeWriteTo((nint)destinationRectanglePtr, destinationRectangle);
        _comImpl->FillOpacityMask(_comPtr, opacityMask.Handle, brush.Handle, content, destinationRectanglePtr, null);
    }

    /// <summary>
    /// Applies the opacity mask described by the specified bitmap to a brush and uses that brush to paint a region of the render target.
    /// </summary>
    /// <param name="opacityMask">The opacity mask to apply to the brush. The alpha value of each pixel in the region specified by sourceRectangle is multiplied with the alpha value of the brush after the brush has been mapped to the area defined by destinationRectangle.</param>
    /// <param name="brush">The brush used to paint the region of the render target specified by destinationRectangle.</param>
    /// <param name="content">The type of content the opacity mask contains. The value is used to determine the color space in which the opacity mask is blended.</param>
    /// <param name="destinationRectangle">The region of the render target to paint, in device-independent pixels.</param>
    /// <param name="sourceRectangle">The region of the bitmap to use as the opacity mask, in device-independent pixels.</param>
    public void FillOpacityMask(D2D1Bitmap? opacityMask, D2D1Brush? brush, D2D1OpacityMaskContent content, in D2D1RectF destinationRectangle, in D2D1RectF sourceRectangle)
    {
        if (opacityMask is null)
        {
            throw new ArgumentNullException(nameof(opacityMask));
        }

        if (brush is null)
        {
            throw new ArgumentNullException(nameof(brush));
        }

        int destinationRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* destinationRectanglePtr = stackalloc byte[destinationRectangleSize];
        D2D1RectF.NativeWriteTo((nint)destinationRectanglePtr, destinationRectangle);
        int sourceRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* sourceRectanglePtr = stackalloc byte[sourceRectangleSize];
        D2D1RectF.NativeWriteTo((nint)sourceRectanglePtr, sourceRectangle);
        _comImpl->FillOpacityMask(_comPtr, opacityMask.Handle, brush.Handle, content, destinationRectanglePtr, sourceRectanglePtr);
    }

    /// <summary>
    /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
    /// </summary>
    /// <param name="bitmap">The bitmap to render.</param>
    public void DrawBitmap(D2D1Bitmap? bitmap)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        _comImpl->DrawBitmap(_comPtr, bitmap.Handle, null, 1.0f, D2D1BitmapInterpolationMode.Linear, null);
    }

    /// <summary>
    /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
    /// </summary>
    /// <param name="bitmap">The bitmap to render.</param>
    /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
    public void DrawBitmap(D2D1Bitmap? bitmap, in D2D1RectF destinationRectangle)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        int destinationRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* destinationRectanglePtr = stackalloc byte[destinationRectangleSize];
        D2D1RectF.NativeWriteTo((nint)destinationRectanglePtr, destinationRectangle);
        _comImpl->DrawBitmap(_comPtr, bitmap.Handle, destinationRectanglePtr, 1.0f, D2D1BitmapInterpolationMode.Linear, null);
    }

    /// <summary>
    /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
    /// </summary>
    /// <param name="bitmap">The bitmap to render.</param>
    /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
    /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
    public void DrawBitmap(D2D1Bitmap? bitmap, in D2D1RectF destinationRectangle, float opacity)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        int destinationRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* destinationRectanglePtr = stackalloc byte[destinationRectangleSize];
        D2D1RectF.NativeWriteTo((nint)destinationRectanglePtr, destinationRectangle);
        _comImpl->DrawBitmap(_comPtr, bitmap.Handle, destinationRectanglePtr, opacity, D2D1BitmapInterpolationMode.Linear, null);
    }

    /// <summary>
    /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
    /// </summary>
    /// <param name="bitmap">The bitmap to render.</param>
    /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
    /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
    /// <param name="interpolationMode">The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</param>
    public void DrawBitmap(D2D1Bitmap? bitmap, in D2D1RectF destinationRectangle, float opacity, D2D1BitmapInterpolationMode interpolationMode)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        int destinationRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* destinationRectanglePtr = stackalloc byte[destinationRectangleSize];
        D2D1RectF.NativeWriteTo((nint)destinationRectanglePtr, destinationRectangle);
        _comImpl->DrawBitmap(_comPtr, bitmap.Handle, destinationRectanglePtr, opacity, interpolationMode, null);
    }

    /// <summary>
    /// Draws the specified bitmap after scaling it to the size of the specified rectangle.
    /// </summary>
    /// <param name="bitmap">The bitmap to render.</param>
    /// <param name="destinationRectangle">The size and position, in device-independent pixels in the render target's coordinate space, of the area to which the bitmap is drawn.</param>
    /// <param name="opacity">A value between 0.0f and 1.0f, inclusive, that specifies an opacity value to apply to the bitmap; this value is multiplied against the alpha values of the bitmap's contents.</param>
    /// <param name="interpolationMode">The interpolation mode to use if the bitmap is scaled or rotated by the drawing operation.</param>
    /// <param name="sourceRectangle">The size and position, in device-independent pixels in the bitmap's coordinate space, of the area within the bitmap to be drawn.</param>
    public void DrawBitmap(D2D1Bitmap? bitmap, in D2D1RectF destinationRectangle, float opacity, D2D1BitmapInterpolationMode interpolationMode, in D2D1RectF sourceRectangle)
    {
        if (bitmap is null)
        {
            throw new ArgumentNullException(nameof(bitmap));
        }

        int destinationRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* destinationRectanglePtr = stackalloc byte[destinationRectangleSize];
        D2D1RectF.NativeWriteTo((nint)destinationRectanglePtr, destinationRectangle);
        int sourceRectangleSize = D2D1RectF.NativeRequiredSize();
        byte* sourceRectanglePtr = stackalloc byte[sourceRectangleSize];
        D2D1RectF.NativeWriteTo((nint)sourceRectanglePtr, sourceRectangle);
        _comImpl->DrawBitmap(_comPtr, bitmap.Handle, destinationRectanglePtr, opacity, interpolationMode, sourceRectanglePtr);
    }

    /// <summary>
    /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
    /// </summary>
    /// <param name="text">An array of Unicode characters to draw.</param>
    /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
    /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
    public void DrawText(string? text, DWriteTextFormat? textFormat, in D2D1RectF layoutRect, D2D1Brush? defaultForegroundBrush)
    {
        DrawText(text.AsSpan(), textFormat, layoutRect, defaultForegroundBrush);
    }

    /// <summary>
    /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
    /// </summary>
    /// <param name="text">An array of Unicode characters to draw.</param>
    /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
    /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
    public void DrawText(ReadOnlySpan<char> text, DWriteTextFormat? textFormat, in D2D1RectF layoutRect, D2D1Brush? defaultForegroundBrush)
    {
        if (text.Length == 0)
        {
            return;
        }

        if (textFormat is null)
        {
            throw new ArgumentNullException(nameof(textFormat));
        }

        if (defaultForegroundBrush is null)
        {
            throw new ArgumentNullException(nameof(defaultForegroundBrush));
        }

        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectF.NativeWriteTo((nint)ptr, layoutRect);

        fixed (char* t = text)
        {
            _comImpl->DrawText(_comPtr, t, (uint)text.Length, textFormat.Handle, ptr, defaultForegroundBrush.Handle, D2D1DrawTextOptions.None, DWriteMeasuringMode.Natural);
        }
    }

    /// <summary>
    /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
    /// </summary>
    /// <param name="text">An array of Unicode characters to draw.</param>
    /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
    /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
    /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
    public void DrawText(string? text, DWriteTextFormat? textFormat, in D2D1RectF layoutRect, D2D1Brush? defaultForegroundBrush, D2D1DrawTextOptions options)
    {
        DrawText(text.AsSpan(), textFormat, layoutRect, defaultForegroundBrush, options);
    }

    /// <summary>
    /// Draws the specified text using the format information provided by an <see cref="DWriteTextFormat"/> object.
    /// </summary>
    /// <param name="text">An array of Unicode characters to draw.</param>
    /// <param name="textFormat">An object that describes formatting details of the text to draw, such as the font, the font size, and flow direction.</param>
    /// <param name="layoutRect">The size and position of the area in which the text is drawn.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint the text.</param>
    /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
    public void DrawText(ReadOnlySpan<char> text, DWriteTextFormat? textFormat, in D2D1RectF layoutRect, D2D1Brush? defaultForegroundBrush, D2D1DrawTextOptions options)
    {
        if (text.Length == 0)
        {
            return;
        }

        if (textFormat is null)
        {
            throw new ArgumentNullException(nameof(textFormat));
        }

        if (defaultForegroundBrush is null)
        {
            throw new ArgumentNullException(nameof(defaultForegroundBrush));
        }

        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectF.NativeWriteTo((nint)ptr, layoutRect);

        fixed (char* t = text)
        {
            _comImpl->DrawText(_comPtr, t, (uint)text.Length, textFormat.Handle, ptr, defaultForegroundBrush.Handle, options, DWriteMeasuringMode.Natural);
        }
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
    public void DrawText(string? text, DWriteTextFormat? textFormat, in D2D1RectF layoutRect, D2D1Brush? defaultForegroundBrush, D2D1DrawTextOptions options, DWriteMeasuringMode measuringMode)
    {
        DrawText(text.AsSpan(), textFormat, layoutRect, defaultForegroundBrush, options, measuringMode);
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
    public void DrawText(ReadOnlySpan<char> text, DWriteTextFormat? textFormat, in D2D1RectF layoutRect, D2D1Brush? defaultForegroundBrush, D2D1DrawTextOptions options, DWriteMeasuringMode measuringMode)
    {
        if (text.Length == 0)
        {
            return;
        }

        if (textFormat is null)
        {
            throw new ArgumentNullException(nameof(textFormat));
        }

        if (defaultForegroundBrush is null)
        {
            throw new ArgumentNullException(nameof(defaultForegroundBrush));
        }

        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectF.NativeWriteTo((nint)ptr, layoutRect);

        fixed (char* t = text)
        {
            _comImpl->DrawText(_comPtr, t, (uint)text.Length, textFormat.Handle, ptr, defaultForegroundBrush.Handle, options, measuringMode);
        }
    }

    /// <summary>
    /// Draws the formatted text described by the specified <see cref="DWriteTextLayout"/> object.
    /// </summary>
    /// <param name="origin">The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.</param>
    /// <param name="textLayout">The formatted text to draw.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect.</param>
    public void DrawTextLayout(in D2D1Point2F origin, DWriteTextLayout? textLayout, D2D1Brush? defaultForegroundBrush)
    {
        if (textLayout is null)
        {
            throw new ArgumentNullException(nameof(textLayout));
        }

        if (defaultForegroundBrush is null)
        {
            throw new ArgumentNullException(nameof(defaultForegroundBrush));
        }

        _comImpl->DrawTextLayout(_comPtr, origin.X, origin.Y, textLayout.Handle, defaultForegroundBrush.Handle, D2D1DrawTextOptions.None);
    }

    /// <summary>
    /// Draws the formatted text described by the specified <see cref="DWriteTextLayout"/> object.
    /// </summary>
    /// <param name="origin">The point, described in device-independent pixels, at which the upper-left corner of the text described by textLayout is drawn.</param>
    /// <param name="textLayout">The formatted text to draw.</param>
    /// <param name="defaultForegroundBrush">The brush used to paint any text in textLayout that does not already have a brush associated with it as a drawing effect.</param>
    /// <param name="options">A value that indicates whether the text should be snapped to pixel boundaries and whether the text should be clipped to the layout rectangle.</param>
    public void DrawTextLayout(in D2D1Point2F origin, DWriteTextLayout? textLayout, D2D1Brush? defaultForegroundBrush, D2D1DrawTextOptions options)
    {
        if (textLayout is null)
        {
            throw new ArgumentNullException(nameof(textLayout));
        }

        if (defaultForegroundBrush is null)
        {
            throw new ArgumentNullException(nameof(defaultForegroundBrush));
        }

        _comImpl->DrawTextLayout(_comPtr, origin.X, origin.Y, textLayout.Handle, defaultForegroundBrush.Handle, options);
    }

    /// <summary>
    /// Draws the specified glyphs.
    /// </summary>
    /// <param name="baselineOrigin">The origin, in device-independent pixels, of the glyphs' baseline.</param>
    /// <param name="glyphRun">The glyphs to render.</param>
    /// <param name="foregroundBrush">The brush used to paint the specified glyphs.</param>
    public void DrawGlyphRun(in D2D1Point2F baselineOrigin, in DWriteGlyphRun glyphRun, D2D1Brush? foregroundBrush)
    {
        if (foregroundBrush is null)
        {
            throw new ArgumentNullException(nameof(foregroundBrush));
        }

        int size = DWriteGlyphRun.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        DWriteGlyphRun.NativeWriteTo((nint)ptr, glyphRun);
        _comImpl->DrawGlyphRun(_comPtr, baselineOrigin.X, baselineOrigin.Y, ptr, foregroundBrush.Handle, DWriteMeasuringMode.Natural);
    }

    /// <summary>
    /// Draws the specified glyphs.
    /// </summary>
    /// <param name="baselineOrigin">The origin, in device-independent pixels, of the glyphs' baseline.</param>
    /// <param name="glyphRun">The glyphs to render.</param>
    /// <param name="foregroundBrush">The brush used to paint the specified glyphs.</param>
    /// <param name="measuringMode">A value that indicates how glyph metrics are used to measure text when it is formatted.</param>
    public void DrawGlyphRun(in D2D1Point2F baselineOrigin, in DWriteGlyphRun glyphRun, D2D1Brush? foregroundBrush, DWriteMeasuringMode measuringMode)
    {
        if (foregroundBrush is null)
        {
            throw new ArgumentNullException(nameof(foregroundBrush));
        }

        int size = DWriteGlyphRun.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        DWriteGlyphRun.NativeWriteTo((nint)ptr, glyphRun);
        _comImpl->DrawGlyphRun(_comPtr, baselineOrigin.X, baselineOrigin.Y, ptr, foregroundBrush.Handle, measuringMode);
    }

    /// <summary>
    /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
    /// </summary>
    public void SetTextRenderingParams()
    {
        _comImpl->SetTextRenderingParams(_comPtr, 0);
    }

    /// <summary>
    /// Specifies text rendering options to be applied to all subsequent text and glyph drawing operations.
    /// </summary>
    /// <param name="textRenderingParams">The text rendering options to be applied to all subsequent text and glyph drawing operations.</param>
    public void SetTextRenderingParams(DWriteRenderingParams? textRenderingParams)
    {
        _comImpl->SetTextRenderingParams(_comPtr, textRenderingParams is null ? 0 : textRenderingParams.Handle);
    }

    /// <summary>
    /// Retrieves the render target's current text rendering options.
    /// </summary>
    /// <returns>The render target's current text rendering options.</returns>
    public DWriteRenderingParams? GetTextRenderingParams()
    {
        nint ptr;
        _comImpl->GetTextRenderingParams(_comPtr, &ptr);
        return ptr == 0 ? null : new DWriteRenderingParams(ptr);
    }

    /// <summary>
    /// Specifies a label for subsequent drawing operations.
    /// </summary>
    /// <param name="tag1">The first to apply to subsequent drawing operations.</param>
    /// <param name="tag2">The second to apply to subsequent drawing operations.</param>
    public void SetTags(ulong tag1, ulong tag2)
    {
        _comImpl->SetTags(_comPtr, tag1, tag2);
    }

    /// <summary>
    /// Gets the label for subsequent drawing operations.
    /// </summary>
    /// <param name="tag1">The first label for subsequent drawing operations.</param>
    /// <param name="tag2">The second label for subsequent drawing operations.</param>
    public void GetTags(out ulong tag1, out ulong tag2)
    {
        ulong t1;
        ulong t2;
        _comImpl->GetTags(_comPtr, &t1, &t2);
        tag1 = t1;
        tag2 = t2;
    }

    /// <summary>
    /// Adds the specified layer to the render target so that it receives all subsequent drawing operations until <see cref="PopLayer"/> is called.
    /// </summary>
    /// <param name="layerParameters">The content bounds, geometric mask, opacity, opacity mask, and antialiasing options for the layer.</param>
    /// <param name="layer">The layer that receives subsequent drawing operations.</param>
    public void PushLayer(in D2D1LayerParameters layerParameters, D2D1Layer? layer)
    {
        int size = D2D1LayerParameters.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1LayerParameters.NativeWriteTo((nint)ptr, layerParameters);
        _comImpl->PushLayer(_comPtr, ptr, layer is null ? 0 : layer.Handle);
    }

    /// <summary>
    /// Stops redirecting drawing operations to the layer that is specified by the last <see cref="PushLayer"/> call.
    /// </summary>
    public void PopLayer()
    {
        _comImpl->PopLayer(_comPtr);
    }

    /// <summary>
    /// Executes all pending drawing commands.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Flush()
    {
        ulong t1;
        ulong t2;
        int hr = _comImpl->Flush(_comPtr, &t1, &t2);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Executes all pending drawing commands.
    /// </summary>
    /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
    /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
    public void Flush(out ulong tag1, out ulong tag2)
    {
        ulong t1;
        ulong t2;
        int hr = _comImpl->Flush(_comPtr, &t1, &t2);
        Marshal.ThrowExceptionForHR(hr);
        tag1 = t1;
        tag2 = t2;
    }

    /// <summary>
    /// Saves the current drawing state to the specified <see cref="D2D1DrawingStateBlock"/>.
    /// </summary>
    /// <param name="drawingStateBlock">The current drawing state of the render target.</param>
    public void SaveDrawingState(D2D1DrawingStateBlock? drawingStateBlock)
    {
        if (drawingStateBlock is null)
        {
            throw new ArgumentNullException(nameof(drawingStateBlock));
        }

        _comImpl->SaveDrawingState(_comPtr, drawingStateBlock.Handle);
    }

    /// <summary>
    /// Sets the render target's drawing state to that of the specified <see cref="D2D1DrawingStateBlock"/>.
    /// </summary>
    /// <param name="drawingStateBlock">The new drawing state of the render target.</param>
    public void RestoreDrawingState(D2D1DrawingStateBlock? drawingStateBlock)
    {
        if (drawingStateBlock is null)
        {
            throw new ArgumentNullException(nameof(drawingStateBlock));
        }

        _comImpl->RestoreDrawingState(_comPtr, drawingStateBlock.Handle);
    }

    /// <summary>
    /// Specifies a rectangle to which all subsequent drawing operations are clipped.
    /// </summary>
    /// <param name="clipRect">The size and position of the clipping area, in device-independent pixels.</param>
    /// <param name="antialiasMode">The antialiasing mode that is used to draw the edges of clip rectangles that have subpixel boundaries, and to blend the clip with the scene contents. The blending is performed once when the <see cref="PopAxisAlignedClip"/> method is called, and does not apply to each primitive within the layer.</param>
    public void PushAxisAlignedClip(in D2D1RectF clipRect, D2D1AntialiasMode antialiasMode)
    {
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RectF.NativeWriteTo((nint)ptr, clipRect);
        _comImpl->PushAxisAlignedClip(_comPtr, ptr, antialiasMode);
    }

    /// <summary>
    /// Removes the last axis-aligned clip from the render target. After this method is called, the clip is no longer applied to subsequent drawing operations.
    /// </summary>
    public void PopAxisAlignedClip()
    {
        _comImpl->PopAxisAlignedClip(_comPtr);
    }

    /// <summary>
    /// Clears the drawing area to the specified color.
    /// </summary>
    public void Clear()
    {
        _comImpl->Clear(_comPtr, null);
    }

    /// <summary>
    /// Clears the drawing area to the specified color.
    /// </summary>
    /// <param name="clearColor">The color to which the drawing area is cleared.</param>
    public void Clear(in D2D1ColorF clearColor)
    {
        int size = D2D1ColorF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1ColorF.NativeWriteTo((nint)ptr, clearColor);
        _comImpl->Clear(_comPtr, ptr);
    }

    /// <summary>
    /// Initiates drawing on this render target.
    /// </summary>
    public void BeginDraw()
    {
        _comImpl->BeginDraw(_comPtr);
    }

    /// <summary>
    /// Ends drawing operations on the render target and indicates the current error state and associated tags.
    /// </summary>
    public void EndDraw()
    {
        ulong t1;
        ulong t2;
        int hr = _comImpl->EndDraw(_comPtr, &t1, &t2);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Ends drawing operations on the render target and indicates the current error state and associated tags.
    /// </summary>
    /// <param name="tag1">The first tag for drawing operations that caused errors or 0 if there were no errors.</param>
    /// <param name="tag2">The second tag for drawing operations that caused errors or 0 if there were no errors.</param>
    public void EndDraw(out ulong tag1, out ulong tag2)
    {
        ulong t1;
        ulong t2;
        int hr = _comImpl->EndDraw(_comPtr, &t1, &t2);
        Marshal.ThrowExceptionForHR(hr);
        tag1 = t1;
        tag2 = t2;
    }

    /// <summary>
    /// Ends drawing operations on the render target, ignoring the recreate target error.
    /// </summary>
    public void EndDrawIgnoringRecreateTargetError()
    {
        ulong t1;
        ulong t2;
        int hr = _comImpl->EndDraw(_comPtr, &t1, &t2);

        if (hr != D2D1Error.RecreateTarget)
        {
            Marshal.ThrowExceptionForHR(hr);
        }
    }

    /// <summary>
    /// Sets the dots per inch (DPI) of the render target.
    /// </summary>
    /// <param name="dpiX">A value greater than or equal to zero that specifies the horizontal DPI of the render target.</param>
    /// <param name="dpiY">A value greater than or equal to zero that specifies the vertical DPI of the render target.</param>
    public void SetDpi(float dpiX, float dpiY)
    {
        _comImpl->SetDpi(_comPtr, dpiX, dpiY);
    }

    /// <summary>
    /// Return the render target's dots per inch (DPI).
    /// </summary>
    /// <param name="dpiX">The horizontal DPI of the render target.</param>
    /// <param name="dpiY">The vertical DPI of the render target.</param>
    public void GetDpi(out float dpiX, out float dpiY)
    {
        float x;
        float y;
        _comImpl->GetDpi(_comPtr, &x, &y);
        dpiX = x;
        dpiY = y;
    }

    /// <summary>
    /// Indicates whether the render target supports the specified properties.
    /// </summary>
    /// <param name="renderTargetProperties">The render target properties to test.</param>
    /// <returns><value>true</value> if the specified render target properties are supported by this render target; otherwise, <value>false</value>.</returns>
    public bool IsSupported(in D2D1RenderTargetProperties renderTargetProperties)
    {
        int size = D2D1RenderTargetProperties.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1RenderTargetProperties.NativeWriteTo((nint)ptr, renderTargetProperties);
        int result = _comImpl->IsSupported(_comPtr, ptr);
        return result != 0;
    }
}
