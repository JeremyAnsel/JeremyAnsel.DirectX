// <copyright file="ID3D11RenderTargetView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A render-target-view interface identifies the render-target subresources that can be accessed during rendering.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11View"/></remarks>
[Guid("dfdba067-0b8d-4865-875b-d7b4516cc164")]
internal unsafe readonly struct ID3D11RenderTargetView
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
    /// Get the properties of a render target view.
    /// </summary>
    /// <param name="desc">The description of a render target view.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
