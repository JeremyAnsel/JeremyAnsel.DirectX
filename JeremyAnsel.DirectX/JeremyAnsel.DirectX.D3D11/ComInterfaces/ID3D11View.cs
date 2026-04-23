// <copyright file="ID3D11View.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A view interface specifies the parts of a resource the pipeline can access during rendering.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("839d1216-bb2e-412b-b7f4-a9dbebe08ed1")]
internal unsafe readonly struct ID3D11View
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Get the resource that is accessed through this view.
    /// </summary>
    /// <param name="resource">The resource that is accessed through this view.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetResource;
}
