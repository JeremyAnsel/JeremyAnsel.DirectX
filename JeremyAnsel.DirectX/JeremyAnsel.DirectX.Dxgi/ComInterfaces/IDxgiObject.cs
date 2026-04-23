// <copyright file="IDxgiObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// An <c>IDXGIObject</c> interface is a base interface for all DXGI objects. <c>IDXGIObject</c> supports associating caller-defined (private data) with an object and retrieval of an interface to the parent object.
/// </summary>
[Guid("aec22fb8-76f3-4639-9be0-28eb43a67a2e")]
internal unsafe readonly struct IDxgiObject
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Sets application-defined data to the object and associates that data with a GUID.
    /// </summary>
    /// <param name="name">A GUID that identifies the data.</param>
    /// <param name="dataSize">The size of the object's data.</param>
    /// <param name="data">A pointer to the object's data.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, uint, void*, int> SetPrivateData;

    /// <summary>
    /// Set an interface in the object's private data.
    /// </summary>
    /// <param name="name">A GUID identifying the interface.</param>
    /// <param name="unknown">The interface to set.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint, int> SetPrivateDataInterface;

    /// <summary>
    /// Get a pointer to the object's data.
    /// </summary>
    /// <param name="name">A GUID identifying the data.</param>
    /// <param name="dataSize">The size of the data.</param>
    /// <param name="data">Pointer to the data.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, uint*, void*, int> GetPrivateData;

    /// <summary>
    /// Gets the parent of the object.
    /// </summary>
    /// <param name="riid">The ID of the requested interface.</param>
    /// <returns>The address of a pointer to the parent object.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, in Guid, nint*, int> GetParent;
}
