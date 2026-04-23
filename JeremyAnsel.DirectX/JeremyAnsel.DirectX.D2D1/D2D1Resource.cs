// <copyright file="D2D1Resource.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D2D1.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D2D1;

/// <summary>
/// The root interface for all resources in D2D.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D2D1Resource : DXComObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D2D1ResourceGuid = typeof(ID2D1Resource).GUID;

    private readonly nint _comPtr;
    private readonly ID2D1Resource* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D2D1Resource"/> class.
    /// </summary>
    public D2D1Resource(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID2D1Resource**)comPtr;
    }

    /// <summary>
    /// Retrieve the factory associated with this resource.
    /// </summary>
    /// <returns>The factory that created this resource.</returns>
    public D2D1Factory GetFactory()
    {
        nint ptr;
        _comImpl->GetFactory(_comPtr, &ptr);
        return new D2D1Factory(ptr);
    }
}
