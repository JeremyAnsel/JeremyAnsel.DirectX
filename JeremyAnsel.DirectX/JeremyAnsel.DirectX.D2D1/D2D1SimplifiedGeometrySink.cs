// <copyright file="D2D1SimplifiedGeometrySink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes a geometric path that does not contain quadratic bezier curves or arcs.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1SimplifiedGeometrySink : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1SimplifiedGeometrySinkGuid = typeof(ID2D1SimplifiedGeometrySink).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1SimplifiedGeometrySink* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1SimplifiedGeometrySink"/> class.
    /// </summary>
    public D2D1SimplifiedGeometrySink(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1SimplifiedGeometrySink**)comPtr;
    }

    /// <summary>
    /// Specifies the method used to determine which points are inside the geometry described by this geometry sink and which points are outside.
    /// </summary>
    /// <param name="fillMode">The method used to determine whether a given point is part of the geometry.</param>
    public void SetFillMode(D2D1FillMode fillMode)
    {
        _comImpl->SetFillMode(_comPtr, fillMode);
    }

    /// <summary>
    /// Specifies stroke and join options to be applied to new segments added to the geometry sink.
    /// </summary>
    /// <param name="vertexOptions">Stroke and join options to be applied to new segments added to the geometry sink.</param>
    public void SetSegmentOptions(D2D1PathSegmentOptions vertexOptions)
    {
        _comImpl->SetSegmentFlags(_comPtr, vertexOptions);
    }

    /// <summary>
    /// Starts a new figure at the specified point.
    /// </summary>
    /// <param name="startPoint">The point at which to begin the new figure.</param>
    /// <param name="figureBegin">Whether the new figure should be hollow or filled.</param>
    public void BeginFigure(in D2D1Point2F startPoint, D2D1FigureBegin figureBegin)
    {
        _comImpl->BeginFigure(_comPtr, startPoint.X, startPoint.Y, figureBegin);
    }

    /// <summary>
    /// Creates a sequence of lines using the specified points and adds them to the geometry sink.
    /// </summary>
    /// <param name="points">An array of one or more points that describe the lines to draw. A line is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the first point in the array. if the array contains additional points, a line is drawn from the first point to the second point in the array, from the second point to the third point, and so on.</param>
    public void AddLines(D2D1Point2F[]? points)
    {
        AddLines(points.AsSpan());
    }

    /// <summary>
    /// Creates a sequence of lines using the specified points and adds them to the geometry sink.
    /// </summary>
    /// <param name="points">An array of one or more points that describe the lines to draw. A line is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the first point in the array. if the array contains additional points, a line is drawn from the first point to the second point in the array, from the second point to the third point, and so on.</param>
    public void AddLines(ReadOnlySpan<D2D1Point2F> points)
    {
        if (points.Length == 0)
        {
            throw new ArgumentNullException(nameof(points));
        }

        int size = D2D1Point2F.NativeRequiredSize(points.Length);
        byte* ptr = stackalloc byte[size];
        D2D1Point2F.NativeWriteTo((nint)ptr, points);
        _comImpl->AddLines(_comPtr, ptr, (uint)points.Length);
    }

    /// <summary>
    /// Creates a sequence of cubic Bezier curves and adds them to the geometry sink.
    /// </summary>
    /// <param name="beziers">An array of Bezier segments that describes the Bezier curves to create. A curve is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the end point of the first Bezier segment in the array. if the array contains additional Bezier segments, each subsequent Bezier segment uses the end point of the preceding Bezier segment as its start point.</param>
    public void AddBeziers(D2D1BezierSegment[]? beziers)
    {
        AddBeziers(beziers.AsSpan());
    }

    /// <summary>
    /// Creates a sequence of cubic Bezier curves and adds them to the geometry sink.
    /// </summary>
    /// <param name="beziers">An array of Bezier segments that describes the Bezier curves to create. A curve is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the end point of the first Bezier segment in the array. if the array contains additional Bezier segments, each subsequent Bezier segment uses the end point of the preceding Bezier segment as its start point.</param>
    public void AddBeziers(ReadOnlySpan<D2D1BezierSegment> beziers)
    {
        if (beziers.Length == 0)
        {
            throw new ArgumentNullException(nameof(beziers));
        }

        int size = D2D1BezierSegment.NativeRequiredSize(beziers.Length);
        byte* ptr = stackalloc byte[size];
        D2D1BezierSegment.NativeWriteTo((nint)ptr, beziers);
        _comImpl->AddBeziers(_comPtr, ptr, (uint)beziers.Length);
    }

    /// <summary>
    /// Ends the current figure; optionally, closes it.
    /// </summary>
    /// <param name="figureEnd">A value that indicates whether the current figure is closed. If the figure is closed, a line is drawn between the current point and the start point specified by <see cref="BeginFigure"/>.</param>
    public void EndFigure(D2D1FigureEnd figureEnd)
    {
        _comImpl->EndFigure(_comPtr, figureEnd);
    }

    /// <summary>
    /// Closes the geometry sink, indicates whether it is in an error state, and resets the sink's error state.
    /// </summary>
    public void Close()
    {
        int hr = _comImpl->Close(_comPtr);
        Marshal.ThrowExceptionForHR(hr);
    }
}
