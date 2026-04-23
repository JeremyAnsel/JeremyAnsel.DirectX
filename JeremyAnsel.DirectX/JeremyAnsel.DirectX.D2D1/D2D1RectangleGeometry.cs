// <copyright file="D2D1RectangleGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes a two-dimensional rectangle.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1RectangleGeometry : D2D1Geometry
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1RectangleGeometryGuid = typeof(ID2D1RectangleGeometry).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1RectangleGeometry* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RectangleGeometry"/> class.
    /// </summary>
    public D2D1RectangleGeometry(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1RectangleGeometry**)comPtr;
    }

    /// <summary>
    /// Gets the rectangle that describes the rectangle geometry's dimensions.
    /// </summary>
    public D2D1RectF Rect
    {
        get
        {
            int size = D2D1RectF.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetRect(_comPtr, ptr);
            return D2D1RectF.NativeReadFrom((nint)ptr);
        }
    }
}
