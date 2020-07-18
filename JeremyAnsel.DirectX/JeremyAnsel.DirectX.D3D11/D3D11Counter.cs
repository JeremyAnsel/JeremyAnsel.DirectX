// <copyright file="D3D11Counter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// This interface encapsulates methods for measuring GPU performance.
    /// </summary>
    public sealed class D3D11Counter : D3D11Asynchronous
    {
        /// <summary>
        /// The D3D11 counter interface.
        /// </summary>
        private readonly ID3D11Counter counter;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11Counter"/> class.
        /// </summary>
        /// <param name="counter">A D3D11 counter interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11Counter(ID3D11Counter counter)
        {
            this.counter = counter;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.counter; }
        }

        /// <summary>
        /// Gets a counter description.
        /// </summary>
        [SuppressMessage("Reliability", "CA2010:Toujours consommer la valeur retournée par les méthodes marquées avec PreserveSigAttribute", Justification = "Reviewed.")]
        public D3D11CounterDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.counter.GetDesc(out D3D11CounterDesc desc);
                return desc;
            }
        }
    }
}
