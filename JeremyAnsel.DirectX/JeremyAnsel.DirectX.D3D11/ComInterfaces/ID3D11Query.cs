// <copyright file="ID3D11Query.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A query interface queries information from the GPU.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11Asynchronous"/></remarks>
[Guid("d6c00747-87b7-425e-b84d-44d108560afd")]
internal unsafe readonly struct ID3D11Query
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetDataSize;

    /// <summary>
    /// Get a query description.
    /// </summary>
    /// <param name="desc">A query description.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
