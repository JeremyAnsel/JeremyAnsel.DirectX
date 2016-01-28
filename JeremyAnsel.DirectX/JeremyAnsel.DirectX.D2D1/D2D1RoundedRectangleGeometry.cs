// <copyright file="D2D1RoundedRectangleGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Describes a rounded rectangle.
    /// </summary>
    public sealed class D2D1RoundedRectangleGeometry : D2D1Geometry
    {
        /// <summary>
        /// The D2D1 geometry interface.
        /// </summary>
        private ID2D1RoundedRectangleGeometry geometry;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RoundedRectangleGeometry"/> class.
        /// </summary>
        /// <param name="geometry">A D2D1 geometry interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1RoundedRectangleGeometry(ID2D1RoundedRectangleGeometry geometry)
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
        /// Gets a rounded rectangle that describes this rounded rectangle geometry.
        /// </summary>
        public D2D1RoundedRect RoundedRect
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D2D1RoundedRect roundedRect;
                this.geometry.GetRoundedRect(out roundedRect);
                return roundedRect;
            }
        }
    }
}
