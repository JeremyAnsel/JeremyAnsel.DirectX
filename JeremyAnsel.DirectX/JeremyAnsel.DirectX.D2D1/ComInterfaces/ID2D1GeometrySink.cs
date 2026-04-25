// <copyright file="ID2D1GeometrySink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Describes a geometric path that can contain lines, arcs, cubic Bezier curves, and quadratic Bezier curves.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1SimplifiedGeometrySink"/></remarks>
[Guid("2cd9069f-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1GeometrySink
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetFillMode;
    private readonly nint SetSegmentFlags;
    private readonly nint BeginFigure;
    private readonly nint AddLines;
    private readonly nint AddBeziers;
    private readonly nint EndFigure;
    private readonly nint Close;

    /// <summary>
    /// Creates a line segment between the current point and the specified end point and adds it to the geometry sink.
    /// </summary>
    /// <param name="point">The end point of the line to draw.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, void> AddLine;

    /// <summary>
    /// Creates a cubic Bezier curve between the current point and the specified endpoint.
    /// </summary>
    /// <param name="bezier">A structure that describes the control points and endpoint of the Bezier curve to add.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> AddBezier;

    /// <summary>
    /// Creates a quadratic Bezier curve between the current point and the specified endpoint.
    /// </summary>
    /// <param name="bezier">A structure that describes the control point and the endpoint of the quadratic Bezier curve to add.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> AddQuadraticBezier;

    /// <summary>
    /// Adds a sequence of quadratic Bezier segments as an array in a single call.
    /// </summary>
    /// <param name="beziers">An array of a sequence of quadratic Bezier segments.</param>
    /// <param name="beziersCount">A value indicating the number of quadratic Bezier segments in beziers.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, void> AddQuadraticBeziers;

    /// <summary>
    /// Adds a single arc to the path geometry.
    /// </summary>
    /// <param name="arc">The arc segment to add to the figure.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> AddArc;
}
