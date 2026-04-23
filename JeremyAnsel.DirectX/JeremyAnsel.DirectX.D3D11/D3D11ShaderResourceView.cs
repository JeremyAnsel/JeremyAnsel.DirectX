// <copyright file="D3D11ShaderResourceView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A shader-resource-view interface specifies the subresources a shader can access during rendering.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11ShaderResourceView : D3D11View
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11ShaderResourceViewGuid = typeof(ID3D11ShaderResourceView).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11ShaderResourceView* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11ShaderResourceView"/> class.
    /// </summary>
    public D3D11ShaderResourceView(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11ShaderResourceView**)comPtr;
    }

    /// <summary>
    /// Gets the shader resource view's description.
    /// </summary>
    public D3D11ShaderResourceViewDesc Description
    {
        get
        {
            int size = D3D11ShaderResourceViewDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11ShaderResourceViewDesc.NativeReadFrom((nint)ptr);
        }
    }
}
