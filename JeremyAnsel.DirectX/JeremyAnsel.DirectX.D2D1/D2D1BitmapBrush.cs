// <copyright file="D2D1BitmapBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// A bitmap brush allows a bitmap to be used to fill a geometry.
    /// </summary>
    public sealed class D2D1BitmapBrush : D2D1Brush
    {
        /// <summary>
        /// The D2D1 brush interface.
        /// </summary>
        private readonly ID2D1BitmapBrush brush;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BitmapBrush"/> class.
        /// </summary>
        /// <param name="brush">A D2D1 brush interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1BitmapBrush(ID2D1BitmapBrush brush)
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
        /// Gets or sets the method by which the brush horizontally tiles those areas that extend past its bitmap.
        /// </summary>
        public D2D1ExtendMode ExtendModeX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetExtendModeX(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetExtendModeX(value); }
        }

        /// <summary>
        /// Gets or sets the method by which the brush vertically tiles those areas that extend past its bitmap.
        /// </summary>
        public D2D1ExtendMode ExtendModeY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetExtendModeY(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetExtendModeY(value); }
        }

        /// <summary>
        /// Gets or sets the interpolation method used when the brush bitmap is scaled or rotated.
        /// </summary>
        public D2D1BitmapInterpolationMode InterpolationMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.brush.GetInterpolationMode(); }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set { this.brush.SetInterpolationMode(value); }
        }

        /// <summary>
        /// Gets or sets the bitmap source that this brush uses to paint.
        /// </summary>
        public D2D1Bitmap Bitmap
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                ID2D1Bitmap bitmap;
                this.brush.GetBitmap(out bitmap);

                if (bitmap == null)
                {
                    return null;
                }

                return new D2D1Bitmap(bitmap);
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            set
            {
                this.brush.SetBitmap(value?.GetHandle<ID2D1Bitmap>());
            }
        }
    }
}
