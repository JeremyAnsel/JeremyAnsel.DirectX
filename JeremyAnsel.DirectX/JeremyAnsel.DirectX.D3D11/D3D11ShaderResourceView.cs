// <copyright file="D3D11ShaderResourceView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A shader-resource-view interface specifies the subresources a shader can access during rendering.
    /// </summary>
    public sealed class D3D11ShaderResourceView : D3D11View
    {
        /// <summary>
        /// The D3D11 shader resource view interface.
        /// </summary>
        private readonly ID3D11ShaderResourceView shaderResourceView;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ShaderResourceView"/> class.
        /// </summary>
        /// <param name="shaderResourceView">A D3D11 shader resource view interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11ShaderResourceView(ID3D11ShaderResourceView shaderResourceView)
        {
            this.shaderResourceView = shaderResourceView;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.shaderResourceView; }
        }

        /// <summary>
        /// Gets the shader resource view's description.
        /// </summary>
        public D3D11ShaderResourceViewDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.shaderResourceView.GetDesc(out D3D11ShaderResourceViewDesc desc);
                return desc;
            }
        }
    }
}
