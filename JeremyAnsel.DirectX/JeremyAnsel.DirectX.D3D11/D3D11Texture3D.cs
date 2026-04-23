// <copyright file="D3D11Texture3D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A 3D texture interface accesses texel data, which is structured memory.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Texture3D : D3D11Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11Texture3DGuid = typeof(ID3D11Texture3D).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Texture3D* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Texture3D"/> class.
    /// </summary>
    public D3D11Texture3D(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Texture3D**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Texture3D"/> class.
    /// </summary>
    /// <param name="resource">A ressource interface which implements the <c>ID3D11Texture3D</c> interface.</param>
    public static D3D11Texture3D CreateTexture3DFromRessource(DXComObject resource)
    {
        return CreateTexture3DFromRessource(resource.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Texture3D"/> class.
    /// </summary>
    /// <param name="resource">A ressource interface which implements the <c>ID3D11Texture3D</c> interface.</param>
    public static D3D11Texture3D CreateTexture3DFromRessource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, D3D11Texture3DGuid);
        return new D3D11Texture3D(ptr);
    }

    /// <summary>
    /// Gets the properties of the texture resource.
    /// </summary>
    public D3D11Texture3DDesc Description
    {
        get
        {
            int size = D3D11Texture3DDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11Texture3DDesc.NativeReadFrom((nint)ptr);
        }
    }

    /// <summary>
    /// Gets the handle to a shared resource.
    /// </summary>
    /// <returns>A handle.</returns>
    public nint GetSharedHandle()
    {
        nint ptr = QueryInterface(DxgiResource.DxgiResourceGuid);
        using var resource = new DxgiResource(ptr);
        nint handle = resource.GetSharedHandle();
        return handle;
    }
}
