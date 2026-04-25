// <copyright file="D2D1Geometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a geometry resource and defines a set of helper methods for manipulating and measuring geometric shapes.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Geometry : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1GeometryGuid = typeof(ID2D1Geometry).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Geometry* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Geometry"/> class.
    /// </summary>
    public D2D1Geometry(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Geometry**)comPtr;
    }

    /// <summary>
    /// Retrieves the bounds of the geometry.
    /// </summary>
    /// <returns>The bounds of this geometry.</returns>
    public D2D1RectF GetBounds()
    {
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetBounds(_comPtr, null, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return D2D1RectF.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Retrieves the bounds of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry before calculating its bounds, or NULL.</param>
    /// <returns>The bounds of this geometry.</returns>
    public D2D1RectF GetBounds(in D2D1Matrix3X2F worldTransform)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        int hr = _comImpl->GetBounds(_comPtr, worldTransformPtr, ptr);
        Marshal.ThrowExceptionForHR(hr);
        return D2D1RectF.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
    /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more accurate results but cause slower execution.</param>
    /// <returns>The bounds of the widened geometry.</returns>
    public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle? strokeStyle, float flatteningTolerance)
    {
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->GetWidenedBounds(_comPtr, strokeWidth, strokeStylePtr, null, flatteningTolerance, ptr);
        return D2D1RectF.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
    /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
    /// <param name="worldTransform">A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more accurate results but cause slower execution.</param>
    /// <returns>The bounds of the widened geometry.</returns>
    public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle? strokeStyle, in D2D1Matrix3X2F worldTransform, float flatteningTolerance)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->GetWidenedBounds(_comPtr, strokeWidth, strokeStylePtr, worldTransformPtr, flatteningTolerance, ptr);
        return D2D1RectF.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
    /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
    /// <returns>The bounds of the widened geometry.</returns>
    public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->GetWidenedBounds(_comPtr, strokeWidth, strokeStylePtr, null, D2D1Constants.DefaultFlatteningTolerance, ptr);
        return D2D1RectF.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
    /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
    /// <param name="worldTransform">A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked.</param>
    /// <returns>The bounds of the widened geometry.</returns>
    public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle? strokeStyle, in D2D1Matrix3X2F worldTransform)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int size = D2D1RectF.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->GetWidenedBounds(_comPtr, strokeWidth, strokeStylePtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, ptr);
        return D2D1RectF.NativeReadFrom((nint)ptr);
    }

    /// <summary>
    /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
    /// </summary>
    /// <param name="point">The point to test for containment.</param>
    /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
    /// <param name="strokeStyle">The style of stroke to apply.</param>
    /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the stroke by less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.</param>
    /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
    public bool StrokeContainsPoint(in D2D1Point2F point, float strokeWidth, D2D1StrokeStyle? strokeStyle, float flatteningTolerance)
    {
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int ptr;
        int hr = _comImpl->StrokeContainsPoint(_comPtr, point, strokeWidth, strokeStylePtr, null, flatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
    /// </summary>
    /// <param name="point">The point to test for containment.</param>
    /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
    /// <param name="strokeStyle">The style of stroke to apply.</param>
    /// <param name="worldTransform">The transform to apply to the stroked geometry.</param>
    /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the stroke by less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.</param>
    /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
    public bool StrokeContainsPoint(in D2D1Point2F point, float strokeWidth, D2D1StrokeStyle? strokeStyle, in D2D1Matrix3X2F worldTransform, float flatteningTolerance)
    {
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int ptr;
        int hr = _comImpl->StrokeContainsPoint(_comPtr, point, strokeWidth, strokeStylePtr, worldTransformPtr, flatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
    /// </summary>
    /// <param name="point">The point to test for containment.</param>
    /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
    /// <param name="strokeStyle">The style of stroke to apply.</param>
    /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
    public bool StrokeContainsPoint(in D2D1Point2F point, float strokeWidth, D2D1StrokeStyle? strokeStyle)
    {
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int ptr;
        int hr = _comImpl->StrokeContainsPoint(_comPtr, point, strokeWidth, strokeStylePtr, null, D2D1Constants.DefaultFlatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
    /// </summary>
    /// <param name="point">The point to test for containment.</param>
    /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
    /// <param name="strokeStyle">The style of stroke to apply.</param>
    /// <param name="worldTransform">The transform to apply to the stroked geometry.</param>
    /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
    public bool StrokeContainsPoint(in D2D1Point2F point, float strokeWidth, D2D1StrokeStyle? strokeStyle, in D2D1Matrix3X2F worldTransform)
    {
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int ptr;
        int hr = _comImpl->StrokeContainsPoint(_comPtr, point, strokeWidth, strokeStylePtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Indicates whether the area filled by the geometry would contain the specified point.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less than the tolerance are still considered inside.</param>
    /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
    public bool FillContainsPoint(in D2D1Point2F point, float flatteningTolerance)
    {
        int ptr;
        int hr = _comImpl->FillContainsPoint(_comPtr, point, null, flatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Indicates whether the area filled by the geometry would contain the specified point.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <param name="worldTransform">The transform to apply to the geometry prior to testing for containment.</param>
    /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less than the tolerance are still considered inside.</param>
    /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
    public bool FillContainsPoint(in D2D1Point2F point, in D2D1Matrix3X2F worldTransform, float flatteningTolerance)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int ptr;
        int hr = _comImpl->FillContainsPoint(_comPtr, point, worldTransformPtr, flatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Indicates whether the area filled by the geometry would contain the specified point.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
    public bool FillContainsPoint(in D2D1Point2F point)
    {
        int ptr;
        int hr = _comImpl->FillContainsPoint(_comPtr, point, null, D2D1Constants.DefaultFlatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Indicates whether the area filled by the geometry would contain the specified point.
    /// </summary>
    /// <param name="point">The point to test.</param>
    /// <param name="worldTransform">The transform to apply to the geometry prior to testing for containment.</param>
    /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
    public bool FillContainsPoint(in D2D1Point2F point, in D2D1Matrix3X2F worldTransform)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int ptr;
        int hr = _comImpl->FillContainsPoint(_comPtr, point, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr != 0;
    }

    /// <summary>
    /// Describes the intersection between this geometry and the specified geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to test.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
    public D2D1GeometryRelation CompareWithGeometry(D2D1Geometry? inputGeometry, float flatteningTolerance)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        D2D1GeometryRelation relation;
        int hr = _comImpl->CompareWithGeometry(_comPtr, inputGeometry.Handle, null, flatteningTolerance, &relation);
        Marshal.ThrowExceptionForHR(hr);
        return relation;
    }

    /// <summary>
    /// Describes the intersection between this geometry and the specified geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to test.</param>
    /// <param name="inputGeometryTransform">The transform to apply to inputGeometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
    public D2D1GeometryRelation? CompareWithGeometry(D2D1Geometry? inputGeometry, in D2D1Matrix3X2F inputGeometryTransform, float flatteningTolerance)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        int size = D2D1Matrix3X2F.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1Matrix3X2F.NativeWriteTo((nint)ptr, inputGeometryTransform);
        D2D1GeometryRelation relation;
        int hr = _comImpl->CompareWithGeometry(_comPtr, inputGeometry.Handle, ptr, flatteningTolerance, &relation);
        Marshal.ThrowExceptionForHR(hr);
        return relation;
    }

    /// <summary>
    /// Describes the intersection between this geometry and the specified geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to test.</param>
    /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
    public D2D1GeometryRelation CompareWithGeometry(D2D1Geometry? inputGeometry)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        D2D1GeometryRelation relation;
        int hr = _comImpl->CompareWithGeometry(_comPtr, inputGeometry.Handle, null, D2D1Constants.DefaultFlatteningTolerance, &relation);
        Marshal.ThrowExceptionForHR(hr);
        return relation;
    }

    /// <summary>
    /// Describes the intersection between this geometry and the specified geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to test.</param>
    /// <param name="inputGeometryTransform">The transform to apply to inputGeometry.</param>
    /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
    public D2D1GeometryRelation? CompareWithGeometry(D2D1Geometry? inputGeometry, in D2D1Matrix3X2F inputGeometryTransform)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        int size = D2D1Matrix3X2F.NativeRequiredSize();
        byte* ptr = stackalloc byte[size];
        D2D1Matrix3X2F.NativeWriteTo((nint)ptr, inputGeometryTransform);
        D2D1GeometryRelation relation;
        int hr = _comImpl->CompareWithGeometry(_comPtr, inputGeometry.Handle, ptr, D2D1Constants.DefaultFlatteningTolerance, &relation);
        Marshal.ThrowExceptionForHR(hr);
        return relation;
    }

    /// <summary>
    /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
    /// </summary>
    /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Simplify(D2D1GeometrySimplificationOption simplificationOption, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->Simplify(_comPtr, simplificationOption, null, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
    /// </summary>
    /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
    /// <param name="worldTransform">The transform to apply to the simplified geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
    public void Simplify(D2D1GeometrySimplificationOption simplificationOption, in D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int hr = _comImpl->Simplify(_comPtr, simplificationOption, worldTransformPtr, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
    /// </summary>
    /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
    public void Simplify(D2D1GeometrySimplificationOption simplificationOption, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->Simplify(_comPtr, simplificationOption, null, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
    /// </summary>
    /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
    /// <param name="worldTransform">The transform to apply to the simplified geometry.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
    public void Simplify(D2D1GeometrySimplificationOption simplificationOption, in D2D1Matrix3X2F worldTransform, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int hr = _comImpl->Simplify(_comPtr, simplificationOption, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Tessellates a geometry into triangles.
    /// </summary>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
    public void Tessellate(float flatteningTolerance, D2D1TessellationSink? tessellationSink)
    {
        if (tessellationSink is null)
        {
            throw new ArgumentNullException(nameof(tessellationSink));
        }

        int hr = _comImpl->Tessellate(_comPtr, null, flatteningTolerance, tessellationSink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Tessellates a geometry into triangles.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
    public void Tessellate(in D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1TessellationSink? tessellationSink)
    {
        if (tessellationSink is null)
        {
            throw new ArgumentNullException(nameof(tessellationSink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int hr = _comImpl->Tessellate(_comPtr, worldTransformPtr, flatteningTolerance, tessellationSink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Tessellates a geometry into triangles.
    /// </summary>
    /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
    public void Tessellate(D2D1TessellationSink? tessellationSink)
    {
        if (tessellationSink is null)
        {
            throw new ArgumentNullException(nameof(tessellationSink));
        }

        int hr = _comImpl->Tessellate(_comPtr, null, D2D1Constants.DefaultFlatteningTolerance, tessellationSink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Tessellates a geometry into triangles.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry.</param>
    /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
    public void Tessellate(in D2D1Matrix3X2F worldTransform, D2D1TessellationSink? tessellationSink)
    {
        if (tessellationSink is null)
        {
            throw new ArgumentNullException(nameof(tessellationSink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int hr = _comImpl->Tessellate(_comPtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, tessellationSink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Performs a combine operation between the two geometries to produce a resulting
    /// geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to combine with this instance.</param>
    /// <param name="combineMode">The type of combine operation to perform.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The result of the combine operation.</param>
    public void CombineWithGeometry(D2D1Geometry? inputGeometry, D2D1CombineMode combineMode, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->CombineWithGeometry(_comPtr, inputGeometry.Handle, combineMode, null, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Performs a combine operation between the two geometries to produce a resulting
    /// geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to combine with this instance.</param>
    /// <param name="combineMode">The type of combine operation to perform.</param>
    /// <param name="inputGeometryTransform">The transform to apply to inputGeometry before combining.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The result of the combine operation.</param>
    public void CombineWithGeometry(D2D1Geometry? inputGeometry, D2D1CombineMode combineMode, in D2D1Matrix3X2F inputGeometryTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int inputGeometryTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* inputGeometryTransformPtr = stackalloc byte[inputGeometryTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)inputGeometryTransformPtr, inputGeometryTransform);
        int hr = _comImpl->CombineWithGeometry(_comPtr, inputGeometry.Handle, combineMode, inputGeometryTransformPtr, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Performs a combine operation between the two geometries to produce a resulting
    /// geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to combine with this instance.</param>
    /// <param name="combineMode">The type of combine operation to perform.</param>
    /// <param name="geometrySink">The result of the combine operation.</param>
    public void CombineWithGeometry(D2D1Geometry? inputGeometry, D2D1CombineMode combineMode, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->CombineWithGeometry(_comPtr, inputGeometry.Handle, combineMode, null, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Performs a combine operation between the two geometries to produce a resulting
    /// geometry.
    /// </summary>
    /// <param name="inputGeometry">The geometry to combine with this instance.</param>
    /// <param name="combineMode">The type of combine operation to perform.</param>
    /// <param name="inputGeometryTransform">The transform to apply to inputGeometry before combining.</param>
    /// <param name="geometrySink">The result of the combine operation.</param>
    public void CombineWithGeometry(D2D1Geometry? inputGeometry, D2D1CombineMode combineMode, in D2D1Matrix3X2F inputGeometryTransform, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (inputGeometry is null)
        {
            throw new ArgumentNullException(nameof(inputGeometry));
        }

        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int inputGeometryTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* inputGeometryTransformPtr = stackalloc byte[inputGeometryTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)inputGeometryTransformPtr, inputGeometryTransform);
        int hr = _comImpl->CombineWithGeometry(_comPtr, inputGeometry.Handle, combineMode, inputGeometryTransformPtr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Computes the outline of the geometry. The result is written back into a
    /// simplified geometry sink.
    /// </summary>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
    public void Outline(float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->Outline(_comPtr, null, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Computes the outline of the geometry. The result is written back into a
    /// simplified geometry sink.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to the geometry outline.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
    public void Outline(in D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int hr = _comImpl->Outline(_comPtr, worldTransformPtr, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Computes the outline of the geometry. The result is written back into a
    /// simplified geometry sink.
    /// </summary>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
    public void Outline(D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int hr = _comImpl->Outline(_comPtr, null, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Computes the outline of the geometry. The result is written back into a
    /// simplified geometry sink.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to the geometry outline.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
    public void Outline(in D2D1Matrix3X2F worldTransform, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int hr = _comImpl->Outline(_comPtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Computes the area of the geometry.
    /// </summary>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <returns>The area of the transformed, flattened version of this geometry.</returns>
    public float ComputeArea(float flatteningTolerance)
    {
        float area;
        int hr = _comImpl->ComputeArea(_comPtr, null, flatteningTolerance, &area);
        Marshal.ThrowExceptionForHR(hr);
        return area;
    }

    /// <summary>
    /// Computes the area of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry before computing its area.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <returns>The area of the transformed, flattened version of this geometry.</returns>
    public float ComputeArea(in D2D1Matrix3X2F worldTransform, float flatteningTolerance)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        float area;
        int hr = _comImpl->ComputeArea(_comPtr, worldTransformPtr, flatteningTolerance, &area);
        Marshal.ThrowExceptionForHR(hr);
        return area;
    }

    /// <summary>
    /// Computes the area of the geometry.
    /// </summary>
    /// <returns>The area of the transformed, flattened version of this geometry.</returns>
    public float ComputeArea()
    {
        float area;
        int hr = _comImpl->ComputeArea(_comPtr, null, D2D1Constants.DefaultFlatteningTolerance, &area);
        Marshal.ThrowExceptionForHR(hr);
        return area;
    }

    /// <summary>
    /// Computes the area of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to this geometry before computing its area.</param>
    /// <returns>The area of the transformed, flattened version of this geometry.</returns>
    public float ComputeArea(in D2D1Matrix3X2F worldTransform)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        float area;
        int hr = _comImpl->ComputeArea(_comPtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, &area);
        Marshal.ThrowExceptionForHR(hr);
        return area;
    }

    /// <summary>
    /// Computes the length of the geometry.
    /// </summary>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
    public float ComputeLength(float flatteningTolerance)
    {
        float length;
        int hr = _comImpl->ComputeLength(_comPtr, null, flatteningTolerance, &length);
        Marshal.ThrowExceptionForHR(hr);
        return length;
    }

    /// <summary>
    /// Computes the length of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to the geometry before calculating its length.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
    public float ComputeLength(in D2D1Matrix3X2F worldTransform, float flatteningTolerance)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        float length;
        int hr = _comImpl->ComputeLength(_comPtr, worldTransformPtr, flatteningTolerance, &length);
        Marshal.ThrowExceptionForHR(hr);
        return length;
    }

    /// <summary>
    /// Computes the length of the geometry.
    /// </summary>
    /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
    public float ComputeLength()
    {
        float length;
        int hr = _comImpl->ComputeLength(_comPtr, null, D2D1Constants.DefaultFlatteningTolerance, &length);
        Marshal.ThrowExceptionForHR(hr);
        return length;
    }

    /// <summary>
    /// Computes the length of the geometry.
    /// </summary>
    /// <param name="worldTransform">The transform to apply to the geometry before calculating its length.</param>
    /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
    public float ComputeLength(in D2D1Matrix3X2F worldTransform)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        float length;
        int hr = _comImpl->ComputeLength(_comPtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, &length);
        Marshal.ThrowExceptionForHR(hr);
        return length;
    }

    /// <summary>
    /// Computes the point and tangent a given distance along the path.
    /// </summary>
    /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
    /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
    public void ComputePointAtLength(float length, float flatteningTolerance, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
    {
        int size = D2D1Point2F.NativeRequiredSize();
        byte* pointPtr = stackalloc byte[size];
        byte* unitTangentVectorPtr = stackalloc byte[size];
        int hr = _comImpl->ComputePointAtLength(_comPtr, length, null, flatteningTolerance, pointPtr, unitTangentVectorPtr);
        Marshal.ThrowExceptionForHR(hr);
        point = D2D1Point2F.NativeReadFrom((nint)pointPtr);
        unitTangentVector = D2D1Point2F.NativeReadFrom((nint)unitTangentVectorPtr);
    }

    /// <summary>
    /// Computes the point and tangent a given distance along the path.
    /// </summary>
    /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
    /// <param name="worldTransform">The transform to apply to the geometry before calculating the specified point and tangent.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
    /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
    public void ComputePointAtLength(float length, in D2D1Matrix3X2F worldTransform, float flatteningTolerance, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int size = D2D1Point2F.NativeRequiredSize();
        byte* pointPtr = stackalloc byte[size];
        byte* unitTangentVectorPtr = stackalloc byte[size];
        int hr = _comImpl->ComputePointAtLength(_comPtr, length, worldTransformPtr, flatteningTolerance, pointPtr, unitTangentVectorPtr);
        Marshal.ThrowExceptionForHR(hr);
        point = D2D1Point2F.NativeReadFrom((nint)pointPtr);
        unitTangentVector = D2D1Point2F.NativeReadFrom((nint)unitTangentVectorPtr);
    }

    /// <summary>
    /// Computes the point and tangent a given distance along the path.
    /// </summary>
    /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
    /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
    /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
    public void ComputePointAtLength(float length, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
    {
        int size = D2D1Point2F.NativeRequiredSize();
        byte* pointPtr = stackalloc byte[size];
        byte* unitTangentVectorPtr = stackalloc byte[size];
        int hr = _comImpl->ComputePointAtLength(_comPtr, length, null, D2D1Constants.DefaultFlatteningTolerance, pointPtr, unitTangentVectorPtr);
        Marshal.ThrowExceptionForHR(hr);
        point = D2D1Point2F.NativeReadFrom((nint)pointPtr);
        unitTangentVector = D2D1Point2F.NativeReadFrom((nint)unitTangentVectorPtr);
    }

    /// <summary>
    /// Computes the point and tangent a given distance along the path.
    /// </summary>
    /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
    /// <param name="worldTransform">The transform to apply to the geometry before calculating the specified point and tangent.</param>
    /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
    /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
    public void ComputePointAtLength(float length, in D2D1Matrix3X2F worldTransform, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
    {
        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        int size = D2D1Point2F.NativeRequiredSize();
        byte* pointPtr = stackalloc byte[size];
        byte* unitTangentVectorPtr = stackalloc byte[size];
        int hr = _comImpl->ComputePointAtLength(_comPtr, length, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, pointPtr, unitTangentVectorPtr);
        Marshal.ThrowExceptionForHR(hr);
        point = D2D1Point2F.NativeReadFrom((nint)pointPtr);
        unitTangentVector = D2D1Point2F.NativeReadFrom((nint)unitTangentVectorPtr);
    }

    /// <summary>
    /// Get the geometry and widen it as well as apply an optional pen style.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
    public void Widen(float strokeWidth, D2D1StrokeStyle? strokeStyle, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->Widen(_comPtr, strokeWidth, strokeStylePtr, null, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get the geometry and widen it as well as apply an optional pen style.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
    /// <param name="worldTransform">The transform to apply to the geometry after widening it.</param>
    /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
    public void Widen(float strokeWidth, D2D1StrokeStyle? strokeStyle, in D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->Widen(_comPtr, strokeWidth, strokeStylePtr, worldTransformPtr, flatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get the geometry and widen it as well as apply an optional pen style.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
    public void Widen(float strokeWidth, D2D1StrokeStyle? strokeStyle, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->Widen(_comPtr, strokeWidth, strokeStylePtr, null, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Get the geometry and widen it as well as apply an optional pen style.
    /// </summary>
    /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
    /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
    /// <param name="worldTransform">The transform to apply to the geometry after widening it.</param>
    /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
    public void Widen(float strokeWidth, D2D1StrokeStyle? strokeStyle, in D2D1Matrix3X2F worldTransform, D2D1SimplifiedGeometrySink? geometrySink)
    {
        if (geometrySink is null)
        {
            throw new ArgumentNullException(nameof(geometrySink));
        }

        int worldTransformSize = D2D1Matrix3X2F.NativeRequiredSize();
        byte* worldTransformPtr = stackalloc byte[worldTransformSize];
        D2D1Matrix3X2F.NativeWriteTo((nint)worldTransformPtr, worldTransform);
        nint strokeStylePtr = strokeStyle is null ? 0 : strokeStyle.Handle;
        int hr = _comImpl->Widen(_comPtr, strokeWidth, strokeStylePtr, worldTransformPtr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.Handle);
        Marshal.ThrowExceptionForHR(hr);
    }
}
