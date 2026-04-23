// <copyright file="D2D1GeometrySink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes a geometric path that can contain lines, arcs, cubic Bezier curves, and quadratic Bezier curves.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1GeometrySink : D2D1SimplifiedGeometrySink
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1GeometrySinkGuid = typeof(ID2D1GeometrySink).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1GeometrySink* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1GeometrySink"/> class.
    /// </summary>
    public D2D1GeometrySink(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1GeometrySink**)comPtr;
    }

    /// <summary>
    /// Creates a line segment between the current point and the specified end point and adds it to the geometry sink.
    /// </summary>
    /// <param name="point">The end point of the line to draw.</param>
    public void AddLine(in D2D1Point2F point)
    {
        _comImpl->AddLine(_comPtr, point.X, point.Y);
    }

    /// <summary>
    /// Creates a cubic Bezier curve between the current point and the specified endpoint.
    /// </summary>
    /// <param name="bezier">A structure that describes the control points and endpoint of the Bezier curve to add.</param>
    public void AddBezier(in D2D1BezierSegment bezier)
    {
        int size = D2D1BezierSegment.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1BezierSegment.NativeWriteTo((nint)ptr, bezier);
        _comImpl->AddBezier(_comPtr, ptr);
    }

    /// <summary>
    /// Creates a quadratic Bezier curve between the current point and the specified endpoint.
    /// </summary>
    /// <param name="bezier">A structure that describes the control point and the endpoint of the quadratic Bezier curve to add.</param>
    public void AddQuadraticBezier(in D2D1QuadraticBezierSegment bezier)
    {
        int size = D2D1QuadraticBezierSegment.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1QuadraticBezierSegment.NativeWriteTo((nint)ptr, bezier);
        _comImpl->AddQuadraticBezier(_comPtr, ptr);
    }

    /// <summary>
    /// Adds a sequence of quadratic Bezier segments as an array in a single call.
    /// </summary>
    /// <param name="beziers">An array of a sequence of quadratic Bezier segments.</param>
    public void AddQuadraticBeziers(D2D1QuadraticBezierSegment[]? beziers)
    {
        AddQuadraticBeziers(beziers.AsSpan());
    }

    /// <summary>
    /// Adds a sequence of quadratic Bezier segments as an array in a single call.
    /// </summary>
    /// <param name="beziers">An array of a sequence of quadratic Bezier segments.</param>
    public void AddQuadraticBeziers(ReadOnlySpan<D2D1QuadraticBezierSegment> beziers)
    {
        if (beziers.Length == 0)
        {
            throw new ArgumentNullException(nameof(beziers));
        }

        int size = D2D1QuadraticBezierSegment.NativeRequiredSize(beziers.Length);
        byte* ptr = stackalloc byte[size];
        D2D1QuadraticBezierSegment.NativeWriteTo((nint)ptr, beziers);
        _comImpl->AddQuadraticBeziers(_comPtr, ptr, (uint)beziers.Length);
    }

    /// <summary>
    /// Adds a single arc to the path geometry.
    /// </summary>
    /// <param name="arc">The arc segment to add to the figure.</param>
    public void AddArc(in D2D1ArcSegment arc)
    {
        int size = D2D1ArcSegment.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1ArcSegment.NativeWriteTo((nint)ptr, arc);
        _comImpl->AddArc(_comPtr, ptr);
    }
}
