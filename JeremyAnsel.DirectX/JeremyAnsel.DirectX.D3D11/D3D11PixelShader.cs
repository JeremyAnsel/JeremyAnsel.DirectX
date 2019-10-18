// <copyright file="D3D11PixelShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A pixel shader interface manages an executable program (a pixel shader) that controls the pixel shader stage.
    /// </summary>
    public sealed class D3D11PixelShader : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 pixel shader interface.
        /// </summary>
        private ID3D11PixelShader pixelShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11PixelShader"/> class.
        /// </summary>
        /// <param name="pixelShader">A D3D11 pixel shader interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11PixelShader(ID3D11PixelShader pixelShader)
        {
            this.pixelShader = pixelShader;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.pixelShader; }
        }
    }
}
