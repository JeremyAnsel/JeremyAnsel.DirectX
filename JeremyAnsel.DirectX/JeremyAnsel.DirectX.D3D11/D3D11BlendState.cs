// <copyright file="D3D11BlendState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// The blend-state interface holds a description for blending state that you can bind to the output-merger stage.
    /// </summary>
    public sealed class D3D11BlendState : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 blend state interface.
        /// </summary>
        private ID3D11BlendState blendState;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11BlendState"/> class.
        /// </summary>
        /// <param name="blendState">A D3D11 blend state interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11BlendState(ID3D11BlendState blendState)
        {
            this.blendState = blendState;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.blendState; }
        }

        /// <summary>
        /// Gets the description for blending state that you used to create the blend-state object.
        /// </summary>
        public D3D11BlendDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11BlendDesc desc;
                this.blendState.GetDesc(out desc);
                return desc;
            }
        }
    }
}
