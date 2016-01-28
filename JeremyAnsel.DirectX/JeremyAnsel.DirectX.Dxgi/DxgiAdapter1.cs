// <copyright file="DxgiAdapter1.cs" company="Jérémy Ansel">
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
    /// The <c>IDXGIAdapter1</c> interface represents a display sub-system (including one or more GPU's, DACs and video memory).
    /// </summary>
    public sealed class DxgiAdapter1 : DxgiObject
    {
        /// <summary>
        /// The DXGI adapter interface.
        /// </summary>
        private IDxgiAdapter1 adapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiAdapter1"/> class.
        /// </summary>
        /// <param name="adapter">A DXGI adapter interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiAdapter1(IDxgiAdapter1 adapter)
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
        /// Gets a DXGI 1.1 description of an adapter (or video card).
        /// </summary>
        public DxgiAdapterDesc1 Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.adapter.GetDesc1();
            }
        }

        /// <summary>
        /// Enumerate adapter (video card) outputs.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="DxgiOutput"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<DxgiOutput1> EnumOutputs()
        {
            IDxgiOutput output;

            for (uint i = 0; !this.adapter.EnumOutputs(i, out output); i++)
            {
                yield return new DxgiOutput1(output);
            }
        }

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <returns>The parent of the object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiFactory1 GetParent()
        {
            Guid riid = typeof(IDxgiFactory1).GUID;
            return new DxgiFactory1((IDxgiFactory1)this.adapter.GetParent(ref riid));
        }
    }
}
