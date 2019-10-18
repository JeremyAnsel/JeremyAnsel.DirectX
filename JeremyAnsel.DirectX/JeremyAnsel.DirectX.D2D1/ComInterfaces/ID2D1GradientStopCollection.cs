// <copyright file="ID2D1GradientStopCollection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Represents an collection of <see cref="D2D1GradientStop"/> objects for linear and radial gradient brushes.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906a7-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1GradientStopCollection
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory factory);

        /// <summary>
        /// Retrieves the number of gradient stops in the collection.
        /// </summary>
        /// <returns>The number of gradient stops in the collection.</returns>
        [PreserveSig]
        uint GetGradientStopCount();

        /// <summary>
        /// Copies the gradient stops from the collection into an array of <see cref="D2D1GradientStop"/> structures.
        /// </summary>
        /// <param name="gradientStops">The collection's gradient stops.</param>
        /// <param name="gradientStopsCount">A value indicating the number of gradient stops to copy.</param>
        [PreserveSig]
        void GetGradientStops(
            [Out, MarshalAs(UnmanagedType.LPArray)] D2D1GradientStop[] gradientStops,
            [In] uint gradientStopsCount);

        /// <summary>
        /// Indicates the gamma space in which the gradient stops are interpolated.
        /// </summary>
        /// <returns>The gamma space in which the gradient stops are interpolated.</returns>
        [PreserveSig]
        D2D1Gamma GetColorInterpolationGamma();

        /// <summary>
        /// Indicates the behavior of the gradient outside the normalized gradient range.
        /// </summary>
        /// <returns>The behavior of the gradient outside the [0,1] normalized gradient range.</returns>
        [PreserveSig]
        D2D1ExtendMode GetExtendMode();
    }
}
