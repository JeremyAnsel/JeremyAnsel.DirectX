// <copyright file="ID3D11BlendState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// The blend-state interface holds a description for blending state that you can bind to the output-merger stage.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("75b68faa-347d-4159-8f45-a0640f01cd9a")]
internal unsafe readonly struct ID3D11BlendState
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the description for blending state that you used to create the blend-state object.
    /// </summary>
    /// <param name="desc">A description of the blend state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
