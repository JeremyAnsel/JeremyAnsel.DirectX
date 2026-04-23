// <copyright file="D3D11InputLayout.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// An input-layout interface holds a definition of how to feed vertex data that is laid out in memory into the input-assembler stage of the graphics pipeline.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11InputLayout : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11InputLayoutGuid = typeof(ID3D11InputLayout).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11InputLayout* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11InputLayout"/> class.
    /// </summary>
    public D3D11InputLayout(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11InputLayout**)comPtr;
    }
}
