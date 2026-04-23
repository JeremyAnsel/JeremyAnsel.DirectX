// <copyright file="ID3D11CommandList.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// Encapsulates a list of graphics commands for play back.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("a24bc4d1-769e-43f7-8013-98ff566c18e2")]
internal unsafe readonly struct ID3D11CommandList
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the initialization flags associated with the deferred context that created the command list.
    /// </summary>
    /// <returns>The context flag is reserved for future use and is always 0.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetContextOptions;
}
