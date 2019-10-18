// <copyright file="D3D11Buffer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A buffer interface accesses a buffer resource, which is unstructured memory.
    /// </summary>
    public sealed class D3D11Buffer : D3D11Resource
    {
        /// <summary>
        /// The D3D11 buffer interface.
        /// </summary>
        private ID3D11Buffer buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Buffer"/> class.
        /// </summary>
        /// <param name="buffer">A D3D11 buffer interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Buffer(ID3D11Buffer buffer)
        {
            this.buffer = buffer;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.buffer; }
        }

        /// <summary>
        /// Gets the properties of a buffer resource.
        /// </summary>
        public D3D11BufferDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11BufferDesc desc;
                this.buffer.GetDesc(out desc);
                return desc;
            }
        }
    }
}
