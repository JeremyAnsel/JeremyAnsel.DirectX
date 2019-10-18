// <copyright file="D3D11DepthStencilState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// The depth-stencil-state interface holds a description for depth-stencil state that you can bind to the output-merger stage.
    /// </summary>
    public sealed class D3D11DepthStencilState : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 depth stencil state interface.
        /// </summary>
        private ID3D11DepthStencilState depthStencilState;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11DepthStencilState"/> class.
        /// </summary>
        /// <param name="depthStencilState">A D3D11 depth stencil depth interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11DepthStencilState(ID3D11DepthStencilState depthStencilState)
        {
            this.depthStencilState = depthStencilState;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.depthStencilState; }
        }

        /// <summary>
        /// Gets the description for depth-stencil state that you used to create the depth-stencil-state object.
        /// </summary>
        public D3D11DepthStencilDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11DepthStencilDesc desc;
                this.depthStencilState.GetDesc(out desc);
                return desc;
            }
        }
    }
}
