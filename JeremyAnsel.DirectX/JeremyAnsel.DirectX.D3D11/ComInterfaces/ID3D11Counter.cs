// <copyright file="ID3D11Counter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// This interface encapsulates methods for measuring GPU performance.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11Asynchronous"/></remarks>
[Guid("6e8c49fb-a371-4770-b440-29086022b741")]
internal unsafe readonly struct ID3D11Counter
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
    /// Get a counter description.
    /// </summary>
    /// <param name="desc">A counter description.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;
}
