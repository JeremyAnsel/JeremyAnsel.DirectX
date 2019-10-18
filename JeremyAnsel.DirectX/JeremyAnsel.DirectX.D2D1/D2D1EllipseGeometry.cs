// <copyright file="D2D1EllipseGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents an ellipse.
    /// </summary>
    public sealed class D2D1EllipseGeometry : D2D1Geometry
    {
        /// <summary>
        /// The D2D1 geometry interface.
        /// </summary>
        private ID2D1EllipseGeometry geometry;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1EllipseGeometry"/> class.
        /// </summary>
        /// <param name="geometry">A D2D1 geometry interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1EllipseGeometry(ID2D1EllipseGeometry geometry)
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
        /// Gets the <see cref="D2D1Ellipse"/> structure that describes this ellipse geometry.
        /// </summary>
        public D2D1Ellipse Ellipse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D2D1Ellipse ellipse;
                this.geometry.GetEllipse(out ellipse);
                return ellipse;
            }
        }
    }
}
