// <copyright file="D2D1Mesh.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1
{
    using System.Runtime.CompilerServices;
    using JeremyAnsel.DirectX.D2D1.ComInterfaces;

    /// <summary>
    /// Represents a set of vertices that form a list of triangles.
    /// </summary>
    public sealed class D2D1Mesh : D2D1Resource
    {
        /// <summary>
        /// The D2D1 mesh interface.
        /// </summary>
        private readonly ID2D1Mesh mesh;

        /// <summary>
        /// Initializes a new instance of the <see cref="D2D1Mesh"/> class.
        /// </summary>
        /// <param name="mesh">A D2D1 mesh interface.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal D2D1Mesh(ID2D1Mesh mesh)
        {
            this.mesh = mesh;
        }

        /// <summary>
        /// Gets an handle representing the D2D1 object interface.
        /// </summary>
        public override object Handle
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return this.mesh; }
        }

        /// <summary>
        /// Opens the mesh for population.
        /// </summary>
        /// <returns>An <see cref="D2D1TessellationSink"/> that is used to populate the mesh.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public D2D1TessellationSink? Open()
        {
            this.mesh.Open(out ID2D1TessellationSink? tessellationSink);

            if (tessellationSink == null)
            {
                return null;
            }

            return new D2D1TessellationSink(tessellationSink);
        }
    }
}
