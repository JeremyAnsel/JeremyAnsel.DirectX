// <copyright file="ID2D1GeometryGroup.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Represents a composite geometry, composed of other <see cref="ID2D1Geometry"/> objects.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Geometry"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906a6-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1GeometryGroup
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory? factory);

        /// <summary>
        /// RRetrieves the bounds of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry before calculating its bounds, or NULL.</param>
        /// <param name="bounds">The bounds of this geometry.</param>
        void GetBounds(
            [In] IntPtr worldTransform,
            [Out] out D2D1RectF bounds);

        /// <summary>
        /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
        /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
        /// <param name="worldTransform">A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more accurate results but cause slower execution.</param>
        /// <param name="bounds">The bounds of the widened geometry.</param>
        void GetWidenedBounds(
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle? strokeStyle,
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [Out] out D2D1RectF bounds);

        /// <summary>
        /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
        /// </summary>
        /// <param name="point">The point to test for containment.</param>
        /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
        /// <param name="strokeStyle">The style of stroke to apply.</param>
        /// <param name="worldTransform">The transform to apply to the stroked geometry.</param>
        /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the stroke by less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.</param>
        /// <param name="contains">A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</param>
        void StrokeContainsPoint(
            [In] D2D1Point2F point,
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle? strokeStyle,
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool contains);

        /// <summary>
        /// Indicates whether the area filled by the geometry would contain the specified point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <param name="worldTransform">The transform to apply to the geometry prior to testing for containment.</param>
        /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less than the tolerance are still considered inside.</param>
        /// <param name="contains">When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</param>
        void FillContainsPoint(
            [In] D2D1Point2F point,
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [Out, MarshalAs(UnmanagedType.Bool)] out bool contains);

        /// <summary>
        /// Describes the intersection between this geometry and the specified geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to test.</param>
        /// <param name="inputGeometryTransform">The transform to apply to inputGeometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="relation">A value that describes how this geometry is related to inputGeometry.</param>
        void CompareWithGeometry(
            [In] ID2D1Geometry? inputGeometry,
            [In] IntPtr inputGeometryTransform,
            [In] float flatteningTolerance,
            [Out] out D2D1GeometryRelation relation);

        /// <summary>
        /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="ID2D1SimplifiedGeometrySink"/>.
        /// </summary>
        /// <param name="simplificationOptions">A value that specifies whether the simplified geometry should contain curves.</param>
        /// <param name="worldTransform">The transform to apply to the simplified geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="ID2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
        void Simplify(
            [In] D2D1GeometrySimplificationOption simplificationOptions,
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [In] ID2D1SimplifiedGeometrySink? geometrySink);

        /// <summary>
        /// Tessellates a geometry into triangles.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="tessellationSink">The <see cref="ID2D1TessellationSink"/> to which the tessellated is appended.</param>
        void Tessellate(
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [In] ID2D1TessellationSink? tessellationSink);

        /// <summary>
        /// Performs a combine operation between the two geometries to produce a resulting
        /// geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to combine with this instance.</param>
        /// <param name="combineMode">The type of combine operation to perform.</param>
        /// <param name="inputGeometryTransform">The transform to apply to inputGeometry before combining.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The result of the combine operation.</param>
        void CombineWithGeometry(
            [In] ID2D1Geometry? inputGeometry,
            [In] D2D1CombineMode combineMode,
            [In] IntPtr inputGeometryTransform,
            [In] float flatteningTolerance,
            [In] ID2D1SimplifiedGeometrySink? geometrySink);

        /// <summary>
        /// Computes the outline of the geometry. The result is written back into a
        /// simplified geometry sink.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to the geometry outline.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="ID2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
        void Outline(
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [In] ID2D1SimplifiedGeometrySink? geometrySink);

        /// <summary>
        /// Computes the area of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry before computing its area.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="area">The area of the transformed, flattened version of this geometry.</param>
        void ComputeArea(
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [Out] out float area);

        /// <summary>
        /// Computes the length of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to the geometry before calculating its length.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="length">The length of the geometry. For closed geometries, the length includes an implicit closing segment.</param>
        void ComputeLength(
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [Out] out float length);

        /// <summary>
        /// Computes the point and tangent a given distance along the path.
        /// </summary>
        /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
        /// <param name="worldTransform">The transform to apply to the geometry before calculating the specified point and tangent.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
        /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
        void ComputePointAtLength(
            [In] float length,
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [Out] out D2D1Point2F point,
            [Out] out D2D1Point2F unitTangentVector);

        /// <summary>
        /// Get the geometry and widen it as well as apply an optional pen style.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
        /// <param name="worldTransform">The transform to apply to the geometry after widening it.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="ID2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
        void Widen(
            [In] float strokeWidth,
            [In] ID2D1StrokeStyle? strokeStyle,
            [In] IntPtr worldTransform,
            [In] float flatteningTolerance,
            [In] ID2D1SimplifiedGeometrySink? geometrySink);

        /// <summary>
        /// Indicates how the intersecting areas of the geometries contained in this geometry group are combined.
        /// </summary>
        /// <returns>A value that indicates how the intersecting areas of the geometries contained in this geometry group are combined.</returns>
        [PreserveSig]
        D2D1FillMode GetFillMode();

        /// <summary>
        /// Indicates the number of geometry objects in the geometry group.
        /// </summary>
        /// <returns>The number of geometries in the <see cref="ID2D1GeometryGroup"/>.</returns>
        [PreserveSig]
        uint GetSourceGeometryCount();

        /// <summary>
        /// Retrieves the geometries in the geometry group.
        /// </summary>
        /// <param name="geometries">An array of geometries to be filled by this method. The length of the array is specified by the geometryCount parameter.</param>
        /// <param name="geometriesCount">A value indicating the number of geometries to return in the geometries array. If this value is less than the number of geometries in the geometry group, the remaining geometries are omitted. If this value is larger than the number of geometries in the geometry group, the extra geometries are set to NULL.</param>
        [PreserveSig]
        void GetSourceGeometries(
            [Out, MarshalAs(UnmanagedType.LPArray)] ID2D1Geometry[]? geometries,
            [In] uint geometriesCount);
    }
}
