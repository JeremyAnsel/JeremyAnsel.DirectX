// <copyright file="ID3D11RasterizerState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// The rasterizer-state interface holds a description for rasterizer state that you can bind to the rasterizer stage.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("9bb4ab81-ab1a-4d8f-b506-fc04200b6ee7")]
internal unsafe readonly struct ID3D11RasterizerState
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the description for rasterizer state that you used to create the rasterizer-state object.
    /// </summary>
    /// <param name="desc">A description of the rasterizer state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
