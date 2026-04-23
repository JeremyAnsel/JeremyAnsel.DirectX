// <copyright file="D3D11BlendState.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using JeremyAnsel.DirectX.DXCommon;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// The blend-state interface holds a description for blending state that you can bind to the output-merger stage.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11BlendState : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11BlendStateGuid = typeof(ID3D11BlendState).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11BlendState* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11BlendState"/> class.
    /// </summary>
    public D3D11BlendState(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11BlendState**)comPtr;
    }

    /// <summary>
    /// Gets the description for blending state that you used to create the blend-state object.
    /// </summary>
    public D3D11BlendDesc Description
    {
        get
        {
            int size = D3D11BlendDesc.NativeRequiredSize();
            byte* ptr = stackalloc byte[size];
            _comImpl->GetDesc(_comPtr, ptr);
            return D3D11BlendDesc.NativeReadFrom((nint)ptr);
        }
    }
}
