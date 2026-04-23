// <copyright file="D3D11Asynchronous.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.D3D11.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Security;

namespace JeremyAnsel.DirectX.D3D11;

/// <summary>
/// This interface encapsulates methods for retrieving data from the GPU asynchronously.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class D3D11Asynchronous : D3D11DeviceChild
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid D3D11AsynchronousGuid = typeof(ID3D11Asynchronous).GUID;

    private readonly nint _comPtr;
    private readonly ID3D11Asynchronous* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="D3D11Asynchronous"/> class.
    /// </summary>
    public D3D11Asynchronous(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(ID3D11Asynchronous**)comPtr;
    }

    /// <summary>
    /// Gets the size of the data (in bytes) that is output when calling <c>GetData</c>.
    /// </summary>
    public uint DataSize
    {
        get { return _comImpl->GetDataSize(_comPtr); }
    }
}
