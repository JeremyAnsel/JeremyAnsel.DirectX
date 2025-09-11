// <copyright file="D2D1PathGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents a complex shape that may be composed of arcs, curves, and lines.
    /// </summary>
    public sealed class D2D1PathGeometry : D2D1Geometry
    {
        /// <summary>
        /// The D2D1 geometry interface.
        /// </summary>
        private readonly ID2D1PathGeometry geometry;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1PathGeometry"/> class.
        /// </summary>
        /// <param name="geometry">A D2D1 geometry interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1PathGeometry(ID2D1PathGeometry geometry)
        {
            this.geometry = geometry;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.geometry; }
        }

        /// <summary>
        /// Gets the number of segments in the path geometry.
        /// </summary>
        public uint SegmentCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.geometry.GetSegmentCount(out uint count);
                return count;
            }
        }

        /// <summary>
        /// Gets the number of figures in the path geometry.
        /// </summary>
        public uint FigureCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.geometry.GetFigureCount(out uint count);
                return count;
            }
        }

        /// <summary>
        /// Retrieves the geometry sink that is used to populate the path geometry with figures and segments.
        /// </summary>
        /// <returns>The geometry sink that is used to populate the path geometry with figures and segments.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GeometrySink? Open()
        {
            this.geometry.Open(out ID2D1GeometrySink? geometrySink);

            if (geometrySink == null)
            {
                return null;
            }

            return new D2D1GeometrySink(geometrySink);
        }

        /// <summary>
        /// Copies the contents of the path geometry to the specified <see cref="D2D1GeometrySink"/>.
        /// </summary>
        /// <param name="geometrySink">The sink to which the path geometry's contents are copied. Modifying this sink does not change the contents of this path geometry.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Stream(D2D1GeometrySink? geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.geometry.Stream(geometrySink.GetHandle<ID2D1GeometrySink>());
        }
    }
}
