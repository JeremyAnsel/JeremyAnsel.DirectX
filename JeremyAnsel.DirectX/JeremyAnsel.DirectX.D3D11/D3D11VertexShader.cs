// <copyright file="D3D11VertexShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A vertex shader interface manages an executable program (a vertex shader) that controls the vertex shader stage.
    /// </summary>
    public sealed class D3D11VertexShader : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 vertex shader interface.
        /// </summary>
        private readonly ID3D11VertexShader vertexShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11VertexShader"/> class.
        /// </summary>
        /// <param name="vertexShader">A D3D11 vertex shader interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11VertexShader(ID3D11VertexShader vertexShader)
        {
            this.vertexShader = vertexShader;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.vertexShader; }
        }
    }
}
