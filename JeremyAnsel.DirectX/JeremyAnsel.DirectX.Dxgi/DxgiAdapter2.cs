﻿// <copyright file="DxgiAdapter2.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.Dxgi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.Dxgi.ComInterfaces;

    /// <summary>
    /// The <c>IDXGIAdapter2</c> interface represents a display sub-system, which includes one or more GPUs, DACs, and video memory.
    /// </summary>
    public sealed class DxgiAdapter2 : DxgiObject
    {
        /// <summary>
        /// The DXGI adapter interface.
        /// </summary>
        private readonly IDxgiAdapter2 adapter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DxgiAdapter2"/> class.
        /// </summary>
        /// <param name="adapter">A DXGI adapter interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal DxgiAdapter2(IDxgiAdapter2 adapter)
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
        /// Gets a DXGI 1.2 description of an adapter (or video card).
        /// </summary>
        public DxgiAdapterDesc2 Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return this.adapter.GetDesc2();
            }
        }

        /// <summary>
        /// Enumerate adapter (video card) outputs.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="DxgiOutput2"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IEnumerable<DxgiOutput2> EnumOutputs()
        {
            for (uint i = 0; !this.adapter.EnumOutputs(i, out IDxgiOutput output); i++)
            {
                yield return output == null ? null : new DxgiOutput2((IDxgiOutput1)output);
            }
        }

        /// <summary>
        /// Gets the parent of the object.
        /// </summary>
        /// <returns>The parent of the object.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DxgiFactory2 GetParent()
        {
            Guid riid = typeof(IDxgiFactory2).GUID;
            object parent = this.adapter.GetParent(ref riid);

            if (parent == null)
            {
                return null;
            }

            return new DxgiFactory2((IDxgiFactory2)parent);
        }
    }
}
