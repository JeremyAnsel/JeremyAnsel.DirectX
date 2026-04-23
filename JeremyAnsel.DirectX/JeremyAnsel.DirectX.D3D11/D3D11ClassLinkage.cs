// <copyright file="D3D11ClassLinkage.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// This interface encapsulates an HLSL dynamic linkage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11ClassLinkage : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11ClassLinkageGuid = typeof(ID3D11ClassLinkage).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11ClassLinkage* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ClassLinkage"/> class.
    /// </summary>
    public D3D11ClassLinkage(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11ClassLinkage**)comPtr;
    }

    /// <summary>
    /// Gets the class-instance object that represents the specified HLSL class.
    /// </summary>
    /// <param name="name">The name of a class for which to get the class instance.</param>
    /// <param name="index">The index of the class instance.</param>
    /// <returns>A class instance interface.</returns>
    public D3D11ClassInstance GetClassInstance(string name, uint index)
    {
        return GetClassInstance(name.AsSpan(), index);
    }

    /// <summary>
    /// Gets the class-instance object that represents the specified HLSL class.
    /// </summary>
    /// <param name="name">The name of a class for which to get the class instance.</param>
    /// <param name="index">The index of the class instance.</param>
    /// <returns>A class instance interface.</returns>
    public D3D11ClassInstance GetClassInstance(ReadOnlySpan<char> name, uint index)
    {
        fixed (char* namePtr = name)
        {
            int size = Encoding.ASCII.GetByteCount(namePtr, name.Length) + 1;
            byte* dataPtr = stackalloc byte[size];
            int count = Encoding.ASCII.GetBytes(namePtr, name.Length, dataPtr, size);
            dataPtr[count] = 0;
            return GetClassInstance(new ReadOnlySpan<byte>(dataPtr, count + 1), index);
        }
    }

    /// <summary>
    /// Gets the class-instance object that represents the specified HLSL class.
    /// </summary>
    /// <param name="name">The name of a class for which to get the class instance.</param>
    /// <param name="index">The index of the class instance.</param>
    /// <returns>A class instance interface.</returns>
    public D3D11ClassInstance GetClassInstance(ReadOnlySpan<byte> name, uint index)
    {
        fixed (byte* namePtr = name)
        {
            nint ptr;
            int hr = _comImpl->GetClassInstance(_comPtr, namePtr, index, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11ClassInstance(ptr);
        }
    }

    /// <summary>
    /// Initializes a class-instance object that represents an HLSL class instance.
    /// </summary>
    /// <param name="classTypeName">The type name of a class to initialize.</param>
    /// <param name="constantBufferOffset">Identifies the constant buffer that contains the class data.</param>
    /// <param name="constantVectorOffset">The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is not a byte offset.</param>
    /// <param name="textureOffset">The texture slot for the first texture; there may be multiple textures following the offset.</param>
    /// <param name="samplerOffset">The sampler slot for the first sampler; there may be multiple samplers following the offset.</param>
    /// <returns>A class instance interface.</returns>
    public D3D11ClassInstance CreateClassInstance(
        string classTypeName,
        uint constantBufferOffset,
        uint constantVectorOffset,
        uint textureOffset,
        uint samplerOffset)
    {
        return CreateClassInstance(classTypeName.AsSpan(), constantBufferOffset, constantVectorOffset, textureOffset, samplerOffset);
    }

    /// <summary>
    /// Initializes a class-instance object that represents an HLSL class instance.
    /// </summary>
    /// <param name="classTypeName">The type name of a class to initialize.</param>
    /// <param name="constantBufferOffset">Identifies the constant buffer that contains the class data.</param>
    /// <param name="constantVectorOffset">The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is not a byte offset.</param>
    /// <param name="textureOffset">The texture slot for the first texture; there may be multiple textures following the offset.</param>
    /// <param name="samplerOffset">The sampler slot for the first sampler; there may be multiple samplers following the offset.</param>
    /// <returns>A class instance interface.</returns>
    public D3D11ClassInstance CreateClassInstance(
        ReadOnlySpan<char> classTypeName,
        uint constantBufferOffset,
        uint constantVectorOffset,
        uint textureOffset,
        uint samplerOffset)
    {
        fixed (char* namePtr = classTypeName)
        {
            int size = Encoding.ASCII.GetByteCount(namePtr, classTypeName.Length) + 1;
            byte* dataPtr = stackalloc byte[size];
            int count = Encoding.ASCII.GetBytes(namePtr, classTypeName.Length, dataPtr, size);
            dataPtr[count] = 0;
            return CreateClassInstance(new ReadOnlySpan<byte>(dataPtr, count + 1), constantBufferOffset, constantVectorOffset, textureOffset, samplerOffset);
        }
    }

    /// <summary>
    /// Initializes a class-instance object that represents an HLSL class instance.
    /// </summary>
    /// <param name="classTypeName">The type name of a class to initialize.</param>
    /// <param name="constantBufferOffset">Identifies the constant buffer that contains the class data.</param>
    /// <param name="constantVectorOffset">The four-component vector offset from the start of the constant buffer where the class data will begin. Consequently, this is not a byte offset.</param>
    /// <param name="textureOffset">The texture slot for the first texture; there may be multiple textures following the offset.</param>
    /// <param name="samplerOffset">The sampler slot for the first sampler; there may be multiple samplers following the offset.</param>
    /// <returns>A class instance interface.</returns>
    public D3D11ClassInstance CreateClassInstance(
        ReadOnlySpan<byte> classTypeName,
        uint constantBufferOffset,
        uint constantVectorOffset,
        uint textureOffset,
        uint samplerOffset)
    {
        fixed (byte* namePtr = classTypeName)
        {
            nint ptr;
            int hr = _comImpl->CreateClassInstance(_comPtr, namePtr, constantBufferOffset, constantVectorOffset, textureOffset, samplerOffset, &ptr);
            Marshal.ThrowExceptionForHR(hr);
            return new D3D11ClassInstance(ptr);
        }
    }
}
