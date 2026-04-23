// <copyright file="ID3D11Buffer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A buffer interface accesses a buffer resource, which is unstructured memory.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11Resource"/></remarks>
[Guid("48570b85-d1ee-4fcd-a250-eb350722b037")]
internal unsafe readonly struct ID3D11Buffer
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetDimension;
    private readonly nint SetEvictionPriority;
    private readonly nint GetEvictionPriority;

    /// <summary>
    /// Get the properties of a buffer resource.
    /// </summary>
    /// <param name="desc">A resource description.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
