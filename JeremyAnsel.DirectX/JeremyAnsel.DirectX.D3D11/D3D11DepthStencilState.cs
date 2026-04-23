// <copyright file="D3D11DepthStencilState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// The depth-stencil-state interface holds a description for depth-stencil state that you can bind to the output-merger stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11DepthStencilState : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11DepthStencilStateGuid = typeof(ID3D11DepthStencilState).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11DepthStencilState* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilState"/> class.
    /// </summary>
    public D3D11DepthStencilState(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11DepthStencilState**)comPtr;
    }

    /// <summary>
    /// Gets the description for depth-stencil state that you used to create the depth-stencil-state object.
    /// </summary>
    public D3D11DepthStencilDesc Description
    {
        get
        {
            int size = D3D11DepthStencilDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11DepthStencilDesc.NativeReadFrom((nint)ptr);
        }
    }
}
