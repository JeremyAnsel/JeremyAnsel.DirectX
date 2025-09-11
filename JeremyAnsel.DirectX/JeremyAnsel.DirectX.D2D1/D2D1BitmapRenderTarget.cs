// <copyright file="D2D1BitmapRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Renders to an intermediate texture created by the <see cref="D2D1RenderTarget.CreateCompatibleRenderTarget()"/> method.
    /// </summary>
    public sealed class D2D1BitmapRenderTarget : D2D1RenderTarget
    {
        /// <summary>
        /// The D2D1 render target interface.
        /// </summary>
        private readonly ID2D1BitmapRenderTarget renderTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1BitmapRenderTarget"/> class.
        /// </summary>
        /// <param name="renderTarget">A D2D1 render target interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1BitmapRenderTarget(ID2D1BitmapRenderTarget renderTarget)
        {
            this.renderTarget = renderTarget;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.renderTarget; }
        }

        /// <summary>
        /// Gets the bitmap for this render target. The returned bitmap can be used for drawing operations.
        /// </summary>
        public D2D1Bitmap? Bitmap
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.renderTarget.GetBitmap(out ID2D1Bitmap? bitmap);

                if (bitmap == null)
                {
                    return null;
                }

                return new D2D1Bitmap(bitmap);
            }
        }
    }
}
