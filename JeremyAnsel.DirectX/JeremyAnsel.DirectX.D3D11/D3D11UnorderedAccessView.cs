// <copyright file="D3D11UnorderedAccessView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D3D11
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D3D11.ComInterfaces;

    /// <summary>
    /// A view interface specifies the parts of a resource the pipeline can access during rendering.
    /// </summary>
    public sealed class D3D11UnorderedAccessView : D3D11View
    {
        /// <summary>
        /// The D3D11 unordered access view interface.
        /// </summary>
        private ID3D11UnorderedAccessView unorderedAccessView;

        /// <summary>
        /// Initializes a new instance of the <see cref="D3D11UnorderedAccessView"/> class.
        /// </summary>
        /// <param name="unorderedAccessView">A D3D11 unordered access view interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D3D11UnorderedAccessView(ID3D11UnorderedAccessView unorderedAccessView)
        {
            this.unorderedAccessView = unorderedAccessView;
        }

        /// <summary>
        /// Gets an handle representing the D3D11 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.unorderedAccessView; }
        }

        /// <summary>
        /// Gets a description of the resource.
        /// </summary>
        public D3D11UnorderedAccessViewDesc Description
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                D3D11UnorderedAccessViewDesc desc;
                this.unorderedAccessView.GetDesc(out desc);
                return desc;
            }
        }
    }
}
