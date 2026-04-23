// <copyright file="IDxgiKeyedMutex.cs" company="Jérémy Ansel">
// Copyright (c) 2014-2026 Jérémy Ansel
// </copyright>

using System.Runtime.InteropServices;

namespace JeremyAnsel.DirectX.Dxgi.ComInterfaces;

/// <summary>
/// Represents a keyed mutex, which allows exclusive access to a shared resource that is used by multiple devices.
/// </summary>
/// <remarks>Inherited from <see cref="IDxgiDeviceSubObject"/></remarks>
[Guid("9d8e1289-d7b3-465f-8126-250e349af85d")]
internal unsafe readonly struct IDxgiKeyedMutex
{
    private readonly nint QueryInterface;
    private readonly nint AddRef;
    private readonly nint Release;
    private readonly nint SetPrivateData;
    private readonly nint SetPrivateDataInterface;
    private readonly nint GetPrivateData;
    private readonly nint GetParent;
    private readonly nint GetDevice;

    /// <summary>
    /// Using a key, acquires exclusive rendering access to a shared resource.
    /// </summary>
    /// <param name="key">A value that indicates which device to give access to.</param>
    /// <param name="milliseconds">The time-out interval, in milliseconds.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, ulong, uint, int> AcquireSync;

    /// <summary>
    /// Using a key, releases exclusive rendering access to a shared resource.
    /// </summary>
    /// <param name="key">A value that indicates which device to give access to.</param>
    public readonly delegate* unmanaged[Stdcall]<nint, ulong, int> ReleaseSync;
}
