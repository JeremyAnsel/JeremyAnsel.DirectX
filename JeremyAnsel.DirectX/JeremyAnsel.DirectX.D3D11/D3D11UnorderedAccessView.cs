// <copyright file="D3D11UnorderedAccessView.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A view interface specifies the parts of a resource the pipeline can access during rendering.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11UnorderedAccessView : D3D11View
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11UnorderedAccessViewGuid = typeof(ID3D11UnorderedAccessView).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11UnorderedAccessView* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11UnorderedAccessView"/> class.
    /// </summary>
    public D3D11UnorderedAccessView(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11UnorderedAccessView**)comPtr;
    }

    /// <summary>
    /// Gets a description of the resource.
    /// </summary>
    public D3D11UnorderedAccessViewDesc Description
    {
        get
        {
            int size = D3D11UnorderedAccessViewDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11UnorderedAccessViewDesc.NativeReadFrom((nint)ptr);
        }
    }
}
