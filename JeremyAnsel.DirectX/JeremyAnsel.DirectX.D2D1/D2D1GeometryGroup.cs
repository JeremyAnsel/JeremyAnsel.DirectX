// <copyright file="D2D1GeometryGroup.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents a composite geometry, composed of other <see cref="D2D1Geometry"/> objects.
    /// </summary>
    public sealed class D2D1GeometryGroup : D2D1Geometry
    {
        /// <summary>
        /// The D2D1 geometry interface.
        /// </summary>
        private ID2D1GeometryGroup geometry;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1GeometryGroup"/> class.
        /// </summary>
        /// <param name="geometry">A D2D1 geometry interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1GeometryGroup(ID2D1GeometryGroup geometry)
        {
            this.geometry = geometry;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.geometry; }
        }

        /// <summary>
        /// Gets a value indicating how the intersecting areas of the geometries contained in this geometry group are combined.
        /// </summary>
        public D2D1FillMode FillMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.geometry.GetFillMode(); }
        }

        /// <summary>
        /// Gets the number of geometry objects in the geometry group.
        /// </summary>
        /// <returns>The number of geometries in the geometry group.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Reviewed")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint GetSourceGeometryCount()
        {
            return this.geometry.GetSourceGeometryCount();
        }

        /// <summary>
        /// Retrieves the geometries in the geometry group.
        /// </summary>
        /// <returns>An array of geometries to be filled by this method.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1Geometry[] GetSourceGeometries()
        {
            uint count = this.geometry.GetSourceGeometryCount();

            ID2D1Geometry[] geometries = new ID2D1Geometry[count];
            this.geometry.GetSourceGeometries(geometries, count);

            return Array.ConvertAll(geometries, t => new D2D1GeometryBase(t));
        }
    }
}
