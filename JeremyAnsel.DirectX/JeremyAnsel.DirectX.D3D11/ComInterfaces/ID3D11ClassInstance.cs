// <copyright file="ID3D11ClassInstance.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// This interface encapsulates an HLSL class.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("a6cd7faa-b0b7-4a2f-9436-8662a65797cb")]
internal unsafe readonly struct ID3D11ClassInstance
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the <see cref="ID3D11ClassLinkage"/> object associated with the current HLSL class.
    /// </summary>
    /// <param name="linkage">A <see cref="ID3D11ClassLinkage"/> interface.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, nint*, void> GetClassLinkage;

    /// <summary>
    /// Gets a description of the current HLSL class.
    /// </summary>
    /// <param name="desc">A description of the current HLSL class.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, void> GetDesc;

    /// <summary>
    /// Gets the instance name of the current HLSL class.
    /// </summary>
    /// <param name="instanceName">The instance name of the current HLSL class.</param>
    /// <param name="bufferLength">The length of the instanceName parameter.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nuint*, void> GetInstanceName;

    /// <summary>
    /// Gets the type of the current HLSL class.
    /// </summary>
    /// <param name="typeName">The type of the current HLSL class.</param>
    /// <param name="bufferLength">The length of the typeName parameter.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, nuint*, void> GetTypeName;
}
