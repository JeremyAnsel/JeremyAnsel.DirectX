// <copyright file="D2D1RenderTargetBase.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents an object that can receive drawing commands.
    /// </summary>
    internal sealed class D2D1RenderTargetBase : D2D1RenderTarget
    {
        /// <summary>
        /// The D2D1 render target interface.
        /// </summary>
        private ID2D1RenderTarget renderTarget;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1RenderTargetBase"/> class.
        /// </summary>
        /// <param name="renderTarget">A D2D1 render target interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1RenderTargetBase(ID2D1RenderTarget renderTarget)
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
    }
}
