// <copyright file="D3D11HullShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A hull shader interface manages an executable program (a hull shader) that controls the hull shader stage.
    /// </summary>
    public sealed class D3D11HullShader : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 hull shader interface.
        /// </summary>
        private ID3D11HullShader hullShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11HullShader"/> class.
        /// </summary>
        /// <param name="hullShader">A D3D11 hull shader interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11HullShader(ID3D11HullShader hullShader)
        {
            this.hullShader = hullShader;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.hullShader; }
        }
    }
}
