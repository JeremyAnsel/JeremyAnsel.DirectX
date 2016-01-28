// <copyright file="D2D1RectangleGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Describes a two-dimensional rectangle.
    /// </summary>
    public sealed class D2D1RectangleGeometry : D2D1Geometry
    {
        /// <summary>
        /// The D2D1 geometry interface.
        /// </summary>
        private ID2D1RectangleGeometry geometry;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RectangleGeometry"/> class.
        /// </summary>
        /// <param name="geometry">A D2D1 geometry interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1RectangleGeometry(ID2D1RectangleGeometry geometry)
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
        /// Gets the rectangle that describes the rectangle geometry's dimensions.
        /// </summary>
        public D2D1RectF Rect
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D2D1RectF rect;
                this.geometry.GetRect(out rect);
                return rect;
            }
        }
    }
}
