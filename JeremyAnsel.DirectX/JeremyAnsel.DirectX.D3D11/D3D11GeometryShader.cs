// <copyright file="D3D11GeometryShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A geometry shader interface manages an executable program (a geometry shader) that controls the geometry shader stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11GeometryShader : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11GeometryShaderGuid = typeof(ID3D11GeometryShader).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11GeometryShader* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11GeometryShader"/> class.
    /// </summary>
    public D3D11GeometryShader(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11GeometryShader**)comPtr;
    }
}
