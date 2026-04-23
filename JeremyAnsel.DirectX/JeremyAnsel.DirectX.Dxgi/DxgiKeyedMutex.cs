// <copyright file="DxgiKeyedMutex.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using JeremyAnsel.DirectX.Dxgi.ComInterfaces;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.DirectX.Dxgi;

/// <summary>
/// Represents a keyed mutex, which allows exclusive access to a shared resource that is used by multiple devices.
/// </summary>
[SecurityCritical, SuppressUnmanagedCodeSecurity]
[SkipLocalsInit]
public unsafe class DxgiKeyedMutex : DxgiDeviceSubObject
{
    /// <summary>
    /// The interface GUID.
    /// </summary>
    public static readonly Guid DxgiKeyedMutexGuid = typeof(IDxgiKeyedMutex).GUID;

    private readonly nint _comPtr;
    private readonly IDxgiKeyedMutex* _comImpl;

    /// <summary>
    /// Initializes a new instance of the <see cref="DxgiKeyedMutex"/> class.
    /// </summary>
    public DxgiKeyedMutex(nint comPtr)
        : base(comPtr)
    {
        _comPtr = comPtr;
        _comImpl = *(IDxgiKeyedMutex**)comPtr;
    }

    /// <summary>
    /// Using a key, acquires exclusive rendering access to a shared resource.
    /// </summary>
    /// <param name="key">A value that indicates which device to give access to.</param>
    /// <param name="milliseconds">The time-out interval, in milliseconds.</param>
    public void AcquireSync(ulong key, uint milliseconds)
    {
        int hr = _comImpl->AcquireSync(_comPtr, key, milliseconds);
        Marshal.ThrowExceptionForHR(hr);
    }

    /// <summary>
    /// Using a key, releases exclusive rendering access to a shared resource.
    /// </summary>
    /// <param name="key">A value that indicates which device to give access to.</param>
    public void ReleaseSync(ulong key)
    {
        int hr = _comImpl->ReleaseSync(_comPtr, key);
        Marshal.ThrowExceptionForHR(hr);
    }
}
