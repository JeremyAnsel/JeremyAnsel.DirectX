// <copyright file="D3D11DepthStencilView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A depth-stencil-view interface accesses a texture resource during depth-stencil testing.
    /// </summary>
    public sealed class D3D11DepthStencilView : D3D11View
    {
        /// <summary>
        /// The D3D11 depth stencil view interface.
        /// </summary>
        private ID3D11DepthStencilView depthStencilView;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11DepthStencilView"/> class.
        /// </summary>
        /// <param name="depthStencilView">A D3D11 depth stencil view interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11DepthStencilView(ID3D11DepthStencilView depthStencilView)
        {
            this.depthStencilView = depthStencilView;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.depthStencilView; }
        }

        /// <summary>
        /// Gets the depth-stencil view.
        /// </summary>
        public D3D11DepthStencilViewDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11DepthStencilViewDesc desc;
                this.depthStencilView.GetDesc(out desc);
                return desc;
            }
        }
    }
}
