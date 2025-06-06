﻿// <copyright file="D2D1Geometry.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents a geometry resource and defines a set of helper methods for manipulating and measuring geometric shapes.
    /// </summary>
    public abstract class D2D1Geometry : D2D1Resource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Geometry"/> class.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Geometry()
        {
        }

        /// <summary>
        /// Retrieves the bounds of the geometry.
        /// </summary>
        /// <returns>The bounds of this geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectF GetBounds()
        {
            this.GetHandle<ID2D1Geometry>().GetBounds(IntPtr.Zero, out D2D1RectF bounds);
            return bounds;
        }

        /// <summary>
        /// Retrieves the bounds of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry before calculating its bounds, or NULL.</param>
        /// <returns>The bounds of this geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectF GetBounds(D2D1Matrix3X2F worldTransform)
        {
            D2D1RectF bounds;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().GetBounds(ptr, out bounds);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bounds;
        }

        /// <summary>
        /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
        /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more accurate results but cause slower execution.</param>
        /// <returns>The bounds of the widened geometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle strokeStyle, float flatteningTolerance)
        {
            this.GetHandle<ID2D1Geometry>().GetWidenedBounds(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), IntPtr.Zero, flatteningTolerance, out D2D1RectF bounds);
            return bounds;
        }

        /// <summary>
        /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
        /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
        /// <param name="worldTransform">A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance. Smaller values produce more accurate results but cause slower execution.</param>
        /// <returns>The bounds of the widened geometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1Matrix3X2F worldTransform, float flatteningTolerance)
        {
            D2D1RectF bounds;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().GetWidenedBounds(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), ptr, flatteningTolerance, out bounds);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bounds;
        }

        /// <summary>
        /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
        /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
        /// <returns>The bounds of the widened geometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            this.GetHandle<ID2D1Geometry>().GetWidenedBounds(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out D2D1RectF bounds);
            return bounds;
        }

        /// <summary>
        /// Gets the bounds of the geometry after it has been widened by the specified stroke width and style and transformed by the specified matrix.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry by stroking its outline.</param>
        /// <param name="strokeStyle">The style of the stroke that widens the geometry.</param>
        /// <param name="worldTransform">A transform to apply to the geometry after the geometry is transformed and after the geometry has been stroked.</param>
        /// <returns>The bounds of the widened geometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1RectF GetWidenedBounds(float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1Matrix3X2F worldTransform)
        {
            D2D1RectF bounds;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().GetWidenedBounds(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), ptr, D2D1Constants.DefaultFlatteningTolerance, out bounds);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return bounds;
        }

        /// <summary>
        /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
        /// </summary>
        /// <param name="point">The point to test for containment.</param>
        /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
        /// <param name="strokeStyle">The style of stroke to apply.</param>
        /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the stroke by less than the tolerance are still considered inside. Smaller values produce more accurate results but cause slower execution.</param>
        /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StrokeContainsPoint(D2D1Point2F point, float strokeWidth, D2D1StrokeStyle strokeStyle, float flatteningTolerance)
        {
            this.GetHandle<ID2D1Geometry>().StrokeContainsPoint(point, strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), IntPtr.Zero, flatteningTolerance, out bool contains);
            return contains;
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
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StrokeContainsPoint(D2D1Point2F point, float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1Matrix3X2F worldTransform, float flatteningTolerance)
        {
            bool contains;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().StrokeContainsPoint(point, strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), ptr, flatteningTolerance, out contains);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return contains;
        }

        /// <summary>
        /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
        /// </summary>
        /// <param name="point">The point to test for containment.</param>
        /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
        /// <param name="strokeStyle">The style of stroke to apply.</param>
        /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StrokeContainsPoint(D2D1Point2F point, float strokeWidth, D2D1StrokeStyle strokeStyle)
        {
            this.GetHandle<ID2D1Geometry>().StrokeContainsPoint(point, strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out bool contains);
            return contains;
        }

        /// <summary>
        /// Determines whether the geometry's stroke contains the specified point given the specified stroke thickness, style, and transform.
        /// </summary>
        /// <param name="point">The point to test for containment.</param>
        /// <param name="strokeWidth">The thickness of the stroke to apply.</param>
        /// <param name="strokeStyle">The style of stroke to apply.</param>
        /// <param name="worldTransform">The transform to apply to the stroked geometry.</param>
        /// <returns>A value set to <value>true</value> if the geometry's stroke contains the specified point; otherwise, <value>false</value>.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool StrokeContainsPoint(D2D1Point2F point, float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1Matrix3X2F worldTransform)
        {
            bool contains;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().StrokeContainsPoint(point, strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), ptr, D2D1Constants.DefaultFlatteningTolerance, out contains);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return contains;
        }

        /// <summary>
        /// Indicates whether the area filled by the geometry would contain the specified point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less than the tolerance are still considered inside.</param>
        /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FillContainPoint(D2D1Point2F point, float flatteningTolerance)
        {
            this.GetHandle<ID2D1Geometry>().FillContainsPoint(point, IntPtr.Zero, flatteningTolerance, out bool contains);
            return contains;
        }

        /// <summary>
        /// Indicates whether the area filled by the geometry would contain the specified point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <param name="worldTransform">The transform to apply to the geometry prior to testing for containment.</param>
        /// <param name="flatteningTolerance">The numeric accuracy with which the precise geometric path and path intersection is calculated. Points missing the fill by less than the tolerance are still considered inside.</param>
        /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FillContainPoint(D2D1Point2F point, D2D1Matrix3X2F worldTransform, float flatteningTolerance)
        {
            bool contains;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().FillContainsPoint(point, ptr, flatteningTolerance, out contains);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return contains;
        }

        /// <summary>
        /// Indicates whether the area filled by the geometry would contain the specified point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FillContainPoint(D2D1Point2F point)
        {
            this.GetHandle<ID2D1Geometry>().FillContainsPoint(point, IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out bool contains);
            return contains;
        }

        /// <summary>
        /// Indicates whether the area filled by the geometry would contain the specified point.
        /// </summary>
        /// <param name="point">The point to test.</param>
        /// <param name="worldTransform">The transform to apply to the geometry prior to testing for containment.</param>
        /// <returns>When this method returns, contains a boolean value that is <value>true</value> if the area filled by the geometry contains point; otherwise, <value>false</value>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool FillContainPoint(D2D1Point2F point, D2D1Matrix3X2F worldTransform)
        {
            bool contains;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().FillContainsPoint(point, ptr, D2D1Constants.DefaultFlatteningTolerance, out contains);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return contains;
        }

        /// <summary>
        /// Describes the intersection between this geometry and the specified geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to test.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GeometryRelation CompareWithGeometry(D2D1Geometry inputGeometry, float flatteningTolerance)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            this.GetHandle<ID2D1Geometry>().CompareWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), IntPtr.Zero, flatteningTolerance, out D2D1GeometryRelation relation);
            return relation;
        }

        /// <summary>
        /// Describes the intersection between this geometry and the specified geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to test.</param>
        /// <param name="inputGeometryTransform">The transform to apply to inputGeometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GeometryRelation CompareWithGeometry(D2D1Geometry inputGeometry, D2D1Matrix3X2F inputGeometryTransform, float flatteningTolerance)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            D2D1GeometryRelation relation;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(inputGeometryTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().CompareWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), ptr, flatteningTolerance, out relation);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return relation;
        }

        /// <summary>
        /// Describes the intersection between this geometry and the specified geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to test.</param>
        /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GeometryRelation CompareWithGeometry(D2D1Geometry inputGeometry)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            this.GetHandle<ID2D1Geometry>().CompareWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out D2D1GeometryRelation relation);
            return relation;
        }

        /// <summary>
        /// Describes the intersection between this geometry and the specified geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to test.</param>
        /// <param name="inputGeometryTransform">The transform to apply to inputGeometry.</param>
        /// <returns>A value that describes how this geometry is related to inputGeometry.</returns>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1GeometryRelation CompareWithGeometry(D2D1Geometry inputGeometry, D2D1Matrix3X2F inputGeometryTransform)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            D2D1GeometryRelation relation;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(inputGeometryTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().CompareWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), ptr, D2D1Constants.DefaultFlatteningTolerance, out relation);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return relation;
        }

        /// <summary>
        /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
        /// </summary>
        /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Simplify(D2D1GeometrySimplificationOption simplificationOption, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().Simplify(simplificationOption, IntPtr.Zero, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
        /// </summary>
        /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
        /// <param name="worldTransform">The transform to apply to the simplified geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Simplify(D2D1GeometrySimplificationOption simplificationOption, D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Simplify(simplificationOption, ptr, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
        /// </summary>
        /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Simplify(D2D1GeometrySimplificationOption simplificationOption, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().Simplify(simplificationOption, IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Creates a simplified version of the geometry that contains only lines and (optionally) cubic Bezier curves and writes the result to an <see cref="D2D1SimplifiedGeometrySink"/>.
        /// </summary>
        /// <param name="simplificationOption">A value that specifies whether the simplified geometry should contain curves.</param>
        /// <param name="worldTransform">The transform to apply to the simplified geometry.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the simplified geometry is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Simplify(D2D1GeometrySimplificationOption simplificationOption, D2D1Matrix3X2F worldTransform, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Simplify(simplificationOption, ptr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tessellates a geometry into triangles.
        /// </summary>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Tessellate(float flatteningTolerance, D2D1TessellationSink tessellationSink)
        {
            if (tessellationSink == null)
            {
                throw new ArgumentNullException(nameof(tessellationSink));
            }

            this.GetHandle<ID2D1Geometry>().Tessellate(IntPtr.Zero, flatteningTolerance, (ID2D1TessellationSink)tessellationSink.Handle);
        }

        /// <summary>
        /// Tessellates a geometry into triangles.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Tessellate(D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1TessellationSink tessellationSink)
        {
            if (tessellationSink == null)
            {
                throw new ArgumentNullException(nameof(tessellationSink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Tessellate(ptr, flatteningTolerance, (ID2D1TessellationSink)tessellationSink.Handle);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Tessellates a geometry into triangles.
        /// </summary>
        /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Tessellate(D2D1TessellationSink tessellationSink)
        {
            if (tessellationSink == null)
            {
                throw new ArgumentNullException(nameof(tessellationSink));
            }

            this.GetHandle<ID2D1Geometry>().Tessellate(IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, (ID2D1TessellationSink)tessellationSink.Handle);
        }

        /// <summary>
        /// Tessellates a geometry into triangles.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry.</param>
        /// <param name="tessellationSink">The <see cref="D2D1TessellationSink"/> to which the tessellated is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Tessellate(D2D1Matrix3X2F worldTransform, D2D1TessellationSink tessellationSink)
        {
            if (tessellationSink == null)
            {
                throw new ArgumentNullException(nameof(tessellationSink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Tessellate(ptr, D2D1Constants.DefaultFlatteningTolerance, (ID2D1TessellationSink)tessellationSink.Handle);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Performs a combine operation between the two geometries to produce a resulting
        /// geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to combine with this instance.</param>
        /// <param name="combineMode">The type of combine operation to perform.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The result of the combine operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CombineWithGeometry(D2D1Geometry inputGeometry, D2D1CombineMode combineMode, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().CombineWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), combineMode, IntPtr.Zero, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
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
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CombineWithGeometry(D2D1Geometry inputGeometry, D2D1CombineMode combineMode, D2D1Matrix3X2F inputGeometryTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(inputGeometryTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().CombineWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), combineMode, ptr, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Performs a combine operation between the two geometries to produce a resulting
        /// geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to combine with this instance.</param>
        /// <param name="combineMode">The type of combine operation to perform.</param>
        /// <param name="geometrySink">The result of the combine operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CombineWithGeometry(D2D1Geometry inputGeometry, D2D1CombineMode combineMode, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().CombineWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), combineMode, IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Performs a combine operation between the two geometries to produce a resulting
        /// geometry.
        /// </summary>
        /// <param name="inputGeometry">The geometry to combine with this instance.</param>
        /// <param name="combineMode">The type of combine operation to perform.</param>
        /// <param name="inputGeometryTransform">The transform to apply to inputGeometry before combining.</param>
        /// <param name="geometrySink">The result of the combine operation.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void CombineWithGeometry(D2D1Geometry inputGeometry, D2D1CombineMode combineMode, D2D1Matrix3X2F inputGeometryTransform, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (inputGeometry == null)
            {
                throw new ArgumentNullException(nameof(inputGeometry));
            }

            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(inputGeometryTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().CombineWithGeometry(inputGeometry.GetHandle<ID2D1Geometry>(), combineMode, ptr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Computes the outline of the geometry. The result is written back into a
        /// simplified geometry sink.
        /// </summary>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Outline(float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().Outline(IntPtr.Zero, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Computes the outline of the geometry. The result is written back into a
        /// simplified geometry sink.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to the geometry outline.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Outline(D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Outline(ptr, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Computes the outline of the geometry. The result is written back into a
        /// simplified geometry sink.
        /// </summary>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Outline(D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().Outline(IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Computes the outline of the geometry. The result is written back into a
        /// simplified geometry sink.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to the geometry outline.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the geometry's transformed outline is appended.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Outline(D2D1Matrix3X2F worldTransform, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Outline(ptr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Computes the area of the geometry.
        /// </summary>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <returns>The area of the transformed, flattened version of this geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeArea(float flatteningTolerance)
        {
            this.GetHandle<ID2D1Geometry>().ComputeArea(IntPtr.Zero, flatteningTolerance, out float area);
            return area;
        }

        /// <summary>
        /// Computes the area of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry before computing its area.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <returns>The area of the transformed, flattened version of this geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeArea(D2D1Matrix3X2F worldTransform, float flatteningTolerance)
        {
            float area;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().ComputeArea(ptr, flatteningTolerance, out area);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return area;
        }

        /// <summary>
        /// Computes the area of the geometry.
        /// </summary>
        /// <returns>The area of the transformed, flattened version of this geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeArea()
        {
            this.GetHandle<ID2D1Geometry>().ComputeArea(IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out float area);
            return area;
        }

        /// <summary>
        /// Computes the area of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to this geometry before computing its area.</param>
        /// <returns>The area of the transformed, flattened version of this geometry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeArea(D2D1Matrix3X2F worldTransform)
        {
            float area;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().ComputeArea(ptr, D2D1Constants.DefaultFlatteningTolerance, out area);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return area;
        }

        /// <summary>
        /// Computes the length of the geometry.
        /// </summary>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeLength(float flatteningTolerance)
        {
            this.GetHandle<ID2D1Geometry>().ComputeLength(IntPtr.Zero, flatteningTolerance, out float length);
            return length;
        }

        /// <summary>
        /// Computes the length of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to the geometry before calculating its length.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeLength(D2D1Matrix3X2F worldTransform, float flatteningTolerance)
        {
            float length;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().ComputeLength(ptr, flatteningTolerance, out length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return length;
        }

        /// <summary>
        /// Computes the length of the geometry.
        /// </summary>
        /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeLength()
        {
            this.GetHandle<ID2D1Geometry>().ComputeLength(IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out float length);
            return length;
        }

        /// <summary>
        /// Computes the length of the geometry.
        /// </summary>
        /// <param name="worldTransform">The transform to apply to the geometry before calculating its length.</param>
        /// <returns>The length of the geometry. For closed geometries, the length includes an implicit closing segment.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float ComputeLength(D2D1Matrix3X2F worldTransform)
        {
            float length;

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().ComputeLength(ptr, D2D1Constants.DefaultFlatteningTolerance, out length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            return length;
        }

        /// <summary>
        /// Computes the point and tangent a given distance along the path.
        /// </summary>
        /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
        /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComputePointAtLength(float length, float flatteningTolerance, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
        {
            this.GetHandle<ID2D1Geometry>().ComputePointAtLength(length, IntPtr.Zero, flatteningTolerance, out point, out unitTangentVector);
        }

        /// <summary>
        /// Computes the point and tangent a given distance along the path.
        /// </summary>
        /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
        /// <param name="worldTransform">The transform to apply to the geometry before calculating the specified point and tangent.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
        /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComputePointAtLength(float length, D2D1Matrix3X2F worldTransform, float flatteningTolerance, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().ComputePointAtLength(length, ptr, flatteningTolerance, out point, out unitTangentVector);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Computes the point and tangent a given distance along the path.
        /// </summary>
        /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
        /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
        /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComputePointAtLength(float length, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
        {
            this.GetHandle<ID2D1Geometry>().ComputePointAtLength(length, IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, out point, out unitTangentVector);
        }

        /// <summary>
        /// Computes the point and tangent a given distance along the path.
        /// </summary>
        /// <param name="length">The distance along the geometry of the point and tangent to find. If this distance is less then 0, this method calculates the first point in the geometry. If this distance is greater than the length of the geometry, this method calculates the last point in the geometry.</param>
        /// <param name="worldTransform">The transform to apply to the geometry before calculating the specified point and tangent.</param>
        /// <param name="point">The location at the specified distance along the geometry. If the geometry is empty, this point contains NaN as its x and y values.</param>
        /// <param name="unitTangentVector">The tangent vector at the specified distance along the geometry. If the geometry is empty, this vector contains NaN as its x and y values. You must allocate storage for this parameter.</param>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "Reviewed")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ComputePointAtLength(float length, D2D1Matrix3X2F worldTransform, out D2D1Point2F point, out D2D1Point2F unitTangentVector)
        {
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().ComputePointAtLength(length, ptr, D2D1Constants.DefaultFlatteningTolerance, out point, out unitTangentVector);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Get the geometry and widen it as well as apply an optional pen style.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Widen(float strokeWidth, D2D1StrokeStyle strokeStyle, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().Widen(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), IntPtr.Zero, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Get the geometry and widen it as well as apply an optional pen style.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
        /// <param name="worldTransform">The transform to apply to the geometry after widening it.</param>
        /// <param name="flatteningTolerance">The maximum error allowed when constructing a polygonal approximation of the geometry. No point in the polygonal representation will diverge from the original geometry by more than the flattening tolerance.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Widen(float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1Matrix3X2F worldTransform, float flatteningTolerance, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Widen(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), ptr, flatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Get the geometry and widen it as well as apply an optional pen style.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Widen(float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            this.GetHandle<ID2D1Geometry>().Widen(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), IntPtr.Zero, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
        }

        /// <summary>
        /// Get the geometry and widen it as well as apply an optional pen style.
        /// </summary>
        /// <param name="strokeWidth">The amount by which to widen the geometry.</param>
        /// <param name="strokeStyle">The style of stroke to apply to the geometry.</param>
        /// <param name="worldTransform">The transform to apply to the geometry after widening it.</param>
        /// <param name="geometrySink">The <see cref="D2D1SimplifiedGeometrySink"/> to which the widened geometry is appended.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Widen(float strokeWidth, D2D1StrokeStyle strokeStyle, D2D1Matrix3X2F worldTransform, D2D1SimplifiedGeometrySink geometrySink)
        {
            if (geometrySink == null)
            {
                throw new ArgumentNullException(nameof(geometrySink));
            }

            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(D2D1Matrix3X2F)));

            try
            {
                Marshal.StructureToPtr(worldTransform, ptr, false);

                this.GetHandle<ID2D1Geometry>().Widen(strokeWidth, strokeStyle?.GetHandle<ID2D1StrokeStyle>(), ptr, D2D1Constants.DefaultFlatteningTolerance, geometrySink.GetHandle<ID2D1SimplifiedGeometrySink>());
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
