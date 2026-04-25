// <copyright file="ID2D1RadialGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Paints an area with a radial gradient.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
[Guid("2cd906ac-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1RadialGradientBrush
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;
    private readonly nint SetOpacity;
    private readonly nint SetTransform;
    private readonly nint GetOpacity;
    private readonly nint GetTransform;

    /// <summary>
    /// Specifies the center of the gradient ellipse in the brush's coordinate space.
    /// </summary>
    /// <param name="center">The center of the gradient ellipse, in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, void> SetCenter;

    /// <summary>
    /// Specifies the offset of the gradient origin relative to the gradient ellipse's center.
    /// </summary>
    /// <param name="gradientOriginOffset">The offset of the gradient origin from the center of the gradient ellipse.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, void> SetGradientOriginOffset;

    /// <summary>
    /// Specifies the x-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    /// <param name="radiusX">The x-radius of the gradient ellipse. This value is in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, void> SetRadiusX;

    /// <summary>
    /// Specifies the y-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    /// <param name="radiusY">The y-radius of the gradient ellipse. This value is in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, void> SetRadiusY;

    /// <summary>
    /// Retrieves the center of the gradient ellipse.
    /// </summary>
    /// <param name="center">The center of the gradient ellipse. This value is expressed in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetCenter;

    /// <summary>
    /// Retrieves the offset of the gradient origin relative to the gradient ellipse's center.
    /// </summary>
    /// <param name="offset">The offset of the gradient origin from the center of the gradient ellipse. This value is expressed in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetGradientOriginOffset;

    /// <summary>
    /// Retrieves the x-radius of the gradient ellipse.
    /// </summary>
    /// <returns>The x-radius of the gradient ellipse. This value is expressed in the brush's coordinate space.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetRadiusX;

    /// <summary>
    /// Retrieves the y-radius of the gradient ellipse.
    /// </summary>
    /// <returns>The y-radius of the gradient ellipse. This value is expressed in the brush's coordinate space.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, float> GetRadiusY;

    /// <summary>
    /// Retrieves the <see cref="ID2D1GradientStopCollection"/> associated with this radial gradient brush object.
    /// </summary>
    /// <param name="gradientStopCollection">The <see cref="ID2D1GradientStopCollection"/> object associated with this linear gradient brush object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetGradientStopCollection;
}
