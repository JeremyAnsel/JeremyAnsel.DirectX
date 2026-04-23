// <copyright file="ID2D1Mesh.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Represents a set of vertices that form a list of triangles.
/// </summary>
/// <remarks>Inherited from <see cref="ID2D1Resource"/></remarks>
[Guid("2cd906c2-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1Mesh
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetFactory;

    /// <summary>
    /// Opens the mesh for population.
    /// </summary>
    /// <param name="tessellationSink">An <see cref="ID2D1TessellationSink"/> that is used to populate the mesh.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> Open;
}
