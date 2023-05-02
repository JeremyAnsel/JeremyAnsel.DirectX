// <copyright file="D2D1LinearGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Paints an area with a linear gradient.
    /// </summary>
    public sealed class D2D1LinearGradientBrush : D2D1Brush
    {
        /// <summary>
        /// The D2D1 brush interface.
        /// </summary>
        private readonly ID2D1LinearGradientBrush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1LinearGradientBrush"/> class.
        /// </summary>
        /// <param name="brush">A D2D1 brush interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1LinearGradientBrush(ID2D1LinearGradientBrush brush)
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
        /// Gets or sets the starting coordinates of the linear gradient in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F StartPoint
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.brush.GetStartPoint(out D2D1Point2F point);
                return point;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetStartPoint(value); }
        }

        /// <summary>
        /// Gets or sets the ending coordinates of the linear gradient in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F EndPoint
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.brush.GetEndPoint(out D2D1Point2F point);
                return point;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetEndPoint(value); }
        }

        /// <summary>
        /// Retrieves the <see cref="D2D1GradientStopCollection"/> associated with this linear gradient brush.
        /// </summary>
        /// <returns>The <see cref="D2D1GradientStopCollection"/> object associated with this linear gradient brush object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GradientStopCollection GetGradientStopCollection()
        {
            this.brush.GetGradientStopCollection(out ID2D1GradientStopCollection gradientStopCollection);

            if (gradientStopCollection == null)
            {
                return null;
            }

            return new D2D1GradientStopCollection(gradientStopCollection);
        }
    }
}
