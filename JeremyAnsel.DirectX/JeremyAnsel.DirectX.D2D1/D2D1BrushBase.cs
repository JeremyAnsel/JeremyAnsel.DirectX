// <copyright file="D2D1BrushBase.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// The root brush interface. All brushes can be used to fill or pen a geometry.
    /// </summary>
    internal sealed class D2D1BrushBase : D2D1Brush
    {
        /// <summary>
        /// The D2D1 brush interface.
        /// </summary>
        private readonly ID2D1Brush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BrushBase"/> class.
        /// </summary>
        /// <param name="brush">A D2D1 brush interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1BrushBase(ID2D1Brush brush)
        {
            this.brush = brush;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush; }
        }
    }
}
