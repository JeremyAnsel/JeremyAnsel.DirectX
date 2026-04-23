// <copyright file="D2D1RoundedRectangleGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Describes a rounded rectangle.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1RoundedRectangleGeometry : D2D1Geometry
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1RoundedRectangleGeometryGuid = typeof(ID2D1RoundedRectangleGeometry).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1RoundedRectangleGeometry* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1RoundedRectangleGeometry"/> class.
    /// </summary>
    public D2D1RoundedRectangleGeometry(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1RoundedRectangleGeometry**)comPtr;
    }

    /// <summary>
    /// Gets a rounded rectangle that describes this rounded rectangle geometry.
    /// </summary>
    public D2D1RoundedRect RoundedRect
    {
        get
        {
            int size = D2D1RoundedRect.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetRoundedRect(_comPtr, ptr);
            return D2D1RoundedRect.NativeReadFrom((nint)ptr);
        }
    }
}
