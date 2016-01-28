// <copyright file="ID2D1BitmapBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// A bitmap brush allows a bitmap to be used to fill a geometry.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906aa-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1BitmapBrush
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory factory);

        /// <summary>
        /// Sets the opacity for when the brush is drawn over the entire fill of the brush.
        /// </summary>
        /// <param name="opacity">A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multiplied together.</param>
        [PreserveSig]
        void SetOpacity(
            [In] float opacity);

        /// <summary>
        /// Sets the transform that applies to everything drawn by the brush.
        /// </summary>
        /// <param name="transform">The transformation to apply to this brush.</param>
        [PreserveSig]
        void SetTransform(
            [In] ref D2D1Matrix3X2F transform);

        /// <summary>
        /// Gets the degree of opacity of this brush.
        /// </summary>
        /// <returns>A value between zero and 1 that indicates the opacity of the brush. This value is a constant multiplier that linearly scales the alpha value of all pixels filled by the brush. The opacity values are clamped in the range 0–1 before they are multiplied together.</returns>
        [PreserveSig]
        float GetOpacity();

        /// <summary>
        /// Gets the transform applied to this brush.
        /// </summary>
        /// <param name="transform">The transform applied to this brush.</param>
        [PreserveSig]
        void GetTransform(
            [Out] out D2D1Matrix3X2F transform);

        /// <summary>
        /// Sets how the bitmap is to be treated outside of its natural extent on the X
        /// axis.
        /// </summary>
        /// <param name="extendModeX">A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</param>
        [PreserveSig]
        void SetExtendModeX(
            [In] D2D1ExtendMode extendModeX);

        /// <summary>
        /// Sets how the bitmap is to be treated outside of its natural extent on the X
        /// axis.
        /// </summary>
        /// <param name="extendModeY">A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</param>
        [PreserveSig]
        void SetExtendModeY(
            [In] D2D1ExtendMode extendModeY);

        /// <summary>
        /// Sets the interpolation mode used when this brush is used.
        /// </summary>
        /// <param name="interpolationMode">The interpolation mode used when the brush bitmap is scaled or rotated.</param>
        [PreserveSig]
        void SetInterpolationMode(
            [In] D2D1BitmapInterpolationMode interpolationMode);

        /// <summary>
        /// Sets the bitmap associated as the source of this brush.
        /// </summary>
        /// <param name="bitmap">The bitmap source used by the brush.</param>
        [PreserveSig]
        void SetBitmap(
            [In] ID2D1Bitmap bitmap);

        /// <summary>
        /// Gets the method by which the brush horizontally tiles those areas that extend past its bitmap.
        /// </summary>
        /// <returns>A value that specifies how the brush horizontally tiles those areas that extend past its bitmap.</returns>
        [PreserveSig]
        D2D1ExtendMode GetExtendModeX();

        /// <summary>
        /// Gets the method by which the brush vertically tiles those areas that extend past its bitmap.
        /// </summary>
        /// <returns>A value that specifies how the brush vertically tiles those areas that extend past its bitmap.</returns>
        [PreserveSig]
        D2D1ExtendMode GetExtendModeY();

        /// <summary>
        /// Gets the interpolation method used when the brush bitmap is scaled or rotated.
        /// </summary>
        /// <returns>The interpolation method used when the brush bitmap is scaled or rotated.</returns>
        [PreserveSig]
        D2D1BitmapInterpolationMode GetInterpolationMode();

        /// <summary>
        /// Gets the bitmap source that this brush uses to paint.
        /// </summary>
        /// <param name="bitmap">The bitmap with which this brush paints.</param>
        [PreserveSig]
        void GetBitmap(
            [Out] out ID2D1Bitmap bitmap);
    }
}
