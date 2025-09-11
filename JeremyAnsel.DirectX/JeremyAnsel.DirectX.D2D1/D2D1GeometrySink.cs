// <copyright file="D2D1GeometrySink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Describes a geometric path that can contain lines, arcs, cubic Bezier curves, and quadratic Bezier curves.
    /// </summary>
    public sealed class D2D1GeometrySink : D2D1SimplifiedGeometrySink
    {
        /// <summary>
        /// The D2D1 brush interface.
        /// </summary>
        private readonly ID2D1GeometrySink geometrySink;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1GeometrySink"/> class.
        /// </summary>
        /// <param name="geometrySink">A D2D1 brush interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1GeometrySink(ID2D1GeometrySink geometrySink)
        {
            this.geometrySink = geometrySink;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.geometrySink; }
        }

        /// <summary>
        /// Creates a line segment between the current point and the specified end point and adds it to the geometry sink.
        /// </summary>
        /// <param name="point">The end point of the line to draw.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddLine(D2D1Point2F point)
        {
            this.geometrySink.AddLine(point);
        }

        /// <summary>
        /// Creates a cubic Bezier curve between the current point and the specified endpoint.
        /// </summary>
        /// <param name="bezier">A structure that describes the control points and endpoint of the Bezier curve to add.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddBezier(D2D1BezierSegment bezier)
        {
            this.geometrySink.AddBezier(ref bezier);
        }

        /// <summary>
        /// Creates a quadratic Bezier curve between the current point and the specified endpoint.
        /// </summary>
        /// <param name="bezier">A structure that describes the control point and the endpoint of the quadratic Bezier curve to add.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddQuadraticBezier(D2D1QuadraticBezierSegment bezier)
        {
            this.geometrySink.AddQuadraticBezier(ref bezier);
        }

        /// <summary>
        /// Adds a sequence of quadratic Bezier segments as an array in a single call.
        /// </summary>
        /// <param name="beziers">An array of a sequence of quadratic Bezier segments.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddQuadraticBeziers(D2D1QuadraticBezierSegment[]? beziers)
        {
            if (beziers == null)
            {
                throw new ArgumentNullException(nameof(beziers));
            }

            this.geometrySink.AddQuadraticBeziers(beziers, (uint)beziers.Length);
        }

        /// <summary>
        /// Adds a single arc to the path geometry.
        /// </summary>
        /// <param name="arc">The arc segment to add to the figure.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public void AddArc(D2D1ArcSegment arc)
        {
            this.geometrySink.AddArc(ref arc);
        }
    }
}
