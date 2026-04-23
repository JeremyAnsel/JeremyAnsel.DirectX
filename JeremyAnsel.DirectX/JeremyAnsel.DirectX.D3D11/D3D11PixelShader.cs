// <copyright file="D3D11PixelShader.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A pixel shader interface manages an executable program (a pixel shader) that controls the pixel shader stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11PixelShader : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11PixelShaderGuid = typeof(ID3D11PixelShader).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11PixelShader* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11PixelShader"/> class.
    /// </summary>
    public D3D11PixelShader(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11PixelShader**)comPtr;
    }
}
