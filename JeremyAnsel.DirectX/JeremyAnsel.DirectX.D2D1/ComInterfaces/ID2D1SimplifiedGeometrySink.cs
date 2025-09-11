// <copyright file="ID2D1SimplifiedGeometrySink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Describes a geometric path that does not contain quadratic bezier curves or arcs.
    /// </summary>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd9069e-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1SimplifiedGeometrySink
    {
        /// <summary>
        /// Specifies the method used to determine which points are inside the geometry described by this geometry sink and which points are outside.
        /// </summary>
        /// <param name="fillMode">The method used to determine whether a given point is part of the geometry.</param>
        [PreserveSig]
        void SetFillMode(
            [In] D2D1FillMode fillMode);

        /// <summary>
        /// Specifies stroke and join options to be applied to new segments added to the geometry sink.
        /// </summary>
        /// <param name="vertexFlags">Stroke and join options to be applied to new segments added to the geometry sink.</param>
        [PreserveSig]
        void SetSegmentFlags(
            [In] D2D1PathSegmentOptions vertexFlags);

        /// <summary>
        /// Starts a new figure at the specified point.
        /// </summary>
        /// <param name="startPoint">The point at which to begin the new figure.</param>
        /// <param name="figureBegin">Whether the new figure should be hollow or filled.</param>
        [PreserveSig]
        void BeginFigure(
            [In] D2D1Point2F startPoint,
            [In] D2D1FigureBegin figureBegin);

        /// <summary>
        /// Creates a sequence of lines using the specified points and adds them to the geometry sink.
        /// </summary>
        /// <param name="points">An array of one or more points that describe the lines to draw. A line is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the first point in the array. if the array contains additional points, a line is drawn from the first point to the second point in the array, from the second point to the third point, and so on.</param>
        /// <param name="pointsCount">The number of points in the points array.</param>
        [PreserveSig]
        void AddLines(
            [In, MarshalAs(UnmanagedType.LPArray)] D2D1Point2F[]? points,
            [In] uint pointsCount);

        /// <summary>
        /// Creates a sequence of cubic Bezier curves and adds them to the geometry sink.
        /// </summary>
        /// <param name="beziers">An array of Bezier segments that describes the Bezier curves to create. A curve is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the end point of the first Bezier segment in the array. if the array contains additional Bezier segments, each subsequent Bezier segment uses the end point of the preceding Bezier segment as its start point.</param>
        /// <param name="beziersCount">The number of Bezier segments in the beziers array.</param>
        [PreserveSig]
        void AddBeziers(
            [In, MarshalAs(UnmanagedType.LPArray)] D2D1BezierSegment[]? beziers,
            [In] uint beziersCount);

        /// <summary>
        /// Ends the current figure; optionally, closes it.
        /// </summary>
        /// <param name="figureEnd">A value that indicates whether the current figure is closed. If the figure is closed, a line is drawn between the current point and the start point specified by <see cref="BeginFigure"/>.</param>
        [PreserveSig]
        void EndFigure(
            [In] D2D1FigureEnd figureEnd);

        /// <summary>
        /// Closes the geometry sink, indicates whether it is in an error state, and resets the sink's error state.
        /// </summary>
        void Close();
    }
}
