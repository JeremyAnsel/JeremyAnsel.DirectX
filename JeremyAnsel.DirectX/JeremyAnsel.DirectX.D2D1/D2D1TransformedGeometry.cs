// <copyright file="D2D1TransformedGeometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a geometry that has been transformed.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1TransformedGeometry : D2D1Geometry
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1TransformedGeometryGuid = typeof(ID2D1TransformedGeometry).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1TransformedGeometry* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1TransformedGeometry"/> class.
    /// </summary>
    public D2D1TransformedGeometry(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1TransformedGeometry**)comPtr;
    }

    /// <summary>
    /// Gets the source geometry of this transformed geometry object.
    /// </summary>
    public D2D1Geometry SourceGeometry
    {
        get
        {
            nint ptr;
            _comImpl->GetSourceGeometry(_comPtr, &ptr);
            return new D2D1Geometry(ptr);
        }
    }

    /// <summary>
    /// Gets the matrix used to transform the <see cref="D2D1TransformedGeometry"/> object's source geometry.
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
    }
}
