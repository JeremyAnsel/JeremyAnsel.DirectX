// <copyright file="D2D1GeometryGroup.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a composite geometry, composed of other <see cref="D2D1Geometry"/> objects.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1GeometryGroup : D2D1Geometry
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1GeometryGroupGuid = typeof(ID2D1GeometryGroup).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1GeometryGroup* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1GeometryGroup"/> class.
    /// </summary>
    public D2D1GeometryGroup(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1GeometryGroup**)comPtr;
    }

    /// <summary>
    /// Gets a value indicating how the intersecting areas of the geometries contained in this geometry group are combined.
    /// </summary>
    public D2D1FillMode FillMode
    {
        get { return _comImpl->GetFillMode(_comPtr); }
    }

    /// <summary>
    /// Gets the number of geometry objects in the geometry group.
    /// </summary>
    /// <returns>The number of geometries in the geometry group.</returns>
    public uint GetSourceGeometryCount()
    {
        return this._comImpl->GetSourceGeometryCount(_comPtr);
    }

    /// <summary>
    /// Retrieves the geometries in the geometry group.
    /// </summary>
    /// <returns>An array of geometries to be filled by this method.</returns>
    public D2D1Geometry[] GetSourceGeometries()
    {
        uint count = GetSourceGeometryCount();
        D2D1Geometry[] geometries = new D2D1Geometry[count];
        GetSourceGeometries(geometries.AsSpan());
        return geometries;
    }

    /// <summary>
    /// Retrieves the geometries in the geometry group.
    /// </summary>
    /// <param name="geometries">An array of geometries to be filled by this method.</param>
    public void GetSourceGeometries(Span<D2D1Geometry> geometries)
    {
        nint* ptr = stackalloc nint[geometries.Length];
        _comImpl->GetSourceGeometries(_comPtr, ptr, (uint)geometries.Length);
        for (int i = 0; i < geometries.Length; i++)
        {
            geometries[i] = new D2D1Geometry(ptr[i]);
        }
    }
}
