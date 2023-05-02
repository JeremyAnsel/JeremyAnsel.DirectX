// <copyright file="D2D1SolidColorBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Paints an area with a solid color.
    /// </summary>
    public sealed class D2D1SolidColorBrush : D2D1Brush
    {
        /// <summary>
        /// The D2D1 brush interface.
        /// </summary>
        private readonly ID2D1SolidColorBrush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1SolidColorBrush"/> class.
        /// </summary>
        /// <param name="brush">A D2D1 brush interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1SolidColorBrush(ID2D1SolidColorBrush brush)
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

        /// <summary>
        /// Gets or sets the color of the solid color brush.
        /// </summary>
        public D2D1ColorF Color
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.brush.GetColor(out D2D1ColorF color);
                return color;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetColor(ref value); }
        }
    }
}
