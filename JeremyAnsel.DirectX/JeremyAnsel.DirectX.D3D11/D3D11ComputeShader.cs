// <copyright file="D3D11ComputeShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A compute shader interface manages an executable program (a compute shader) that controls the compute shader stage.
    /// </summary>
    public sealed class D3D11ComputeShader : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 compute shader interface.
        /// </summary>
        private ID3D11ComputeShader computeShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11ComputeShader"/> class.
        /// </summary>
        /// <param name="computeShader">A D3D11 compute shader interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11ComputeShader(ID3D11ComputeShader computeShader)
        {
            this.computeShader = computeShader;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.computeShader; }
        }
    }
}
