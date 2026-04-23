// <copyright file="ID2D1GeometryGroup.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents a composite geometry, composed of other <see cref="ID2D1Geometry"/> objects.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Geometry"/></remarks>
[Guid("2cd906a6-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1GeometryGroup
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;
    private readonly nint GetBounds;
    private readonly nint GetWidenedBounds;
    private readonly nint StrokeContainsPoint;
    private readonly nint FillContainsPoint;
    private readonly nint CompareWithGeometry;
    private readonly nint Simplify;
    private readonly nint Tessellate;
    private readonly nint CombineWithGeometry;
    private readonly nint Outline;
    private readonly nint ComputeArea;
    private readonly nint ComputeLength;
    private readonly nint ComputePointAtLength;
    private readonly nint Widen;

    /// <summary>
    /// Indicates how the intersecting areas of the geometries contained in this geometry group are combined.
    /// </summary>
    /// <returns>A value that indicates how the intersecting areas of the geometries contained in this geometry group are combined.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1FillMode> GetFillMode;

    /// <summary>
    /// Indicates the number of geometry objects in the geometry group.
    /// </summary>
    /// <returns>The number of geometries in the <see cref="ID2D1GeometryGroup"/>.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetSourceGeometryCount;

    /// <summary>
    /// Retrieves the geometries in the geometry group.
    /// </summary>
    /// <param name="geometries">An array of geometries to be filled by this method. The length of the array is specified by the geometryCount parameter.</param>
    /// <param name="geometriesCount">A value indicating the number of geometries to return in the geometries array. If this value is less than the number of geometries in the geometry group, the remaining geometries are omitted. If this value is larger than the number of geometries in the geometry group, the extra geometries are set to NULL.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, uint, void> GetSourceGeometries;
}
