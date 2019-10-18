// <copyright file="D2D1DCRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Issues drawing commands to a GDI device context.
    /// </summary>
    public sealed class D2D1DCRenderTarget : D2D1RenderTarget
    {
        /// <summary>
        /// The D2D1 render target interface.
        /// </summary>
        private readonly ID2D1DCRenderTarget renderTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1DCRenderTarget"/> class.
        /// </summary>
        /// <param name="renderTarget">A D2D1 render target interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1DCRenderTarget(ID2D1DCRenderTarget renderTarget)
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
        /// Binds the render target to the device context to which it issues drawing commands.
        /// </summary>
        /// <param name="hdc">The device context to which the render target issues drawing commands.</param>
        /// <param name="subRect">The dimensions of the handle to a device context (HDC) to which the render target is bound.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void BindDC(IntPtr hdc, D2D1RectL subRect)
        {
            this.renderTarget.BindDC(hdc, ref subRect);
        }
    }
}
