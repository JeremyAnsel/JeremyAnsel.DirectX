// <copyright file="D3D11RenderTargetView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A render-target-view interface identifies the render-target subresources that can be accessed during rendering.
    /// </summary>
    public sealed class D3D11RenderTargetView : D3D11View
    {
        /// <summary>
        /// The D3D11 render interface.
        /// </summary>
        private readonly ID3D11RenderTargetView renderTargetView;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11RenderTargetView"/> class.
        /// </summary>
        /// <param name="renderTargetView">A D3D11 render target view interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11RenderTargetView(ID3D11RenderTargetView renderTargetView)
        {
            this.renderTargetView = renderTargetView;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.renderTargetView; }
        }

        /// <summary>
        /// Gets the properties of a render target view.
        /// </summary>
        public D3D11RenderTargetViewDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.renderTargetView.GetDesc(out D3D11RenderTargetViewDesc desc);
                return desc;
            }
        }
    }
}
