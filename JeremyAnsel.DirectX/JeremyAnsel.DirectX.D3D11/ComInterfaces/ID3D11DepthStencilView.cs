// <copyright file="ID3D11DepthStencilView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A depth-stencil-view interface accesses a texture resource during depth-stencil testing.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11View"/></remarks>
[Guid("9fdac92a-1876-48c3-afad-25b94f84a9b6")]
internal unsafe readonly struct ID3D11DepthStencilView
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
    /// Get the depth-stencil view.
    /// </summary>
    /// <param name="desc">A depth-stencil-view description.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
