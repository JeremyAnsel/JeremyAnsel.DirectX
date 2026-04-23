// <copyright file="D3D11View.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A view interface specifies the parts of a resource the pipeline can access during rendering.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11View : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11ViewGuid = typeof(ID3D11View).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11View* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11View"/> class.
    /// </summary>
    public D3D11View(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11View**)comPtr;
    }

    /// <summary>
    /// Gets the resource that is accessed through this view.
    /// </summary>
    /// <returns>The resource that is accessed through this view.</returns>
    public D3D11Resource GetResource()
    {
        nint ptr;
        _comImpl->GetResource(_comPtr, &ptr);
        var resource = new D3D11Resource(ptr);
        D3D11ResourceDimension dimension = resource.Dimension;
        return dimension switch
        {
            D3D11ResourceDimension.Buffer => new D3D11Buffer(ptr),
            D3D11ResourceDimension.Texture1D => new D3D11Texture1D(ptr),
            D3D11ResourceDimension.Texture2D => new D3D11Texture2D(ptr),
            D3D11ResourceDimension.Texture3D => new D3D11Texture3D(ptr),
            _ => throw new IndexOutOfRangeException(nameof(dimension))
        };
    }
}
