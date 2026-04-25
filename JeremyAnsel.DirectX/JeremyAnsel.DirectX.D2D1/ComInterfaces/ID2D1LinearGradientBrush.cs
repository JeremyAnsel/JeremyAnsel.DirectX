// <copyright file="ID2D1LinearGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Paints an area with a linear gradient.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Brush"/></remarks>
[Guid("2cd906ab-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1LinearGradientBrush
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
    /// Sets the starting coordinates of the linear gradient in the brush's coordinate space.
    /// </summary>
    /// <param name="startPoint">The starting two-dimensional coordinates of the linear gradient, in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, void> SetStartPoint;

    /// <summary>
    /// Sets the ending coordinates of the linear gradient in the brush's coordinate space.
    /// </summary>
    /// <param name="endPoint">The ending two-dimensional coordinates of the linear gradient, in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, void> SetEndPoint;

    /// <summary>
    /// Retrieves the starting coordinates of the linear gradient.
    /// </summary>
    /// <param name="point">The starting two-dimensional coordinates of the linear gradient, in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetStartPoint;

    /// <summary>
    /// Retrieves the ending coordinates of the linear gradient.
    /// </summary>
    /// <param name="point">The ending two-dimensional coordinates of the linear gradient, in the brush's coordinate space.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetEndPoint;

    /// <summary>
    /// Retrieves the <see cref="ID2D1GradientStopCollection"/> associated with this linear gradient brush.
    /// </summary>
    /// <param name="gradientStopCollection">The <see cref="ID2D1GradientStopCollection"/> object associated with this linear gradient brush object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetGradientStopCollection;
}
