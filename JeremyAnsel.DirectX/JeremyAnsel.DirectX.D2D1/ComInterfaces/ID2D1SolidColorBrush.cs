﻿// <copyright file="ID2D1SolidColorBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Paints an area with a solid color.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906a9-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1SolidColorBrush
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
        /// Specifies the color of this solid-color brush.
        /// </summary>
        /// <param name="color">The color of this solid-color brush.</param>
        [PreserveSig]
        void SetColor(
            [In] ref D2D1ColorF color);

        /// <summary>
        /// Retrieves the color of the solid color brush.
        /// </summary>
        /// <returns>The color of this solid color brush.</returns>
        [PreserveSig]
        D2D1ColorF GetColor();
    }
}
