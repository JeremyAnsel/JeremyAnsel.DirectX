// <copyright file="ID3D11Texture2D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A 2D texture interface manages texel data, which is structured memory.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11Resource"/></remarks>
[Guid("6f15aaf2-d208-4e89-9ab4-489535d34f9c")]
internal unsafe readonly struct ID3D11Texture2D
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
