// <copyright file="ID2D1RadialGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Paints an area with a radial gradient.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906ac-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1RadialGradientBrush
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
        /// Specifies the center of the gradient ellipse in the brush's coordinate space.
        /// </summary>
        /// <param name="center">The center of the gradient ellipse, in the brush's coordinate space.</param>
        [PreserveSig]
        void SetCenter(
            [In] D2D1Point2F center);

        /// <summary>
        /// Specifies the offset of the gradient origin relative to the gradient ellipse's center.
        /// </summary>
        /// <param name="gradientOriginOffset">The offset of the gradient origin from the center of the gradient ellipse.</param>
        [PreserveSig]
        void SetGradientOriginOffset(
            [In] D2D1Point2F gradientOriginOffset);

        /// <summary>
        /// Specifies the x-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        /// <param name="radiusX">The x-radius of the gradient ellipse. This value is in the brush's coordinate space.</param>
        [PreserveSig]
        void SetRadiusX(
            [In] float radiusX);

        /// <summary>
        /// Specifies the y-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        /// <param name="radiusY">The y-radius of the gradient ellipse. This value is in the brush's coordinate space.</param>
        [PreserveSig]
        void SetRadiusY(
            [In] float radiusY);

        /// <summary>
        /// Retrieves the center of the gradient ellipse.
        /// </summary>
        /// <returns>The center of the gradient ellipse. This value is expressed in the brush's coordinate space.</returns>
        [PreserveSig]
        D2D1Point2F GetCenter();

        /// <summary>
        /// Retrieves the offset of the gradient origin relative to the gradient ellipse's center.
        /// </summary>
        /// <returns>The offset of the gradient origin from the center of the gradient ellipse. This value is expressed in the brush's coordinate space.</returns>
        [PreserveSig]
        D2D1Point2F GetGradientOriginOffset();

        /// <summary>
        /// Retrieves the x-radius of the gradient ellipse.
        /// </summary>
        /// <returns>The x-radius of the gradient ellipse. This value is expressed in the brush's coordinate space.</returns>
        [PreserveSig]
        float GetRadiusX();

        /// <summary>
        /// Retrieves the y-radius of the gradient ellipse.
        /// </summary>
        /// <returns>The y-radius of the gradient ellipse. This value is expressed in the brush's coordinate space.</returns>
        [PreserveSig]
        float GetRadiusY();

        /// <summary>
        /// Retrieves the <see cref="ID2D1GradientStopCollection"/> associated with this radial gradient brush object.
        /// </summary>
        /// <param name="gradientStopCollection">The <see cref="ID2D1GradientStopCollection"/> object associated with this linear gradient brush object.</param>
        [PreserveSig]
        void GetGradientStopCollection(
            [Out] out ID2D1GradientStopCollection gradientStopCollection);
    }
}
