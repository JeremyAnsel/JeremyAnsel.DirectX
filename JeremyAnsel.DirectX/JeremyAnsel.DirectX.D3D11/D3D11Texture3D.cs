﻿// <copyright file="D3D11Texture3D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A 3D texture interface accesses texel data, which is structured memory.
    /// </summary>
    public sealed class D3D11Texture3D : D3D11Resource
    {
        /// <summary>
        /// The D3D11 texture 3D interface.
        /// </summary>
        private readonly ID3D11Texture3D texture3D;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Texture3D"/> class.
        /// </summary>
        /// <param name="texture3D">A D3D11 texture 3D interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Texture3D(ID3D11Texture3D texture3D)
        {
            this.texture3D = texture3D;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.texture3D; }
        }

        /// <summary>
        /// Gets the properties of the texture resource.
        /// </summary>
        public D3D11Texture3DDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.texture3D.GetDesc(out D3D11Texture3DDesc desc);
                return desc;
            }
        }
    }
}
