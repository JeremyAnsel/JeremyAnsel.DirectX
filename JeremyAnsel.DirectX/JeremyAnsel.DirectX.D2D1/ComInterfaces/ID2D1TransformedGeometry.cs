// <copyright file="ID2D1TransformedGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents a geometry that has been transformed.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Geometry"/></remarks>
[Guid("2cd906bb-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1TransformedGeometry
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;
    private readonly nint GetBounds;
    private readonly nint GetWidenedBounds;
    private readonly nint StrokeContainsPoint;
    private readonly nint FillContainsPoint;
    private readonly nint CompareWithGeometry;
    private readonly nint Simplify;
    private readonly nint Tessellate;
    private readonly nint CombineWithGeometry;
    private readonly nint Outline;
    private readonly nint ComputeArea;
    private readonly nint ComputeLength;
    private readonly nint ComputePointAtLength;
    private readonly nint Widen;

    /// <summary>
    /// Retrieves the source geometry of this transformed geometry object.
    /// </summary>
    /// <param name="sourceGeometry">The source geometry for this transformed geometry object.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetSourceGeometry;

    /// <summary>
    /// Retrieves the matrix used to transform the <see cref="ID2D1TransformedGeometry"/> object's source geometry.
    /// </summary>
    /// <param name="transform">The matrix used to transform the <see cref="ID2D1TransformedGeometry"/> object's source geometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetTransform;
}
