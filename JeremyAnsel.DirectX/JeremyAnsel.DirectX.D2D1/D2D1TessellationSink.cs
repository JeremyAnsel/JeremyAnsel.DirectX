// <copyright file="D2D1TessellationSink.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// Populates an <see cref="D2D1Mesh"/> object with triangles.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1TessellationSink : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1TessellationSinkGuid = typeof(ID2D1TessellationSink).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1TessellationSink* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1TessellationSink"/> class.
    /// </summary>
    public D2D1TessellationSink(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1TessellationSink**)comPtr;
    }

    /// <summary>
    /// Copies the specified triangles to the sink.
    /// </summary>
    /// <param name="triangles">An array of <see cref="D2D1Triangle"/> structures that describe the triangles to add to the sink.</param>
    public void AddTriangles(D2D1Triangle[]? triangles)
    {
        AddTriangles(triangles.AsSpan());
    }

    /// <summary>
    /// Copies the specified triangles to the sink.
    /// </summary>
    /// <param name="triangles">An array of <see cref="D2D1Triangle"/> structures that describe the triangles to add to the sink.</param>
    public void AddTriangles(ReadOnlySpan<D2D1Triangle> triangles)
    {
        if (triangles.Length == 0)
        {
            throw new ArgumentNullException(nameof(triangles));
        }

        int size = D2D1Triangle.NativeRequiredSize(triangles.Length);
        byte* ptr = stackalloc byte[size];
        D2D1Triangle.NativeWriteTo((nint)ptr, triangles);
        _comImpl->AddTriangles(_comPtr, ptr, (uint)triangles.Length);
    }

    /// <summary>
    /// Closes the sink and returns its error status.
    /// </summary>
    public void Close()
    {
        _comImpl->Close(_comPtr);
    }
}
