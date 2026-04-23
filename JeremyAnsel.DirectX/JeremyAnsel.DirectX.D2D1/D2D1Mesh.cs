// <copyright file="D2D1Mesh.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Represents a set of vertices that form a list of triangles.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Mesh : D2D1Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1MeshGuid = typeof(ID2D1Mesh).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Mesh* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Mesh"/> class.
    /// </summary>
    public D2D1Mesh(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Mesh**)comPtr;
    }

    /// <summary>
    /// Opens the mesh for population.
    /// </summary>
    /// <returns>An <see cref="D2D1TessellationSink"/> that is used to populate the mesh.</returns>
    public D2D1TessellationSink Open()
    {
        nint ptr;
        int hr = _comImpl->Open(_comPtr, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return new D2D1TessellationSink(ptr);
    }
}
