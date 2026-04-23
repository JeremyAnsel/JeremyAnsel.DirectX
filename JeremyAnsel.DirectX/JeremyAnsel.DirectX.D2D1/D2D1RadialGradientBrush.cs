// <copyright file="D2D1RadialGradientBrush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Paints an area with a radial gradient.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1RadialGradientBrush : D2D1Brush
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1RadialGradientBrushGuid = typeof(ID2D1RadialGradientBrush).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1RadialGradientBrush* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RadialGradientBrush"/> class.
    /// </summary>
    public D2D1RadialGradientBrush(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1RadialGradientBrush**)comPtr;
    }

    /// <summary>
    /// Gets or sets the center of the gradient ellipse in the brush's coordinate space.
    /// </summary>
    public D2D1Point2F Center
    {
        get
        {
            int size = D2D1Point2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetCenter(_comPtr, ptr);
            return D2D1Point2F.NativeReadFrom((nint)ptr);
        }

        set
        {
            _comImpl->SetCenter(_comPtr, value.X, value.Y);
        }
    }

    /// <summary>
    /// Gets or sets the offset of the gradient origin relative to the gradient ellipse's center.
    /// </summary>
    public D2D1Point2F GradientOriginOffset
    {
        get
        {
            int size = D2D1Point2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetGradientOriginOffset(_comPtr, ptr);
            return D2D1Point2F.NativeReadFrom((nint)ptr);
        }

        set
        {
            _comImpl->SetGradientOriginOffset(_comPtr, value.X, value.Y);
        }
    }

    /// <summary>
    /// Gets or sets the x-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    public float RadiusX
    {
        get { return _comImpl->GetRadiusX(_comPtr); }
        set { _comImpl->SetRadiusX(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the y-radius of the gradient ellipse, in the brush's coordinate space.
    /// </summary>
    public float RadiusY
    {
        get { return _comImpl->GetRadiusY(_comPtr); }
        set { _comImpl->SetRadiusY(_comPtr, value); }
    }

    /// <summary>
    /// Retrieves the <see cref="D2D1GradientStopCollection"/> associated with this radial gradient brush object.
    /// </summary>
    /// <returns>The <see cref="D2D1GradientStopCollection"/> object associated with this linear gradient brush object.</returns>
    public D2D1GradientStopCollection GetGradientStopCollection()
    {
        nint ptr;
        _comImpl->GetGradientStopCollection(_comPtr, &ptr);
        return new D2D1GradientStopCollection(ptr);
    }
}
