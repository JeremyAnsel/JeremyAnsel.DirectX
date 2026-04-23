// <copyright file="ID3D11Texture3D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A 3D texture interface accesses texel data, which is structured memory.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11Resource"/></remarks>
[Guid("037e866e-f56d-4357-a8af-9dabbe6e250e")]
internal unsafe readonly struct ID3D11Texture3D
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
    /// Get the properties of the texture resource.
    /// </summary>
    /// <param name="desc">A resource description.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
