// <copyright file="D3D11Texture2D.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A 2D texture interface manages texel data, which is structured memory.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Texture2D : D3D11Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11Texture2DGuid = typeof(ID3D11Texture2D).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Texture2D* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Texture2D"/> class.
    /// </summary>
    public D3D11Texture2D(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Texture2D**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Texture2D"/> class.
    /// </summary>
    /// <param name="resource">A ressource interface which implements the <c>ID3D11Texture2D</c> interface.</param>
    public static D3D11Texture2D CreateTexture2DFromRessource(DXComObject resource)
    {
        return CreateTexture2DFromRessource(resource.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Texture2D"/> class.
    /// </summary>
    /// <param name="resource">A ressource interface which implements the <c>ID3D11Texture2D</c> interface.</param>
    public static D3D11Texture2D CreateTexture2DFromRessource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, D3D11Texture2DGuid);
        return new D3D11Texture2D(ptr);
    }

    /// <summary>
    /// Gets the properties of the texture resource.
    /// </summary>
    public D3D11Texture2DDesc Description
    {
        get
        {
            int size = D3D11Texture2DDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11Texture2DDesc.NativeReadFrom((nint)ptr);
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
