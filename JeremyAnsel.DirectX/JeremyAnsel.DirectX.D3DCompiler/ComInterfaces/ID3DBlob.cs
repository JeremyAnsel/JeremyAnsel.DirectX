// <copyright file="ID3DBlob.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3DCompiler.ComInterfaces;

/// <summary>
/// This interface is used to return data of arbitrary length.
/// </summary>
[Guid("8BA5FB08-5195-40e2-AC58-0D989C3A0102")]
internal unsafe readonly struct ID3DBlob
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;

    /// <summary>
    /// Retrieves a pointer to the blob's data.
    /// </summary>
    /// <returns>Returns a pointer to the blob's data.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nint> GetBufferPointer;

    /// <summary>
    /// Retrieves the size, in bytes, of the blob's data.
    /// </summary>
    /// <returns>Returns the size of the blob's data, in bytes.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, nuint> GetBufferSize;
}
