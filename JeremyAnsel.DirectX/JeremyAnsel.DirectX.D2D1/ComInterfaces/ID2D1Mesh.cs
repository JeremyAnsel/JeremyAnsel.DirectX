// <copyright file="ID2D1Mesh.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2016, 2019 Jérémy Ansel
// </copyright>

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Represents a set of vertices that form a list of triangles.
    /// </summary>
    /// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    [ComImport, Guid("2cd906c2-12e2-11dc-9fed-001143a055f9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ID2D1Mesh
    {
        /// <summary>
        /// Retrieve the factory associated with this resource.
        /// </summary>
        /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
        [PreserveSig]
        void GetFactory(
            [Out] out ID2D1Factory? factory);

        /// <summary>
        /// Opens the mesh for population.
        /// </summary>
        /// <param name="tessellationSink">An <see cref="ID2D1TessellationSink"/> that is used to populate the mesh.</param>
        void Open(
            [Out] out ID2D1TessellationSink? tessellationSink);
    }
}
