// <copyright file="ID2D1GradientStopCollection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents an collection of <see cref="D2D1GradientStop"/> objects for linear and radial gradient brushes.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd906a7-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1GradientStopCollection
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Retrieves the number of gradient stops in the collection.
    /// </summary>
    /// <returns>The number of gradient stops in the collection.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetGradientStopCount;

    /// <summary>
    /// Copies the gradient stops from the collection into an array of <see cref="D2D1GradientStop"/> structures.
    /// </summary>
    /// <param name="gradientStops">The collection's gradient stops.</param>
    /// <param name="gradientStopsCount">A value indicating the number of gradient stops to copy.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, void> GetGradientStops;

    /// <summary>
    /// Indicates the gamma space in which the gradient stops are interpolated.
    /// </summary>
    /// <returns>The gamma space in which the gradient stops are interpolated.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Gamma> GetColorInterpolationGamma;

    /// <summary>
    /// Indicates the behavior of the gradient outside the normalized gradient range.
    /// </summary>
    /// <returns>The behavior of the gradient outside the [0,1] normalized gradient range.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1ExtendMode> GetExtendMode;
}
