// <copyright file="D3D11ComputeShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A compute shader interface manages an executable program (a compute shader) that controls the compute shader stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11ComputeShader : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11ComputeShaderGuid = typeof(ID3D11ComputeShader).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11ComputeShader* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ComputeShader"/> class.
    /// </summary>
    public D3D11ComputeShader(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11ComputeShader**)comPtr;
    }
}
