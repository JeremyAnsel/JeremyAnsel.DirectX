// <copyright file="D3D11RenderTargetView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A render-target-view interface identifies the render-target subresources that can be accessed during rendering.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11RenderTargetView : D3D11View
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11RenderTargetViewGuid = typeof(ID3D11RenderTargetView).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11RenderTargetView* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11RenderTargetView"/> class.
    /// </summary>
    public D3D11RenderTargetView(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11RenderTargetView**)comPtr;
    }

    /// <summary>
    /// Gets the properties of a render target view.
    /// </summary>
    public D3D11RenderTargetViewDesc Description
    {
        get
        {
            int size = D3D11RenderTargetViewDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11RenderTargetViewDesc.NativeReadFrom((nint)ptr);
        }
    }
}
