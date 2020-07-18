// <copyright file="D2D1RadialGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Paints an area with a radial gradient.
    /// </summary>
    public sealed class D2D1RadialGradientBrush : D2D1Brush
    {
        /// <summary>
        /// The D2D1 brush interface.
        /// </summary>
        private readonly ID2D1RadialGradientBrush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RadialGradientBrush"/> class.
        /// </summary>
        /// <param name="brush">A D2D1 brush interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1RadialGradientBrush(ID2D1RadialGradientBrush brush)
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
        /// Gets or sets the center of the gradient ellipse in the brush's coordinate space.
        /// </summary>
        public D2D1Point2F Center
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetCenter(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetCenter(value); }
        }

        /// <summary>
        /// Gets or sets the offset of the gradient origin relative to the gradient ellipse's center.
        /// </summary>
        public D2D1Point2F GradientOriginOffset
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetGradientOriginOffset(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetGradientOriginOffset(value); }
        }

        /// <summary>
        /// Gets or sets the x-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        public float RadiusX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetRadiusX(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetRadiusX(value); }
        }

        /// <summary>
        /// Gets or sets the y-radius of the gradient ellipse, in the brush's coordinate space.
        /// </summary>
        public float RadiusY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetRadiusY(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetRadiusY(value); }
        }

        /// <summary>
        /// Retrieves the <see cref="D2D1GradientStopCollection"/> associated with this radial gradient brush object.
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
