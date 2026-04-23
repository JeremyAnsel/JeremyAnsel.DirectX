// <copyright file="D3D11RasterizerState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// The rasterizer-state interface holds a description for rasterizer state that you can bind to the rasterizer stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11RasterizerState : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11RasterizerStateGuid = typeof(ID3D11RasterizerState).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11RasterizerState* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RasterizerState"/> class.
    /// </summary>
    public D3D11RasterizerState(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11RasterizerState**)comPtr;
    }

    /// <summary>
    /// Gets the description for rasterizer state that you used to create the rasterizer-state object.
    /// </summary>
    public D3D11RasterizerDesc Description
    {
        get
        {
            int size = D3D11RasterizerDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11RasterizerDesc.NativeReadFrom((nint)ptr);
        }
    }
}
