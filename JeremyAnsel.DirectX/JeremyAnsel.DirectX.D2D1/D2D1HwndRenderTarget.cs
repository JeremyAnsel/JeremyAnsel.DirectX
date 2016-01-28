// <copyright file="D2D1HwndRenderTarget.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Renders drawing instructions to a window.
    /// </summary>
    public sealed class D2D1HwndRenderTarget : D2D1RenderTarget
    {
        /// <summary>
        /// The D2D1 render target interface.
        /// </summary>
        private ID2D1HwndRenderTarget renderTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1HwndRenderTarget"/> class.
        /// </summary>
        /// <param name="renderTarget">A D2D1 render target interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1HwndRenderTarget(ID2D1HwndRenderTarget renderTarget)
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
        /// Gets the HWND associated with this render target.
        /// </summary>
        public IntPtr Hwnd
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.renderTarget.GetHwnd(); }
        }

        /// <summary>
        /// Indicates whether the HWND associated with this render target is occluded.
        /// </summary>
        /// <returns>A value that indicates whether the HWND associated with this render target is occluded.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1WindowStates CheckWindowState()
        {
            return this.renderTarget.CheckWindowState();
        }

        /// <summary>
        /// Changes the size of the render target to the specified pixel size.
        /// </summary>
        /// <param name="pixelSize">The new size of the render target in device pixels.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Resize(D2D1SizeU pixelSize)
        {
            this.renderTarget.Resize(ref pixelSize);
        }
    }
}
