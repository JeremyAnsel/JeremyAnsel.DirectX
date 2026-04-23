// <copyright file="ID3D11DepthStencilState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// The depth-stencil-state interface holds a description for depth-stencil state that you can bind to the output-merger stage.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("03823efb-8d8f-4e1c-9aa2-f64bb2cbfdf1")]
internal unsafe readonly struct ID3D11DepthStencilState
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the description for depth-stencil state that you used to create the depth-stencil-state object.
    /// </summary>
    /// <param name="desc">A description of the depth-stencil state.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
