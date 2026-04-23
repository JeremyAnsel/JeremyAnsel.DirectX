// <copyright file="D3D11Predicate.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// A predicate interface determines whether geometry should be processed depending on the results of a previous draw call.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Predicate : D3D11Query
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11PredicateGuid = typeof(ID3D11Predicate).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Predicate* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Predicate"/> class.
    /// </summary>
    public D3D11Predicate(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Predicate**)comPtr;
    }
}
