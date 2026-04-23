// <copyright file="ID3D11ShaderResourceView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A shader-resource-view interface specifies the subresources a shader can access during rendering.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11View"/></remarks>
[Guid("b0e06fe0-8192-4e1a-b1ca-36d7414710b2")]
internal unsafe readonly struct ID3D11ShaderResourceView
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetResource;

    /// <summary>
    /// Get the shader resource view's description.
    /// </summary>
    /// <param name="desc">The data about the shader resource view.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
