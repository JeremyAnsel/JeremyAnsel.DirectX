// <copyright file="DxgiDeviceSubObject.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Inherited from objects that are tied to the device so that they can retrieve a pointer to it.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiDeviceSubObject : DxgiObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiDeviceSubObjectGuid = typeof(IDxgiDeviceSubObject).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiDeviceSubObject* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiDeviceSubObject"/> class.
    /// </summary>
    public DxgiDeviceSubObject(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiDeviceSubObject**)comPtr;
    }

    /// <summary>
    /// Retrieves the device.
    /// </summary>
    /// <param name="riid">The reference id for the device.</param>
    /// <returns>The address of a pointer to the device.</returns>
    public nint GetDevice(in Guid riid)
    {
        nint ptr;
        int hr = _comImpl->GetDevice(_comPtr, riid, &ptr);
        Marshal.ThrowExceptionForHR(hr);
        return ptr;
    }
}
