// <copyright file="D3D11DepthStencilView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A depth-stencil-view interface accesses a texture resource during depth-stencil testing.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11DepthStencilView : D3D11View
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11DepthStencilViewGuid = typeof(ID3D11DepthStencilView).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11DepthStencilView* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11DepthStencilView"/> class.
    /// </summary>
    public D3D11DepthStencilView(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11DepthStencilView**)comPtr;
    }

    /// <summary>
    /// Gets the depth-stencil view.
    /// </summary>
    public D3D11DepthStencilViewDesc Description
    {
        get
        {
            int size = D3D11DepthStencilViewDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11DepthStencilViewDesc.NativeReadFrom((nint)ptr);
        }
    }
}
