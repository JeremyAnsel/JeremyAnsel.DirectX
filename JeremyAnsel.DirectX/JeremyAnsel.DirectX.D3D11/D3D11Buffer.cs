// <copyright file="D3D11Buffer.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using JeremyAnsel.DirectX.Dxgi;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A buffer interface accesses a buffer resource, which is unstructured memory.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Buffer : D3D11Resource
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11BufferGuid = typeof(ID3D11Buffer).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Buffer* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Buffer"/> class.
    /// </summary>
    public D3D11Buffer(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Buffer**)comPtr;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Buffer"/> class.
    /// </summary>
    /// <param name="resource">A ressource interface which implements the <c>ID3D11Buffer</c> interface.</param>
    public static D3D11Buffer CreateBufferFromRessource(DXComObject resource)
    {
        return CreateBufferFromRessource(resource.Handle);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Buffer"/> class.
    /// </summary>
    /// <param name="resource">A ressource interface which implements the <c>ID3D11Buffer</c> interface.</param>
    public static D3D11Buffer CreateBufferFromRessource(nint resource)
    {
        if (resource == 0)
        {
            throw new ArgumentNullException(nameof(resource));
        }

        nint ptr = DXUtils.QueryInterface(resource, D3D11BufferGuid);
        return new D3D11Buffer(ptr);
    }

    /// <summary>
    /// Gets the properties of a buffer resource.
    /// </summary>
    public D3D11BufferDesc Description
    {
        get
        {
            int size = D3D11BufferDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11BufferDesc.NativeReadFrom((nint)ptr);
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
