// <copyright file="D3D11Counter.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// This interface encapsulates methods for measuring GPU performance.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Counter : D3D11Asynchronous
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11CounterGuid = typeof(ID3D11Counter).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Counter* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Counter"/> class.
    /// </summary>
    public D3D11Counter(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Counter**)comPtr;
    }

    /// <summary>
    /// Gets a counter description.
    /// </summary>
    public D3D11CounterDesc Description
    {
        get
        {
            int size = D3D11CounterDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11CounterDesc.NativeReadFrom((nint)ptr);
        }
    }
}
