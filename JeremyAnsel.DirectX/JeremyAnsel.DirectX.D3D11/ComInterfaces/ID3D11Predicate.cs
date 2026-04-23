// <copyright file="ID3D11Predicate.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// A predicate interface determines whether geometry should be processed depending on the results of a previous draw call.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11Query"/></remarks>
[Guid("9eb576dd-9f77-4d86-81aa-8bab5fe490e2")]
internal unsafe readonly struct ID3D11Predicate
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetDataSize;
    private readonly nint GetDesc;
}
