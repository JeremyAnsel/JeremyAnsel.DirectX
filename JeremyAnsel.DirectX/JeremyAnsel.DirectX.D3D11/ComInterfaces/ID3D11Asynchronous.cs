// <copyright file="ID3D11Asynchronous.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// This interface encapsulates methods for retrieving data from the GPU asynchronously.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("4b35d0cd-1e15-4258-9c98-1b1333f6dd3b")]
internal unsafe readonly struct ID3D11Asynchronous
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Get the size of the data (in bytes) that is output when calling <c>GetData</c>.
    /// </summary>
    /// <returns>The size of the data (in bytes) that is output when calling <c>GetData</c>.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, uint> GetDataSize;
}
