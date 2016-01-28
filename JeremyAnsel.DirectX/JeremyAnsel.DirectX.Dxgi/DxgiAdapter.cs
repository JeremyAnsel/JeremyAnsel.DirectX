// <copyright file="DxgiAdapter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// The <c>IDXGIAdapter</c> interface represents a display sub-system (including one or more GPU's, DACs and video memory).
    /// </summary>
    public sealed class DxgiAdapter : DxgiObject
    {
        /// <summary>
        /// The DXGI adapter interface.
        /// </summary>
        private IDxgiAdapter adapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiAdapter"/> class.
        /// </summary>
        /// <param name="adapter">A DXGI adapter interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiAdapter(IDxgiAdapter adapter)
        {
            this.adapter = adapter;
        }

        /// <summary>
        /// Gets an handle representing the DXGI object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.adapter; }
        }

        /// <summary>
        /// Gets a DXGI 1.0 description of an adapter (or video card).
        /// </summary>
        public DxgiAdapterDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.adapter.GetDesc();
            }
        }

        /// <summary>
        /// Enumerate adapter (video card) outputs.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="DxgiOutput"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<DxgiOutput> EnumOutputs()
        {
            IDxgiOutput output;

            for (uint i = 0; !this.adapter.EnumOutputs(i, out output); i++)
            {
                yield return new DxgiOutput(output);
            }
        }

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <returns>The parent of the object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiFactory GetParent()
        {
            Guid riid = typeof(IDxgiFactory).GUID;
            return new DxgiFactory((IDxgiFactory)this.adapter.GetParent(ref riid));
        }
    }
}
