// <copyright file="D2D1Layer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents the backing store required to render a layer.
    /// </summary>
    public sealed class D2D1Layer : D2D1Resource
    {
        /// <summary>
        /// The D2D1 layer interface.
        /// </summary>
        private readonly ID2D1Layer layer;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Layer"/> class.
        /// </summary>
        /// <param name="layer">A D2D1 layer interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Layer(ID2D1Layer layer)
        {
            this.layer = layer;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.layer; }
        }

        /// <summary>
        /// Gets the size of the layer in device-independent pixels.
        /// </summary>
        public D2D1SizeF Size
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                this.layer.GetSize(out D2D1SizeF size);
                return size;
            }
        }
    }
}
