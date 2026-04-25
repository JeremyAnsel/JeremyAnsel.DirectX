// <copyright file="ID2D1Geometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents a geometry resource and defines a set of helper methods for manipulating and measuring geometric shapes. Interfaces that inherit from <see cref="ID2D1Geometry"/> define specific shapes.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd906a1-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1Geometry
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Retrieves the bounds of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry before calculating its bounds, or NULL.</param>
    /// <param name="bounds">The bounds of this geometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void*, int> GetBounds;

    /// <summary>
    /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
    /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
    /// <param name="worldTransform">A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more accurate results but cause slower execution.</param>
    /// <param name="bounds">The bounds of the widened geometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, nint, void*, float, void*, int> GetWidenedBounds;

    /// <summary>
    /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
    /// </summary>
    /// <param name="point">The point to test for containment.</param>
    /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
    /// <param name="strokeStyle">The style of stroke to apply.</param>
    /// <param name="worldTransform">The transform to apply to the stroked geometry.</param>
    /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the stroke by less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.</param>
    /// <param name="contains">A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, float, nint, void*, float, int*, int> StrokeContainsPoint;

    /// <summary>
    /// Indicates whether the area filled by the geometry would contain the specified point.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <param name="worldTransform">The transform to apply to the geometry prior to testing for containment.</param>
    /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less than the tolerance are still considered inside.</param>
    /// <param name="contains">When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1Point2F, void*, float, int*, int> FillContainsPoint;

    /// <summary>
    /// Describes the intersection between this geometry and the specified geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to test.</param>
    /// <param name="inputGeometryTransform">The transform to apply to inputGeometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="relation">A value that describes how this geometry is related to inputGeometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, void*, float, D2D1GeometryRelation*, int> CompareWithGeometry;

    /// <summary>
    /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="ID2D1SimplifiedGeometrySink"/>.
    /// </summary>
    /// <param name="simplificationOptions">A value that specifies whether the simplified geometry should contain curves.</param>
    /// <param name="worldTransform">The transform to apply to the simplified geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="ID2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D2D1GeometrySimplificationOption, void*, float, nint, int> Simplify;

    /// <summary>
    /// Tessellates a geometry into triangles.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="tessellationSink">The <see cref="ID2D1TessellationSink"/> to which the tessellated is appended.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, float, nint, int> Tessellate;

    /// <summary>
    /// Performs a combine operation between the two geometries to produce a resulting
    /// geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to combine with this instance.</param>
    /// <param name="combineMode">The type of combine operation to perform.</param>
    /// <param name="inputGeometryTransform">The transform to apply to inputGeometry before combining.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The result of the combine operation.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, D2D1CombineMode, void*, float, nint, int> CombineWithGeometry;

    /// <summary>
    /// Computes the outline of the geometry. The result is written back into a
    /// simplified geometry sink.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to the geometry outline.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="ID2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, float, nint, int> Outline;

    /// <summary>
    /// Computes the area of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry before computing its area.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="area">The area of the transformed, flattened version of this geometry.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, float, float*, int> ComputeArea;

    /// <summary>
    /// Computes the length of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to the geometry before calculating its length.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="length">The length of the geometry. For closed geometries, the length includes an implicit closing segment.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, float, float*, int> ComputeLength;

    /// <summary>
    /// Computes the point and tangent a given distance along the path.
    /// </summary>
    /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
    /// <param name="worldTransform">The transform to apply to the geometry before calculating the specified point and tangent.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
    /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, void*, float, void*, void*, int> ComputePointAtLength;

    /// <summary>
    /// Get the geometry and widen it as well as apply an optional pen style.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
    /// <param name="worldTransform">The transform to apply to the geometry after widening it.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="ID2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, float, nint, void*, float, nint, int> Widen;
}
