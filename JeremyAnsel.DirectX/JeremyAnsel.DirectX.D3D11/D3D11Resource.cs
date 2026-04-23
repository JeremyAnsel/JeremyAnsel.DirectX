// <copyright file="D3D11Resource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A resource interface provides common actions on all resources.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Resource : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11ResourceGuid = typeof(ID3D11Resource).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Resource* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Resource"/> class.
    /// </summary>
    public D3D11Resource(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Resource**)comPtr;
    }

    /// <summary>
    /// Gets the type of the resource.
    /// </summary>
    public D3D11ResourceDimension Dimension
    {
        get
        {
            D3D11ResourceDimension value;
            _comImpl->GetDimension(_comPtr, &value);
            return value;
        }
    }

    /// <summary>
    /// Gets or sets the eviction priority of a resource.
    /// </summary>
    public DxgiResourceEvictionPriority EvictionPriority
    {
        get
        {
            return _comImpl->GetEvictionPriority(_comPtr);
        }

        set
        {
            _comImpl->SetEvictionPriority(_comPtr, value);
        }
    }
}
