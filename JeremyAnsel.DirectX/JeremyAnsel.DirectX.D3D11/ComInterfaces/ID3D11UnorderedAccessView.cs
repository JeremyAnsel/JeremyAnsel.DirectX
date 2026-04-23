// <copyright file="ID3D11UnorderedAccessView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A view interface specifies the parts of a resource the pipeline can access during rendering.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11View"/></remarks>
[Guid("28acf509-7f5c-48f6-8611-f316010a6380")]
internal unsafe readonly struct ID3D11UnorderedAccessView
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
    /// Get a description of the resource.
    /// </summary>
    /// <param name="desc">A resource description.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
