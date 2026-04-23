// <copyright file="ID2D1Resource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D2D1.ComInterfaces;

/// <summary>
/// The root interface for all resources in D2D.
/// </summary>
[Guid("2cd90691-12e2-11dc-9fed-001143a055f9")]
internal unsafe readonly struct ID2D1Resource
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Retrieve the factory associated with this resource.
    /// </summary>
    /// <param name="factory">When this method returns, contains a pointer to a pointer to the factory that created this resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetFactory;
}
