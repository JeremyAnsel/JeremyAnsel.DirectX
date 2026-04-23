// <copyright file="D2D1Brush.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// The root brush interface. All brushes can be used to fill or pen a geometry.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Brush : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1BrushGuid = typeof(ID2D1Brush).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Brush* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Brush"/> class.
    /// </summary>
    public D2D1Brush(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Brush**)comPtr;
    }

    /// <summary>
    /// Gets or sets the degree of opacity of this brush.
    /// </summary>
    public float Opacity
    {
        get { return _comImpl->GetOpacity(_comPtr); }
        set { _comImpl->SetOpacity(_comPtr, value); }
    }

    /// <summary>
    /// Gets or sets the transform applied to this brush.
    /// </summary>
    public D2D1Matrix3X2F Transform
    {
        get
        {
            int size = D2D1Matrix3X2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetTransform(_comPtr, ptr);
            return D2D1Matrix3X2F.NativeReadFrom((nint)ptr);
        }

        set
        {
            int size = D2D1Matrix3X2F.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            D2D1Matrix3X2F.NativeWriteTo((nint)ptr, value);
            _comImpl->SetTransform(_comPtr, ptr);
        }
    }
}
