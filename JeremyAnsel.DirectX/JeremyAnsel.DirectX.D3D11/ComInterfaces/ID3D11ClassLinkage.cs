// <copyright file="ID3D11ClassLinkage.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.D3D11.ComInterfaces;

/// <summary>
/// This interface encapsulates an HLSL dynamic linkage.
/// </summary>
/// <remarks>Inherited from <see cref="ID3D11DeviceChild"/></remarks>
[Guid("ddf57cba-9543-46e4-a12b-f207a0fe7fed")]
internal unsafe readonly struct ID3D11ClassLinkage
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint GetDevice;
    private readonly nint GetPrivateData;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;

    /// <summary>
    /// Gets the class-instance object that represents the specified HLSL class.
    /// </summary>
    /// <param name="classInstanceName">The name of a class for which to get the class instance.</param>
    /// <param name="instanceIndex">The index of the class instance.</param>
    /// <returns>An <see cref="ID3D11ClassInstance"/> interface.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, nint*, int> GetClassInstance;

    /// <summary>
    /// Initializes a class-instance object that represents an HLSL class instance.
    /// </summary>
    /// <param name="classTypeName">The type name of a class to initialize.</param>
    /// <param name="constantBufferOffset">Identifies the constant buffer that contains the class data.</param>
    /// <param name="constantVectorOffset">The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is not a byte offset.</param>
    /// <param name="textureOffset">The texture slot for the first texture; there may be multiple textures following the offset.</param>
    /// <param name="samplerOffset">The sampler slot for the first sampler; there may be multiple samplers following the offset.</param>
    /// <returns>An <see cref="ID3D11ClassInstance"/> interface.</returns>
    public readonly delegate* unmanaged[Stdcall]<nint, void*, uint, uint, uint, uint, nint*, int> CreateClassInstance;
}
