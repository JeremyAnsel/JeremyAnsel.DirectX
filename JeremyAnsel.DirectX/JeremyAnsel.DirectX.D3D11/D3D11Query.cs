// <copyright file="D3D11Query.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A query interface queries information from the GPU.
    /// </summary>
    public sealed class D3D11Query : D3D11Asynchronous
    {
        /// <summary>
        /// The D3D11 query interface.
        /// </summary>
        private readonly ID3D11Query query;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Query"/> class.
        /// </summary>
        /// <param name="query">A D3D11 query interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Query(ID3D11Query query)
        {
            this.query = query;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.query; }
        }

        /// <summary>
        /// Gets a query description.
        /// </summary>
        public D3D11QueryDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
            get
            {
                this.query.GetDesc(out D3D11QueryDesc desc);
                return desc;
            }
        }
    }
}
