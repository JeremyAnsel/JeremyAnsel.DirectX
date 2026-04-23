// <copyright file="ID2D1PathGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents a complex shape that may be composed of arcs, curves, and lines.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Geometry"/></remarks>
[Guid("2cd906a5-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1PathGeometry
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
    /// Retrieves the geometry sink that is used to populate the path geometry with figures and segments.
    /// </summary>
    /// <param name="geometrySink">The geometry sink that is used to populate the path geometry with figures and segments.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> Open;

    /// <summary>
    /// Copies the contents of the path geometry to the specified <see cref="ID2D1GeometrySink"/>.
    /// </summary>
    /// <param name="geometrySink">The sink to which the path geometry's contents are copied. Modifying this sink does not change the contents of this path geometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, int> Stream;

    /// <summary>
    /// Retrieves the number of segments in the path geometry.
    /// </summary>
    /// <param name="count">The number of segments in the path geometry when this method returns.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetSegmentCount;

    /// <summary>
    /// Retrieves the number of figures in the path geometry.
    /// </summary>
    /// <param name="count">The number of figures in the path geometry when this method returns.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, uint*, int> GetFigureCount;
}
