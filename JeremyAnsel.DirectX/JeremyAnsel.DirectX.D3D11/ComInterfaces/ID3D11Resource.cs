// <copyright file="ID3D11Resource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A resource interface provides common actions on all resources.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("dc8e63f3-d12b-4952-b47b-5e45026a862d")]
internal unsafe readonly struct ID3D11Resource
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Get the type of the resource.
    /// </summary>
    /// <param name="dimension">The resource type.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, D3D11ResourceDimension*, void> GetDimension;

    /// <summary>
    /// Set the eviction priority of a resource.
    /// </summary>
    /// <param name="evictionPriority">The eviction priority for the resource.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiResourceEvictionPriority, void> SetEvictionPriority;

    /// <summary>
    /// Get the eviction priority of a resource.
    /// </summary>
    /// <returns>The eviction priority for the resource.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiResourceEvictionPriority> GetEvictionPriority;
}
