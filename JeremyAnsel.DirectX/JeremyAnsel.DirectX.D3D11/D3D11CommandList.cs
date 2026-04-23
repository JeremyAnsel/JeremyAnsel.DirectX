// <copyright file="D3D11CommandList.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// Encapsulates a list of graphics commands for play back.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11CommandList : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11CommandListGuid = typeof(ID3D11CommandList).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11CommandList* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11CommandList"/> class.
    /// </summary>
    public D3D11CommandList(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11CommandList**)comPtr;
    }
}
