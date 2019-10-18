// <copyright file="D2D1SimplifiedGeometrySink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Describes a geometric path that does not contain quadratic bezier curves or arcs.
    /// </summary>
    [SuppressMessage("Design", "CA1063:Implémenter IDisposable correctement", Justification = "Reviewed")]
    public abstract class D2D1SimplifiedGeometrySink : IDisposable, ID2D1Releasable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1SimplifiedGeometrySink"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1SimplifiedGeometrySink()
        {
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public abstract object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <param name="value">A D2D1 object.</param>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(D2D1SimplifiedGeometrySink value)
        {
            return value != null && value.Handle != null;
        }

        /// <summary>
        /// Gets a boolean indicating if the handle is not null.
        /// </summary>
        /// <returns>A boolean</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ToBoolean()
        {
            return this.Handle != null;
        }

        /// <summary>
        /// Immediately releases the unmanaged resources used by the <see cref="D2D1SimplifiedGeometrySink"/> object.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Marshal.ReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Releases the managed reference to the COM D2D1 interface.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Release()
        {
            Marshal.FinalReleaseComObject(this.Handle);
        }

        /// <summary>
        /// Specifies the method used to determine which points are inside the geometry described by this geometry sink and which points are outside.
        /// </summary>
        /// <param name="fillMode">The method used to determine whether a given point is part of the geometry.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void SetFillMode(D2D1FillMode fillMode)
        {
            this.GetHandle<ID2D1SimplifiedGeometrySink>().SetFillMode(fillMode);
        }

        /// <summary>
        /// Specifies stroke and join options to be applied to new segments added to the geometry sink.
        /// </summary>
        /// <param name="vertexOptions">Stroke and join options to be applied to new segments added to the geometry sink.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void SetSegmentOptions(D2D1PathSegmentOptions vertexOptions)
        {
            this.GetHandle<ID2D1SimplifiedGeometrySink>().SetSegmentFlags(vertexOptions);
        }

        /// <summary>
        /// Starts a new figure at the specified point.
        /// </summary>
        /// <param name="startPoint">The point at which to begin the new figure.</param>
        /// <param name="figureBegin">Whether the new figure should be hollow or filled.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void BeginFigure(D2D1Point2F startPoint, D2D1FigureBegin figureBegin)
        {
            this.GetHandle<ID2D1SimplifiedGeometrySink>().BeginFigure(startPoint, figureBegin);
        }

        /// <summary>
        /// Creates a sequence of lines using the specified points and adds them to the geometry sink.
        /// </summary>
        /// <param name="points">An array of one or more points that describe the lines to draw. A line is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the first point in the array. if the array contains additional points, a line is drawn from the first point to the second point in the array, from the second point to the third point, and so on.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddLines(D2D1Point2F[] points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            this.GetHandle<ID2D1SimplifiedGeometrySink>().AddLines(points, (uint)points.Length);
        }

        /// <summary>
        /// Creates a sequence of cubic Bezier curves and adds them to the geometry sink.
        /// </summary>
        /// <param name="beziers">An array of Bezier segments that describes the Bezier curves to create. A curve is drawn from the geometry sink's current point (the end point of the last segment drawn or the location specified by <see cref="BeginFigure"/>) to the end point of the first Bezier segment in the array. if the array contains additional Bezier segments, each subsequent Bezier segment uses the end point of the preceding Bezier segment as its start point.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddBeziers(D2D1BezierSegment[] beziers)
        {
            if (beziers == null)
            {
                throw new ArgumentNullException(nameof(beziers));
            }

            this.GetHandle<ID2D1SimplifiedGeometrySink>().AddBeziers(beziers, (uint)beziers.Length);
        }

        /// <summary>
        /// Ends the current figure; optionally, closes it.
        /// </summary>
        /// <param name="figureEnd">A value that indicates whether the current figure is closed. If the figure is closed, a line is drawn between the current point and the start point specified by <see cref="BeginFigure"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void EndFigure(D2D1FigureEnd figureEnd)
        {
            this.GetHandle<ID2D1SimplifiedGeometrySink>().EndFigure(figureEnd);
        }

        /// <summary>
        /// Closes the geometry sink, indicates whether it is in an error state, and resets the sink's error state.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Close()
        {
            this.GetHandle<ID2D1SimplifiedGeometrySink>().Close();
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        /// <typeparam name="T">A D2D1 interface type.</typeparam>
        /// <returns>The D2D1 interface.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal T GetHandle<T>()
        {
            return (T)this.Handle;
        }
    }
}
