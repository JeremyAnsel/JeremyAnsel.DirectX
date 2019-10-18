// <copyright file="D3D11RasterizerState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// The rasterizer-state interface holds a description for rasterizer state that you can bind to the rasterizer stage.
    /// </summary>
    public sealed class D3D11RasterizerState : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 rasterizer state interface.
        /// </summary>
        private ID3D11RasterizerState rasterizerState;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11RasterizerState"/> class.
        /// </summary>
        /// <param name="rasterizerState">A D3D11 rasterizer state interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11RasterizerState(ID3D11RasterizerState rasterizerState)
        {
            this.rasterizerState = rasterizerState;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.rasterizerState; }
        }

        /// <summary>
        /// Gets the description for rasterizer state that you used to create the rasterizer-state object.
        /// </summary>
        public D3D11RasterizerDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11RasterizerDesc desc;
                this.rasterizerState.GetDesc(out desc);
                return desc;
            }
        }
    }
}
