// <copyright file="D3D11HullShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A hull shader interface manages an executable program (a hull shader) that controls the hull shader stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11HullShader : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11HullShaderGuid = typeof(ID3D11HullShader).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11HullShader* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11HullShader"/> class.
    /// </summary>
    public D3D11HullShader(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11HullShader**)comPtr;
    }
}
