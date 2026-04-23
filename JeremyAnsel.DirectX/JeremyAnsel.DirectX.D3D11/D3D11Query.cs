// <copyright file="D3D11Query.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A query interface queries information from the GPU.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Query : D3D11Asynchronous
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11QueryGuid = typeof(ID3D11Query).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Query* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Query"/> class.
    /// </summary>
    public D3D11Query(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Query**)comPtr;
    }

    /// <summary>
    /// Gets a query description.
    /// </summary>
    public D3D11QueryDesc Description
    {
        get
        {
            int size = D3D11QueryDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11QueryDesc.NativeReadFrom((nint)ptr);
        }
    }
}
