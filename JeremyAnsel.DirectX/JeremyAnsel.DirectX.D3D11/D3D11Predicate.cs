// <copyright file="D3D11Predicate.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A predicate interface determines whether geometry should be processed depending on the results of a previous draw call.
    /// </summary>
    public sealed class D3D11Predicate : D3D11Asynchronous
    {
        /// <summary>
        /// The D3D11 predicate interface.
        /// </summary>
        private readonly ID3D11Predicate predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Predicate"/> class.
        /// </summary>
        /// <param name="predicate">A D3D11 predicate interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Predicate(ID3D11Predicate predicate)
        {
            this.predicate = predicate;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.predicate; }
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
                this.predicate.GetDesc(out D3D11QueryDesc desc);
                return desc;
            }
        }
    }
}
