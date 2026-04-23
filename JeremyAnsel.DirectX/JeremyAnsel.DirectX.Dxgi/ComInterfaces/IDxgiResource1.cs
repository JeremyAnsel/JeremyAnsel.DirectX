// <copyright file="IDxgiResource1.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// An <c>IDXGIResource1</c> interface extends the <c>IDXGIResource</c> interface by adding support for creating a sub-resource surface object and for creating a handle to a shared resource.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiResource"/></remarks>
[Guid("30961379-4609-4a41-998e-54fe567ee0c1")]
internal unsafe readonly struct IDxgiResource1
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

    /// <summary>
    /// Creates a sub-resource surface object.
    /// </summary>
    /// <param name="index">The index of the sub-resource surface object to enumerate.</param>
    /// <returns>A <c>IDXGISurface2</c> interface that represents the created sub-resource surface object at the position specified.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint, nint*, int> CreateSubresourceSurface;

    /// <summary>
    /// Creates a handle to a shared resource. You can then use the returned handle with multiple Direct3D devices.
    /// </summary>
    /// <param name="securityAttributes">A pointer to a <c>SECURITY_ATTRIBUTES</c> structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether child processes can inherit the returned handle.</param>
    /// <param name="access">The requested access rights to the resource.</param>
    /// <param name="name">The name of the resource to share. The name is limited to <value>MAX_PATH</value> characters. Name comparison is case sensitive.</param>
    /// <returns>The <c>NT HANDLE</c> value to the resource to share. You can use this handle in calls to access the resource.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint, DxgiSharedResourceAccess, char*, nint*, int> CreateSharedHandle;
}
