// <copyright file="D2D1GradientStopCollection.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents an collection of <see cref="D2D1GradientStop"/> objects for linear and radial gradient brushes.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1GradientStopCollection : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1GradientStopCollectionGuid = typeof(ID2D1GradientStopCollection).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1GradientStopCollection* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1GradientStopCollection"/> class.
    /// </summary>
    public D2D1GradientStopCollection(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1GradientStopCollection**)comPtr;
    }

    /// <summary>
    /// Gets the gamma space in which the gradient stops are interpolated.
    /// </summary>
    public D2D1Gamma ColorInterpolationGamma
    {
        get { return _comImpl->GetColorInterpolationGamma(_comPtr); }
    }

    /// <summary>
    /// Gets the behavior of the gradient outside the normalized gradient range.
    /// </summary>
    public D2D1ExtendMode ExtendMode
    {
        get { return _comImpl->GetExtendMode(_comPtr); }
    }

    /// <summary>
    /// Retrieves the number of gradient stops in the collection.
    /// </summary>
    /// <returns>The number of gradient stops in the collection.</returns>
    public uint GetGradientStopCount()
    {
        return _comImpl->GetGradientStopCount(_comPtr);
    }

    /// <summary>
    /// Copies the gradient stops from the collection into an array of <see cref="D2D1GradientStop"/> structures.
    /// </summary>
    /// <returns>The collection's gradient stops.</returns>
    public D2D1GradientStop[] GetGradientStops()
    {
        uint count = GetGradientStopCount();
        D2D1GradientStop[] gradientStops = new D2D1GradientStop[count];
        GetGradientStops(gradientStops.AsSpan());
        return gradientStops;
    }

    /// <summary>
    /// Copies the gradient stops from the collection into an array of <see cref="D2D1GradientStop"/> structures.
    /// </summary>
    /// <param name="gradientStops">The collection's gradient stops.</param>
    public void GetGradientStops(Span<D2D1GradientStop> gradientStops)
    {
        int size = D2D1GradientStop.NativeRequiredSize(gradientStops.Length);
        byte* ptr = stackalloc byte[size];
        _comImpl->GetGradientStops(_comPtr, ptr, (uint)gradientStops.Length);
        D2D1GradientStop.NativeReadFrom((nint)ptr, gradientStops);
    }
}
