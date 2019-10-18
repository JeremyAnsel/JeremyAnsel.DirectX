// <copyright file="D3D11InputLayout.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// An input-layout interface holds a definition of how to feed vertex data that is laid out in memory into the input-assembler stage of the graphics pipeline.
    /// </summary>
    public sealed class D3D11InputLayout : D3D11DeviceChild
    {
        /// <summary>
        /// The D3D11 input layout interface.
        /// </summary>
        private ID3D11InputLayout inputLayout;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11InputLayout"/> class.
        /// </summary>
        /// <param name="inputLayout">A D3D11 input layout interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11InputLayout(ID3D11InputLayout inputLayout)
        {
            this.inputLayout = inputLayout;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.inputLayout; }
        }
    }
}
