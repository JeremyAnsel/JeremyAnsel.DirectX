// <copyright file="ID2D1TessellationSink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// Populates an <see cref="ID2D1Mesh"/> object with triangles.
/// </summary>
[Guid("2cd906c1-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1TessellationSink
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Copies the specified triangles to the sink.
    /// </summary>
    /// <param name="triangles">An array of <see cref="D2D1Triangle"/> structures that describe the triangles to add to the sink.</param>
    /// <param name="trianglesCount">The number of triangles to copy from the triangles array.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, void> AddTriangles;

    /// <summary>
    /// Closes the sink and returns its error status.
    /// </summary>
    public readonly delegate* unmanaged[Stdcall]<nint, void> Close;
}
