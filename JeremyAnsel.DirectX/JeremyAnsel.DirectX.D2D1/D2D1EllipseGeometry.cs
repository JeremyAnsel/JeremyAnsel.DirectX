// <copyright file="D2D1EllipseGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents an ellipse.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1EllipseGeometry : D2D1Geometry
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1EllipseGeometryGuid = typeof(ID2D1EllipseGeometry).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1EllipseGeometry* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1EllipseGeometry"/> class.
    /// </summary>
    public D2D1EllipseGeometry(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1EllipseGeometry**)comPtr;
    }

    /// <summary>
    /// Gets the <see cref="D2D1Ellipse"/> structure that describes this ellipse geometry.
    /// </summary>
    public D2D1Ellipse Ellipse
    {
        get
        {
            int size = D2D1Ellipse.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetEllipse(_comPtr, ptr);
            return D2D1Ellipse.NativeReadFrom((nint)ptr);
        }
    }
}
