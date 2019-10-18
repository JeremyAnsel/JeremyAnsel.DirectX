// <copyright file="D3D11DomainShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A domain shader interface manages an executable program (a domain shader) that controls the domain shader stage.
    /// </summary>
    public sealed class D3D11DomainShader : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 domain shader interface.
        /// </summary>
        private ID3D11DomainShader domainShader;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11DomainShader"/> class.
        /// </summary>
        /// <param name="domainShader">A D3D11 domain shader interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11DomainShader(ID3D11DomainShader domainShader)
        {
            this.domainShader = domainShader;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.domainShader; }
        }
    }
}
