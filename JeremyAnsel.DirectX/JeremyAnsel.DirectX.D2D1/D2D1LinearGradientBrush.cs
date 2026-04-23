// <copyright file="D2D1LinearGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Paints an area with a linear gradient.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1LinearGradientBrush : D2D1Brush
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1LinearGradientBrushGuid = typeof(ID2D1LinearGradientBrush).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1LinearGradientBrush* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1LinearGradientBrush"/> class.
    /// </summary>
    public D2D1LinearGradientBrush(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1LinearGradientBrush**)comPtr;
    }

    /// <summary>
    /// Gets or sets the starting coordinates of the linear gradient in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F StartPoint
    {
        get
        {
            int size = D2D1Point2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetStartPoint(_comPtr, ptr);
            return D2D1Point2F.NativeReadFrom((nint)ptr);
        }

        set
        {
            _comImpl->SetStartPoint(_comPtr, value.X, value.Y);
        }
    }

    /// <summary>
    /// Gets or sets the ending coordinates of the linear gradient in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F EndPoint
    {
        get
        {
            int size = D2D1Point2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetEndPoint(_comPtr, ptr);
            return D2D1Point2F.NativeReadFrom((nint)ptr);
        }

        set
        {
            _comImpl->SetEndPoint(_comPtr, value.X, value.Y);
        }
    }

    /// <summary>
    /// Retrieves the <see cref="D2D1GradientStopCollection"/> associated with this linear gradient brush.
    /// </summary>
    /// <returns>The <see cref="D2D1GradientStopCollection"/> object associated with this linear gradient brush object.</returns>
    public D2D1GradientStopCollection GetGradientStopCollection()
    {
        nint ptr;
        _comImpl->GetGradientStopCollection(_comPtr, &ptr);
        return new D2D1GradientStopCollection(ptr);
    }
}
