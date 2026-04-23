// <copyright file="ID3D11SamplerState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// The sampler-state interface holds a description for sampler state that you can bind to any shader stage of the pipeline for reference by texture sample operations.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("da6fea51-564c-4487-9810-f0d0f9b4e3a5")]
internal unsafe readonly struct ID3D11SamplerState
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the description for sampler state that you used to create the sampler-state object.
    /// </summary>
    /// <param name="desc">A description of the sampler state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
