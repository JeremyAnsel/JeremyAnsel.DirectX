// <copyright file="IDxgiResource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// An <c>IDXGIResource</c> interface allows resource sharing and identifies the memory that a resource resides in.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
[Guid("035f3ab4-482e-4e50-b41f-8a7f8bd8960b")]
internal unsafe readonly struct IDxgiResource
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;
    private readonly nint GetDevice;

    /// <summary>
    /// Gets the handle to a shared resource.
    /// </summary>
    /// <returns>A handle.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, int> GetSharedHandle;

    /// <summary>
    /// Get the expected resource usage.
    /// </summary>
    /// <returns>A usage flag.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiUsages*, int> GetUsage;

    /// <summary>
    /// Set the priority for evicting the resource from memory.
    /// </summary>
    /// <param name="evictionPriority">The eviction priority, which determines when a resource can be evicted from memory.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiResourceEvictionPriority, int> SetEvictionPriority;

    /// <summary>
    /// Get the eviction priority.
    /// </summary>
    /// <returns>The eviction priority, which determines when a resource can be evicted from memory.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, DxgiResourceEvictionPriority*, int> GetEvictionPriority;
}
