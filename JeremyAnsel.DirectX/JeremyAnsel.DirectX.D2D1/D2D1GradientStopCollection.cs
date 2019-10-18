// <copyright file="D2D1GradientStopCollection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents an collection of <see cref="D2D1GradientStop"/> objects for linear and radial gradient brushes.
    /// </summary>
    public sealed class D2D1GradientStopCollection : D2D1Resource
    {
        /// <summary>
        /// The D2D1 gradient stop collection interface.
        /// </summary>
        private ID2D1GradientStopCollection gradientStopCollection;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1GradientStopCollection"/> class.
        /// </summary>
        /// <param name="gradientStopCollection">A D2D1 gradient stop collection interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1GradientStopCollection(ID2D1GradientStopCollection gradientStopCollection)
        {
            this.gradientStopCollection = gradientStopCollection;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.gradientStopCollection; }
        }

        /// <summary>
        /// Gets the gamma space in which the gradient stops are interpolated.
        /// </summary>
        public D2D1Gamma ColorInterpolationGamma
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.gradientStopCollection.GetColorInterpolationGamma(); }
        }

        /// <summary>
        /// Gets the behavior of the gradient outside the normalized gradient range.
        /// </summary>
        public D2D1ExtendMode ExtendMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.gradientStopCollection.GetExtendMode(); }
        }

        /// <summary>
        /// Retrieves the number of gradient stops in the collection.
        /// </summary>
        /// <returns>The number of gradient stops in the collection.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetGradientStopCount()
        {
            return this.gradientStopCollection.GetGradientStopCount();
        }

        /// <summary>
        /// Copies the gradient stops from the collection into an array of <see cref="D2D1GradientStop"/> structures.
        /// </summary>
        /// <returns>The collection's gradient stops.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GradientStop[] GetGradientStops()
        {
            uint count = this.gradientStopCollection.GetGradientStopCount();

            D2D1GradientStop[] gradientStops = new D2D1GradientStop[count];
            this.gradientStopCollection.GetGradientStops(gradientStops, count);

            return gradientStops;
        }
    }
}
