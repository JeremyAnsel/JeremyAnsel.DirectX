// <copyright file="D3D11SamplerState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// The sampler-state interface holds a description for sampler state that you can bind to any shader stage of the pipeline for reference by texture sample operations.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11SamplerState : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11SamplerStateGuid = typeof(ID3D11SamplerState).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11SamplerState* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11SamplerState"/> class.
    /// </summary>
    public D3D11SamplerState(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11SamplerState**)comPtr;
    }

    /// <summary>
    /// Gets the description for sampler state that you used to create the sampler-state object.
    /// </summary>
    public D3D11SamplerDesc Description
    {
        get
        {
            int size = D3D11SamplerDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11SamplerDesc.NativeReadFrom((nint)ptr);
        }
    }
}
